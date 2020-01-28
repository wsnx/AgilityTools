namespace AgilityTools
{
    partial class MappingDR
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.panel2 = new System.Windows.Forms.Panel();
            this.DgsDraftDR = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_ETD = new System.Windows.Forms.Label();
            this.txt_Freight = new System.Windows.Forms.Label();
            this.txt_NoInvoice = new System.Windows.Forms.Label();
            this.txt_destination = new System.Windows.Forms.Label();
            this.txt_ShippingLine = new System.Windows.Forms.Label();
            this.txt_Carline = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgsDraftDR)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1769, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.txt_Carline);
            this.panel1.Controls.Add(this.txt_ShippingLine);
            this.panel1.Controls.Add(this.txt_destination);
            this.panel1.Controls.Add(this.txt_NoInvoice);
            this.panel1.Controls.Add(this.txt_Freight);
            this.panel1.Controls.Add(this.txt_ETD);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1769, 103);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.DgsDraftDR);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(0, 128);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1769, 712);
            this.panel2.TabIndex = 2;
            // 
            // DgsDraftDR
            // 
            this.DgsDraftDR.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgsDraftDR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgsDraftDR.Location = new System.Drawing.Point(0, 0);
            this.DgsDraftDR.Name = "DgsDraftDR";
            this.DgsDraftDR.RowTemplate.Height = 24;
            this.DgsDraftDR.Size = new System.Drawing.Size(1769, 712);
            this.DgsDraftDR.TabIndex = 0;
            this.DgsDraftDR.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgsDraftDR_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "ETD";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Jenis Keberangkatan";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(21, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "No Invoice";
            // 
            // txt_ETD
            // 
            this.txt_ETD.AutoSize = true;
            this.txt_ETD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ETD.Location = new System.Drawing.Point(217, 14);
            this.txt_ETD.Name = "txt_ETD";
            this.txt_ETD.Size = new System.Drawing.Size(18, 18);
            this.txt_ETD.TabIndex = 3;
            this.txt_ETD.Text = "--";
            // 
            // txt_Freight
            // 
            this.txt_Freight.AutoSize = true;
            this.txt_Freight.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Freight.Location = new System.Drawing.Point(217, 43);
            this.txt_Freight.Name = "txt_Freight";
            this.txt_Freight.Size = new System.Drawing.Size(0, 18);
            this.txt_Freight.TabIndex = 4;
            // 
            // txt_NoInvoice
            // 
            this.txt_NoInvoice.AutoSize = true;
            this.txt_NoInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_NoInvoice.Location = new System.Drawing.Point(217, 69);
            this.txt_NoInvoice.Name = "txt_NoInvoice";
            this.txt_NoInvoice.Size = new System.Drawing.Size(0, 18);
            this.txt_NoInvoice.TabIndex = 5;
            // 
            // txt_destination
            // 
            this.txt_destination.AutoSize = true;
            this.txt_destination.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_destination.Location = new System.Drawing.Point(735, 61);
            this.txt_destination.Name = "txt_destination";
            this.txt_destination.Size = new System.Drawing.Size(89, 39);
            this.txt_destination.TabIndex = 6;
            this.txt_destination.Text = "ETD";
            // 
            // txt_ShippingLine
            // 
            this.txt_ShippingLine.AutoSize = true;
            this.txt_ShippingLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ShippingLine.ForeColor = System.Drawing.Color.DarkRed;
            this.txt_ShippingLine.Location = new System.Drawing.Point(454, 11);
            this.txt_ShippingLine.Name = "txt_ShippingLine";
            this.txt_ShippingLine.Size = new System.Drawing.Size(128, 58);
            this.txt_ShippingLine.TabIndex = 7;
            this.txt_ShippingLine.Text = "ETD";
            // 
            // txt_Carline
            // 
            this.txt_Carline.AutoSize = true;
            this.txt_Carline.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Carline.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txt_Carline.Location = new System.Drawing.Point(735, 14);
            this.txt_Carline.Name = "txt_Carline";
            this.txt_Carline.Size = new System.Drawing.Size(89, 39);
            this.txt_Carline.TabIndex = 8;
            this.txt_Carline.Text = "ETD";
            this.txt_Carline.Click += new System.EventHandler(this.txt_Carline_Click);
            // 
            // MappingDR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "MappingDR";
            this.Size = new System.Drawing.Size(1769, 840);
            this.Load += new System.EventHandler(this.MappingDR_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgsDraftDR)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView DgsDraftDR;
        private System.Windows.Forms.Label txt_NoInvoice;
        private System.Windows.Forms.Label txt_Freight;
        private System.Windows.Forms.Label txt_ETD;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label txt_ShippingLine;
        private System.Windows.Forms.Label txt_destination;
        private System.Windows.Forms.Label txt_Carline;
    }
}
