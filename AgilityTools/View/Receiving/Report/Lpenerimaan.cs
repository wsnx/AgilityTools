using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace AgilityTools.View.Receiving.Report
{
    public partial class Lpenerimaan : UserControl
    {
        public Lpenerimaan()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            ReportDocument cryRpt = new ReportDocument();
            cryRpt.Load("C:\\CR\\StandarReport.rpt");
            crystalReportViewer1.Refresh();
            crystalReportViewer1.Show();

        }
        private void OpenCR()
        {

            ReportDocument cryRpt = new ReportDocument();
            ParameterFieldDefinitions crParameterFieldDefinitions;
            ParameterFieldDefinition crParameterFieldDefinition;
            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();
            cryRpt.Load("C:\\CR\\Lpenerimaan.rpt");
            crParameterDiscreteValue.Value = txt_Receiptkey.Text;
            crystalReportViewer1.ReportSource = cryRpt;
            crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["RECEIPTKEY"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;
            crParameterValues.Clear();
            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);
            cryRpt.SetDatabaseLogon("kadmin", "53c4dm1n", "10.130.24.4", "KaizenDB");
            crystalReportViewer1.Refresh();
            crystalReportViewer1.Show();
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            OpenCR();
        }
    }
}
