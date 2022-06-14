using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_10
{
    public partial class Room : Form
    {
        public Room()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Addroom x = new Addroom();
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
            Updateroom x = new Updateroom();
            x.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Hide();
            Searchroom x = new Searchroom();
            x.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Deleteroom x = new Deleteroom();
            x.Show();
        }
        private DataTable member()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-L87146T;Initial Catalog=HMS;Persist Security Info=True;User ID=sa;Password=12345");
            con.Open();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("SELECT * from roomlist", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        void BindData()
        {
            DataTable dt = member();
            dataGridView1.DataSource = dt;

        }
        private void button4_Click(object sender, EventArgs e)
        {
            BindData();
        }
    }
}
