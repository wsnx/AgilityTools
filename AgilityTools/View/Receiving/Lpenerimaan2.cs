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
using CrystalDecisions.Shared;
using System.Data.SqlClient;

namespace AgilityTools
{
    public partial class Lpenerimaan2 : UserControl
    {
        public Lpenerimaan2()
        {
            InitializeComponent();
        }

        private void OpenCR()
        {


                ReportDocument cryRpt = new ReportDocument();
                TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
                TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
                ConnectionInfo crConnectionInfo = new ConnectionInfo();
                Tables CrTables;
                cryRpt.Load(@"C:\\CR\\lpenerimaan.rpt");
                crConnectionInfo.ServerName = ConfigDB.DbHostnameLocal;
                crConnectionInfo.DatabaseName = ConfigDB.DbNameLocal;
                crConnectionInfo.UserID = ConfigDB.DbUserNameLocal;
                crConnectionInfo.Password = ConfigDB.DbPasswordLocal;

                CrTables = cryRpt.Database.Tables;
                foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTables)
                {
                    crtableLogoninfo = CrTable.LogOnInfo;
                    crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                    CrTable.ApplyLogOnInfo(crtableLogoninfo);
                }

                crystalReportViewer1.ReportSource = cryRpt;
                crystalReportViewer1.Refresh();

            }
        private void Btn_print_Click(object sender, EventArgs e)
        {
            CreateData();
        }
        private void CreateData()
        {
            using (SqlConnection conn = new SqlConnection(ConfigDB.DBlocal))
            {
                conn.Close();
                conn.Open();
                SqlCommand cmd = new SqlCommand("rptLpenerimaan", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter();
                param = cmd.Parameters.Add("@Receiptkey", SqlDbType.VarChar, 50);
                param.Direction = ParameterDirection.Input;
                param.Value = txt_fromReceiptkey.ToString();

                try
                {


                    cmd.ExecuteNonQuery();
                    conn.Close();
                    OpenCR();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
    }
}
