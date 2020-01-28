using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using ZXing.Common;
using ZXing;
using ZXing.QrCode;
using System.Data.SqlClient;
using System.Threading;
using System.IO;
using System.Drawing.Imaging;
using CrystalDecisions.Shared;
using System.Diagnostics;

namespace AgilityTools
{
    public partial class rptMovev2 : UserControl
    {
        SqlConnection ConnWMS = new SqlConnection(ConfigDB.conWMS);
        SqlConnection ConnLocal = new SqlConnection(ConfigDB.DBlocal);
        DataSet DsWMS = new DataSet();
        private DataTable DtWMS = new DataTable();
        private static string MappingID_text="";

        public rptMovev2()
        {
            InitializeComponent();
        }
        private void ShowList()
        {

        }
        private void CreateQR()
        {
            QrCodeEncodingOptions options = new QrCodeEncodingOptions
            {
                DisableECI = true,
                CharacterSet = "UTF-8",
                Width = 100,
                Height = 100,
            };
            var qr = new ZXing.BarcodeWriter();
            qr.Options = options;
            qr.Format = ZXing.BarcodeFormat.QR_CODE;
            string strData;
        }

        private void UpdateStok()
        {

            ConnLocal.Close();
            ConnLocal.Open();
            SqlCommand cmd = new SqlCommand("truncate table tbPLBSAMI_FG_stgMappingStock3", ConnLocal);
            cmd.ExecuteNonQuery();
            ConnLocal.Close();

            DataSet ds;
            ConnWMS.Open();
            SqlDataAdapter DA = new SqlDataAdapter("select ''RECEIPTKEY ,a.LOT,a.SKU, '' as FromPallet,b.LOTTABLE10 as CartonID,a.QTY,a.STORERKEY,1 as StdPallet,'' STATUS, 'NN' carmaker, a.loc, d.locationflag, a.id as ToPalletID,  '' datereceived,b.lottable09,b.Notes from (select storerkey,sku,lot,loc,id,qty from LOTXLOCXID WHERE qty>0  AND  qtypicked=0 AND loc <>'PENDINGOUT')a join (select tolot,sku,lottable10,lottable09, notes from RECEIPTDETAIL where status>0 AND qtyreceived>0) b on a.lot = b.TOLOT inner join (select loc,locationflag from loc) d on a.loc = d.LOC where a.STORERKEY like'%PLBS%' and d.loc <> 'Damage' and a.loc not like 'PICKTO' and a.qty > 0   order by b.LOTTABLE10, a.SKU", ConnWMS);
            ds = new DataSet();
            DA.Fill(ds);
            ConnWMS.Close();

            ConnLocal.Open();
            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(ConnLocal))
            {
                bulkCopy.DestinationTableName =
                    "tbPLBSAMI_FG_stgMappingStock3";
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
        private void CreateData()
        {

            ConnLocal.Close();
            SqlCommand cmd2 = new SqlCommand();
                ConnLocal.Open();
                cmd2.Connection = ConnLocal;
                cmd2.CommandText = ("delete tbPLBSAMI_FG_PrintMappingList where NIK =@NIK");
                SqlDataAdapter DA2 = new SqlDataAdapter(cmd2);
                cmd2.Parameters.AddWithValue("NIK", FormLogin.NIK.ToString());
                cmd2.ExecuteNonQuery();
                ConnLocal.Close();

            try
            {   
                ConnWMS.Open();
                DsWMS.Clear();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = ConnLocal;
                cmd.CommandText = ("select   a.PalletID,a.Invoice,b.CartonID,b.SKU,CONCAT(b.STORERKEY,'\r\n',b.LOC,'\r\n',b.topalletID,'\r\n',b.SKU,'\r\n',b.LOT,'\r\n',b.qty,'\r\n','SET','\r\n','\r\n','\r\n',a.palletID,'\r\n')as QRconfig from tbPLBSAMI_FG_DispatchList a inner join  tbPLBSAMI_FG_stgMappingStock3 b on a.qrcontent = replace(b.qrcontent,'|',',')  where invoice='"+txt_Invoice.Text+ "' and a.palletID =@PalletID and b.loc != @PalletID");
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("PalletID", txt_PalletID.Text);
                DA.Fill(DsWMS);
                ConnWMS.Close();
                Insert();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Insert()
        {
            QrCodeEncodingOptions options = new QrCodeEncodingOptions
            {
                DisableECI = true,
                CharacterSet = "UTF-8",
                Width = 120,
                Height =120,
            };

            var qr = new ZXing.BarcodeWriter();
            qr.Options = options;
            qr.Format = ZXing.BarcodeFormat.QR_CODE;
            string strData;

            this.progressBar.Minimum = 0;
            this.progressBar.Maximum = DsWMS.Tables[0].Rows.Count + 1;
            this.progressBar.Value = 0;

            int a = DsWMS.Tables[0].Rows.Count - 1;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConnLocal;
            ConnLocal.Open();
            cmd.CommandText = "INSERT INTO tbPLBSAMI_FG_PrintMappingList (SKU,CartonID,QRimage,QRConfig,NIK) " +
                "values(@SKU,@CartonID,@QRimage,@QRconfig,@NIK)";
            for (int i = 0; i <= a; i++)
            {

                this.progressBar.Value = this.progressBar.Value + 1;
                cmd.Parameters.Clear();
               // cmd.Parameters.AddWithValue("TaskID", DsWMS.Tables[0].Rows[i]["TaskID"]);
                //cmd.Parameters.AddWithValue("MappingID", DsWMS.Tables[0].Rows[i]["MappingID"]);
                cmd.Parameters.AddWithValue("SKU", DsWMS.Tables[0].Rows[i]["SKU"]);
                cmd.Parameters.AddWithValue("CartonID", DsWMS.Tables[0].Rows[i]["CartonID"]);
                cmd.Parameters.AddWithValue("QRconfig", DsWMS.Tables[0].Rows[i]["QRconfig"]);
                strData = DsWMS.Tables[0].Rows[i]["QRconfig"].ToString();
                Bitmap Result = new Bitmap(qr.Write(strData));
                Byte[] data;
                using (var memoryStream = new MemoryStream())
                {
                    Result.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Bmp);
                    data = memoryStream.ToArray();
                }
                cmd.Parameters.AddWithValue("@QRimage", data);
                cmd.Parameters.AddWithValue("@NIK", FormLogin.NIK.ToString());

                try
                {
                    cmd.ExecuteNonQuery();
                    ShowGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            ConnLocal.Close();
        }
        private void ShowGrid()
        {

            //FromMove
            try
            {
                ConnLocal.Close();
                ConnLocal.Open();
                SqlDataAdapter DA = new SqlDataAdapter(" select DENSE_RANK() OVER (PARTITION BY mappingID ORDER BY cartonID asc ) AS No,case when cartonID%2=0 then QRimage else null end QR,CartonID,case when cartonID%2<>0 then QRimage else null end QR,MappingID,SKU  from tbPLBSAMI_FG_PrintMappingList  group by Qrimage,CartonID,MappingID,SKU  order by CartonID ", ConnLocal);
                DataSet DS = new DataSet();
                DS.Clear();
                DA.Fill(DS);
                dgsList.DataSource = DS.Tables[0];
                DataGridViewColumn column1 = dgsList.Columns[0];
                DataGridViewColumn column2 = dgsList.Columns[1];
                DataGridViewColumn column3 = dgsList.Columns[2];
                DataGridViewColumn column4 = dgsList.Columns[3];
                column1.Width = 50;
                column2.Width = 150;
                column3.Width = 200;
                column4.Width = 400;
                
            }
            catch (Exception ex)
            {

            }
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            int a = DsWMS.Tables[0].Rows.Count;
            for (int i = 1; i <= a; i++)
            {
                // Wait 50 milliseconds.  
                Thread.Sleep(50);
                // Report progress.  
                backgroundWorker1.ReportProgress(i);


            }
        }


        private void CreateDataDyna()
        {

            ConnLocal.Close();
            SqlCommand cmd2 = new SqlCommand();
            ConnLocal.Open();
            cmd2.Connection = ConnLocal;
            cmd2.CommandText = ("delete tbPLBSAMI_FG_PrintMappingList where NIK =@NIK");
            SqlDataAdapter DA2 = new SqlDataAdapter(cmd2);
            cmd2.Parameters.AddWithValue("NIK", FormLogin.NIK.ToString());
            cmd2.ExecuteNonQuery();
            ConnLocal.Close();

            try
            {
                ConnWMS.Open();
                DsWMS.Clear();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = ConnLocal;
                cmd.CommandText = (
                    "select   a.PalletID,a.Invoice,b.CartonID,b.SKU,CONCAT(b.STORERKEY,'\r\n',b.LOC,'\r\n',b.topalletID,'\r\n',b.SKU,'\r\n',b.LOT,'\r\n',b.qty,'\r\n','SET','\r\n','\r\n','\r\n',case when b.storerkey='PLBSAMJFG' then 'STGFGINJ02' else 'STGFGINT14' end,'\r\n',a.palletID)as QRconfig  " +
                "from tbplbsami_fg_Dockingdyna a inner join  tbPLBSAMI_FG_stgMappingStock3 b on a.qrcontent = replace(b.qrcontent,'|',',')   " +
                "where invoice='"+txt_Invoice.Text+ "' and a.palletID =@PalletID and b.topalletID != @PalletID "
                );
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("PalletID", txt_PalletID.Text);
                DA.Fill(DsWMS);
                ConnWMS.Close();
                Insert();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {

            if (txt_DocType.Text=="Dyna")
            {

                UpdateStok();
                this.dgsList.DataSource = null;
                dgsList.Rows.Clear();
                dgsList.Refresh();
                CreateDataDyna();
            }
            else
            {
                this.dgsList.DataSource = null;
                dgsList.Rows.Clear();
                dgsList.Refresh();
                UpdateStok();
                CreateData();
            }
            


            
        }

        private void OpenTelnet_Click(object sender, EventArgs e)
        {
            Process proc = null;
            try
            {
                Process p = new Process();
                ProcessStartInfo psi = new ProcessStartInfo(@"cmd.exe", @"/C telnet gunsapr.logistics.intra");
                psi.WindowStyle = ProcessWindowStyle.Normal;
                p.Start();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace.ToString());
            }
        }
    }
}
