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
    public partial class Staff : Form
    {
        public Staff()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Addstaff x = new Addstaff();
            x.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminDashboard x = new AdminDashboard();
            x.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Updatestaff x = new Updatestaff();
            x.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Hide();
            Searchstaff x = new Searchstaff();
            x.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            DeleteStaff x = new DeleteStaff();
            x.Show();
        }
    }
}
