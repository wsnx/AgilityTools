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
        public ReceivedList()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }
        private void ReceivedList_Load(object sender, EventArgs e)
        {
            //Grid Design
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
                SqlDataAdapter DA = new SqlDataAdapter("Select a.RECEIPTKEY,a.TrailerNumber,a.storerkey, concat(count(b.sku) / count(distinct(a.SKU)), '%') as SKU, concat(count(b.CartonID) / count(distinct(a.LOTTABLE10)), '%') as Carton" +
                " from kaizenDB.dbo.tbPLBSAMI_FG_stgReceiptdetail a " +
                " left join kaizenDB.dbo.tbPLBSAMI_FG_UnloadDetails b" +
                " on a.RECEIPTKEY = b.Receiptkey and a.sku = b.sku and a.lottable10 = b.cartonid and a.toid = b.frompalletid " +
                " group by a.RECEIPTKEY,a.TrailerNumber,a.storerkey", ConnLocal);
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
            ConnLocal.Open();
            SqlCommand cmd = new SqlCommand("truncate table kaizenDB.dbo.tbPLBSAMI_FG_stgReceiptdetail", ConnLocal);
            cmd.ExecuteNonQuery();
            MessageBox.Show("succes");
            ConnLocal.Close();
            DataSet ds;
            Conn.Open();
            SqlDataAdapter DA = new SqlDataAdapter("select a.RECEIPTKEY,a.EXTERNRECEIPTKEY,a.STORERKEY,sku,toid,LOTTABLE10,QTYEXPECTED,QTYRECEIVED,a.ADDDATE,b.TrailerNumber " +
                "from receiptdetail a inner join receipt b on a.RECEIPTKEY= b.RECEIPTKEY", Conn);
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

        private void DgsSummaryReceipt_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            AsnCell = DgsSummaryReceipt.Rows[e.RowIndex].Cells[0].Value.ToString();
            ConnLocal.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConnLocal;
            cmd.CommandText = ("Select a.storerkey,a.RECEIPTKEY,a.sku,a.QTYEXPECTED,b.Qty as QtyScan,a.QTYRECEIVED,b.loc ,a.LOTTABLE10 as CartonID , b.CartonID," +
            " b.UserName,b.Editdate as TglScan , " +
            "case when b.qty-a.qtyexpected>0 then 'Excess' " +
            "when b.qty-a.qtyexpected <0 then 'Shortage' " +
            "when b.qty-qtyexpected=0 then 'OK' end Notes " +
            " from kaizenDB.dbo.tbPLBSAMI_FG_stgReceiptdetail a left" +
            " join kaizenDB.dbo.tbPLBSAMI_FG_UnloadDetails b" +
            " on a.RECEIPTKEY = b.Receiptkey and a.sku = b.sku and a.lottable10 = b.cartonid and a.toid = b.frompalletid " +
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
            cmd2.CommandText = "Select a.RECEIPTKEY,Count(distinct(a.toid))as Pallet,count(distinct(a.SKU))as SKUExpected , Count(distinct(a.LOTTABLE10))as CartonExpected ," +
                "count(b.sku) as SKUreceipt, count(b.cartonID) as CartonReceipt, concat(count(b.sku) / count(distinct(a.SKU)), '%') as SKU, concat(count(b.CartonID) / count(distinct(a.LOTTABLE10)), '%') as Carton" +
                " from kaizenDB.dbo.tbPLBSAMI_FG_stgReceiptdetail a  " +
                " left join kaizenDB.dbo.tbPLBSAMI_FG_UnloadDetails b" +
                " on a.RECEIPTKEY = b.Receiptkey and a.sku = b.sku and a.lottable10 = b.cartonid and a.toid = b.frompalletid " +
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
            Print f2 = new Print();
            //f2.MdiParent = AgilityTools.ActiveForm;
            f2.Show();

        }
        private void btnTarikData_Click(object sender, EventArgs e)
        {
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
    }

    internal class Datatable : DataTable
    {
    }
}
