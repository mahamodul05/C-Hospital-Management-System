﻿using System;
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
    public partial class UpdateDoctor : Form
    {
        public UpdateDoctor()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Doctor x = new Doctor();
            x.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-L87146T;Initial Catalog=HMS;Persist Security Info=True;User ID=sa;Password=12345");
            con.Open();
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "" || textBox9.Text == "" || textBox10.Text == "")
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
                        SqlCommand cmd = new SqlCommand("UPDATE stafflist SET DoctorID = @DoctorID , Name=@DoctorID, Gender= @Gender, Dateofbirth=@Dateofbirth, Contact=@Contact, Address = @Address, SpecialistType=@SpecialistType, Visitingdate=@Visitingdate, VisitingHour=@VisitingHour, Salary=@Salary WHERE DoctorID = @DoctorID", con);
                        cmd.Parameters.AddWithValue("@DoctorID", int.Parse(textBox1.Text));
                        cmd.Parameters.AddWithValue("@Name", textBox2.Text);
                        cmd.Parameters.AddWithValue("@Gender", textBox3.Text);
                        cmd.Parameters.AddWithValue("@Dateofbirth", dateTimePicker1.Value.ToString() + "");
                        cmd.Parameters.AddWithValue("@Contact", textBox5.Text);
                        cmd.Parameters.AddWithValue("@Address", textBox6.Text);
                        cmd.Parameters.AddWithValue("@SpecialistType", textBox7.Text);
                        cmd.Parameters.AddWithValue("@Visitingdate", textBox8.Text);
                        cmd.Parameters.AddWithValue("@VisitingHour", textBox9.Text);
                        cmd.Parameters.AddWithValue("@Salary", float.Parse(textBox10.Text));
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
                        textBox9.Text = "";
                        textBox10.Text = "";
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
            SqlCommand cmd = new SqlCommand("SELECT * from doctorlist", con);
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
            if (textBox4.Text == "" || textBox11.Text == "")
            {
                MessageBox.Show("Please fill required fields.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                SqlCommand check_User_Name = new SqlCommand("SELECT DoctorID FROM doctorlist WHERE (DoctorID = @DoctorID)", con);
                check_User_Name.Parameters.AddWithValue("@DoctorID", textBox4.Text);
                SqlDataReader reader = check_User_Name.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Close();
                    reader.Dispose();

                    try
                    {
                        SqlCommand cmd = new SqlCommand("UPDATE doctorlist SET DoctorID = @DoctorID, Salary = @Salary WHERE DoctorID = @DoctorID", con);
                        cmd.Parameters.AddWithValue("@DoctorID", int.Parse(textBox4.Text));
                        cmd.Parameters.AddWithValue("@Salary", textBox11.Text);
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
                    MessageBox.Show("Doctor NOT Exists.");
                }
            }


        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-L87146T;Initial Catalog=HMS;Persist Security Info=True;User ID=sa;Password=12345");
            con.Open();
            if (textBox12.Text == "" || textBox13.Text == "")
            {
                MessageBox.Show("Please fill required fields.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                SqlCommand check_User_Name = new SqlCommand("SELECT DoctorID FROM doctorlist WHERE (DoctorID = @DoctorID)", con);
                check_User_Name.Parameters.AddWithValue("@DoctorID", textBox12.Text);
                SqlDataReader reader = check_User_Name.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Close();
                    reader.Dispose();

                    try
                    {
                        SqlCommand cmd = new SqlCommand("UPDATE doctorlist SET DoctorID = @DoctorID, Visitingdate = @Visitingdate WHERE DoctorID = @DoctorID", con);
                        cmd.Parameters.AddWithValue("@DoctorID", int.Parse(textBox12.Text));
                        cmd.Parameters.AddWithValue("@Visitingdate", textBox13.Text);
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
                    MessageBox.Show("Doctor NOT Exists.");
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-L87146T;Initial Catalog=HMS;Persist Security Info=True;User ID=sa;Password=12345");
            con.Open();
            if (textBox14.Text == "" || textBox15.Text == "")
            {
                MessageBox.Show("Please fill required fields.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                SqlCommand check_User_Name = new SqlCommand("SELECT DoctorID FROM doctorlist WHERE (DoctorID = @DoctorID)", con);
                check_User_Name.Parameters.AddWithValue("@DoctorID", textBox14.Text);
                SqlDataReader reader = check_User_Name.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Close();
                    reader.Dispose();

                    try
                    {
                        SqlCommand cmd = new SqlCommand("UPDATE doctorlist SET DoctorID = @DoctorID, VisitingHour = @VisitingHour WHERE DoctorID = @DoctorID", con);
                        cmd.Parameters.AddWithValue("@DoctorID", int.Parse(textBox14.Text));
                        cmd.Parameters.AddWithValue("@VisitingHour", textBox15.Text);
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
                    MessageBox.Show("Doctor NOT Exists.");
                }
            }
        }
    }
}
