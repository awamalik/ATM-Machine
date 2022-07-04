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
    public partial class Balance_Inc : Form
    {
        public Balance_Inc()
        {
            InitializeComponent();
        }
        static string conStr = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=BankDB;Data Source=DESKTOP-8S8DEUD\SQLEXPRESS";
        SqlConnection con = new SqlConnection(conStr);

        private void button2_Click(object sender, EventArgs e)
        {
            Dashboard d = new Dashboard();
            d.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("TRANSFER_MONEY", con);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@From", Account.AccNo.ToString());
                cmd.Parameters.AddWithValue("@To", string.Empty);
                cmd.Parameters.AddWithValue("@AMOUNT", Account.balance);

                cmd.Parameters.AddWithValue("@TYPE", "DEDUCTION");
                cmd.Parameters.AddWithValue("@AMT", 10);
                cmd.Parameters.AddWithValue("@DATE", DateTime.Now.ToString().Split(' ')[0]);
                cmd.Parameters.AddWithValue("@TIME", DateTime.Now.ToString().Split(' ')[1]);

                cmd.Parameters.AddWithValue("@MID", Machine.MachineID);
                cmd.Parameters.Add("@CHK", SqlDbType.Int).Value = 0;
                cmd.Parameters["@CHK"].Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                Account.balance -= 10;
                label4.Text = Account.balance.ToString();
                
                MessageBox.Show("Recipt Issued:)");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }

            }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Landing_Page l = new Landing_Page();
            l.Show();
            this.Hide();
        }

        private void Balance_Inc_Load(object sender, EventArgs e)
        {
            label4.Text = Account.balance.ToString();
        }
    }
}
