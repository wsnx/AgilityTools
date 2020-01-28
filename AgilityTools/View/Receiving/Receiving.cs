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
using AgilityTools.View.Receiving;

namespace AgilityTools
{
    public partial class Receiving : UserControl
    {
        SqlConnection Conn = new SqlConnection(ConfigDB.conWMS);
        SqlConnection ConnLocal = new SqlConnection(ConfigDB.DBlocal);
        DataSet DsReceipt = new DataSet();
        DataSet DsExpected = new DataSet();
        private DataTable DTexpected = new DataTable();
        private DataTable DTreceived = new DataTable();
        private static string AsnCell;
        public static string vKey;

        public Receiving()
        {
            InitializeComponent();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void Receiving_Load(object sender, EventArgs e)
        {
            Btn_Refresh.Enabled = false;
            DgsSummaryReceipt.EnableHeadersVisualStyles = false;
            dgsDetailsReceipt.EnableHeadersVisualStyles = false;
            dgsDetailsReceipt2.EnableHeadersVisualStyles = false;
            DgsSummaryReceipt.ColumnHeadersDefaultCellStyle.BackColor = Color.Orange;
            DgsSummaryReceipt.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            DgsSummaryReceipt.GridColor = Color.Gray;
            dgsDetailsReceipt.ColumnHeadersDefaultCellStyle.BackColor = Color.Orange;
            dgsDetailsReceipt2.ColumnHeadersDefaultCellStyle.BackColor = Color.Orange;
            getExpected();
        }
        private void getExpected()
        {
            try
            {
                ConnLocal.Open();
                SqlDataAdapter DA = new SqlDataAdapter("select b.STORERKEY,b.RECEIPTKEY as 'Receiptkey',b.AJU,b.Invoice as 'No. Invoice' , Trailernumber as 'No. Kendaraan ', ContainerKey as 'No. Container '," +
                    " Concat(cast((a.QTYRECEIVED + b.QtyReceived) / (a.QtyExpected + b.QtyExpected) * 100 as decimal(10, 2)), '%') as 'Checking Progress [Scan IN]' , ASNStatus 'ASN Status [WMS]' " +
                    "from(select RECEIPTKEY, storerkey, sum(QTYEXPECTED) as QtyExpected, Sum(QTYRECEIVED)QTYRECEIVED from tbPLBSAMI_FG_stgReceiptdetail where QRContent not like '0' group by RECEIPTKEY, storerkey)a right join " +
                    " (Select a.trailerNumber,a.Containerkey,a.RECEIPTKEY, a.storerkey, max(a.POKEY) as Invoice, a.Warehousereference as AJU, " +
                    " (cast(count(distinct(b.sku)) as float))Expected, cast(count(distinct(a.SKU)) as float)Received, " +
                    " cast(count(b.CartonID) as float)QtyReceived, cast(count((a.Lottable10)) as float)QtyExpected, a.receiptstatus as ASNStatus from tbPLBSAMI_FG_UnloadDetails b " +
                    " right join tbPLBSAMI_FG_stgReceiptdetail a on a.RECEIPTKEY = b.Receiptkey and a.sku = b.sku and a.Lottable10 = b.cartonid and a.Toid = b.frompalletid " +
                    " where a.receiptstatus <> 'Closed' and (a.storerkey like 'PLBSAM%') and a.QRContent not like '0'  group by a.RECEIPTKEY, a.TrailerNumber, a.storerkey, a.receiptstatus, a.Warehousereference,Containerkey) b  " +
                    " on a.RECEIPTKEY = b.RECEIPTKEY and a.STORERKEY = b.STORERKEY ", ConnLocal);
                DataSet DS = new DataSet();
                DA.Fill(DS);
                DgsSummaryReceipt.DataSource = DS.Tables[0];
                ConnLocal.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void TarikdataASN()
        {
            ConnLocal.Close();
            ConnLocal.Open();
            SqlCommand cmd = new SqlCommand("truncate table tbPLBSAMI_FG_stgReceiptdetail", ConnLocal);
            cmd.ExecuteNonQuery();
            ConnLocal.Close();
            DataSet ds;
            Conn.Open();
            SqlDataAdapter DA = new SqlDataAdapter("select a.RECEIPTKEY,a.EXTERNRECEIPTKEY,a.STORERKEY,sku, altsku as TOID ,Lottable10,QTYEXPECTED,QTYRECEIVED,a.ADDDATE, case when ISNULL(b.CONTAINERKEY, '') <> '' then '0' else b.trailerNumber end trailerNumber,a.Lottable10 , " +
                " case when b.status='9' then 'received' when b.status='0' then 'New' when b.status='5' then 'In Receiving' when b.status='11' then 'Closed' end Receiptstatus,b.containerkey,a.lottable03,a.lottable02,a.lottable10 as destinationCode, a.Notes as QrContent, a.Pokey,b.SUSR1,b.Warehousereference ,lottable09" +
                " from receiptdetail a inner join receipt b on a.RECEIPTKEY= b.RECEIPTKEY where b.status <>'11' and b.storerkey in ('PLBSAMTFG','PLBSAMJFG') ", Conn);
            ds = new DataSet();
            DA.Fill(ds);
            Conn.Close();
            ConnLocal.Open();
            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(ConnLocal))
            {
                bulkCopy.DestinationTableName =
                    "tbPLBSAMI_FG_stgReceiptdetail";

                try
                {
                    bulkCopy.WriteToServer(ds.Tables[0]);
                    MessageBox.Show("succes");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            ConnLocal.Close();
        }
        private void DataDetail()
        {
            Cursor.Current = Cursors.WaitCursor;
            dgsDetailsReceipt.Columns.Clear();
            ConnLocal.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConnLocal;
            cmd.CommandText = ("Select a.storerkey as 'Factory',a.RECEIPTKEY,a.sku as SKU," +
                "a.lottable09,SUBSTRING(a.lottable09,0,charindex('~',a.lottable09)) as 'AssyCode [ASN]',b.assycode as 'AssyCode [QR]', " +
                "a.TOID as 'Pallet Number',a.QTYEXPECTED 'Expected Qty',b.Qty as 'Scaned Qty',a.QTYRECEIVED 'Received Qty',b.loc 'Staging Loc' ,a.Lottable10 as 'ASN Serial (Expected)' , b.CartonID as 'Actual Serial (Scan)', " +
            " b.UserName 'Scan By',b.Editdate as 'Scan Datetime' ,  case when isnull(b.qty,0)<>a.QTYEXPECTED then 'Selisih' else 'OK' end Notes, " +
            " case when SUBSTRING(a.lottable09,0,charindex('~',a.lottable09))=b.assycode then 'Match' else 'Not Match' end 'AssyCode Validate' " +
            ", b.QrContent ,b.TransID" +
            " from tbPLBSAMI_FG_stgReceiptdetail a full  join tbPLBSAMI_FG_UnloadDetails b on a.RECEIPTKEY = b.Receiptkey and a.sku = b.sku and a.Lottable10 = b.cartonid   " +
            " where a.receiptkey=@receiptkey order by [Pallet Number] desc ");
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("receiptkey", AsnCell);
            DataSet DS = new DataSet();
            DA.Fill(DS);

            DataGridViewCheckBoxColumn CheckboxColumn = new DataGridViewCheckBoxColumn();
            CheckBox chk = new CheckBox();
            CheckboxColumn.Width = 20;
            dgsDetailsReceipt.Columns.Add(CheckboxColumn);
            dgsDetailsReceipt.DataSource = DS.Tables[0];
            dgsBindingDetailsReceipt.DataSource = DS.Tables[0];
            dgsDetailsReceipt.AutoResizeColumns();
            ConnLocal.Close();
            ConnLocal.Open();
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = ConnLocal;
            cmd2.CommandText = "Select a.RECEIPTKEY,Count(distinct(a.TOID))as '∑ Total Pallet',count(distinct(a.SKU)) as '∑ Total SKU ', Count((a.Lottable10)) as '∑ Jumlah Carton Expected '," +
                "  count(b.cartonID) as '∑ Jumlah Carton Received',  " +
                " concat(cast(cast(count(b.CartonID) as float) / cast(count((a.Lottable10))as float) as decimal (10,2))*100, '%') as 'Percentage'" +
                " from tbPLBSAMI_FG_stgReceiptdetail a  " +
                " left join tbPLBSAMI_FG_UnloadDetails b" +
                " on a.RECEIPTKEY = b.Receiptkey and a.sku = b.sku and a.Lottable10 = b.cartonid and a.TOID = b.frompalletid " +
                "where a.receiptkey=@receiptkey and len(a.Qrcontent)>1" +
                " group by a.RECEIPTKEY";
            SqlDataAdapter DA2 = new SqlDataAdapter(cmd2);
            cmd2.Parameters.AddWithValue("receiptkey", AsnCell);
            DataSet DS2 = new DataSet();
            DA2.Fill(DS2);
            dgsDetailsReceipt2.ReadOnly = true;
            dgsDetailsReceipt2.DataSource = DS2.Tables[0];
            dgsDetailsReceipt2.DataSource = DS2.Tables[0];
            ConnLocal.Close();
            headerASN();
            tabControl2.SelectedTab = tabPage4;

        }
        private void getreceiptkey()
        {

            string hasil = "";
            try
            {
                foreach (DataGridViewRow Row in dgsDetailsReceipt.Rows)
                {

                    if (Row.Cells[0].Value != null)
                    {
                        if ((bool)(Row.Cells[0].Value) == true)
                        {
                            string receiptkey = dgsDetailsReceipt.Rows[Row.Index].Cells["TransID"].Value.ToString();
                            hasil += ",'" + receiptkey + "'";
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Anda Belum memilih" + ex.ToString());
            }

            int a = hasil.Length - 1;
            string aa = hasil.Substring(1, a);
            txt_CartonID = aa.ToString();

        }
        private static string txt_CartonID;
        private void DgsSummaryReceipt_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            AsnCell = DgsSummaryReceipt.Rows[e.RowIndex].Cells[1].Value.ToString();
            Btn_Refresh.Enabled = true;
            DataDetail();
        }
        private void headerASN()
        {

            Conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conn;
            cmd.CommandText = "select a.receiptkey,a.EXTERNRECEIPTKEY,a.STORERKEY,b.POKEY as Invoice,a.CONTAINERKEY," +
            "SUBSTRING(b.lottable03, 0, charindex('~', b.lottable03)) as DocBCJenis," +
            "replace(SUBSTRING(b.lottable03, charindex('~', b.lottable03), len(b.lottable03) + 1), '~', '') as DocBCNomor" +
            ",cast(max(cast(b.adddate as date))as varchar) as ASNdate ," +
            "case when b.status='9' then 'received' when b.status='0' then 'New' when b.status='5' then 'In Receiving' when b.status='11' then 'Closed' end Receiptstatus " +
            "from receipt a inner join receiptdetail b on a.RECEIPTKEY = b.receiptkey where a.RECEIPTKEY =@receiptkey " +
            "group by a.receiptkey,a.EXTERNRECEIPTKEY,a.STORERKEY,a.CONTAINERKEY,LOTTABLE03,b.POKEY,b.status";
            cmd.Parameters.AddWithValue("receiptkey", AsnCell);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                txt_ASN.Text = reader.GetString(0);
                txt_Extern.Text = reader.GetString(1);
                txt_suplier.Text = reader.GetString(2);
                txt_invoice.Text = reader.GetString(3);
                txt_ContNo.Text = reader.GetString(4);
                txtAjuNo.Text = reader.GetString(6);
                txt_AJUtype.Text = reader.GetString(5);
                txt_ASNDATE.Text = reader.GetString(7);
                txt_status.Text = reader.GetString(8);
            }
            Conn.Close();
        }
        private void dgsDetailsReceipt_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
           /* foreach (DataGridViewRow row in dgsDetailsReceipt.Rows)
            {
                if (Convert.ToString(row.Cells["Notes"].Value) == "OK")// Or your condition 
                {

                }
                else
                {

                    row.Cells["Notes"].Style.BackColor = Color.Red;
                }
            }
            */
        }

        private void DgsSummaryReceipt_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            /*foreach (DataGridViewRow row in DgsSummaryReceipt.Rows)
            {
                if (Convert.ToString(row.Cells["Carton"].Value) == "100.00%")// Or your condition 
                {
                    row.Cells["Carton"].Style.BackColor = Color.Green;

                }
                else if (Convert.ToString(row.Cells["Carton"].Value) == "0.00%")
                {
                    row.Cells["Carton"].Style.BackColor = Color.White;

                }
                else
                {
                    row.Cells["Carton"].Style.BackColor = Color.Red;

                }
            }
            */
        }

        private void Btn_tarilkData_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Jangan Lupa Closed ASN yang status nya sudah Received");
            getExpected();
            TarikdataASN();
        }

        private void Btn_Refresh_Click(object sender, EventArgs e)
        {
            DataDetail();
        }

        private void dgsDetailsReceipt_FilterStringChanged(object sender, EventArgs e)
        {
            this.dgsBindingDetailsReceipt.Filter = this.dgsDetailsReceipt.FilterString;
        }

        private void dgsDetailsReceipt_SortStringChanged(object sender, EventArgs e)
        {
            this.dgsBindingDetailsReceipt.Sort = this.dgsDetailsReceipt.SortString;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Btn_Delete_Click(object sender, EventArgs e)
        {
            getreceiptkey();
            DeletedSQL2();
            DeletedSQL();

        }
        private void DeletedSQL2()
        {

            SqlCommand cmd = new SqlCommand("Update tbPLBSAMI_FG_UnloadDetails " +
                "set PK= concat(receiptkey,SKU,CartonID,AssyCode,'~delete~',convert(Varchar,getdate(),106),'~','" + FormLogin.NIK.ToString() + "') where TransID in(" + txt_CartonID + ")", ConnLocal);
            try
            {
                ConnLocal.Open();
                cmd.ExecuteNonQuery();
                ConnLocal.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void DeletedSQL()
        {
            ConnLocal.Close();
            SqlCommand cmd = new SqlCommand("Update tbPLBSAMI_FG_UnloadDetails " +
                "set receiptkey= concat(receiptkey,'~delete~',convert(Varchar,getdate(),106),'~','"+FormLogin.NIK.ToString()+"') where TransID in(" + txt_CartonID + ")", ConnLocal);
            try
            {
                ConnLocal.Open();
                cmd.ExecuteNonQuery();
                ConnLocal.Close();
                MessageBox.Show("Deleted Succesed");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            DataDetail();
        }

        private void Btn_EditScan_Click(object sender, EventArgs e)
        {
            F_EditPalletInbound f2 = new F_EditPalletInbound();
            f2.Show();
        }

        private void dgsDetailsReceipt2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
