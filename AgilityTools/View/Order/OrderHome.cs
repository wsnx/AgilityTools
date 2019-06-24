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
        DataSet dsWMS = new DataSet();
        private static string hasil;
        private static string OrderkeyCell;

        public OrderHome()
        {
            InitializeComponent();
        }

        private void GetOrderDetail()
        {
            try
            {
                //WMS
                    
                ConnWMS.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = ConnWMS;
                cmd.CommandText = ("select Concat(b.SKU,b.CartonID)as ID,b.SKU,a.Storerkey,a.orderkey,a.Externorderkey,cast(a.Orderdate as Date) as OrderDate,a.trailerNumber,b.CartonID,PalletID, DESCRIPTION as Status " +
               " from Orders a inner join (select SKU,Orderkey, LOTTABLE01 as CartonID from orderdetail group by SKU,ORDERKEY,Lottable01) b on a.ORDERKEY = b.ORDERKEY " +
                " inner join(select ORDERKEY, ID as PalletID from PICKDETAIL group by ORDERKEY,ID)c on a.ORDERKEY = c.ORDERKEY " +
                " inner join ORDERSTATUSSETUP d on a.STATUS = d.CODE " +
                 " where Storerkey like '%PLBSAM%' and a.status < '95' and a.Orderkey= @Orderkey ");


                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("Orderkey", OrderkeyCell);
                DataSet ds = new DataSet();
                DA.Fill(ds);
                DataTable Orders = ds.Tables[0];
                ConnWMS.Close();

                //Local
                ConnLocal.Open();
                cmd.Connection = ConnLocal;
                cmd.CommandText = " select Concat(SKU,CARTONID)as ID,Len(concat(SKU,CARTONID)),SKU,Orderkey,Notes,CartonID,PalletID,Convert( varchar,MAx(Editdate),120)as Date ,Editwho from tbPLBSAMI_FG_PickingCheck " +
                    " where orderkey = @Orderkey2 " +
                    " group by Orderkey,Notes,CartonID,PalletID,SKU,editwho";

                SqlDataAdapter DALocal = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("Orderkey2", OrderkeyCell);
                DataSet dsLocal = new DataSet();
                DALocal.Fill(dsLocal);
                DataTable OrdersLocal = dsLocal.Tables[0];
                ConnLocal.Close();

                //Joining
                DataTable dtResult = new DataTable();
                dtResult.Columns.Add("Orderkey", typeof(string));
                dtResult.Columns.Add("CartonID", typeof(string));
                dtResult.Columns.Add("PalletID", typeof(string));
                dtResult.Columns.Add("Editdate", typeof(string));
                dtResult.Columns.Add("EditWho", typeof(string));
                dtResult.Columns.Add("Notes", typeof(string));

                IEnumerable<DataRow> query =
                from Wms in Orders.AsEnumerable()
                join Locals in OrdersLocal.AsEnumerable() on  Wms.Field<string>("ID")  equals
                 Locals.Field<string>("ID") 
                into cek
                from r in cek.DefaultIfEmpty()
                select dtResult.LoadDataRow(new object[]{
                    Wms.Field<string>("Orderkey")   ,
                    Wms.Field<string>("CartonID")   ,
                    Wms.Field<string>("PAlletID")   ,
                    r.Field<string>("Editdate") ,
                    r.Field<string>("Editwho"),
                    r==null?" ": r.Field<string>("Notes"),
                },false);

                // Show in Grid
                DataTable boundTable = query.CopyToDataTable<DataRow>();
                DgsOrderDetails.DataSource = boundTable;

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
                SqlDataAdapter DA = new SqlDataAdapter("select a.Storerkey, a.orderkey, a.Externorderkey, cast(a.Orderdate as Date) as OrderDate, a.trailerNumber, b.JumlahCarton, c.JumlahPallet, d.DESCRIPTION as Status"+
                " from Orders a inner join (select Orderkey, count(LOTTABLE01) as JumlahCarton from orderdetail group by ORDERKEY) b on a.ORDERKEY = b.ORDERKEY"+
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
            GetOrderList();
        }

        private void dgsOrderList_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            OrderkeyCell = dgsOrderList.Rows[e.RowIndex].Cells[1].Value.ToString();
            GetOrderDetail();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            GetOrderList();
        }
    }
}
