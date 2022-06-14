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
    public partial class Doctor : Form
    {
        public Doctor()
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
            Adddoctor x = new Adddoctor();
            x.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            UpdateDoctor x = new UpdateDoctor();
            x.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Hide();
            SearchDoctor x = new SearchDoctor();
            x.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            DeleteDoctor x = new DeleteDoctor();
            x.Show();
        }
    }
}
