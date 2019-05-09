using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AgilityTools
{
    public partial class MappingList : UserControl
    {

        SqlConnection Conn = new SqlConnection(ConfigDB.conWMS);
        SqlConnection ConnLocal = new SqlConnection(ConfigDB.DBlocal);
        private static int Std_Pallet = 20;
        private static string txt_CartonID;

        public MappingList()
        {
            InitializeComponent();
        }

        private void getList()
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
                dgsSummaryMapping.DataSource = DS.Tables[0];
                ConnLocal.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void GetMappingListDetails()
        {
            try
            {
                ConnLocal.Open();
                SqlDataAdapter DA = new SqlDataAdapter("select a.*,b.FromPallet,b.sku,b.Qty,a.MappingID as ToPallet , " +
                    " case when isnull(b.cartonID,'')='' then 'Not Ready' else 'Ready' end Status from tbPLBSAMI_FG_tempGenerateLIST " +
                    " a left Join tbPLBSAMI_FG_stgMappingStock b on a.CartonID = b.CartonID where MappingID='MAP190508002'", ConnLocal);
                DataSet DS = new DataSet();
                DA.Fill(DS);
                dgsMappingList.DataSource = DS.Tables[0];
                ConnLocal.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void GenerateMappingList()
        {
            string a = txt_CartonID.Substring(2, 3);
            int x = Convert.ToInt32(a);
            for (int i = x + 1; i < ((x) + 1 + Std_Pallet); i++)
            {
                if (i < 10)
                {

                    txt_CartonID = "CT00" + i.ToString();
                    goto proses;
                }
                else
                {
                    txt_CartonID = "CT0" + i.ToString();
                    goto proses;
                }
                proses:
                string MappingID = "MAP190508002";
                ConnLocal.Close();
                SqlCommand cmd = new SqlCommand("insert into tbPLBSAMI_FG_tempGenerateLIST (MappingID,CartonID ) values(@MappingID,@CartonID)", ConnLocal);
                cmd.Parameters.Add(new SqlParameter("MappingID", MappingID));
                cmd.Parameters.Add(new SqlParameter("CartonID", txt_CartonID));
                ConnLocal.Open();
                cmd.ExecuteNonQuery();
                ConnLocal.Close();
            }
            MessageBox.Show("Selesai");
        }
        private void CekStok()
        {
            //Cek CartonID Terbesar Base ON SKU per ASN Ready
            ConnLocal.Close();
            SqlCommand cmd = new SqlCommand("select max(CartonID) as LastCartonID from tbPLBSAMI_FG_tempGenerateLIST group by MappingID", ConnLocal);
            // cmd.Parameters.AddWithValue("@RECEIPTKEY", );
            ConnLocal.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                txt_CartonID = reader.GetString(0);
            }

            ConnLocal.Close();
        }
        private void GenerateMappingID()
        {

        }
        private void MappingList_Load(object sender, EventArgs e)
        {
            getList();
            GetMappingListDetails();
        }
        private void Btn_generate_Click(object sender, EventArgs e)
        {
            CekStok();
            GenerateMappingList();
            GetMappingListDetails();
        }
    }
}
