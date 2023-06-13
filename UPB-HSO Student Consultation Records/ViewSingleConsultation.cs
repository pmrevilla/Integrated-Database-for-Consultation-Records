using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities.Encoders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UPB_HSO_Student_Consultation_Records
{
    public partial class ViewSingleConsultation : Form
    {
        public ViewSingleConsultation(string studentNumber, string dateOfCon, string timeOfCon, string p_PEALF, string p_DAM, string editedDate, string timeEdited)
        {
            InitializeComponent();
            this.studentNo.Text = studentNumber;
            this.consultationDate.Text = dateOfCon;
            this.consultationTime.Text = timeOfCon;
            this.findings.Text = p_PEALF;
            this.diagnosis.Text = p_DAM;
            this.editedDateTime.Text = editedDate + " " + timeEdited;

            string connectionString = ConfigurationManager.ConnectionStrings["ConString"].ToString();
            MySqlConnection myConnection = new MySqlConnection(connectionString);
            myConnection.Open();
            string query = "SELECT * FROM patient_consultation WHERE Patient_StudentNumber = @StudentNumber ORDER BY Patient_ConsultationDate DESC, Patient_ConsultationTime DESC";

            MySqlCommand mySqlCommand = new MySqlCommand(query, myConnection);
            mySqlCommand.Parameters.AddWithValue("@StudentNumber", studentNumber);

            MySqlDataReader reader = mySqlCommand.ExecuteReader();

            while (reader.Read())
            {
                DateTime consultationDate = DateTime.Parse(reader["Patient_ConsultationDate"].ToString());
                string formattedConsultationDate = consultationDate.ToString("yyyy-MM-dd");

                string consultationTime = reader["Patient_ConsultationTime"].ToString();
                string physicalExamination = reader["Patient_PhysicalExaminationAndLaboratoryFindings"].ToString();
                string diagnosisAndManagement = reader["Patient_DiagnosisAndManagement"].ToString();

            }

            myConnection.Close();


        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewRecentConsultation viewRecentConsultation = new ViewRecentConsultation();
            viewRecentConsultation.Show();
            
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string studNo = studentNo.Text;
            string studentNumber = studNo.ToString();


            string connectionString = ConfigurationManager.ConnectionStrings["ConString"].ToString();
            MySqlConnection myConnection = new MySqlConnection(connectionString);

            myConnection.Open();
            string query = @"SELECT pi.*, pmh.*, pcon.*
                FROM patient_info pi
                JOIN patient_medicalhistory pmh ON pi.Patient_StudentNumber = pmh.Patient_StudentNumber
                JOIN patient_consultation pcon ON pi.Patient_StudentNumber = pcon.Patient_StudentNumber
                WHERE pi.Patient_StudentNumber = @StudentNumber";

            MySqlCommand mySqlCommand = new MySqlCommand(query, myConnection);
            mySqlCommand.Parameters.AddWithValue("@StudentNumber", studentNumber);

            MySqlDataReader reader = mySqlCommand.ExecuteReader();

            if (reader.Read())
            {
                string lastName = reader["Patient_LastName"].ToString();
                string firstName = reader["Patient_FirstName"].ToString();
                string middleName = reader["Patient_MiddleName"].ToString();
                string birthDate = reader["Patient_Birthdate"].ToString();
                string college = reader["Patient_College"].ToString();
                string course = reader["Patient_Course"].ToString();
                string age = reader["Patient_Age"].ToString();
                string sex = reader["Patient_Sex"].ToString();
                string civStatus = reader["Patient_CivilStatus"].ToString();
                string address = reader["Patient_Address"].ToString();
                string contactNumber = reader["Patient_ContactNumber"].ToString();
                string contactPerson = reader["Patient_ContactPerson"].ToString();
                string contactPersonNum = reader["Patient_ContactPersonNum"].ToString();

                string famHisto = reader["Patient_FamilyHistory"].ToString();
                string pastMedicalHisto = reader["Patient_PastMedicalHistory"].ToString();
                string historyOfAllergies = reader["Patient_HistoryOfAllergies"].ToString();

                DateTime conDate = DateTime.Parse(reader["Patient_ConsultationDate"].ToString());
                string dateOfCon = conDate.ToString("yyyy-MM-dd");

                string timeOfCon = reader["Patient_ConsultationTime"].ToString();
                string p_PEALF = reader["Patient_PhysicalExaminationAndLaboratoryFindings"].ToString();
                string p_DAM = reader["Patient_DiagnosisAndManagement"].ToString();

                DateTime conEditedDate = DateTime.Parse(reader["Patient_DateEdited"].ToString());
                string dateEditedOfCon = conEditedDate.ToString("yyyy-MM-dd");

                string timeEditedOfCon = reader["Patient_TimeEdited"].ToString();

                ViewPatientRecord2 viewPatientRecord = new ViewPatientRecord2(studentNumber, lastName, firstName, middleName, birthDate, course,
            college, age, sex, civStatus, address, contactNumber, contactPerson, contactPersonNum, famHisto, pastMedicalHisto, historyOfAllergies,
                        dateOfCon, timeOfCon, p_PEALF, p_DAM, dateEditedOfCon, timeEditedOfCon);
                viewPatientRecord.Show();
                this.Hide();
            }
        }
    }
}
