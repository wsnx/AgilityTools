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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Create");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Progress");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Mapping", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("MapingList");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("MovementList");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Report", new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode5});
            this.MappingTree = new System.Windows.Forms.TreeView();
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
            this.MappingTree.Location = new System.Drawing.Point(0, 0);
            this.MappingTree.Name = "MappingTree";
            treeNode1.Name = "Create";
            treeNode1.Text = "Create";
            treeNode2.Name = "Progress";
            treeNode2.Text = "Progress";
            treeNode3.Name = "Mapping";
            treeNode3.Text = "Mapping";
            treeNode4.Name = "MappingList";
            treeNode4.Text = "MapingList";
            treeNode5.Name = "MovementList";
            treeNode5.Text = "MovementList";
            treeNode6.Name = "Report";
            treeNode6.Text = "Report";
            this.MappingTree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode6});
            this.MappingTree.Size = new System.Drawing.Size(281, 701);
            this.MappingTree.TabIndex = 3;
            this.MappingTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.MappingTree_AfterSelect);
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
    }
}
