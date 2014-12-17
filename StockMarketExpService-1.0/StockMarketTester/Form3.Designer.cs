namespace StockMarketTester
{
    partial class Form3
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
            this.cbNew = new System.Windows.Forms.CheckBox();
            this.tbAddNew = new System.Windows.Forms.TextBox();
            this.cbOld = new System.Windows.Forms.ComboBox();
            this.btnUpload = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbNew
            // 
            this.cbNew.AutoSize = true;
            this.cbNew.Location = new System.Drawing.Point(46, 26);
            this.cbNew.Name = "cbNew";
            this.cbNew.Size = new System.Drawing.Size(100, 17);
            this.cbNew.TabIndex = 0;
            this.cbNew.Text = "Add new share ";
            this.cbNew.UseVisualStyleBackColor = true;
            this.cbNew.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // tbAddNew
            // 
            this.tbAddNew.Location = new System.Drawing.Point(46, 68);
            this.tbAddNew.Name = "tbAddNew";
            this.tbAddNew.Size = new System.Drawing.Size(100, 20);
            this.tbAddNew.TabIndex = 1;
            this.tbAddNew.Visible = false;
            this.tbAddNew.TextChanged += new System.EventHandler(this.tbAddNew_TextChanged);
            // 
            // cbOld
            // 
            this.cbOld.FormattingEnabled = true;
            this.cbOld.Location = new System.Drawing.Point(46, 68);
            this.cbOld.Name = "cbOld";
            this.cbOld.Size = new System.Drawing.Size(121, 21);
            this.cbOld.TabIndex = 2;
            this.cbOld.Text = "Select The Stock";
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(92, 159);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(75, 23);
            this.btnUpload.TabIndex = 3;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(231, 2);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(41, 23);
            this.btnBack.TabIndex = 4;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.cbOld);
            this.Controls.Add(this.tbAddNew);
            this.Controls.Add(this.cbNew);
            this.Name = "Form3";
            this.Text = "Form3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbNew;
        private System.Windows.Forms.TextBox tbAddNew;
        private System.Windows.Forms.ComboBox cbOld;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Button btnBack;

    }
}