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
    public partial class OrderNavigation : UserControl
    {
        public OrderNavigation()
        {
            InitializeComponent();
        }

        private void OrderTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = OrderTree.SelectedNode;
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
                panelView.Controls.Clear();
                panelView.Dock = DockStyle.Fill;
                OrderHome userControl = new OrderHome();
                userControl.Dock = DockStyle.Fill;
                panelView.Controls.Add(userControl);
            }
        }
    }
}
