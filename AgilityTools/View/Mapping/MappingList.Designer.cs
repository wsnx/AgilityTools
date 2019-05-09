namespace AgilityTools
{
    partial class MappingList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MappingList));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgsSummaryMapping = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.Btn_generate = new System.Windows.Forms.ToolStripButton();
            this.btn = new System.Windows.Forms.ToolStripButton();
            this.dgsMappingList = new System.Windows.Forms.DataGridView();
            this.lblCartonID = new System.Windows.Forms.ToolStripButton();
            this.ProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgsSummaryMapping)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgsMappingList)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgsMappingList);
            this.splitContainer1.Size = new System.Drawing.Size(1329, 678);
            this.splitContainer1.SplitterDistance = 289;
            this.splitContainer1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 31);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1329, 258);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgsSummaryMapping);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1321, 225);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgsSummaryMapping
            // 
            this.dgsSummaryMapping.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgsSummaryMapping.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgsSummaryMapping.Location = new System.Drawing.Point(3, 3);
            this.dgsSummaryMapping.Name = "dgsSummaryMapping";
            this.dgsSummaryMapping.Size = new System.Drawing.Size(1315, 219);
            this.dgsSummaryMapping.TabIndex = 2;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1321, 225);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Btn_generate,
            this.btn,
            this.lblCartonID,
            this.ProgressBar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1329, 31);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // Btn_generate
            // 
            this.Btn_generate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Btn_generate.Image = global::AgilityTools.Properties.Resources.refresh;
            this.Btn_generate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Btn_generate.Name = "Btn_generate";
            this.Btn_generate.Size = new System.Drawing.Size(28, 28);
            this.Btn_generate.Text = "toolStripButton1";
            this.Btn_generate.Click += new System.EventHandler(this.Btn_generate_Click);
            // 
            // btn
            // 
            this.btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn.Image = ((System.Drawing.Image)(resources.GetObject("btn.Image")));
            this.btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn.Name = "btn";
            this.btn.Size = new System.Drawing.Size(28, 28);
            // 
            // dgsMappingList
            // 
            this.dgsMappingList.AllowUserToAddRows = false;
            this.dgsMappingList.AllowUserToDeleteRows = false;
            this.dgsMappingList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgsMappingList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgsMappingList.Location = new System.Drawing.Point(0, 0);
            this.dgsMappingList.Name = "dgsMappingList";
            this.dgsMappingList.ReadOnly = true;
            this.dgsMappingList.RowTemplate.Height = 28;
            this.dgsMappingList.Size = new System.Drawing.Size(1329, 385);
            this.dgsMappingList.TabIndex = 0;
            // 
            // lblCartonID
            // 
            this.lblCartonID.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.lblCartonID.Image = ((System.Drawing.Image)(resources.GetObject("lblCartonID.Image")));
            this.lblCartonID.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.lblCartonID.Name = "lblCartonID";
            this.lblCartonID.Size = new System.Drawing.Size(23, 28);
            // 
            // ProgressBar
            // 
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(100, 28);
            // 
            // MappingList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "MappingList";
            this.Size = new System.Drawing.Size(1329, 678);
            this.Load += new System.EventHandler(this.MappingList_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgsSummaryMapping)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgsMappingList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton Btn_generate;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dgsSummaryMapping;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ToolStripButton btn;
        private System.Windows.Forms.DataGridView dgsMappingList;
        private System.Windows.Forms.ToolStripButton lblCartonID;
        private System.Windows.Forms.ToolStripProgressBar ProgressBar;
    }
}
