using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgilityTools
{
    public partial class FrmMappingList : Form
    {
        SqlConnection ConnWMS = new SqlConnection(ConfigDB.conWMS);
        SqlConnection ConnLocal = new SqlConnection(ConfigDB.DBlocal);
        private static string TransID;
        private static string txt_UserName;
        private static string txt_StorerKey;


        public FrmMappingList()
        {
            InitializeComponent();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            ShowMappingList();
            ShowGrid();
        }
        private void ShowMappingList()
        {
            try
            {
                ConnLocal.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = ConnLocal;
                cmd.CommandText = " select   mappingID,taskid,sku,cast(count(cartonID) as varchar) as SNP,assyCOde,carline,storerkey  from tbplbsami_fg_tempGenerateList where mappingID=@mappingID group by mappingid,SKU,taskID,assycode,carline,storerkey";
                cmd.Parameters.AddWithValue("MappingID", txt_mappingID.Text);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    txt_mappingList.Text = reader.GetString(0);
                    txt_MI.Text = reader.GetString(1);
                    txt_SKU.Text = reader.GetString(2);
                    txt_SNP.Text = reader.GetString(3);
                    txt_carmaker.Text = reader.GetString(5);
                    txt_Assycode.Text = reader.GetString(4);
                    txt_StorerKey = reader.GetString(6);
                }

                ConnLocal.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Tidak ada data yang ditampilkan"+ ex.ToString());
            }

        }
        private void ShowGrid()
        {

            try
            {

                ConnLocal.Open();

                SqlCommand cmd = new SqlCommand(" select TaskID ,MappingID,SKU,AssyCode,cartonID as 'CartonID',Editdate,editby,'0' Status ,ID as TransID  " +
                    " from tbplbsami_fg_tempGenerateList where mappingID=@MappingID " +
                    " union all " +
                    " select TaskID ," +
                    " case when status='Remap' then NewMappingID else MappingID end MappingID,SKU,AssyCode,cartonID as 'CartonID',Editdate,editby, Status ,ID as TransID  " +
                    " from tbLogDeleteMappingList where mappingID=@MappingID  ", ConnLocal);
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@MappingID", txt_mappingID.Text);
                dgsMappingList.Rows.Clear();
                DataTable dt = new DataTable();
                DA.Fill(dt);
                foreach (DataRow Item in dt.Rows)
                {
                    int n = dgsMappingList.Rows.Add();
                    dgsMappingList.Rows[n].Cells[0].Value = "false";
                    dgsMappingList.Rows[n].Cells[1].Value = Item["TaskID"].ToString();
                    dgsMappingList.Rows[n].Cells[2].Value = Item["MappingID"].ToString();
                    dgsMappingList.Rows[n].Cells[3].Value = Item["SKU"].ToString();
                    dgsMappingList.Rows[n].Cells[4].Value = Item["AssyCode"].ToString();
                    dgsMappingList.Rows[n].Cells[5].Value = Item["CartonID"].ToString();
                    dgsMappingList.Rows[n].Cells[6].Value = Item["Editdate"].ToString();
                    dgsMappingList.Rows[n].Cells[7].Value = Item["editby"].ToString();
                    dgsMappingList.Rows[n].Cells[8].Value = Item["Status"].ToString();
                    dgsMappingList.Rows[n].Cells[9].Value = Item["TransID"].ToString();

                }
                ConnLocal.Close();               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private  void UpdateSNP()
        {
            SqlCommand cmd = new SqlCommand("update tbplbsami_fg_tempgeneratelist " +
                " set StdPallet='"+txt_SNP.Text+"'" +
                " where MappingID = '" + txt_mappingID.Text + "'", ConnLocal);

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

            foreach (DataGridViewRow item in dgsMappingList.Rows)
            {
                if (bool.Parse(item.Cells[0].Value.ToString()))
                {
                    ConnLocal.Close();
                    string MappingID = dgsMappingList.Rows[item.Index].Cells["ID"].Value.ToString();
                    SqlCommand cmd = new SqlCommand("delete from tbplbsami_fg_tempgeneratelist where ID = '" + MappingID + "'", ConnLocal);

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
            }
            MessageBox.Show("Deleted");

        }

        private void Btn_Delete_Click(object sender, EventArgs e)
        {
            LOGDelete();
            DeletedSQL();
            ShowGrid();
            ShowMappingList();
            UpdateSNP();
            ShowGrid();

        }

        private void LOGDelete()
        {
            txt_UserName = FormLogin.NIK.ToString() + " "+FormLogin.UserName.ToString();
            foreach (DataGridViewRow item in dgsMappingList.Rows)
            {
                if (bool.Parse(item.Cells[0].Value.ToString()))
                {
                    ConnLocal.Close();
                    string receiptkey = dgsMappingList.Rows[item.Index].Cells["ID"].Value.ToString();
                    SqlCommand cmd = new SqlCommand("insert into kaizenDB.dbo.tbLogDeleteMappingList   (MappingID,CartonID,TASKID,SKU,STorerkey,Editdate,Editby,Carline,MappID,ID,Status,AssyCode,StdPallet) " +
                        " select MappingID,CartonID,TASKID,SKU,STorerkey,getdate()as Editdate,'" + txt_UserName + "' as Editby,Carline,MappID,ID,'Deleted' Status,AssyCode,StdPallet from tbplbsami_fg_tempgeneratelist where ID = '" + receiptkey + "'", ConnLocal);

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
            }
        }

        private void dgsMappingList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_create_new_Click(object sender, EventArgs e)
        {
            CreateMappingID();
        }
        private static string txt_LastmappingID;
        private static string txt_mapID;

        private void CreateMappingID()
        {

            GenerateMappingID();
            
        }
        private void GenerateMappingID()
        {
            //Create ID
            if (txt_carmaker.Text.Contains("HONDA CRV"))
            {

                ConnLocal.Close();
                SqlCommand cmd = new SqlCommand("select storerkey,max(MappingID) as LastMAPID ,Carline from tbplbsami_FG_tempGeneratelist  where Carline=@Carline and storerkey= @storerkey " +
                    " group by storerkey,Carline ", ConnLocal);
                cmd.Parameters.AddWithValue("Carline", txt_carmaker.Text);
                cmd.Parameters.AddWithValue("storerkey", txt_StorerKey);
                ConnLocal.Open();
                var result = cmd.ExecuteScalar();
                if (result != null)
                {
                    try
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            txt_LastmappingID = reader.GetString(1);
                            txt_StorerKey = reader.GetString(0);

                        }

                        string mapID = txt_LastmappingID.Substring(4, 7);
                        int x = Convert.ToInt32(mapID) + 1;
                        txt_mapID = "1HND" + x.ToString();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                        //txt_MappingID = "1HND" + "9007001";
                    }
                }
                else
                {

                }

            }
            else
            {
                ConnLocal.Close();
                SqlCommand cmd = new SqlCommand("select storerkey,max(MappingID) as LastMAPID ,Carline from tbplbsami_FG_tempGeneratelist  where Carline=@Carline and storerkey= @storerkey " +
                    " group by storerkey,Carline ", ConnLocal);
                cmd.Parameters.AddWithValue("Carline", txt_carmaker.Text);
                cmd.Parameters.AddWithValue("storerkey", txt_StorerKey);
                ConnLocal.Open();
                var result = cmd.ExecuteScalar();
                if (result != null)
                {
                    try
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            txt_LastmappingID = reader.GetString(1);
                            txt_StorerKey = reader.GetString(0);

                        }
                        ConnLocal.Close();
                        string mapID = txt_LastmappingID.Substring(txt_LastmappingID.Length - 8);
                        int x = Convert.ToInt32(mapID) + 1;
                        if (txt_StorerKey == "PLBSAMTFG")
                        {
                            txt_mapID = "TS. " + txt_carmaker.Text + " - " + x.ToString();

                        }
                        else
                        {
                            txt_mapID = "JS. " + txt_carmaker.Text + " - " + x.ToString();
                        }

                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
            txt_NewMappingID.Text = txt_mapID.ToString();
            insertNewSQL();
        }
        private void insertNewSQL()
        {
            txt_UserName = FormLogin.NIK.ToString() + " " + FormLogin.UserName.ToString();
                    SqlCommand cmd = new SqlCommand("insert into  tbplbsami_fg_tempgeneratelist  (MappingID,CartonID,TASKID,SKU,STorerkey,Editdate,Editby,Carline,MappID,Status,AssyCode,StdPallet) " +
                        " select '"+txt_mapID.ToString()+"'MappingID,CartonID,TASKID,SKU,STorerkey,getdate()as Editdate,'" + txt_UserName + "' as Editby,Carline,MappID,'Remap' Status,AssyCode,StdPallet from kaizenDB.dbo.tbLogDeleteMappingList where status ='Deleted' and mappingID = '" + txt_mappingID.Text + "'", ConnLocal);

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
            UpdateNewMapping();

        }
        private void UpdateNewMapping()
        {
            SqlCommand cmd = new SqlCommand("update kaizenDB.dbo.tbLogDeleteMappingList " +
               " set Status='Remap'" +
               " where MappingID = '" + txt_mappingList.Text + "'", ConnLocal);

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

            UpdateNewMapping2();
        }
        private void UpdateNewMapping2()
        {
            SqlCommand cmd = new SqlCommand("update kaizenDB.dbo.tbLogDeleteMappingList " +
               " set NewMappingID='"+ txt_mapID.ToString() + "'" +
               " where MappingID = '" + txt_mappingList.Text + "'", ConnLocal);

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

            NewMappingList();
        }
        private void NewMappingList()
        {
            try
            {
                ConnLocal.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = ConnLocal;
                cmd.CommandText = " select   mappingID,taskid,sku,cast(count(cartonID) as varchar) as SNP,assyCOde,carline,storerkey  from tbplbsami_fg_tempGenerateList where mappingID=@mappingID group by mappingid,SKU,taskID,assycode,carline,storerkey";
                cmd.Parameters.AddWithValue("MappingID", txt_mapID.ToString());
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    txt_NewMappingID.Text = reader.GetString(0);
                    txt_newMI.Text = reader.GetString(1);
                    Txt_newSKU.Text = reader.GetString(2);
                    txt_newSNP.Text = reader.GetString(3);
                    txt_newCarmaker.Text = reader.GetString(5);
                    txt_newAssyCode.Text = reader.GetString(4);
                    txt_StorerKey = reader.GetString(6);
                }

                ConnLocal.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Tidak ada data yang ditampilkan" + ex.ToString());
            }
            ShowGrid();
            MessageBox.Show("Succesed");
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            ShowGrid();
        }

        private void btn_help_Click(object sender, EventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo("http://10.130.36.11/tutorial/How-To-Edit-MappingList.pdf");
            Process.Start(sInfo);
        }
    }
}
