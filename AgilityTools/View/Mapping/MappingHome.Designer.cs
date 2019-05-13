namespace AgilityTools
{
    partial class MappingHomes
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Create");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Progress", 8, 11);
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Mapping", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("MappingList", 3, 11);
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("MovementList", 3, 11);
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Report", new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Back", 6, 6);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MappingHomes));
            this.MappingTree = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.PanelView = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MappingTree
            // 
            this.MappingTree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MappingTree.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MappingTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MappingTree.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MappingTree.ImageIndex = 0;
            this.MappingTree.ImageList = this.imageList1;
            this.MappingTree.Location = new System.Drawing.Point(0, 0);
            this.MappingTree.Name = "MappingTree";
            treeNode1.Name = "Create";
            treeNode1.SelectedImageIndex = 10;
            treeNode1.Text = "Create";
            treeNode2.ImageIndex = 8;
            treeNode2.Name = "Progress";
            treeNode2.SelectedImageIndex = 11;
            treeNode2.Text = "Progress";
            treeNode3.ImageKey = "folder.png";
            treeNode3.Name = "Mapping";
            treeNode3.SelectedImageIndex = 2;
            treeNode3.Text = "Mapping";
            treeNode4.ImageIndex = 3;
            treeNode4.Name = "MappingList";
            treeNode4.SelectedImageIndex = 11;
            treeNode4.Text = "MappingList";
            treeNode5.ImageIndex = 3;
            treeNode5.Name = "MovementList";
            treeNode5.SelectedImageIndex = 11;
            treeNode5.Text = "MovementList";
            treeNode6.ImageIndex = 3;
            treeNode6.Name = "Report";
            treeNode6.Text = "Report";
            treeNode7.ImageIndex = 6;
            treeNode7.Name = "Back";
            treeNode7.SelectedImageIndex = 6;
            treeNode7.Text = "Back";
            this.MappingTree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode6,
            treeNode7});
            this.MappingTree.SelectedImageIndex = 0;
            this.MappingTree.Size = new System.Drawing.Size(281, 701);
            this.MappingTree.TabIndex = 3;
            this.MappingTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.MappingTree_AfterSelect);
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
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.MappingTree);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.PanelView);
            this.splitContainer1.Size = new System.Drawing.Size(1414, 701);
            this.splitContainer1.SplitterDistance = 281;
            this.splitContainer1.TabIndex = 1;
            // 
            // PanelView
            // 
            this.PanelView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelView.Location = new System.Drawing.Point(0, 0);
            this.PanelView.Name = "PanelView";
            this.PanelView.Size = new System.Drawing.Size(1129, 701);
            this.PanelView.TabIndex = 0;
            // 
            // MappingHomes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "MappingHomes";
            this.Size = new System.Drawing.Size(1414, 701);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView MappingTree;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel PanelView;
        private System.Windows.Forms.ImageList imageList1;
    }
}
