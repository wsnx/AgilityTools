using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgilityTools
{
    public partial class frmRemapping : Form
    {
        SqlConnection Conn = new SqlConnection(ConfigDB.conWMS);
        SqlConnection ConnLocal = new SqlConnection(ConfigDB.DBlocal);
        public frmRemapping()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetMappingReprint();

        }
        private void GetMappingReprint()
        {
            try
            {
                ConnLocal.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = ConnLocal;
                cmd.CommandText = " select a.STorerkey,a.MappingID,a.SKU,count(a.CartonID) as JumlahCarton ,b.receiptkey as ASN,convert(varchar(120),max(ReceiptDate)) as ReceivedDate,b.LOC from tbPLBSAMI_FG_tempGenerateLIST a left Join tbPLBSAMI_FG_stgMappingStock b on a.CartonID = b.CartonID and a.sku = b.sku left join(select cartonID, SKU , notes from tbplbsami_fg_mappingChecking ) c on a.CartonID = c.CartonID and c.sku = b.sku where isnull(c.notes,'')= '' and ISNULL(b.receiptkey,'')<> ''   group by b.receiptkey ,b.LOC,a.STorerkey,a.MappingID,a.SKU";
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);
                dgsReprintdetails.DataSource = DS.Tables[0];
                dgsBindingReprint.DataSource = DS.Tables[0];

                ConnLocal.Close();

            }
            catch (Exception ex)
            {

            }
        }

        private void dgsReprintdetails_FilterStringChanged(object sender, EventArgs e)
        {
            this.dgsBindingReprint.Filter = this.dgsReprintdetails.FilterString;
        }

        private void dgsReprintdetails_SortStringChanged(object sender, EventArgs e)
        {
            this.dgsBindingReprint.Sort = this.dgsReprintdetails.SortString;

        }
    }
}
