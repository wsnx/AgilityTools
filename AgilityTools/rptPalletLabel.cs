using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
using ZXing.QrCode;
using System.IO;
using System.Drawing.Imaging;
using CrystalDecisions.Shared;

namespace AgilityTools
{
    public partial class rptPalletLabel : UserControl
    {

        SqlConnection ConnWMS = new SqlConnection(ConfigDB.conWMS);
        SqlConnection ConnLocal = new SqlConnection(ConfigDB.DBlocal);
        DataSet DsWMS = new DataSet();
        private DataTable DtWMS = new DataTable();

        public rptPalletLabel()
        {
            InitializeComponent();
        }
        private void rptPalletLabel_Load(object sender, EventArgs e)
        {

            ReportDocument cryRpt = new ReportDocument();
            cryRpt.Load("C:\\CR\\StandarReport.rpt");
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
            cryRpt.Load("C:\\CR\\PalletNonMix.rpt");
            crParameterDiscreteValue.Value = txt_fromReceiptkey.Text;
            crystalReportViewer1.ReportSource = cryRpt;
            crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["MappingID"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;
            crParameterValues.Clear();
            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);
            cryRpt.SetDatabaseLogon("kadmin", "53c4dm1n", "10.130.24.4", "KaizenDB");
            crystalReportViewer1.Refresh();
            crystalReportViewer1.Show();
        
        }
        private void DeleteData()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                ConnLocal.Open();
                cmd.Connection = ConnLocal;
                cmd.CommandText = ("truncate table tbPLBSAMI_FG_tempPalletID");
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
//            DeleteData();
            try
            {
                ConnLocal.Open();
                SqlCommand cmd = new SqlCommand();
                    cmd.Connection = ConnLocal;
                    cmd.CommandText = ("declare @result varchar(500) " +
                        " select @result = coalesce(@result+',','')+b.CartonID from  tbPLBSAMI_FG_tempGenerateLIST a inner join tbPLBSAMI_FG_stgMappingStock b on a.CartonID = b.CartonID " +
                        " " +
                        "select MappingID,@result as List,COUNT(b.cartoniD)as JumlahPolly , " +
                        " CONCAT(MappingID,',',sku,',',COUNT(b.cartoniD),',',@result) as QRConfig " +
                        " from tbPLBSAMI_FG_tempGenerateLIST a inner join tbPLBSAMI_FG_stgMappingStock b on a.CartonID = b.CartonID group by MappingID,sku");
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DA.Fill(DsWMS);
                ConnLocal.Close();
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
                Width = 200,
                Height = 200,
            };

            var qr = new ZXing.BarcodeWriter();
            qr.Options = options;
            qr.Format = ZXing.BarcodeFormat.QR_CODE;
            string strData;
            this.ProgressBar.Minimum = 0;
            this.ProgressBar.Maximum = DsWMS.Tables[0].Rows.Count + 1;
            this.ProgressBar.Value = 0;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConnLocal;
            ConnLocal.Open();
            cmd.CommandText = "INSERT INTO tbPLBSAMI_FG_tempPalletID (MappingID,QRimage,QRConfig) " +
                "values(@MappingID,@QRimage,@QRconfig)";
            for (int i = 0; i <= DsWMS.Tables[0].Rows.Count - 1; i++)
            {
                LblStatus.Text = ProgressBar.Value.ToString();
                this.ProgressBar.Value = this.ProgressBar.Value + 1;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("MappingID", DsWMS.Tables[0].Rows[i]["MappingID"]);
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
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                     MessageBox.Show(ex.ToString());
                }

                LblStatus.Text = "Total " + DsWMS.Tables[0].Rows.Count.ToString();
            }
            ConnLocal.Close();
            OpenCR();
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            CreateData();
        }
    }
}
