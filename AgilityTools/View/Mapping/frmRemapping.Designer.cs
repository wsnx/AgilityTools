namespace AgilityTools
{
    partial class frmRemapping
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRemapping));
            this.dgsReprintdetails = new ADGV.AdvancedDataGridView();
            this.dgsBindingReprint = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgsReprintdetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgsBindingReprint)).BeginInit();
            this.SuspendLayout();
            // 
            // dgsReprintdetails
            // 
            this.dgsReprintdetails.AutoGenerateContextFilters = true;
            this.dgsReprintdetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgsReprintdetails.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.dgsReprintdetails.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgsReprintdetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgsReprintdetails.DateWithTime = false;
            this.dgsReprintdetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgsReprintdetails.Location = new System.Drawing.Point(0, 0);
            this.dgsReprintdetails.Name = "dgsReprintdetails";
            this.dgsReprintdetails.RowTemplate.Height = 24;
            this.dgsReprintdetails.Size = new System.Drawing.Size(1546, 667);
            this.dgsReprintdetails.TabIndex = 0;
            this.dgsReprintdetails.TimeFilter = false;
            this.dgsReprintdetails.SortStringChanged += new System.EventHandler(this.dgsReprintdetails_SortStringChanged);
            this.dgsReprintdetails.FilterStringChanged += new System.EventHandler(this.dgsReprintdetails_FilterStringChanged);
            // 
            // frmRemapping
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1546, 667);
            this.Controls.Add(this.dgsReprintdetails);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRemapping";
            this.Text = "Belum di Proses Scan Mapping";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgsReprintdetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgsBindingReprint)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ADGV.AdvancedDataGridView dgsReprintdetails;
        private System.Windows.Forms.BindingSource dgsBindingReprint;
    }
}