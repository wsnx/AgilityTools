using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Threading.Tasks;
using TextBox = System.Windows.Forms.TextBox;

namespace AgilityTools
{
    public partial class Navigation : Form
    {
        public Navigation()
        {
            Thread t = new Thread(new ThreadStart(StartForm));
            t.Start();
            Thread.Sleep(1000);
            t.Abort();
            InitializeComponent();
            webBrowser1.ScriptErrorsSuppressed = true;
            TimeUpdater();
        }

        async void TimeUpdater()
        {
            while (true)
            {
                txt_Jam.Text = DateTime.Now.ToString("dd-MMMM-yyyy HH:mm:ss");
                await Task.Delay(1000);
            }
        }

        private void StartForm()
        {
            Application.Run(new SplashScreen());
        }

        private void Btn_Closed_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_inbound_plan_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
            Lbl_menu.Text = "Receiving";
            panelView.Controls.Clear();
            panelView.Dock = DockStyle.Fill;
            Receiving userControl=new Receiving();
            userControl.Dock = DockStyle.Fill;
            panelView.Controls.Add(userControl);
        }

        private void btn_MappingPlan_Click(object sender, EventArgs e)
        {

            tabControl1.SelectedTab = tabPage1;
            Lbl_menu.Text = "Mapping";
            panelView.Controls.Clear();
            panelView.Dock = DockStyle.Fill;
            MappingList userControl = new MappingList();
            userControl.Dock = DockStyle.Fill;
            panelView.Controls.Add(userControl);
        }

        private void btn_orderPlan_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
            Lbl_menu.Text = "Shipment";
            panelView.Controls.Clear();
            panelView.Dock = DockStyle.Fill;
            OrderHome userControl = new OrderHome();
            userControl.Dock = DockStyle.Fill;
            panelView.Controls.Add(userControl);

        }

        private void Btn_Closed_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
            this.Close();
        }

        private void Navigation_Load(object sender, EventArgs e)
        {
            NavBar.Cursor = Cursors.Hand;
            toolStrip2.Cursor = Cursors.Hand;
            btn_Max.Visible = false;
            Home_btn.Visible = false;
            Release_Nav.Visible = false;
            Btn_Profil.Text=FormLogin.UserName;
        }

        private void btn_signOut_Click(object sender, EventArgs e)
        {
           this.Hide();
           FormLogin f2 = new FormLogin();
           f2.Show();
        }

        private void Btn_profDetail_Click(object sender, EventArgs e)
        {

            panelView.Controls.Clear();
            Lbl_menu.Text = "User Management";
            panelView.Dock = DockStyle.Fill;
            Profile userControl = new Profile();
            userControl.Dock = DockStyle.Fill;
            panelView.Controls.Add(userControl);

        }

        private void btn_ITS_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
            Lbl_menu.Text = "Receiving";
            panelReport.Controls.Clear();
            panelReport.Dock = DockStyle.Fill;
            ITS userControl = new ITS();
            userControl.Dock = DockStyle.Fill;
            panelReport.Controls.Add(userControl);
        }

        private void btn_PrintMappingList_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
            Lbl_menu.Text = "Mapping";

            panelReport.Controls.Clear();
            panelReport.Dock = DockStyle.Fill;
            rptMappingList userControl = new rptMappingList();
            userControl.Dock = DockStyle.Fill;
            panelReport.Controls.Add(userControl);
        }

        private void btn_PrintUpdatePallet_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
            Lbl_menu.Text = "Inventory";

            panelReport.Controls.Clear();
            panelReport.Dock = DockStyle.Fill;
            rptMovev2 userControl = new rptMovev2();
            userControl.Dock = DockStyle.Fill;
            panelReport.Controls.Add(userControl);
        }

        private void Btn_NavMini_Click(object sender, EventArgs e)
        {
            Home_btn.Visible = true;
            Release_Nav.Visible = true;
            btn_Mapping.DisplayStyle = ToolStripItemDisplayStyle.Image;
            Btn_Invnetory.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btn_Receiving.DisplayStyle = ToolStripItemDisplayStyle.Image;
            Btn_Shipment.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnHandOver.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btn_home.Visible = false;
            Btn_NavMini.Visible = false;

        }

        private void Release_Nav_Click(object sender, EventArgs e)
        {
            Home_btn.Visible = false;
            Release_Nav.Visible = false;
            btn_Mapping.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            Btn_Invnetory.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            btn_Receiving.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            Btn_Shipment.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            btnHandOver.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            btnHandOver.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            btn_home.Visible = true;
            Btn_NavMini.Visible = true;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void panelView_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_normal_Click(object sender, EventArgs e)
        {
            btn_normal.Visible = false;
            this.WindowState = FormWindowState.Normal;
            btn_Max.Visible = true;
        }

        private void btn_Max_Click(object sender, EventArgs e)
        {
            btn_normal.Visible = true;
            this.WindowState = FormWindowState.Maximized;
            btn_Max.Visible = false ;
        }

        private void btn_GRN_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
            Lbl_menu.Text = "Receiving";
            panelReport.Controls.Clear();
            panelReport.Dock = DockStyle.Fill;
            Lpenerimaan2 userControl = new Lpenerimaan2();
            userControl.Dock = DockStyle.Fill;
            panelReport.Controls.Add(userControl);

        }

        private void btn_sample_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
            Lbl_menu.Text = "Receiving";
            panelReport.Controls.Clear();
            panelReport.Dock = DockStyle.Fill;
            SampleQR userControl = new SampleQR();
            userControl.Dock = DockStyle.Fill;
            panelReport.Controls.Add(userControl);

        }

        private void btn_Prepare_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
            Lbl_menu.Text = "Receiving";
            panelReport.Controls.Clear();
            panelReport.Dock = DockStyle.Fill;
            rptMovementList userControl = new rptMovementList();
            userControl.Dock = DockStyle.Fill;
            panelReport.Controls.Add(userControl);
        }

        private void btn_Updater_Click(object sender, EventArgs e)
        {

        }
        private void btn_WMS_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
            webBrowser1.Refresh();

        }

        private void Btn_PalletUpdate_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
            tabPage3.Text = "Report";
            panelReport.Controls.Clear();
            panelReport.Dock = DockStyle.Fill;
            PalletUpdater userControl = new PalletUpdater();
            userControl.Dock = DockStyle.Fill;
            panelReport.Controls.Add(userControl);
        }

        private void panelView_Paint_1(object sender, PaintEventArgs e)
        {
            
        }
        protected void DownloadFile(object sender, EventArgs e)
        {

        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void btn_DraftDR_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
            Lbl_menu.Text = "Mapping";
            panelView.Controls.Clear();
            panelView.Dock = DockStyle.Fill;
            PlaningMapping userControl = new PlaningMapping();
            userControl.Dock = DockStyle.Fill;
            panelView.Controls.Add(userControl);
        }

        private void Btn_Invnetory_Click(object sender, EventArgs e)
        {

        }

        private void pTFByWaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
            Lbl_menu.Text = "Mapping";
            panelReport.Controls.Clear();
            panelReport.Dock = DockStyle.Fill;
            PickTicket userControl = new PickTicket();
            userControl.Dock = DockStyle.Fill;
            panelReport.Controls.Add(userControl);

        }

        private void Btn_CekPicking_Click(object sender, EventArgs e)
        {


        }

        private void btn_OrderReport_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
            Lbl_menu.Text = "Shipment";
            panelReport.Controls.Clear();
            panelReport.Dock = DockStyle.Fill;
            RptPickingForm userControl = new RptPickingForm();
            userControl.Dock = DockStyle.Fill;
            panelReport.Controls.Add(userControl);
            
        }

        private void btn_SOH_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
            Lbl_menu.Text = "Inventory";
            panelReport.Controls.Clear();
            panelReport.Dock = DockStyle.Fill;
            ReportSOH userControl = new ReportSOH();
            userControl.Dock = DockStyle.Fill;
            panelReport.Controls.Add(userControl);
            /*
            TabPage tp = new TabPage("Data");
            tabControl1.TabPages.Add(tp);
            TextBox tb = new TextBox();
            tb.Dock = DockStyle.Fill;
            tb.Multiline = true;
            tp.Controls.Add(tb);
            */
        }

        private void Btn_Shipment_Click(object sender, EventArgs e)
        {

        }
    }
}
