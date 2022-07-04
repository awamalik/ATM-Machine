using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ATM_Project
{
    public partial class Login : Form
    {
        static string conStr = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=BankDB;Data Source=DESKTOP-8S8DEUD\SQLEXPRESS";
        SqlConnection con = new SqlConnection(conStr);
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            tbCardNo.Text = "";
        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            tbPin.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("ACC_LOGIN", con);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AccNo", tbCardNo.Text);


                cmd.Parameters.AddWithValue("@PIN", tbPin.Text);

                cmd.Parameters.Add("@Balance", SqlDbType.Int).Value = 0;
                cmd.Parameters["@Balance"].Direction = ParameterDirection.Output;

                cmd.Parameters.Add("@AtmStatus", SqlDbType.VarChar,20);
                cmd.Parameters["@AtmStatus"].Direction = ParameterDirection.Output;

                cmd.Parameters.Add("@CHECK", SqlDbType.Int).Value = 0;
                cmd.Parameters["@CHECK"].Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();


                int c = int.Parse((cmd.Parameters["@CHECK"].Value).ToString());
                Account.AccNo = (cmd.Parameters["@AccNo"].Value).ToString();
                Account.balance = int.Parse((cmd.Parameters["@Balance"].Value).ToString());
                Account.AtmStatus = (cmd.Parameters["@AtmStatus"].Value).ToString();
          
                if (c == 1)
                {
                    if (Account.AtmStatus.ToString() == "ISSUED")
                    {
                        //if (Account.balance < 100000)
                        //{
                        //    MessageBox.Show("Low Balance Plz Recharge!\nOtherwise Account will be blocked!");
                        //}
                        new Dashboard().Show();
                        this.Hide();
                    }

                    else
                    {
                        MessageBox.Show("Card Not Issued Contact Bank!!");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid UserName or Password!!");
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
            //Dashboard f = new Dashboard();
            //f.Show();
            //this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Landing_Page l = new Landing_Page();
            l.Show();
            this.Hide();
        }

        private void tbCardNo_MouseDown(object sender, MouseEventArgs e)
        {
            tbCardNo.Text = null;
            tbCardNo.ForeColor = Color.Black;
        }

        private void tbPin_MouseDown(object sender, MouseEventArgs e)
        {
            tbPin.Text = null;
            tbPin.ForeColor = Color.Black;
        }
    }
}
