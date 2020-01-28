namespace AgilityTools
{
    partial class FrmMappingList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMappingList));
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.txt_mappingID = new System.Windows.Forms.ToolStripTextBox();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.dgsMappingList = new System.Windows.Forms.DataGridView();
            this.Cek = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.TASKID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MappingID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SKU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AssyCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CartonID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Editdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EditBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txt_SNP = new System.Windows.Forms.TextBox();
            this.txt_carmaker = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_Assycode = new System.Windows.Forms.Label();
            this.txt_SKU = new System.Windows.Forms.Label();
            this.txt_MI = new System.Windows.Forms.TextBox();
            this.txt_mappingList = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_newSNP = new System.Windows.Forms.TextBox();
            this.txt_newCarmaker = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txt_newAssyCode = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.Txt_newSKU = new System.Windows.Forms.Label();
            this.txt_newMI = new System.Windows.Forms.TextBox();
            this.txt_NewMappingID = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.Btn_Delete = new System.Windows.Forms.ToolStripButton();
            this.btn_create_new = new System.Windows.Forms.ToolStripButton();
            this.btn_refresh = new System.Windows.Forms.ToolStripButton();
            this.btn_search = new System.Windows.Forms.ToolStripButton();
            this.btn_help = new System.Windows.Forms.ToolStripButton();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgsMappingList)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.toolStrip2);
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1330, 192);
            this.panel1.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.White;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.txt_mappingID,
            this.btn_search,
            this.btn_help});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1330, 28);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(96, 25);
            this.toolStripLabel1.Text = "MappingID";
            // 
            // txt_mappingID
            // 
            this.txt_mappingID.BackColor = System.Drawing.Color.Linen;
            this.txt_mappingID.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txt_mappingID.Name = "txt_mappingID";
            this.txt_mappingID.Size = new System.Drawing.Size(200, 28);
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Btn_Delete,
            this.btn_create_new,
            this.btn_refresh});
            this.toolStrip2.Location = new System.Drawing.Point(0, 167);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1330, 25);
            this.toolStrip2.TabIndex = 13;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // dgsMappingList
            // 
            this.dgsMappingList.AllowUserToAddRows = false;
            this.dgsMappingList.AllowUserToDeleteRows = false;
            this.dgsMappingList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgsMappingList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgsMappingList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.dgsMappingList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgsMappingList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Cek,
            this.TASKID,
            this.MappingID,
            this.SKU,
            this.AssyCode,
            this.CartonID,
            this.Editdate,
            this.EditBy,
            this.Status,
            this.ID});
            this.dgsMappingList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgsMappingList.Location = new System.Drawing.Point(0, 192);
            this.dgsMappingList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgsMappingList.Name = "dgsMappingList";
            this.dgsMappingList.Size = new System.Drawing.Size(1330, 401);
            this.dgsMappingList.TabIndex = 1;
            this.dgsMappingList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgsMappingList_CellContentClick);
            // 
            // Cek
            // 
            this.Cek.HeaderText = "Selected";
            this.Cek.Name = "Cek";
            this.Cek.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Cek.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Cek.Width = 74;
            // 
            // TASKID
            // 
            this.TASKID.HeaderText = "Mapping Instruction";
            this.TASKID.Name = "TASKID";
            this.TASKID.Width = 114;
            // 
            // MappingID
            // 
            this.MappingID.HeaderText = "MappingID";
            this.MappingID.Name = "MappingID";
            this.MappingID.Width = 84;
            // 
            // SKU
            // 
            this.SKU.HeaderText = "SKU";
            this.SKU.Name = "SKU";
            this.SKU.Width = 54;
            // 
            // AssyCode
            // 
            this.AssyCode.HeaderText = "AssyCode";
            this.AssyCode.Name = "AssyCode";
            this.AssyCode.Width = 79;
            // 
            // CartonID
            // 
            this.CartonID.HeaderText = "CartonID";
            this.CartonID.Name = "CartonID";
            this.CartonID.Width = 74;
            // 
            // Editdate
            // 
            this.Editdate.HeaderText = "Editdate";
            this.Editdate.Name = "Editdate";
            this.Editdate.Width = 71;
            // 
            // EditBy
            // 
            this.EditBy.HeaderText = "EditBy";
            this.EditBy.Name = "EditBy";
            this.EditBy.Width = 62;
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.Width = 62;
            // 
            // ID
            // 
            this.ID.HeaderText = "TransID";
            this.ID.Name = "ID";
            this.ID.Visible = false;
            this.ID.Width = 70;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.panel2.Controls.Add(this.txt_SNP);
            this.panel2.Controls.Add(this.txt_carmaker);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txt_Assycode);
            this.panel2.Controls.Add(this.txt_SKU);
            this.panel2.Controls.Add(this.txt_MI);
            this.panel2.Controls.Add(this.txt_mappingList);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 28);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(688, 139);
            this.panel2.TabIndex = 14;
            // 
            // txt_SNP
            // 
            this.txt_SNP.Enabled = false;
            this.txt_SNP.Location = new System.Drawing.Point(431, 88);
            this.txt_SNP.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txt_SNP.Name = "txt_SNP";
            this.txt_SNP.Size = new System.Drawing.Size(165, 20);
            this.txt_SNP.TabIndex = 24;
            // 
            // txt_carmaker
            // 
            this.txt_carmaker.AutoSize = true;
            this.txt_carmaker.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_carmaker.Location = new System.Drawing.Point(428, 60);
            this.txt_carmaker.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txt_carmaker.Name = "txt_carmaker";
            this.txt_carmaker.Size = new System.Drawing.Size(13, 17);
            this.txt_carmaker.TabIndex = 23;
            this.txt_carmaker.Text = "-";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(311, 32);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 17);
            this.label6.TabIndex = 22;
            this.label6.Text = "AssyCode";
            // 
            // txt_Assycode
            // 
            this.txt_Assycode.AutoSize = true;
            this.txt_Assycode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Assycode.Location = new System.Drawing.Point(428, 33);
            this.txt_Assycode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txt_Assycode.Name = "txt_Assycode";
            this.txt_Assycode.Size = new System.Drawing.Size(13, 17);
            this.txt_Assycode.TabIndex = 21;
            this.txt_Assycode.Text = "-";
            // 
            // txt_SKU
            // 
            this.txt_SKU.AutoSize = true;
            this.txt_SKU.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_SKU.Location = new System.Drawing.Point(95, 88);
            this.txt_SKU.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txt_SKU.Name = "txt_SKU";
            this.txt_SKU.Size = new System.Drawing.Size(13, 17);
            this.txt_SKU.TabIndex = 20;
            this.txt_SKU.Text = "-";
            // 
            // txt_MI
            // 
            this.txt_MI.Enabled = false;
            this.txt_MI.Location = new System.Drawing.Point(98, 60);
            this.txt_MI.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txt_MI.Name = "txt_MI";
            this.txt_MI.Size = new System.Drawing.Size(165, 20);
            this.txt_MI.TabIndex = 19;
            // 
            // txt_mappingList
            // 
            this.txt_mappingList.Enabled = false;
            this.txt_mappingList.Location = new System.Drawing.Point(98, 32);
            this.txt_mappingList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txt_mappingList.Name = "txt_mappingList";
            this.txt_mappingList.Size = new System.Drawing.Size(165, 20);
            this.txt_mappingList.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(17, 88);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 17);
            this.label5.TabIndex = 17;
            this.label5.Text = "SKU";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(311, 88);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 17);
            this.label4.TabIndex = 16;
            this.label4.Text = "SNP";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(311, 63);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 17);
            this.label3.TabIndex = 15;
            this.label3.Text = "Carmaker";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 60);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 17);
            this.label2.TabIndex = 14;
            this.label2.Text = "MI";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "MappingID";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(688, 28);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(642, 139);
            this.panel3.TabIndex = 15;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.groupBox1.Controls.Add(this.txt_newSNP);
            this.groupBox1.Controls.Add(this.txt_newCarmaker);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txt_newAssyCode);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.Txt_newSKU);
            this.groupBox1.Controls.Add(this.txt_newMI);
            this.groupBox1.Controls.Add(this.txt_NewMappingID);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Size = new System.Drawing.Size(642, 139);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "New Pallet";
            // 
            // txt_newSNP
            // 
            this.txt_newSNP.Enabled = false;
            this.txt_newSNP.Location = new System.Drawing.Point(457, 82);
            this.txt_newSNP.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txt_newSNP.Name = "txt_newSNP";
            this.txt_newSNP.Size = new System.Drawing.Size(165, 20);
            this.txt_newSNP.TabIndex = 32;
            // 
            // txt_newCarmaker
            // 
            this.txt_newCarmaker.AutoSize = true;
            this.txt_newCarmaker.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_newCarmaker.Location = new System.Drawing.Point(454, 54);
            this.txt_newCarmaker.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txt_newCarmaker.Name = "txt_newCarmaker";
            this.txt_newCarmaker.Size = new System.Drawing.Size(13, 17);
            this.txt_newCarmaker.TabIndex = 31;
            this.txt_newCarmaker.Text = "-";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(337, 26);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 17);
            this.label12.TabIndex = 30;
            this.label12.Text = "AssyCode";
            // 
            // txt_newAssyCode
            // 
            this.txt_newAssyCode.AutoSize = true;
            this.txt_newAssyCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_newAssyCode.Location = new System.Drawing.Point(454, 27);
            this.txt_newAssyCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txt_newAssyCode.Name = "txt_newAssyCode";
            this.txt_newAssyCode.Size = new System.Drawing.Size(13, 17);
            this.txt_newAssyCode.TabIndex = 29;
            this.txt_newAssyCode.Text = "-";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(337, 82);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(36, 17);
            this.label14.TabIndex = 28;
            this.label14.Text = "SNP";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(337, 57);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(69, 17);
            this.label15.TabIndex = 27;
            this.label15.Text = "Carmaker";
            // 
            // Txt_newSKU
            // 
            this.Txt_newSKU.AutoSize = true;
            this.Txt_newSKU.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_newSKU.Location = new System.Drawing.Point(91, 80);
            this.Txt_newSKU.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Txt_newSKU.Name = "Txt_newSKU";
            this.Txt_newSKU.Size = new System.Drawing.Size(13, 17);
            this.Txt_newSKU.TabIndex = 26;
            this.Txt_newSKU.Text = "-";
            // 
            // txt_newMI
            // 
            this.txt_newMI.Enabled = false;
            this.txt_newMI.Location = new System.Drawing.Point(94, 52);
            this.txt_newMI.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txt_newMI.Name = "txt_newMI";
            this.txt_newMI.Size = new System.Drawing.Size(165, 20);
            this.txt_newMI.TabIndex = 25;
            // 
            // txt_NewMappingID
            // 
            this.txt_NewMappingID.Location = new System.Drawing.Point(94, 24);
            this.txt_NewMappingID.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txt_NewMappingID.Name = "txt_NewMappingID";
            this.txt_NewMappingID.ReadOnly = true;
            this.txt_NewMappingID.Size = new System.Drawing.Size(165, 20);
            this.txt_NewMappingID.TabIndex = 24;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(13, 80);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 17);
            this.label8.TabIndex = 23;
            this.label8.Text = "SKU";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(13, 52);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(22, 17);
            this.label9.TabIndex = 22;
            this.label9.Text = "MI";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(13, 24);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 17);
            this.label10.TabIndex = 21;
            this.label10.Text = "MappingID";
            // 
            // Btn_Delete
            // 
            this.Btn_Delete.Image = global::AgilityTools.Properties.Resources.close;
            this.Btn_Delete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Btn_Delete.Name = "Btn_Delete";
            this.Btn_Delete.Size = new System.Drawing.Size(60, 22);
            this.Btn_Delete.Text = "Delete";
            this.Btn_Delete.Click += new System.EventHandler(this.Btn_Delete_Click);
            // 
            // btn_create_new
            // 
            this.btn_create_new.Image = global::AgilityTools.Properties.Resources.list;
            this.btn_create_new.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_create_new.Name = "btn_create_new";
            this.btn_create_new.Size = new System.Drawing.Size(155, 22);
            this.btn_create_new.Text = "Create new MappingList";
            this.btn_create_new.Click += new System.EventHandler(this.btn_create_new_Click);
            // 
            // btn_refresh
            // 
            this.btn_refresh.Image = global::AgilityTools.Properties.Resources.refresh;
            this.btn_refresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(66, 22);
            this.btn_refresh.Text = "Refresh";
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // btn_search
            // 
            this.btn_search.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btn_search.Image = global::AgilityTools.Properties.Resources.find;
            this.btn_search.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(81, 25);
            this.btn_search.Text = "Search";
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // btn_help
            // 
            this.btn_help.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btn_help.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btn_help.Image = global::AgilityTools.Properties.Resources.help;
            this.btn_help.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_help.Name = "btn_help";
            this.btn_help.Size = new System.Drawing.Size(62, 25);
            this.btn_help.Text = "Help";
            this.btn_help.Click += new System.EventHandler(this.btn_help_Click);
            // 
            // FrmMappingList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1330, 593);
            this.Controls.Add(this.dgsMappingList);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "FrmMappingList";
            this.Text = "Edit Mapping List";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgsMappingList)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox txt_mappingID;
        private System.Windows.Forms.ToolStripButton btn_search;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton Btn_Delete;
        private System.Windows.Forms.ToolStripButton btn_create_new;
        private System.Windows.Forms.DataGridView dgsMappingList;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Cek;
        private System.Windows.Forms.DataGridViewTextBoxColumn TASKID;
        private System.Windows.Forms.DataGridViewTextBoxColumn MappingID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SKU;
        private System.Windows.Forms.DataGridViewTextBoxColumn AssyCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn CartonID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Editdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn EditBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txt_SNP;
        private System.Windows.Forms.Label txt_carmaker;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label txt_Assycode;
        private System.Windows.Forms.Label txt_SKU;
        private System.Windows.Forms.TextBox txt_MI;
        private System.Windows.Forms.TextBox txt_mappingList;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ToolStripButton btn_refresh;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_newSNP;
        private System.Windows.Forms.Label txt_newCarmaker;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label txt_newAssyCode;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label Txt_newSKU;
        private System.Windows.Forms.TextBox txt_newMI;
        private System.Windows.Forms.TextBox txt_NewMappingID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ToolStripButton btn_help;
    }
}