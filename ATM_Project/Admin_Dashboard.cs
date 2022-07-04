using System;
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
    public partial class Admin_Dashboard : Form
    {
        public Admin_Dashboard()
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
            Reg_user r = new Reg_user();
            r.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Add_AtmCard a = new Add_AtmCard();
            a.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Check_Cash c = new Check_Cash();
            c.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Check_Reports c = new Check_Reports();
            c.Show();
            this.Hide();
        }
    }
}
