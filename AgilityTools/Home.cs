using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace AgilityTools
{
    public partial class Home : Form
    {
        private string key;
        public static string vKey="1";
        public Home()
        {
            InitializeComponent();
            this.Size = new System.Drawing.Size(1000, 600);
              
        }
        private void DeleteConn()
        {
            //System.Diagnostics.Process.Start("Net.exe", @" * /del /y ");

        }
        
        private void ConnectReport()
        {

            //System.Diagnostics.Process.Start("Net.exe", @"use * \\10.130.37.5\Reports");
        }
        private void Home_Load(object sender, EventArgs e)
        {
            DeleteConn();
            ConnectReport();
            if (vKey =="1")
            {
                HomePanel.Controls.Clear();
                HomePanel.Dock = DockStyle.Fill;
                Explorer userControl = new Explorer();
                userControl.Dock = DockStyle.Fill;
                HomePanel.Controls.Add(userControl);
            }else if(vKey=="0")
            {
                this.Close();
                FormLogin f2 = new FormLogin();
                f2.MdiParent = AgilityTools.ActiveForm;
                f2.Show();

            }

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ExplorerView_MouseClick(object sender, MouseEventArgs e)
        {

        }
        private void NodesHandler()
        {
            goto cek;
            cek:
            if (key == "1")
            {
                }
            else if (key == "2")
            {
                }
            else if (key == "3")
            {
            }
            else if (key == "4")
            {

            }
            else if (key == "5")
            {

            }
            else if (key == "6")
            {

            }
            else if (key == "7")
            {

            }
            else if (key == "0")
            {
                this.Close();
                Home f2 = new Home();
                f2.MdiParent = AgilityTools.ActiveForm;
                f2.Show();
            }
        }
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblSignOut_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
    }
}
