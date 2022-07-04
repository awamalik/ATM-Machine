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
    public partial class Reg_user : Form
    {
        static string conStr = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=BankDB;Data Source=DESKTOP-8S8DEUD\SQLEXPRESS";
        SqlConnection con = new SqlConnection(conStr);
        public string path="";
        public Reg_user()
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

        private void tbName_MouseDown(object sender, MouseEventArgs e)
        {
            tbName.Text = null;
            tbName.ForeColor = Color.Black;
        }

        private void tbCNIC_MouseDown(object sender, MouseEventArgs e)
        {
            tbCNIC.Text = null;
            tbName.ForeColor = Color.Black;
        }

        private void tbPassword_MouseDown(object sender, MouseEventArgs e)
        {
            tbPassword.Text = null;
            tbPassword.ForeColor = Color.Black;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("REG_NEW_ADMIN", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PASS", tbPassword.Text.ToString());
                    cmd.Parameters.AddWithValue("@NAME", tbName.Text.ToString());
                    cmd.Parameters.AddWithValue("@CNIC", tbCNIC.Text.ToString());
                    cmd.Parameters.AddWithValue("@PIC", path.ToString());
                    cmd.Parameters.AddWithValue("@ROLE", cbRole.SelectedItem.ToString());

                    
                    cmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                
                con.Close();
                MessageBox.Show("User Registered Successfully!!");
                new Admin_Dashboard().Show();
                this.Hide();
                }
            }

        private void btnBrowsePic_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            // image filters  
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box  
                pictureBox1.Image = new Bitmap(open.FileName);
                // image file path  
                 path = open.FileName;
            }
    }

    
    }
}