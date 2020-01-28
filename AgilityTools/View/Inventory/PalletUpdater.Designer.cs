namespace AgilityTools
{
    partial class PalletUpdater
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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.DgsComplete = new ADGV.AdvancedDataGridView();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.btn_refresh = new System.Windows.Forms.ToolStripButton();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_status = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_HasilScan = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_mapp = new System.Windows.Forms.Label();
            this.txt_SOH = new System.Windows.Forms.Label();
            this.txt_QtyMapping = new System.Windows.Forms.Label();
            this.txt_QtySNP = new System.Windows.Forms.Label();
            this.txt_SKU = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgsList = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dgsNotCompleted = new ADGV.AdvancedDataGridView();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btn_refresh2 = new System.Windows.Forms.ToolStripButton();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.dgsMoveExcel = new System.Windows.Forms.DataGridView();
            this.toolStrip4 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.txt_taskID = new System.Windows.Forms.ToolStripTextBox();
            this.btn_MoveByExcel = new System.Windows.Forms.ToolStripButton();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.DgsListMoveNew = new System.Windows.Forms.DataGridView();
            this.lbl_SKU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbl_AssyCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CartonID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QR_left = new System.Windows.Forms.DataGridViewImageColumn();
            this.MappingID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QR_Right = new System.Windows.Forms.DataGridViewImageColumn();
            this.toolStrip5 = new System.Windows.Forms.ToolStrip();
            this.txt_MappingID2 = new System.Windows.Forms.ToolStripTextBox();
            this.Btn_Submit = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.txt_MappingID = new System.Windows.Forms.ToolStripTextBox();
            this.btnGetData = new System.Windows.Forms.ToolStripButton();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.dgsBindingComplete = new System.Windows.Forms.BindingSource(this.components);
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgsComplete)).BeginInit();
            this.toolStrip3.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgsList)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgsNotCompleted)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgsMoveExcel)).BeginInit();
            this.toolStrip4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgsListMoveNew)).BeginInit();
            this.toolStrip5.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgsBindingComplete)).BeginInit();
            this.SuspendLayout();
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.DgsComplete);
            this.tabPage2.Controls.Add(this.toolStrip3);
            this.tabPage2.Location = new System.Drawing.Point(4, 44);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(1579, 673);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Completed";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // DgsComplete
            // 
            this.DgsComplete.AutoGenerateContextFilters = true;
            this.DgsComplete.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DgsComplete.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DgsComplete.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.DgsComplete.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgsComplete.DateWithTime = false;
            this.DgsComplete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgsComplete.Location = new System.Drawing.Point(4, 31);
            this.DgsComplete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DgsComplete.Name = "DgsComplete";
            this.DgsComplete.RowHeadersWidth = 51;
            this.DgsComplete.RowTemplate.Height = 24;
            this.DgsComplete.Size = new System.Drawing.Size(1571, 638);
            this.DgsComplete.TabIndex = 1;
            this.DgsComplete.TimeFilter = false;
            this.DgsComplete.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgsComplete_CellContentClick);
            // 
            // toolStrip3
            // 
            this.toolStrip3.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_refresh});
            this.toolStrip3.Location = new System.Drawing.Point(4, 4);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(1571, 27);
            this.toolStrip3.TabIndex = 0;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // btn_refresh
            // 
            this.btn_refresh.Image = global::AgilityTools.Properties.Resources.refresh;
            this.btn_refresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(82, 24);
            this.btn_refresh.Text = "Refresh";
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.panel3);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 44);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(1579, 673);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Preview";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.groupBox1.Controls.Add(this.txt_status);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(748, 519);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(827, 150);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Status";
            // 
            // txt_status
            // 
            this.txt_status.AutoSize = true;
            this.txt_status.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_status.Location = new System.Drawing.Point(19, 30);
            this.txt_status.Name = "txt_status";
            this.txt_status.Size = new System.Drawing.Size(42, 58);
            this.txt_status.TabIndex = 18;
            this.txt_status.Text = "-";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.txt_HasilScan);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.txt_mapp);
            this.panel3.Controls.Add(this.txt_SOH);
            this.panel3.Controls.Add(this.txt_QtyMapping);
            this.panel3.Controls.Add(this.txt_QtySNP);
            this.panel3.Controls.Add(this.txt_SKU);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(748, 4);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(827, 665);
            this.panel3.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(241, 303);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 17);
            this.label2.TabIndex = 33;
            this.label2.Text = ":";
            // 
            // txt_HasilScan
            // 
            this.txt_HasilScan.AutoSize = true;
            this.txt_HasilScan.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_HasilScan.Location = new System.Drawing.Point(276, 292);
            this.txt_HasilScan.Name = "txt_HasilScan";
            this.txt_HasilScan.Size = new System.Drawing.Size(21, 29);
            this.txt_HasilScan.TabIndex = 32;
            this.txt_HasilScan.Text = "-";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(24, 293);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(227, 29);
            this.label7.TabIndex = 31;
            this.label7.Text = "Hasil Scan Mapping";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(241, 352);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(12, 17);
            this.label13.TabIndex = 30;
            this.label13.Text = ":";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(241, 233);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(12, 17);
            this.label12.TabIndex = 29;
            this.label12.Text = ":";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(241, 174);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(12, 17);
            this.label11.TabIndex = 28;
            this.label11.Text = ":";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(241, 132);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(12, 17);
            this.label10.TabIndex = 27;
            this.label10.Text = ":";
            // 
            // txt_mapp
            // 
            this.txt_mapp.AutoSize = true;
            this.txt_mapp.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_mapp.Location = new System.Drawing.Point(24, 15);
            this.txt_mapp.Name = "txt_mapp";
            this.txt_mapp.Size = new System.Drawing.Size(192, 39);
            this.txt_mapp.TabIndex = 19;
            this.txt_mapp.Text = "Mapping ID";
            // 
            // txt_SOH
            // 
            this.txt_SOH.AutoSize = true;
            this.txt_SOH.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_SOH.Location = new System.Drawing.Point(276, 342);
            this.txt_SOH.Name = "txt_SOH";
            this.txt_SOH.Size = new System.Drawing.Size(21, 29);
            this.txt_SOH.TabIndex = 26;
            this.txt_SOH.Text = "-";
            // 
            // txt_QtyMapping
            // 
            this.txt_QtyMapping.AutoSize = true;
            this.txt_QtyMapping.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_QtyMapping.Location = new System.Drawing.Point(276, 233);
            this.txt_QtyMapping.Name = "txt_QtyMapping";
            this.txt_QtyMapping.Size = new System.Drawing.Size(21, 29);
            this.txt_QtyMapping.TabIndex = 25;
            this.txt_QtyMapping.Text = "-";
            // 
            // txt_QtySNP
            // 
            this.txt_QtySNP.AutoSize = true;
            this.txt_QtySNP.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_QtySNP.Location = new System.Drawing.Point(275, 160);
            this.txt_QtySNP.Name = "txt_QtySNP";
            this.txt_QtySNP.Size = new System.Drawing.Size(28, 39);
            this.txt_QtySNP.TabIndex = 24;
            this.txt_QtySNP.Text = "-";
            // 
            // txt_SKU
            // 
            this.txt_SKU.AutoSize = true;
            this.txt_SKU.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_SKU.Location = new System.Drawing.Point(276, 122);
            this.txt_SKU.Name = "txt_SKU";
            this.txt_SKU.Size = new System.Drawing.Size(21, 29);
            this.txt_SKU.TabIndex = 23;
            this.txt_SKU.Text = "-";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(27, 346);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(221, 29);
            this.label5.TabIndex = 22;
            this.label5.Text = "Stock WMS Update";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(24, 223);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(173, 29);
            this.label4.TabIndex = 21;
            this.label4.Text = "Stock Mapping";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(24, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 29);
            this.label3.TabIndex = 20;
            this.label3.Text = "SNP";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 29);
            this.label1.TabIndex = 18;
            this.label1.Text = "SKU";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgsList);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(744, 665);
            this.panel1.TabIndex = 21;
            // 
            // dgsList
            // 
            this.dgsList.AllowUserToAddRows = false;
            this.dgsList.AllowUserToDeleteRows = false;
            this.dgsList.BackgroundColor = System.Drawing.Color.White;
            this.dgsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgsList.Location = new System.Drawing.Point(0, 0);
            this.dgsList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgsList.Name = "dgsList";
            this.dgsList.ReadOnly = true;
            this.dgsList.RowHeadersWidth = 18;
            this.dgsList.RowTemplate.Height = 120;
            this.dgsList.Size = new System.Drawing.Size(744, 665);
            this.dgsList.TabIndex = 1;
            this.dgsList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgsList_CellContentClick_1);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ItemSize = new System.Drawing.Size(200, 40);
            this.tabControl1.Location = new System.Drawing.Point(0, 33);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1587, 721);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dgsNotCompleted);
            this.tabPage3.Controls.Add(this.toolStrip2);
            this.tabPage3.Location = new System.Drawing.Point(4, 44);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage3.Size = new System.Drawing.Size(1579, 673);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Not Completed";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dgsNotCompleted
            // 
            this.dgsNotCompleted.AutoGenerateContextFilters = true;
            this.dgsNotCompleted.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgsNotCompleted.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgsNotCompleted.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgsNotCompleted.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgsNotCompleted.DateWithTime = false;
            this.dgsNotCompleted.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgsNotCompleted.Location = new System.Drawing.Point(3, 29);
            this.dgsNotCompleted.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgsNotCompleted.MultiSelect = false;
            this.dgsNotCompleted.Name = "dgsNotCompleted";
            this.dgsNotCompleted.RowHeadersWidth = 51;
            this.dgsNotCompleted.RowTemplate.Height = 24;
            this.dgsNotCompleted.Size = new System.Drawing.Size(1573, 642);
            this.dgsNotCompleted.TabIndex = 2;
            this.dgsNotCompleted.TimeFilter = false;
            // 
            // toolStrip2
            // 
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_refresh2});
            this.toolStrip2.Location = new System.Drawing.Point(3, 2);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1573, 27);
            this.toolStrip2.TabIndex = 1;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // btn_refresh2
            // 
            this.btn_refresh2.Image = global::AgilityTools.Properties.Resources.refresh;
            this.btn_refresh2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_refresh2.Name = "btn_refresh2";
            this.btn_refresh2.Size = new System.Drawing.Size(82, 24);
            this.btn_refresh2.Text = "Refresh";
            this.btn_refresh2.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.dgsMoveExcel);
            this.tabPage4.Controls.Add(this.toolStrip4);
            this.tabPage4.Location = new System.Drawing.Point(4, 44);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage4.Size = new System.Drawing.Size(1579, 673);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Move by Excel";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // dgsMoveExcel
            // 
            this.dgsMoveExcel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgsMoveExcel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgsMoveExcel.Location = new System.Drawing.Point(3, 29);
            this.dgsMoveExcel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgsMoveExcel.Name = "dgsMoveExcel";
            this.dgsMoveExcel.RowHeadersVisible = false;
            this.dgsMoveExcel.RowHeadersWidth = 51;
            this.dgsMoveExcel.RowTemplate.Height = 24;
            this.dgsMoveExcel.Size = new System.Drawing.Size(1573, 642);
            this.dgsMoveExcel.TabIndex = 2;
            this.dgsMoveExcel.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgsMoveExcel_CellContentClick);
            // 
            // toolStrip4
            // 
            this.toolStrip4.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.txt_taskID,
            this.btn_MoveByExcel});
            this.toolStrip4.Location = new System.Drawing.Point(3, 2);
            this.toolStrip4.Name = "toolStrip4";
            this.toolStrip4.Size = new System.Drawing.Size(1573, 27);
            this.toolStrip4.TabIndex = 0;
            this.toolStrip4.Text = "toolStrip4";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(56, 24);
            this.toolStripLabel1.Text = "Invoice";
            // 
            // txt_taskID
            // 
            this.txt_taskID.Name = "txt_taskID";
            this.txt_taskID.Size = new System.Drawing.Size(132, 27);
            // 
            // btn_MoveByExcel
            // 
            this.btn_MoveByExcel.Image = global::AgilityTools.Properties.Resources.find;
            this.btn_MoveByExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_MoveByExcel.Name = "btn_MoveByExcel";
            this.btn_MoveByExcel.Size = new System.Drawing.Size(88, 24);
            this.btn_MoveByExcel.Text = "GetData";
            this.btn_MoveByExcel.Click += new System.EventHandler(this.btn_MoveByExcel_Click);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.splitContainer1);
            this.tabPage5.Location = new System.Drawing.Point(4, 44);
            this.tabPage5.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage5.Size = new System.Drawing.Size(1579, 673);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "new";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(4, 4);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.DgsListMoveNew);
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip5);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(1571, 665);
            this.splitContainer1.SplitterDistance = 696;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
            // 
            // DgsListMoveNew
            // 
            this.DgsListMoveNew.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DgsListMoveNew.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DgsListMoveNew.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgsListMoveNew.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.lbl_SKU,
            this.lbl_AssyCode,
            this.CartonID,
            this.QR_left,
            this.MappingID,
            this.QR_Right});
            this.DgsListMoveNew.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgsListMoveNew.Location = new System.Drawing.Point(0, 27);
            this.DgsListMoveNew.Margin = new System.Windows.Forms.Padding(4);
            this.DgsListMoveNew.Name = "DgsListMoveNew";
            this.DgsListMoveNew.RowHeadersWidth = 51;
            this.DgsListMoveNew.Size = new System.Drawing.Size(696, 638);
            this.DgsListMoveNew.TabIndex = 1;
            // 
            // lbl_SKU
            // 
            this.lbl_SKU.HeaderText = "SKU";
            this.lbl_SKU.MinimumWidth = 6;
            this.lbl_SKU.Name = "lbl_SKU";
            this.lbl_SKU.Width = 65;
            // 
            // lbl_AssyCode
            // 
            this.lbl_AssyCode.HeaderText = "AssyCode";
            this.lbl_AssyCode.MinimumWidth = 6;
            this.lbl_AssyCode.Name = "lbl_AssyCode";
            // 
            // CartonID
            // 
            this.CartonID.HeaderText = "CartonID";
            this.CartonID.MinimumWidth = 6;
            this.CartonID.Name = "CartonID";
            this.CartonID.Width = 92;
            // 
            // QR_left
            // 
            this.QR_left.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.QR_left.HeaderText = "QRcode";
            this.QR_left.MinimumWidth = 6;
            this.QR_left.Name = "QR_left";
            this.QR_left.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.QR_left.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // MappingID
            // 
            this.MappingID.HeaderText = "MappingID";
            this.MappingID.MinimumWidth = 6;
            this.MappingID.Name = "MappingID";
            this.MappingID.Width = 104;
            // 
            // QR_Right
            // 
            this.QR_Right.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.QR_Right.HeaderText = "QRCode";
            this.QR_Right.MinimumWidth = 6;
            this.QR_Right.Name = "QR_Right";
            this.QR_Right.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.QR_Right.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // toolStrip5
            // 
            this.toolStrip5.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip5.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txt_MappingID2,
            this.Btn_Submit});
            this.toolStrip5.Location = new System.Drawing.Point(0, 0);
            this.toolStrip5.Name = "toolStrip5";
            this.toolStrip5.Size = new System.Drawing.Size(696, 27);
            this.toolStrip5.TabIndex = 0;
            this.toolStrip5.Text = "toolStrip5";
            // 
            // txt_MappingID2
            // 
            this.txt_MappingID2.Name = "txt_MappingID2";
            this.txt_MappingID2.Size = new System.Drawing.Size(132, 27);
            // 
            // Btn_Submit
            // 
            this.Btn_Submit.Image = global::AgilityTools.Properties.Resources.find;
            this.Btn_Submit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Btn_Submit.Name = "Btn_Submit";
            this.Btn_Submit.Size = new System.Drawing.Size(80, 24);
            this.Btn_Submit.Text = "Submit";
            this.Btn_Submit.Click += new System.EventHandler(this.Btn_Submit_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.txt_MappingID,
            this.btnGetData,
            this.progressBar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1587, 33);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(84, 30);
            this.toolStripLabel2.Text = "MappingID";
            // 
            // txt_MappingID
            // 
            this.txt_MappingID.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txt_MappingID.Name = "txt_MappingID";
            this.txt_MappingID.Size = new System.Drawing.Size(265, 33);
            // 
            // btnGetData
            // 
            this.btnGetData.Image = global::AgilityTools.Properties.Resources.find;
            this.btnGetData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(92, 30);
            this.btnGetData.Text = "Get Data";
            this.btnGetData.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // progressBar
            // 
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(133, 30);
            // 
            // PalletUpdater
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "PalletUpdater";
            this.Size = new System.Drawing.Size(1587, 754);
            this.Load += new System.EventHandler(this.PalletUpdater_Load);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgsComplete)).EndInit();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgsList)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgsNotCompleted)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgsMoveExcel)).EndInit();
            this.toolStrip4.ResumeLayout(false);
            this.toolStrip4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgsListMoveNew)).EndInit();
            this.toolStrip5.ResumeLayout(false);
            this.toolStrip5.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgsBindingComplete)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label txt_status;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgsList;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox txt_MappingID;
        private System.Windows.Forms.ToolStripButton btnGetData;
        private System.Windows.Forms.ToolStripProgressBar progressBar;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label txt_HasilScan;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label txt_mapp;
        private System.Windows.Forms.Label txt_SOH;
        private System.Windows.Forms.Label txt_QtyMapping;
        private System.Windows.Forms.Label txt_QtySNP;
        private System.Windows.Forms.Label txt_SKU;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private ADGV.AdvancedDataGridView DgsComplete;
        private System.Windows.Forms.ToolStripButton btn_refresh;
        private System.Windows.Forms.TabPage tabPage3;
        private ADGV.AdvancedDataGridView dgsNotCompleted;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton btn_refresh2;
        private System.Windows.Forms.BindingSource dgsBindingComplete;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.DataGridView dgsMoveExcel;
        private System.Windows.Forms.ToolStrip toolStrip4;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox txt_taskID;
        private System.Windows.Forms.ToolStripButton btn_MoveByExcel;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView DgsListMoveNew;
        private System.Windows.Forms.ToolStrip toolStrip5;
        private System.Windows.Forms.ToolStripButton Btn_Submit;
        private System.Windows.Forms.DataGridViewTextBoxColumn lbl_SKU;
        private System.Windows.Forms.DataGridViewTextBoxColumn lbl_AssyCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn CartonID;
        private System.Windows.Forms.DataGridViewImageColumn QR_left;
        private System.Windows.Forms.DataGridViewTextBoxColumn MappingID;
        private System.Windows.Forms.DataGridViewImageColumn QR_Right;
        private System.Windows.Forms.ToolStripTextBox txt_MappingID2;
    }
}
