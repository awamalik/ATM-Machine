using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ATM_Project
{
    public partial class Admin_Login : Form
    {
        public Admin_Login()
        {
            InitializeComponent();
        }
        static string conStr = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=BankDB;Data Source=DESKTOP-8S8DEUD\SQLEXPRESS";
        SqlConnection con = new SqlConnection(conStr);

        private void button1_Click(object sender, EventArgs e)
        {
            Landing_Page l=new Landing_Page();
            l.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("ADMIN_LOGIN", con);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EMPID", tbUserID.Text);


                cmd.Parameters.AddWithValue("@PIN", tbPassword.Text);

                cmd.Parameters.Add("@ROLE", SqlDbType.VarChar, 20);
                cmd.Parameters["@ROLE"].Direction = ParameterDirection.Output;

                cmd.Parameters.Add("@CHECK", SqlDbType.Int).Value = 0;
                cmd.Parameters["@CHECK"].Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();


                int c = int.Parse((cmd.Parameters["@CHECK"].Value).ToString());
                User.EmpID = tbUserID.Text;
                User.role = (cmd.Parameters["@ROLE"].Value).ToString();

                if (c == 0)
                {
                    MessageBox.Show("Invalid UserName or Password!!");


                    
                } 
                else
                {
                    new Admin_Dashboard().Show();
                    this.Hide();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }

           
        }

        private void tbUserID_MouseDown(object sender, MouseEventArgs e)
        {
            tbUserID.Text = null;
            tbUserID.ForeColor = Color.Black;
        }

        private void tbPassword_MouseDown(object sender, MouseEventArgs e)
        {
            tbPassword.Text = null;
            tbPassword.ForeColor = Color.Black;
        }
    }
}
