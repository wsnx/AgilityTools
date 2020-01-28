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
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;


namespace AgilityTools
{
    public partial class RptPickingForm : UserControl
    {
        SqlConnection ConnWMS = new SqlConnection(ConfigDB.conWMS);
        SqlConnection ConnLocal = new SqlConnection(ConfigDB.DBlocal);
        public RptPickingForm()
        {
            InitializeComponent();
        }


        private void btn_printManual_Click(object sender, EventArgs e)
        {
            if (txt_report.Text == "PickingCheck")
            {

                rptPicking();
                tabControl1.SelectedTab = tabPrint;


            }
            else if (txt_report.Text == "LoadingCheck")

            {

                rptLoading();
                tabControl1.SelectedTab = tabPrint;
            }
            else if (txt_report.Text == "LoadingReport")

            {
                UpdateSO();
                rptLoadingReport();
                tabControl1.SelectedTab = tabPrint;
            }
            else if (txt_report.Text == "Dispatch ex BC 3.3")

            {
                tabControl2.SelectedTab = tabPage3;
                Btn_Export.Enabled = true;
                DispatchExBC33();

            }

            else if (txt_report.Text == "OutstandingSO")

            {
                tabControl2.SelectedTab = tabPage3;
                showOutstandihgSO();
            }
            else
            {
                MessageBox.Show("Pilih Report terlebih dahulu !!");
            }
        }
        private static string path;
        private void UpdateSO()
        {
            ConnLocal.Close();
            ConnLocal.Open();
            SqlCommand cmd = new SqlCommand("truncate table tbplbsami_fg_stgOrderdetail", ConnLocal);
            cmd.ExecuteNonQuery();
            ConnLocal.Close();

            DataSet ds;
            ConnWMS.Open();
            SqlDataAdapter DA = new SqlDataAdapter("select c.STORERKEY,b.ORDERKEY,ID,c.TrailerNumber,EXTERNORDERKEY,C_CITY from prapr.wmwhse36.PICKDETAIL  b inner join prapr.wmwhse36.ORDERS c on b.ORDERKEY = c.ORDERKEY where b.ORDERKEY='" + txt_mappingID1.Text + "'", ConnWMS);
            ds = new DataSet();
            DA.Fill(ds);
            ConnWMS.Close();
            ConnLocal.Open();
            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(ConnLocal))
            {
                bulkCopy.DestinationTableName =
                    "tbplbsami_fg_stgOrderdetail";
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
        private void rptPicking()
        {


            ReportDocument cryRpt = new ReportDocument();
            ParameterFieldDefinitions crParameterFieldDefinitions;
            ParameterFieldDefinition crParameterFieldDefinition;
            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();

            cryRpt.Load("C:\\CR\\CheckPickingForm.rpt");

            crParameterDiscreteValue.Value = txt_mappingID1.Text;
            crystalReportViewer1.ReportSource = cryRpt;
            crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["Orderkey"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;
            crParameterValues.Clear();
            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);
            cryRpt.SetDatabaseLogon(ConfigDB.DbUserName, ConfigDB.DbPassword, ConfigDB.DbHostname, ConfigDB.DbName);
            crystalReportViewer1.Refresh();
            crystalReportViewer1.Show();
        }
        private void rptLoading()
        {
            ReportDocument cryRpt = new ReportDocument();
            ParameterFieldDefinitions crParameterFieldDefinitions;
            ParameterFieldDefinition crParameterFieldDefinition;
            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();
            cryRpt.Load("C:\\CR\\LoadingForm.rpt");
            crParameterDiscreteValue.Value = txt_mappingID1.Text;
            crystalReportViewer1.ReportSource = cryRpt;
            crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["Orderkey"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;
            crParameterValues.Clear();
            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);
            cryRpt.SetDatabaseLogon(ConfigDB.DbUserName, ConfigDB.DbPassword, ConfigDB.DbHostname, ConfigDB.DbName);
            crystalReportViewer1.Refresh();
            crystalReportViewer1.Show();
        }
        private void rptLoadingReport()
        {
            ReportDocument cryRpt = new ReportDocument();
            ParameterFieldDefinitions crParameterFieldDefinitions;
            ParameterFieldDefinition crParameterFieldDefinition;
            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();
            cryRpt.Load("C:\\CR\\LoadingReport.rpt");
            crParameterDiscreteValue.Value = txt_mappingID1.Text;
            crystalReportViewer1.ReportSource = cryRpt;
            crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["Orderkey"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;
            crParameterValues.Clear();
            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            cryRpt.SetDatabaseLogon(ConfigDB.DbUserNameLocal, ConfigDB.DbPasswordLocal, ConfigDB.DbHostnameLocal, ConfigDB.DbNameLocal);
            crystalReportViewer1.Refresh();
            crystalReportViewer1.Show();
        }
        private void DispatchExBC33()
        {

            ConnLocal.Close();
            ConnLocal.Open();
            SqlCommand cmd = new SqlCommand("truncate table tbplbsami_fg_dispatchBC33_SO", ConnLocal);
            cmd.ExecuteNonQuery();
            ConnLocal.Close();
            DataSet ds;
            ConnWMS.Open();
            SqlDataAdapter DA = new SqlDataAdapter(
                "declare @Orderkey varchar(50)  " +
"set @Orderkey = '" + txt_mappingID1.Text + "' " +
"select SUBSTRING(a.lottable09,0,charindex('~',a.lottable09)) as 'ASSY CODE',a.SKU as 'NAMA BARANG',e.DESCR as 'Keterangan barang',E.SUSR4 as HSCODE ,a.LOTTABLE10 as SERIAL,cast(a.OPENQTY as int) as Qty,   " +
"c.UOM as Satuan,SUBSTRING(h.lottable01,0,charindex('~',h.lottable01)) as Invoice, 'BC27M' as 'Jenis DOK',replace(SUBSTRING(h.Lottable03, charindex('~', h.Lottable03) + 1, 26), '~', '') as 'NO AJU', SUBSTRING(d.susr1,0,charindex('~',d.susr1)) 'NO BC',  CONVERT(VARCHAR(10),replace(SUBSTRING(d.susr1,charindex('~',d.susr1),len(d.susr1)+1),'~',''), 120) as 'Tanggal BC',  concat(SUBSTRING(replace(SUBSTRING(c.lottable03,charindex('~',c.lottable03),len(c.lottable03)+1),'~',''),0,5),'00') as kode_kantor   " +
",  REPLACE(c.NOTES,'|',',') as BarcodeBox , Case when len(f.id)='11' then concat(substring(f.id,0,5),'00000',substring(f.id,len(f.id)-6,7)) when  f.id like '%-%' and g.jumlahSKu>1 then concat('2',substring(f.id,5,3),'00000',substring(f.id,len(f.id)-6,7)) when f.id like '%-%' then concat('1',substring(f.id,5,3),'00000',substring(f.id,len(f.id)-6,7)) else f.id    end 'Barcode Pallet Versi AI',    " +
"e.SUSR6 'Box Type',E.BUSR9 as 'Jenis Pallet' from PRAPR.wmwhse36.ORDERDETAIL a  inner join PRAPR.wmwhse36.PICKDETAIL f on a.ORDERLINENUMBER = f.ORDERLINENUMBER and a.SKU = f.sku and a.ORDERKEY = f.ORDERKEY   " +
"inner join lotattribute h on f.lot = h.lot  " +
"left join PRAPR.wmwhse36.RECEIPTDETAIL c on f.lot = c.tolot    " +
"left join prapr.wmwhse36.RECEIPT d on d.RECEIPTKEY = c.RECEIPTKEY inner join prapr.wmwhse36.SKU e on a.sku = e.sku inner join (select id,count(distinct(sku))as jumlahSKu from PRAPR.wmwhse36.PICKDETAIL where orderkey=@Orderkey group by id ) g on f.id = g.id  " +
"where a.ORDERKEY=@Orderkey order by  SUBSTRING(a.lottable09,0,charindex('~',a.lottable09)),a.SKU,cast(a.LOTTABLE10 as int) "

             , ConnWMS);
            ds = new DataSet();
            DA.Fill(ds);
            ConnWMS.Close();
            ConnLocal.Open();

            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(ConnLocal))
            {
                bulkCopy.DestinationTableName =
                    "tbplbsami_fg_dispatchBC33_SO";
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
            showDispatch();
        }
        private void showDispatch()
        {
            getSO();
            Cursor.Current = Cursors.WaitCursor;
            ConnLocal.Close();
            ConnLocal.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConnLocal;
            cmd.CommandText = (

 "declare @orderkey varchar(50)  " +
"set @orderkey ='"+txt_mappingID1+"'  " +
"select row_number() over (order by a.[Barcode Pallet Versi AI]  )	Nomer,  " +
"* from (select case when b.STORERKEY ='PLBSAMJFG' then '7686'  " +
"when b.STORERKEY ='PLBSAMTFG' then 'A535' end AssyCode,   " +
"'EMPTY POLYTAINER' as 'Nama Barang', 'EMPTY POLYTAINER' as 'Keterangan barang','39232990' HSCODE ,CartonID as Serial,'0' QTY,'PC' Satuan,'' Invoice,  " +
"'' 'Jenis Dok','' 'NO AJU','' 'NO BC','' 'Tanggal BC', case when b.STORERKEY ='PLBSAMJFG' then '060300' when b.STORERKEY ='PLBSAMTFG' then '060800' end 'Kode Kantor'  ,  " +
"QRcontent, Case when substring(a.palletID,2,1) like '%S%' then concat('1',substring(palletID,5,3),'00000',substring(palletID,len(palletID)-6,7)) else palletID    end 'Barcode Pallet Versi AI' ,Concat('EMPTY ',c.Box) 'Box Type','PT11' 'Jenis Pallet'   " +
"from tbPLBSAMI_FG_PickingCheck a inner join prapr.wmwhse36.ORDERS b on a.Orderkey = b.ORDERKEY     " +
"inner join (select orderkey,a.palletid as Pallet,b.[Box Type] as Box from tbPLBSAMI_FG_PickingCheck a  inner join tbplbsami_fg_dispatchBC33_SO b   " +
"on substring(b.[Barcode Pallet Versi AI],2,17)= ( " +
"Case   when substring(a.palletID,2,1) like '%S%' then concat(substring(palletID,5,3),'00000',substring(palletID,len(palletID)-6,7)) else 'LPN Tidak Sesuai Format'    end))    " +
"c on a.orderkey = c.orderkey and a.palletid=c.pallet where a.Orderkey=@orderkey  " +
"and QRcontent like '%EMPTY%' group by QRcontent,B.STORERKEY,CartonID,PalletID,c.box   " +
"union all  " +
"select  b.* from tbplbsami_fg_dispatchBC33_SO b   " +
"inner join  " +
"(select QRcontent,PalletID,SKU,CartonID,SUBSTRING(Lottable09,0,charindex('~',lottable09))as AssyCOd from tbPLBSAMI_FG_PickingCheck where orderkey=@orderkey  " +
"group by PalletID,SKU,CartonID,Lottable09,QRcontent)a   " +
"on  b.[BarcodeBox] =  a.QRcontent )a " +
"order by a.[Barcode Pallet Versi AI] ")
;
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            DA.Fill(ds);
            DataTable Orders = ds.Tables[0];
            dgsList.DataSource = ds.Tables[0];
            dgsListBinding.DataSource = ds.Tables[0];
            showDispatch_sum();
            ConnLocal.Close();

        }


        private void showOutstandihgSO()
        {

            Cursor.Current = Cursors.WaitCursor;
            ConnWMS.Close();
            ConnWMS.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConnWMS;
            cmd.CommandText = (
                "select a.storerkey,a.orderkey,a.externorderkey,a.sku,a.lottable09,a.lottable10 , " +
"case when isnull(b.status,'')='' then 'Belum ada ASN' when b.status=0 then 'Belum di Proses GR' end 'Status ASN' " +
",b.receiptkey as ASN,b.ID as 'Pallet Inbound[LPN]' from orderdetail a inner join orders c on a.orderkey= c.orderkey " +
"left join receiptdetail b on a.sku = b.sku and a.lottable09 = b.lottable09 and a.lottable10 = b.lottable10 " +
"where a.status <17 and (b.status =0 or isnull(b.status,'')='') and a.storerkey='"+txt_mappingID1.Text+"' order by a.orderkey"

);
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            DA.Fill(ds);
            DataTable Orders = ds.Tables[0];
            dgsList.DataSource = ds.Tables[0];
            dgsListBinding.DataSource = ds.Tables[0];
            ConnLocal.Close();
            showOutstandihgSO_sum();

        }

        private void showOutstandihgSO_sum()
        {

            Cursor.Current = Cursors.WaitCursor;
            ConnWMS.Close();
            ConnWMS.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConnWMS;
            cmd.CommandText = (
"select storerkey,orderkey,externorderkey,sku,lottable09,OrdersCtn as 'Order [Ctn]',OrdersCtn-count(StatusASN) 'Ready [Ctn]',count(StatusASN)'Oustanding [Ctn]' from  " +
"(select a.storerkey,a.orderkey,a.externorderkey,a.sku,a.lottable09,a.lottable10 , " +
"case when isnull(b.status,'')='' then 'Belum ada ASN' when b.status=0 then 'Belum di Proses GR' end 'StatusASN' " +
",b.receiptkey as ASN,c.totalorderlines OrdersCtn from orderdetail a inner join orders c on a.orderkey= c.orderkey " +
"left join receiptdetail b on a.sku = b.sku and a.lottable09 = b.lottable09 and a.lottable10 = b.lottable10 " +
"where a.status <17 and (b.status =0 or isnull(b.status,'')='') and a.storerkey='"+txt_mappingID1.Text+"') a " +
"group by storerkey,orderkey,externorderkey,sku,lottable09,OrdersCtn "
);
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            DA.Fill(ds);
            DataTable Orders = ds.Tables[0];
            dgs_sumDispatch.DataSource = ds.Tables[0];
            ConnLocal.Close();

        }



        private void showDispatch_sum()
        {
            getSO();
            Cursor.Current = Cursors.WaitCursor;
            ConnLocal.Close();
            ConnLocal.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConnLocal;
            cmd.CommandText = (
"declare @Orderkey varchar(50)  " +
"set @Orderkey = '"+txt_mappingID1+"' " +
"select a.[Barcode Pallet Versi AI],count(BarcodeBox) as JumlahOrder,COUNT(QRcontent) as JumlahCek, " +
"case when count(BarcodeBox) = COUNT(QRcontent) then 'OK'  " +
"when count(BarcodeBox) > COUNT(QRcontent) then 'Belum di ScanPicking' end Status " +
"from tbplbsami_fg_dispatchBC33_SO a left join   " +
"(select PalletID,qrcontent from tbplbsami_fg_pickingCheck where orderkey =@Orderkey  " +
"group by qrcontent,PalletID) b  " +
"on a.BarcodeBox = b.Qrcontent  " +
"group by PalletID,[Barcode Pallet Versi AI],[Box Type] ")
;
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            DA.Fill(ds);
            DataTable Orders = ds.Tables[0];
            dgs_sumDispatch.DataSource = ds.Tables[0];
            ConnLocal.Close();

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dataSO();
        }

        private void dataSO()
        {
            ConnWMS.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConnWMS;
            cmd.CommandText = ("select storerkey,orderkey,externorderkey,c_city destination, susr2 Carmaker, b.DESCRIPTION  as status from orders a inner join ORDERSTATUSSETUP b  on a.status = b.CODE where status<95");
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            DA.Fill(ds);
            DataTable Orders = ds.Tables[0];
            dgsList.DataSource = ds.Tables[0];
            ConnWMS.Close();

        }
        private static string SO;
        private static string Storerkey;
        private void getSO ()
        {
            ConnWMS.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConnWMS;
            cmd.CommandText = ("select storerkey,externorderkey from orders where orderkey ='"+txt_mappingID1.Text+"'");
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                SO = reader.GetString(1);
                Storerkey = reader.GetString(0);
            }
            ConnWMS.Close();

        }
        private void ExportToExcel()
        {


            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            Excel.Range formatRange;
            formatRange = xlWorkSheet.get_Range("A1", "R"+ (dgsList.RowCount+5).ToString());
            formatRange.NumberFormat = "@";

            
            int i = 0;
            int j = 0;

            this.ProgressBar1.Minimum = i;
            this.ProgressBar1.Maximum = dgsList.RowCount + 1;

            for (i = 0; i <= dgsList.RowCount - 1; i++)
            {
                this.ProgressBar1.Value = i + 1;
                for (j = 0; j <= dgsList.ColumnCount - 1; j++)
                {

                    DataGridViewCell cell = dgsList[j, i];
                    xlWorkSheet.Cells[i + 7, j + 1] = cell.Value;
                }
            }

            xlWorkSheet.Cells[1, 1] = "PT. Semarang Autocomp Manufacturing Indonesia";
            xlWorkSheet.Cells[2, 1] = "PELENGKAP BC 33";
            xlWorkSheet.Cells[3, 1] = "INVOICE FG : "+ SO;
            xlWorkSheet.Cells[4, 1]="KODE FACTORY : "+ Storerkey;  
            xlWorkSheet.Cells[6, 1] = "No";
            xlWorkSheet.Cells[6, 2] = "Assy Code";
            xlWorkSheet.Cells[6, 3] = "NAMA BARANG";
            xlWorkSheet.Cells[6, 4] = "KETERANGAN BARANG";
            xlWorkSheet.Cells[6, 5] = "HS CODE";
            xlWorkSheet.Cells[6, 6] = "SERIAL";
            xlWorkSheet.Cells[6, 7] = "QTY";
            xlWorkSheet.Cells[6, 8] = "SATUAN";
            xlWorkSheet.Cells[6, 9] = "INVOICE";
            xlWorkSheet.Cells[6, 10] = "JENIS DOK";
            xlWorkSheet.Cells[6, 11] = "NO AJU";
            xlWorkSheet.Cells[6, 12] = "NO BC";
            xlWorkSheet.Cells[6, 13] = "TGL BC";
            xlWorkSheet.Cells[6, 14] = "KODE KANTOR";
            xlWorkSheet.Cells[6, 15] = "BARCODE BOX";
            xlWorkSheet.Cells[6, 16] = "BARCODE PALLET VERSI AI";
            xlWorkSheet.Cells[6, 17] = "JENIS PACKING";
            xlWorkSheet.Cells[6, 18] = "JENIS PALLET";


            xlWorkSheet.Cells[5, 9] = "EKS DOKUMEN";

            xlWorkSheet.get_Range("A5", "A6").Merge(false);
            xlWorkSheet.get_Range("B5", "B6").Merge(false);
            xlWorkSheet.get_Range("C5", "C6").Merge(false);
            xlWorkSheet.get_Range("D5", "D6").Merge(false);
            xlWorkSheet.get_Range("E5", "E6").Merge(false);
            xlWorkSheet.get_Range("F5", "F6").Merge(false);
            xlWorkSheet.get_Range("G5", "G6").Merge(false);
            xlWorkSheet.get_Range("H5", "H6").Merge(false);
            xlWorkSheet.get_Range("O5", "O6").Merge(false);
            xlWorkSheet.get_Range("P5", "P6").Merge(false);
            xlWorkSheet.get_Range("Q5", "Q6").Merge(false);
            xlWorkSheet.get_Range("R5", "R6").Merge(false);
            xlWorkSheet.get_Range("I5", "N5").Merge(false);

            xlWorkSheet.Columns["B:R"].AutoFit();
            
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.FileName = "Dipatch Ex-BC "+SO;


            saveDialog.Filter = "Excel files (*.xls)|*.xls|All files (*.*)|*.*";
            saveDialog.FilterIndex = 2;

            if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                xlWorkBook.SaveAs(saveDialog.FileName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();
                MessageBox.Show("Export Successful");
            }

            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);

        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        private void Btn_Export_Click(object sender, EventArgs e)
        {
            ExportToExcel();
        }

        private void dgsList_FilterStringChanged(object sender, EventArgs e)
        {
            this.dgsListBinding.Filter = this.dgsList.FilterString;
        }

        private void dgsList_SortStringChanged(object sender, EventArgs e)
        {
            this.dgsListBinding.Sort = this.dgsList.SortString;
        }

        private void txt_report_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txt_report.Text =="OutstandingSO")
            {
                txt_parameter.Text = "Storerkey";
            }
            else
            {
                txt_parameter.Text = "Orderkey";
            }
        }

        private void dgsList_FilterStringChanged_1(object sender, EventArgs e)
        {
            this.dgsListBinding.Filter = this.dgsList.FilterString;

        }

        private void dgsList_SortStringChanged_1(object sender, EventArgs e)
        {
            this.dgsListBinding.Sort = this.dgsList.SortString;

        }
    }
}
