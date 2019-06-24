using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AgilityTools
{
    public partial class Explorer : UserControl
    {
        public static string vkey;
        public Explorer()
        {
            InitializeComponent();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = treeView1.SelectedNode;
            if (node.Text == "Log Out")
            {
                vkey = "0";
                Home n = new Home();
                n.Close();
            }
            else if (node.Text == "Receiving")
            {
                vkey = "1";
                ContentView f2 = new ContentView();
                f2.MdiParent = AgilityTools.ActiveForm;
                f2.Show();

            }
            else if (node.Text == "Mapping")
            {
                vkey ="2";
                ContentView f2 = new ContentView();
                f2.MdiParent = AgilityTools.ActiveForm;
                f2.Show();
            }
            else if (node.Text == "Order")
            {
                vkey = "3";
                ContentView f2 = new ContentView();
                f2.MdiParent = AgilityTools.ActiveForm;
                f2.Show();
            }
         }
        private void Explorer_Load(object sender, EventArgs e)
        {
            lblUserName.Text = FormLogin.UserName.ToString();
        }
    }
}
