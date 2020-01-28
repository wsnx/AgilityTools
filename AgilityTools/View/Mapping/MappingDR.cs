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
    public partial class MappingDR : UserControl
    {


        SqlConnection ConnLocal = new SqlConnection(ConfigDB.DBlocal);
        public MappingDR()
        {
            InitializeComponent();
        }

        private void btnProsesUpload_Click(object sender, EventArgs e)
        {

        }

        private void DraftDR()
        {

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConnLocal;
            ConnLocal.Close();
            ConnLocal.Open();

            cmd.CommandText = "select SKU,C1,C2,C3,C4,C4,C5,C6,C7,C8,C9,C10,C11,C12,C13,C14,C15,C16,C17,C18,C19,C20 from tbPLBSAMI_FG_DraftDR";
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet DsWMS = new DataSet();
            DA.Fill(DsWMS);
            DgsDraftDR.DataSource = DsWMS.Tables[0];
            ConnLocal.Close();

        }

        private void MappingHead()
        {


            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConnLocal;

            cmd.CommandText = "select etd,FreightType,Invoice,Destination,ShippingLine,Carline from tbPLBSAMI_FG_DraftDR ";
            ConnLocal.Close();
           ConnLocal.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                txt_ETD.Text = reader.GetString(0);
                txt_Freight.Text = reader.GetString(1);
                txt_NoInvoice.Text = reader.GetString(2);
                txt_ShippingLine.Text = reader.GetString(3);
                txt_destination.Text = reader.GetString(4);

                txt_Carline.Text = reader.GetString(5);
            }
            ConnLocal.Close();


        }
        private void MappingDR_Load(object sender, EventArgs e)
        {
            DraftDR();
            MappingHead();
        }

        private void txt_Carline_Click(object sender, EventArgs e)
        {

        }

        private void DgsDraftDR_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
