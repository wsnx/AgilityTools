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

namespace AgilityTools.View.Receiving
{
    public partial class F_EditPalletInbound : Form
    {
        public F_EditPalletInbound()
        {
            InitializeComponent();
        }
        SqlConnection Conn = new SqlConnection(ConfigDB.conWMS);
        SqlConnection ConnLocal = new SqlConnection(ConfigDB.DBlocal);
        private static string TransID;

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            getPallet();
        }
        private void getPallet()
        {
            try
            {

                Dgs_Unloaddetails.Columns.Clear();
                ConnLocal.Open();
                SqlDataAdapter DA = new SqlDataAdapter("select Receiptkey,FromPalletID,SKU,AssyCode,cartonID,Editdate,UserName,TransID from tbplbsami_fg_unloaddetails where receiptkey='" + txt_Receiptkey.Text+"' and frompalletID='"+txt_PalletID.Text+"'", ConnLocal);
                DataSet DS = new DataSet();
                DA.Fill(DS);
                DataGridViewCheckBoxColumn CheckboxColumn = new DataGridViewCheckBoxColumn();
                CheckBox chk = new CheckBox();
                CheckboxColumn.Width = 20;
                Dgs_Unloaddetails.Columns.Add(CheckboxColumn);

                Dgs_Unloaddetails.DataSource = DS.Tables[0];
                ConnLocal.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void DeletedSQL2()
        {

            SqlCommand cmd = new SqlCommand("Update tbPLBSAMI_FG_UnloadDetails " +
                "set PK= concat(receiptkey,SKU,CartonID,AssyCode,'~delete~',convert(Varchar,getdate(),106),'~','" + FormLogin.NIK.ToString() + "') where TransID in(" + TransID + ")", ConnLocal);
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
            ConnLocal.Close();
            SqlCommand cmd = new SqlCommand("Update tbPLBSAMI_FG_UnloadDetails " +
                "set receiptkey= concat(receiptkey,'~delete~',convert(Varchar,getdate(),106),'~','" + FormLogin.NIK.ToString() + "') where TransID in(" + TransID + ")", ConnLocal);
            try
            {
                ConnLocal.Open();
                cmd.ExecuteNonQuery();
                ConnLocal.Close();
                MessageBox.Show("Deleted Succesed");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            getPallet();
        }

        private void Btn_Del_Click(object sender, EventArgs e)
        {
            getreceiptkey();
            DeletedSQL2();
            DeletedSQL();
        }

        private void getreceiptkey()
        {
            string hasil = "";
            try
            {
                foreach (DataGridViewRow Row in Dgs_Unloaddetails.Rows)
                {

                    if (Row.Cells[0].Value != null)
                    {
                        if ((bool)(Row.Cells[0].Value) == true)
                        {
                            string receiptkey = Dgs_Unloaddetails.Rows[Row.Index].Cells["TransID"].Value.ToString();
                            hasil += ",'" + receiptkey + "'";
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Anda Belum memilih" + ex.ToString());
            }

            int a = hasil.Length - 1;
            string aa = hasil.Substring(1, a);
            TransID = aa.ToString();

        }
    }
}
