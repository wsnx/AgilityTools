namespace AgilityTools
{
    partial class PickTicket
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PickTicket));
            this.bWorkerShow = new System.ComponentModel.BackgroundWorker();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.tabPrint = new System.Windows.Forms.TabPage();
            this.btn_printManual = new System.Windows.Forms.ToolStripButton();
            this.txt_mappingID1 = new System.Windows.Forms.ToolStripTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgsList = new ADGV.AdvancedDataGridView();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.txt_DocType = new System.Windows.Forms.ToolStripComboBox();
            this.parameter = new System.Windows.Forms.ToolStripLabel();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.helpToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.btn_getList = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.dgsListBinding = new System.Windows.Forms.BindingSource(this.components);
            this.tabPrint.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgsList)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgsListBinding)).BeginInit();
            this.SuspendLayout();
            // 
            // bWorkerShow
            // 
            this.bWorkerShow.WorkerReportsProgress = true;
            this.bWorkerShow.WorkerSupportsCancellation = true;
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
            this.crystalReportViewer1.Size = new System.Drawing.Size(1563, 668);
            this.crystalReportViewer1.TabIndex = 0;
            // 
            // tabPrint
            // 
            this.tabPrint.Controls.Add(this.crystalReportViewer1);
            this.tabPrint.Location = new System.Drawing.Point(4, 34);
            this.tabPrint.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPrint.Name = "tabPrint";
            this.tabPrint.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPrint.Size = new System.Drawing.Size(1569, 672);
            this.tabPrint.TabIndex = 1;
            this.tabPrint.Text = "Preview";
            this.tabPrint.UseVisualStyleBackColor = true;
            // 
            // btn_printManual
            // 
            this.btn_printManual.Image = global::AgilityTools.Properties.Resources.find;
            this.btn_printManual.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_printManual.Name = "btn_printManual";
            this.btn_printManual.Size = new System.Drawing.Size(77, 32);
            this.btn_printManual.Text = "Print";
            this.btn_printManual.Click += new System.EventHandler(this.btn_printManual_Click);
            // 
            // txt_mappingID1
            // 
            this.txt_mappingID1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txt_mappingID1.Name = "txt_mappingID1";
            this.txt_mappingID1.Size = new System.Drawing.Size(200, 35);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgsList);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 37);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1563, 644);
            this.panel2.TabIndex = 2;
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
            this.dgsList.Location = new System.Drawing.Point(0, 0);
            this.dgsList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgsList.Name = "dgsList";
            this.dgsList.RowTemplate.Height = 24;
            this.dgsList.Size = new System.Drawing.Size(1563, 644);
            this.dgsList.TabIndex = 0;
            this.dgsList.TimeFilter = false;
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.Color.White;
            this.toolStrip2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txt_DocType,
            this.parameter,
            this.txt_mappingID1,
            this.btn_printManual});
            this.toolStrip2.Location = new System.Drawing.Point(3, 2);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1563, 35);
            this.toolStrip2.TabIndex = 1;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // txt_DocType
            // 
            this.txt_DocType.Items.AddRange(new object[] {
            "ASN",
            "Wave",
            "Dyna",
            "Wave by DR.No"});
            this.txt_DocType.Name = "txt_DocType";
            this.txt_DocType.Size = new System.Drawing.Size(160, 35);
            this.txt_DocType.Text = "Doc Type";
            // 
            // parameter
            // 
            this.parameter.Name = "parameter";
            this.parameter.Size = new System.Drawing.Size(100, 32);
            this.parameter.Text = "Parameter";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.toolStrip2);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Size = new System.Drawing.Size(1569, 683);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Data";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 47);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1577, 721);
            this.panel1.TabIndex = 5;
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
            this.tabControl1.Size = new System.Drawing.Size(1577, 721);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 0;
            // 
            // helpToolStripButton
            // 
            this.helpToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("helpToolStripButton.Image")));
            this.helpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.helpToolStripButton.Name = "helpToolStripButton";
            this.helpToolStripButton.Size = new System.Drawing.Size(127, 44);
            this.helpToolStripButton.Text = "Bantuan";
            // 
            // btn_getList
            // 
            this.btn_getList.Image = global::AgilityTools.Properties.Resources.refresh;
            this.btn_getList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_getList.Name = "btn_getList";
            this.btn_getList.Size = new System.Drawing.Size(150, 44);
            this.btn_getList.Text = "Show Data";
            this.btn_getList.Click += new System.EventHandler(this.btn_getList_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_getList,
            this.helpToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1577, 47);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // PickTicket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "PickTicket";
            this.Size = new System.Drawing.Size(1577, 768);
            this.tabPrint.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgsList)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgsListBinding)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker bWorkerShow;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.TabPage tabPrint;
        private System.Windows.Forms.ToolStripButton btn_printManual;
        private System.Windows.Forms.ToolStripTextBox txt_mappingID1;
        private System.Windows.Forms.Panel panel2;
        private ADGV.AdvancedDataGridView dgsList;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.ToolStripButton helpToolStripButton;
        private System.Windows.Forms.ToolStripButton btn_getList;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.BindingSource dgsListBinding;
        private System.Windows.Forms.ToolStripLabel parameter;
        private System.Windows.Forms.ToolStripComboBox txt_DocType;
    }
}
