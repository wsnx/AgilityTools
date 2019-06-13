﻿using System;
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

    public partial class rptMappingList : UserControl
    {
        SqlConnection ConnWMS = new SqlConnection(ConfigDB.conWMS);
        SqlConnection ConnLocal = new SqlConnection(ConfigDB.DBlocal);
        DataSet DsWMS = new DataSet();
        private DataTable DtWMS = new DataTable();

        public rptMappingList()
        {
            InitializeComponent();
        }
    
        private void btnPrint_Click(object sender, EventArgs e)
        {
            CreateData();

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
                cmd.Connection = ConnWMS;
                cmd.CommandText = ("select top 30  lottable01 as CartonID," +
                    " concat(a.STORERKEY,'\r\n'," +
                    " toloc,'\r\n', " +
                    " a.POLINENUMBER  as TOID,'\r\n'," +
                    " a.SKU,'\r\n'," +
                    "TOLOT,'\r\n'," +
                    "a.qtyreceived,'\r\n'," +
                    "a.Uom,'\r\n\r\n')  as QRconfig " +
                    "from RECEIPTDETAIL a " +
                    " inner join sku b on a.sku = b.sku and a.STORERKEY = b.STORERKEY " +
                    " where a.receiptkey like '%0068%'");
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
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
                Height =150,
            };

            var qr = new ZXing.BarcodeWriter();
            qr.Options = options;
            qr.Format = ZXing.BarcodeFormat.QR_CODE;
            string strData;

            this.ProgressBar.Minimum = 0;
            this.ProgressBar.Maximum = DsWMS.Tables[0].Rows.Count + 1;
            this.ProgressBar.Value = 0;
            
            int a = DsWMS.Tables[0].Rows.Count - 1;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConnLocal;
            ConnLocal.Open();
            cmd.CommandText = "INSERT INTO tbPLBSAMI_FG_PrintMappingList (Lottable10,QRimage,QRConfig) " +
                "values(@CartonID,@QRimage,@QRconfig)";
            
            for (int i = 0; i <= a; i++)
            {

                LblStatus.Text = ProgressBar.Value + 1.ToString();
                this.ProgressBar.Value = this.ProgressBar.Value + 1;
                cmd.Parameters.Clear();
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
                    LblStatus.Text = "Total " + DsWMS.Tables[0].Rows.Count.ToString();
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
            cryRpt.Load("C:\\CR\\MappingList.rpt");
            crystalReportViewer1.ReportSource = cryRpt;
            crystalReportViewer1.Refresh();

        }
        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            
            
        }
        private void rptMappingList_Load(object sender, EventArgs e)
        {
            }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgressBar.Value = e.ProgressPercentage;
            LblStatus.Text = e.ProgressPercentage.ToString();

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            int a = DsWMS.Tables[0].Rows.Count ;
            for (int i = 1; i <= a; i++)
            {
                // Wait 50 milliseconds.  
                Thread.Sleep(50);
                // Report progress.  
               backgroundWorker1.ReportProgress(i);
            }

        }
    }
}
