using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace AgilityTools
{
    public partial class rptMovementList : UserControl
    {
        public rptMovementList()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

            ReportDocument cryRpt = new ReportDocument();
            cryRpt.Load("C:\\CR\\MovementMAP.rpt");
            crystalReportViewer1.ReportSource = cryRpt;
            crystalReportViewer1.Refresh();

        }
    }
}
