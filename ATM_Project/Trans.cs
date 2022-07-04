using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATM_Project
{
    public partial class Trans : Form
    {
        public Trans()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dashboard d = new Dashboard();
            d.Show();
            this.Hide();
        }
        static string conStr = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=BankDB;Data Source=DESKTOP-8S8DEUD\SQLEXPRESS";
        SqlConnection con = new SqlConnection(conStr);

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Landing_Page l = new Landing_Page();
            l.Show();
            this.Hide();
        }

        private void tbAccNo_MouseDown(object sender, MouseEventArgs e)
        {
            tbAccNo.Text = null;
            tbAccNo.ForeColor = Color.Black;
        }

        private void tbAmount_MouseDown(object sender, MouseEventArgs e)
        {
            tbAmount.Text = null;
            tbAmount.ForeColor = Color.Black;
        }

        private void Trans_Load(object sender, EventArgs e)
        {
            lbCurrentBalance.Text = Account.balance.ToString();
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(tbAmount.Text) <= Account.balance && int.Parse(tbAmount.Text) > 0)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("TRANSFER_MONEY", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@From", Account.AccNo.ToString());
                    cmd.Parameters.AddWithValue("@To", tbAccNo.Text.ToString());
                    cmd.Parameters.AddWithValue("@AMOUNT", Account.balance);

                    cmd.Parameters.AddWithValue("@TYPE", "TRANSFER");
                    cmd.Parameters.AddWithValue("@AMT", int.Parse(tbAmount.Text.ToString()));
                    cmd.Parameters.AddWithValue("@DATE", DateTime.Now.ToString().Split(' ')[0]);
                    cmd.Parameters.AddWithValue("@TIME", DateTime.Now.ToString().Split(' ')[1]);

                    cmd.Parameters.AddWithValue("@MID", Machine.MachineID);
                    cmd.Parameters.Add("@CHK", SqlDbType.Int).Value = 0;
                    cmd.Parameters["@CHK"].Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();
                    Account.balance -= int.Parse(tbAmount.Text.ToString());
                    lbCurrentBalance.Text = Account.balance.ToString();

                    string message = "Transaction Completed:)\nDo you want to make another Transfer Transaction?";
                    string title = "Close Window";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result = MessageBox.Show(message, title, buttons);
                    if (result == DialogResult.No)
                    {
                        new Dashboard().Show();
                        this.Hide();
                    }

                }
                else
                    MessageBox.Show("Invalid Entry!");
                

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

    }
}
