using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Windows.Forms;

namespace UPB_HSO_Student_Consultation_Records
{
    public partial class AddNewPatient : Form
    {
        public AddNewPatient()
        {
            InitializeComponent();
            this.confirmBtn.Click += new EventHandler(loginBtn_Click);
        }


        private void AddNewPatient_Load(object sender, EventArgs e)
        {
           
        }
        public void Alert(string msg, AlertBox.enmType type)
        {
            AlertBox alert = new AlertBox();
            alert.showAlert(msg, type);
        }

        /*
        public void Message(string msg,  MessageBox.enmType type)
        {
            MessageBox message = new MessageBox();
            message.showMessage(msg, type);
        }
        */

        private void contactNo_TextChanged(object sender, EventArgs e)
        {
            if(contactNo.TextLength == 11)
            {
                contactNo.ForeColor = Color.Black;
            }
            else
            {
                contactNo.ForeColor = Color.Maroon;
            }
        }

        private void contactNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                this.Alert("Field accepts numbers only", AlertBox.enmType.Error);
                this.contactNo.Focus();
                return;
            }
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lastName.Text))
            {
            
                this.Alert("Please Enter Last Name", AlertBox.enmType.Error);
                this.lastName.Focus();
                return;
            }
            if (string.IsNullOrEmpty(firstName.Text))
            {
                this.Alert("Please Enter First Name", AlertBox.enmType.Error);
                this.firstName.Focus();
                return;
            }
            if (string.IsNullOrEmpty(middleName.Text))
            {
                this.Alert("Please Enter Middle Name", AlertBox.enmType.Error);
                this.middleName.Focus();
                return;
            }
            if (string.IsNullOrEmpty(studentNo.Text))
            {
                this.Alert("Please Enter Student Number", AlertBox.enmType.Error);
                this.studentNo.Focus();
                return;
            }
            if (string.IsNullOrEmpty(address.Text))
            {
                this.Alert("Please Enter Address", AlertBox.enmType.Error);
                this.address.Focus();
                return;
            }
            if (string.IsNullOrEmpty(contactNo.Text))
            {
                this.Alert("Please Enter Contact Number", AlertBox.enmType.Error);
                this.contactNo.Focus();
                return;
            }
            if (string.IsNullOrEmpty(age.Text))
            {
                this.Alert("Please Enter Age", AlertBox.enmType.Error);
                this.age.Focus();
                return;
            }
            if (string.IsNullOrEmpty(birthDate.Value.ToString()))
            {
                this.Alert("Please Enter Birth Date", AlertBox.enmType.Error);
                this.birthDate.Focus();
                return;
            }
            if (string.IsNullOrEmpty(civStatus.Text))
            {
                this.Alert("Please Enter Civil Status", AlertBox.enmType.Error);
                this.civStatus.Focus();
                return;
            }
            if (string.IsNullOrEmpty(college.Text))
            {
                this.Alert("Please Enter College", AlertBox.enmType.Error);
                this.college.Focus();
                return;
            }
            if (string.IsNullOrEmpty(course.Text))
            {
                this.Alert("Please Enter Course", AlertBox.enmType.Error);
                this.course.Focus();
                return;
            }
            if (string.IsNullOrEmpty(contactPerson.Text))
            {
                this.Alert("Please Enter Contact Person", AlertBox.enmType.Error);
                this.contactPerson.Focus();
                return;
            }
            if (string.IsNullOrEmpty(contactPersonNum.Text))
            {
                this.Alert("Please Enter Contact Person Number", AlertBox.enmType.Error);
                this.contactPersonNum.Focus();
                return;
            }
            String connectionString = ConfigurationManager.ConnectionStrings["ConString"].ToString();
            MySqlConnection myConnection = new MySqlConnection(connectionString);

            myConnection.Open();
            string query = "INSERT INTO patient_info (Patient_StudentNumber, Patient_LastName, Patient_FirstName, Patient_MiddleName, Patient_BirthDate, Patient_Age, Patient_Sex, Patient_CivilStatus, Patient_Address, Patient_College, Patient_Course, Patient_ContactNumber, Patient_ContactPerson, Patient_ContactPersonNum  ) " +
                "VALUES (@studentNumber, @lastName, @firstName, @middleName, @birthDate, @age, @sex, @civStatus, @address, @college, @course, @contactNumber, @contactPerson, @contactPersonNumber)";

            MySqlCommand myCommand = new MySqlCommand(query, myConnection);
            myCommand.Parameters.AddWithValue("@studentNumber", studentNo.Text);
            myCommand.Parameters.AddWithValue("@lastName", lastName.Text);
            myCommand.Parameters.AddWithValue("@firstName", firstName.Text);
            myCommand.Parameters.AddWithValue("@middleName", middleName.Text);
            myCommand.Parameters.AddWithValue("@birthDate", birthDate.Value.ToString("yyyy-MM-dd"));
            myCommand.Parameters.AddWithValue("@age", age.Text);
            myCommand.Parameters.AddWithValue("@sex", sex.SelectedItem);
            myCommand.Parameters.AddWithValue("@civStatus", civStatus.SelectedItem);
            myCommand.Parameters.AddWithValue("@address", address.Text);
            myCommand.Parameters.AddWithValue("@college", college.SelectedItem);
            myCommand.Parameters.AddWithValue("@course", course.SelectedItem);
            myCommand.Parameters.AddWithValue("@contactNumber", contactNo.Text);
            myCommand.Parameters.AddWithValue("@contactPerson", contactPerson.Text);
            myCommand.Parameters.AddWithValue("@contactPersonNumber", contactPersonNum.Text);
            myCommand.ExecuteNonQuery();
            myConnection.Close();
            
            myConnection.Open();
            string query1 = "INSERT INTO patient_medicalhistory (Patient_StudentNumber, Patient_FamilyHistory, Patient_PastMedicalHistory, Patient_HistoryOfAllergies) " +
                "VALUES (@studentNumber1, @famHisto, @pastMedHisto, @histoAllergy)";

            MySqlCommand myCommand1 = new MySqlCommand(query1, myConnection);
            myCommand1.Parameters.AddWithValue("@studentNumber1", studentNo.Text);

            List<string> checkedValues = new List<string>();

            if (hypertension.Checked) checkedValues.Add("Hypertension");
            if (diabetes.Checked) checkedValues.Add("Diabetes");
            if (cancer.Checked) checkedValues.Add("Cancer");
            if (bronchialAsthma.Checked) checkedValues.Add("Bronchial Asthma");
            if (stroke.Checked) checkedValues.Add("Stroke");
            if (heartDisease.Checked) checkedValues.Add("Heart Disease");

            string famHisto = string.Join(", ", checkedValues);

            myCommand1.Parameters.AddWithValue("@famHisto", famHisto);
            myCommand1.Parameters.AddWithValue("@pastMedHisto", pastMedHisto.Text);
            myCommand1.Parameters.AddWithValue("@histoAllergy", histoAllergy.Text);
            myCommand1.ExecuteNonQuery();
            myConnection.Close();

            this.Alert("Patient Information Added Successfully!", AlertBox.enmType.Success);

            var popup = System.Windows.Forms.MessageBox.Show("Add consultation record for this patient?", "Add Consultation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (popup == DialogResult.Yes)
            {
                this.Hide();
                AddNewConsultation_updated addNewConsultation = new AddNewConsultation_updated();
                addNewConsultation.Show();
            }

            else if (popup == DialogResult.No)
            {
                this.Hide();
                dashboard dashboard = new dashboard();
                dashboard.Show();
            }

                

            /*
            dashboard dashboard = new dashboard();
            dashboard.Show();
            this.Hide();
            */
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            dashboard dashboard = new dashboard();
            dashboard.Show();
            this.Hide();
        }

        private void lastName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
         

        }

        private void loginBtn_Click_1(object sender, EventArgs e)
        {
            
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void address_TextChanged(object sender, EventArgs e)
        {

        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            var popup = System.Windows.Forms.MessageBox.Show("Information you entered may not be saved. Exit window?", "Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            
            if (popup == DialogResult.Yes)
            {
                this.Hide();
                dashboard dashboard = new dashboard();
                dashboard.Show();
            }

        }

        private void pastMedHisto_TextChanged(object sender, EventArgs e)
        {

        }

        private void contactPersonNum_TextChanged(object sender, EventArgs e)
        {
            if (contactPersonNum.TextLength == 11)
            {
                contactPersonNum.ForeColor = Color.Black;
            }
            else
            {
                contactPersonNum.ForeColor = Color.Maroon;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
