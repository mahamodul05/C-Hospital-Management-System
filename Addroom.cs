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
    public partial class Addroom : Form
    {
        public Addroom()
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

                    MessageBox.Show("That RoomNo already exixt");


                }
                else
                {
                    reader.Close();
                    reader.Dispose();
                    try
                    {


                        SqlCommand cmd = new SqlCommand("INSERT INTO roomlist(RoomNo, RoomType, BedRent, Status) VALUES(@RoomNo, @RoomType, @BedRent, @Status)", con);
                        cmd.Parameters.AddWithValue("@RoomNo", int.Parse(textBox1.Text));
                        cmd.Parameters.AddWithValue("@RoomType", textBox2.Text);
                        cmd.Parameters.AddWithValue("@BedRent", textBox3.Text);
                        cmd.Parameters.AddWithValue("@Status", textBox4.Text);
                        
                        cmd.ExecuteNonQuery();
                        con.Close();

                        BindData();
                        MessageBox.Show("Successfully Inserted", "Seccess", MessageBoxButtons.OK, MessageBoxIcon.Information);

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


        private void button3_Click_1(object sender, EventArgs e)
        {
            BindData();
        }
    }
}
