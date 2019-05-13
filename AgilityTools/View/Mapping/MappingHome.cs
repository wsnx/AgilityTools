using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgilityTools
{
    public partial class MappingHomes : UserControl
    {
        public MappingHomes()
        {
            InitializeComponent();
        }

        private void MappingTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = MappingTree.SelectedNode;

            if (node.Text == "Back")
            {

                Home f2 = new Home();
                f2.MdiParent = AgilityTools.ActiveForm;
                f2.Show();
            }

            else if (node.Text == "Create")
            {

                PanelView.Controls.Clear();
                PanelView.Dock = DockStyle.Fill;
                MappingList userControl = new MappingList();
                userControl.Dock = DockStyle.Fill;
                PanelView.Controls.Add(userControl);
            }


        }
    }
}
