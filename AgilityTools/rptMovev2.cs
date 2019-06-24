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

namespace AgilityTools
{
    public partial class rptMovev2 : UserControl
    {
        SqlConnection ConnWMS = new SqlConnection(ConfigDB.conWMS);
        SqlConnection ConnLocal = new SqlConnection(ConfigDB.DBlocal);
        DataSet DsWMS = new DataSet();
        private DataTable DtWMS = new DataTable();

        public rptMovev2()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
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
        private void DeleteData()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                ConnLocal.Open();
                cmd.Connection = ConnLocal;
                cmd.CommandText = ("truncate table tbPLBSAMI_FG_PrintMappingList");
                cmd.ExecuteNonQuery();
                ConnLocal.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void CreateData()
        {
            DeleteData();
            try
            {
                ConnWMS.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = ConnLocal;
                cmd.CommandText = ("select b.TASKID,b.MappingID,a.CartonID,a.SKU,CONCAT(a.Storerkey,'\r\n','STAGEIN001','\r\n',lot,'\r\n',a.cartonID,'\r\n',a.sku,'\r\n',qty,'\r\n','SET','\r\n','\r\n','\r\n','STAGEIN001','\r\n',MappingID)as QRconfig " +
              " from tbPLBSAMI_FG_stgMappingStock a inner join " +
              " tbPLBSAMI_FG_tempGenerateLIST b on a.CartonID = b.CartonID and a.sku = b.sku and a.Storerkey = b.STorerkey " +
              " where MappingID= @MappingID " +
              " order by MappingID,CartonID");
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("MappingID", txt_fromReceiptkey.Text);
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
                Width = 150,
                Height = 150,
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
            cmd.CommandText = "INSERT INTO tbPLBSAMI_FG_PrintMappingList (TaskID,MappingID,SKU,CartonID,QRimage,QRConfig) " +
                "values(@taskID,@mappingID,@SKU,@CartonID,@QRimage,@QRconfig)";

            for (int i = 0; i <= a; i++)
            {
                
                this.progressBar.Value = this.progressBar.Value + 1;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("TaskID", DsWMS.Tables[0].Rows[i]["TaskID"]);
                cmd.Parameters.AddWithValue("MappingID", DsWMS.Tables[0].Rows[i]["MappingID"]);
                cmd.Parameters.AddWithValue("SKU", DsWMS.Tables[0].Rows[i]["SKU"]);
                cmd.Parameters.AddWithValue("CartonID", DsWMS.Tables[0].Rows[i]["CartonID"]);
                cmd.Parameters.AddWithValue("QRconfig", DsWMS.Tables[0].Rows[i]["QRconfig"]);
                strData = DsWMS.Tables[0].Rows[i]["QRconfig"].ToString();
                Bitmap Result = new Bitmap(qr.Write(strData));
                Byte[] data;
                using (var memoryStream = new MemoryStream())
                {
                    Result.Save(memoryStream, ImageFormat.Bmp);
                    data = memoryStream.ToArray();
                }
                cmd.Parameters.AddWithValue("@QRimage", data);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            ConnLocal.Close();
            OpenCR();
        }
        private void OpenCR()
        {
            ReportDocument cryRpt = new ReportDocument();
            cryRpt.Load("C:\\CR\\UpdatePalletnew.rpt");
            crystalReportViewer1.ReportSource = cryRpt;
            crystalReportViewer1.Refresh();

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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DeleteData();
            CreateData();
        }
    }
}
