using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgilityTools
{
    public partial class Home : Form
    {
        private string key;
        public static string vKey="2";
        public Home()
        {
            InitializeComponent();
            this.Size = new System.Drawing.Size(1000, 600);

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
                Home f2 = new Home();
                f2.MdiParent = AgilityTools.ActiveForm;
                f2.Show();
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
                TreeNode node = treeView1.SelectedNode;
                if (node.Text == "Receiving")
                {
                    this.Hide();
                    vKey = "1";
                    ContentView f2 = new ContentView();
                    f2.MdiParent = AgilityTools.ActiveForm;
                    f2.Show();

                }
                else if (node.Text == "Mapping")
                {
                    this.Hide();
                    vKey = "2";
                    ContentView f2 = new ContentView();
                    f2.MdiParent = AgilityTools.ActiveForm;
                    f2.Show();

                }
            else if (node.Text == "MappingList")
                {
                    key = "3";
                    NodesHandler();

                }
                else
                {
                    key = "0";
                    NodesHandler();
                }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
