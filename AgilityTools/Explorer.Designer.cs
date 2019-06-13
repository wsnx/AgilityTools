namespace AgilityTools
{
    partial class Explorer
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
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Dashboard");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Receiving");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Mapping");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Order");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Menu", new System.Windows.Forms.TreeNode[] {
            treeNode12,
            treeNode13,
            treeNode14,
            treeNode15});
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("PaletID");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("MappingList");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("Report", new System.Windows.Forms.TreeNode[] {
            treeNode17,
            treeNode18});
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("Manage");
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("User", new System.Windows.Forms.TreeNode[] {
            treeNode20});
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("Log Out");
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Status = new System.Windows.Forms.StatusStrip();
            this.lblUserName = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.Status.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.Status);
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(1003, 448);
            this.splitContainer1.SplitterDistance = 158;
            this.splitContainer1.TabIndex = 0;
            // 
            // treeView1
            // 
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeView1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.Indent = 20;
            this.treeView1.ItemHeight = 30;
            this.treeView1.LineColor = System.Drawing.Color.DimGray;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            treeNode12.ImageKey = "chart.png";
            treeNode12.Name = "Dashboard";
            treeNode12.Text = "Dashboard";
            treeNode13.ImageKey = "Forklift.png";
            treeNode13.Name = "Receiving";
            treeNode13.Text = "Receiving";
            treeNode14.ImageKey = "ctn.png";
            treeNode14.Name = "Mapping";
            treeNode14.Text = "Mapping";
            treeNode15.ImageIndex = 4;
            treeNode15.Name = "Order";
            treeNode15.Text = "Order";
            treeNode16.ImageKey = "folder.png";
            treeNode16.Name = "Home";
            treeNode16.Text = "Menu";
            treeNode17.ImageKey = "print.png";
            treeNode17.Name = "PrintLabel";
            treeNode17.Text = "PaletID";
            treeNode18.ImageKey = "print.png";
            treeNode18.Name = "MappingList";
            treeNode18.Text = "MappingList";
            treeNode19.ImageKey = "report.png";
            treeNode19.Name = "Report";
            treeNode19.Text = "Report";
            treeNode20.Name = "Manage";
            treeNode20.Text = "Manage";
            treeNode21.ImageKey = "iconfinder_Manager_131484.png";
            treeNode21.Name = "User";
            treeNode21.Text = "User";
            treeNode22.ForeColor = System.Drawing.Color.Red;
            treeNode22.ImageKey = "Back.png";
            treeNode22.Name = "Log Out";
            treeNode22.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode22.Text = "Log Out";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode16,
            treeNode19,
            treeNode21,
            treeNode22});
            this.treeView1.Size = new System.Drawing.Size(158, 448);
            this.treeView1.TabIndex = 5;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 41.99623F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 58.00377F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(841, 448);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // Status
            // 
            this.Status.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.Status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblUserName});
            this.Status.Location = new System.Drawing.Point(0, 426);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(158, 22);
            this.Status.TabIndex = 6;
            // 
            // lblUserName
            // 
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(0, 17);
            // 
            // Explorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "Explorer";
            this.Size = new System.Drawing.Size(1003, 448);
            this.Load += new System.EventHandler(this.Explorer_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.Status.ResumeLayout(false);
            this.Status.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.StatusStrip Status;
        private System.Windows.Forms.ToolStripStatusLabel lblUserName;
    }
}
