﻿using System;
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
        protected override bool ShowFocusCues
        {
            get
            {
                // return base.ShowFocusCues;
                return false;
            }
        }

        private void Login()
        {
            btn_login.BackColor = Color.DarkOrange;
            btn_login.ForeColor = Color.Black;

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
            btn_login.BackColor = Color.Green;
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

        private void btn_login_MouseEnter(object sender, EventArgs e)
        {
            btn_login.BackColor = Color.DarkOrange;
            btn_login.ForeColor = Color.Black;
        }

        private void btn_login_KeyPress(object sender, KeyPressEventArgs e)
        {
            btn_login.BackColor = Color.DarkOrange;
            btn_login.ForeColor = Color.Black;

        }

      

        private void txt_UserName_Enter(object sender, EventArgs e)
        {
            panel2.BackColor = Color.DarkOrange;
            txt_UserName.Font = new Font("Microsoft Sans Serif", 18);
            txt_UserName.ForeColor = Color.Black;

            txt_UserName.Text = "";
            lblUsername.Visible = true;

        }
        private void txt_UserName_Leave(object sender, EventArgs e)
        {
            panel2.BackColor = Color.DarkGray;
            lblUsername.Visible = false;
            if (txt_UserName.Text =="" )
            {
                txt_UserName.Text = "Masukan Username";
                txt_UserName.Font = new Font("Microsoft Sans Serif", 12);
                txt_UserName.ForeColor = Color.DarkGray;

            }
            else
            {
                txt_UserName.Font = new Font("Microsoft Sans Serif", 18);
                txt_UserName.ForeColor = Color.Black;

            }

        }

        private void txt_Pass_Enter(object sender, EventArgs e)
        {
            panel1.BackColor = Color.DarkOrange;
            txt_Pass.Font = new Font("Microsoft Sans Serif", 18);
            txt_Pass.ForeColor = Color.Black;
            txt_Pass.Text = "";
            lblPass.Visible = true;
            lblPass2.Visible = false;
        }

        private void txt_Pass_Leave(object sender, EventArgs e)
        {
            panel1.BackColor = Color.DarkGray;
            txt_Pass.Font = new Font("Microsoft Sans Serif", 12);
            txt_Pass.ForeColor = Color.DarkGray;
            lblPass2.ForeColor = Color.DarkGray;
            lblPass2.Visible = true;
            lblPass.Visible = false;

        }

        private void btn_login_Click(object sender, MouseEventArgs e)
        {
            btn_login.BackColor = Color.DarkOrange;
            btn_login.ForeColor = Color.Black;
            Login();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            
            lblPass.Visible = false;
            lblPass2.ForeColor = Color.DarkGray;

        }
    }
}