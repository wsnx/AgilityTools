using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AgilityTools
{
    public partial class FormLogin : Form

    {


        SqlConnection Conn = new SqlConnection(ConfigDB.conWMS);
        SqlConnection ConnLocal = new SqlConnection(ConfigDB.DBlocal);
        public static string UserName;
        public static string NIK;
        public static string Password;

        public FormLogin()
        {
            InitializeComponent();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {

            btn_login.BackColor = Color.DarkOrange;
            btn_login.ForeColor = Color.Black;
            Login();
        }
        private void Login()
        {
            ConnLocal.Close();
            SqlCommand cmd = new SqlCommand("select NIK,UserName,Password from kaizendb.dbo.tbplbsami_fg_user where nik =@nik", ConnLocal);
            cmd.Parameters.AddWithValue("@NIK", txt_UserName.Text);
            ConnLocal.Open();
            var result = cmd.ExecuteScalar();
            if (result != null)
            {
                SqlDataReader reader = null;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    NIK = reader.GetString(0);

                    UserName = reader.GetString(1);

                    Password = reader.GetString(2);
                }
                goto cek;
                ConnLocal.Close();
                }
            else
            {
                MessageBox.Show("NIK Belum terdaftar");
            }
            cek:

            if (NIK == txt_UserName.Text &&  txt_Pass.Text == Password)
            {
                menu();
            }
            else
            {
                MessageBox.Show("Password Salah");
            }
            

        }
        private void menu()
        {
            this.Close();
            Home f2 = new Home();
            f2.MdiParent = AgilityTools.ActiveForm;
            f2.Show();

        }
        private void btn_login_MouseHover(object sender, EventArgs e)
        {
            btn_login.BackColor = Color.DarkOrange;
            btn_login.ForeColor = Color.Black;
        }
        private void btn_login_MouseLeave(object sender, EventArgs e)
        {
            btn_login.BackColor = Color.Orange;
            btn_login.ForeColor = Color.White;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_login_MouseClick(object sender, MouseEventArgs e)
        {
            btn_login.BackColor = Color.DarkOrange;
            btn_login.ForeColor = Color.Black;

        }
    }
}
