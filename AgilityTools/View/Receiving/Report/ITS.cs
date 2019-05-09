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
            ReportDocument cryRpt = new ReportDocument();
            cryRpt.Load("C:\\CR\\ReportITS.rpt");
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
