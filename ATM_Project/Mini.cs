using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATM_Project
{
    public partial class Mini : Form
    {
        public Mini()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dashboard d = new Dashboard();
            d.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Landing_Page l = new Landing_Page();
            l.Show();
            this.Hide();
        }
        static string conStr = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=BankDB;Data Source=DESKTOP-8S8DEUD\SQLEXPRESS";
        SqlConnection con = new SqlConnection(conStr);
        private void Mini_Load(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("MINI_STATEMENT", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ACC_NO", Account.AccNo);
                cmd.ExecuteNonQuery();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.Rows.Clear();

                foreach (DataRow dr in dt.Rows)
                {
                    dataGridView1.Rows.Add(int.Parse(dr[0].ToString()), dr[1].ToString(), int.Parse(dr[2].ToString()), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString());
                }
              
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            
        }

        private void btnPrint_Click(object sender, EventArgs e)
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

                MessageBox.Show("Mini Statement Issued:)");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                new Dashboard().Show();
                this.Hide();
                con.Close();
            }
            
           
        }
    }
}
