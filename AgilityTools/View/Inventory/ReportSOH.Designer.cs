namespace AgilityTools
{
    partial class ReportSOH
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgsList = new ADGV.AdvancedDataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.txt_storerkey = new System.Windows.Forms.ToolStripComboBox();
            this.btn_run = new System.Windows.Forms.ToolStripButton();
            this.btn_export = new System.Windows.Forms.ToolStripButton();
            this.dgsListBinding = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgsList)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgsListBinding)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1463, 22);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Stock On Hand";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgsList);
            this.panel2.Controls.Add(this.toolStrip1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 22);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1463, 744);
            this.panel2.TabIndex = 1;
            // 
            // dgsList
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Azure;
            this.dgsList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgsList.AutoGenerateContextFilters = true;
            this.dgsList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgsList.DateWithTime = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgsList.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgsList.Location = new System.Drawing.Point(0, 28);
            this.dgsList.Margin = new System.Windows.Forms.Padding(2);
            this.dgsList.Name = "dgsList";
            this.dgsList.RowTemplate.Height = 24;
            this.dgsList.Size = new System.Drawing.Size(1463, 716);
            this.dgsList.TabIndex = 1;
            this.dgsList.TimeFilter = false;
            this.dgsList.SortStringChanged += new System.EventHandler(this.dgsList_SortStringChanged);
            this.dgsList.FilterStringChanged += new System.EventHandler(this.dgsList_FilterStringChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txt_storerkey,
            this.btn_run,
            this.btn_export});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1463, 28);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // txt_storerkey
            // 
            this.txt_storerkey.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txt_storerkey.Items.AddRange(new object[] {
            "PLBSAMTFG",
            "PLBSAMJFG"});
            this.txt_storerkey.Name = "txt_storerkey";
            this.txt_storerkey.Size = new System.Drawing.Size(121, 28);
            this.txt_storerkey.Text = "Storerkey";
            // 
            // btn_run
            // 
            this.btn_run.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btn_run.Image = global::AgilityTools.Properties.Resources.find;
            this.btn_run.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_run.Name = "btn_run";
            this.btn_run.Size = new System.Drawing.Size(73, 25);
            this.btn_run.Text = "Show";
            this.btn_run.Click += new System.EventHandler(this.btn_run_Click);
            // 
            // btn_export
            // 
            this.btn_export.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btn_export.Image = global::AgilityTools.Properties.Resources.Excel;
            this.btn_export.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_export.Name = "btn_export";
            this.btn_export.Size = new System.Drawing.Size(135, 25);
            this.btn_export.Text = "Export To Excel";
            this.btn_export.Click += new System.EventHandler(this.btn_export_Click);
            // 
            // ReportSOH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ReportSOH";
            this.Size = new System.Drawing.Size(1463, 766);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgsList)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgsListBinding)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private ADGV.AdvancedDataGridView dgsList;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btn_run;
        private System.Windows.Forms.ToolStripButton btn_export;
        private System.Windows.Forms.BindingSource dgsListBinding;
        private System.Windows.Forms.ToolStripComboBox txt_storerkey;
        private System.Windows.Forms.Label label1;
    }
}
