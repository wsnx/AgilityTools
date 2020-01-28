namespace AgilityTools
{
    partial class rptMappingList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rptMappingList));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.txt_storerkey = new System.Windows.Forms.ToolStripComboBox();
            this.btn_getList = new System.Windows.Forms.ToolStripButton();
            this.btn_Print = new System.Windows.Forms.ToolStripButton();
            this.helpToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgsList = new ADGV.AdvancedDataGridView();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripTextBox();
            this.txt_mappingID1 = new System.Windows.Forms.ToolStripTextBox();
            this.btn_printManual = new System.Windows.Forms.ToolStripButton();
            this.ProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.lbl_status = new System.Windows.Forms.ToolStripLabel();
            this.tabPrint = new System.Windows.Forms.TabPage();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.CekBox = new System.Windows.Forms.CheckBox();
            this.dgsListBinding = new System.Windows.Forms.BindingSource(this.components);
            this.bWorkerShow = new System.ComponentModel.BackgroundWorker();
            this.Btn_updateStock = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgsList)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.tabPrint.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgsListBinding)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txt_storerkey,
            this.btn_getList,
            this.btn_Print,
            this.Btn_updateStock,
            this.helpToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1148, 47);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // txt_storerkey
            // 
            this.txt_storerkey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txt_storerkey.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.txt_storerkey.Items.AddRange(new object[] {
            "PLBSAMTFG",
            "PLBSAMJFG"});
            this.txt_storerkey.Name = "txt_storerkey";
            this.txt_storerkey.Size = new System.Drawing.Size(121, 47);
            this.txt_storerkey.Text = "Storer";
            this.txt_storerkey.SelectedIndexChanged += new System.EventHandler(this.txt_storerkey_SelectedIndexChanged);
            this.txt_storerkey.Click += new System.EventHandler(this.txt_storerkey_Click);
            // 
            // btn_getList
            // 
            this.btn_getList.DoubleClickEnabled = true;
            this.btn_getList.Image = global::AgilityTools.Properties.Resources.refresh;
            this.btn_getList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_getList.Name = "btn_getList";
            this.btn_getList.Size = new System.Drawing.Size(107, 44);
            this.btn_getList.Text = "Refresh";
            this.btn_getList.Click += new System.EventHandler(this.btn_getList_Click);
            // 
            // btn_Print
            // 
            this.btn_Print.Image = global::AgilityTools.Properties.Resources.iconfinder_Printer_Picture_52810;
            this.btn_Print.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Print.Name = "btn_Print";
            this.btn_Print.Size = new System.Drawing.Size(149, 44);
            this.btn_Print.Text = "Print Selected";
            this.btn_Print.Click += new System.EventHandler(this.btn_Print_Click);
            // 
            // helpToolStripButton
            // 
            this.helpToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("helpToolStripButton.Image")));
            this.helpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.helpToolStripButton.Name = "helpToolStripButton";
            this.helpToolStripButton.Size = new System.Drawing.Size(86, 44);
            this.helpToolStripButton.Text = "Help";
            this.helpToolStripButton.Click += new System.EventHandler(this.helpToolStripButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 47);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1148, 525);
            this.panel1.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPrint);
            this.tabControl1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.ItemSize = new System.Drawing.Size(200, 30);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1148, 525);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.toolStrip2);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage1.Size = new System.Drawing.Size(1140, 487);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Mapping List";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgsList);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(2, 31);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1136, 454);
            this.panel2.TabIndex = 2;
            // 
            // dgsList
            // 
            this.dgsList.AutoGenerateContextFilters = true;
            this.dgsList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgsList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgsList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.dgsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgsList.DateWithTime = false;
            this.dgsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgsList.Location = new System.Drawing.Point(0, 0);
            this.dgsList.Margin = new System.Windows.Forms.Padding(2);
            this.dgsList.Name = "dgsList";
            this.dgsList.RowTemplate.Height = 24;
            this.dgsList.Size = new System.Drawing.Size(1136, 454);
            this.dgsList.TabIndex = 0;
            this.dgsList.TimeFilter = false;
            this.dgsList.FilterStringChanged += new System.EventHandler(this.dgsList_FilterStringChanged);
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.Color.White;
            this.toolStrip2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.txt_mappingID1,
            this.btn_printManual,
            this.ProgressBar1,
            this.lbl_status});
            this.toolStrip2.Location = new System.Drawing.Point(2, 2);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1136, 29);
            this.toolStrip2.TabIndex = 1;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(84, 29);
            this.toolStripLabel1.Text = "MappingID";
            // 
            // txt_mappingID1
            // 
            this.txt_mappingID1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txt_mappingID1.Name = "txt_mappingID1";
            this.txt_mappingID1.Size = new System.Drawing.Size(151, 29);
            // 
            // btn_printManual
            // 
            this.btn_printManual.Image = global::AgilityTools.Properties.Resources.find;
            this.btn_printManual.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_printManual.Name = "btn_printManual";
            this.btn_printManual.Size = new System.Drawing.Size(123, 26);
            this.btn_printManual.Text = "Print manual";
            this.btn_printManual.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // ProgressBar1
            // 
            this.ProgressBar1.Name = "ProgressBar1";
            this.ProgressBar1.Size = new System.Drawing.Size(100, 26);
            // 
            // lbl_status
            // 
            this.lbl_status.Name = "lbl_status";
            this.lbl_status.Size = new System.Drawing.Size(52, 26);
            this.lbl_status.Text = "Status";
            // 
            // tabPrint
            // 
            this.tabPrint.Controls.Add(this.crystalReportViewer1);
            this.tabPrint.Location = new System.Drawing.Point(4, 34);
            this.tabPrint.Margin = new System.Windows.Forms.Padding(2);
            this.tabPrint.Name = "tabPrint";
            this.tabPrint.Padding = new System.Windows.Forms.Padding(2);
            this.tabPrint.Size = new System.Drawing.Size(1140, 487);
            this.tabPrint.TabIndex = 1;
            this.tabPrint.Text = "Preview";
            this.tabPrint.UseVisualStyleBackColor = true;
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.crystalReportViewer1.DisplayStatusBar = false;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(2, 2);
            this.crystalReportViewer1.Margin = new System.Windows.Forms.Padding(2);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(1136, 483);
            this.crystalReportViewer1.TabIndex = 0;
            // 
            // CekBox
            // 
            this.CekBox.AutoSize = true;
            this.CekBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.CekBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CekBox.Location = new System.Drawing.Point(762, -26);
            this.CekBox.Margin = new System.Windows.Forms.Padding(2);
            this.CekBox.Name = "CekBox";
            this.CekBox.Size = new System.Drawing.Size(159, 24);
            this.CekBox.TabIndex = 3;
            this.CekBox.Tag = "Tampilkan data yang sudah di print";
            this.CekBox.Text = "Show Reprint Only";
            this.CekBox.UseVisualStyleBackColor = false;
            // 
            // bWorkerShow
            // 
            this.bWorkerShow.WorkerReportsProgress = true;
            this.bWorkerShow.WorkerSupportsCancellation = true;
            this.bWorkerShow.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bWorkerShow_DoWork);
            this.bWorkerShow.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bWorkerShow_ProgressChanged);
            this.bWorkerShow.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bWorkerShow_RunWorkerCompleted);
            // 
            // Btn_updateStock
            // 
            this.Btn_updateStock.Image = global::AgilityTools.Properties.Resources.iconfinder_switch_1282965;
            this.Btn_updateStock.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Btn_updateStock.Name = "Btn_updateStock";
            this.Btn_updateStock.Size = new System.Drawing.Size(145, 44);
            this.Btn_updateStock.Text = "Update Stock";
            this.Btn_updateStock.Click += new System.EventHandler(this.Btn_updateStock_Click);
            // 
            // rptMappingList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CekBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "rptMappingList";
            this.Size = new System.Drawing.Size(1148, 572);
            this.Load += new System.EventHandler(this.rptMappingList_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgsList)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.tabPrint.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgsListBinding)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btn_getList;
        private System.Windows.Forms.ToolStripButton btn_Print;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPrint;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripTextBox toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox txt_mappingID1;
        private System.Windows.Forms.ToolStripButton btn_printManual;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.CheckBox CekBox;
        private ADGV.AdvancedDataGridView dgsList;
        private System.Windows.Forms.BindingSource dgsListBinding;
        private System.Windows.Forms.ToolStripComboBox txt_storerkey;
        private System.Windows.Forms.ToolStripButton helpToolStripButton;
        private System.ComponentModel.BackgroundWorker bWorkerShow;
        private System.Windows.Forms.ToolStripProgressBar ProgressBar1;
        private System.Windows.Forms.ToolStripLabel lbl_status;
        private System.Windows.Forms.ToolStripButton Btn_updateStock;
    }
}
