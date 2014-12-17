namespace StockMarketTester
{
    partial class Form1
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
            this.stockLastDate = new System.Windows.Forms.DateTimePicker();
            this.lowDays = new System.Windows.Forms.Label();
            this.highDays = new System.Windows.Forms.Label();
            this.minAverageTextBox = new System.Windows.Forms.TextBox();
            this.maxAverageTextBox = new System.Windows.Forms.TextBox();
            this.rTBResults = new System.Windows.Forms.RichTextBox();
            this.rBClear = new System.Windows.Forms.RadioButton();
            this.btnSavefile = new System.Windows.Forms.Button();
            this.btnSaveXls = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.cbChoices = new System.Windows.Forms.ComboBox();
            this.Compare = new System.Windows.Forms.Button();
            this.dPickDate2 = new System.Windows.Forms.DateTimePicker();
            this.cBRange = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // stockLastDate
            // 
            this.stockLastDate.Location = new System.Drawing.Point(12, 65);
            this.stockLastDate.Name = "stockLastDate";
            this.stockLastDate.Size = new System.Drawing.Size(212, 20);
            this.stockLastDate.TabIndex = 0;
            // 
            // lowDays
            // 
            this.lowDays.AutoSize = true;
            this.lowDays.Location = new System.Drawing.Point(15, 124);
            this.lowDays.Name = "lowDays";
            this.lowDays.Size = new System.Drawing.Size(75, 13);
            this.lowDays.TabIndex = 1;
            this.lowDays.Text = "Minimum Days";
            // 
            // highDays
            // 
            this.highDays.AutoSize = true;
            this.highDays.Location = new System.Drawing.Point(12, 178);
            this.highDays.Name = "highDays";
            this.highDays.Size = new System.Drawing.Size(78, 13);
            this.highDays.TabIndex = 2;
            this.highDays.Text = "Maximum Days";
            // 
            // minAverageTextBox
            // 
            this.minAverageTextBox.Location = new System.Drawing.Point(141, 117);
            this.minAverageTextBox.Name = "minAverageTextBox";
            this.minAverageTextBox.Size = new System.Drawing.Size(27, 20);
            this.minAverageTextBox.TabIndex = 3;
            // 
            // maxAverageTextBox
            // 
            this.maxAverageTextBox.Location = new System.Drawing.Point(141, 171);
            this.maxAverageTextBox.Name = "maxAverageTextBox";
            this.maxAverageTextBox.Size = new System.Drawing.Size(27, 20);
            this.maxAverageTextBox.TabIndex = 4;
            // 
            // rTBResults
            // 
            this.rTBResults.Location = new System.Drawing.Point(330, 35);
            this.rTBResults.Name = "rTBResults";
            this.rTBResults.Size = new System.Drawing.Size(303, 217);
            this.rTBResults.TabIndex = 8;
            this.rTBResults.Text = "";
            // 
            // rBClear
            // 
            this.rBClear.AutoSize = true;
            this.rBClear.Location = new System.Drawing.Point(330, 15);
            this.rBClear.Name = "rBClear";
            this.rBClear.Size = new System.Drawing.Size(49, 17);
            this.rBClear.TabIndex = 9;
            this.rBClear.TabStop = true;
            this.rBClear.Text = "Clear";
            this.rBClear.UseVisualStyleBackColor = true;
            this.rBClear.CheckedChanged += new System.EventHandler(this.rBClear_CheckedChanged);
            // 
            // btnSavefile
            // 
            this.btnSavefile.Location = new System.Drawing.Point(424, 258);
            this.btnSavefile.Name = "btnSavefile";
            this.btnSavefile.Size = new System.Drawing.Size(75, 23);
            this.btnSavefile.TabIndex = 10;
            this.btnSavefile.Text = "Save";
            this.btnSavefile.UseVisualStyleBackColor = true;
            this.btnSavefile.Click += new System.EventHandler(this.btnSavefile_Click);
            // 
            // btnSaveXls
            // 
            this.btnSaveXls.Location = new System.Drawing.Point(530, 258);
            this.btnSaveXls.Name = "btnSaveXls";
            this.btnSaveXls.Size = new System.Drawing.Size(75, 23);
            this.btnSaveXls.TabIndex = 11;
            this.btnSaveXls.Text = "Save as ";
            this.btnSaveXls.UseVisualStyleBackColor = true;
            this.btnSaveXls.Click += new System.EventHandler(this.btnSaveXls_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(588, 6);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 12;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // cbChoices
            // 
            this.cbChoices.FormattingEnabled = true;
            this.cbChoices.Location = new System.Drawing.Point(12, 8);
            this.cbChoices.Name = "cbChoices";
            this.cbChoices.Size = new System.Drawing.Size(121, 21);
            this.cbChoices.TabIndex = 13;
            this.cbChoices.Text = "Select";
            // 
            // Compare
            // 
            this.Compare.Location = new System.Drawing.Point(111, 212);
            this.Compare.Name = "Compare";
            this.Compare.Size = new System.Drawing.Size(75, 23);
            this.Compare.TabIndex = 5;
            this.Compare.Text = "Show result";
            this.Compare.UseVisualStyleBackColor = true;
            this.Compare.Click += new System.EventHandler(this.Compare_Click);
            // 
            // dPickDate2
            // 
            this.dPickDate2.Location = new System.Drawing.Point(12, 91);
            this.dPickDate2.Name = "dPickDate2";
            this.dPickDate2.Size = new System.Drawing.Size(200, 20);
            this.dPickDate2.TabIndex = 14;
            this.dPickDate2.Visible = false;
            // 
            // cBRange
            // 
            this.cBRange.AutoSize = true;
            this.cBRange.Location = new System.Drawing.Point(15, 35);
            this.cBRange.Name = "cBRange";
            this.cBRange.Size = new System.Drawing.Size(278, 17);
            this.cBRange.TabIndex = 15;
            this.cBRange.Text = "Do you want to check your data on a Range of dates";
            this.cBRange.UseVisualStyleBackColor = true;
            this.cBRange.CheckedChanged += new System.EventHandler(this.cBRange_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 333);
            this.Controls.Add(this.cBRange);
            this.Controls.Add(this.dPickDate2);
            this.Controls.Add(this.cbChoices);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnSaveXls);
            this.Controls.Add(this.btnSavefile);
            this.Controls.Add(this.rBClear);
            this.Controls.Add(this.rTBResults);
            this.Controls.Add(this.Compare);
            this.Controls.Add(this.maxAverageTextBox);
            this.Controls.Add(this.minAverageTextBox);
            this.Controls.Add(this.highDays);
            this.Controls.Add(this.lowDays);
            this.Controls.Add(this.stockLastDate);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker stockLastDate;
        private System.Windows.Forms.Label lowDays;
        private System.Windows.Forms.Label highDays;
        private System.Windows.Forms.TextBox minAverageTextBox;
        private System.Windows.Forms.TextBox maxAverageTextBox;
        private System.Windows.Forms.RichTextBox rTBResults;
        private System.Windows.Forms.RadioButton rBClear;
        private System.Windows.Forms.Button btnSavefile;
        private System.Windows.Forms.Button btnSaveXls;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.ComboBox cbChoices;
        private System.Windows.Forms.Button Compare;
        private System.Windows.Forms.DateTimePicker dPickDate2;
        private System.Windows.Forms.CheckBox cBRange;
    }
}

