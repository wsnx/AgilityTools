using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Net;
using System.IO;
using CrystalDecisions.Web;
using System.Data.SqlClient;

namespace AgilityTools
{
    public partial class ITS :UserControl
    {
        private static DateTime Editdate = DateTime.Now;
        SqlConnection ConnWMS = new SqlConnection(ConfigDB.conWMS);
        SqlConnection ConnLocal = new SqlConnection(ConfigDB.DBlocal);
        DataSet dsWMS = new DataSet();
        public string receiptkey ;

        public string receiptkey1;
        public ITS()
        {
            InitializeComponent();
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            getreceiptkey();
            Insert();
            openCR();

        }
        private void Insert()
        {


            ConnLocal.Close();
            ConnLocal.Open();
            SqlCommand cmd = new SqlCommand("truncate table tbPLBSAMI_FG_rptITS", ConnLocal);
            cmd.ExecuteNonQuery();
            ConnLocal.Close();
            string areceiptkey =receiptkey.ToString();
            DataSet ds = new DataSet();
                ConnWMS.Open();
                    SqlDataAdapter DA = new SqlDataAdapter("  select case when a.STORERKEY like'%PLBSAMTFG%' then 'SAMI TUGU' when a.STORERKEY like'%PLBSAMJFG%' then 'SAMI JEPARA' END Customer, cast(b.ADDDATE as date) as TglASN,b.WAREHOUSEREFERENCE,b.CONTAINERKEY,a.receiptkey,a.EXTERNRECEIPTKEY,a.sku,cast(count(Lottable10)as int)as JumlahCarton,altsku as Pallet,UOM , " +
                    "  LOTTABLE03 as DocBCNomor,b.TrailerNumber,'1' as ID ,a.Pokey ,sum(qtyexpected)expected from receiptdetail a inner join RECEIPT b on a.RECEIPTKEY = b.RECEIPTKEY " +
                    " where a.RECEIPTKEY in (" +areceiptkey+ ")  " +
                    " group by a.STORERKEY, a.RECEIPTKEY, a.sku, UOM, altsku, a.EXTERNRECEIPTKEY, LOTTABLE03, b.TrailerNumber, b.ADDDATE, b.WAREHOUSEREFERENCE, b.CONTAINERKEY,a.Pokey order by altsku", ConnWMS);
                ds= new DataSet();
                DA.Fill(ds);
                ConnWMS.Close();
            ConnLocal.Close();
            ConnLocal.Open();

            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(ConnLocal))
            {
                bulkCopy.DestinationTableName =
                    "tbPLBSAMI_FG_rptITS";

                try
                {
                    bulkCopy.WriteToServer(ds.Tables[0]);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            ConnLocal.Close();
        
        }   
        private void getreceiptkey()
        {
            
            string hasil = "";
            try
            {

                foreach (DataGridViewRow row in dgsList.Rows)
                {
                    bool isSelected = Convert.ToBoolean(row.Cells[0].Value);
                    if (isSelected)
                    {
                                string receiptkeya = row.Cells["Receiptkey"].Value.ToString();
                                hasil += ",'" + receiptkeya + "'";
                    }

                }
                 }
            catch (Exception ex)
            {

            }

            int a = hasil.Length - 1;
            string aa = hasil.Substring(1, a);
            receiptkey = aa.ToString();

        }
        private void getList()
        {
            try
            {

                dgsList.Columns.Clear();
                //WMS
                ConnWMS.Close();
                ConnWMS.Open();
                SqlCommand cmdwms = new SqlCommand();
                cmdwms.Connection = ConnWMS;
                cmdwms.CommandText = ("select Receiptkey,Containerkey,case when STATUS = 0 then 'New' when STATUS = '9' then 'Received' end Status from RECEIPT where status <11 and storerkey like 'PLBSAM%'");
                SqlDataAdapter DA = new SqlDataAdapter(cmdwms);
                DataSet ds = new DataSet();
                DA.Fill(ds);
                DataTable Orders = ds.Tables[0];
                ConnWMS.Close();
                ConnLocal.Close();
                //Local
                ConnLocal.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = ConnLocal;
                cmd.CommandText = "select DocNumber,cast(count(DocNumber)as int)CountPrinted,convert(varchar,MAX(EditDate),120)as Date,MAX(EditWho)as Who from " +
                    "  tbPLBSAMI_FG_PrintStamp where DocType='ITS'group by DocType,DocNumber";
                SqlDataAdapter DALocal = new SqlDataAdapter(cmd);
                DataSet dsLocal = new DataSet();
                DALocal.Fill(dsLocal);
                DataTable OrdersLocal = dsLocal.Tables[0];
                ConnLocal.Close();

                //Joining
                DataTable dtResult = new DataTable();
                
                dtResult.Columns.Add("Receiptkey", typeof(string));
                dtResult.Columns.Add("ContainerKey", typeof(string));
                //dtResult.Columns.Add("Printx", typeof(int));
                dtResult.Columns.Add("PrintedBy", typeof(string));
                dtResult.Columns.Add("PrintedDate", typeof(string));
                IEnumerable<DataRow> query =
                from Wms in Orders.AsEnumerable()
                join Locals in OrdersLocal.AsEnumerable() on Wms.Field<string>("Receiptkey") equals
                 Locals.Field<string>("DocNumber")
                into cek
                from r in cek.DefaultIfEmpty()
                select dtResult.LoadDataRow(new object[]{
                   
                    Wms.Field<string>("Receiptkey")   ,
                    Wms.Field<string>("ContainerKey") ,
                    r==null?" ":r.Field<string>("Who"),
                    r==null?" ":r.Field<string>("Date")

                }, false);

                // Show in Grid

                
                DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
                checkBoxColumn.HeaderText = "Pilih";
                checkBoxColumn.Width = 30;
                checkBoxColumn.Name = "checkBoxColumn";
                dgsList.Columns.Insert(0, checkBoxColumn);


                DataTable boundTable = query.CopyToDataTable<DataRow>();
                dgsList.DataSource = boundTable;
                DgsBindingList.DataSource = boundTable;



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void getList2()
        {
            try
            {

                dgsList.Columns.Clear();
                //WMS
                ConnWMS.Close();

                ConnWMS.Open();
                SqlCommand cmdwms = new SqlCommand();
                cmdwms.Connection = ConnWMS;
                cmdwms.CommandText = ("select Receiptkey,TrailerNumber,STATUS as tes from RECEIPT where status <11");
                SqlDataAdapter DA = new SqlDataAdapter(cmdwms);
                DataSet ds = new DataSet();
                DA.Fill(ds);
                DataTable Orders = ds.Tables[0];
                ConnWMS.Close();

                ConnLocal.Close();
                //Local
                ConnLocal.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = ConnLocal;
                cmd.CommandText = "select DocNumber,cast(count(DocNumber)as int)CountPrinted,convert(varchar,MAX(EditDate),120)as Date,MAX(EditWho)as Who from " +
                    "  tbPLBSAMI_FG_PrintStamp where DocType='ITS'group by DocType,DocNumber";
                SqlDataAdapter DALocal = new SqlDataAdapter(cmd);
                DataSet dsLocal = new DataSet();
                DALocal.Fill(dsLocal);
                DataTable OrdersLocal = dsLocal.Tables[0];
                ConnLocal.Close();

                //Joining
                DataTable dtResult = new DataTable();

                dtResult.Columns.Add("Receiptkey", typeof(string));
                dtResult.Columns.Add("TrailerNumber", typeof(string));
                //dtResult.Columns.Add("Printx", typeof(int));
                dtResult.Columns.Add("PrintedBy", typeof(string));
                dtResult.Columns.Add("PrintedDate", typeof(string));

                DataTable dtdiffrence = new DataTable();
                var diff= Orders.AsEnumerable().Except(OrdersLocal.AsEnumerable(),
                                                                    DataRowComparer.Default);
                dtdiffrence = diff .Any() ? diff.CopyToDataTable() : new DataTable();
                // Show in Grid

                DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
                checkBoxColumn.HeaderText = "Pilih";
                checkBoxColumn.Width = 30;
                checkBoxColumn.Name = "checkBoxColumn";
                dgsList.Columns.Insert(0, checkBoxColumn);


                dgsList.DataSource = dtdiffrence;
                DgsBindingList.DataSource = dtdiffrence;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void UpdatePrint()
        {
            string hasil = "";
            foreach (DataGridViewRow Row in dgsList.Rows)
            {

                if (Row.Cells[0].Value != null)
                {
                    if ((bool)(Row.Cells[0].Value) == true)
                    {
                        ConnLocal.Close();
                        string receiptkey = dgsList.Rows[Row.Index].Cells["Receiptkey"].Value.ToString();
                        SqlCommand cmd = new SqlCommand("insert into tbPLBSAMI_FG_PrintStamp(DOCtype,DocNumber,Editdate,EditWho,Notes) values " +
                    " (@DOCtype,@DocNumber,@Editdate,@EditWho,@Notes) " +
                     "    ", ConnLocal);
                        cmd.Parameters.Add(new SqlParameter("Doctype", "ITS"));
                        cmd.Parameters.Add(new SqlParameter("DocNumber", receiptkey.ToString()));
                        cmd.Parameters.Add(new SqlParameter("Editdate", Editdate));
                        cmd.Parameters.Add(new SqlParameter("EditWho", FormLogin.NIK + " " + FormLogin.UserName));
                        cmd.Parameters.Add(new SqlParameter("Notes", ""));
                        try
                        {

                            ConnLocal.Close();
                            ConnLocal.Open();
                            cmd.ExecuteNonQuery();
                            getList();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }
                }
            }
        }
        private void openCR()
        {
            try
            {
                ReportDocument cryRpt = new ReportDocument();
                TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
                TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
                ConnectionInfo crConnectionInfo = new ConnectionInfo();
                Tables CrTables;
                cryRpt.Load(@"C:\\CR\\ReportITS.rpt");
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
                Btn_Print.Enabled = false;
                tabControl1.SelectedTab = tabPage2;
                UpdatePrint();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
        
        }
        private void ReceivingReport_Load(object sender, EventArgs e)
        {
            Btn_Print.Enabled = false;
            getList();
            
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            if (CekBox.Checked == true)
            {
                getList();

            }
            else
            {
                getList2();
            }


        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void dgsList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Btn_Print.Enabled = true;
        }

        private void dgsList_FilterStringChanged(object sender, EventArgs e)
        {
            this.DgsBindingList.Filter = this.dgsList.FilterString;

        }

        private void dgsList_SortStringChanged(object sender, EventArgs e)
        {
            this.DgsBindingList.Sort = this.dgsList.SortString;
        }
    }
}
