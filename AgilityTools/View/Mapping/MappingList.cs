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
        private static string txt_MappingID;
        private static string TASKcell;
        private static string txt_taxtID;
        private static DateTime Editdate = DateTime.Now;

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
                    " a left Join tbPLBSAMI_FG_stgMappingStock b on a.CartonID = b.CartonID " +
                    " ", ConnLocal);

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
        private void taskList()
        {
            try
            {
                ConnLocal.Open();
                SqlDataAdapter DA = new SqlDataAdapter("select a.edidate,a.TASKID,count(distinct(b.MAPPINGID))as JumlahMAPPINGID from tbPLBSAMI_FG_TASK a inner join tbPLBSAMI_FG_tempGenerateLIST b on a.TASKID = b.TASKID" +
                    " group by a.edidate,a.TASKID" +
                    " ", ConnLocal);

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
        private void GenerateMappingList()
        {

            int x = Convert.ToInt32(txt_CartonID);
            for (int i = x + 1; i < ((x) + 1 + Std_Pallet); i++)
            {
                
                    int b = i.ToString().Length;
                    int a = txt_CartonID.Length;
                    string c = txt_CartonID.Substring(0, a - b);
                    txt_CartonID = c.ToString() + i.ToString();
             
                
                ConnLocal.Close();
                SqlCommand cmd = new SqlCommand("insert into   tbPLBSAMI_FG_tempGenerateLIST  (MappingID,CartonID,TaskID ) values(@MappingID,@CartonID,@TaskID)", ConnLocal);
                cmd.Parameters.Add(new SqlParameter("MappingID", txt_MappingID));
                cmd.Parameters.Add(new SqlParameter("CartonID", txt_CartonID));
                cmd.Parameters.Add(new SqlParameter("TaskID", txt_taskNo.Text));
                ConnLocal.Open();
                cmd.ExecuteNonQuery();
                ConnLocal.Close();
            }
            MessageBox.Show("Selesai");
        }
        private void CekStok()
        {
            ConnLocal.Close();
            SqlCommand cmd = new SqlCommand("select max(CartonID) as LastCartonID from tbPLBSAMI_FG_tempGenerateLIST group by MappingID", ConnLocal);
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
            ConnLocal.Close();
            SqlCommand cmd = new SqlCommand("select max(MappingID) as LastCartonID from tbPLBSAMI_FG_tempGenerateLIST group by MappingID", ConnLocal);
            // cmd.Parameters.AddWithValue("@RECEIPTKEY", );
            ConnLocal.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                txt_MappingID = reader.GetString(0);
            }
            ConnLocal.Close();
            string MAPid = txt_MappingID.Substring(9, 3);
            int x = Convert.ToInt32(MAPid)+1;
            string yy = Editdate.Year.ToString();
            string yyy = yy.Substring(2,2);
            string mm = Editdate.Month.ToString();
            int m = Convert.ToInt32(Editdate.Month.ToString());
                if (m<10)
                {
                    mm = "0" + m.ToString();
                }
                else
                 {
                    mm =  mm.ToString();
                 }
                
            string dd = Editdate.Day.ToString();
            int d = Convert.ToInt32(Editdate.Day.ToString());
                if (d < 10)
                {
                    dd = "0" + d.ToString();
                 }
                else
                {
                     dd = dd.ToString();
                }
           int b = x.ToString().Length;
           int a = MAPid.Length;
           string c = MAPid.Substring(0, a - b);
           txt_MappingID = "MAP" + yyy.ToString() + mm.ToString() + dd.ToString() + c.ToString() + x.ToString();

        }
        private void MappingList_Load(object sender, EventArgs e)
        {
            Btn_generate.Enabled = false;
            taskList();

        }
        private  void taskNo()
        {
            string transID;
            ConnLocal.Close();
            SqlCommand cmd = new SqlCommand("select max(TaskID) as LastID from tbPLBSAMI_FG_Task group by TASKID", ConnLocal);
            // cmd.Parameters.AddWithValue("@RECEIPTKEY", );
            ConnLocal.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                txt_taxtID = reader.GetString(0);
            }      
            ConnLocal.Close();
            string MAPid = txt_taxtID.Substring(10, 3);
            int x = Convert.ToInt32(MAPid) + 1;
            string yy = Editdate.Year.ToString();
            string yyy = yy.Substring(2, 2);
            string mm = Editdate.Month.ToString();
            int m = Convert.ToInt32(Editdate.Month.ToString());
            if (m < 10)
            {
                mm = "0" + m.ToString();
            }
            else
            {
                mm = mm.ToString();
            }

            string dd = Editdate.Day.ToString();
            int d = Convert.ToInt32(Editdate.Day.ToString());
            if (d < 10)
            {
                dd = "0" + d.ToString();
            }
            else
            {
                dd = dd.ToString();
            }
            int b = x.ToString().Length;
            int a = MAPid.Length;
            string c = MAPid.Substring(0, a - b);
            txt_taxtID = "TASK" + yyy.ToString() + mm.ToString() + dd.ToString() + c.ToString() + x.ToString();
            txt_taskNo.Text = txt_taxtID;
            txt_Date.Text = dd.ToString() + mm.ToString() + Editdate.Year.ToString(); ;


        }
        private void generateTaskno()
        {   
            taskNo();
            ConnLocal.Close();
            SqlCommand cmd = new SqlCommand("insert into tbPLBSAMI_FG_Task (TaskID,Edidate ) values (@TaskID,@Editdate)", ConnLocal);
            cmd.Parameters.Add(new SqlParameter("TaskID", txt_taxtID ));
            cmd.Parameters.Add(new SqlParameter("Editdate", Editdate));
            ConnLocal.Open();
            cmd.ExecuteNonQuery();
        }
        private void Btn_generate_Click(object sender, EventArgs e)
        {
            CekStok();
            GenerateMappingID();
            GenerateMappingList();
            GetMappingListDetails();
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            Btn_generate.Enabled = true;
           

            generateTaskno();

        }

        private void dgsSummaryMapping_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            BtnNew.Enabled = true;
            TASKcell = dgsSummaryMapping.Rows[e.RowIndex].Cells[1].Value.ToString();
            try
            {
                ConnLocal.Open();
                SqlCommand cmd= new SqlCommand();
                cmd.Connection = ConnLocal;
                cmd.CommandText = "select a.*,b.FromPallet,b.sku,b.Qty,a.MappingID as ToPallet , " +
                    " case when isnull(b.cartonID,'')='' then 'Not Ready' else 'Ready' end Status from tbPLBSAMI_FG_tempGenerateLIST " +
                    " a left Join tbPLBSAMI_FG_stgMappingStock b on a.CartonID = b.CartonID " +
                    " where a.TaskID = @TaskID";
                    
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("TaskID",TASKcell);
                DataSet DS = new DataSet();
                DA.Fill(DS);
                dgsMappingList.DataSource = DS.Tables[0];
                ConnLocal.Close();
                txt_taskNo.Text = TASKcell.ToString();
                Btn_generate.Enabled = true;
                tabPage2.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
