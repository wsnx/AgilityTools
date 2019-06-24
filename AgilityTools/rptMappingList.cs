using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;

namespace AgilityTools
{
    public partial class rptMappingList : UserControl
    {
        public rptMappingList()
        {
            InitializeComponent();
        }

        private void openCR()
        {
            ReportDocument cryRpt = new ReportDocument();
            ParameterFieldDefinitions crParameterFieldDefinitions;
            ParameterFieldDefinition crParameterFieldDefinition;
            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();
            cryRpt.Load("C:\\CR\\MappingList.rpt");
            crParameterDiscreteValue.Value = txt_fromReceiptkey.Text;
            crystalReportViewer1.ReportSource = cryRpt;
            crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["MappingID"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;
            crParameterValues.Clear();
            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);
            cryRpt.SetDatabaseLogon(ConfigDB.DbUserNameLocal, ConfigDB.DbPasswordLocal, ConfigDB.DbHostnameLocal, ConfigDB.DbNameLocal);
            crystalReportViewer1.Refresh();
            crystalReportViewer1.Show();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

            ReportDocument cryRpt = new ReportDocument();
            cryRpt.Load("C:\\CR\\StandarReport.rpt");
            crystalReportViewer1.ReportSource = cryRpt;
            crystalReportViewer1.Refresh();
            crystalReportViewer1.Show();

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            openCR();
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txt_fromReceiptkey_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
