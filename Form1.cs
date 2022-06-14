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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "Doctor" && textBox2.Text == "123")
            {
                this.Hide();
                DoctorDashboard d = new DoctorDashboard();
                d.Show();
            }
            else if(textBox1.Text == "Admin" && textBox2.Text == "123")
            {
                this.Hide();
                AdminDashboard a = new AdminDashboard();
                a.Show();               
            }
            else
            {
                MessageBox.Show("Usename and Password not correct.");
            }
        }
    }
}
