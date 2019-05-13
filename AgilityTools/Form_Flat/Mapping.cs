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
    public partial class Mapping : Form
    {
        public Mapping()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Head_txt.Text = Mapping_Btn.Text;
            panel3.Controls.Clear();
            panel3.Dock = DockStyle.Fill;
            MapingHome userControl = new MapingHome();
            userControl.Dock = DockStyle.Fill;
            panel3.Controls.Add(userControl);
        }

        private void ReceivingForm_Click(object sender, EventArgs e)
        {
            Head_txt.Text = ReceivingForm.Text;
            panel3.Controls.Clear();
            panel3.Dock = DockStyle.Fill;
            ReceivingHome userControl = new ReceivingHome();
            userControl.Dock = DockStyle.Fill;
            panel3.Controls.Add(userControl);
        }
    }
}
