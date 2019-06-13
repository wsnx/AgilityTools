using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgilityTools.View.Receiving
{
    public partial class Reports : Form
    {
        public Reports()
        {
            InitializeComponent();
        }
        private void OpenCR()
        {
            ReportDocument cryRpt = new ReportDocument();
            ParameterFieldDefinitions crParameterFieldDefinitions;
            ParameterFieldDefinition crParameterFieldDefinition;
            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();
            cryRpt.Load("C:\\CR\\Lpenerimaan.rpt");
            crParameterDiscreteValue.Value = ReceivedList.vKey.ToString();
            crystalReportViewer1.ReportSource = cryRpt;
            cryRpt.SetDatabaseLogon("kadmin", "53c4dm1n", "10.130.24.4", "KaizenDB");
            crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["RECEIPTKEY"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;
            crParameterValues.Clear();
            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);
            crystalReportViewer1.Refresh();
            crystalReportViewer1.Show();

        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            OpenCR();
        }
    }
}
