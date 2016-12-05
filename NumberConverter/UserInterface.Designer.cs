namespace NumberConverter
{
    partial class UserInterface
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.DecimalValue = new System.Windows.Forms.TextBox();
            this.BinaryValue = new System.Windows.Forms.TextBox();
            this.OctalValue = new System.Windows.Forms.TextBox();
            this.HexValue = new System.Windows.Forms.TextBox();
            this.ValueType = new System.Windows.Forms.ComboBox();
            this.CalculateBttn = new System.Windows.Forms.Button();
            this.StatusReport = new System.Windows.Forms.Label();
            this.ClearBttn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(18, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Decimal";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(18, 88);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Octal";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(18, 124);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Hexadecimal";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(18, 52);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 23);
            this.label4.TabIndex = 3;
            this.label4.Text = "Binary";
            // 
            // DecimalValue
            // 
            this.DecimalValue.Location = new System.Drawing.Point(190, 16);
            this.DecimalValue.Margin = new System.Windows.Forms.Padding(4);
            this.DecimalValue.MaxLength = 20;
            this.DecimalValue.Name = "DecimalValue";
            this.DecimalValue.Size = new System.Drawing.Size(520, 26);
            this.DecimalValue.TabIndex = 4;
            // 
            // BinaryValue
            // 
            this.BinaryValue.Location = new System.Drawing.Point(190, 52);
            this.BinaryValue.Margin = new System.Windows.Forms.Padding(4);
            this.BinaryValue.MaxLength = 64;
            this.BinaryValue.Name = "BinaryValue";
            this.BinaryValue.Size = new System.Drawing.Size(520, 26);
            this.BinaryValue.TabIndex = 5;
            // 
            // OctalValue
            // 
            this.OctalValue.Location = new System.Drawing.Point(190, 88);
            this.OctalValue.Margin = new System.Windows.Forms.Padding(4);
            this.OctalValue.MaxLength = 22;
            this.OctalValue.Name = "OctalValue";
            this.OctalValue.Size = new System.Drawing.Size(520, 26);
            this.OctalValue.TabIndex = 6;
            // 
            // HexValue
            // 
            this.HexValue.Location = new System.Drawing.Point(190, 124);
            this.HexValue.Margin = new System.Windows.Forms.Padding(4);
            this.HexValue.MaxLength = 16;
            this.HexValue.Name = "HexValue";
            this.HexValue.Size = new System.Drawing.Size(520, 26);
            this.HexValue.TabIndex = 7;
            // 
            // ValueType
            // 
            this.ValueType.FormattingEnabled = true;
            this.ValueType.Items.AddRange(new object[] {
            "Decimal",
            "Binary",
            "Octal",
            "Hexadecimal"});
            this.ValueType.Location = new System.Drawing.Point(22, 171);
            this.ValueType.Margin = new System.Windows.Forms.Padding(4);
            this.ValueType.Name = "ValueType";
            this.ValueType.Size = new System.Drawing.Size(301, 26);
            this.ValueType.TabIndex = 8;
            this.ValueType.Text = "Please choose the starting format";
            this.ValueType.SelectedIndexChanged += new System.EventHandler(this.startValueType_SelectedIndexChanged);
            // 
            // CalculateBttn
            // 
            this.CalculateBttn.Location = new System.Drawing.Point(330, 170);
            this.CalculateBttn.Name = "CalculateBttn";
            this.CalculateBttn.Size = new System.Drawing.Size(186, 26);
            this.CalculateBttn.TabIndex = 9;
            this.CalculateBttn.Text = "Calculate";
            this.CalculateBttn.UseVisualStyleBackColor = true;
            this.CalculateBttn.Click += new System.EventHandler(this.CalculateBttn_Click);
            // 
            // StatusReport
            // 
            this.StatusReport.AutoSize = true;
            this.StatusReport.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.StatusReport.Location = new System.Drawing.Point(18, 211);
            this.StatusReport.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.StatusReport.Name = "StatusReport";
            this.StatusReport.Size = new System.Drawing.Size(101, 19);
            this.StatusReport.TabIndex = 10;
            this.StatusReport.Text = "Status report";
            // 
            // ClearBttn
            // 
            this.ClearBttn.Location = new System.Drawing.Point(524, 170);
            this.ClearBttn.Name = "ClearBttn";
            this.ClearBttn.Size = new System.Drawing.Size(186, 26);
            this.ClearBttn.TabIndex = 11;
            this.ClearBttn.Text = "Clear";
            this.ClearBttn.UseVisualStyleBackColor = true;
            this.ClearBttn.Click += new System.EventHandler(this.ClearBttn_Click);
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 243);
            this.Controls.Add(this.ClearBttn);
            this.Controls.Add(this.StatusReport);
            this.Controls.Add(this.CalculateBttn);
            this.Controls.Add(this.ValueType);
            this.Controls.Add(this.HexValue);
            this.Controls.Add(this.OctalValue);
            this.Controls.Add(this.BinaryValue);
            this.Controls.Add(this.DecimalValue);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UserInterface";
            this.Text = "Number Converter";
            this.Load += new System.EventHandler(this.UserInterface_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox DecimalValue;
        private System.Windows.Forms.TextBox BinaryValue;
        private System.Windows.Forms.TextBox OctalValue;
        private System.Windows.Forms.TextBox HexValue;
        private System.Windows.Forms.ComboBox ValueType;
        private System.Windows.Forms.Button CalculateBttn;
        private System.Windows.Forms.Label StatusReport;
        private System.Windows.Forms.Button ClearBttn;
    }
}

