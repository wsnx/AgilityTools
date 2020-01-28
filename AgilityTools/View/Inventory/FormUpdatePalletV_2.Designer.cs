namespace AgilityTools.View.Inventory
{
    partial class FormUpdatePalletV_2
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TabPreview = new System.Windows.Forms.TabPage();
            this.TabComplete = new System.Windows.Forms.TabPage();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dgsComplete = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.TabPreview.SuspendLayout();
            this.TabComplete.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgsComplete)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.TabPreview);
            this.tabControl1.Controls.Add(this.TabComplete);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ItemSize = new System.Drawing.Size(200, 30);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1728, 823);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 0;
            // 
            // TabPreview
            // 
            this.TabPreview.Controls.Add(this.dataGridView1);
            this.TabPreview.Controls.Add(this.toolStrip1);
            this.TabPreview.Location = new System.Drawing.Point(4, 34);
            this.TabPreview.Name = "TabPreview";
            this.TabPreview.Padding = new System.Windows.Forms.Padding(3);
            this.TabPreview.Size = new System.Drawing.Size(1720, 785);
            this.TabPreview.TabIndex = 0;
            this.TabPreview.Text = "Preview";
            this.TabPreview.UseVisualStyleBackColor = true;
            // 
            // TabComplete
            // 
            this.TabComplete.Controls.Add(this.dgsComplete);
            this.TabComplete.Location = new System.Drawing.Point(4, 34);
            this.TabComplete.Name = "TabComplete";
            this.TabComplete.Padding = new System.Windows.Forms.Padding(3);
            this.TabComplete.Size = new System.Drawing.Size(1720, 785);
            this.TabComplete.TabIndex = 1;
            this.TabComplete.Text = "TabComplete";
            this.TabComplete.UseVisualStyleBackColor = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox1,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(3, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1714, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(150, 27);
            this.toolStripTextBox1.Text = "pallet no....";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::AgilityTools.Properties.Resources.find;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 30);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1714, 752);
            this.dataGridView1.TabIndex = 1;
            // 
            // dgsComplete
            // 
            this.dgsComplete.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgsComplete.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgsComplete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgsComplete.Location = new System.Drawing.Point(3, 3);
            this.dgsComplete.Name = "dgsComplete";
            this.dgsComplete.RowTemplate.Height = 24;
            this.dgsComplete.Size = new System.Drawing.Size(1714, 779);
            this.dgsComplete.TabIndex = 2;
            // 
            // FormUpdatePalletV_2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "FormUpdatePalletV_2";
            this.Size = new System.Drawing.Size(1728, 823);
            this.tabControl1.ResumeLayout(false);
            this.TabPreview.ResumeLayout(false);
            this.TabPreview.PerformLayout();
            this.TabComplete.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgsComplete)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage TabPreview;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.TabPage TabComplete;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dgsComplete;
    }
}
