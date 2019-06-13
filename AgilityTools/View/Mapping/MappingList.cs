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
        DataSet DsWMS = new DataSet();
        private static int Std_Pallet;
        private static string txt_SKU;
        private static string txt_Storerkey;
        private static string txt_Carline;
        private static string txt_CartonID;
        private static string txt_MappingID;
        private static string txt_mapID;
        private static int txt_MapIDseq;
        private static string TASKcell;
        private static string txt_taxtID;
        private static DateTime Editdate = DateTime.Now;
        private static int endSerial;
        public MappingList()
        {
            InitializeComponent();
        }
        private void getList()
        {
            try
            {
                ConnLocal.Open();
                SqlDataAdapter DA = new SqlDataAdapter("Select a.RECEIPTKEY,a.TrailerNumber,a.storerkey, concat(count(b.sku) / count(distinct(a.SKU)), '%') as SKU, concat(count(b.CartonID) / count(distinct(a.Lottable01)), '%') as Carton" +
                " from kaizenDB.dbo.tbPLBSAMI_FG_stgReceiptdetail a " +
                " left join kaizenDB.dbo.tbPLBSAMI_FG_UnloadDetails b" +
                " on a.RECEIPTKEY = b.Receiptkey and a.sku = b.sku and a.Lottable01 = b.cartonid and a. POLINENUMBER as TOID = b.frompalletid " +
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

        private void UpdateStok()
        {
            ConnLocal.Close();
            ConnLocal.Open();
            SqlCommand cmd = new SqlCommand("truncate table kaizenDB.dbo.tbPLBSAMI_FG_stgMappingStock", ConnLocal);
            cmd.ExecuteNonQuery();
            ConnLocal.Close();
            DataSet ds;
            Conn.Open();
            SqlDataAdapter DA = new SqlDataAdapter("select b.RECEIPTKEY ,a.LOT,a.SKU, b.POLINENUMBER as FromPallet,b.LOTTABLE01 as CartonID,a.QTY,a.STORERKEY,cast(c.SUSR9 as int)as stdPallet,b.STATUS,c.RETAILSKU from LOTXLOCXID a  " +
            " right join RECEIPTDETAIL b on a.lot = b.TOLOT" +
            " inner join sku c on a.sku = c.sku and a.STORERKEY = b.STORERKEY" +
            " where a.STORERKEY like'%PLBS%' and loc = 'STAGEIN001' and a.qty > 0" +
            " order by b.LOTTABLE01, a.SKU", Conn);
            ds = new DataSet();
            DA.Fill(ds);
            Conn.Close();
            ConnLocal.Open();
            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(ConnLocal))
            {
                bulkCopy.DestinationTableName =
                    "kaizenDB.dbo.tbPLBSAMI_FG_stgMappingStock";
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
        private void Updategrid()
        {
            ConnLocal.Close();
            SqlCommand cmd = new SqlCommand(" select a.storerkey,a.carline,a.sku,min(a.cartonID)as startSerial,Max(a.cartonID)as endserial ,((cast(max(a.cartonid)as int)-cast(min(a.Cartonid)as int))+((cast(max(a.cartonid)as int)-cast(min(a.Cartonid)as int))%cast(stdpallet as int)))+cast(stdpallet as int)as Gap, " +
            " a.stdPallet, b.MappingID from tbPLBSAMI_FG_stgMappingStock a" +
            " left join tbPLBSAMI_FG_tempGenerateLIST b on a.CartonID = b.CartonID and a.sku = b.SKU and a.Storerkey = b.STorerkey" +
            " where isnull(mappingID, '') = '' " +
            " group by a.sku, stdPallet, a.storerkey, a.carline, b.MappingID", ConnLocal);
            ConnLocal.Open();
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DA.Fill(DsWMS);
            ConnLocal.Close();
            dgMappingList.DataSource = DsWMS.Tables[0];
        }
        private void CekStok()
        {
            ConnLocal.Close();
                SqlCommand cmd = new SqlCommand(" select a.storerkey,a.carline,a.sku,min(a.cartonID)as startSerial,Max(a.cartonID)as endserial ,((cast(max(a.cartonid)as int)-cast(min(a.Cartonid)as int))+((cast(max(a.cartonid)as int)-cast(min(a.Cartonid)as int))%cast(stdpallet as int)))+cast(stdpallet as int)as Gap, "+
                " a.stdPallet, b.MappingID from tbPLBSAMI_FG_stgMappingStock a"+
                " left join tbPLBSAMI_FG_tempGenerateLIST b on a.CartonID = b.CartonID and a.sku = b.SKU and a.Storerkey = b.STorerkey"+
                " where isnull(mappingID, '') = '' "+
                " group by a.sku, stdPallet, a.storerkey, a.carline, b.MappingID", ConnLocal);
            ConnLocal.Open();
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DA.Fill(DsWMS);
            ConnLocal.Close();
            int a = DsWMS.Tables[0].Rows.Count;
            this.ProgressBar1.Minimum = 0;
            this.ProgressBar1.Maximum = DsWMS.Tables[0].Rows.Count;
            this.ProgressBar1.Value = 0;
            dgMappingList.DataSource = DsWMS.Tables[0];

            for(int i =0; i < a; i++)
            {
                txt_CartonID = DsWMS.Tables[0].Rows[i]["Startserial"].ToString();
                string Pallet = DsWMS.Tables[0].Rows[i]["stdPallet"].ToString();
                Std_Pallet = Convert.ToInt32(Pallet);
                string Serial = DsWMS.Tables[0].Rows[i]["GAP"].ToString();
                endSerial = Convert.ToInt32(Serial);
                txt_SKU = DsWMS.Tables[0].Rows[i]["SKU"].ToString();
                txt_Storerkey = DsWMS.Tables[0].Rows[i]["Storerkey"].ToString();
                txt_Carline = DsWMS.Tables[0].Rows[i]["Carline"].ToString();
                this.ProgressBar1.Value = this.ProgressBar1.Value + 1;
                GenerateMappingID();
                GenerateMappingList();
                
            }
        }
        private void GenerateMappingList()
        {
            int x = Convert.ToInt32(txt_CartonID);
            for (int i = x; i < ((x) + endSerial); i++)
            {

                int b = i.ToString().Length;
                int a = txt_CartonID.Length;
                string c = txt_CartonID.Substring(0, a - b);
                txt_CartonID = c.ToString() + i.ToString();
                ConnLocal.Close();
                SqlCommand cmd = new SqlCommand("insert into   tbPLBSAMI_FG_tempGenerateLIST  (MappingID,CartonID,TaskID,sku,storerkey ) values(@MappingID,@CartonID,@TaskID,@sku,@storerkey)", ConnLocal);
                cmd.Parameters.Add(new SqlParameter("MappingID", txt_MappingID));
                cmd.Parameters.Add(new SqlParameter("CartonID", txt_CartonID));
                cmd.Parameters.Add(new SqlParameter("TaskID", txt_taskNo.Text));
                cmd.Parameters.Add(new SqlParameter("SKU", txt_SKU));
                cmd.Parameters.Add(new SqlParameter("Storerkey", txt_Storerkey));
                ConnLocal.Open();
                cmd.ExecuteNonQuery();
                ConnLocal.Close();
            }
        }

        private void GenerateMappingID()
        {
                ConnLocal.Close();
                SqlCommand cmd = new SqlCommand("select max(MappingID) as LastMAPID from tbPLBSAMI_FG_tempGenerateLIST where sku=@sku ", ConnLocal);
                cmd.Parameters.AddWithValue("SKU", txt_SKU);
                ConnLocal.Open();
                var result = cmd.ExecuteScalar();
                if (result != null)
                {
                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                       txt_mapID= reader.GetString(0);
                    }
                    int xx = txt_Carline.ToString().Length+2;
                    string mapID = txt_mapID.Substring(xx, 3);
                    int x = Convert.ToInt32(mapID) + 1;

                    if (x > 9)
                    {
                        txt_MappingID = "1" + txt_Carline + "9" + "0" + x.ToString();
                    }
                    else
                    {
                        txt_MappingID = "1" + txt_Carline + "9" + "00" + x.ToString();
                    }

                }
                catch
                {
                    txt_MappingID = "1" + txt_Carline + "9" + "001";
                    txt_MapIDseq = 1;
                }
                
            }
            else
                {
                    txt_MappingID = "1" + txt_Carline + "9" + "001";

                }
                ConnLocal.Close();
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
            GetMappingListDetails();
        }
        private void BtnNew_Click(object sender, EventArgs e)
        {
            UpdateStok();
            Updategrid();
            Btn_generate.Enabled = true;
            generateTaskno();

        }
        private void GetMappingSummary()
        {
            try
            {
                ConnLocal.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = ConnLocal;
                cmd.CommandText = "select a.TASKID,a.MappingID,Count(a.CartonID) as StandarPallet,Count(b.CartonID)as Ready,"+
                 " Count(case when isnull(b.cartonID, '') = '' then 1 end) NotReady,case when Count(a.CartonID)<= Count(b.CartonID) then 'Ready' else 'NotReady' end Status  from tbPLBSAMI_FG_tempGenerateLIST"+
                 " a left Join tbPLBSAMI_FG_stgMappingStock b on a.CartonID = b.CartonID and a.sku = b.sku and a.storerkey= b.storerkey "+
                 " where a.TaskID = @TaskID"+
                " group by a.TASKID,a.MappingID ";
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("TaskID", TASKcell);
                DataSet DS = new DataSet();
                DA.Fill(DS);
                dgMappingList.DataSource = DS.Tables[0];
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
        private void dgsSummaryMapping_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            BtnNew.Enabled = true;
            TASKcell = dgsSummaryMapping.Rows[e.RowIndex].Cells[1].Value.ToString();
            GetMappingSummary();
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
