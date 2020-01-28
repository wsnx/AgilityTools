using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using ZXing.Common;
using ZXing;
using ZXing.QrCode;
using System.Data.SqlClient;
using System.Threading;
using System.IO;
using System.Drawing.Imaging;
using CrystalDecisions.Shared;
using System.Diagnostics;

namespace AgilityTools
{
    public partial class PalletUpdater : UserControl
    {
        SqlConnection ConnWMS = new SqlConnection(ConfigDB.conWMS);
        SqlConnection ConnLocal = new SqlConnection(ConfigDB.DBlocal);
        DataSet DsWMS = new DataSet();
        private DataTable DtWMS = new DataTable();
        private static string key = "1";
        private static string SKU;

        public PalletUpdater()
        {
            InitializeComponent();
        }


        private void btnSubmit_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            this.dgsList.DataSource = null;
            dgsList.Rows.Clear();
            dgsList.Refresh();
            txt_status.Text = "";
            txt_QtySNP.Text = "";
            txt_SKU.Text = "";
            txt_SOH.Text = "";
            txt_HasilScan.Text = "";
            txt_QtyMapping.Text = "";
            txt_mapp.Text = txt_MappingID.Text;
            UpdateStok();
            CreateData();
            ShowDisplay();
            tabControl1.SelectedTab = tabPage1;

            //            FromMove();
        }
        private void ShowDisplay()
        {

            try
            {
                ConnLocal.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = ConnLocal;
                cmd.CommandText = " select TaskID,a.MappingID,a.SKU,assycode,cast(MIN(cast(cartonID as int)) as varchar)as StartSerial   " +
                        ", Max(cast(cartonID as int)) as EndSerial, cast(max(SNP) as varchar) as StdPallet, cast(count(distinct(cartonIDstock))as varchar )as Ready,cast(a.TotalMove as varchar) as stok, cast(Count(distinct(CartonIDcheck)) as varchar)as Cek, " +
                        "Max(SNP) - count(distinct(cartonIDstock)) as Not_Ready,case when Max(SNP) - count(distinct(cartonIDstock)) = 0 then 'Complete' else 'Not Complete'end Status, " +
                        "Count(distinct(CartonIDcheck)) as 'Cek Hasil Mapping', " +
                        "case when a.TotalMove = Max(SNP) then 'Completed' " +
                        " when a.TotalMove > Max(SNP) then 'Proses Move melebihi jumlah SNP , revisi LPN di WMS ya' " +
                        " when Count(distinct(CartonIDStock))-Count(distinct(CartonIDcheck))<>0 then 'Not Completed' " +
                        " else 'Belum Update Pallet ' end 'Update Pallet WMS', " +
                        "concat(cast(cast(Count(distinct(CartonIDcheck)) as float) / max(SNP) as decimal(18, 2)) * 100, '%') as Percentage from(SELECT b.MappingID, AssyNumber as SKU, a.Plankey AS TaskID, f.Totalmove, a.Factory AS storerkey, d.CartonID AS CartonIDStock, d.Loc, d.stdPallet, b.CartonID, e.CartonID AS CartonIDCheck, e.SKU AS SKUCheck, e.Notes, b.Editby, " +
                        "e.editdate AS DateMappingCheck, e.EditWho, d.FromPallet, a.Carmaker, a.AssyNumber, a.SNP, d.Receiptkey, a.AssyCode, d.ToPalletID FROM(SELECT Plankey, Factory, Carmaker, AssyNumber, AssyCode, SNP  FROM dbo.tbMappingInstruction) AS a LEFT OUTER JOIN(SELECT MappingID, SKU, TASKID, CartonID, Editby " +
                        " FROM dbo.tbPLBSAMI_FG_tempGenerateLIST where MappingID = @TaskID) AS b ON a.Plankey = b.TASKID AND a.AssyNumber = b.SKU LEFT OUTER JOIN(SELECT FromPallet, CartonID, Loc, stdPallet, ToPalletID, receiptkey, sku FROM dbo.tbPLBSAMI_FG_stgMappingStock2) AS d ON b.SKU = d.sku AND d.CartonID = b.CartonID " +
                        " left Outer join(select Storerkey, topalletID, count(cartonID)Totalmove from tbPLBSAMI_FG_stgMappingStock2 group by ToPalletID, Storerkey)  f on b.MappingID = f.ToPalletID and a.Factory = f.Storerkey " +
                        " LEFT OUTER JOIN(SELECT MAX(Editdate) AS editdate, EditWho, SKU, CartonID, PalletID, Notes FROM dbo.TbPLBSAMI_FG_MappingChecking GROUP BY EditWho, SKU, CartonID, PalletID, Notes) AS e ON b.CartonID = e.CartonID AND b.SKU = e.SKU AND e.PalletID = b.MappingID " +
                        "WHERE(ISNULL(b.MappingID, '') <> '')) a   where isnull(a.SKU, '') <> '' group by a.MappingID, a.storerkey, taskID, a.SKU, assycode, TaskID, a.Totalmove having count(distinct(cartonIDstock)) > 0 ";
                cmd.Parameters.AddWithValue("TaskID", txt_MappingID.Text);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    txt_status.Text = reader.GetString(13);
                    txt_HasilScan.Text = reader.GetString(9);
                    txt_SOH.Text = reader.GetString(8);
                    txt_SKU.Text = reader.GetString(2);
                    txt_QtyMapping.Text = reader.GetString(7);
                    txt_QtySNP.Text = reader.GetString(6);
                }

                ConnLocal.Close();
            }
            catch (Exception ex)
            {

            }
        }
        private string txt_SKU2;
        private void GetSKU()
        {


            string a;
            ConnLocal.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConnLocal;
            cmd.CommandText = "select SKU from tbplbsami_fg_tempGenerateList where mappingID=@mappingID";
            cmd.Parameters.AddWithValue("mappingID", txt_MappingID);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                txt_SKU.Text = reader.GetString(0);

            }

            ConnLocal.Close();
        }

        private void OutstandingList()
        {

        }

        private void UpdateStok()
        {


            ConnLocal.Close();
            ConnLocal.Open();
            SqlCommand cmd = new SqlCommand("truncate table tbPLBSAMI_FG_stgMappingStock2", ConnLocal);
            cmd.ExecuteNonQuery();
            ConnLocal.Close();

            DataSet ds;
            ConnWMS.Open();
            SqlDataAdapter DA = new SqlDataAdapter("" +
                "select '' RECEIPTKEY ,a.LOT,a.SKU, a.id as FromPallet,b.LOTTABLE10 as CartonID,a.QTY,a.STORERKEY,1 as StdPallet,'' STATUS, 'NN' carmaker, a.loc, '' locationflag, a.id as ToPalletID,'' datereceived,b.lottable09,notes NOTE from (select sku,lot,qty,storerkey, loc,id  from  LOTXLOCXID where  qty > 0 and qtypicked=0 and sku not like '%SS11%') a  inner join (select tolot,lottable10,lottable09,notes from receiptdetail) b on a.lot = b.tolot where (a.STORERKEY ='PLBSAMTFG' or a.STORERKEY ='PLBSAMJFG')   and a.SKu not like 'PT%' and a.SKU not like 'CT%' order by b.LOTTABLE10, a.SKU" +
                "" +
                "", ConnWMS);
            ds = new DataSet();
            DA.Fill(ds);
            ConnWMS.Close();

            ConnLocal.Open();
            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(ConnLocal))
            {
                bulkCopy.DestinationTableName =
                    "tbPLBSAMI_FG_stgMappingStock2";
                try
                {
                    bulkCopy.WriteToServer(ds.Tables[0]);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            ConnLocal.Close();
        }
        private void CreateData()
        {

            ConnLocal.Close();
            SqlCommand cmd2 = new SqlCommand();
            ConnLocal.Open();
            cmd2.Connection = ConnLocal;
            cmd2.CommandText = ("truncate table tbPLBSAMI_FG_PrintMappingList");
            cmd2.ExecuteNonQuery();
            ConnLocal.Close();
            try
            {

                ConnWMS.Open();
                DsWMS.Clear();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = ConnLocal;
                cmd.CommandText = ("select  a.MappingID,a.TASKID,a.CartonID,a.SKU,CONCAT(b.STORERKEY,'\r\n',b.LOC,'\r\n',b.ToPalletID,'\r\n',b.SKU,'\r\n',b.LOT,'\r\n',b.qty,'\r\n','SET','\r\n','\r\n','\r\n',case when a.storerkey='PLBSAMJFG' then 'STGFGINJ02' else 'STGFGINT14' end ,'\r\n',a.mappingID)as QRconfig  from tbPLBSAMI_FG_tempGenerateLIST a inner join tbPLBSAMI_FG_stgMappingStock2 b   on a.CartonID = b.CartonID and a.sku = b.sku  and a.Storerkey = b.STorerkey and SUBSTRING(b.LOTTABLE09,0,charindex('~',b.lottable09)) = a.AssyCode and replace(SUBSTRING(Lottable09,charindex('~',Lottable09),len(Lottable09)+1),'~','')= a.destinationCode inner join TbPLBSAMI_FG_MappingChecking c on a.sku = b.sku and a.MappingID = c.PalletID and a.CartonID = c.CartonID and c.QRcontent= REPLACE(b.Qrcontent,'|',',')  where a.mappingID=@mappingID and ToPalletID " +
                    " !=@mappingID order by MappingID,CartonID");
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("MappingID", txt_MappingID.Text);
                DA.Fill(DsWMS);
                ConnWMS.Close();
                if (DsWMS.Tables[0].Rows.Count > 0)
                {
                    Insert();
                }
                else
                {

                    return;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void Insert()
        {
            QrCodeEncodingOptions options = new QrCodeEncodingOptions
            {
                DisableECI = true,
                CharacterSet = "UTF-8",
                Width = 120,
                Height = 120,
            };

            var qr = new ZXing.BarcodeWriter();
            qr.Options = options;
            qr.Format = ZXing.BarcodeFormat.QR_CODE;
            string strData;

            this.progressBar.Minimum = 0;
            this.progressBar.Maximum = DsWMS.Tables[0].Rows.Count + 1;
            this.progressBar.Value = 0;

            int a = DsWMS.Tables[0].Rows.Count - 1;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConnLocal;
            ConnLocal.Open();
            cmd.CommandText = "INSERT INTO tbPLBSAMI_FG_PrintMappingList (TaskID,MappingID,SKU,CartonID,QRimage,QRConfig) " +
                "values(@taskID,@mappingID,@SKU,@CartonID,@QRimage,@QRconfig)";

            for (int i = 0; i <= a; i++)
            {

                this.progressBar.Value = this.progressBar.Value + 1;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("TaskID", DsWMS.Tables[0].Rows[i]["TaskID"]);
                cmd.Parameters.AddWithValue("MappingID", DsWMS.Tables[0].Rows[i]["MappingID"]);
                cmd.Parameters.AddWithValue("SKU", DsWMS.Tables[0].Rows[i]["SKU"]);
                cmd.Parameters.AddWithValue("CartonID", DsWMS.Tables[0].Rows[i]["CartonID"]);
                cmd.Parameters.AddWithValue("QRconfig", DsWMS.Tables[0].Rows[i]["QRconfig"]);
                strData = DsWMS.Tables[0].Rows[i]["QRconfig"].ToString();
                Bitmap Result = new Bitmap(qr.Write(strData));
                Byte[] data;
                using (var memoryStream = new MemoryStream())
                {
                    Result.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Bmp);
                    data = memoryStream.ToArray();
                }
                cmd.Parameters.AddWithValue("@QRimage", data);
                try
                {
                    cmd.ExecuteNonQuery();
                    ShowGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            ConnLocal.Close();
        }
        private void ShowGrid()
        {

            //FromMove

            dgsList.ClearSelection();

            try
            {
                ConnLocal.Close();
                ConnLocal.Open();

                SqlDataAdapter DA = new SqlDataAdapter(" select DENSE_RANK() OVER (PARTITION BY mappingID ORDER BY cartonID asc ) AS No,case when cartonID%2=0 then QRimage else null end QR,CartonID,case when cartonID%2<>0 then QRimage else null end QR,MappingID  from tbPLBSAMI_FG_PrintMappingList  group by Qrimage,CartonID,MappingID  order by CartonID ", ConnLocal);
                DataSet DS = new DataSet();
                DS.Clear();
                DA.Fill(DS);
                dgsList.DataSource = DS.Tables[0];
                DataGridViewColumn column1 = dgsList.Columns[0];
                DataGridViewColumn column2 = dgsList.Columns[1];
                DataGridViewColumn column3 = dgsList.Columns[2];
                DataGridViewColumn column4 = dgsList.Columns[3];
                DataGridViewColumn column5 = dgsList.Columns[4];
                column1.Width = 50;
                column2.Width = 150;
                column3.Width = 200;
                column4.Width = 150;
                column5.Width = 200;

            }
            catch (Exception ex)
            {

            }
        }


        //New Concept
        private static string txt_SKU3;
        private static string txt_Lottable09;
        private static string txt_ID;

        private void GetLocalData()
        {
            string a;
            ConnLocal.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConnLocal;
            cmd.CommandText =
                "declare @result varchar(500)  " +
"declare @mappingID varchar(50) " +
"set @mappingID='"+ txt_MappingID2.Text+"' " +
"select @result = coalesce(@result+''',''','')+b.CartonID from tbplbsami_fg_tempgeneratelist a  " +
"inner join tbplbsami_fg_MappingChecking b on a.sku = b.sku and a.cartonid= b.cartonid and a.mappingid = b.palletID  " +
"where mappingID=@mappingID " +
"select top 1 a.SKU,concat(Assycode,'~',DestinationCOde)as Lottable09,@result as Hasil from tbplbsami_fg_tempgeneratelist a inner join tbplbsami_fg_MappingChecking b on a.sku = b.sku and a.cartonid= b.cartonid and a.mappingid = b.palletID  " +
"where mappingID=@mappingID ";

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                txt_SKU3 = reader.GetString(0);
                txt_Lottable09 = reader.GetString(1);
                txt_ID = reader.GetString(2);


            }

            ConnLocal.Close();
        }


        private void GetQR()
        {

            ConnWMS.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConnWMS;
            cmd.CommandText = (            
            "declare @mappingid varchar(50) " +
            "set @mappingid='"+ txt_MappingID2.Text+"' " +
            "select b.sku,b.qty,b.id,a.lottable09 as AssyCode,a.lottable10 as CartonID,@mappingid as MappingID ," +
            "case when (ROW_NUMBER()over (order by a.lottable10))%2=0 then " +
            "CONCAT(b.STORERKEY,'\r\n',b.LOC,'\r\n',b.ID,'\r\n',b.SKU,'\r\n',b.LOT,'\r\n',b.qty,'\r\n','SET','\r\n','\r\n','\r\n', " +
            "case when a.storerkey='PLBSAMJFG' then 'STGFGINJ02' else 'STGFGINT14' end ,'\r\n',@mappingid,'\r\n') else 'null' end QR_left, " +
            "case when (ROW_NUMBER()over (order by a.lottable10))%2!=0 then " +
            "CONCAT(b.STORERKEY,'\r\n',b.LOC,'\r\n',b.ID,'\r\n',b.SKU,'\r\n',b.LOT,'\r\n',b.qty,'\r\n','SET','\r\n','\r\n','\r\n', " +
            "case when a.storerkey='PLBSAMJFG' then 'STGFGINJ02' else 'STGFGINT14' end ,'\r\n',@mappingid,'\r\n') else 'null' end QR_Right " +
            "from lotxlocxid b inner join lotattribute a on  a.lot = b.lot  " +
            "where qty>0 and a.sku='"+txt_SKU3+"' and a.lottable10 in( '"+txt_ID+"') and b.ID not like @mappingid "
                );
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DgsListMoveNew.Rows.Clear();
            DataTable dt = new DataTable();
            DA.Fill(dt);
            QrCodeEncodingOptions options = new QrCodeEncodingOptions
            {
                DisableECI = true,
                CharacterSet = "UTF-8",
                Width = 100,
                Height = 100,
            };

            var qr = new ZXing.BarcodeWriter();
            qr.Options = options;
            qr.Format = ZXing.BarcodeFormat.QR_CODE;

            string strData_Left;
            string strData_right;
            foreach (DataRow Item in dt.Rows)
            {
                int n = DgsListMoveNew.Rows.Add();
                DgsListMoveNew.Rows[n].Cells[1].Value = Item["sku"].ToString();
                DgsListMoveNew.Rows[n].Cells[2].Value = Item["AssyCode"].ToString();
                DgsListMoveNew.Rows[n].Cells[4].Value = Item["CartonID"].ToString();
                DgsListMoveNew.Rows[n].Cells[0].Value = Item["MappingID"].ToString();
                strData_Left = Item["QR_left"].ToString();
                Bitmap Result = new Bitmap(qr.Write(strData_Left));
                Byte[] data;
                using (var memoryStream = new MemoryStream())
                {
                    Result.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Bmp);
                    data = memoryStream.ToArray();
                }

                strData_right = Item["QR_right"].ToString();
                Bitmap Resulta = new Bitmap(qr.Write(strData_right));
                Byte[] dataa;
                using (var memoryStream = new MemoryStream())
                {
                    Resulta.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Bmp);
                    dataa = memoryStream.ToArray();
                }

                if (Item["QR_right"].ToString()=="null")
                {
                    DgsListMoveNew.Rows[n].Cells[5].Value = null;
                }
                else
                {
                    DgsListMoveNew.Rows[n].Cells[5].Value = dataa;
                }

                if (Item["QR_left"].ToString() == "null")
                {
                    DgsListMoveNew.Rows[n].Cells[3].Value = null;
                }
                else
                {
                    DgsListMoveNew.Rows[n].Cells[3].Value = data;
                }

            }
            ConnWMS.Close();

        }



        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void PalletUpdater_Load(object sender, EventArgs e)
        {

        }

        private void dgsList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txt_Help_Click(object sender, EventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo("http://10.130.36.11/tutorial/How-To-Print-MappingList.pdf");
            Process.Start(sInfo);
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            showDataComplete();
        }
        private void showDataComplete()
        {
            SqlCommand cmd = new SqlCommand("PalletUpdatercompleted", ConnLocal);
            try
            {


                cmd.ExecuteNonQuery();
                ConnLocal.Close();
            }
            catch
            {

            }
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            DS.Clear();
            DA.Fill(DS);
            DgsComplete.DataSource = DS.Tables[0];

            ConnLocal.Close();
        }

        private void dgsList_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ShowNOtCompleted();
        }
        private void ShowNOtCompleted(){

            ConnLocal.Open();

            SqlCommand cmd = new SqlCommand("PalletUpdaterNotcompleted", ConnLocal);
            try
            {


                cmd.ExecuteNonQuery();
                ConnLocal.Close();
            }
            catch
            {

            }
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            DS.Clear();
            DA.Fill(DS);
            dgsNotCompleted.DataSource = DS.Tables[0];
            ConnLocal.Close();
        }
        private void btn_excel_refresh_Click(object sender, EventArgs e)
        {

        }
        private void CreateDataExcell()
        {


            ConnLocal.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConnLocal;
            cmd.CommandText = ("select b.STORERKEY,b.LOC,isnull(b.ToPalletID, '') as ToPalletID ,cast(b.SKU as varchar) as SKU,b.LOT, cast(b.qty as varchar) as Qty,'SET' 'Uom','' 'Enter1','' 'Enter2', " + 
                " case when a.storerkey='PLBSAMJFG' then 'STGFGINJ02' else 'STGFGINT14' end Toloc ,a.mappingID  from tbPLBSAMI_FG_tempGenerateLIST a inner join tbPLBSAMI_FG_stgMappingStock2 b   on a.CartonID = b.CartonID and a.sku = b.sku  and a.Storerkey = b.STorerkey and SUBSTRING(b.LOTTABLE09,0,charindex('~',b.lottable09)) = a.AssyCode and replace(SUBSTRING(Lottable09,charindex('~',Lottable09),len(Lottable09)+1),'~','')= a.destinationCode inner join TbPLBSAMI_FG_MappingChecking c on a.sku = b.sku and a.MappingID = c.PalletID and a.CartonID = c.CartonID and c.QRcontent= REPLACE(b.Qrcontent,'|',',')   " +
                " where a.TaskID=@MappingID and b.topalletID != a.mappingID ");
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("MappingID", txt_taskID.Text);

            DataSet ds = new DataSet();
            DA.Fill(ds);
            dgsMoveExcel.DataSource = ds.Tables[0];


        }
        private static string MappingCell;
        private void DgsComplete_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //MappingCell = DgsComplete.Rows[e.RowIndex].Cells[1].Value.ToString();
            //CreateDataExcell();
        }

        private void dgsMoveExcel_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_MoveByExcel_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            UpdateStok();
            CreateDataExcell();

        }

        private void DgsListMoveNew_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Btn_Submit_Click(object sender, EventArgs e)
        {
            txt_Lottable09 = "";
            txt_ID = "";
            Cursor.Current = Cursors.WaitCursor;
            GetLocalData();
            GetQR();
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
