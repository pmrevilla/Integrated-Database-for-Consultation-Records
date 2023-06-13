using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UPB_HSO_Student_Consultation_Records
{
    public partial class ViewPatientRecord2 : Form
    {
        public ViewPatientRecord2(string studentNumber, string lastName, string firstName, string middleName, string birthdate, string course,
        string college, string age, string sex, string civStatus, string address, string contactNumber, string contactPerson, string contactPersonNum,
        string famHisto, string pastMedicalHisto, string historyOfAllergies, string dateOfCon, string timeOfCon, string p_PEALF, string p_DAM,
        string dateEditedOfCon, string timeEditedOfCon)
        {
            InitializeComponent();
           

            // Set the patient's information in the form controls
            this.studentNo.Text = studentNumber;
            this.lastName.Text = lastName;
            this.firstName.Text = firstName;
            this.middleName.Text = middleName;
            this.birthdate.Text = birthdate;
            this.age.Text = age;
            this.sex.Text = sex;
            this.civilStatus.Text = civStatus;
            this.address.Text = address;
            this.contactNo.Text = contactNumber;
            this.contactPerson.Text = contactPerson;
            this.contactPersonNo.Text = contactPersonNum;
            this.college.Text = college;
            this.course.Text = course;

            this.pastMedicalHisto.Text = pastMedicalHisto;
            this.historyOfAllergies.Text = historyOfAllergies;

            this.familyHistory.Text = famHisto;

            this.registeredDate.Text = dateOfCon;

            this.editedDateTime.Text = dateEditedOfCon + " " + timeEditedOfCon;

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
                string studnum = reader["Patient_StudentNumber"].ToString();
                string formattedConsultationDate = consultationDate.ToString("yyyy-MM-dd");
                string consultationTime = reader["Patient_ConsultationTime"].ToString();
                string physicalExamination = reader["Patient_PhysicalExaminationAndLaboratoryFindings"].ToString();
                string diagnosisAndManagement = reader["Patient_DiagnosisAndManagement"].ToString();

                databaseCon.Rows.Add(studnum, formattedConsultationDate, consultationTime, physicalExamination, diagnosisAndManagement, "VIEW", "EDIT", "DELETE");
            }

            myConnection.Close();
        }

        public void Alert(string msg, AlertBox.enmType type)
        {
            AlertBox alert = new AlertBox();
            alert.showAlert(msg, type);
        }

        private void databaseCon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0) // Check if a valid cell is clicked
            {
                DataGridViewCell cell = databaseCon.Rows[e.RowIndex].Cells[e.ColumnIndex];

                if (e.ColumnIndex == databaseCon.Columns["View"].Index && e.RowIndex >= 0)
                {
                    // Handle View button click
                    string consultationDate = databaseCon.Rows[e.RowIndex].Cells["date"].Value.ToString();
                    string timeOfCon = databaseCon.Rows[e.RowIndex].Cells["timeOfCon"].Value.ToString();
                    string physicalExamination = databaseCon.Rows[e.RowIndex].Cells["lab"].Value.ToString();
                    string diagnosisAndManagement = databaseCon.Rows[e.RowIndex].Cells["dam"].Value.ToString();
                    
                    string connectionString = ConfigurationManager.ConnectionStrings["ConString"].ToString();
                    MySqlConnection myConnection = new MySqlConnection(connectionString);



                    myConnection.Open();
                    string query = @"SELECT *
                    FROM patient_consultation
                    
                    WHERE Patient_ConsultationDate = @consultationDate
                    AND Patient_ConsultationTime = @timeOfCon";

                    MySqlCommand mySqlCommand = new MySqlCommand(query, myConnection);
                   
                    mySqlCommand.Parameters.AddWithValue("@consultationDate", consultationDate);
                    mySqlCommand.Parameters.AddWithValue("@timeOfCon", timeOfCon);

                    MySqlDataReader reader = mySqlCommand.ExecuteReader();

                    if (reader.Read())
                    {
                        string studentNumber = reader["Patient_StudentNumber"].ToString();
                        string consultationTime = reader["Patient_ConsultationTime"].ToString();
                        string p_PEALF = reader["Patient_PhysicalExaminationAndLaboratoryFindings"].ToString();
                        string p_DAM = reader["Patient_DiagnosisAndManagement"].ToString();

                        DateTime dateRegistered = DateTime.Parse(reader["Patient_DateEdited"].ToString());
                        string registeredDate = dateRegistered.ToString("yyyy-MM-dd");

                        DateTime dateEdited = DateTime.Parse(reader["Patient_DateEdited"].ToString());
                        string editedDate = dateEdited.ToString("yyyy-MM-dd");

                        string timeEdited = reader["Patient_TimeEdited"].ToString();

                        ViewSingleConsultation viewSingleConsultation = new ViewSingleConsultation(studentNumber, consultationDate, consultationTime, p_PEALF, p_DAM, editedDate, timeEdited);
                        viewSingleConsultation.Show();
                        this.Hide();
                    }
                }
                if (e.ColumnIndex == databaseCon.Columns["edit"].Index && e.RowIndex >= 0)
                {
                    // Handle Edit button click
                    string consultationDate = databaseCon.Rows[e.RowIndex].Cells["date"].Value.ToString();
                    string timeOfCon = databaseCon.Rows[e.RowIndex].Cells["timeOfCon"].Value.ToString();
                    string physicalExamination = databaseCon.Rows[e.RowIndex].Cells["lab"].Value.ToString();
                    string diagnosisAndManagement = databaseCon.Rows[e.RowIndex].Cells["dam"].Value.ToString();
                    
                    string connectionString = ConfigurationManager.ConnectionStrings["ConString"].ToString();
                    MySqlConnection myConnection = new MySqlConnection(connectionString);

                    myConnection.Open();
                    string query = @"SELECT *
                 FROM patient_consultation
                
                 WHERE Patient_ConsultationDate = @consultationDate
                AND Patient_ConsultationTime = @timeOfCon";

                    MySqlCommand mySqlCommand = new MySqlCommand(query, myConnection);
                   
                    mySqlCommand.Parameters.AddWithValue("@consultationDate", consultationDate);
                    mySqlCommand.Parameters.AddWithValue("@timeOfCon", timeOfCon);


                    MySqlDataReader reader = mySqlCommand.ExecuteReader();

                    if (reader.Read())
                    {
                        string studentNumber = reader["Patient_StudentNumber"].ToString();
                        string consultationTime = reader["Patient_ConsultationTime"].ToString();
                        string p_PEALF = reader["Patient_PhysicalExaminationAndLaboratoryFindings"].ToString();
                        string p_DAM = reader["Patient_DiagnosisAndManagement"].ToString();

                        DateTime dateRegistered = DateTime.Parse(reader["Patient_DateEdited"].ToString());
                        string registeredDate = dateRegistered.ToString("yyyy-MM-dd");

                        DateTime dateEdited = DateTime.Parse(reader["Patient_DateEdited"].ToString());
                        string editedDate = dateEdited.ToString("yyyy-MM-dd");

                        string timeEdited = reader["Patient_TimeEdited"].ToString();

                        EditConsultationInfo_updated editConsultationInfo = new EditConsultationInfo_updated(studentNumber, registeredDate, editedDate, timeEdited, p_PEALF, p_DAM, timeOfCon);
                        editConsultationInfo.Show();
                        this.Hide();
                    }
                }
                if (e.ColumnIndex == databaseCon.Columns["delete"].Index && e.RowIndex >= 0)
                {

                    var popup = System.Windows.Forms.MessageBox.Show("Move item to Recycle Bin?", "Recycle Bin", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (popup == DialogResult.Yes)
                    {
                        string studentNumber = databaseCon.Rows[e.RowIndex].Cells["studnum"].Value.ToString();
                        string timeOfCon = databaseCon.Rows[e.RowIndex].Cells["timeOfCon"].Value.ToString();
                        string consultationDate = databaseCon.Rows[e.RowIndex].Cells["date"].Value.ToString();
                        string physicalExamination = databaseCon.Rows[e.RowIndex].Cells["lab"].Value.ToString();
                        string diagnosisAndManagement = databaseCon.Rows[e.RowIndex].Cells["dam"].Value.ToString();

                        string connectionString = ConfigurationManager.ConnectionStrings["ConString"].ToString();
                        MySqlConnection myConnection = new MySqlConnection(connectionString);

                        myConnection.Open();
                        string query = @"SELECT *
                        FROM patient_consultation
                        WHERE Patient_StudentNumber = @StudentNumber
                        AND Patient_ConsultationDate = @consultationDate
                        AND Patient_ConsultationTime = @timeOfCon";

                        MySqlCommand mySqlCommand = new MySqlCommand(query, myConnection);
                        mySqlCommand.Parameters.AddWithValue("@StudentNumber", studentNumber);
                        mySqlCommand.Parameters.AddWithValue("@consultationDate", consultationDate);
                        mySqlCommand.Parameters.AddWithValue("@timeOfCon", timeOfCon);

                        MySqlDataReader reader = mySqlCommand.ExecuteReader();


                        if (reader.Read())
                        {

                            // Move the patient's information to the patient_recycledbin table
                            string insertQuery = "INSERT INTO consultation_recycledbin " +
                            "(Patient_StudentNumber, Patient_ConsultationDate, Patient_ConsultationTime, Patient_PhysicalExaminationAndLaboratoryFindings, " +
                            "Patient_DiagnosisAndManagement, Patient_DateEdited, Patient_TimeEdited) " +
                            "VALUES (@StudentNumber, @ConsultationDate, @ConsultationTime, @p_PEALF, " +
                            "@p_DAM, @DateEdited, @TimeEdited)";

                            MySqlCommand insertCommand = new MySqlCommand(insertQuery, myConnection);
                            insertCommand.Parameters.AddWithValue("@StudentNumber", reader["Patient_StudentNumber"]);
                            insertCommand.Parameters.AddWithValue("@ConsultationDate", reader["Patient_ConsultationDate"]);
                            insertCommand.Parameters.AddWithValue("@ConsultationTime", reader["Patient_ConsultationTime"]);
                            insertCommand.Parameters.AddWithValue("@p_PEALF", reader["Patient_PhysicalExaminationAndLaboratoryFindings"]);
                            insertCommand.Parameters.AddWithValue("@p_DAM", reader["Patient_DiagnosisAndManagement"]);
                            insertCommand.Parameters.AddWithValue("@DateEdited", reader["Patient_DateEdited"]);
                            insertCommand.Parameters.AddWithValue("@TimeEdited", reader["Patient_TimeEdited"]);
                            reader.Close();
                            insertCommand.ExecuteNonQuery();

                        }
                        reader.Close();
                        // Delete the patient's information from the patient_info table
                        string deleteQuery = "DELETE FROM patient_consultation WHERE Patient_StudentNumber = @StudentNumber " +
                            "AND Patient_ConsultationDate = @ConDate AND Patient_ConsultationTime = @ConTime";
                        MySqlCommand deleteCommand = new MySqlCommand(deleteQuery, myConnection);
                        deleteCommand.Parameters.AddWithValue("@StudentNumber", studentNumber);

                        deleteCommand.Parameters.AddWithValue("@ConDate", consultationDate);
                        deleteCommand.Parameters.AddWithValue("@ConTime", timeOfCon);
                        deleteCommand.ExecuteNonQuery();

                        databaseCon.Rows.RemoveAt(e.RowIndex);
                        this.Alert("Item moved to Recycle Bin", AlertBox.enmType.Success);
                       


                    }

                   

                
                   refreshBtn_Click(sender, e);
                    
                    


                }
            }
        }
        private void ViewPatientRecord2_Load(object sender, EventArgs e)
        {
            databaseCon.CellContentClick += databaseCon_CellContentClick;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void addConsultation_Click(object sender, EventArgs e)
        {
            AddNewConsultation_updated addNewConsultation_Updated = new AddNewConsultation_updated();
            addNewConsultation_Updated.Show();
            this.Hide();
        }

        private void dtRegistered_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            ViewDatabase viewDatabase = new ViewDatabase();
            viewDatabase.Show();
            this.Hide();
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Show();
           
        }
    }
}
