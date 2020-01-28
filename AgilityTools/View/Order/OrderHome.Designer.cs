namespace AgilityTools
{
    partial class OrderHome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderHome));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.txt_Storerkey = new System.Windows.Forms.ToolStripComboBox();
            this.Btn_refresh = new System.Windows.Forms.ToolStripButton();
            this.btn_Export = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.EditScan = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabList = new System.Windows.Forms.TabPage();
            this.dgsOrderList = new System.Windows.Forms.DataGridView();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.DgsOrderDetails = new ADGV.AdvancedDataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btn_dispatch = new System.Windows.Forms.ToolStripMenuItem();
            this.DgsOrderDetailsBinding = new System.Windows.Forms.BindingSource(this.components);
            this.dgsOrderSUM_Binding = new System.Windows.Forms.BindingSource(this.components);
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgsOrderList)).BeginInit();
            this.tabControl2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgsOrderDetails)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgsOrderDetailsBinding)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgsOrderSUM_Binding)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txt_Storerkey,
            this.Btn_refresh,
            this.btn_Export,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1433, 31);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // txt_Storerkey
            // 
            this.txt_Storerkey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txt_Storerkey.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txt_Storerkey.Items.AddRange(new object[] {
            "PLBSAMTFG",
            "PLBSAMJFG"});
            this.txt_Storerkey.Name = "txt_Storerkey";
            this.txt_Storerkey.Size = new System.Drawing.Size(121, 31);
            this.txt_Storerkey.Text = "Storer";
            // 
            // Btn_refresh
            // 
            this.Btn_refresh.Image = global::AgilityTools.Properties.Resources.refresh;
            this.Btn_refresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Btn_refresh.Name = "Btn_refresh";
            this.Btn_refresh.Size = new System.Drawing.Size(91, 28);
            this.Btn_refresh.Text = "Refresh";
            this.Btn_refresh.Click += new System.EventHandler(this.Btn_refresh_Click);
            // 
            // btn_Export
            // 
            this.btn_Export.Image = global::AgilityTools.Properties.Resources.Excel;
            this.btn_Export.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Export.Name = "btn_Export";
            this.btn_Export.Size = new System.Drawing.Size(139, 28);
            this.btn_Export.Text = "Export To Excel";
            this.btn_Export.ToolTipText = "Export To Excel";
            this.btn_Export.Click += new System.EventHandler(this.btn_Export_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EditScan});
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(40, 28);
            this.toolStripButton1.Text = "Tools";
            this.toolStripButton1.Visible = false;
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click_1);
            // 
            // EditScan
            // 
            this.EditScan.Name = "EditScan";
            this.EditScan.Size = new System.Drawing.Size(180, 26);
            this.EditScan.Text = "Edit Scan Pick";
            this.EditScan.Click += new System.EventHandler(this.EditScan_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 31);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl2);
            this.splitContainer1.Size = new System.Drawing.Size(1433, 520);
            this.splitContainer1.SplitterDistance = 240;
            this.splitContainer1.TabIndex = 3;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabList);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1433, 240);
            this.tabControl1.TabIndex = 1;
            // 
            // tabList
            // 
            this.tabList.Controls.Add(this.dgsOrderList);
            this.tabList.Location = new System.Drawing.Point(4, 22);
            this.tabList.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabList.Name = "tabList";
            this.tabList.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabList.Size = new System.Drawing.Size(1425, 214);
            this.tabList.TabIndex = 1;
            this.tabList.Text = "List";
            this.tabList.UseVisualStyleBackColor = true;
            // 
            // dgsOrderList
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.dgsOrderList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgsOrderList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgsOrderList.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgsOrderList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgsOrderList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgsOrderList.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dgsOrderList.Location = new System.Drawing.Point(2, 2);
            this.dgsOrderList.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgsOrderList.Name = "dgsOrderList";
            this.dgsOrderList.RowTemplate.Height = 24;
            this.dgsOrderList.Size = new System.Drawing.Size(1421, 210);
            this.dgsOrderList.TabIndex = 0;
            this.dgsOrderList.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgsOrderList_CellContentDoubleClick);
            this.dgsOrderList.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgsOrderList_CellFormatting);
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage2);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(1433, 276);
            this.tabControl2.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.DgsOrderDetails);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage2.Size = new System.Drawing.Size(1425, 250);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Details";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // DgsOrderDetails
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.DgsOrderDetails.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.DgsOrderDetails.AutoGenerateContextFilters = true;
            this.DgsOrderDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DgsOrderDetails.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DgsOrderDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgsOrderDetails.DateWithTime = false;
            this.DgsOrderDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgsOrderDetails.Location = new System.Drawing.Point(2, 2);
            this.DgsOrderDetails.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.DgsOrderDetails.Name = "DgsOrderDetails";
            this.DgsOrderDetails.RowHeadersWidth = 51;
            this.DgsOrderDetails.RowTemplate.Height = 24;
            this.DgsOrderDetails.Size = new System.Drawing.Size(1421, 246);
            this.DgsOrderDetails.TabIndex = 0;
            this.DgsOrderDetails.TimeFilter = false;
            this.DgsOrderDetails.SortStringChanged += new System.EventHandler(this.DgsOrderDetails_SortStringChanged);
            this.DgsOrderDetails.FilterStringChanged += new System.EventHandler(this.DgsOrderDetails_FilterStringChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_dispatch});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.ShowImageMargin = false;
            this.contextMenuStrip1.Size = new System.Drawing.Size(96, 26);
            // 
            // btn_dispatch
            // 
            this.btn_dispatch.Name = "btn_dispatch";
            this.btn_dispatch.Size = new System.Drawing.Size(95, 22);
            this.btn_dispatch.Text = "Dispatch";
            this.btn_dispatch.Click += new System.EventHandler(this.btn_dispatch_Click);
            // 
            // OrderHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "OrderHome";
            this.Size = new System.Drawing.Size(1433, 551);
            this.Load += new System.EventHandler(this.OrderHome_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgsOrderList)).EndInit();
            this.tabControl2.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgsOrderDetails)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgsOrderDetailsBinding)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgsOrderSUM_Binding)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton Btn_refresh;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabList;
        private ADGV.AdvancedDataGridView DgsOrderDetails;
        private System.Windows.Forms.BindingSource DgsOrderDetailsBinding;
        private System.Windows.Forms.ToolStripComboBox txt_Storerkey;
        private System.Windows.Forms.ToolStripButton btn_Export;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btn_dispatch;
        private System.Windows.Forms.ToolStripSplitButton toolStripButton1;
        private System.Windows.Forms.ToolStripMenuItem EditScan;
        private System.Windows.Forms.BindingSource dgsOrderSUM_Binding;
        private System.Windows.Forms.DataGridView dgsOrderList;
    }
}
