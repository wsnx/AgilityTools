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
using ZXing.QrCode;
using System.IO;
using System.Drawing.Imaging;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace AgilityTools
{
    public partial class SampleQR : UserControl
    {
        SqlConnection ConnWMS = new SqlConnection(ConfigDB.conWMS);
        SqlConnection ConnLocal = new SqlConnection(ConfigDB.DBlocal);
        DataSet DsWMS = new DataSet();
        public SampleQR()
        {
            InitializeComponent();
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
                cmd.CommandText = ("truncate table tbPLBSAMI_FG_SampleCarton");
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
                cmd.CommandText = ("select concat('TF,1904,17,BIT2',',',SKU,',',Lottable01,',',cast(qtyexpected as int),',','tes') as QrConfig,RECEIPTKEY, " +
                    " Lottable01 as CartonID, POLINENUMBER  as Pallet from RECEIPTDETAIL " +
                    " where receiptkey=@Receiptkey");
                cmd.Parameters.AddWithValue("Receiptkey", txt_fromReceiptkey.Text);
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
                Width = 100,
                Height = 100,
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
            cmd.CommandText = "INSERT INTO tbPLBSAMI_FG_SampleCarton (Pallet,CartonID,Receiptkey,QRimage,QRConfig) " +
                "values(@Pallet,@CartonID,@Receiptkey,@QRimage,@QRconfig)";

            for (int i = 0; i <= a; i++)
            {

                this.ProgressBar.Value = this.ProgressBar.Value + 1;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("Pallet", DsWMS.Tables[0].Rows[i]["Pallet"]);
                cmd.Parameters.AddWithValue("CartonID", DsWMS.Tables[0].Rows[i]["CartonID"]);
                cmd.Parameters.AddWithValue("Receiptkey", DsWMS.Tables[0].Rows[i]["Receiptkey"]);
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
            ParameterFieldDefinitions crParameterFieldDefinitions;
            ParameterFieldDefinition crParameterFieldDefinition;
            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();
            cryRpt.Load("C:\\CR\\SampleQR.rpt");
            crParameterDiscreteValue.Value = txt_fromReceiptkey.Text;
            crystalReportViewer1.ReportSource = cryRpt;
            crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["RECEIPTKEY"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;
            crParameterValues.Clear();
            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);
            cryRpt.SetDatabaseLogon(ConfigDB.DbUserName, ConfigDB.DbPassword, ConfigDB.DbHostname, ConfigDB.DbName);
            crystalReportViewer1.Refresh();
            crystalReportViewer1.Show();



        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            CreateData();
        }
    }
}
