﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

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
            cryRpt.Load("C:\\CR\\standarReport.rpt");
            crystalReportViewer1.ReportSource = cryRpt;
            crystalReportViewer1.Refresh();

        }

        private void OpenCR()
        {

            ReportDocument cryRpt = new ReportDocument();
            ParameterFieldDefinitions crParameterFieldDefinitions;
            ParameterFieldDefinition crParameterFieldDefinition;
            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();
            cryRpt.Load("C:\\CR\\MovementMAP.rpt");
            crParameterDiscreteValue.Value = txt_fromReceiptkey.Text;
            crystalReportViewer1.ReportSource = cryRpt;
            crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["taskID"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;
            crParameterValues.Clear();
            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);
            cryRpt.SetDatabaseLogon(ConfigDB.DbUserNameLocal, ConfigDB.DbPasswordLocal, ConfigDB.DbHostnameLocal, ConfigDB.DbNameLocal);
            crystalReportViewer1.Refresh();
            crystalReportViewer1.Show();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            OpenCR();
        }
    }
}
