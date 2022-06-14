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
    public partial class Searchroom : Form
    {
        public Searchroom()
        {
            InitializeComponent();
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

                SqlCommand check_User_Name = new SqlCommand("SELECT RoomNo FROM roomlist WHERE (RoomNo = @RoomNo)", con);
                check_User_Name.Parameters.AddWithValue("@RoomNo", textBox1.Text);
                SqlDataReader reader = check_User_Name.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Close();
                    reader.Dispose();
                    SqlCommand commandToCheckID = new SqlCommand("SELECT RoomNo FROM roomlist WHERE RoomNo = '" + int.Parse(textBox1.Text) + "'", con);
                    SqlCommand cmd = new SqlCommand("SELECT * FROM roomlist WHERE RoomNo=@RoomNo", con);
                    cmd.Parameters.AddWithValue("@RoomNo", int.Parse(textBox1.Text));
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Room NOT Exists.");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-L87146T;Initial Catalog=HMS;Persist Security Info=True;User ID=sa;Password=12345");
            con.Open();

            if (textBox2.Text == "")
            {
                MessageBox.Show("Please fill required fields.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
               

                SqlCommand check_User_Name = new SqlCommand("SELECT RoomType FROM roomlist WHERE (RoomType = @RoomType)", con);
                check_User_Name.Parameters.AddWithValue("@RoomType", textBox2.Text);
                SqlDataReader reader = check_User_Name.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Close();
                    reader.Dispose();
                    SqlCommand commandToCheckID = new SqlCommand("SELECT RoomType FROM roomlist WHERE RoomType = '" + textBox2.Text + "'", con);
                    SqlCommand cmd = new SqlCommand("SELECT * FROM roomlist WHERE RoomType=@RoomType", con);
                    cmd.Parameters.AddWithValue("@RoomType", textBox2.Text);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("NO ICU Room Free / Exists.");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Room x = new Room();
            x.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-L87146T;Initial Catalog=HMS;Persist Security Info=True;User ID=sa;Password=12345");
            con.Open();

            if (textBox3.Text == "")
            {
                MessageBox.Show("Please fill required fields.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {


                SqlCommand check_User_Name = new SqlCommand("SELECT RoomType FROM roomlist WHERE (RoomType = @RoomType)", con);
                check_User_Name.Parameters.AddWithValue("@RoomType", textBox3.Text);
                SqlDataReader reader = check_User_Name.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Close();
                    reader.Dispose();
                    SqlCommand commandToCheckID = new SqlCommand("SELECT RoomType FROM roomlist WHERE RoomType = '" + textBox3.Text + "'", con);
                    SqlCommand cmd = new SqlCommand("SELECT * FROM roomlist WHERE RoomType=@RoomType", con);
                    cmd.Parameters.AddWithValue("@RoomType", textBox3.Text);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("No General Room Free / Exists.");
                }
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-L87146T;Initial Catalog=HMS;Persist Security Info=True;User ID=sa;Password=12345");
            con.Open();

            if (textBox4.Text == "")
            {
                MessageBox.Show("Please fill required fields.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {


                SqlCommand check_User_Name = new SqlCommand("SELECT Status FROM roomlist WHERE (Status = @Status)", con);
                check_User_Name.Parameters.AddWithValue("@RoomType", textBox3.Text);
                SqlDataReader reader = check_User_Name.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Close();
                    reader.Dispose();
                    SqlCommand commandToCheckID = new SqlCommand("SELECT Status FROM roomlist WHERE Status = '" + textBox4.Text + "'", con);
                    SqlCommand cmd = new SqlCommand("SELECT * FROM roomlist WHERE Status=@Status", con);
                    cmd.Parameters.AddWithValue("@Status", textBox3.Text);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("All Room Are Booked.");
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Addroom x = new Addroom();
            x.Show();
        }

    }
}
