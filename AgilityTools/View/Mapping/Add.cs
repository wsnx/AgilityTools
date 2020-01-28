using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgilityTools
{
    public partial class Add : Form
    {
        private static DateTime Editdate = DateTime.Now;
        SqlConnection ConnWMS = new SqlConnection(ConfigDB.conWMS);
        SqlConnection ConnLocal = new SqlConnection(ConfigDB.DBlocal);
        DataSet DsWMS = new DataSet();
        DataSet dsExcel = new DataSet();

        private static string _path;
        public Add()
        {
            InitializeComponent();
        }
        private void search()
        {
            ConnLocal.Close();
            ConnLocal.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConnLocal;
            cmd.CommandText = "select Plankey,Tujuan,liner,Carmaker,Freight,ETD_PLB,Factory from tbMappingInstruction where plankey=@plankey";
            cmd.Parameters.AddWithValue("plankey", txt_planKey.Text.ToString());
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                txt_tujuan.Text = reader.GetString(1);
                txt_shipingLine.Text = reader.GetString(2);
                txt_carMaker.Text = reader.GetString(3);
                txt_Freight.Text = reader.GetString(4);
                txt_etdPLB.Text = reader.GetString(5);

            }
            ConnLocal.Close();
            ShowGrid();
        }
        private void Edit()
        {

            
            ConnLocal.Close();
             
            SqlCommand cmd = new SqlCommand("update tbMappingInstruction " +
                "set StartSerial= @StartSerial," +
                "EndSerial=@EndSerial ," +
                "SNP = @SNP ," +
                "AssyCode = @AssyCode," +
                " Qty = @Qty" +
                " where AssyNumber = @AssyNumber", ConnLocal);
            cmd.Parameters.Add(new SqlParameter("AssyNumber", txt_SKU.Text));
            cmd.Parameters.Add(new SqlParameter("AssyCode", txt_AssyCode.Text));
            cmd.Parameters.Add(new SqlParameter("Qty", txt_DestinationCode.Text));
            cmd.Parameters.Add(new SqlParameter("SNP", txt_SNP.Text));
            cmd.Parameters.Add(new SqlParameter("StartSerial", txt_serial.Text));
            cmd.Parameters.Add(new SqlParameter("EndSerial", txt_end.Text));
            ConnLocal.Open();
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Succes");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            ShowGrid();
        }
        private void ShowGrid()
        {
            DsWMS.Clear();
            ConnLocal.Close();
            SqlCommand cmd = new SqlCommand(" select Assynumber as SKU,AssyCode,SNP,QTY,StartSerial,EndSerial from tbMappingInstruction where plankey=@plankey", ConnLocal);
            cmd.Parameters.AddWithValue("plankey", txt_planKey.Text);
            ConnLocal.Open();
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            DA.Fill(ds);
            ConnLocal.Close();
            dgsDraftList.DataSource = ds.Tables[0];
            dgsDraftListbinding.DataSource = ds.Tables[0];
            
        }
        private void AddSql()
        {
            ConnLocal.Close();
            SqlCommand cmd = new SqlCommand("insert into tbMappingInstruction (Carmaker,Plankey,AssyNumber,AssyCode,DestinationCode,ETD_PLB,Tujuan,SNP,StartSerial,EndSerial,Factory,Liner,Freight)" +
            "values(@Carmaker, @Plankey, @AssyNumber, @AssyCode, @DestinationCode, @ETD_PLB, @Tujuan, @SNP, @StartSerial, @EndSerial, @Factory, @Liner, @Freight)", ConnLocal);
            cmd.Parameters.Add(new SqlParameter("Carmaker",txt_carMaker.Text));
            cmd.Parameters.Add(new SqlParameter("Plankey",txt_planKey.Text));
            cmd.Parameters.Add(new SqlParameter("AssyNumber",txt_SKU.Text));
            cmd.Parameters.Add(new SqlParameter("AssyCode",txt_AssyCode.Text));
            cmd.Parameters.Add(new SqlParameter("DestinationCode", txt_DestinationCode.Text));
            cmd.Parameters.Add(new SqlParameter("ETD_PLB",txt_etdPLB.Text));
            cmd.Parameters.Add(new SqlParameter("Tujuan",txt_tujuan.Text));
            cmd.Parameters.Add(new SqlParameter("SNP",txt_SNP.Text));
            cmd.Parameters.Add(new SqlParameter("StartSerial",txt_serial.Text));
            cmd.Parameters.Add(new SqlParameter("EndSerial",txt_end.Text));
            cmd.Parameters.Add(new SqlParameter("Factory",txt_Storerkey.Text));
            cmd.Parameters.Add(new SqlParameter("Liner",txt_shipingLine.Text));
            cmd.Parameters.Add(new SqlParameter("Freight",txt_Freight.Text));
            ConnLocal.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Sukses");
            txt_SKU.Text = "";
            txt_SNP.Text = "";
            txt_serial.Text = "";
            txt_end.Text = "";
            txt_DestinationCode.Text = "";
            txt_AssyCode.Text = "";
            txt_STD_PALLET.Text = "";
            ShowGrid();
            ConnLocal.Close();
        }

        private void Close_Click(object sender, EventArgs e)
        {

            this.Dispose();
        }

        private void Btn_cari_Click(object sender, EventArgs e)
        {
            search();
        }
        private void btn_Add_Click(object sender, EventArgs e)
        {
            AddSql();
        }
        private void UploadFile()
        {
            
        }
        private static string SKU;
        private static string AssyCode;
        private static string SNP;
        private static string QTY;
        private static string StartSerial;
        private static string EndSerial;
        private static string Plankey;

        private void dgsDraftList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            SKU = dgsDraftList.Rows[e.RowIndex].Cells[0].Value.ToString();
            AssyCode = dgsDraftList.Rows[e.RowIndex].Cells[1].Value.ToString();
            SNP = dgsDraftList.Rows[e.RowIndex].Cells[2].Value.ToString();
            QTY = dgsDraftList.Rows[e.RowIndex].Cells[3].Value.ToString();
            StartSerial = dgsDraftList.Rows[e.RowIndex].Cells[4].Value.ToString();
            EndSerial = dgsDraftList.Rows[e.RowIndex].Cells[5].Value.ToString();
            txt_SKU.Text = SKU.ToString();
            txt_SNP.Text = SNP.ToString();
            txt_serial.Text = StartSerial.ToString();
            txt_end.Text = EndSerial.ToString();
            txt_DestinationCode.Text = QTY.ToString();
            txt_AssyCode.Text = AssyCode.ToString();
            btn_Add.Enabled = false;
            Btn_save.Enabled = true;
            Btn_save.Visible = true;

        }

        private void Btn_Edit_Click(object sender, EventArgs e)
        {
            Edit();
            txt_SKU.Text = "";
            txt_SNP.Text = "";
            txt_serial.Text = "";
            txt_end.Text = "";
            txt_DestinationCode.Text = "";
            txt_AssyCode.Text = "";
            Btn_save.Visible = false;
            btn_Add.Enabled = true;


        }
        private void UploadExcel()
        {
            
        }
        private void SaveDataGrid()
        {
            SqlDataAdapter DA = new SqlDataAdapter();
            DA.Update(DsWMS.Tables[0]);
        }
        private void Add_Load(object sender, EventArgs e)
        {
            Btn_save.Visible = false;
        }

        private void dgsDraftList_FilterStringChanged(object sender, EventArgs e)
        {
            this.dgsDraftListbinding.Filter = this.dgsDraftList.FilterString;
        }

        private void dgsDraftList_SortStringChanged(object sender, EventArgs e)
        {
            this.dgsDraftListbinding.Sort = this.dgsDraftList.SortString;

        }

        DataSet dsUpdate = new DataSet();
        private void btn_new_Click(object sender, EventArgs e)
        {   
            int aLoop = dgsDraftList.Rows.Count;
            int a = dgsDraftList.Rows.Count;
            try
            {
                for (int i = 0; i < aLoop; i++)
                {
                    Plankey = dsUpdate.Tables[0].Rows[i]["PlanKey"].ToString();
                    SKU = dgsDraftList.Rows[i].Cells[0].Value.ToString();
                    AssyCode = dgsDraftList.Rows[i].Cells[1].Value.ToString();
                    SNP = dgsDraftList.Rows[i].Cells[2].Value.ToString();
                    QTY = dgsDraftList.Rows[i].Cells[3].Value.ToString();
                    StartSerial = dgsDraftList.Rows[i].Cells[4].Value.ToString();
                    EndSerial = dgsDraftList.Rows[i].Cells[5].Value.ToString();
                    MessageBox.Show(SKU);
                    UpdateSQL();
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
        }

        private void UpdateSQL()
        {
            ConnLocal.Close();
            MessageBox.Show(SKU+ txt_planKey.Text+ QTY);
            SqlCommand cmd = new SqlCommand("update tbMappingInstruction " +
                "set StartSerial= @StartSerial," +
                "EndSerial=@EndSerial ," +
                "SNP = @SNP ," +
                "AssyCode = @AssyCode," +
                " Qty = @Qty" +
                " where AssyNumber = @AssyNumber and PlanKey=@PlanKey", ConnLocal);
            cmd.Parameters.Add(new SqlParameter("AssyNumber", SKU));
            cmd.Parameters.Add(new SqlParameter("AssyCode", AssyCode));
            cmd.Parameters.Add(new SqlParameter("Qty", QTY));
            cmd.Parameters.Add(new SqlParameter("SNP", SNP));
            cmd.Parameters.Add(new SqlParameter("StartSerial", StartSerial));
            cmd.Parameters.Add(new SqlParameter("EndSerial", EndSerial));
            cmd.Parameters.Add(new SqlParameter("PlanKey", txt_planKey.Text));

            ConnLocal.Open();
            try
            {
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            ShowGrid();
        }

        private void txt_SKU_Leave(object sender, EventArgs e)
        {
            ConnWMS.Close();
            ConnWMS.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConnWMS;
            cmd.CommandText = "select SUSR9,STORERKEY from SKU where SKU =@SKU";
            cmd.Parameters.AddWithValue("SKU", txt_SKU.Text.ToString());
            cmd.Parameters.AddWithValue("STORERKEY", txt_Storerkey.Text.ToString());

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                txt_STD_PALLET.Text = reader.GetString(0);
            }
            ConnWMS.Close();
        }
       private void btn_upload_Click(object sender, EventArgs e)
        {

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.Filter = "xlsx|*.xlsx";
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.txtFileName.Text = this.openFileDialog1.FileName;
                this.txtShortFileName.Text = this.openFileDialog1.SafeFileName;
                if (isFileAda() == true)
                {
                    if (MessageBox.Show("File sudah pernah diupload, apakah akan di-replace ?", "Double Upload", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        Btn_Upload.Enabled = true;
                    }
                    else
                    {
                        
                        this.txtFileName.Text = "";
                        this.txtShortFileName.Text = "";
                    }
                }
                else
                {
                    Btn_Upload.Enabled = true;
                    //Btn_Proses.Enabled = true;
                }
            }
            Show();

        }

        private bool isFileAda()
        {
            bool hasil = false;
            using (SqlConnection cn = new SqlConnection("Integrated Security=False;Data Source=10.130.24.4;Initial Catalog=KaizenDB;User ID=kadmin;Password=53c4dm1n"))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cn;
                    cn.Open();
                    cmd.CommandText = "Select top 1 * from tbMappingInstruction where FileName=@FileName";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("FileName", this.txtShortFileName.Text);
                    SqlDataReader dr;
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        hasil = true;
                    }

                }
            }
            return hasil;
        }

        private void Btn_Proses_Click(object sender, EventArgs e)
        {
             prosesData();
        }
        private void Show()
        {
            String strXLSConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + this.txtFileName.Text.Trim() + "';Extended Properties=Excel 12.0;Mode=Share Deny Write;";
            DataSet ds = new DataSet();
            if (isFileAda() == true)
            {
                if (MessageBox.Show("File sudah pernah diupload, apakah akan di-replace ?", "Double Upload", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.DeleteData();
                }
                else
                { return; }
            }
            try
            {
                using (System.Data.OleDb.OleDbConnection MyConnection = new System.Data.OleDb.OleDbConnection(strXLSConn))
                {
                    using (System.Data.OleDb.OleDbCommand myCommand = new System.Data.OleDb.OleDbCommand())
                    {
                        MyConnection.Open();
                        myCommand.Connection = MyConnection;

                        myCommand.CommandText = "Select [Car Maker]	,[NO MAPPING INTRUCTION]	,[Assy Number]	,[Assy Code],	[Qty Kirim]	,[ETD PLB]	,[Tujuan]	,[SNP]	,[No Box Terakhir Export]	,[No Box Awal]	,[No Box Akhir]	,[Kode Factory]	,[Liner]	,[Freight]		,[Jumlah Box Per Pallet], [DestinationCode]  " +
                            "  from[MI$]";
                        try
                        {
                            System.Data.OleDb.OleDbDataAdapter da = new System.Data.OleDb.OleDbDataAdapter(myCommand);
                            da.Fill(dsExcel, "hasil");
                            dgsDraftList.DataSource= dsExcel.Tables[0];
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
        }

        private void TampilkanData()
        {
            using (SqlConnection cn = new SqlConnection(ConfigDB.DBlocal))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cn;
                    cn.Open();
                    cmd.CommandText = "Select Carmaker, Plankey, AssyNumber, AssyCode, Qty, ETD_PLB, Tujuan, SNP, StartSerial, EndSerial, Factory, Liner, Freight,DestinationCode from tbMappingInstruction Where FileName=@FileName";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("FileName", this.txtShortFileName.Text);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "hasil");
                    this.dgsDraftList.DataSource = ds.Tables[0];
                }
            }
        }
        
        private void prosesData()
        {
            String strXLSConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + this.txtFileName.Text.Trim() + "';Extended Properties=Excel 12.0;Mode=Share Deny Write;";
            

            try
            {
                using (System.Data.SqlClient.SqlConnection cn = new System.Data.SqlClient.SqlConnection(ConfigDB.DBlocal))
                {
                    using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
                    {
                        cn.Open();
                        this.progressBar.Maximum = dsExcel.Tables[0].Rows.Count;
                        this.progressBar.Minimum = 0;
                        this.progressBar.Value = 0;
                        for (int i = 0; i <= dsExcel.Tables[0].Rows.Count - 1; i++)
                        {
                            progressBar.Value++;
                            if (dsExcel.Tables[0].Rows[i]["No Box Awal"].ToString().Trim() != "")
                            {

                                string strSQL = "INSERT INTO tbMappingInstruction (Carmaker, Plankey, AssyNumber, AssyCode, Qty, ETD_PLB, Tujuan, SNP, StartSerial, EndSerial, Factory, Liner, Freight, FileName, EditDate, Editby,DestinationCode) VALUES (@Carmaker, @Plankey, @AssyNumber, @AssyCode, @Qty, @ETD_PLB, @Tujuan, @SNP, @StartSerial, @EndSerial, @Factory, @Liner, @Freight, @FileName, getdate(), @InputBy,@DestinationCode)";
                                cmd.CommandText = strSQL;
                                cmd.Connection = cn;
                                cmd.Parameters.Clear();
                                cmd.Parameters.AddWithValue("Carmaker", dsExcel.Tables[0].Rows[i]["Car Maker"]);
                                cmd.Parameters.AddWithValue("Plankey", dsExcel.Tables[0].Rows[i]["NO MAPPING INTRUCTION"]);
                                cmd.Parameters.AddWithValue("AssyNumber", dsExcel.Tables[0].Rows[i]["Assy Number"]);
                                cmd.Parameters.AddWithValue("AssyCode", dsExcel.Tables[0].Rows[i]["Assy Code"]);
                                cmd.Parameters.AddWithValue("Qty", dsExcel.Tables[0].Rows[i]["Qty Kirim"]);
                                cmd.Parameters.AddWithValue("ETD_PLB", dsExcel.Tables[0].Rows[i]["ETD PLB"]);
                                cmd.Parameters.AddWithValue("Tujuan", dsExcel.Tables[0].Rows[i]["Tujuan"]);
                                cmd.Parameters.AddWithValue("SNP", dsExcel.Tables[0].Rows[i]["Jumlah Box Per Pallet"]);
                                cmd.Parameters.AddWithValue("StartSerial", dsExcel.Tables[0].Rows[i]["No Box Awal"]);
                                cmd.Parameters.AddWithValue("EndSerial", dsExcel.Tables[0].Rows[i]["No Box Akhir"]);
                                cmd.Parameters.AddWithValue("Factory", dsExcel.Tables[0].Rows[i]["Kode Factory"]);

                                cmd.Parameters.AddWithValue("Liner", dsExcel.Tables[0].Rows[i]["Liner"]);
                                cmd.Parameters.AddWithValue("Freight", dsExcel.Tables[0].Rows[i]["Freight"]);
                                cmd.Parameters.AddWithValue("FileName", this.txtShortFileName.Text.Trim());
                                cmd.Parameters.AddWithValue("InputBy", FormLogin.NIK + " " + FormLogin.UserName);
                                cmd.Parameters.AddWithValue("DestinationCode", dsExcel.Tables[0].Rows[i]["DestinationCode"]);

                                try
                                {
                                    cmd.ExecuteNonQuery();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                    return;
                                }
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
            MessageBox.Show("Done");

            TampilkanData();
            MessageBox.Show("Data Berhasil di-upload");
            this.lblRows.Text = this.dgsDraftList.Rows.Count.ToString() + " row(s)";

        }
        private void DeleteData()
        {
            using (SqlConnection cn = new SqlConnection(ConfigDB.DBlocal))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cn;
                    cn.Open();
                    cmd.CommandText = "Delete tbMappingInstruction Where FileName=@FileName";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("FileName", this.txtShortFileName.Text);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void btn_getMapping_Click(object sender, EventArgs e)
        {
            GetMapping();
        }
        private static string txt_assyCode;
        private static string MappingIDCell;
        private static string txt_SKU1;
        private static string txt_StartSerial;
        private static int txt_endSerial;
        private static int txt_SNP1;
        private static string txt_CartonID;
        private static string txt_Storerkey1;
        private static string txt_Carline;
        private static string txt_mapID;
        private static string txt_MappingID;
        private static string txt_PlanID;
        private static string txt_DestinationCode1;

        private void GetMapping()
        {
            ConnLocal.Close();
            SqlCommand cmd2 = new SqlCommand();
            ConnLocal.Open();
            cmd2.Connection = ConnLocal;
            cmd2.CommandText = ("truncate table tbtempMappingList");
            cmd2.ExecuteNonQuery();
            ConnLocal.Close();

            ConnLocal.Close();
            DsWMS.Clear();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConnLocal;
            cmd.CommandText = "select Carmaker,Plankey,AssyNumber,a.AssyCode,SNP,StartSerial,case when (EndSerial=0 and isnull(c.cartonID,'')<>'') then c.CartonID else EndSerial end endSerial,Factory,Liner,Freight,a.destinationCode " +
            " from tbMappinginstruction a " +
            "left join tbPLBSAMI_FG_tempGenerateLIST b on a.Plankey = b.TASKID and a.AssyNumber = b.SKU  " +
            " left join(select max(lottable10) as CartonID,SKu from tbPLBSAMI_FG_stgReceiptdetail group by SKU)c on a.AssyNumber = c.sku " +
            " where isnull(b.SKU, '') = '' and EndSerial <> 0  and Plankey=@TaskID" +
            " group by Carmaker,Plankey,AssyNumber,a.AssyCode,SNP,StartSerial,EndSerial,Factory,c.CartonID,Liner,Freight,a.destinationCode";
            SqlDataAdapter DA = new SqlDataAdapter(cmd);

            cmd.Parameters.AddWithValue("@TaskID", txt_planKey.Text.ToString());

            DA.Fill(DsWMS);
            int aLoop = DsWMS.Tables[0].Rows.Count;
            int a = DsWMS.Tables[0].Rows.Count;

            try
            {
                for (int i = 0; i < aLoop; i++)
                {
                    txt_assyCode = DsWMS.Tables[0].Rows[i]["AssyCode"].ToString();
                    string Pallet = DsWMS.Tables[0].Rows[i]["SNP"].ToString();
                    txt_SNP1 = Convert.ToInt32(Pallet);
                    txt_CartonID = DsWMS.Tables[0].Rows[i]["Startserial"].ToString();
                    string Serial = DsWMS.Tables[0].Rows[i]["EndSerial"].ToString();
                    txt_endSerial = Convert.ToInt32(Serial);
                    txt_SKU1 = DsWMS.Tables[0].Rows[i]["AssyNumber"].ToString();
                    txt_Storerkey1 = DsWMS.Tables[0].Rows[i]["Factory"].ToString();
                    txt_Carline = DsWMS.Tables[0].Rows[i]["Carmaker"].ToString();
                    txt_PlanID = DsWMS.Tables[0].Rows[i]["Plankey"].ToString();
                    txt_DestinationCode1 = DsWMS.Tables[0].Rows[i]["DestinationCode"].ToString();
                }

                insertMappingInstruction();

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
                MessageBox.Show("Tidak ada Data Untuk di proses");

            }
            finally
            {

            }

        }

        private void insertMappingInstruction()
        {

            int x = Convert.ToInt32(txt_CartonID);

            this.ProgressBar1.Minimum = x;
            this.ProgressBar1.Maximum = txt_endSerial + 1;
            this.ProgressBar1.Value = x;

            for (int i = x; i <= (txt_endSerial); i++)
            {
                this.ProgressBar1.Value = this.ProgressBar1.Value + 1;

                txt_CartonID = i.ToString();
                ConnLocal.Close();
                SqlCommand cmd = new SqlCommand("insert into   tbtempMappingList " +
                    " (CartonID,TASKID,SKU,Storerkey,EditDate,EditBy,Carline,AssyCode,StdPallet,DestinationCode,endSerial ) " +
                    " values(@CartonID,@TASKID,@SKU,@Storerkey,@EditDate,@EditBy,@carline,@Assycode,@SNP,@DestinationCode,@endSerial)", ConnLocal);
                cmd.Parameters.Add(new SqlParameter("CartonID", txt_CartonID));
                cmd.Parameters.Add(new SqlParameter("TASKID", txt_PlanID));
                cmd.Parameters.Add(new SqlParameter("SKU", txt_SKU1));
                cmd.Parameters.Add(new SqlParameter("Storerkey", txt_Storerkey1));
                cmd.Parameters.Add(new SqlParameter("Editdate", Editdate));
                cmd.Parameters.Add(new SqlParameter("EditBy", FormLogin.NIK + " " + FormLogin.UserName));
                cmd.Parameters.Add(new SqlParameter("Carline", txt_Carline));
                cmd.Parameters.Add(new SqlParameter("Assycode", txt_assyCode));
                cmd.Parameters.Add(new SqlParameter("SNP", txt_SNP1));
                cmd.Parameters.Add(new SqlParameter("DestinationCode", txt_DestinationCode1));
                cmd.Parameters.Add(new SqlParameter("EndSerial", txt_endSerial));
                ConnLocal.Open();
                cmd.ExecuteNonQuery();
                ConnLocal.Close();
            }

            RunMapping();
        }
        private static string Endserial;
        private void RunMapping()
        {

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConnLocal;
            cmd.CommandText = "select a.factory,a.Carmaker,b.TaskID,b.AssyCode,a.AssyNumber,a.SNP,min(b.CartonID) as StartSerial,c.MappingID,a.DestinationCode,max(b.endSerial)as EndSerial from tbMappinginstruction a " +
                     "inner join tbtempMappingList b on a.AssyNumber = b.SKU and  a.Plankey = b.TASKID " +
                     "left join tbPLBSAMI_FG_tempGenerateLIST c on a.AssyNumber = c.SKu and a.Plankey = c.TASKID and b.cartonID = c.CartonID " +
                     "where isnull(c.MappingID, '') = '' and plankey=@taskID " +
                     "group by a.Carmaker,b.TaskID,b.AssyCode,a.AssyNumber,a.SNP,c.MappingID,a.factory,a.DestinationCode ";
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            int counter = 0;
            cmd.Parameters.AddWithValue("@TaskID", txt_planKey.Text.ToString());
            DataSet ds = new DataSet();
            ds.Clear();
            DA.Fill(ds);
            int aLoop = DsWMS.Tables[0].Rows.Count;
            int a = ds.Tables[0].Rows.Count;
            try
            {

                for (int i = 0; i < aLoop; i++)
                {
                    counter++;


                    if (counter == 1)
                    {
                        GenerateMappingID();
                    }
                    string Pallet = ds.Tables[0].Rows[i]["SNP"].ToString();
                    txt_SNP1 = Convert.ToInt32(Pallet);
                    txt_CartonID = ds.Tables[0].Rows[i]["Startserial"].ToString();
                    txt_SKU1 = ds.Tables[0].Rows[i]["AssyNumber"].ToString();
                    txt_Storerkey1 = ds.Tables[0].Rows[i]["Factory"].ToString();
                    txt_Carline = ds.Tables[0].Rows[i]["Carmaker"].ToString();
                    txt_PlanID = ds.Tables[0].Rows[i]["TaskID"].ToString();
                    Endserial = ds.Tables[0].Rows[i]["EndSerial"].ToString();
                    txt_assyCode = ds.Tables[0].Rows[i]["AssyCode"].ToString();
                    txt_DestinationCode1 = ds.Tables[0].Rows[i]["DestinationCode"].ToString();

                    SqlCommand cmd2 = new SqlCommand("insert into   tbPLBSAMI_FG_tempGeneratelist " +
                    " (MappingID,CartonID,TASKID,SKU,Storerkey,EditDate,EditBy,Carline,AssyCode,STDPallet,DestinationCode ) " +
                    " values(@MappingID,@CartonID,@TASKID,@SKU,@Storerkey,@EditDate,@EditBy,@carline,@AssyCode,@SNP,@destinationCode)", ConnLocal);
                    cmd2.Parameters.Add(new SqlParameter("MappingID", txt_MappingID));
                    cmd2.Parameters.Add(new SqlParameter("CartonID", txt_CartonID));
                    cmd2.Parameters.Add(new SqlParameter("TASKID", txt_PlanID));
                    cmd2.Parameters.Add(new SqlParameter("SKU", txt_SKU));
                    cmd2.Parameters.Add(new SqlParameter("Storerkey", txt_Storerkey));
                    cmd2.Parameters.Add(new SqlParameter("Editdate", Editdate));
                    cmd2.Parameters.Add(new SqlParameter("EditBy", FormLogin.NIK + " " + FormLogin.UserName));
                    cmd2.Parameters.Add(new SqlParameter("Carline", txt_Carline));
                    cmd2.Parameters.Add(new SqlParameter("AssyCode", txt_assyCode));
                    cmd2.Parameters.Add(new SqlParameter("SNP", txt_SNP));
                    cmd2.Parameters.Add(new SqlParameter("DestinationCode", txt_DestinationCode));
                    ConnLocal.Open();
                    cmd2.ExecuteNonQuery();
                    ConnLocal.Close();

                    if (counter == Convert.ToInt16(txt_SNP))
                    {
                        counter = 0;
                    }
                    else
                    {
                        MessageBox.Show("SALAH");
                    }
                }

            }
            catch (Exception ex)
            {
                ConnLocal.Close();
            }
        }
        private void GenerateMappingID()
        {
            if (txt_Carline.Contains("HONDA CR-V"))
            {

                ConnLocal.Close();
                SqlCommand cmd = new SqlCommand("select storerkey,max(MappingID) as LastMAPID ,Carline from tbplbsami_FG_tempGeneratelist  where Carline=@Carline and storerkey= @storerkey " +
                    " group by storerkey,Carline ", ConnLocal);
                cmd.Parameters.AddWithValue("Carline", txt_Carline);
                cmd.Parameters.AddWithValue("storerkey", txt_Storerkey1);
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
                            txt_Storerkey1 = reader.GetString(0);

                        }

                        string mapID = txt_mapID.Substring(4, 7);
                        int x = Convert.ToInt32(mapID) + 1;
                        txt_MappingID = "1HND" + x.ToString();

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
                cmd.Parameters.AddWithValue("Carline", txt_Carline);
                cmd.Parameters.AddWithValue("storerkey", txt_Storerkey1);
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
                            txt_Storerkey1 = reader.GetString(0);

                        }

                        string mapID = txt_mapID.Substring(txt_mapID.Length - 8);
                        int x = Convert.ToInt32(mapID) + 1;
                        if (txt_Storerkey1 == "PLBSAMTFG")
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
                        if (txt_Storerkey1 == "PLBSAMTFG")
                        {
                            txt_MappingID = "TS. " + txt_Carline + " - " + "19007001";

                        }
                        else
                        {
                            txt_MappingID = "JS. " + txt_Carline + " - " + "19007001";
                        }
                    }
                }
                else
                {
                    if (txt_Storerkey1 == "PLBSAMTFG")
                    {
                        txt_MappingID = "TS. " + txt_Carline + " - " + "19007001";

                    }
                    else
                    {
                        txt_MappingID = "JS. " + txt_Carline + " - " + "19007001";
                    }

                }
            }
        }

        private void GenerateMappingList()
        {
            try
            {
                int x = Convert.ToInt32(txt_CartonID);
                this.ProgressBar1.Minimum = x;
                this.ProgressBar1.Maximum = x + txt_SNP1;
                this.ProgressBar1.Value = x;

                GenerateMappingID();
                for (int i = x; i < ((x) + txt_SNP1); i++)
                {

                    this.ProgressBar1.Value = this.ProgressBar1.Value + 1;

                    txt_CartonID = i.ToString();
                    ConnLocal.Close();
                    SqlCommand cmd = new SqlCommand("insert into   tbPLBSAMI_FG_tempGeneratelist " +
                        " (MappingID,CartonID,TASKID,SKU,Storerkey,EditDate,EditBy,Carline,AssyCode,STDPallet,DestinationCode ) " +
                        " values(@MappingID,@CartonID,@TASKID,@SKU,@Storerkey,@EditDate,@EditBy,@carline,@AssyCode,@SNP,@destinationCode)", ConnLocal);
                    cmd.Parameters.Add(new SqlParameter("MappingID", txt_MappingID));
                    cmd.Parameters.Add(new SqlParameter("CartonID", txt_CartonID));
                    cmd.Parameters.Add(new SqlParameter("TASKID", txt_PlanID));
                    cmd.Parameters.Add(new SqlParameter("SKU", txt_SKU1));
                    cmd.Parameters.Add(new SqlParameter("Storerkey", txt_Storerkey1));
                    cmd.Parameters.Add(new SqlParameter("Editdate", Editdate));
                    cmd.Parameters.Add(new SqlParameter("EditBy", FormLogin.NIK + " " + FormLogin.UserName));
                    cmd.Parameters.Add(new SqlParameter("Carline", txt_Carline));
                    cmd.Parameters.Add(new SqlParameter("AssyCode", txt_assyCode));

                    cmd.Parameters.Add(new SqlParameter("SNP", txt_SNP1));

                    cmd.Parameters.Add(new SqlParameter("DestinationCode", txt_DestinationCode1));
                    ConnLocal.Open();
                    cmd.ExecuteNonQuery();
                    ConnLocal.Close();
                }
            }
            catch (Exception Ex)
            {

            }
            showMappingList();

        }
            private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            showMappingList();
        }

        private void showMappingList()
        {


            ConnLocal.Close();
            SqlCommand cmd = new SqlCommand(" select mappingID,SKU,AssyCode,DestinationCode,min(cast(cartonID as int)) as StartSerial,max(cast(cartonID as int)) as EndSerial,Count(CartonID)as JumnlahCarton from tbplbsami_fg_tempgeneratelist where TaskID=@plankey group by mappingID,SKU,AssyCode,DestinationCode ", ConnLocal);
            cmd.Parameters.AddWithValue("plankey", txt_planKey.Text);
            ConnLocal.Open();
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            DA.Fill(ds);
            ConnLocal.Close();
            dgsMappingList.DataSource = ds.Tables[0];
            

        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            MessageBox.Show("data akan di hapus");
            using (SqlConnection cn = new SqlConnection(ConfigDB.DBlocal))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cn;
                    cn.Open();
                    cmd.CommandText = "Delete tbMappingInstruction Where Plankey=@plankey";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("plankey", this.txt_planKey.Text);
                    cmd.ExecuteNonQuery();
                }
            }

            using (SqlConnection cn = new SqlConnection(ConfigDB.DBlocal))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cn;
                    cn.Open();
                    cmd.CommandText = "Delete tbplbsami_fg_tempgeneratelist Where taskID=@plankey";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("plankey", this.txt_planKey.Text);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
