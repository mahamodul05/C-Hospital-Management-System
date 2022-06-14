using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_10
{
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Doctor x = new Doctor();
            x.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 x = new Form1();
            x.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Staff x = new Staff();
            x.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Room x = new Room();
            x.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Patient x = new Patient();
            x.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Appointment x = new Appointment();
            x.Show();
        }
    }
}
