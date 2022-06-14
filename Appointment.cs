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
    public partial class Appointment : Form
    {
        public Appointment()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminDashboard x = new AdminDashboard();
            x.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Addappointment x = new Addappointment();
            x.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Hide();
            Searchappointment x = new Searchappointment();
            x.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Deleteappointment x = new Deleteappointment();
            x.Show();
        }
        
    }
}
