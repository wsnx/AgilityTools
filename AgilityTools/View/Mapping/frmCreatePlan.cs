using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgilityTools
{
    public partial class frmCreatePlan : Form
    {
        OleDbConnection oledbcon;

        public frmCreatePlan()
        {
            InitializeComponent();
        }
        public static string excel_path
        {
            get;
            set;
        }

        public static string excelfile
        {
            get;
            set;
        }

        public DataTable excel_sheet_name
        {
            get;
            set;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfileDial = new OpenFileDialog();
            if (openfileDial.ShowDialog() == DialogResult.OK)
            {
                excel_path = openfileDial.FileName;
                excelfile = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + excel_path + ";Extended Properties=\"Excel 8.0;HDR=YES;\";";
                oledbcon = new OleDbConnection(excelfile);

                label1.Text = excel_path;

                try
                {
                    oledbcon.Open();
                    excel_sheet_name = new DataTable();
                    excel_sheet_name = oledbcon.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, null);

                    for (int x = 0; x < excel_sheet_name.Rows.Count; x++)
                    {
                        //Sheet_Name.Items.Add(excel_sheet_name.Rows[x]["TABLE_NAME"].ToString());
                        //Table_Name.Items.Add(excel_sheet_name.Rows[x]["COLUMN_NAME"].ToString());
                    }

                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error!");
                }
                finally
                {
                    oledbcon.Close();
                }
            }

            else
            {

            }

        }
    }
}
