namespace AgilityTools.View.Receiving
{
    partial class F_EditPalletInbound
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_EditPalletInbound));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.txt_Receiptkey = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.txt_PalletID = new System.Windows.Forms.ToolStripTextBox();
            this.btn_Show = new System.Windows.Forms.ToolStripButton();
            this.Btn_Del = new System.Windows.Forms.ToolStripButton();
            this.Dgs_Unloaddetails = new System.Windows.Forms.DataGridView();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgs_Unloaddetails)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.txt_Receiptkey,
            this.toolStripLabel1,
            this.txt_PalletID,
            this.btn_Show,
            this.Btn_Del});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1312, 34);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(81, 31);
            this.toolStripLabel2.Text = "Receiptkey";
            // 
            // txt_Receiptkey
            // 
            this.txt_Receiptkey.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txt_Receiptkey.Name = "txt_Receiptkey";
            this.txt_Receiptkey.Size = new System.Drawing.Size(200, 34);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(60, 31);
            this.toolStripLabel1.Text = "PalletID";
            // 
            // txt_PalletID
            // 
            this.txt_PalletID.Name = "txt_PalletID";
            this.txt_PalletID.Size = new System.Drawing.Size(200, 34);
            // 
            // btn_Show
            // 
            this.btn_Show.Image = global::AgilityTools.Properties.Resources.find;
            this.btn_Show.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Show.Name = "btn_Show";
            this.btn_Show.Size = new System.Drawing.Size(69, 31);
            this.btn_Show.Text = "Show";
            this.btn_Show.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // Btn_Del
            // 
            this.Btn_Del.Image = global::AgilityTools.Properties.Resources.delete;
            this.Btn_Del.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Btn_Del.Name = "Btn_Del";
            this.Btn_Del.Size = new System.Drawing.Size(77, 31);
            this.Btn_Del.Text = "Delete";
            this.Btn_Del.Click += new System.EventHandler(this.Btn_Del_Click);
            // 
            // Dgs_Unloaddetails
            // 
            this.Dgs_Unloaddetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgs_Unloaddetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Dgs_Unloaddetails.Location = new System.Drawing.Point(0, 34);
            this.Dgs_Unloaddetails.Name = "Dgs_Unloaddetails";
            this.Dgs_Unloaddetails.RowTemplate.Height = 24;
            this.Dgs_Unloaddetails.Size = new System.Drawing.Size(1312, 518);
            this.Dgs_Unloaddetails.TabIndex = 1;
            // 
            // F_EditPalletInbound
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1312, 552);
            this.Controls.Add(this.Dgs_Unloaddetails);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "F_EditPalletInbound";
            this.Text = "Edit Contains Inbound";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgs_Unloaddetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.DataGridView Dgs_Unloaddetails;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox txt_Receiptkey;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox txt_PalletID;
        private System.Windows.Forms.ToolStripButton btn_Show;
        private System.Windows.Forms.ToolStripButton Btn_Del;
    }
}