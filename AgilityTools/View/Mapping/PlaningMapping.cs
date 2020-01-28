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

namespace AgilityTools
{
    public partial class PlaningMapping : UserControl

    {
        private BackgroundWorker bgw;
        private static DateTime Editdate = DateTime.Now;
        SqlConnection Conn = new SqlConnection(ConfigDB.conWMS);
        SqlConnection ConnLocal = new SqlConnection(ConfigDB.DBlocal);
        DataSet DsWMS = new DataSet();
        private static string PlankeyCell;
        public PlaningMapping()
        {
            InitializeComponent();
            TaskList();
        }
        
        private void TaskList()
        {
            ConnLocal.Close();
            SqlCommand cmd = new SqlCommand(" select TASKID as 'MI',Factory,Carmaker,count(distinct(b.MappingID)) as 'Total Mapping List (∑)', " +
                " Count(distinct(a.AssyNumber)) as 'Total SKU Mapping Instruction(∑)',  " +
                " Count(distinct(b.CartonID)) as 'Total Carton Mapping(∑)', MAX((c.ReceiptDate)) as 'Last Received'  " +
                " from(select factory, Plankey, assynumber, ETD_PLB, Tujuan, Carmaker, Liner, Freight from tbMappingInstruction) a " +
                " right join(select editdate, cartonID, sku, TASKID, MappingID from tbPLBSAMI_FG_tempGenerateLIST) b on a.Plankey = b.TASKID  and a.AssyNumber = b.SKU" +
                " inner join(select ReceiptDate, receiptkey, SKU, cartonID  From tbPLBSAMI_FG_stgMappingStock )c on c.sku = b.sku and c.cartonID = b.CartonID " +
                " where isnull(plankey,'')!='' " +
                " group by TASKID,Factory, Carmaker" +
                "  " +
                " ", ConnLocal);
            ConnLocal.Open();
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet(); 
            DA.Fill(ds);
            ConnLocal.Close();
            dgsTaskList.DataSource = ds.Tables[0];
            dgsTaskListBinding.DataSource = ds.Tables[0];
            
        }
        private void DgsMappingList_FilterStringChanged(object sender, EventArgs e)
        {
            this.DgsMappingListBinding.Filter = this.DgsMappingList.FilterString;
        }

        private void DgsMappingList_SortStringChanged(object sender, EventArgs e)
        {
            this.DgsMappingListBinding.Sort = this.DgsMappingList.SortString;

        }
        private void dgsOutstanding_list_FilterStringChanged(object sender, EventArgs e)
        {
            this.dgsBindingOutstanding.Filter = this.dgsOutstanding_list.FilterString;
        }

        private static string StorerkeyCell;
        private static string PortCell;
        private void dgsTaskList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgsTaskList.ReadOnly = true;
            PlankeyCell = dgsTaskList.Rows[e.RowIndex].Cells[0].Value.ToString();
           // StorerkeyCell = dgsTaskList.Rows[e.RowIndex].Cells[1].Value.ToString();
           // PortCell = dgsTaskList.Rows[e.RowIndex].Cells[2].Value.ToString();
            GetMappingSummary();
        }
        private void dgsOutstanding_list_SortStringChanged(object sender, EventArgs e)
        {
            this.dgsBindingOutstanding.Sort = this.dgsOutstanding_list.SortString;
        }
        private void dgsMappingList_details_SortStringChanged(object sender, EventArgs e)
        {
            this.dgsBindingMappinglist_detail.Sort = this.dgsMappingList_details.SortString;
        }
        private void GetMappingSummary()
        {
            try
            {
                ConnLocal.Open();

                SqlCommand cmd = new SqlCommand("select DENSE_RANK() OVER (PARTITION BY taskID ORDER BY a.mappingID  asc ) AS No,TaskID as 'MappingInstruction',a.MappingID,a.SKU,assycode,MIN(cast(cartonID as int)) as StartSerial , Max(cast(cartonID as int)) as EndSerial, max(SNP) as StdPallet, count(distinct(cartonIDstock)) as Ready, Max(SNP) - count(distinct(cartonIDstock)) as Not_Ready,case when Max(SNP) - count(distinct(cartonIDstock)) = 0 then 'Complete' else 'Not Complete'end 'Stock Status',  " +
            "case when Count(distinct(CartonIDcheck))  = Max(SNP) then 'Complete' else cast(Count(distinct(CartonIDcheck))  as varchar)  end 'Scan Mapping status', case when a.TotalMove = Max(SNP) then 'Complete' else cast(a.TotalMove as varchar)  end 'Update Pallet WMS', concat(cast(cast(Count(distinct(CartonIDcheck)) as float) / max(SNP) as decimal(18, 2)) * 100, '%') as Percentage " +
            "from(SELECT b.MappingID, b.SKU, a.Plankey AS TaskID,a.tujuan, f.Totalmove, a.Factory AS storerkey, d.CartonID AS CartonIDStock, d.Loc, d.stdPallet, b.CartonID, e.CartonID AS CartonIDCheck, e.SKU AS SKUCheck, e.Notes, b.Editby,e.editdate AS DateMappingCheck, e.EditWho, d.FromPallet, a.Carmaker, a.AssyNumber, a.SNP, d.Receiptkey, a.AssyCode, d.ToPalletID FROM (SELECT Plankey, Factory, Carmaker,Tujuan ,AssyNumber, AssyCode, SNP  FROM dbo.tbMappingInstruction  " +
            " where  Plankey = @TaskID )  " +
            "AS a inner JOIN(SELECT MappingID, SKU, TASKID, CartonID, Editby  FROM dbo.tbPLBSAMI_FG_tempGenerateLIST  ) AS b ON a.Plankey = b.TASKID AND a.AssyNumber = b.SKU LEFT OUTER JOIN(SELECT FromPallet, CartonID, Loc, stdPallet, ToPalletID, receiptkey, sku FROM tbPLBSAMI_FG_stgMappingStock2) AS d ON b.SKU = d.sku AND d.CartonID = b.CartonID  " +
            "left Outer join(select Storerkey, topalletID, count(cartonID)Totalmove from tbPLBSAMI_FG_stgMappingStock2 group by ToPalletID, Storerkey)  f on b.MappingID = f.ToPalletID and a.Factory = f.Storerkey   " +
            "LEFT OUTER JOIN(SELECT MAX(Editdate) AS editdate, EditWho, SKU, CartonID, PalletID, Notes,QRcontent FROM dbo.TbPLBSAMI_FG_MappingChecking GROUP BY EditWho, SKU, CartonID, PalletID, Notes,QRcontent) AS e ON b.CartonID = e.CartonID AND b.SKU = e.SKU AND e.PalletID = b.MappingID   " +
            "WHERE(ISNULL(b.MappingID, '') <> '')) a   where isnull(a.SKU, '') <> ''  group by a.MappingID, a.storerkey, taskID,tujuan, a.SKU, assycode, TaskID, a.Totalmove having count(distinct(cartonIDstock)) > 0 ", ConnLocal);
                cmd.Parameters.AddWithValue("@TaskID", PlankeyCell.ToString());
               // cmd.Parameters.AddWithValue("@storerkey", StorerkeyCell.ToString());
                //cmd.Parameters.AddWithValue("@tujuan", PortCell.ToString()); 

                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                DA.Fill(dt);
                DgsMappingList.DataSource = dt;
                DgsMappingListBinding.DataSource = dt;
                ConnLocal.Close();
                Btn_generate.Enabled = true;
               
               }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        
        private void GetMappinglistDetails()
        {
            try
            {
                ConnLocal.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = ConnLocal;
                    cmd.CommandText = " select a.STorerkey,a.MappingID,a.SKU,cast(a.CartonID as int) cartonID,b.FromPallet,b.Qty , " +
                        " case when isnull(b.cartonID,'')='' then 'Not Ready' else 'Ready' end Status,c.notes as CekMapping,b.receiptkey as ASN,convert(varchar(120),ReceiptDate) as ReceivedDate,b.LOC from tbPLBSAMI_FG_tempGenerateLIST " +
                        " a left Join PRAPR.dbo.vtbStgStock b on a.CartonID = b.CartonID and a.sku = b.sku" +
                        "  left join  (select palletID,cartonID,SKU , notes  from tbplbsami_fg_mappingChecking group by palletID,cartonID,SKU , notes ) c on a.CartonID = c.CartonID and c.sku = b.sku and a.MappingID = c.PalletID " +
                        " where a.mappingID=@mappingID" +
                        " order by a.cartonid";
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("mappingID", MappingIDCell);
                DataSet DS = new DataSet();
                DA.Fill(DS);
                dgsMappingList_details.DataSource = DS.Tables[0];
                dgsBindingMappinglist_detail.DataSource = DS.Tables[0];
                ConnLocal.Close();
                tabMappingLIST.SelectedTab = tabPage4;

            }
            catch (Exception ex)
            {

            }
        }
        private void GetOutstanding()
        {
            DsWMS.Clear();
            ConnLocal.Open();

            SqlCommand cmd = new SqlCommand("Ouststading_Maping", ConnLocal);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            DA.Fill(DS);
            dgsOutstanding_list.DataSource = DS.Tables[0];
            dgsBindingOutstanding.DataSource = DS.Tables[0];

            dgsOutstanding_list.AutoResizeColumns();
            ConnLocal.Close();
        }
        //get Mapping
        private static string txt_assyCode;
        private static string MappingIDCell;
        private static string txt_SKU;
        private static string txt_StartSerial;
        private static int txt_endSerial;
        private static int txt_SNP;
        private static string txt_CartonID;
        private static string txt_Storerkey;
        private static string txt_Carline;
        private static string txt_mapID;
        private static string txt_MappingID;
        private static string txt_PlanID;
        private static string txt_DestinationCode;

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
            cmd.CommandText = "select Carmaker,Plankey,AssyNumber,a.AssyCode,SNP,StartSerial,case when (EndSerial=0 and isnull(c.cartonID,'')<>'') then c.CartonID else EndSerial end endSerial,Factory,Liner,Freight,a.destinationCode "+
            " from tbMappinginstruction a " +
            "left join tbPLBSAMI_FG_tempGenerateLIST b on a.Plankey = b.TASKID and a.AssyNumber = b.SKU  " +
            " left join(select max(lottable10) as CartonID,SKu from tbPLBSAMI_FG_stgReceiptdetail group by SKU)c on a.AssyNumber = c.sku " +
            " where isnull(b.SKU, '') = '' and EndSerial <> 0  and Plankey=@TaskID" +
            " group by Carmaker,Plankey,AssyNumber,a.AssyCode,SNP,StartSerial,EndSerial,Factory,c.CartonID,Liner,Freight,a.destinationCode";
            SqlDataAdapter DA = new SqlDataAdapter(cmd);

            cmd.Parameters.AddWithValue("@TaskID", txt_taskID.Text.ToString());

            DA.Fill(DsWMS);
            int aLoop = DsWMS.Tables[0].Rows.Count;
            int a = DsWMS.Tables[0].Rows.Count;

            try
            {
                for (int i = 0; i < aLoop; i++)
                {
                    txt_assyCode = DsWMS.Tables[0].Rows[i]["AssyCode"].ToString();
                    string Pallet = DsWMS.Tables[0].Rows[i]["SNP"].ToString();
                    txt_SNP = Convert.ToInt32(Pallet);
                    txt_CartonID = DsWMS.Tables[0].Rows[i]["Startserial"].ToString();
                    string Serial = DsWMS.Tables[0].Rows[i]["EndSerial"].ToString();
                    txt_endSerial = Convert.ToInt32(Serial);
                    txt_SKU = DsWMS.Tables[0].Rows[i]["AssyNumber"].ToString();
                    txt_Storerkey = DsWMS.Tables[0].Rows[i]["Factory"].ToString();
                    txt_Carline = DsWMS.Tables[0].Rows[i]["Carmaker"].ToString();
                    txt_PlanID = DsWMS.Tables[0].Rows[i]["Plankey"].ToString();
                    txt_DestinationCode = DsWMS.Tables[0].Rows[i]["DestinationCode"].ToString();
                }

                insertMappingInstruction();

            }
            catch (Exception ex)
            {

            }
            finally
            {

            }            
        }

        private void insertMappingInstruction()
        {
            
            int x = Convert.ToInt32(txt_CartonID);
            
            this.ProgressBar1.Minimum = x;
            this.ProgressBar1.Maximum = txt_endSerial+1;
            this.ProgressBar1.Value = x;

            for (int i = x; i <=(txt_endSerial); i++)
            {
                this.ProgressBar1.Value = this.ProgressBar1.Value +1;

                txt_CartonID = i.ToString();
                ConnLocal.Close();
                SqlCommand cmd = new SqlCommand("insert into   tbtempMappingList " +
                    " (CartonID,TASKID,SKU,Storerkey,EditDate,EditBy,Carline,AssyCode,StdPallet,DestinationCode,endSerial ) " +
                    " values(@CartonID,@TASKID,@SKU,@Storerkey,@EditDate,@EditBy,@carline,@Assycode,@SNP,@DestinationCode,@endSerial)", ConnLocal);
                cmd.Parameters.Add(new SqlParameter("CartonID", txt_CartonID));
                cmd.Parameters.Add(new SqlParameter("TASKID", txt_PlanID));
                cmd.Parameters.Add(new SqlParameter("SKU", txt_SKU));
                cmd.Parameters.Add(new SqlParameter("Storerkey", txt_Storerkey));
                cmd.Parameters.Add(new SqlParameter("Editdate", Editdate));
                cmd.Parameters.Add(new SqlParameter("EditBy", FormLogin.NIK + " " + FormLogin.UserName));
                cmd.Parameters.Add(new SqlParameter("Carline", txt_Carline));
                cmd.Parameters.Add(new SqlParameter("Assycode", txt_assyCode));
                cmd.Parameters.Add(new SqlParameter("SNP", txt_SNP));
                cmd.Parameters.Add(new SqlParameter("DestinationCode", txt_DestinationCode));
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
            cmd.CommandText = "select a.factory,a.Carmaker,b.TaskID,b.AssyCode,a.AssyNumber,a.SNP,min(cast(b.CartonID as int)) as StartSerial,c.MappingID,a.DestinationCode,max(b.endSerial)as EndSerial from tbMappinginstruction a inner join tbtempMappingList b on a.AssyNumber = b.SKU and  a.Plankey = b.TASKID  left join tbPLBSAMI_FG_tempGenerateLIST c on a.AssyNumber = c.SKu and a.Plankey = c.TASKID and b.cartonID = c.CartonID  " +
                "where isnull(c.MappingID, '') = '' and plankey=@taskID " +
                " group by a.Carmaker,b.TaskID,b.AssyCode,a.AssyNumber,a.SNP,c.MappingID,a.factory,a.DestinationCode   ";
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@TaskID", txt_taskID.Text.ToString());
            DataSet ds = new DataSet();
            ds.Clear();
            DA.Fill(ds);
            int aLoop = DsWMS.Tables[0].Rows.Count;
            int a = ds.Tables[0].Rows.Count;

            try
            {

                for (int i = 0; i < aLoop; i++)
                {
                    string Pallet = ds.Tables[0].Rows[i]["SNP"].ToString();
                    txt_SNP = Convert.ToInt32(Pallet);
                    txt_CartonID = ds.Tables[0].Rows[i]["Startserial"].ToString();
                    txt_SKU = ds.Tables[0].Rows[i]["AssyNumber"].ToString();
                    txt_Storerkey = ds.Tables[0].Rows[i]["Factory"].ToString();
                    txt_Carline = ds.Tables[0].Rows[i]["Carmaker"].ToString();
                    txt_PlanID = ds.Tables[0].Rows[i]["TaskID"].ToString();
                    Endserial = ds.Tables[0].Rows[i]["EndSerial"].ToString();
                    txt_assyCode = ds.Tables[0].Rows[i]["AssyCode"].ToString();
                   
                    txt_DestinationCode = ds.Tables[0].Rows[i]["DestinationCode"].ToString();
                    GenerateMappingID();
                    GenerateMappingList();
                }

            } catch (Exception ex)
            {
                ConnLocal.Close();
            }
        }
        private void GenerateMappingID()
        {
            if (txt_Carline.Contains("HONDA CR-V"))
            {

                ConnLocal.Close();
                SqlCommand cmd = new SqlCommand("select storerkey,max(substring(MappingID,6,6)) as LastMAPID  ,Carline from tbplbsami_FG_tempGeneratelist  where Carline=@Carline and storerkey= @storerkey " +
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



                        DateTime yyyy = DateTime.Now;

                        DateTime datevalue = (Convert.ToDateTime(yyyy.ToString()));
                        String yy = datevalue.Year.ToString().Substring(3, 1);

                        string mapID = txt_mapID;
                        int x = Convert.ToInt32(mapID);
                       
                        string GenerateID()
                        {
                            int lastAddedId = x;
                            string demo = Convert.ToString(lastAddedId + 1).PadLeft(6, '0');
                            return demo;
                        }

     
                        txt_MappingID = "1HND" + yy.ToString()+GenerateID().ToString();
                        
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
            if (txt_Carline.Contains("TOYOTA YNA"))
            {

                ConnLocal.Close();
                SqlCommand cmd = new SqlCommand("select storerkey,max(MappingID) as LastMAPID ,Carline from tbplbsami_FG_tempGeneratelist  where Carline=@Carline and storerkey= @storerkey " +
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

                        string mapID = txt_mapID.Substring(4, 7);
                        int x = Convert.ToInt32(mapID) + 1;
                        txt_MappingID = "4SYT" + x.ToString();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                        txt_MappingID = "4SYT" + "0008001";
                    }
                }
                else
                {

                }

            }
            else
            if (txt_Carline.Contains("MAZDA TAP"))
            {

                ConnLocal.Close();
                SqlCommand cmd = new SqlCommand("select storerkey,max(substring(MappingID,7,5)) as LastMAPID ,Carline from tbplbsami_FG_tempGeneratelist  where Carline=@Carline and storerkey= @storerkey " +
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

                        string mapID = txt_mapID;
                        int x = Convert.ToInt32(mapID);

                        string GenerateID()
                        {
                            int lastAddedId = x;
                            string demo = Convert.ToString(lastAddedId + 1).PadLeft(5, '0');
                            return demo;
                        }


                        txt_MappingID = "1MZD0-" + GenerateID().ToString();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                        txt_MappingID = "1MZD0-" + "04001";
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
                        DateTime yyyy = DateTime.Now ;

                        DateTime datevalue = (Convert.ToDateTime(yyyy.ToString()));
                        String yy = datevalue.Year.ToString().Substring(2,2);

                        string mapID = txt_mapID.Substring(txt_mapID.Length - 6);
                        int x = Convert.ToInt32(mapID);

                        string GenerateID()
                        {
                            int lastAddedId = x;
                            string demo = Convert.ToString(lastAddedId + 1).PadLeft(6, '0');
                            return demo;
                        }

                        if (txt_Storerkey == "PLBSAMTFG")
                        {
                            txt_MappingID = "TS. " + txt_Carline + " - "+yy.ToString() + GenerateID();

                        }
                        else if (txt_Storerkey == "PLBSAMJFG")
                        {
                            txt_MappingID = "JS. " + txt_Carline + " - " + yy.ToString() + GenerateID();
                        }

                    }
                    catch
                    {
                        if (txt_Storerkey == "PLBSAMTFG")
                        {
                            txt_MappingID = "TS. " + txt_Carline + " - " + "20000001";

                        }
                        else
                        {
                            txt_MappingID = "JS. " + txt_Carline + " - " + "20000001";
                        }
                    }
                }
                else
                {
                    if (txt_Storerkey == "PLBSAMTFG")
                    {
                        txt_MappingID = "TS. " + txt_Carline + " - " + "20000001";

                    }
                    else
                    {
                        txt_MappingID = "JS. " + txt_Carline + " - " + "20000001";
                    }

                }
            }
        }       
        private void GenerateMappingList()
        {

            int x = Convert.ToInt32(txt_CartonID);
            this.ProgressBar1.Minimum = x;
            this.ProgressBar1.Maximum = x + txt_SNP;
            this.ProgressBar1.Value = x;
            
            GenerateMappingID();
            int snp=0 ;

            if (Convert.ToInt32(Endserial) <=txt_SNP)
            {
                snp = (Convert.ToInt32(Endserial) % txt_SNP) +1;
            }
            else 
            {
                snp = txt_SNP;
            }



            for (int i = x; i < (x + snp); i++)
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
                cmd.Parameters.Add(new SqlParameter("SKU", txt_SKU));
                cmd.Parameters.Add(new SqlParameter("Storerkey", txt_Storerkey));
                cmd.Parameters.Add(new SqlParameter("Editdate", Editdate));
                cmd.Parameters.Add(new SqlParameter("EditBy", FormLogin.NIK + " " + FormLogin.UserName));
                cmd.Parameters.Add(new SqlParameter("Carline", txt_Carline));
                cmd.Parameters.Add(new SqlParameter("AssyCode", txt_assyCode));
                cmd.Parameters.Add(new SqlParameter("SNP", snp));
                cmd.Parameters.Add(new SqlParameter("DestinationCode", txt_DestinationCode));
                ConnLocal.Open();
                cmd.ExecuteNonQuery();
                ConnLocal.Close(); 
            
            }
            RunMapping();
            GetMapping();
        }
        private void btn_Save_Click(object sender, EventArgs e)
        {
            GetMapping();
        }
        private void BtnNew_Click(object sender, EventArgs e)
        {
          
        }

        private void dgsTaskList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
        }

        private void Btn_generate_Click(object sender, EventArgs e)
        {
            //UpdateStok();
            TaskList();
           // GetOutstanding();
        }

        private void DgsMappingList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MappingIDCell = DgsMappingList.Rows[e.RowIndex].Cells[2].Value.ToString();
            GetMappinglistDetails();
        }

        private void PlaningMapping_Load(object sender, EventArgs e)
        {
            
            GetOutstanding();
        }

        private void btn_createPlan_Click(object sender, EventArgs e)
        {
            
                Add f2 = new Add();
                f2.Show();
            
        }

        private void btn_GetStok_Click(object sender, EventArgs e)
        {

        }
        private void UpdateStok()
        {

            ConnLocal.Close();
            ConnLocal.Open();
            SqlCommand cmd = new SqlCommand("truncate table tbplbsami_fg_stgMappingStock", ConnLocal);
            cmd.ExecuteNonQuery();
            ConnLocal.Close();
    
            DataSet ds;
            Conn.Open();
            SqlDataAdapter DA = new SqlDataAdapter("select  b.RECEIPTKEY ,a.LOT,a.SKU, b.ALTSKU as FromPallet,b.LOTTABLE10 as CartonID,a.QTY,a.STORERKEY,1 as StdPallet,b.STATUS, 'NN' carmaker, a.loc, d.locationflag, a.id as ToPalletID, b.datereceived,b.LOTTABLE09 from LOTXLOCXID a join RECEIPTDETAIL b on a.lot = b.TOLOT inner join loc d on a.loc = d.LOC where a.STORERKEY like'%PLBS%' and d.loc <> 'Damage' and a.qty > 0 order by b.LOTTABLE10, a.SKU", Conn);
            ds = new DataSet();
            DA.Fill(ds);
            Conn.Close();
            ConnLocal.Open();
            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(ConnLocal))
            {
                bulkCopy.DestinationTableName =
                    "tbplbsami_fg_stgMappingStock";
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

        private void btn_updateStock_Click(object sender, EventArgs e)
        {
            UpdateStok();
        }

        private void btn_Remaping_Click(object sender, EventArgs e)
        {
            frmRemapping f2 = new frmRemapping();
            f2.Show();
        }
        private void btn_editMapping_Click(object sender, EventArgs e)
        {
            FrmMappingList f2 = new FrmMappingList();
            f2.Show();
        }
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgressBar1.Value = e.ProgressPercentage;
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            MessageBox.Show(@"Finished");
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            GetMappingSummary();
        }

        private void GetMapping_DirectedWMS()
        {

        }

        private void DgsMappingList_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
