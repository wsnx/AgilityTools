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
    public partial class MappingHomes : UserControl
    {

        public static string vKey;
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
            else if (node.Text == "MappingList")
            {
                vKey ="1";
                PanelView.Controls.Clear();
                PanelView.Dock = DockStyle.Fill;
                rptMappingList userControl = new rptMappingList();
                userControl.Dock = DockStyle.Fill;
                PanelView.Controls.Add(userControl);
            }
            else if (node.Text == "MovementList")
            {
                vKey = "2";
                PanelView.Controls.Clear();
                PanelView.Dock = DockStyle.Fill;
                rptMovementList userControl = new rptMovementList();
                userControl.Dock = DockStyle.Fill;
                PanelView.Controls.Add(userControl);
            }
            else if (node.Text == "PalletLabel")
            {
                vKey = "1";
                PanelView.Controls.Clear();
                PanelView.Dock = DockStyle.Fill;
                rptPalletLabel userControl = new rptPalletLabel();
                userControl.Dock = DockStyle.Fill;
                PanelView.Controls.Add(userControl);
            }

        }
    }
}
