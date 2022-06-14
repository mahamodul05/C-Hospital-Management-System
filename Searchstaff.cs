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
    public partial class Searchstaff : Form
    {
        public Searchstaff()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Staff a = new Staff();
            a.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-L87146T;Initial Catalog=HMS;Persist Security Info=True;User ID=sa;Password=12345");
            con.Open();

            if (textBox1.Text == "")
            {
                MessageBox.Show("Please fill required fields.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                SqlCommand check_User_Name = new SqlCommand("SELECT StaffID FROM stafflist WHERE (StaffID = @StaffID)", con);
                check_User_Name.Parameters.AddWithValue("@StaffID", textBox1.Text);
                SqlDataReader reader = check_User_Name.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Close();
                    reader.Dispose();
                    SqlCommand commandToCheckID = new SqlCommand("SELECT StaffID FROM stafflist WHERE StaffID = '" + int.Parse(textBox1.Text) + "'", con);
                    SqlCommand cmd = new SqlCommand("SELECT * FROM stafflist WHERE StaffID=@StaffID", con);
                    cmd.Parameters.AddWithValue("@StaffID", int.Parse(textBox1.Text));
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Staff not Exists.");
                }
            }
        }
    }
}
