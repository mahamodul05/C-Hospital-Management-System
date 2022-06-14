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
    public partial class Updateroom : Form
    {
        public Updateroom()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Room a = new Room();
            a.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-L87146T;Initial Catalog=HMS;Persist Security Info=True;User ID=sa;Password=12345");
            con.Open();
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
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

                    try
                    {
                        SqlCommand cmd = new SqlCommand("UPDATE roomlist SET RoomNo = @RoomNo, RoomType = @RoomType, BedRent = @BedRent, Status = @Status  WHERE RoomNo = @RoomNo", con);
                        cmd.Parameters.AddWithValue("@RoomNo", int.Parse(textBox1.Text));
                        cmd.Parameters.AddWithValue("@RoomType", textBox2.Text);
                        cmd.Parameters.AddWithValue("@BedRent", textBox3.Text);
                        cmd.Parameters.AddWithValue("@Status", textBox4.Text);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        BindData();
                        MessageBox.Show("Successfully Updated.", "Seccess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
                else
                {
                    MessageBox.Show("User NOT Exists.");
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
            SqlCommand cmd = new SqlCommand("SELECT * from roomlist", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BindData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-L87146T;Initial Catalog=HMS;Persist Security Info=True;User ID=sa;Password=12345");
            con.Open();
            if (textBox6.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Please fill required fields.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                SqlCommand check_User_Name = new SqlCommand("SELECT RoomNo FROM roomlist WHERE (RoomNo = @RoomNo)", con);
                check_User_Name.Parameters.AddWithValue("@RoomNo", textBox6.Text);
                SqlDataReader reader = check_User_Name.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Close();
                    reader.Dispose();

                    try
                    {
                        SqlCommand cmd = new SqlCommand("UPDATE roomlist SET RoomNo = @RoomNo, RoomType = @RoomType WHERE RoomNo = @RoomNo", con);
                        cmd.Parameters.AddWithValue("@RoomNo", int.Parse(textBox6.Text));
                        cmd.Parameters.AddWithValue("@RoomType", textBox5.Text);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        BindData();
                        MessageBox.Show("Successfully Updated.", "Seccess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox5.Text = "";
                        textBox6.Text = "";
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
                else
                {
                    MessageBox.Show("User NOT Exists.");
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-L87146T;Initial Catalog=HMS;Persist Security Info=True;User ID=sa;Password=12345");
            con.Open();
            if (textBox8.Text == "" || textBox7.Text == "")
            {
                MessageBox.Show("Please fill required fields.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                SqlCommand check_User_Name = new SqlCommand("SELECT RoomNo FROM roomlist WHERE (RoomNo = @RoomNo)", con);
                check_User_Name.Parameters.AddWithValue("@RoomNo", textBox8.Text);
                SqlDataReader reader = check_User_Name.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Close();
                    reader.Dispose();

                    try
                    {
                        SqlCommand cmd = new SqlCommand("UPDATE roomlist SET RoomNo = @RoomNo, BedRent = @BedRent WHERE RoomNo = @RoomNo", con);
                        cmd.Parameters.AddWithValue("@RoomNo", int.Parse(textBox8.Text));
                        cmd.Parameters.AddWithValue("@BedRent", textBox7.Text);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        BindData();
                        MessageBox.Show("Successfully Updated.", "Seccess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox7.Text = "";
                        textBox8.Text = "";
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
                else
                {
                    MessageBox.Show("User NOT Exists.");
                }


            }




        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-L87146T;Initial Catalog=HMS;Persist Security Info=True;User ID=sa;Password=12345");
            con.Open();
            if (textBox10.Text == "" || textBox9.Text == "")
            {
                MessageBox.Show("Please fill required fields.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                SqlCommand check_User_Name = new SqlCommand("SELECT RoomNo FROM roomlist WHERE (RoomNo = @RoomNo)", con);
                check_User_Name.Parameters.AddWithValue("@RoomNo", textBox10.Text);
                SqlDataReader reader = check_User_Name.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Close();
                    reader.Dispose();

                    try
                    {
                        SqlCommand cmd = new SqlCommand("UPDATE roomlist SET RoomNo = @RoomNo, Status = @Status  WHERE RoomNo = @RoomNo", con);
                        cmd.Parameters.AddWithValue("@RoomNo", int.Parse(textBox10.Text));
                        cmd.Parameters.AddWithValue("@Status", textBox9.Text);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        BindData();
                        MessageBox.Show("Successfully Updated.", "Seccess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox10.Text = "";
                        textBox9.Text = "";
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
                else
                {
                    MessageBox.Show("User NOT Exists.");
                }


            }
        }



    }
}
