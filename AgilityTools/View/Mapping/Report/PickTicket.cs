using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace AgilityTools
{
    public partial class PickTicket : UserControl
    {

        SqlConnection ConnWMS = new SqlConnection(ConfigDB.conWMS);
        SqlConnection ConnLocal = new SqlConnection(ConfigDB.DBlocal);

        public PickTicket()
        {
            InitializeComponent();
        }
        private void txt_storerkey_Click(object sender, EventArgs e)
        {

        }
        private void btn_getList_Click(object sender, EventArgs e)
        {
            GetList();
        }
        private void GetList()
        {
            try
            {
                dgsList.Columns.Clear();
                ConnWMS.Close();
                ConnWMS.Open();

                SqlDataAdapter DA = new SqlDataAdapter(" select d.WAVEKEY,a.externorderkey from orderdetail a inner join ORDERSTATUSSETUP b on a.status = b.code  inner join (select a.loc,a.sku,a.ID,b.lottable09, b.lottable10 from lotxlocxid a inner join lotattribute b on a.lot = b.lot where qty>0 ) c  on a.sku = c.sku  and a.lottable10 = c.lottable10 and a.lottable09 = c.lottable09  inner join wavedetail d on a.orderkey = d.orderkey where status<14 group by  d.WAVEKEY,a.externorderkey"
                    , ConnWMS);
                DataSet DS = new DataSet();
                DA.Fill(DS);

                dgsList.DataSource = DS.Tables[0];
                dgsListBinding.DataSource = DS.Tables[0];
                ConnWMS.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btn_printManual_Click(object sender, EventArgs e)
        {
            if (txt_DocType.Text == "ASN")
            {

                rptByASN();
                tabControl1.SelectedTab = tabPrint;


            }
            else if (txt_DocType.Text == "Wave")

            {

                rptByWaveComplete();
                tabControl1.SelectedTab = tabPrint;
            }
            else if (txt_DocType.Text == "SummaryMapping")

            {

                CreateDataSummary();
                tabControl1.SelectedTab = tabPrint;
            }
            else if (txt_DocType.Text == "Wave by DR.No")

            {

                rptByWaveDR();
                tabControl1.SelectedTab = tabPrint;
            }


        }

        private void printByWave()
        {
            MessageBox.Show("Pastikan SO yang anda Pilih sudah di lakukan Proses Wave ada di WMS");
        }

        private void CreateData()
        {
            ConnLocal.Close();
            ConnLocal.Open();
            SqlCommand cmd = new SqlCommand("truncate table tbplbsami_fg_ptf", ConnLocal);
            cmd.ExecuteNonQuery();
            ConnLocal.Close();
            string areceiptkey = txt_mappingID1.ToString();
            DataSet ds = new DataSet();
            ConnWMS.Open();
            SqlDataAdapter DA = new SqlDataAdapter
                ("select d.WAVEKEY, a.ORDERKEY, a.externorderkey, a.SKU, a.lottable09, a.lottable10, c.loc, c.ID, b.description Status, " +
                " case when c.loc like '%ID%' then substring(c.loc,4,2) else c.loc end Rack from orderdetail a inner join ORDERSTATUSSETUP b on a.status = b.code  inner join (select a.loc,a.sku,a.ID,b.lottable09, b.lottable10 from lotxlocxid a inner join lotattribute b on a.lot = b.lot where qty>0 ) c  on a.sku = c.sku  and a.lottable10 = c.lottable10 and a.lottable09 = c.lottable09  " +
                " inner join wavedetail d on a.orderkey = d.orderkey  where d.WAVEKEY='" + txt_mappingID1.Text + "' ", ConnWMS);

            ds = new DataSet();
            DA.Fill(ds);

            ConnWMS.Close();
            ConnLocal.Close();
            ConnLocal.Open();

            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(ConnLocal))
            {
                bulkCopy.DestinationTableName =
                    "tbplbsami_fg_ptf";

                try
                {
                    bulkCopy.WriteToServer(ds.Tables[0]);
                    printByOrderkey();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            ConnLocal.Close();

        }

        private void rptByWaveDR()
        {
            ReportDocument cryRpt = new ReportDocument();
            ParameterFieldDefinitions crParameterFieldDefinitions;
            ParameterFieldDefinition crParameterFieldDefinition;
            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();
            cryRpt.Load("C:\\CR\\PTFwave_Versi1.2.rpt");
            crParameterDiscreteValue.Value = txt_mappingID1.Text;
            crystalReportViewer1.ReportSource = cryRpt;
            crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["Wavekey"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;
            crParameterValues.Clear();
            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);
            cryRpt.SetDatabaseLogon(ConfigDB.DbUserName, ConfigDB.DbPassword, ConfigDB.DbHostname, ConfigDB.DbName);
            crystalReportViewer1.Refresh();
            crystalReportViewer1.Show();
        }

        private void rptByWaveComplete()
        {
            ReportDocument cryRpt = new ReportDocument();
            ParameterFieldDefinitions crParameterFieldDefinitions;
            ParameterFieldDefinition crParameterFieldDefinition;
            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();
            cryRpt.Load("C:\\CR\\PTFwave.rpt");
            crParameterDiscreteValue.Value = txt_mappingID1.Text;
            crystalReportViewer1.ReportSource = cryRpt;
            crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["Wavekey"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;
            crParameterValues.Clear();
            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);
            cryRpt.SetDatabaseLogon(ConfigDB.DbUserName, ConfigDB.DbPassword, ConfigDB.DbHostname, ConfigDB.DbName);
            crystalReportViewer1.Refresh();
            crystalReportViewer1.Show();
        }


        private void printByOrderkey()
        {
            ReportDocument cryRpt = new ReportDocument();
            TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
            TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
            ConnectionInfo crConnectionInfo = new ConnectionInfo();
            Tables CrTables;
            cryRpt.Load(@"C:\\CR\\PTFwave.rpt");
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
            tabControl1.SelectedTab = tabPrint;
        }

        private void rptByASN()
        {
            ReportDocument cryRpt = new ReportDocument();
            ParameterFieldDefinitions crParameterFieldDefinitions;
            ParameterFieldDefinition crParameterFieldDefinition;
            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();
            cryRpt.Load("C:\\CR\\ptfByASN.rpt");
            crParameterDiscreteValue.Value = txt_mappingID1.Text;
            crystalReportViewer1.ReportSource = cryRpt;
            crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["Receiptkey"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;
            crParameterValues.Clear();
            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);
            cryRpt.SetDatabaseLogon(ConfigDB.DbUserName, ConfigDB.DbPassword, ConfigDB.DbHostname, ConfigDB.DbName);
            crystalReportViewer1.Refresh();
            crystalReportViewer1.Show();
        }

        private void CreateDataSummary()
        {
            ConnLocal.Close();
            ConnLocal.Open();
            SqlCommand cmd = new SqlCommand("truncate table tbplbsami_fg_SummaryMapping", ConnLocal);
            cmd.ExecuteNonQuery();
            ConnLocal.Close();
            string areceiptkey = txt_mappingID1.ToString();
            DataSet ds = new DataSet();
            ConnWMS.Open();
            SqlDataAdapter DA = new SqlDataAdapter
                ("select  SO.C_CITY as PortDestination,SO.ORDERKEY,SO.EXTERNORDERKEY, SO.lottable09 AS AssyCode,cast(SO.Stok as Varchar) Stock,SO.LOTTABLE10,SO.SOH, SO.STORERKEY, SO.SUSR2 as Carmaker ,SO.DELIVERYDATE as ETD_PLB from  " +
                "(select c_city,SO.SUSR2,SO.EXTERNORDERKEY,SO.Storerkey,deliverydate,a.LOTTABLE10,a.LOTTABLE09,a.ORDERKEY,a.SKU ,case when  isnull(cast(b.Qty AS varchar),'')='' then 'x' else '' end 'Stok', isnull(b.Qty,'0') SOH " +
                " from PRAPR.wmwhse36.ORDERDETAIL a left  join (select  b.RECEIPTKEY ,a.LOT,a.SKU, b.ALTSKU as FromPallet,b.LOTTABLE10 as CartonID,a.QTY,a.STORERKEY,1 as StdPallet,b.STATUS, 'NN' carmaker, a.loc, d.locationflag, a.id as ToPalletID, b.datereceived,b.LOTTABLE09,c.SUSR6 boxType,c.BUSR9 as PalletType,replace(b.notes,'|',',')Qrcontent from LOTXLOCXID a join RECEIPTDETAIL b on a.lot = b.TOLOT inner join loc d on a.loc = d.LOC inner join (select sku, storerkey,susr6,BUSR9 from sku)c on a.sku = c.sku and a.storerkey = c.storerkey where a.STORERKEY like'%PLBS%' and d.loc <> 'Damage' and a.qty > 0)" +
                "b on a.sku = b.sku and a.LOTTABLE09 = b.lottable09 and a.LOTTABLE10 = b.CartonID  inner join PRAPR.wmwhse36.Orders SO on a.orderkey = SO.ORDERKEY " +
                "where  a.ORDERKEY ='"+txt_mappingID1.Text+"'  ) SO ", ConnWMS);

            ds = new DataSet();
            DA.Fill(ds);

            ConnWMS.Close();
            ConnLocal.Close();
            ConnLocal.Open();

            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(ConnLocal))
            {
                bulkCopy.DestinationTableName =
                    "tbplbsami_fg_SummaryMapping";

                try
                {
                    bulkCopy.WriteToServer(ds.Tables[0]);
                    printByOrderkey();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            ConnLocal.Close();

            using (SqlConnection conn = new SqlConnection(ConfigDB.DBlocal))
            {
                conn.Close();
                conn.Open();
                SqlCommand cmd2 = new SqlCommand("rptFinalDR", conn);
                cmd2.CommandType = System.Data.CommandType.StoredProcedure;
                //SqlParameter param = new SqlParameter();
                //param = cmd2.Parameters.Add("@Receiptkey", SqlDbType.VarChar, 50);
                //param.Direction = ParameterDirection.Input;
                //param.Value = txt_mappingID1.ToString();

                try
                {


                    cmd.ExecuteNonQuery();
                    conn.Close();
                    printBySummaryMappingList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }

        }
        private void printBySummaryMappingList()
        {
            ReportDocument cryRpt = new ReportDocument();
            TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
            TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
            ConnectionInfo crConnectionInfo = new ConnectionInfo();
            Tables CrTables;
            cryRpt.Load(@"C:\\CR\\PTFwave.rpt");
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
            tabControl1.SelectedTab = tabPrint;
        }

    }
}
