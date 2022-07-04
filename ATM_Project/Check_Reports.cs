using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATM_Project
{
   
    public partial class Check_Reports : Form
    {
        static string conStr = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=BankDB;Data Source=DESKTOP-8S8DEUD\SQLEXPRESS";
        SqlConnection con = new SqlConnection(conStr);
        public Check_Reports()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Landing_Page l = new Landing_Page();
            l.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Admin_Dashboard a = new Admin_Dashboard();
            a.Show();
            this.Hide();
        }
        public DataTable dt = new DataTable();

        private void Check_Reports_Load(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("REPORTS", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.Rows.Clear();

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

        private void btnToday_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string date = DateTime.Now.ToString().Split(' ')[0];
            foreach (DataRow dr in dt.Rows)
            {
                if (dr[5].ToString().Equals(date))
                {
                    dataGridView1.Rows.Add(int.Parse(dr[0].ToString()), dr[1].ToString(), int.Parse(dr[2].ToString()), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString());
                }
            }
        }

        private void btnYesterday_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string date = DateTime.Now.ToString().Split(' ')[0];
            string day = (int.Parse(date.Split('/')[1])-1).ToString();
            string month = date.Split('/')[0];
            string year = date.Split('/')[2];
            string yester = month + "/" + day + "/" + year;
            //MessageBox.Show("Date: "+date+"\nYesterday: "+yester);
            foreach (DataRow dr in dt.Rows)
            {
                if (dr[5].ToString().Equals(yester))
                {
                    dataGridView1.Rows.Add(int.Parse(dr[0].ToString()), dr[1].ToString(), int.Parse(dr[2].ToString()), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString());
                }
            }
        }

        private void btnLastWeek_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                dataGridView1.Rows.Add(int.Parse(dr[0].ToString()), dr[1].ToString(), int.Parse(dr[2].ToString()), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString());
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Selected Reports Printed!!");
            
        }
    }
}
