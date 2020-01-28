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
using System.Diagnostics;

namespace AgilityTools
{
    public partial class rptMappingList : UserControl
    {
        SqlConnection ConnWMS = new SqlConnection(ConfigDB.conWMS);
        SqlConnection ConnLocal = new SqlConnection(ConfigDB.DBlocal);
        private static string DocType;
        private static string DocNumber;
        private static DateTime Editdate = DateTime.Now;
        private static string txt_mappingID;

        public rptMappingList()
        {
            InitializeComponent();
        }

        private void GetListNew()
        {
            Cursor.Current = Cursors.WaitCursor;
            using (SqlConnection conn = new SqlConnection(ConfigDB.DBlocal))
            {
                dgsList.Columns.Clear();
                SqlDataAdapter DA = new SqlDataAdapter("DisplayMappingList", conn);
                DA.SelectCommand.CommandType = CommandType.StoredProcedure;
                DA.SelectCommand.Parameters.AddWithValue("@orderkey", txt_storerkey.Text.ToString());
                DataSet DS = new DataSet();
                DA.Fill(DS);
                DataGridViewCheckBoxColumn CheckboxColumn = new DataGridViewCheckBoxColumn();
                CheckBox chk = new CheckBox();
                CheckboxColumn.Width = 20;
                dgsList.Columns.Add(CheckboxColumn);
                dgsList.DataSource = DS.Tables[0];
                dgsListBinding.DataSource = DS.Tables[0];
                ConnLocal.Close();
                conn.Close();
            }
         }
        private void GetList()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                dgsList.Columns.Clear();
                ConnLocal.Close();
                ConnLocal.Open();

                SqlDataAdapter DA = new SqlDataAdapter(
                    "select Max(receiptkey) 'ASN terakhir',e.plankey,c.MappingID,b.sku,b.lottable09 AssyCode ,Count(distinct(c.cartonID)) as 'Stock Ready', " +
                    "max(c.StdPallet)stdPallet,min(cast(b.cartonid as int)) as StartSerial, Max(cast(b.cartonid as int)) EndSerial,case when count(distinct(c.CartonID))<max(c.StdPallet) then 'Not Complete' else 'Complete' end StatusMapping ,max(f.Sticker) 'Verifikasi Label',d.Printby,d.PrintDate   " +
                    "from  tbplbsami_fg_stgMappingStock  b    " +
                    "inner join tbPLBSAMI_FG_tempGenerateLIST c on b.SKU = c.sku and b.cartonID = c.CartonID and concat(c.AssyCode,'~',c.destinationcode)= b.lottable09    " +
"left join(select count(distinct(docNumber)) as JumlahPrint, DocNumber, MAX(editdate) as PrintDate, max(editWho) as Printby  from tbPLBSAMI_FG_PrintStamp where DocType = 'MappingList' group by DocNumber) d on c.MappingID = d.DocNumber inner join tbMappingInstruction e on c.sku = e.assynumber and e.Plankey = c.TASKID  and e.assycode = c.assycode " +
"left join(select palletid,max(editwho)as Sticker from tbplbsami_fg_labelCheck group by palletid) f on c.mappingid = f.palletid " +
"where b.storerkey= '"+txt_storerkey.Text+"'  " +
"group by  c.MappingID, e.plankey,JumlahPrint, d.Printby, d.PrintDate ,b.sku,b.lottable09 " +
"having count(b.cartonID)>0  order by max(c.Editdate) desc "

                    , ConnLocal);
                DataSet DS = new DataSet();
                DA.Fill(DS);
                DataGridViewCheckBoxColumn CheckboxColumn = new DataGridViewCheckBoxColumn();
                CheckBox chk = new CheckBox();
                CheckboxColumn.Width = 20;
                dgsList.Columns.Add(CheckboxColumn);
                dgsList.DataSource = DS.Tables[0];
                dgsListBinding.DataSource = DS.Tables[0];
                ConnLocal.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        //show Unchecked
        private void GetList2()
        {
            
            try
            {
                dgsList.Columns.Clear();
                ConnLocal.Close();
                ConnLocal.Open();
                SqlDataAdapter DA = new SqlDataAdapter("select e.plankey,c.MappingID,b.sku,Count(distinct(b.CartonID)) as JumlahCarton,f.JumlahScan,max(SNP)stdPallet,case when count(b.CartonID)<max(e.SNP) then 'Not Complete' else 'Complete' end StatusMapping , JumlahPrint as PrintCount,d.Printby,d.PrintDate,Max(receiptkey) 'ASN terakhir'  from(select cartonID, SKu, receiptkey from tbPLBSAMI_FG_stgMappingStock where loc not like 'Pickto') b " +
                    "inner join  tbPLBSAMI_FG_tempGenerateLIST c on b.SKU = c.sku and b.cartonID = c.CartonID left join(select count(distinct(cartonID)) JumlahScan, PalletID from TbPLBSAMI_FG_MappingChecking group by PalletID)f on c.MappingID = f.PalletID left join(select count(distinct(docNumber)) as JumlahPrint, DocNumber, MAX(editdate) as PrintDate, max(editWho) as Printby  from tbPLBSAMI_FG_PrintStamp where DocType = 'MappingList' group by DocNumber) d on c.MappingID = d.DocNumber inner join tbMappingInstruction e on c.sku = e.assynumber and e.Plankey = c.TASKID group by  c.MappingID, e.plankey, JumlahPrint, d.Printby, d.PrintDate, f.JumlahScan,b.SKU  having  Count(distinct(c.CartonID)) - (isnull(f.JumlahScan, 0)) > 0", ConnLocal);
                DataSet DS = new DataSet();
                DA.Fill(DS);

                DataGridViewCheckBoxColumn CheckboxColumn = new DataGridViewCheckBoxColumn();
                CheckBox chk = new CheckBox();
                CheckboxColumn.Width = 20;
                dgsList.Columns.Add(CheckboxColumn);
                dgsList.DataSource = DS.Tables[0];
                dgsListBinding.DataSource = DS.Tables[0];
                ConnLocal.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
            
        }

        private void Insert()
        {
            ConnLocal.Close();

            ConnLocal.Open();
            SqlCommand cmd = new SqlCommand("truncate table tbPLBSAMI_FG_rptMappingList", ConnLocal);
            cmd.ExecuteNonQuery();

            ConnLocal.Close();

            string areceiptkey = txt_mappingID.ToString();
            DataSet ds = new DataSet();
            ConnLocal.Open();
            SqlDataAdapter DA = new SqlDataAdapter(" select MappingID,Storerkey,'1' as Status from tbPLBSAMI_FG_tempGenerateLIST " +
            " where mappingID in (" + areceiptkey + ")  " +
            " group by MappingID,Storerkey ", ConnLocal);
            ds = new DataSet();

            DA.Fill(ds);
            ConnLocal.Close();



            ConnLocal.Open();
            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(ConnLocal))
            {
                bulkCopy.DestinationTableName =
                    "tbPLBSAMI_FG_rptMappingList";

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
                foreach (DataGridViewRow Row in dgsList.Rows)
                {

                    if (Row.Cells[0].Value != null)
                    {
                        if ((bool)(Row.Cells[0].Value) == true)
                        {
                            string receiptkey = dgsList.Rows[Row.Index].Cells["MappingID"].Value.ToString();
                            hasil += ",'" + receiptkey + "'";
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Anda Belum memilih" + ex.ToString());
                GetList();
            }
            int a = hasil.Length - 1;
            string aa = hasil.Substring(1, a);
            txt_mappingID = aa.ToString();

        }


        private void UpdateStatus()
         {
            string hasil = "";
            foreach (DataGridViewRow Row in dgsList.Rows)
            {

                if (Row.Cells[0].Value != null)
                {
                    if ((bool)(Row.Cells[0].Value) == true)
                    {
                        ConnLocal.Close();
                        string receiptkey = dgsList.Rows[Row.Index].Cells["MappingID"].Value.ToString();
                        SqlCommand cmd = new SqlCommand("insert into tbPLBSAMI_FG_PrintStamp(DOCtype,DocNumber,Editdate,EditWho,Notes) values " +
                    " (@DOCtype,@DocNumber,@Editdate,@EditWho,@Notes) " +
                     "    ", ConnLocal);
                        cmd.Parameters.Add(new SqlParameter("Doctype", "MappingList"));
                        cmd.Parameters.Add(new SqlParameter("DocNumber", receiptkey.ToString()));
                        cmd.Parameters.Add(new SqlParameter("Editdate", Editdate));
                        cmd.Parameters.Add(new SqlParameter("EditWho", FormLogin.NIK + " " + FormLogin.UserName));
                        cmd.Parameters.Add(new SqlParameter("Notes", ""));
                        try
                        {
                            ConnLocal.Open();
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }

                    }
                }
            }
        }

        private void OpenCR()
        {

            ReportDocument cryRpt = new ReportDocument();
            TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
            TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
            ConnectionInfo crConnectionInfo = new ConnectionInfo();
            Tables CrTables;
            cryRpt.Load(@"C:\\CR\\MappingList.rpt");
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
        private void btn_getList_Click(object sender, EventArgs e)
        {



            bWorkerShow.DoWork += new DoWorkEventHandler(bWorkerShow_DoWork);
            bWorkerShow.ProgressChanged += new ProgressChangedEventHandler(bWorkerShow_ProgressChanged);
            bWorkerShow.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bWorkerShow_RunWorkerCompleted);
            bWorkerShow.WorkerReportsProgress = true;
            bWorkerShow.RunWorkerAsync();

            if (txt_storerkey.Text.Contains("PLBSAM"))
            {
                //GetList();
                GetListNew();
            }
            else
            {
                MessageBox.Show("Pilih Storerkey Dulu !");
            }



        }

        private void rptMappingList_Load(object sender, EventArgs e)
        {
        }

        private void btn_Print_Click(object sender, EventArgs e)
        {
            getreceiptkey();
            MessageBox.Show(txt_mappingID.ToString());
            Insert();
            tabControl1.SelectedTab = tabPrint;
            UpdateStatus();
            OpenCR();
            GetList();
            
        }

        private void dgsList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgsList_FilterStringChanged(object sender, EventArgs e)
        {
            this.dgsListBinding.Filter = this.dgsList.FilterString;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            
            ConnLocal.Open();
            SqlCommand cmd = new SqlCommand("truncate table tbPLBSAMI_FG_rptMappingList", ConnLocal);
            cmd.ExecuteNonQuery();
            ConnLocal.Close();

            string areceiptkey = txt_mappingID1.Text.ToString();
            DataSet ds = new DataSet();
            ConnLocal.Open();
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = ConnLocal;
            cmd2.Connection = ConnLocal;
            cmd2.CommandText =" select MappingID,Storerkey,'1' as Status from tbPLBSAMI_FG_tempGenerateLIST " +
            " where mappingID = @mappingID  " +
            " group by MappingID,Storerkey ";
            ds = new DataSet();
            cmd2.Parameters.AddWithValue("mappingID", areceiptkey);
            SqlDataAdapter DA = new SqlDataAdapter(cmd2);


            DA.Fill(ds);
            ConnLocal.Close();



            ConnLocal.Open();
            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(ConnLocal))
            {
                bulkCopy.DestinationTableName =
                    "tbPLBSAMI_FG_rptMappingList";

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



            tabControl1.SelectedTab = tabPrint;
            UpdateStatus();
            OpenCR();


        }

        private void txt_storerkey_Click(object sender, EventArgs e)
        {

        }

        private void txt_storerkey_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void helpToolStripButton_Click(object sender, EventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo("http://10.130.36.11/tutorial/How-To-Print-MappingList.pdf");
            Process.Start(sInfo);
        }

        private void bWorkerShow_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void bWorkerShow_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgressBar1.Value = e.ProgressPercentage;
        }

        private void bWorkerShow_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
        }

        private void Btn_updateStock_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            UpdateStok();


        }
        SqlConnection Conn = new SqlConnection(ConfigDB.conWMS);

        private void UpdateStok()
        {

            ConnLocal.Close();
            ConnLocal.Open();
            SqlCommand cmd = new SqlCommand("truncate table tbplbsami_fg_stgMappingStock", ConnLocal);
            cmd.ExecuteNonQuery();
            ConnLocal.Close();

            DataSet ds;
            Conn.Open();
            SqlDataAdapter DA = new SqlDataAdapter("select  b.RECEIPTKEY ,a.LOT,a.SKU, b.ALTSKU as FromPallet,b.LOTTABLE10 as CartonID,a.QTY,a.STORERKEY,1 as StdPallet,b.STATUS, 'NN' carmaker, a.loc, d.locationflag, a.id as ToPalletID, b.datereceived,b.LOTTABLE09,c.SUSR6 boxType,c.BUSR9 as PalletType,replace(b.notes,'|',',')Qrcontent from LOTXLOCXID a join RECEIPTDETAIL b on a.lot = b.TOLOT inner join loc d on a.loc = d.LOC inner join (select sku, storerkey,susr6,BUSR9 from sku)c on a.sku = c.sku and a.storerkey = c.storerkey where a.STORERKEY like'%PLBSAM%' and d.loc <> 'Damage' and a.qty > 0 order by b.LOTTABLE10, a.SKU", Conn);
            ds = new DataSet();
            DA.Fill(ds);
            Conn.Close();
            ConnLocal.Open();
            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(ConnLocal))
            {
                bulkCopy.DestinationTableName =
                    "tbplbsami_fg_stgMappingStock";
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
       


    }
}
