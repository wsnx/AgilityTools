namespace AgilityTools
{
    partial class frmCreatePlan
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Table_Name = new System.Windows.Forms.Label();
            this.Sheet_Name = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(69, 33);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 48);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(177, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // Table_Name
            // 
            this.Table_Name.AutoSize = true;
            this.Table_Name.Location = new System.Drawing.Point(177, 132);
            this.Table_Name.Name = "Table_Name";
            this.Table_Name.Size = new System.Drawing.Size(46, 17);
            this.Table_Name.TabIndex = 2;
            this.Table_Name.Text = "label2";
            // 
            // Sheet_Name
            // 
            this.Sheet_Name.AutoSize = true;
            this.Sheet_Name.Location = new System.Drawing.Point(177, 88);
            this.Sheet_Name.Name = "Sheet_Name";
            this.Sheet_Name.Size = new System.Drawing.Size(46, 17);
            this.Sheet_Name.TabIndex = 3;
            this.Sheet_Name.Text = "label3";
            // 
            // frmCreatePlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 618);
            this.Controls.Add(this.Sheet_Name);
            this.Controls.Add(this.Table_Name);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "frmCreatePlan";
            this.Text = "CreatePlan";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Table_Name;
        private System.Windows.Forms.Label Sheet_Name;
    }
}