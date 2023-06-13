using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UPB_HSO_Student_Consultation_Records
{
    public partial class ViewRecentConsultation : Form
    {
        public ViewRecentConsultation()
        {
            InitializeComponent();
            this.backBtn.Click += new EventHandler(backBtn_Click);
            databaseCon.CellContentClick += databaseCon_CellContentClick;

            string connectionString = ConfigurationManager.ConnectionStrings["ConString"].ToString();
            using (MySqlConnection myConnection = new MySqlConnection(connectionString))
            {
                myConnection.Open();
                string query = "SELECT * FROM patient_consultation ORDER BY Patient_ConsultationDate DESC, Patient_ConsultationTime DESC";
                MySqlCommand mySqlCommand = new MySqlCommand(query, myConnection);

                using (MySqlDataReader reader = mySqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        DateTime consultationDate = DateTime.Parse(reader["Patient_ConsultationDate"].ToString());
                        string formattedConsultationDate = consultationDate.ToString("yyyy-MM-dd");

                        databaseCon.Rows.Add(
                            reader["Patient_StudentNumber"],
                            formattedConsultationDate,
                            reader["Patient_ConsultationTime"],
                            reader["Patient_PhysicalExaminationAndLaboratoryFindings"],
                            reader["Patient_DiagnosisAndManagement"],
                            "VIEW",
                            "EDIT",
                            "DELETE"
                        );
                    }
                }
            }
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

                if (cell.Value != null && cell.Value.ToString() == "VIEW")
                {
                    // Handle View button click
                    string studentNumber = databaseCon.Rows[e.RowIndex].Cells["studentNo"].Value.ToString();
                    string timeOfCon = databaseCon.Rows[e.RowIndex].Cells["timeOfCon"].Value.ToString();
                    string physicalExamination = databaseCon.Rows[e.RowIndex].Cells["lab"].Value.ToString();
                    string diagnosisAndManagement = databaseCon.Rows[e.RowIndex].Cells["diag"].Value.ToString();
                    string consultationDate = databaseCon.Rows[e.RowIndex].Cells["date"].Value.ToString();
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
                else if (cell.Value != null && cell.Value.ToString() == "EDIT")
                {
                    // Handle Edit button click
                    string studentNumber = databaseCon.Rows[e.RowIndex].Cells["studentNo"].Value.ToString();
                    string timeOfCon = databaseCon.Rows[e.RowIndex].Cells["timeOfCon"].Value.ToString();
                    string consultationDate = databaseCon.Rows[e.RowIndex].Cells["date"].Value.ToString();
                    string physicalExamination = databaseCon.Rows[e.RowIndex].Cells["lab"].Value.ToString();
                    string diagnosisAndManagement = databaseCon.Rows[e.RowIndex].Cells["diag"].Value.ToString();

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
                        string consultationTime = reader["Patient_ConsultationTime"].ToString();
                        string p_PEALF = reader["Patient_PhysicalExaminationAndLaboratoryFindings"].ToString();
                        string p_DAM = reader["Patient_DiagnosisAndManagement"].ToString();
                        
                        DateTime dateRegistered = DateTime.Parse(reader["Patient_DateEdited"].ToString());
                        string registeredDate = dateRegistered.ToString("yyyy-MM-dd");

                        DateTime dateEdited = DateTime.Parse(reader["Patient_DateEdited"].ToString());
                        string editedDate = dateEdited.ToString("yyyy-MM-dd");

                        string timeEdited = reader["Patient_TimeEdited"].ToString();

                        EditConsultationInfo_updated editConsultationInfo = new EditConsultationInfo_updated(studentNumber, registeredDate, timeEdited, p_PEALF, p_DAM, timeOfCon, editedDate);
                        editConsultationInfo.Show();
                        this.Hide();
                    }
                }
                else if (cell.Value != null && cell.Value.ToString() == "DELETE")
                {
                    var popup = System.Windows.Forms.MessageBox.Show("Move item to Recycle Bin?", "Recycle Bin", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (popup == DialogResult.Yes)
                    {
                        string studentNumber = databaseCon.Rows[e.RowIndex].Cells["studentNo"].Value.ToString();
                        string timeOfCon = databaseCon.Rows[e.RowIndex].Cells["timeOfCon"].Value.ToString();
                        string consultationDate = databaseCon.Rows[e.RowIndex].Cells["date"].Value.ToString();
                        string physicalExamination = databaseCon.Rows[e.RowIndex].Cells["lab"].Value.ToString();
                        string diagnosisAndManagement = databaseCon.Rows[e.RowIndex].Cells["diag"].Value.ToString();

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

                        this.Alert("Item moved to Recycle Bin", AlertBox.enmType.Success);
                        refreshBtn_Click(sender, e);
                    }
                }
            }
        }



        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            dashboard dashboard = new dashboard();
            dashboard.Show();
            this.Hide();
        }

        private void backBtn_Click_1(object sender, EventArgs e)
        {

        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            string searchString = FilterSearch.Text.Trim();

            string connectionString = ConfigurationManager.ConnectionStrings["ConString"].ToString();
            using (MySqlConnection myConnection = new MySqlConnection(connectionString))
            {
                myConnection.Open();

                // Construct the query with the search criteria
                string query = @"SELECT * FROM patient_consultation WHERE 
                    Patient_StudentNumber LIKE @SearchString OR
                    Patient_PhysicalExaminationAndLaboratoryFindings LIKE @SearchString OR
                    Patient_DiagnosisAndManagement LIKE @SearchString OR
                    Patient_ConsultationDate LIKE @SearchString";

                MySqlCommand mySqlCommand = new MySqlCommand(query, myConnection);
                mySqlCommand.Parameters.AddWithValue("@SearchString", $"%{searchString}%");

                // Clear existing rows from the DataGridView
                databaseCon.Rows.Clear();

                using (MySqlDataReader reader = mySqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DateTime consultationDate = DateTime.Parse(reader["Patient_ConsultationDate"].ToString());
                        string formattedConsultationDate = consultationDate.ToString("yyyy-MM-dd");

                        databaseCon.Rows.Add(
                            reader["Patient_StudentNumber"],
                            formattedConsultationDate,
                            reader["Patient_ConsultationTime"],
                            reader["Patient_PhysicalExaminationAndLaboratoryFindings"],
                            reader["Patient_DiagnosisAndManagement"],
                            "VIEW",
                            "EDIT",
                            "DELETE"

                        ) ;
                    }
                }
            }
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            ViewRecentConsultation viewRecentConsultation = new ViewRecentConsultation();
            viewRecentConsultation.Show();
            this.Hide();
        }

        private void deletedRecords_Click(object sender, EventArgs e)
        {
            this.Hide();
            DeletedConsultations deletedConsultations = new DeletedConsultations();
            deletedConsultations.Show();
        }
    }
}
