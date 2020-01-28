namespace AgilityTools
{
    partial class RptPickingForm
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
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.tabPrint = new System.Windows.Forms.TabPage();
            this.btn_printManual = new System.Windows.Forms.ToolStripButton();
            this.txt_mappingID1 = new System.Windows.Forms.ToolStripTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgsList = new ADGV.AdvancedDataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dgs_sumDispatch = new System.Windows.Forms.DataGridView();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.txt_report = new System.Windows.Forms.ToolStripComboBox();
            this.txt_parameter = new System.Windows.Forms.ToolStripLabel();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.Btn_Export = new System.Windows.Forms.ToolStripButton();
            this.ProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.dgsListBinding = new System.Windows.Forms.BindingSource(this.components);
            this.tabPrint.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgsList)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgs_sumDispatch)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgsListBinding)).BeginInit();
            this.SuspendLayout();
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.DisplayStatusBar = false;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(3, 2);
            this.crystalReportViewer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(1566, 743);
            this.crystalReportViewer1.TabIndex = 0;
            // 
            // tabPrint
            // 
            this.tabPrint.Controls.Add(this.crystalReportViewer1);
            this.tabPrint.Location = new System.Drawing.Point(4, 34);
            this.tabPrint.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPrint.Name = "tabPrint";
            this.tabPrint.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPrint.Size = new System.Drawing.Size(1572, 747);
            this.tabPrint.TabIndex = 1;
            this.tabPrint.Text = "Preview";
            this.tabPrint.UseVisualStyleBackColor = true;
            // 
            // btn_printManual
            // 
            this.btn_printManual.Image = global::AgilityTools.Properties.Resources.find;
            this.btn_printManual.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_printManual.Name = "btn_printManual";
            this.btn_printManual.Size = new System.Drawing.Size(84, 41);
            this.btn_printManual.Text = "Show";
            this.btn_printManual.Click += new System.EventHandler(this.btn_printManual_Click);
            // 
            // txt_mappingID1
            // 
            this.txt_mappingID1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txt_mappingID1.Name = "txt_mappingID1";
            this.txt_mappingID1.Size = new System.Drawing.Size(200, 44);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabControl2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 46);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1566, 699);
            this.panel2.TabIndex = 2;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage2);
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.ItemSize = new System.Drawing.Size(300, 30);
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(1566, 699);
            this.tabControl2.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl2.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgsList);
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1558, 661);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.Text = "List";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgsList
            // 
            this.dgsList.AutoGenerateContextFilters = true;
            this.dgsList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgsList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgsList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgsList.DateWithTime = false;
            this.dgsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgsList.Location = new System.Drawing.Point(3, 3);
            this.dgsList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgsList.Name = "dgsList";
            this.dgsList.RowHeadersVisible = false;
            this.dgsList.RowHeadersWidth = 51;
            this.dgsList.RowTemplate.Height = 24;
            this.dgsList.Size = new System.Drawing.Size(1552, 655);
            this.dgsList.TabIndex = 1;
            this.dgsList.TimeFilter = false;
            this.dgsList.SortStringChanged += new System.EventHandler(this.dgsList_SortStringChanged_1);
            this.dgsList.FilterStringChanged += new System.EventHandler(this.dgsList_FilterStringChanged_1);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dgs_sumDispatch);
            this.tabPage3.Location = new System.Drawing.Point(4, 54);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1558, 641);
            this.tabPage3.TabIndex = 1;
            this.tabPage3.Text = "Summary";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dgs_sumDispatch
            // 
            this.dgs_sumDispatch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgs_sumDispatch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgs_sumDispatch.Location = new System.Drawing.Point(3, 3);
            this.dgs_sumDispatch.Name = "dgs_sumDispatch";
            this.dgs_sumDispatch.RowHeadersWidth = 51;
            this.dgs_sumDispatch.RowTemplate.Height = 24;
            this.dgs_sumDispatch.Size = new System.Drawing.Size(1552, 635);
            this.dgs_sumDispatch.TabIndex = 0;
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.Color.White;
            this.toolStrip2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txt_report,
            this.txt_parameter,
            this.txt_mappingID1,
            this.btn_printManual,
            this.btnRefresh,
            this.Btn_Export,
            this.ProgressBar1});
            this.toolStrip2.Location = new System.Drawing.Point(3, 2);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1566, 44);
            this.toolStrip2.TabIndex = 1;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // txt_report
            // 
            this.txt_report.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txt_report.Items.AddRange(new object[] {
            "PickingCheck",
            "PickingReport",
            "LoadingCheck",
            "LoadingReport",
            "Dispatch ex BC 3.3",
            "Dispatch ex BC 2.7",
            "OutstandingSO"});
            this.txt_report.Name = "txt_report";
            this.txt_report.Size = new System.Drawing.Size(160, 44);
            this.txt_report.Text = "Report..";
            this.txt_report.SelectedIndexChanged += new System.EventHandler(this.txt_report_SelectedIndexChanged);
            // 
            // txt_parameter
            // 
            this.txt_parameter.Name = "txt_parameter";
            this.txt_parameter.Size = new System.Drawing.Size(95, 41);
            this.txt_parameter.Text = "OrderKey";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::AgilityTools.Properties.Resources.refresh;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(65, 41);
            this.btnRefresh.Text = "List";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // Btn_Export
            // 
            this.Btn_Export.Enabled = false;
            this.Btn_Export.Image = global::AgilityTools.Properties.Resources.save;
            this.Btn_Export.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Btn_Export.Name = "Btn_Export";
            this.Btn_Export.Size = new System.Drawing.Size(93, 41);
            this.Btn_Export.Text = "Export";
            this.Btn_Export.Click += new System.EventHandler(this.Btn_Export_Click);
            // 
            // ProgressBar1
            // 
            this.ProgressBar1.Name = "ProgressBar1";
            this.ProgressBar1.Size = new System.Drawing.Size(133, 41);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.toolStrip2);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Size = new System.Drawing.Size(1572, 747);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Data";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1580, 785);
            this.panel1.TabIndex = 7;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPrint);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.ItemSize = new System.Drawing.Size(200, 30);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1580, 785);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 0;
            // 
            // RptPickingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "RptPickingForm";
            this.Size = new System.Drawing.Size(1580, 785);
            this.tabPrint.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgsList)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgs_sumDispatch)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgsListBinding)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.TabPage tabPrint;
        private System.Windows.Forms.ToolStripButton btn_printManual;
        private System.Windows.Forms.ToolStripTextBox txt_mappingID1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel txt_parameter;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.BindingSource dgsListBinding;
        private System.Windows.Forms.ToolStripComboBox txt_report;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripButton Btn_Export;
        private System.Windows.Forms.ToolStripProgressBar ProgressBar1;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage2;
        private ADGV.AdvancedDataGridView dgsList;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dgs_sumDispatch;
    }
}
