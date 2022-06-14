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
    public partial class Addappointment : Form
    {
        public Addappointment()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Appointment x = new Appointment();
            x.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-L87146T;Initial Catalog=HMS;Persist Security Info=True;User ID=sa;Password=12345");
            con.Open();
            if (textBox1.Text == "" || textBox2.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Please fill required fields.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {

                SqlCommand check_User_Name = new SqlCommand("SELECT PatientID FROM patientlist WHERE (PatientID = @PatientID)", con);
                check_User_Name.Parameters.AddWithValue("@PatientID", textBox1.Text);
                SqlDataReader reader = check_User_Name.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Close();
                    reader.Dispose();

                    SqlCommand check_User_Name1 = new SqlCommand("SELECT DoctorID FROM doctorlist WHERE (DoctorID = @DoctorID)", con);
                    check_User_Name.Parameters.AddWithValue("@DoctortID", textBox2.Text);
                    SqlDataReader reader1 = check_User_Name.ExecuteReader();

                    if (reader1.HasRows)
                    {
                        reader1.Close();
                        reader1.Dispose();

                        try
                        {
                            SqlCommand cmd = new SqlCommand("INSERT INTO appointment(PatientID, DoctorID, Appointmentdate, Appointmenttime) VALUES(@PatientID, @DoctorID, @Appointmentdate, @Appointmenttime)", con);
                            cmd.Parameters.AddWithValue("@PatientID", int.Parse(textBox1.Text));
                            cmd.Parameters.AddWithValue("@DoctorID", int.Parse(textBox2.Text));
                            cmd.Parameters.AddWithValue("@Appointmentdate", dateTimePicker1.Value.ToString() + "");
                            cmd.Parameters.AddWithValue("@Appointmenttime", textBox4.Text);

                            cmd.ExecuteNonQuery();
                            con.Close();

                            BindData();
                            MessageBox.Show("Successfully Inserted", "Seccess", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            textBox1.Text = "";
                            textBox2.Text = "";
                            textBox4.Text = "";
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                    }

                    else
                    {
                        MessageBox.Show("Doctor not Exist.");
                    }

                }

                else
                {
                    MessageBox.Show("Patient not Exist.");
                }

            }
                              
        }

        void BindData()
        {
            DataTable dt = appointment();
            dataGridView1.DataSource = dt;

        }

        private DataTable appointment()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-L87146T;Initial Catalog=HMS;Persist Security Info=True;User ID=sa;Password=12345");
            con.Open();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("SELECT * from appointment", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }


        void BindDataa()
        {
            DataTable dt = doctorslist();
            dataGridView1.DataSource = dt;

        }

        private DataTable doctorslist()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-L87146T;Initial Catalog=HMS;Persist Security Info=True;User ID=sa;Password=12345");
            con.Open();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("SELECT DoctorID, Name, SpecialistType from doctorlist", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }




        private void button3_Click(object sender, EventArgs e)
        {
            BindData();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            BindDataa();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddPatient x = new AddPatient();
            x.Show();
        }
    }
}
