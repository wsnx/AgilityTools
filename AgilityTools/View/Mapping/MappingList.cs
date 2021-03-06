﻿using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing;

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
        private static string TaskStorer;
        private static string TASKcell;
        private static string MappingCell;
        private static string txt_taxtID;
        private static DateTime Editdate = DateTime.Now;
        private static int endSerial;
        private static int aLoop;
        public MappingList()
        {
            InitializeComponent();
        }
        private void getList()
        {
            try
            {
                ConnLocal.Open();
                SqlDataAdapter DA = new SqlDataAdapter("Select a.RECEIPTKEY,a.TrailerNumber,a.storerkey, concat(count(b.sku) / count(distinct(a.SKU)), '%') as SKU, concat(count(b.CartonID) / count(distinct(a.Lottable10)), '%') as Carton" +
                " from tbPLBSAMI_FG_stgReceiptdetail a " +
                " left join tbPLBSAMI_FG_UnloadDetails b" +
                " on a.RECEIPTKEY = b.Receiptkey and a.sku = b.sku and a.Lottable10 = b.cartonid and a. POLINENUMBER as TOID = b.frompalletid " +
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
        private void GoodStok()
        {
            ConnLocal.Close();
            ConnLocal.Open();
            SqlCommand cmd = new SqlCommand("truncate table tbPLBSAMI_FG_stgMappingStock", ConnLocal);
            cmd.ExecuteNonQuery();
            ConnLocal.Close();
            DataSet ds;
            Conn.Open();
            SqlDataAdapter DA = new SqlDataAdapter("select b.RECEIPTKEY ,a.LOT,a.SKU, b.ALTSKU as FromPallet,b.LOTTABLE10 as CartonID,a.QTY,a.STORERKEY,cast(c.SUSR9 as int)as stdPallet,b.STATUS,c.RETAILSKU ,d.locationflag,b.DATERECEIVED as Receiptdate from LOTXLOCXID a  " +
            " right join RECEIPTDETAIL b on a.lot = b.TOLOT" +
            " inner join sku c on a.sku = c.sku and a.STORERKEY = b.STORERKEY" +
            " inner join loc d on a.loc = d.LOC" +
            " where a.STORERKEY like'%PLBS%' and a.qty > 0" +
            " order by b.LOTTABLE10, a.SKU", Conn);
            ds = new DataSet();
            DA.Fill(ds);
            Conn.Close();
            ConnLocal.Open();
            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(ConnLocal))
            {
                bulkCopy.DestinationTableName =
                    "tbPLBSAMI_FG_stgMappingStock";
                try
                {
                    bulkCopy.WriteToServer(ds.Tables[0]);
                    btn_Save.Enabled = true;
                    MessageBox.Show("succes");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            ConnLocal.Close();
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
                dgsMappingList_details.DataSource = DS.Tables[0];
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
                SqlDataAdapter DA = new SqlDataAdapter("select max(cast(DateMapping as date)) as Tanggal,TaskID,count(distinct(mappingID))as JumlahMappingID, STorerkey as Customer,max(EditBy)as Username from vTbPLBSAMI_FG_MappingList   where isnull(taskid,'')<>'' Group by taskid,STorerkey order by max(dateMapping) desc ", ConnLocal);
                DataSet DS = new DataSet();
                DA.Fill(DS);
                dgsSummaryMapping.DataSource = DS.Tables[0];
                DataGridViewColumn column = dgsSummaryMapping.Columns[0];
                DataGridViewColumn column2 = dgsSummaryMapping.Columns[1];
                DataGridViewColumn column3 = dgsSummaryMapping.Columns[2];
                DataGridViewColumn column4 = dgsSummaryMapping.Columns[2];
                DataGridViewColumn column5 = dgsSummaryMapping.Columns[2];
                column.Width = 160;
                column2.Width = 160;
                column3.Width = 160;
                column4.Width = 160;
                column5.Width = 160;
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
            SqlCommand cmd = new SqlCommand("truncate table tbPLBSAMI_FG_stgMappingStock", ConnLocal);
            cmd.ExecuteNonQuery();
            ConnLocal.Close();
            DataSet ds;
            Conn.Open();
            SqlDataAdapter DA = new SqlDataAdapter("select b.RECEIPTKEY ,a.LOT,a.SKU, b.ALTSKU as FromPallet,b.LOTTABLE10 as CartonID,a.QTY,a.STORERKEY,cast(c.SUSR9 as int)as stdPallet,b.STATUS, " +
            " case when isnull(c.Carmaker,'')='' then c.retailsku else c.carmaker end Carmaker ,a.loc, d.locationflag,a.id as ToPalletID, b.datereceived from LOTXLOCXID a  " +
            " right join RECEIPTDETAIL b on a.lot = b.TOLOT" +
            " inner join (select storerkey,sku,susr9,BUSr10 as Carmaker,retailsku from sku where storerkey like '%PLBSAM%') c on a.sku = c.sku and a.STORERKEY = b.STORERKEY " +
            " inner join loc d on a.loc = d.LOC " +
            " where a.STORERKEY like'%PLBS%' and d.loc <>'Damage' and a.qty > 0 and Carmaker<>'ALL' " +
            " order by b.LOTTABLE10, a.SKU ", Conn);
            ds = new DataSet();
            DA.Fill(ds);
            Conn.Close();

            ConnLocal.Open();
            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(ConnLocal))
            {
                bulkCopy.DestinationTableName =
                    "tbPLBSAMI_FG_stgMappingStock";
                try
                {
                    bulkCopy.WriteToServer(ds.Tables[0]);
                    btn_Save.Enabled = true;
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
            DsWMS.Clear();
            SqlCommand cmd = new SqlCommand(" select DENSE_RANK() OVER (PARTITION BY a.SKU ORDER BY b.mappingID  asc ) AS No,a.storerkey,a.carline,a.sku,min(a.cartonID)as startSerial,Max(a.cartonID)as endserial ,((cast(max(a.cartonid)as int)-cast(min(a.Cartonid)as int))+((cast(max(a.cartonid)as int)-cast(min(a.Cartonid)as int))%cast(stdpallet as int)))+cast(stdpallet as int)as Gap, " +
            " a.stdPallet, b.MappingID,'Ready' as Status, max(c.notes) as CekMapping from tbPLBSAMI_FG_stgMappingStock a" +
            " left join tbPLBSAMI_FG_tempGenerateLIST b on a.CartonID = b.CartonID and a.sku = b.SKU and a.Storerkey = b.STorerkey " +
            " left join  (select cartonID,SKU , notes from tbplbsami_fg_mappingChecking ) c on a.CartonID = c.CartonID and c.sku = b.sku" +
            " where isnull(mappingID, '') = '' and a.locationflag ='HOLD'" +
            " group by a.sku, stdPallet, a.storerkey, a.carline, b.MappingID", ConnLocal);
            ConnLocal.Open();
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DA.Fill(DsWMS);
            ConnLocal.Close();
            dgMappingList.DataSource = DsWMS.Tables[0];
            tabControl1.SelectedTab = tabPage2;
        }
        
        private void RunMapping()
        {
            DsWMS.Clear();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConnLocal;
            cmd.CommandText = "select a.storerkey,a.carline,a.sku,min(a.cartonID)as startSerial,Max(a.cartonID)as endserial , " +
            " ((cast(max(a.cartonid) as int) - cast(min(a.Cartonid) as int)) + ((cast(max(a.cartonid) as int) - cast(min(a.Cartonid) as int)) % cast(stdpallet as int))) + cast(stdpallet as int) as Gap, " +
            " case when SUBSTRING(a.Carline,0,charindex(' ', a.Carline))= '' then a.Carline else SUBSTRING(a.Carline, 0, charindex(' ', a.Carline)) end CarlineID, " +
            " a.stdPallet, b.MappingID from tbPLBSAMI_FG_stgMappingStock a " +
            " left join tbPLBSAMI_FG_tempGenerateLIST b on a.CartonID = b.CartonID and a.sku = b.SKU and a.Storerkey = b.STorerkey" +
            " where isnull(mappingID, '') = ''  " +
            " group by a.sku, stdPallet, a.storerkey, a.carline, b.MappingID ";

            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DA.Fill(DsWMS);
            aLoop = DsWMS.Tables[0].Rows.Count;
            int a = DsWMS.Tables[0].Rows.Count;
            this.ProgressBar1.Minimum = 0;
            this.ProgressBar1.Maximum = DsWMS.Tables[0].Rows.Count;
            dgMappingList.DataSource = DsWMS.Tables[0];

            for (int i = 0; i < aLoop; i++)
            {
                this.ProgressBar1.Value = this.ProgressBar1.Value + 1;
                string Pallet = DsWMS.Tables[0].Rows[i]["stdPallet"].ToString();
                Std_Pallet = Convert.ToInt32(Pallet);
                txt_CartonID = DsWMS.Tables[0].Rows[i]["Startserial"].ToString();
                string Serial = DsWMS.Tables[0].Rows[i]["GAP"].ToString();
                endSerial = Convert.ToInt32(Serial);
                txt_SKU = DsWMS.Tables[0].Rows[i]["SKU"].ToString();
                txt_Storerkey = DsWMS.Tables[0].Rows[i]["Storerkey"].ToString();
                txt_Carline = DsWMS.Tables[0].Rows[i]["CarlineID"].ToString();
                GenerateMappingID();
                GenerateMappingList();
            }
        }

        private void GenerateMappingList()
        {

            int x = Convert.ToInt32(txt_CartonID);
            GenerateMappingID();
            for (int i = x; i < ((x) + Std_Pallet); i++)
            {
                int b = i.ToString().Length;
                int a = txt_CartonID.Length;
                string c = txt_CartonID.Substring(0, a - b);
                txt_CartonID = c.ToString() + i.ToString();
                ConnLocal.Close();
                SqlCommand cmd = new SqlCommand("insert into   tbPLBSAMI_FG_tempGenerateLIST  (MappingID,CartonID,TaskID,sku,storerkey,editdate,editby,Carline ) values(@MappingID,@CartonID,@TaskID,@sku,@storerkey,@editdate,@editby,@carline)", ConnLocal);
                cmd.Parameters.Add(new SqlParameter("MappingID", txt_MappingID));
                cmd.Parameters.Add(new SqlParameter("CartonID", txt_CartonID));
                cmd.Parameters.Add(new SqlParameter("TaskID", txt_taxtID));
                cmd.Parameters.Add(new SqlParameter("SKU", txt_SKU));
                cmd.Parameters.Add(new SqlParameter("Storerkey", txt_Storerkey));
                cmd.Parameters.Add(new SqlParameter("Editdate", Editdate));
                cmd.Parameters.Add(new SqlParameter("EditBy", FormLogin.NIK+" "+FormLogin.UserName));
                cmd.Parameters.Add(new SqlParameter("Carline", txt_Carline));
                ConnLocal.Open();
                cmd.ExecuteNonQuery();
                ConnLocal.Close();
            }
            RunMapping();
        }
        private void GenerateMappingID()
        {   
            ConnLocal.Close();
            SqlCommand cmd = new SqlCommand("select storerkey,max(MappingID) as LastMAPID ,Carline from tbPLBSAMI_FG_tempGenerateLIST  where Carline=@Carline and storerkey= @storerkey " +
                " group by storerkey,Carline ", ConnLocal);
            cmd.Parameters.AddWithValue("Carline", txt_Carline);
            cmd.Parameters.AddWithValue("storerkey", txt_Storerkey);


            ConnLocal.Open();
            var result = cmd.ExecuteScalar();
            if (result != null)
            {
                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        txt_mapID = reader.GetString(1);
                        txt_Storerkey = reader.GetString(0);

                    }
                    int xx = txt_Carline.ToString().Length + 7;
                    string mapID = txt_mapID.Substring(xx, 8);
                    int x = Convert.ToInt32(mapID) + 1;
                    if (txt_Storerkey=="PLBSAMTFG")
                    {
                        txt_MappingID = "TS. " + txt_Carline + " - " + x.ToString();

                    }
                    else
                    {
                        txt_MappingID = "JS. " + txt_Carline + " - " + x.ToString();

                    }

                }
                catch
                {
                    getlastPALLET();
                }

            }
            else
            {
                getlastPALLET();

            }
            ConnLocal.Close();
        }
        private void getlastPALLET()
        {
            ConnLocal.Close();
            SqlCommand cmd = new SqlCommand("select cast(LastID as varchar) as LastID from tbPLBSAMI_FG_LASTPALLET where Carline= @Carline  ", ConnLocal);
            cmd.Parameters.AddWithValue("Carline", txt_Carline);
            ConnLocal.Open();
            try
            {
                var result = cmd.ExecuteScalar();
                if (result != null)
                {
                    try
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            string map = reader.GetString(0);
                            int a = Convert.ToInt32(map) + 1;
                            txt_mapID = a.ToString();

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            ConnLocal.Close();
        }
        private void MappingList_Load(object sender, EventArgs e)
        {
            dgMappingList.EnableHeadersVisualStyles = false;
            dgsSummaryMapping.EnableHeadersVisualStyles = false;
            dgsMappingList_details.EnableHeadersVisualStyles = false;
            dgMappingList.ColumnHeadersDefaultCellStyle.BackColor = Color.Orange;
            dgsSummaryMapping.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgsMappingList_details.GridColor = Color.Gray;
            dgsSummaryMapping.ColumnHeadersDefaultCellStyle.BackColor = Color.Orange;
            dgsMappingList_details.ColumnHeadersDefaultCellStyle.BackColor = Color.Orange;
            taskList();
           btn_Save.Enabled = false;
        }
       
        private void generateTaskno()
        {
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
            int b = x.ToString().Length;
            int a = MAPid.Length;
            string c = MAPid.Substring(0, a - b);
            txt_taxtID = "TASK" + yyy.ToString() + mm.ToString() + dd.ToString() + c.ToString() + x.ToString();
            txt_taskNo.Text = txt_taxtID;
            txt_Date.Text = dd.ToString() + "-" + mm.ToString() + "-" + Editdate.Year.ToString(); ;
            
        }
        private void saveTask()
        {
            ConnLocal.Close();
            SqlCommand cmd2 = new SqlCommand("insert into tbPLBSAMI_FG_Task (TaskID,Edidate ) values (@TaskID,@Editdate)", ConnLocal);
            cmd2.Parameters.Add(new SqlParameter("TaskID", txt_taxtID));
            cmd2.Parameters.Add(new SqlParameter("Editdate", Editdate));
            ConnLocal.Open();
            cmd2.ExecuteNonQuery();
            ConnLocal.Close();
            BtnNew.Enabled = false;
            
        }
        private void Btn_generate_Click(object sender, EventArgs e)
        {
            taskList();
        }
        private void BtnNew_Click(object sender, EventArgs e)
        {
            UpdateStok();
            Updategrid();
            generateTaskno();

        }
        private void GetMappingSummary()
        {
            try
            {
                ConnLocal.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = ConnLocal;
                
                cmd.CommandText = "select DENSE_RANK() OVER (PARTITION BY taskID ORDER BY mappingID  asc ) AS No,Storerkey,MappingID,SKU,MIN(cartonID) as StartSerial ,Max(cartonID) as EndSerial ,max(stdPallet)as StdPallet,count(distinct(cartonIDstock))as Ready , " +
                    " Max(stdPallet) - count(distinct(cartonIDstock)) as Not_Ready,case when Max(stdPallet)-count(distinct(cartonIDstock)) > 0 then 'Not Complete' else 'Complete'end Status, " +
                    "  case when Count(distinct(CartonIDcheck))= max(stdpallet) then 'Sesuai' else cast(Count(distinct(CartonIDcheck)) as varchar)  end CekMapping, "+
                    "  concat(cast(cast(Count(distinct(CartonIDcheck)) as float) / max(stdPallet) as decimal(18, 2)) * 100, '%') as Percentage ,Loc " +
                    " from vTbPLBSAMI_FG_MappingList where TaskID = @TaskID and storerkey = @storerkey   " +
                    " group by MappingID,Storerkey,taskID,Loc,SKU " +
                    "having Count(distinct(cartonID))>0 ";
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("storerkey", TaskStorer);
                cmd.Parameters.AddWithValue("TaskID", TASKcell);
                DataSet DS = new DataSet();
                DS.Clear();
                DA.Fill(DS);
                dgMappingList.DataSource = DS.Tables[0];
                DataGridViewColumn column = dgMappingList.Columns[0];
                DataGridViewColumn column2 = dgMappingList.Columns[1];
                DataGridViewColumn column3 = dgMappingList.Columns[2];
                column.Width = 30;
                column2.Width = 160;
                column3.Width = 200;

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
            TaskStorer = dgsSummaryMapping.Rows[e.RowIndex].Cells[3].Value.ToString();

            GetMappingSummary();
            txt_taskNo.Text = TASKcell.ToString();
            Btn_generate.Enabled = true;
            tabPage2.Focus();

        }
        private void GetMappingDetail()
        {
            try
            {
                ConnLocal.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = ConnLocal;
                cmd.CommandText = " select a.STorerkey,a.MappingID,a.SKU,a.CartonID,b.FromPallet,b.Qty , " +
                    " case when isnull(b.cartonID,'')='' then 'Not Ready' else 'Ready' end Status,c.notes as CekMapping,b.receiptkey as ASN,b.LOC from tbPLBSAMI_FG_tempGenerateLIST " +
                    " a left Join tbPLBSAMI_FG_stgMappingStock b on a.CartonID = b.CartonID and a.sku = b.sku" +
                    "  left join  (select cartonID,SKU , notes from tbplbsami_fg_mappingChecking ) c on a.CartonID = c.CartonID and c.sku = b.sku " +
                    " where a.TaskID = @TaskID and a.mappingID=@mappingID";
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("TaskID", TASKcell);
                cmd.Parameters.AddWithValue("mappingID", MappingCell);
                DataSet DS = new DataSet();
                DA.Fill(DS);
                dgsMappingList_details.DataSource = DS.Tables[0];
                ConnLocal.Close();
                tabMappingLIST.SelectedTab = tabPage4;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btn_Save_Click(object sender, EventArgs e)
        {
            RunMapping();
            GetMappingListDetails();
        }

        private void dgMappingList_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            MappingCell = dgMappingList.Rows[e.RowIndex].Cells[2].Value.ToString();
            GetMappingDetail();
           
        }

        private void dgMappingList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgMappingList_MouseClick(object sender, MouseEventArgs e)
        {
         
        }

        private void dgMappingList_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }

        private void dgMappingList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            
            foreach (DataGridViewRow row in dgMappingList.Rows)
            {
                if (Convert.ToString(row.Cells["Status"].Value) == "NotReady")// Or your condition 
                {
                    row.Cells["Status"].Style.BackColor = Color.Red;
                    row.Cells["MappingID"].Style.ForeColor = Color.Red;

                }
                else if (Convert.ToString(row.Cells["Status"].Value) == "Closed")// Or your condition 
                {

                    row.Cells["Status"].Style.BackColor = Color.Yellow;
                    row.Cells["MappingID"].Style.BackColor = Color.Yellow;
                    row.Cells["MappingID"].Style.ForeColor = Color.Red;

                }
                else if (Convert.ToString(row.Cells["CekMapping"].Value) == "Sesuai")
                {

                    row.Cells["CekMapping"].Style.BackColor = Color.Green;
                    row.Cells["MappingID"].Style.ForeColor = Color.Green;

                }


            }
        }

        private void txt_Date_Click(object sender, EventArgs e)
        {

        }

        private void txt_taskNo_Click(object sender, EventArgs e)
        {

        }

        private void ContextMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
        }

        private void add_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Halo");
        }
    }
}
