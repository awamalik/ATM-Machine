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
    public partial class Withdraw : Form
    {
        public Withdraw()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        static string conStr = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=BankDB;Data Source=DESKTOP-8S8DEUD\SQLEXPRESS";
        SqlConnection con = new SqlConnection(conStr);
        private void button2_Click(object sender, EventArgs e)
        {
            Dashboard d = new Dashboard();
            d.Show();
            this.Hide();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            int Amount = int.Parse(tbAmount.Text);
            if (Amount <= Account.balance)
            {
                if (Machine.TotalCash >= Amount)
                {
                    int no_500 = 0;
                    int no_1000 = 0;
                    int no_5000 = 0;
                    int remaining = 0;
                    int trem = 0;
                    //  Checking Validity
                    if (Amount % 500 == 0)
                    {
                        if (Amount > 4999)
                        {
                            if (Amount % 5000 != 0)
                            {
                                remaining = Amount % 5000;
                                no_5000 = (Amount - remaining) / 5000;
                                if (no_5000 > Machine.n5000)
                                {
                                    remaining += (no_5000 - Machine.n5000)*5000;
                                    no_5000 -= (no_5000 - Machine.n5000);
                                }
                                if (remaining > 999)
                                {
                                    if (remaining % 1000 != 0)
                                    {
                                        trem = remaining % 1000;
                                        no_1000 = (remaining - trem) / 1000;
                                        if (no_1000 > Machine.n1000)
                                        {
                                            remaining += (no_1000 - Machine.n1000) * 1000;
                                            no_1000 -= (no_1000 - Machine.n1000);
                                        }
                                        if (trem == 500)
                                        {
                                            no_500 = 1;
                                        }
                                        else
                                        {
                                            no_500 = 0;
                                        }

                                    }
                                    else
                                    {
                                        no_1000 = remaining / 1000;
                                        if (no_1000 > Machine.n1000)
                                        {
                                            remaining += (no_1000 - Machine.n1000) * 1000;
                                            no_1000 -= (no_1000 - Machine.n1000);
                                        }
                                    }
                                }
                                else
                                {
                                    if (trem == 500)
                                    {
                                        no_500 = 1;
                                    }
                                    else
                                    {
                                        no_500 = 0;
                                    }
                                }
                            }
                            else
                            {
                                no_5000 = Amount / 5000;
                                //if (no_5000 > Machine.n5000)
                                //{
                                //    remaining *= (no_5000 - Machine.n5000);
                                //    no_5000 -= Machine.n5000;
                                //}
                            }
                        }
                        else if (Amount > 999 && Amount < 5000)
                        {
                            remaining = Amount;
                            if (remaining % 1000 != 0)
                            {
                                trem = remaining % 1000;
                                no_1000 = (remaining - trem) / 1000;
                                if (no_1000 > Machine.n1000)
                                {
                                    trem += (no_1000 - Machine.n1000) * 1000;
                                    no_1000 -= (no_1000 - Machine.n1000);
                                }
                                if (trem == 500)
                                {
                                    no_500 = 1;
                                }
                                else
                                {
                                    no_500 = 0;
                                }

                            }
                            else
                            {
                                no_1000 = remaining / 1000;
                            }
                        }
                        else
                        {
                            trem = Amount;
                            if (trem == 500)
                            {
                                no_500 = 1;
                            }
                            else
                            {
                                no_500 = 0;
                            }
                        }
                        if (Machine.TotalCash >= Amount)
                        {
                            int fin_500 = no_500;
                            int fin_1000 = no_1000;
                            int fin_5000 = no_5000;
                            int temp = 0;
                            if (Machine.n5000 < no_5000)
                            {
                                temp = no_5000 - Machine.n5000;
                                fin_1000 += (temp * 5);
                            }
                            if (Machine.n1000 < fin_1000)
                            {
                                temp = no_1000 - Machine.n1000;
                                fin_500 += (temp * 2);
                            }
                            MessageBox.Show("Balance: " + Machine.TotalCash + "\n500: " + Machine.n500 + " \n1000: " + Machine.n1000 + " \n5000: " + Machine.n5000);

                            // fin_500, fin_1000, fin_5000, Amount
                            MessageBox.Show("Amount: " + Amount + "\n500: " + fin_500 + " \n1000: " + fin_1000 + " \n5000: " + fin_5000);

                            Machine.n5000 -= fin_5000;
                            Machine.n500 -= fin_500;
                            Machine.n1000 -= fin_1000;
                            Machine.TotalCash -= Amount;

                            // fin_500, fin_1000, fin_5000, Amount
                            try
                            {
                                con.Open();
                                SqlCommand cmd = new SqlCommand("ADD_CASH", con);

                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@MachineID", Machine.MachineID.ToString());
                                cmd.Parameters.AddWithValue("@n500", Machine.n500);
                                cmd.Parameters.AddWithValue("@n1000", Machine.n1000);
                                cmd.Parameters.AddWithValue("@n5000", Machine.n5000);
                                cmd.Parameters.AddWithValue("@total", Machine.TotalCash);

                                cmd.ExecuteNonQuery();
                                con.Close();
                                con.Open();
                                SqlCommand cmd1 = new SqlCommand("TRANSFER_MONEY", con);

                                cmd1.CommandType = CommandType.StoredProcedure;
                                cmd1.Parameters.AddWithValue("@From", Account.AccNo.ToString());
                                cmd1.Parameters.AddWithValue("@To", string.Empty);
                                cmd1.Parameters.AddWithValue("@AMOUNT", Account.balance);

                                cmd1.Parameters.AddWithValue("@TYPE", "WITHDRAW");
                                cmd1.Parameters.AddWithValue("@AMT", int.Parse(tbAmount.Text.ToString()));
                                cmd1.Parameters.AddWithValue("@DATE", DateTime.Now.ToString().Split(' ')[0]);
                                cmd1.Parameters.AddWithValue("@TIME", DateTime.Now.ToString().Split(' ')[1]);

                                cmd1.Parameters.AddWithValue("@MID", Machine.MachineID);
                                cmd1.Parameters.Add("@CHK", SqlDbType.Int).Value = 0;
                                cmd1.Parameters["@CHK"].Direction = ParameterDirection.Output;

                                cmd1.ExecuteNonQuery();
                                Account.balance -= Amount;

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
                    else
                    {
                        MessageBox.Show("Invalid Amount!");
                    }
                }
                else
                {
                    MessageBox.Show("Insuficient Balance in Machine.\nTry later!");
                }
            }
            else
                MessageBox.Show("Insuficient Balance!");


        }
    
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
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

        private void tbAmount_MouseDown(object sender, MouseEventArgs e)
        {
            tbAmount.Text = null;
            tbAmount.ForeColor = Color.Black;
        }

        private void btn500_Click(object sender, EventArgs e)
        {
            tbAmount.Text = "500";
        }

        private void btn1000_Click(object sender, EventArgs e)
        {
            tbAmount.Text = "1000";

        }

        private void btn10000_Click(object sender, EventArgs e)
        {
            tbAmount.Text = "10000";

        }

        private void btn5000_Click(object sender, EventArgs e)
        {
            tbAmount.Text = "5000";

        }
    }
}
