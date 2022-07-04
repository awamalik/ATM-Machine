using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATM_Project
{
    public partial class Check_Cash : Form
    {
        public Check_Cash()
        {
            InitializeComponent();
        }
        static string conStr = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=BankDB;Data Source=DESKTOP-8S8DEUD\SQLEXPRESS";
        SqlConnection con = new SqlConnection(conStr);
        public void saveChanges()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("ADD_CASH", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MACHINEID", Machine.MachineID.ToString());


                cmd.Parameters.AddWithValue("@n500", Machine.n500);
                cmd.Parameters.AddWithValue("@n1000", Machine.n1000);
                cmd.Parameters.AddWithValue("@n5000", Machine.n5000);
                cmd.Parameters.AddWithValue("@total", Machine.TotalCash);



                cmd.ExecuteNonQuery();


                //foreach (DataRow dr in dt.Rows)
                //{
                //    dataGridView1.Rows.Add(int.Parse(dr[0].ToString()), dr[1].ToString(), int.Parse(dr[2].ToString()), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString());
                //}

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

        private void button2_Click(object sender, EventArgs e)
        {
            Admin_Dashboard a = new Admin_Dashboard();
            a.Show();

            this.Hide();
            saveChanges();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            saveChanges();
            Landing_Page l = new Landing_Page();
            l.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
        public void refresh()
        {
            cap500.Text = ((500 - Machine.n500) * 500).ToString();
            cap1000.Text = ((500 - Machine.n1000) * 1000).ToString();
            cap5000.Text = ((500 - Machine.n5000) * 5000).ToString();
            lbAvailable.Text = Machine.TotalCash.ToString();
            lbCapacity.Text = "3250000";
            label7.Text = Machine.n500.ToString();
            label10.Text = "Rs. " + (Machine.n500) * 500;
            label8.Text = Machine.n1000.ToString();
            label11.Text = "Rs. " + (Machine.n1000) * 1000;
            label9.Text = Machine.n5000.ToString();
            label12.Text = "Rs. " + (Machine.n5000) * 5000;
        }
        private void Check_Cash_Load(object sender, EventArgs e)
        {
            refresh();
        }

        private void tbAddCash_MouseDown(object sender, MouseEventArgs e)
        {
            tb500.Text = null;
            tb500.ForeColor = Color.Black;
        }

        private void btnAdd500_Click(object sender, EventArgs e)
        {
            if (int.Parse(tb500.Text) % 500 == 0)
            {
                int RC_500 = 500 - Machine.n500;
                int new500 = int.Parse(tb500.Text) / 500 + Machine.n500;
                int newBalance = int.Parse(tb500.Text) + Machine.TotalCash;
                if (int.Parse(tb500.Text) / 500 <= RC_500)
                {
                    Machine.n500 = new500;
                    Machine.TotalCash = newBalance;
                    tb500.Text = "";
                    refresh();
                    /* 
                    UPDATE DB_Table => Machines
                    new500 for n500
                    newBalance for  totalCash
                    */
                    //MessageBox.Show("Cash Added!");
                    /*
                    Reload Current Form to Accept Changes
                    */
                }
                else
                {
                    MessageBox.Show("Invalid Entry!");
                }
            }
        }

        private void btnAdd1000_Click(object sender, EventArgs e)
        {
            if (int.Parse(tb1000.Text) % 1000 == 0)
            {
                int RC_1000 = 500 - Machine.n1000;
                int new1000 = int.Parse(tb1000.Text) / 1000 + Machine.n1000;
                int newBalance = int.Parse(tb1000.Text) + Machine.TotalCash;
                if (int.Parse(tb1000.Text) / 1000 <= RC_1000)
                {
                    Machine.n1000 = new1000;
                    Machine.TotalCash = newBalance;
                    tb1000.Text = "";
                    refresh();
                    /* 
                    UPDATE DB_Table => Machines
                    new1000 for n1000
                    newBalance for  totalCash
                    */
                    // MessageBox.Show("Cash Added!");
                    /*
                    Reload Current Form to Accept Changes
                    */
                }
                else
                {
                    MessageBox.Show("Invalid Entry!");
                }
            }
        }

        private void btnAdd5000_Click(object sender, EventArgs e)
        {
            if (int.Parse(tb5000.Text) % 5000 == 0)
            {
                int RC_5000 = 500 - Machine.n5000;
                int new5000 = int.Parse(tb5000.Text) / 5000 + Machine.n5000;
                int newBalance = int.Parse(tb5000.Text) + Machine.TotalCash;
                if (int.Parse(tb5000.Text) / 5000 <= RC_5000)
                {
                    Machine.n5000 = new5000;
                    Machine.TotalCash = newBalance;
                    tb5000.Text = "";
                    refresh();
                    /* 
                    UPDATE DB_Table => Machines
                    new5000 for n5000
                    newBalance for  totalCash
                    */

                }
                else
                {
                    MessageBox.Show("Invalid Entry!");
                }
            }
        }
        
        private void button1_Click_1(object sender, EventArgs e)
        {

            saveChanges();
        }
    } 
}
