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
    public partial class Add_AtmCard : Form
    {
        static string conStr = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=BankDB;Data Source=DESKTOP-8S8DEUD\SQLEXPRESS";
        SqlConnection con = new SqlConnection(conStr);
        public Add_AtmCard()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Admin_Dashboard a = new Admin_Dashboard();
            a.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Landing_Page l = new Landing_Page();
            l.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("ISSUE_ATMCARD", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ACC_NO", tbAccNo.Text);


               cmd.ExecuteNonQuery();
                MessageBox.Show("Card Assigned!");
                lbStatus.Text = "Issued";
                btnAssignCard.Hide();

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }

            MessageBox.Show("Card Assigned!");
            lbStatus.Text = "Issued";
            btnAssignCard.Hide();
        }

        private void Add_AtmCard_Load(object sender, EventArgs e)
        {
            lbAccNo.Hide();
            lbBalance.Hide();
            lbStatus.Hide();
            lbTitle.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("GET_ACC_DETAIL", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ACC_NO", tbAccNo.Text);


                SqlDataReader sdr = cmd.ExecuteReader();
                while(sdr.Read())
                {
                    lbAccNo.Show();
                    lbAccNo.Text = sdr[0].ToString();
                    lbBalance.Show();
                    lbBalance.Text= sdr[3].ToString();
                    lbStatus.Show();
                    lbStatus.Text= sdr[4].ToString();
                    lbTitle.Show();
                    lbTitle.Text= sdr[2].ToString();
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

        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
            tbAccNo.Text = null;
            tbAccNo.ForeColor = Color.Black;
        }
    }
}
