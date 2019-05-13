using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using System.Net;
using System.IO;

namespace AgilityTools
{
    public partial class ITS :UserControl
    {
        public ITS()
        {
            InitializeComponent();
            
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            openCR();
        }
        private void openCR()
        {
            WebClient request = new WebClient();
            request.Credentials = new NetworkCredential("Logistics\\administrator", "Useradm1n");
            string[] theFolders = Directory.GetDirectories(@"\\10.130.37.5\repository\home\CR");

            ReportDocument cryRpt = new ReportDocument();
            cryRpt.Load("\\10.130.37.5\\repository\\home\\CR");
            crystalReportViewer1.ReportSource = cryRpt;
            crystalReportViewer1.Refresh();

        }
        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
/*
            ReportDocument cryRpt = new ReportDocument();
            cryRpt.Load("C:\\CR\\ITS.rpt");
            crystalReportViewer1.ReportSource = cryRpt;
            crystalReportViewer1.Refresh();
            /*
            if (ReceivingHome.key== "ITS") {
                ReportDocument cryRpt = new ReportDocument();
                cryRpt.Load("C:\\CR\\ITS.rpt");
                crystalReportViewer1.ReportSource = cryRpt;
                crystalReportViewer1.Refresh();
                
            }else if (key == "Lpenerimaan")
            {

                ReportDocument cryRpt = new ReportDocument();
                cryRpt.Load("C:\\CR\\Lpenerimaan.rpt");
                crystalReportViewer1.ReportSource = cryRpt;
                crystalReportViewer1.Refresh();
            }
            else if (key == "Lselisih")
            {

                ReportDocument cryRpt = new ReportDocument();
                cryRpt.Load("C:\\CR\\Lselisih.rpt");
                crystalReportViewer1.ReportSource = cryRpt;
                crystalReportViewer1.Refresh();
            }
            */
        }
        
        
        private void ReceivingReport_Load(object sender, EventArgs e)
        {
            
        }
    }
}
