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
    public partial class Patient : Form
    {
        public Patient()
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
            AddPatient x = new AddPatient();
            x.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Updatepatient x = new Updatepatient();
            x.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Hide();
            SearchPatient x = new SearchPatient();
            x.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            DeletePatient x = new DeletePatient();
            x.Show();
        }
    }
}
