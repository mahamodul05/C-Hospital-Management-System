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
    public partial class AddPatient : Form
    {
        public AddPatient()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Patient a = new Patient();
            a.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-L87146T;Initial Catalog=HMS;Persist Security Info=True;User ID=sa;Password=12345");
            con.Open();
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "" || textBox10.Text == "" || textBox11.Text == "" || textBox12.Text == "" || textBox13.Text == "" || textBox14.Text == "" || textBox15.Text == "")
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

                    MessageBox.Show("That Patient ID already exixt");


                }
                else
                {
                    reader.Close();
                    reader.Dispose();
                    try
                    {


                        SqlCommand cmd = new SqlCommand("INSERT INTO patientlist (PatientID, Name, Gender, Dateofbirth, Contact, Address, Disease, Status, Admitdate, RoomNo, Observationdoctor, Medicine, OT, Test, Totalbill, Dischargedate) VALUES( @PatientID, @Name, @Gender, @Dateofbirth, @Contact, @Address, @Disease, @Status, @Admitdate, @RoomNo, @Observationdoctor, @Medicine, @OT, @Test, @Totalbill, @Dischargedate)", con);
                        cmd.Parameters.AddWithValue("@PatientID", Convert.ToInt32(textBox1.Text));
                        cmd.Parameters.AddWithValue("@Name", textBox2.Text);
                        cmd.Parameters.AddWithValue("@Gender", textBox3.Text);
                        cmd.Parameters.AddWithValue("@Dateofbirth", dateTimePicker1.Value.ToString() + "");
                        cmd.Parameters.AddWithValue("@Contact", textBox5.Text);
                        cmd.Parameters.AddWithValue("@Address", textBox6.Text);
                        cmd.Parameters.AddWithValue("@Disease", textBox7.Text);
                        cmd.Parameters.AddWithValue("@Status", textBox8.Text);
                        cmd.Parameters.AddWithValue("@Admitdate", dateTimePicker2.Value.ToString() + "");
                        cmd.Parameters.AddWithValue("@RoomNo", int.Parse(textBox10.Text));
                        cmd.Parameters.AddWithValue("@Observationdoctor", textBox11.Text);
                        cmd.Parameters.AddWithValue("@Medicine", textBox12.Text);
                        cmd.Parameters.AddWithValue("@OT", textBox13.Text);
                        cmd.Parameters.AddWithValue("@Test", textBox14.Text);
                        cmd.Parameters.AddWithValue("@Totalbill", float.Parse(textBox15.Text));
                        cmd.Parameters.AddWithValue("@Dischargedate", dateTimePicker3.Value.ToString() + "");

                        cmd.ExecuteNonQuery();
                        con.Close();

                        BindData();
                        MessageBox.Show("Successfully Inserted", "Seccess", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox5.Text = "";
                        textBox6.Text = "";
                        textBox7.Text = "";
                        textBox8.Text = "";
                        textBox10.Text = "";
                        textBox11.Text = "";
                        textBox12.Text = "";
                        textBox13.Text = "";
                        textBox14.Text = "";
                        textBox15.Text = "";
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
            DataTable dt = patientlist();
            dataGridView1.DataSource = dt;

        }

        private DataTable patientlist()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-L87146T;Initial Catalog=HMS;Persist Security Info=True;User ID=sa;Password=12345");
            con.Open();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("SELECT * from patientlist", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        private void AddPatient_Load(object sender, EventArgs e)
        {

        }
    }
}
