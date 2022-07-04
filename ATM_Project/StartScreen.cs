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
    public partial class StartScreen : Form
    {
        static string conStr = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=BankDB;Data Source=DESKTOP-8S8DEUD\SQLEXPRESS";
        SqlConnection con = new SqlConnection(conStr);
        public StartScreen()
        {
            InitializeComponent();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("START_MACHINE", con);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MachineID", tbMachineNo.Text);

                cmd.Parameters.Add("@n500", SqlDbType.Int).Value = 0;
                cmd.Parameters["@n500"].Direction = ParameterDirection.Output;

                cmd.Parameters.Add("@n1000", SqlDbType.Int).Value = 0;
                cmd.Parameters["@n1000"].Direction = ParameterDirection.Output;

                cmd.Parameters.Add("@n5000", SqlDbType.Int).Value = 0;
                cmd.Parameters["@n5000"].Direction = ParameterDirection.Output;

                cmd.Parameters.Add("@TotalCash", SqlDbType.Int).Value = 0;
                cmd.Parameters["@TotalCash"].Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                int n500 = int.Parse((cmd.Parameters["@n500"].Value).ToString());
                int n1000 = int.Parse((cmd.Parameters["@n1000"].Value).ToString());
                int n5000 = int.Parse((cmd.Parameters["@n5000"].Value).ToString());
                int TotalCash = int.Parse((cmd.Parameters["@TotalCash"].Value).ToString());

                Machine.MachineID = (cmd.Parameters["@MachineID"].Value).ToString() ;
                Machine.n500 = n500;
                Machine.n1000 = n1000;
                Machine.n5000 = n5000;
                Machine.TotalCash = TotalCash;

                Landing_Page l = new Landing_Page();
                l.Show();
                this.Hide();

            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void StartScreen_Load(object sender, EventArgs e)
        {
            //MessageBox.Show((20 * 5000).ToString() + "\n" + (20 * 1000).ToString() + "\n" + (20 * 500).ToString()+"\n"+ ((20 * 5000) + (20 * 1000) + (20 * 500)).ToString());
        }
    }
}
