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
using System.Globalization;

namespace AgilityTools
{
    public partial class OrderHome : UserControl
    {
        SqlConnection ConnWMS = new SqlConnection(ConfigDB.conWMS);
        SqlConnection ConnLocal = new SqlConnection(ConfigDB.DBlocal);
        SqlConnection ConnLocal_IT = new SqlConnection(ConfigDB.DBlocal_IT);
        DataSet dsWMS = new DataSet();
        private static string hasil;
        private static string OrderkeyCell;

        public OrderHome()
        {
            InitializeComponent();
        }
        private void GetSumOrder()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                //WMS

                ConnWMS.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = ConnWMS;

                cmd.CommandText = (
                    "select (isnull((PROMISEDSHIPDATE),'1900-01-01')) AS 'CloseCargo', (isnull((SCHEDULEDSHIPDATE),'1900-01-01')) 'CloseDocument'  " +
" ,a.Dispatch,a.PRIORITY,a.SUSR2 as Carmaker,a.ORDERDATE as Orderdate,case when a.STORERKEY='plbsamJFG' then 'JEPARA' else 'TUGU' end StorerKey,a.C_CITY as Destination,a.ORDERKEY,a.EXTERNORDERKEY,   " +
"  DELIVERYDATE as 'ETD_PLB',  a.TrailerNumber,cast(a.TOTALORDERLINES as varchar) as JumlahOrder,cast(b.JumlahCarton as varchar) as JumlahStock,cast(a.TOTALORDERLINES - JumlahCarton as varchar) as Outstanding, cast(d.JumlahPallet as varchar) as JumlahPallet,cast(JumlahLineDR as varchar)as JumlahLineDR,c.DESCRIPTION as Status ,  " +
" concat(cast(cast(isnull(b.JumlahCarton,0) as float)/cast(a.TOTALORDERLINES as float)*100 as decimal(10,2)),'%') 'Percentage' from   " +
" (select PROMISEDSHIPDATE,SCHEDULEDSHIPDATE,case when bolprinted ='0' then '-' when bolprinted ='1'  then 'OK' else '-' end Dispatch    " +
" ,orderdate,susr2,STORERKEY,DELIVERYDATE,TrailerNumber,TOTALORDERLINES,C_CITY,ORDERKEY,STATUS,PRIORITY,EXTERNORDERKEY from ORDERS)a   " +
" left join (select a.orderkey,count(b.LOTTABLE10) as JumlahCarton,count(distinct(a.susr1))as JumlahLineDR from orderdetail a inner join (Select a.sku , b.LOTTABLE10,b.LOTTABLE09 from LOTXLOCXID a   " +
" inner join lotattribute b on a.lot = b.lot where qty> 0  group by a.sku , b.LOTTABLE10,b.LOTTABLE09)b on a.SKU = b.sku and a.lottable10 = b.LOTTABLE10  and a.lottable09 = b.lottable09  " +
" group by ORDERKEY)b on a.orderkey = b.ORDERKEY left join(select orderkey, count(distinct(ID)) JumlahPallet from PICKDETAIL group by ORDERKEY) d on a.ORDERKEY = d.ORDERKEY   " +
" inner join ORDERSTATUSSETUP c on a.status = c.CODE where status<95 and a.storerkey ='"+txt_Storerkey.Text+"' "

                    );

                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                DA.Fill(ds);
                DataTable Orders = ds.Tables[0];
                ConnWMS.Close();
                //Local
                ConnLocal.Open();
                cmd.Connection = ConnLocal;
                cmd.CommandText = "select a.Orderkey,cast(sum(cartonID) as varchar) JumlahCek,Convert(varchar, MAx(a.Editdate), 120) as Editdate, " +
                    " case when isnull(b.PalletID,'')= '' then '0' else cast(b.PalletID as varchar) end JumlahLoaded " +
                    " from(select Max(editdate)editdate, Orderkey, count(distinct(QRcontent)) as CartonID, SKU " +
                    " from tbPLBSAMI_FG_PickingCheck where QRcontent not like 'Empty%' group by orderkey, sku) a left join " +
                    "  (select count(distinct(palletID)) as PalletID, orderkey from tbPLBSAMI_FG_shipmentLoadingCheck group by orderkey)b " +
                    " on a.orderkey = b.Orderkey where a.sku not like '%EMPTY%' group by a.Orderkey,b.PalletID";

                SqlDataAdapter DALocal = new SqlDataAdapter(cmd);
                DataSet dsLocal = new DataSet();
                DALocal.Fill(dsLocal);
                DataTable OrdersLocal = dsLocal.Tables[0];
                ConnLocal.Close();

                //Local_IT
                ConnLocal_IT.Open();
                cmd.Connection = ConnLocal_IT;
                cmd.CommandText = "select Orderkey,ExternOrderKey,Storerkey, " +
                " cast(TotalBoxScan as varchar) as PickingCheck_IT,cast(totalPalletScanLoad as varchar) as LoadingCheck_PLT,cast(TotalboxScanLoad as varchar)as LoadingCheck_Ctn from RF_FG_CheckerMonitoring  ";
                SqlDataAdapter DALocal_IT = new SqlDataAdapter(cmd);
                DataSet dsLocal_IT = new DataSet();
                DALocal.Fill(dsLocal_IT);
                DataTable OrdersLocal_IT = dsLocal_IT.Tables[0];
                ConnLocal_IT.Close();

                //Joining
                DataTable dtResult = new DataTable();
                dtResult.Columns.Add("Storerkey", typeof(string)); //1
                dtResult.Columns.Add("Orderkey", typeof(string)); //2
                dtResult.Columns.Add("Destination", typeof(string)); //3
                dtResult.Columns.Add("Externorderkey", typeof(string)); //4
                dtResult.Columns.Add("Carmaker", typeof(string)); //5
                dtResult.Columns.Add("ETD_PLB", typeof(string));//6
                dtResult.Columns.Add("Trailer Number", typeof(string));//9
                dtResult.Columns.Add("Jumlah Order", typeof(string));//10
                dtResult.Columns.Add("Jumlah Stock", typeof(string));//11
                dtResult.Columns.Add("OutStanding", typeof(string));//12
                dtResult.Columns.Add("Percentage", typeof(string));//13
                dtResult.Columns.Add("Jumlah Line DR [SUSR1]", typeof(string));//14
                dtResult.Columns.Add("Jumlah Pallet [LPN]", typeof(string));//14
                dtResult.Columns.Add("Picking Checking", typeof(string));//15
                dtResult.Columns.Add("Loading Cheking", typeof(string));//16

                dtResult.Columns.Add("Picking Check_IT", typeof(string));//17
                dtResult.Columns.Add("Loading Check_PLT", typeof(string));//17
                dtResult.Columns.Add("Loading Check_Ctn", typeof(string));//17
                dtResult.Columns.Add("Status", typeof(string));//18
                dtResult.Columns.Add("Dispatch", typeof(string));//19
                dtResult.Columns.Add("Priority", typeof(string));//20

                IEnumerable<DataRow> query =
                from Wms in Orders.AsEnumerable()
                join Locals in OrdersLocal.AsEnumerable() on Wms.Field<string>("Orderkey") equals
                 Locals.Field<string>("Orderkey")
                                into cek
                from r in cek.DefaultIfEmpty()
                
                join Locals_IT in OrdersLocal_IT.AsEnumerable() on Wms.Field<string>("Orderkey") equals
                Locals_IT.Field<string>("Orderkey") 

               into Cek_IT
                from r_IT in Cek_IT.DefaultIfEmpty()

                select dtResult.LoadDataRow(new object[]{
                    Wms.Field<string>("Storerkey")   , //1
                    Wms.Field<string>("Orderkey")   , //2
                    Wms.Field<string>("Destination")   , //3
                    Wms.Field<string>("Externorderkey")   , //4
                    Wms.Field<string>("Carmaker")   , //5
                    Wms.Field<DateTime>("ETD_PLB")   , //6
      //              Wms.Field<DateTime>("CloseDocument")   ,//7
      //              Wms.Field<DateTime>("CloseCargo")   ,//8
                    Wms.Field<string>("TrailerNumber")   ,//9
                    Wms.Field<string>("JumlahOrder")   ,//10
                    Wms.Field<string>("JumlahStock") ,//11
                    Wms.Field<string>("Outstanding"),//12
                    Wms.Field<string>("Percentage"),//13
                      Wms.Field<string>("JumlahLineDR"),//14
                    Wms.Field<string>("JumlahPallet"),//14

                    r==null?" ":Wms.Field<string>("JumlahOrder")==r.Field<string>("Jumlahcek")
                    ?"Sesuai":r.Field<string>("Jumlahcek"), //15
                    r==null?" ":Wms.Field<string>("JumlahPallet")==r.Field<string>("JumlahLoaded")
                    ?"Sesuai":r.Field<string>("JumlahLoaded"),//16
                   
                    r_IT==null?" ":Wms.Field<string>("JumlahOrder")==r_IT.Field<string>("PickingCheck_IT")
                    ?"Sesuai":r_IT.Field<string>("PickingCheck_IT"),//17
                    r_IT==null?" ":Wms.Field<string>("JumlahPallet")==r_IT.Field<string>("LoadingCheck_PLT")
                    ?"Sesuai":r_IT.Field<string>("LoadingCheck_PLT"),
                    r_IT==null?" ":Wms.Field<string>("JumlahOrder")==r_IT.Field<string>("LoadingCheck_Ctn")
                    ?"Sesuai":r_IT.Field<string>("LoadingCheck_Ctn"),

                    Wms.Field<string>("Status"),//18
                    Wms.Field<string>("Dispatch"),//19
                    Wms.Field<string>("Priority")//20\
                 }, false);
                // Show in Grid
                DataTable boundTable = query.CopyToDataTable<DataRow>();
                dgsOrderList.DataSource = boundTable;
                dgsOrderSUM_Binding.DataSource = boundTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void GetOrderDetail()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                //WMS
                ConnWMS.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = ConnWMS;
                cmd.CommandText = (
                    "declare @order varchar(50)" +
                    " set @order= '"+ OrderkeyCell + "' " +
                    "select b.Notes as ID, b.ORDERKEY, b.sku, b.LOTTABLE09 AssyCode,b.LOTTABLE10 as CartonID, b.id as PalletID , case when isnull(b.Stock,'')='' then 'Not Available' else 'Available' end Stock ,Receiptkey, PalletASN,  " +
"case when ReceiptStatus ='11' then 'Closed' when  ReceiptStatus ='9' then 'Received'  " +
" when  ReceiptStatus ='0' then 'NEW' else ReceiptStatus end ReceiptStatus ,StatusWMS as OrderStatus,cast(b.QTY as int) QTY ,cast(SOH as varchar) QtySOH " +
"from (select e.description as StatusWMS,orderkey,a.sku,a.lottable10,a.lottable09,b.lot,a.status,b.lot as Stock,c.status as Receiptstatus,replace(c.notes,'|',',')as notes,c.receiptkey,d.ID,c.ALTSKU as PalletASN,cast(a.OpenQty as int) as QTY,cast(d.qty as int) as SOH from orderdetail a   " +
"left join lotattribute b on a.sku = b.sku and a.lottable09 = b.lottable09 and a.lottable10 = b.lottable10   " +
"left join (select lot,sku,id,qty from lotxlocxid where qty>0)d on b.lot = d.lot   " +
"left join receiptdetail c on a.sku = c.sku and a.lottable10 = c.lottable10 and a.lottable09= c.lottable09   " +
"inner join orderstatussetup e on a.status = e.code  " +
"where ORDERKEY =@order  )b "
                    );
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("Orderkey", OrderkeyCell);
                DataSet ds = new DataSet();
                DA.Fill(ds);
                DataTable Orders = ds.Tables[0];
                ConnWMS.Close();

                //Local
                ConnLocal.Open();
                cmd.Connection = ConnLocal;
                cmd.CommandText = "select rtrim(a.Qrcontent) as ID,SKU,a.Orderkey,a.Notes,CartonID,a.PalletID,Convert( varchar,MAx(a.Editdate),120)as SelesaiPicking ,Max(a.Editwho) UserName, Convert( varchar,MAx(b.Editdate),120) as JamMuat,Max(b.Editwho) as Checker from tbPLBSAMI_FG_PickingCheck a left join tbPLBSAMI_FG_shipmentLoadingCheck b on a.orderkey = b.Orderkey and a.palletID = b.PalletID " +
                    " where a.orderkey = @Orderkey2 " +
                    " group by a.Orderkey,a.Notes,CartonID,a.PalletID,SKU ,a.Qrcontent";

                SqlDataAdapter DALocal = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("Orderkey2", OrderkeyCell);
                DataSet dsLocal = new DataSet();
                DALocal.Fill(dsLocal);
                DataTable OrdersLocal = dsLocal.Tables[0];  
                ConnLocal.Close();

                ConnLocal_IT.Open();
                cmd.Connection = ConnLocal_IT;
                cmd.CommandText = "select QR as ID,UserID,Convert( varchar,MAx(LastUpdated),120) as JamPick,OrderKey,l_UserID,TrailerNumber,Convert( varchar,MAx(L_LastUpdated),120) as JamLoad   from [dbo].[RF_FG_PickedChecking] " +
                    "where orderkey=@Orderkey3 group by OrderKey,QR,UserID,l_UserID,TrailerNumber";

                SqlDataAdapter DALocalIT = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("Orderkey3", OrderkeyCell);
                DataSet dsLocalIT = new DataSet();
                DALocal.Fill(dsLocalIT);
                DataTable OrdersLocal_IT = dsLocalIT.Tables[0];
                ConnLocal_IT.Close();


                //Joining
                DataTable dtResult = new DataTable();
                dtResult.Columns.Add("Orderkey", typeof(string));
                dtResult.Columns.Add("SKU", typeof(string));
                dtResult.Columns.Add("AssyCode", typeof(string));
                dtResult.Columns.Add("CartonID", typeof(string));
                dtResult.Columns.Add("QTY Order", typeof(int));
                dtResult.Columns.Add("QTY SOH", typeof(string));
                dtResult.Columns.Add("PalletID [LPN]", typeof(string));
                dtResult.Columns.Add("Selesai Picking", typeof(string));
                dtResult.Columns.Add("User Name", typeof(string));
                dtResult.Columns.Add("Jam Muat", typeof(string));
                dtResult.Columns.Add("Checker", typeof(string));
                dtResult.Columns.Add("Scan Check Picking", typeof(string));
                dtResult.Columns.Add("UserID Pick", typeof(string));
                dtResult.Columns.Add("Scan Loading", typeof(string));
                dtResult.Columns.Add("Jam LOAD", typeof(string));
                dtResult.Columns.Add("Stock", typeof(string));
                dtResult.Columns.Add("Order Status", typeof(string));
                dtResult.Columns.Add("Receiptkey", typeof(string));
                dtResult.Columns.Add("Pallet ASN", typeof(string));
                dtResult.Columns.Add("Receipt Status", typeof(string));
                IEnumerable<DataRow> query =
                from Wms in Orders.AsEnumerable()
                join Locals in OrdersLocal.AsEnumerable() on  Wms.Field<string>("ID")  equals
                 Locals.Field<string>("ID") 
                into cek
                from r in cek.DefaultIfEmpty()

                join Locals_IT in OrdersLocal_IT.AsEnumerable() on Wms.Field<string>("ID") equals
Locals_IT.Field<string>("ID")
into Cek_IT
                from r_IT in Cek_IT.DefaultIfEmpty()


                select dtResult.LoadDataRow(new object[]{
                    Wms.Field<string>("Orderkey")   ,
                    Wms.Field<string>("SKU")   ,
                    Wms.Field<string>("AssyCode")   ,
                    Wms.Field<string>("CartonID")   ,
                    Wms.Field<int>("QTY")   ,

                    Wms.Field<string>("QtySOH")   ,
                    Wms.Field<string>("PAlletID")   ,
                 r==null?"belum di Scan ": r.Field<string>("SelesaiPicking") ,
                 r==null?" ": r.Field<string>("UserName"),
                  r==null?" ": r.Field<string>("JamMuat"),
                  r==null?" ": r.Field<string>("Checker"),
                  r_IT==null?" ": r_IT.Field<string>("JamPick"),
                  r_IT==null?" ": r_IT.Field<string>("UserID"),
                  r_IT==null?" ": r_IT.Field<string>("l_UserID"),
                  r_IT==null?" ": r_IT.Field<string>("JamLoad"),
    

                     Wms.Field<string>("Stock"),
                    Wms.Field<string>("OrderStatus"),
                    Wms.Field<string>("Receiptkey"),
                    Wms.Field<string>("PalletASN"),
                    Wms.Field<string>("ReceiptStatus")

                }, false);

                // Show in Grid
                DataTable boundTable = query.CopyToDataTable<DataRow>();
                DgsOrderDetails.DataSource = boundTable;
                DgsOrderDetailsBinding.DataSource = boundTable;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void GetOrderList()
        {
            try
            {
                ConnWMS.Open();
                SqlDataAdapter DA = new SqlDataAdapter("select a.Storerkey, a.orderkey, a.Externorderkey, cast(a.Orderdate as Date) as 'Add Date',REQUESTEDSHIPDATE as ETD_PLB ,a.trailerNumber, b.JumlahCarton, c.JumlahPallet, d.DESCRIPTION as Status" +
                " from Orders a inner join (select Orderkey, count(Lottable10) as JumlahCarton from orderdetail group by ORDERKEY) b on a.ORDERKEY = b.ORDERKEY"+
                 " inner join(select ORDERKEY, count(distinct(ID)) as JumlahPallet from PICKDETAIL group by ORDERKEY)c on a.ORDERKEY = c.ORDERKEY"+
                 " inner join ORDERSTATUSSETUP d on a.STATUS = d.CODE "+
                " where Storerkey like '%PLBSAM%' and a.status < '95'", ConnWMS);
                DataSet DS = new DataSet();
                DA.Fill(DS);
                dgsOrderList.DataSource = DS.Tables[0];
                ConnWMS.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void OrderHome_Load(object sender, EventArgs e)
        {
        }

        private void dgsOrderList_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            OrderkeyCell = dgsOrderList.Rows[e.RowIndex].Cells[1].Value.ToString();
            GetOrderDetail();
        }

        private void dgsOrderList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow row in dgsOrderList.Rows)
            {

                if (this.dgsOrderList.Columns[e.ColumnIndex].Name == "Priority")
                {
                    if (e.Value != null && e.Value.ToString() == "1")
                    {
                        dgsOrderList.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.PaleGreen;
                    }
                    if(e.Value != null && e.Value.ToString() == "3")
                    {
                        dgsOrderList.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Cyan;
                    }
                    else if (e.Value != null && e.Value.ToString() == "5")
                        {
                        dgsOrderList.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;

                    }

                }

            }
        }

        private void DgsOrderDetails_SortStringChanged(object sender, EventArgs e)
        {

            this.DgsOrderDetailsBinding.Sort = this.DgsOrderDetails.SortString;
        }

        private void DgsOrderDetails_FilterStringChanged(object sender, EventArgs e)
        {
            this.DgsOrderDetailsBinding.Filter = this.DgsOrderDetails.FilterString;

        }

        private void Btn_refresh_Click(object sender, EventArgs e)
        {


            if (txt_Storerkey.Text.Contains("PLBSAM"))
            {
                GetSumOrder();

            }
            else
            {
                MessageBox.Show("Pilih Storerkey Dulu !");
            }
            
        }

        private void dgsOrderList_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button==MouseButtons.Left)
            {
                
            }
            else {

                /*
                ContextMenuStrip menu = new System.Windows.Forms.ContextMenuStrip();
                ToolStripMenuItem menuItem = new ToolStripMenuItem("Exit");
                
                if(Position >= 0)
                {
                    menu.Items.Add("Detail").Name = "Detail";
                    menu.Items.Add("Dispatch").Name = "Dispatch";


                }
                menu.Click += new EventHandler(menuItem_Click);
                menu.Show(dgsOrderList, new Point(e.X, e.Y));
                */
                int Position = dgsOrderList.HitTest(e.X, e.Y).RowIndex;    
                this.ContextMenuStrip = contextMenuStrip1;
            }
        }

        private void btn_dispatch_Click(object sender, EventArgs e)
        {
        }

        private void btn_Export_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            
            for (int i = 1; i <= 10; i++)
            {
            DataGridViewRow row =
            (DataGridViewRow)dgsOrderList.RowTemplate.Clone();

            }
            
            Microsoft.Office.Interop.Excel._Application excel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = excel.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            try
            {
                worksheet = workbook.ActiveSheet;
                worksheet.Name = "Sheet1";

                int cellRowIndex = 1;
                int cellColumnIndex = 1;


                for (int i = 0; i < dgsOrderList.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dgsOrderList.Columns.Count; j++)
                    {

                        if (cellRowIndex == 1)
                        {
                            worksheet.Cells[cellRowIndex, cellColumnIndex] = dgsOrderList.Columns[j].HeaderText;
                        }
                        else
                        {
                            worksheet.Cells[cellRowIndex, cellColumnIndex] = dgsOrderList.Rows[i].Cells[j].Value.ToString();
                        }
                        cellColumnIndex++;
                    }
                    cellColumnIndex = 1;
                    cellRowIndex++;
                }

                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                saveDialog.FilterIndex = 2;

                if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    workbook.SaveAs(saveDialog.FileName);
                    MessageBox.Show("Export Successful");
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                excel.Quit();
                workbook = null;
                excel = null;

            }
        }

        private void dgsOrderList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgsOrderList_CellContentDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {

            OrderkeyCell = dgsOrderList.Rows[e.RowIndex].Cells[1].Value.ToString();
            GetOrderDetail();
        }

        private void dgsOrderList_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {

        }

        private void EditScan_Click(object sender, EventArgs e)
        {
            frmDeleteScanPick f2 = new frmDeleteScanPick();
            f2.Show();

        }
    }
}
