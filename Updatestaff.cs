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
    public partial class Updatestaff : Form
    {
        public Updatestaff()
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
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "")
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

                    try
                    {
                        SqlCommand cmd = new SqlCommand("UPDATE stafflist SET StaffID = @StaffID, Name = @Name, Gender = @Gender, Dateofbirth = @Dateofbirth, Address = @Address, Contact=@Contact, Salary=@Salary, Position=@Position  WHERE StaffID = @StaffID", con);
                        cmd.Parameters.AddWithValue("@StaffID", int.Parse(textBox1.Text));
                        cmd.Parameters.AddWithValue("@Name", textBox2.Text);
                        cmd.Parameters.AddWithValue("@Gender", textBox3.Text);
                        cmd.Parameters.AddWithValue("@Dateofbirth", dateTimePicker1.Value.ToString() + "");
                        cmd.Parameters.AddWithValue("@Address", textBox5.Text);
                        cmd.Parameters.AddWithValue("@Contact", textBox6.Text);
                        cmd.Parameters.AddWithValue("@Salary", textBox7.Text);
                        cmd.Parameters.AddWithValue("@Position", textBox8.Text);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        BindData();
                        MessageBox.Show("Successfully Updated.", "Seccess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox5.Text = "";
                        textBox6.Text = "";
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
            SqlCommand cmd = new SqlCommand("SELECT * from stafflist", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BindData();
        }
    }
    
}
