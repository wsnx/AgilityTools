using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AgilityTools
{
    public partial class AgilityTools : Form
    {
        public AgilityTools()
        {
            InitializeComponent();
            FormLogin f2 = new FormLogin();
            f2.MdiParent = this;
            f2.Show();
             
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Controls.OfType<MdiClient>().FirstOrDefault().BackColor = Color.Black;
            
        }
    }
}
