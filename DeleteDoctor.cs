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
    public partial class DeleteDoctor : Form
    {
        public DeleteDoctor()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Doctor x = new Doctor();
            x.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BindData();
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
                SqlCommand check_User_Name = new SqlCommand("SELECT DoctorID FROM doctorlist WHERE (DoctorID = @DoctorID)", con);
                check_User_Name.Parameters.AddWithValue("@DoctorID", textBox1.Text);
                SqlDataReader reader = check_User_Name.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Close();
                    reader.Dispose();

                    try
                    {
                        SqlCommand cmd = new SqlCommand("DELETE doctorlist WHERE DoctorID=@DoctorID", con);
                        cmd.Parameters.AddWithValue("@DoctorID", int.Parse(textBox1.Text));
                        cmd.ExecuteNonQuery();
                        con.Close();
                        BindData();
                        MessageBox.Show("Successfully Deleted");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

                else
                {
                    MessageBox.Show("Doctor NOT Exists.");
                }
            }


        }

        void BindData()
        {
            DataTable dt = doctorslist();
            dataGridView1.DataSource = dt;

        }

        private DataTable doctorslist()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-L87146T;Initial Catalog=HMS;Persist Security Info=True;User ID=sa;Password=12345");
            con.Open();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("SELECT * from Doctorlist", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }


    }
}
