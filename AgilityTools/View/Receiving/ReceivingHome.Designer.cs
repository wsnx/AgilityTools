namespace AgilityTools
{
    partial class ReceivingHome
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Planing");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Receiving", 2, 2, new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("ITS");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("GRN");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("SampleQR");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Report", new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode4,
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Back");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReceivingHome));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblForm = new System.Windows.Forms.ToolStripStatusLabel();
            this.ReceivingTree = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.PanelView = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.statusStrip1);
            this.splitContainer1.Panel1.Controls.Add(this.ReceivingTree);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.PanelView);
            this.splitContainer1.Size = new System.Drawing.Size(1284, 603);
            this.splitContainer1.SplitterDistance = 173;
            this.splitContainer1.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblForm});
            this.statusStrip1.Location = new System.Drawing.Point(0, 573);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(173, 30);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblForm
            // 
            this.lblForm.BackColor = System.Drawing.Color.Transparent;
            this.lblForm.Name = "lblForm";
            this.lblForm.Size = new System.Drawing.Size(149, 25);
            this.lblForm.Text = "by Kaizen @2019";
            // 
            // ReceivingTree
            // 
            this.ReceivingTree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ReceivingTree.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ReceivingTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReceivingTree.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReceivingTree.ImageIndex = 0;
            this.ReceivingTree.ImageList = this.imageList1;
            this.ReceivingTree.Location = new System.Drawing.Point(0, 0);
            this.ReceivingTree.Name = "ReceivingTree";
            treeNode1.ImageIndex = 9;
            treeNode1.Name = "Planing";
            treeNode1.StateImageKey = "(none)";
            treeNode1.Text = "Planing";
            treeNode2.ImageIndex = 2;
            treeNode2.Name = "Receiving";
            treeNode2.SelectedImageIndex = 2;
            treeNode2.Text = "Receiving";
            treeNode3.ImageKey = "report.png";
            treeNode3.Name = "ITS";
            treeNode3.SelectedImageIndex = 0;
            treeNode3.Text = "ITS";
            treeNode4.ImageIndex = 3;
            treeNode4.Name = "GRN";
            treeNode4.Text = "GRN";
            treeNode5.Name = "SampleQR";
            treeNode5.Text = "SampleQR";
            treeNode6.ImageKey = "print.png";
            treeNode6.Name = "Report";
            treeNode6.SelectedImageIndex = 7;
            treeNode6.Text = "Report";
            treeNode7.ImageKey = "Back.png";
            treeNode7.Name = "Back";
            treeNode7.SelectedImageIndex = 6;
            treeNode7.Text = "Back";
            this.ReceivingTree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode6,
            treeNode7});
            this.ReceivingTree.SelectedImageIndex = 0;
            this.ReceivingTree.Size = new System.Drawing.Size(173, 603);
            this.ReceivingTree.TabIndex = 2;
            this.ReceivingTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.ReceivingTree_AfterSelect);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "add.png");
            this.imageList1.Images.SetKeyName(1, "home.png");
            this.imageList1.Images.SetKeyName(2, "folder.png");
            this.imageList1.Images.SetKeyName(3, "report.png");
            this.imageList1.Images.SetKeyName(4, "User.png");
            this.imageList1.Images.SetKeyName(5, "iconfinder_Manager_131484.png");
            this.imageList1.Images.SetKeyName(6, "Back.png");
            this.imageList1.Images.SetKeyName(7, "print.png");
            this.imageList1.Images.SetKeyName(8, "chart.png");
            this.imageList1.Images.SetKeyName(9, "Forklift.png");
            this.imageList1.Images.SetKeyName(10, "number.png");
            this.imageList1.Images.SetKeyName(11, "ctn.png");
            // 
            // PanelView
            // 
            this.PanelView.AutoSize = true;
            this.PanelView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelView.Location = new System.Drawing.Point(0, 0);
            this.PanelView.Margin = new System.Windows.Forms.Padding(0);
            this.PanelView.Name = "PanelView";
            this.PanelView.Size = new System.Drawing.Size(1107, 603);
            this.PanelView.TabIndex = 0;
            // 
            // ReceivingHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ReceivingHome";
            this.Size = new System.Drawing.Size(1284, 603);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView ReceivingTree;
        private System.Windows.Forms.Panel PanelView;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblForm;
        private System.Windows.Forms.ImageList imageList1;
    }
}
