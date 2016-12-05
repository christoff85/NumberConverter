/**
 *  NumberConverter project
 *  Made by Krzysztof Grzeslak 05.12.2016
 * 
 *  This is my final project for the CS50: Introduction to Computer Science MOOC.
 *  
 *  Program purpose is to convert between four number bases: Binary, Octal, Decimal and Hexadecimal
 *  It includes simple User Interface based on the Windows Form
 *  User receives status reports, if any error occurs.
 *  
 *  Note: I'm aware, that C# Libraries include methods, that would made this project much simpler.
 *  But it was done the hard way (or reinventing the wheel way) for the educational purpose.
 */

using System;
using System.Text;
using System.Windows.Forms;

namespace NumberConverter
{
    enum status { noSource, noValue, wrongValue, reset, tooBigValue }
    enum maxValIndex { maxDecimal, maxBinary, maxOctal, maxHex, Size }
    enum numberType { n_decimal, n_binary, n_octal, n_hex }

    struct sourceValue
    {
        public readonly string Text;
        public readonly uint Divider;

        public sourceValue(string text, uint divider) : this ()
        {
            Text = text;
            Divider = divider;
        }
    }

    public partial class UserInterface : Form
    {
        TextBox[] x_valueBoxes;
        string[] x_maxValues; // [maxDecimal, maxBinary, maxOctal, maxHex]
        Control x_activeControl;

        public UserInterface()
        {
            InitializeComponent();
            TextBox[] valueBoxes = { DecimalValue, BinaryValue, OctalValue, HexValue };
            x_valueBoxes = valueBoxes;
        }
        
        private void UserInterface_Load(object sender, EventArgs e)
        {
            initializeUI();
        }

        private void ClearBttn_Click(object sender, EventArgs e)
        {
            clearValues();
        }

        // Ensure user can only input selected source value
        private void startValueType_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshForm(ValueType.Text);
        }

        private void CalculateBttn_Click(object sender, EventArgs e)
        {
            try
            {
                if (x_activeControl.Text == "")
                {
                    statusUpdate(status.noValue);
                }
                else
                {
                    statusUpdate(status.reset);
                    string valType = ValueType.Text;
                    convert(valType);
                }

            }
            catch(System.OverflowException)
            {
                string valType = ValueType.Text;
                reportBadValue(status.tooBigValue, valType);
            }
        }

        // Main calculation roadmap
        private void convert(string valType)
        {
            sourceValue srcVal;
            switch (valType)
            {
                case "Binary":
                    srcVal = new sourceValue(BinaryValue.Text, 2);
                    break;

                case "Octal":
                    srcVal = new sourceValue(OctalValue.Text, 8);
                    break;

                case "Decimal":
                    srcVal = new sourceValue(DecimalValue.Text, 10);
                    break;

                case "Hexadecimal":
                    srcVal = new sourceValue(HexValue.Text.ToUpper(), 16);
                    break;

                default:
                    statusUpdate(status.noSource);
                    return;
            }

            if (isValueValid(srcVal.Text, srcVal.Divider))
            {
                string decVal = toDecimal(srcVal.Text, srcVal.Divider);
                returnValues(decVal);
            }
            else
            {
                reportBadValue(status.wrongValue, valType);
            }
            this.ActiveControl = x_activeControl;
        }

        // Convert decimal number to other types. Reports false, if user input has incorrect format
        private void returnValues(string decVal)
        {
            DecimalValue.Text = decVal;
            BinaryValue.Text = fromDecimal(decVal, 2);
            OctalValue.Text = fromDecimal(decVal, 8);
            HexValue.Text = fromDecimal(decVal, 16);
        }
        
        private void reportBadValue(status errorType, string valType)
        {
            statusUpdate(errorType, valType);
            string curText = x_activeControl.Text;
            clearValues();
            x_activeControl.Text = curText;
        }

        // checks the decimal number for invalid characters
        // divider: 2 for binary, 8 for octal, 10 for decimal and 16 for hex
        private bool isValueValid(string input, uint divider)
        {
            bool isValid = true;
            bool isHex = false;
            char max = '\0';

            if (divider < 10)
            {
                max = Convert.ToChar((uint)'0' + divider - 1);
            }
            else
            {
                max = '9';
                isHex = true;
            }

            // Check if each character is valid
            foreach (char c in input)
            {
                if (max == '\0' || c < '0' || c > max)
                {
                    if (isHex && c >= 'A' && c <= 'F')
                    {
                        // do nothing
                    }
                    else
                    {
                        isValid = false;
                    }
                } 
            }
            return isValid;
        }
        
        // Converts decimal number, based on the given divider
        private string fromDecimal(string decimalValue, uint divider)
        {
            StringBuilder newValue = new StringBuilder("");
            ulong decValue = ulong.Parse(decimalValue);
            uint nextDigit = 0;
            do
            {
                nextDigit = (uint)(decValue % (divider));
                if (nextDigit > 9)
                {
                    newValue.Insert(0, toHexLetter(nextDigit));
                }
                else
                {
                    newValue.Insert(0, nextDigit);
                }
                decValue /= divider;
            }
            while (decValue > 0);
            return newValue.ToString();
        }

        // Converts other number types to decimal number
        private string toDecimal(string curVal, uint numberBase)
        {
            // check if value is already decimal
            if (numberBase == 10)
            {
                return curVal;
            }

            ulong decValue = 0;
            uint nextDigit = 0;

            // Process each digit
            for (int i = curVal.Length - 1, j = 0; i >= 0; i--, j++)
            {
                nextDigit = getNextDigit(curVal[i]);
                checked
                {
                    decValue += (ulong)nextDigit * (ulong)Math.Pow(numberBase, (double)j);
                }
            }

            return decValue.ToString();
        }

        // Determine next digit
        private uint getNextDigit (char nextChar)
        {
            uint nextDigit = 0;
            // check if digit is hex bigger than 9
            if (nextChar >= 'A' && nextChar <= 'F')
            {
                nextDigit = fromHexLetter(nextChar);
            }
            else
            {
                nextDigit = (uint)Char.GetNumericValue(nextChar);
            }
            return nextDigit;
        }

        // Converts 10-15 digits to A-F
        private char toHexLetter(uint digit)
        {
            char retVal = Convert.ToChar(Convert.ToInt32('A') + digit - 10);
            return retVal;
        }

        // Converts A-F to 10-15 digits
        private uint fromHexLetter(char hexDigit)
        {
            char retVal = Convert.ToChar(Convert.ToInt32(hexDigit - 'A') +  10);
            return retVal;
        }

        // unlock the field for selected input value type
        private void refreshForm(string valType)
        {
            lockAllFields();
            clearValues();

            TextBox activeBox = null;
            switch (valType)
            {
                case "Decimal":
                    activeBox = DecimalValue;
                    break;

                case "Binary":
                    activeBox = BinaryValue;
                    break;

                case "Octal":
                    activeBox = OctalValue;
                    break;

                case "Hexadecimal":
                    activeBox = HexValue;
                    break;

                default:
                    // do nothing
                    break;
            }
            activeBox.ReadOnly = false;
            x_activeControl = activeBox;
            this.ActiveControl = x_activeControl;
        }

        private void initializeUI()
        {
            setMaxValues();
            lockAllFields();
            this.ActiveControl = ValueType;
            x_activeControl = this.ActiveControl;
            statusUpdate(status.noSource);
        }

        private void clearValues()
        {
            foreach(TextBox valueBox in x_valueBoxes)
            {
                valueBox.Text = "";
            }
            this.ActiveControl = x_activeControl;
        }

        private void lockAllFields()
        {
            foreach (TextBox valueBox in x_valueBoxes)
            {
                valueBox.ReadOnly = true;
            }
        }

        // Provides error feedback to the user
        private void statusUpdate(status state, string numberType = "")
        {
            string message = "";
            switch (state)
            {
                case status.wrongValue:
                    message = String.Format("{0} number is not valid. Please try again.", numberType);
                    break;

                case status.noValue:
                    message = "Please input number to convert";
                    break;

                case status.noSource:
                    message = "Please choose the source format";
                    break;

                case status.tooBigValue:
                    string maxValue = getMaxValue(numberType);
                    message = String.Format( "Max value is : {0}", maxValue);
                    break;

                default:
                case status.reset:
                    message = "";
                    break;
            }

            StatusReport.Text = message;
        }

        // Determine max value for each number type
        private void setMaxValues()
        {
            string maxDecimal = ulong.MaxValue.ToString();
            string[] maxValues = new string[(int)maxValIndex.Size];
            maxValues[(int)maxValIndex.maxDecimal] = maxDecimal;
            maxValues[(int)maxValIndex.maxBinary] = fromDecimal(maxDecimal, 2).ToString();
            maxValues[(int)maxValIndex.maxOctal] = fromDecimal(maxDecimal, 8).ToString();
            maxValues[(int)maxValIndex.maxHex] = fromDecimal(maxDecimal, 16).ToString();

            x_maxValues = maxValues;
        }

        string getMaxValue(string valType)
        {
            string maxValue = "";
            switch (valType)
            {
                case "Decimal":
                    maxValue = x_maxValues[(int)maxValIndex.maxDecimal];
                    break;

                case "Binary":
                    maxValue = x_maxValues[(int)maxValIndex.maxBinary];
                    break;

                case "Octal":
                    maxValue = x_maxValues[(int)maxValIndex.maxOctal];
                    break;

                case "Hexadecimal":
                    maxValue = x_maxValues[(int)maxValIndex.maxHex];
                    break;
            }
            return maxValue;
        }
    }
}