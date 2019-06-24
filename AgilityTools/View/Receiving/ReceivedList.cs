using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text; 
using System.Windows.Forms;
using System.Data.SqlClient;
namespace AgilityTools.View.Receiving
{
    public partial class ReceivedList : UserControl
    {
        SqlConnection Conn = new SqlConnection(ConfigDB.conWMS);
        SqlConnection ConnLocal = new SqlConnection(ConfigDB.DBlocal);
        DataSet DsReceipt = new DataSet();
        DataSet DsExpected = new DataSet();
        private DataTable DTexpected = new DataTable();
        private DataTable DTreceived = new DataTable();
        private static string AsnCell;
        public static string vKey;
        public ReceivedList()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }
        private void ReceivedList_Load(object sender, EventArgs e)
        {
            //Grid Design
            Btn_Refresh.Enabled = false;
            DgsSummaryReceipt.EnableHeadersVisualStyles = false;
            dgsDetailsReceipt.EnableHeadersVisualStyles = false;
            dgsDetailsReceipt2.EnableHeadersVisualStyles = false;
            DgsSummaryReceipt.ColumnHeadersDefaultCellStyle.BackColor = Color.Orange;
            DgsSummaryReceipt.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            DgsSummaryReceipt.GridColor= Color.Gray;
            dgsDetailsReceipt.ColumnHeadersDefaultCellStyle.BackColor = Color.Orange;
            dgsDetailsReceipt2.ColumnHeadersDefaultCellStyle.BackColor = Color.Orange;
            //Function
            getExpected();
        }
        private void getExpected()
        {
            try
            {
                ConnLocal.Open();
                SqlDataAdapter DA = new SqlDataAdapter("Select a.RECEIPTKEY,a.TrailerNumber,a.storerkey, " +
                "concat(cast((cast(count(distinct(b.sku)) as float) / cast(count(distinct(a.SKU))as float)*100) as decimal (10,2)), '%') as SKU," +
                "concat(cast(cast(count(b.CartonID) as float) / cast(count(distinct(a.Lottable01))as float) as decimal (10,2)) *100, '%') as Carton ,a.receiptstatus as ASNStatus" +
                " from kaizenDB.dbo.tbPLBSAMI_FG_stgReceiptdetail a " +
                " left join kaizenDB.dbo.tbPLBSAMI_FG_UnloadDetails b" +
                " on a.RECEIPTKEY = b.Receiptkey and a.sku = b.sku and a.Lottable01 = b.cartonid and a.Toid = b.frompalletid" +
                " where a.receiptstatus<>'Closed' " +
                " group by a.RECEIPTKEY,a.TrailerNumber,a.storerkey,a.receiptstatus", ConnLocal);
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
            SqlCommand cmd = new SqlCommand("truncate table kaizenDB.dbo.tbPLBSAMI_FG_stgReceiptdetail", ConnLocal);
            cmd.ExecuteNonQuery();
            ConnLocal.Close();
            DataSet ds;
            Conn.Open();
            SqlDataAdapter DA = new SqlDataAdapter("select a.RECEIPTKEY,a.EXTERNRECEIPTKEY,a.STORERKEY,sku, POLINENUMBER as TOID ,Lottable10,QTYEXPECTED,QTYRECEIVED,a.ADDDATE,b.TrailerNumber,Lottable01," +
                " case when b.status='9' then 'received' when b.status='0' then 'New' when b.status='5' then 'In Receiving' when b.status='11' then 'Closed' end Receiptstatus" +
                " from receiptdetail a inner join receipt b on a.RECEIPTKEY= b.RECEIPTKEY", Conn);
            ds = new DataSet();
            DA.Fill(ds);
            Conn.Close();
            ConnLocal.Open();
            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(ConnLocal))
            {
                bulkCopy.DestinationTableName =
                    "kaizenDB.dbo.tbPLBSAMI_FG_stgReceiptdetail";

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
            ConnLocal.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConnLocal;
            cmd.CommandText = ("Select a.storerkey,a.RECEIPTKEY,a.sku,a.QTYEXPECTED,b.Qty as QtyScan,a.QTYRECEIVED,a.TOID as Pallet,b.loc ,a.Lottable01 as CartonIDExpected , b.CartonID as CartonIDScan," +
            " b.UserName,b.Editdate as TglScan , " +
            " b.notes" +
            " from kaizenDB.dbo.tbPLBSAMI_FG_stgReceiptdetail a full " +
            " join kaizenDB.dbo.tbPLBSAMI_FG_UnloadDetails b" +
            " on a.RECEIPTKEY = b.Receiptkey and a.sku = b.sku and a.Lottable01 = b.cartonid  " +
            " where a.receiptkey =@receiptkey");
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("receiptkey", AsnCell);
            DataSet DS = new DataSet();
            DA.Fill(DS);
            dgsDetailsReceipt.DataSource = DS.Tables[0];
            ConnLocal.Close();
            ConnLocal.Open();
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = ConnLocal;
            cmd2.CommandText = "Select a.RECEIPTKEY,Count(distinct(a.TOID))as Pallet,count(distinct(a.SKU))as SKUExpected , Count(distinct(a.Lottable01))as CartonExpected ," +
                "count(distinct(b.sku)) as SKUreceipt, count(b.cartonID) as CartonReceipt, concat((count(distinct(b.sku)) / count(distinct(a.SKU))*100), '%') as SKU, " +
                "concat(cast(cast(count(b.CartonID) as float) / cast(count(distinct(a.Lottable01))as float) as decimal (10,2))*100, '%') as Carton" +
                " from kaizenDB.dbo.tbPLBSAMI_FG_stgReceiptdetail a  " +
                " left join kaizenDB.dbo.tbPLBSAMI_FG_UnloadDetails b" +
                " on a.RECEIPTKEY = b.Receiptkey and a.sku = b.sku and a.Lottable01 = b.cartonid and a.TOID = b.frompalletid " +
                "where a.receiptkey=@receiptkey" +
                " group by a.RECEIPTKEY";
            SqlDataAdapter DA2 = new SqlDataAdapter(cmd2);
            cmd2.Parameters.AddWithValue("receiptkey", AsnCell);
            DataSet DS2 = new DataSet();
            DA2.Fill(DS2);
            dgsDetailsReceipt2.DataSource = DS2.Tables[0];
            ConnLocal.Close();
            headerASN();
            tabControl2.SelectedTab = tabPage4;

        }

        private void DgsSummaryReceipt_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            AsnCell = DgsSummaryReceipt.Rows[e.RowIndex].Cells[0].Value.ToString();
            Btn_Refresh.Enabled = true;
            DataDetail();
        }
        private void headerASN()
        {
            
            Conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conn;
            cmd.CommandText = "select a.receiptkey,a.EXTERNRECEIPTKEY,a.STORERKEY,a.TrailerNumber,a.CONTAINERKEY," +
            "SUBSTRING(b.lottable03, 0, charindex('~', b.lottable03)) as DocBCJenis," +
            "replace(SUBSTRING(b.lottable03, charindex('~', b.lottable03), len(b.lottable03) + 1), '~', '') as DocBCNomor" +
            ",cast(max(cast(b.adddate as date))as varchar) as ASNdate " +
            "from receipt a inner join receiptdetail b on a.RECEIPTKEY = b.receiptkey where a.RECEIPTKEY =@receiptkey " +
            "group by a.receiptkey,a.EXTERNRECEIPTKEY,a.STORERKEY,a.TrailerNumber,a.CONTAINERKEY,LOTTABLE03";
            cmd.Parameters.AddWithValue("receiptkey", AsnCell);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                txt_ASN.Text = reader.GetString(0);
                txt_Extern.Text = reader.GetString(1);
                txt_suplier.Text = reader.GetString(2);
                txt_TrailerNo.Text = reader.GetString(3);
                txt_ContNo.Text = reader.GetString(4);
                txtAjuNo.Text = reader.GetString(6);
                txt_AJUtype.Text = reader.GetString(5);
                txt_ASNDATE.Text = reader.GetString(7);
             }
            Conn.Close();
        }
        private void BtnPrint_Click(object sender, EventArgs e)
        {
            vKey = txt_ASN.Text;
            Reports f2 = new Reports();
            f2.MdiParent = AgilityTools.ActiveForm;
            f2.Show();

        }
        private void btnTarikData_Click(object sender, EventArgs e)
        {
            getExpected();
            TarikdataASN();
        }
         private void dgsDetailsReceipt_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dgsDetailsReceipt_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void toolStrip1_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {
        }
        private void dgsDetailsReceipt_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow row in dgsDetailsReceipt.Rows)
            {
                if (Convert.ToString(row.Cells["Notes"].Value) =="OK")// Or your condition 
                {

                }
                else
                {
                   
                        row.Cells["QtyScan"].Style.BackColor = Color.Red;
                }
            }
        }

        private void DgsSummaryReceipt_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            foreach (DataGridViewRow row in DgsSummaryReceipt.Rows)
            {
                if (Convert.ToString(row.Cells["Carton"].Value) == "100.00%")// Or your condition 
                {
                    row.Cells["Carton"].Style.BackColor = Color.Green;

                }
                else if (Convert.ToString(row.Cells["Carton"].Value) == "0.00%")
                {
                    row.Cells["Carton"].Style.BackColor = Color.White;

                }else
                {
                    row.Cells["Carton"].Style.BackColor = Color.Red;

                }
            }
        }

        private void Btn_Refresh_Click(object sender, EventArgs e)
        {
            DataDetail();
        }

        private void DgsSummaryReceipt_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

    internal class Datatable : DataTable
    {
    }
}
