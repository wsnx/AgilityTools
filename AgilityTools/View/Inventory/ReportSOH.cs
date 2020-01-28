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
using System.IO;

using Excel = Microsoft.Office.Interop.Excel;


namespace AgilityTools
{
    public partial class ReportSOH : UserControl
    {
        SqlConnection ConnWMS = new SqlConnection(ConfigDB.conWMS);
        SqlConnection ConnLocal = new SqlConnection(ConfigDB.DBlocal);
        public ReportSOH()
        {
            InitializeComponent();
        }

        private void btn_run_Click(object sender, EventArgs e)
        {

            if (txt_storerkey.Text.Contains("PLBSAM"))
            {
                ShowData();

            }
            else
            {
                MessageBox.Show("Pilih Storerkey Dulu !");
            }


        }
        private void ShowData()
        {
            Cursor.Current = Cursors.WaitCursor;
            ConnWMS.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConnWMS;
            cmd.CommandText = ("select a.storerkey as Factory,d.busr10 as Carmaker,cast(receiptkey as varchar) as ASN,asn.POKEY as 'Invoice ASN',asn.DATERECEIVED 'Receipt Date',a.LOC,a.ID as PalletID,a.lot,a.sku as SKU, asn.lottable10 as Serial, asn.lottable09 as AssyCode, cast(a.qty as int) as Onhand,cast(a.QTYALLOCATED as int) as Alocated,cast(a.QTYPICKED as int) Picked,cast(a.qty-a.QTYALLOCATED-QTYPICKED as int) as Available,c.ORDERKEY,c.EXTERNORDERKEY as 'Invoice SO',OrderStatus  from  " +
            "(select storerkey,qty,sku,lot,QTYALLOCATED,QTYPICKED,loc,ID from LOTXLOCXID where qty >0)a " +
            "inner join (select sku,busr10 from sku) d on a.sku = d.sku  " +
            "inner join (select tolot,receiptkey,POKEY,DATERECEIVED,lottable09,lottable10 from RECEIPTDETAIL ) asn on a.LOT = asn.tolot " +
            "left join (select orderkey,sku,lottable09, lottable10,a.EXTERNORDERKEY,b.DESCRIPTION as OrderStatus from orderdetail a inner join ORDERSTATUSSETUP b on a.STATUS= b.CODE where a.status<95) c on c.lottable09 = asn.lottable09 and c.lottable10 = asn.lottable10  " +
            "and c.sku = a.sku where a.storerkey='"+txt_storerkey.Text+"'");
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            DA.Fill(ds);
            DataTable Orders = ds.Tables[0];
            dgsList.DataSource = ds.Tables[0];
            dgsListBinding.DataSource = ds.Tables[0];

            ConnWMS.Close();

            
        }
        
        private void ToCsV(DataGridView dGV, string filename)
        {
            string stOutput = "";
            // Export titles:
            string sHeaders = "";

            for (int j = 0; j < dGV.Columns.Count; j++)
                sHeaders = sHeaders.ToString() + Convert.ToString(dGV.Columns[j].HeaderText) + "\t";
            stOutput += sHeaders + "\r\n";
            // Export data.
            for (int i = 0; i < dGV.RowCount - 1; i++)
            {
                string stLine = "";
                for (int j = 0; j < dGV.Rows[i].Cells.Count; j++)
                    stLine = stLine.ToString() + Convert.ToString(dGV.Rows[i].Cells[j].Value) + "\t";
                stOutput += stLine + "\r\n";
            }
            Encoding utf16 = Encoding.GetEncoding(1254);
            byte[] output = utf16.GetBytes(stOutput);
            FileStream fs = new FileStream(filename, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(output, 0, output.Length); //write the encoded file
            bw.Flush();
            bw.Close();
            fs.Close();
            MessageBox.Show("Succes");
        }
        
        private void btn_export_Click(object sender, EventArgs e)
        {
            //ExportToExcel();
            
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "SOH.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Cursor.Current = Cursors.WaitCursor;
                ToCsV(dgsList, sfd.FileName); // Here dgsList is your grid view name

                //ExportToExcel();

            }
            
        }

     /* private void ExportToExcel()
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            int i = 0;
            int j = 0;


            for (i = 0; i <= dgsList.RowCount - 1; i++)
            {
                for (j = 0; j <= dgsList.ColumnCount - 1; j++)
                {
                    DataGridViewCell cell = dgsList[j, i];
                    xlWorkSheet.Cells[i + 2, j + 1] = cell.Value;
                }
            }

            Excel.Range formatRange;
            formatRange = xlWorkSheet.get_Range("A1:Q1");
            formatRange.Interior.Color = System.Drawing.
            ColorTranslator.ToOle(System.Drawing.Color.Aqua);
            formatRange = xlWorkSheet.get_Range("A1:Q1");
            formatRange.BorderAround(Excel.XlLineStyle.xlContinuous,
            Excel.XlBorderWeight.xlMedium, Excel.XlColorIndex.xlColorIndexAutomatic,
            Excel.XlColorIndex.xlColorIndexAutomatic);

            xlWorkSheet.Cells[1, 1] = "Factory";
            xlWorkSheet.Cells[1, 2] = "Carmaker";
            xlWorkSheet.Cells[1, 3] = "ASN.Number";
            xlWorkSheet.Cells[1, 4] = "Receipt Date";
            xlWorkSheet.Cells[1, 5] = "Location";
            xlWorkSheet.Cells[1, 7] = "Pallet.Number";
            xlWorkSheet.Cells[1, 8] = "SKU";
            xlWorkSheet.Cells[1, 9] = "Serial";
            xlWorkSheet.Cells[1, 10] = "Assy.Code";
            xlWorkSheet.Cells[1, 11] = "Onhand";
            xlWorkSheet.Cells[1, 12] = "Alocated";
            xlWorkSheet.Cells[1, 13] = "Picked";
            xlWorkSheet.Cells[1, 14] = "Available";
            xlWorkSheet.Cells[1, 15] = "Orderkey";
            xlWorkSheet.Cells[1, 16] = "Invoice.SO";
            xlWorkSheet.Cells[1, 17] = "Order.Status";

            
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
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

    
    */
        private void dgsList_FilterStringChanged(object sender, EventArgs e)
        {
            this.dgsListBinding.Filter = this.dgsList.FilterString;
        }

        private void dgsList_SortStringChanged(object sender, EventArgs e)
        {
            this.dgsListBinding.Sort = this.dgsList.SortString;
        }
    }
}
