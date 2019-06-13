using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AgilityTools.View.Receiving;
using AgilityTools.View.Receiving.Report;

namespace AgilityTools
{
    
    public partial class ReceivingHome : UserControl
    {

        public string key = "";
        public ReceivingHome()
        {
            InitializeComponent();
        }
        public string PrintKey
        {
            
            get { return key; }
            set { key = value; }
        }

        private void NodesHandler()
        {  
        }
        
        public void ReceivingTree_AfterSelect(object sender, TreeViewEventArgs e)
        {

            TreeNode node = ReceivingTree.SelectedNode;
            lblForm.Text = node.Text;
            if (node.Text == "Back")
            {
                ContentView f = new ContentView();
                f.Close();
                Home f2 = new Home();
                f2.MdiParent = AgilityTools.ActiveForm;
                f2.Show();
            }
            else if (node.Text == "Planing")
            {
                PanelView.Controls.Clear();
                PanelView.Dock = DockStyle.Fill;
                ReceivedList userControl = new ReceivedList();
                userControl.Dock = DockStyle.Fill;
                PanelView.Controls.Add(userControl);
            }
            else if (node.Text == "Report")
            {


            }
            else if (node.Text == "ITS")
            {
                key = "ITS";
                PanelView.Controls.Clear();
                PanelView.Dock = DockStyle.Fill;
                ITS userControl = new ITS();
                userControl.Dock = DockStyle.Fill;
                PanelView.Controls.Add(userControl);

            }
            else if (node.Text == "GRN")
            {
                key = "Lpenerimaan";
                PanelView.Controls.Clear();
                PanelView.Dock = DockStyle.Fill;                
                Lpenerimaan userControl = new Lpenerimaan();
                userControl.Dock = DockStyle.Fill;
                PanelView.Controls.Add(userControl);

            }
            else if (node.Text == "Selisih")
            {

                key = "Lselisih";
                PanelView.Controls.Clear();
                PanelView.Dock = DockStyle.Fill;
                Lselisih userControl = new Lselisih();
                userControl.Dock = DockStyle.Fill;
                PanelView.Controls.Add(userControl);

            }
            else if (node.Text == "SampleQR")
            {
                PanelView.Controls.Clear();
                PanelView.Dock = DockStyle.Fill;
                SampleQR userControl = new SampleQR();
                userControl.Dock = DockStyle.Fill;
                PanelView.Controls.Add(userControl);
            }
            else
            {
            }

        }
    }
}
