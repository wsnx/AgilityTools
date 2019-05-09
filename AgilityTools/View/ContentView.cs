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
    public partial class ContentView : Form
    {
        private static string key = Home.vKey;
        public ContentView()
        {
            InitializeComponent();
            this.Size = new System.Drawing.Size(1000, 600);
            vHandler();
        }
        private  void vHandler()
        {
            if (Home.vKey == "1")
            {
                panelView.Controls.Clear();
                panelView.Dock = DockStyle.Fill;

                ReceivingHome userControl = new ReceivingHome();
                userControl.Dock = DockStyle.Fill;
                panelView.Controls.Add(userControl);
                
            }
            else
            if (Home.vKey == "2")
            {
                panelView.Controls.Clear();
                panelView.Dock = DockStyle.Fill;
                MappingHomes userControl = new MappingHomes();
                userControl.Dock = DockStyle.Fill;
                panelView.Controls.Add(userControl);

            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home f2 = new Home();
            f2.MdiParent = AgilityTools.ActiveForm;
            f2.Show();
        }
    }
}
