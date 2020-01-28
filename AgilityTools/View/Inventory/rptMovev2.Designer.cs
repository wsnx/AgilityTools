namespace AgilityTools
{
    partial class rptMovev2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rptMovev2));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.txt_DocType = new System.Windows.Forms.ToolStripComboBox();
            this.txt_Invoice = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.txt_PalletID = new System.Windows.Forms.ToolStripTextBox();
            this.Btn_get = new System.Windows.Forms.ToolStripButton();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgsList = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.DgsReadyToMove = new ADGV.AdvancedDataGridView();
            this.OpenTelnet = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgsList)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgsReadyToMove)).BeginInit();
            this.SuspendLayout();
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.txt_DocType,
            this.txt_Invoice,
            this.toolStripLabel1,
            this.txt_PalletID,
            this.Btn_get,
            this.progressBar,
            this.OpenTelnet});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1216, 29);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(99, 26);
            this.toolStripLabel2.Text = "Doc Number";
            // 
            // txt_DocType
            // 
            this.txt_DocType.Items.AddRange(new object[] {
            "CycleCount",
            "Dyna"});
            this.txt_DocType.Name = "txt_DocType";
            this.txt_DocType.Size = new System.Drawing.Size(92, 29);
            // 
            // txt_Invoice
            // 
            this.txt_Invoice.Name = "txt_Invoice";
            this.txt_Invoice.Size = new System.Drawing.Size(200, 29);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(101, 26);
            this.toolStripLabel1.Text = "Pallet ID/LOC";
            // 
            // txt_PalletID
            // 
            this.txt_PalletID.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txt_PalletID.Name = "txt_PalletID";
            this.txt_PalletID.Size = new System.Drawing.Size(151, 29);
            // 
            // Btn_get
            // 
            this.Btn_get.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.Btn_get.Image = global::AgilityTools.Properties.Resources.list;
            this.Btn_get.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Btn_get.Name = "Btn_get";
            this.Btn_get.Size = new System.Drawing.Size(94, 26);
            this.Btn_get.Text = "Get Data";
            this.Btn_get.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // progressBar
            // 
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(165, 26);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 29);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1216, 527);
            this.panel1.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.ItemSize = new System.Drawing.Size(400, 30);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1216, 527);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgsList);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage1.Size = new System.Drawing.Size(1208, 489);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Preview";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgsList
            // 
            this.dgsList.AllowUserToAddRows = false;
            this.dgsList.AllowUserToDeleteRows = false;
            this.dgsList.BackgroundColor = System.Drawing.Color.White;
            this.dgsList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgsList.Location = new System.Drawing.Point(2, 2);
            this.dgsList.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgsList.Name = "dgsList";
            this.dgsList.ReadOnly = true;
            this.dgsList.RowHeadersWidth = 18;
            this.dgsList.RowTemplate.Height = 120;
            this.dgsList.Size = new System.Drawing.Size(1204, 485);
            this.dgsList.TabIndex = 4;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.DgsReadyToMove);
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage2.Size = new System.Drawing.Size(949, 489);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "List";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // DgsReadyToMove
            // 
            this.DgsReadyToMove.AutoGenerateContextFilters = true;
            this.DgsReadyToMove.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgsReadyToMove.DateWithTime = false;
            this.DgsReadyToMove.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgsReadyToMove.Location = new System.Drawing.Point(2, 2);
            this.DgsReadyToMove.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.DgsReadyToMove.Name = "DgsReadyToMove";
            this.DgsReadyToMove.RowTemplate.Height = 24;
            this.DgsReadyToMove.Size = new System.Drawing.Size(945, 485);
            this.DgsReadyToMove.TabIndex = 0;
            this.DgsReadyToMove.TimeFilter = false;
            // 
            // OpenTelnet
            // 
            this.OpenTelnet.Image = ((System.Drawing.Image)(resources.GetObject("OpenTelnet.Image")));
            this.OpenTelnet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OpenTelnet.Name = "OpenTelnet";
            this.OpenTelnet.Size = new System.Drawing.Size(74, 26);
            this.OpenTelnet.Text = "Telnet";
            this.OpenTelnet.Click += new System.EventHandler(this.OpenTelnet_Click);
            // 
            // rptMovev2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "rptMovev2";
            this.Size = new System.Drawing.Size(1216, 556);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgsList)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgsReadyToMove)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox txt_PalletID;
        private System.Windows.Forms.ToolStripButton Btn_get;
        private System.Windows.Forms.ToolStripProgressBar progressBar;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dgsList;
        private System.Windows.Forms.TabPage tabPage2;
        private ADGV.AdvancedDataGridView DgsReadyToMove;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox txt_Invoice;
        private System.Windows.Forms.ToolStripComboBox txt_DocType;
        private System.Windows.Forms.ToolStripButton OpenTelnet;
    }
}
