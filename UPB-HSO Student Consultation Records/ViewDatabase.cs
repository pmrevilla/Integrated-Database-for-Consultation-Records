using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UPB_HSO_Student_Consultation_Records
{
    public partial class ViewDatabase : Form
    {
        public ViewDatabase()
        {
            InitializeComponent();
            this.cancelBtn.Click += new EventHandler(cancelBtn_Click);
            this.Course.SelectedIndexChanged += new EventHandler(Course_SelectedIndexChanged);

        }

        public void Alert(string msg, AlertBox.enmType type)
        {
            AlertBox alert = new AlertBox();
            alert.showAlert(msg, type);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void ViewDatabase_Load(object sender, EventArgs e)
        {

            String connectionString = ConfigurationManager.ConnectionStrings["ConString"].ToString();
            MySqlConnection myConnection = new MySqlConnection(connectionString);

            myConnection.Open();
            string query = "SELECT * FROM patient_info ORDER BY Patient_DateRegistered DESC";

            MySqlCommand mySqlCommand = new MySqlCommand(query, myConnection);

            MySqlDataReader reader = mySqlCommand.ExecuteReader();

            while (reader.Read())
            {
                database.Rows.Add(reader["Patient_StudentNumber"], reader["Patient_LastName"], reader["Patient_FirstName"],
                                    reader["Patient_Course"], "VIEW", "EDIT", "DELETE");
            }

            myConnection.Close();
        }


        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            dashboard dashboard = new dashboard();
            dashboard.Show();
            this.Hide();
        }
        private void database_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == database.Columns["edit"].Index && e.RowIndex >= 0)
            {
                string studentNumber = database.Rows[e.RowIndex].Cells["studNum"].Value.ToString();
                string lastName = database.Rows[e.RowIndex].Cells["lastName"].Value.ToString();
                string firstName = database.Rows[e.RowIndex].Cells["studName"].Value.ToString();
                string course = database.Rows[e.RowIndex].Cells["studCourse"].Value.ToString();

                string connectionString = ConfigurationManager.ConnectionStrings["ConString"].ToString();
                MySqlConnection myConnection = new MySqlConnection(connectionString);

                myConnection.Open();
                string query = @"SELECT pi.*, pmh.*
                FROM patient_info pi
                JOIN patient_medicalhistory pmh ON pi.Patient_StudentNumber = pmh.Patient_StudentNumber
                WHERE pi.Patient_StudentNumber = @StudentNumber";

                MySqlCommand mySqlCommand = new MySqlCommand(query, myConnection);
                mySqlCommand.Parameters.AddWithValue("@StudentNumber", studentNumber);

                MySqlDataReader reader = mySqlCommand.ExecuteReader();

                if (reader.Read())
                {
                    string middleName = reader["Patient_MiddleName"].ToString();

                    string college = reader["Patient_College"].ToString();
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



                    // Parse the birthDate string into a DateTime object
                    DateTime birthDate = DateTime.Parse(reader["Patient_Birthdate"].ToString());
                    string birthdate = birthDate.ToString("yyyy-MM-dd");



                    DateTime dateRegistered = DateTime.Parse(reader["Patient_DateRegistered"].ToString());
                    string registeredDate = dateRegistered.ToString("yyyy-MM-dd");

                    DateTime dateEdited = DateTime.Parse(reader["Patient_DateEdited"].ToString());
                    string editedDate = dateEdited.ToString("yyyy-MM-dd");

                    string timeEdited = reader["Patient_TimeEdited"].ToString();

                    reader.Close();

                    EditPatientRecord editPatientRecord = new EditPatientRecord(studentNumber, lastName, firstName, middleName, birthdate, course,
                        college, age, sex, civStatus, address, contactNumber, contactPerson, contactPersonNum, famHisto, pastMedicalHisto, historyOfAllergies,
                        registeredDate, editedDate, timeEdited);
                    editPatientRecord.Show();
                    this.Hide();
                }



            }

            else if (e.ColumnIndex == database.Columns["delete"].Index && e.RowIndex >= 0)
            {
                var popup = System.Windows.Forms.MessageBox.Show("Move item to Recycle Bin?", "Recycle Bin", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (popup == DialogResult.Yes)
                {
                    string studentNumber = database.Rows[e.RowIndex].Cells["studNum"].Value.ToString();
                    string lastName = database.Rows[e.RowIndex].Cells["lastName"].Value.ToString();
                    string firstName = database.Rows[e.RowIndex].Cells["studName"].Value.ToString();
                    string course = database.Rows[e.RowIndex].Cells["studCourse"].Value.ToString();

                    string connectionString = ConfigurationManager.ConnectionStrings["ConString"].ToString();
                    MySqlConnection myConnection = new MySqlConnection(connectionString);

                    myConnection.Open();
                    string query = @"SELECT pi.*, pmh.*
                FROM patient_info pi
                JOIN patient_medicalhistory pmh ON pi.Patient_StudentNumber = pmh.Patient_StudentNumber
                WHERE pi.Patient_StudentNumber = @StudentNumber";

                    MySqlCommand mySqlCommand = new MySqlCommand(query, myConnection);
                    mySqlCommand.Parameters.AddWithValue("@StudentNumber", studentNumber);

                    MySqlDataReader reader = mySqlCommand.ExecuteReader();


                    if (reader.Read())
                    {

                        // Move the patient's information to the patient_recycledbin table
                        string insertQuery = "INSERT INTO patient_recycledbin " +
                        "(Patient_StudentNumber, Patient_LastName, Patient_FirstName, Patient_MiddleName, " +
                        "Patient_Birthdate, Patient_Age, Patient_Sex, Patient_CivilStatus, Patient_Address, " +
                        "Patient_ContactNumber, Patient_ContactPerson, Patient_ContactPersonNum, " +
                        "Patient_DateRegistered, Patient_College, Patient_Course, Patient_FamilyHistory, Patient_PastMedicalHistory, Patient_HistoryOfAllergies ," +
                        "Patient_DateEdited, Patient_TimeEdited) " +
                        "VALUES (@StudentNumber, @LastName, @FirstName, @MiddleName, " +
                        "@Birthdate, @Age, @Sex, @CivilStatus, @Address, " +
                        "@ContactNumber, @ContactPerson, @ContactPersonNum, " +
                        "@DateRegistered, @College, @Course,@FamHisto, @MedHisto, @HistOfAllergy, " +
                        "@DateEdited, @TimeEdited)";

                        MySqlCommand insertCommand = new MySqlCommand(insertQuery, myConnection);
                        insertCommand.Parameters.AddWithValue("@StudentNumber", reader["Patient_StudentNumber"]);
                        insertCommand.Parameters.AddWithValue("@LastName", reader["Patient_LastName"]);
                        insertCommand.Parameters.AddWithValue("@FirstName", reader["Patient_FirstName"]);
                        insertCommand.Parameters.AddWithValue("@MiddleName", reader["Patient_MiddleName"]);
                        insertCommand.Parameters.AddWithValue("@Birthdate", reader["Patient_Birthdate"]);
                        insertCommand.Parameters.AddWithValue("@Age", reader["Patient_Age"]);
                        insertCommand.Parameters.AddWithValue("@Sex", reader["Patient_Sex"]);
                        insertCommand.Parameters.AddWithValue("@CivilStatus", reader["Patient_CivilStatus"]);
                        insertCommand.Parameters.AddWithValue("@Address", reader["Patient_Address"]);
                        insertCommand.Parameters.AddWithValue("@ContactNumber", reader["Patient_ContactNumber"]);
                        insertCommand.Parameters.AddWithValue("@ContactPerson", reader["Patient_ContactPerson"]);
                        insertCommand.Parameters.AddWithValue("@ContactPersonNum", reader["Patient_ContactPersonNum"]);
                        insertCommand.Parameters.AddWithValue("@DateRegistered", reader["Patient_DateRegistered"]);
                        insertCommand.Parameters.AddWithValue("@College", reader["Patient_College"]);
                        insertCommand.Parameters.AddWithValue("@Course", reader["Patient_Course"]);

                        insertCommand.Parameters.AddWithValue("@FamHisto", reader["Patient_FamilyHistory"]);
                        insertCommand.Parameters.AddWithValue("@MedHisto", reader["Patient_PastMedicalHistory"]);
                        insertCommand.Parameters.AddWithValue("@HistOfAllergy", reader["Patient_HistoryOfAllergies"]);
                        insertCommand.Parameters.AddWithValue("@DateEdited", reader["Patient_DateEdited"]);
                        insertCommand.Parameters.AddWithValue("@TimeEdited", reader["Patient_TimeEdited"]);

                        reader.Close();
                        insertCommand.ExecuteNonQuery();

                    }
                    reader.Close();
                    // Delete the patient's information from the patient_info table
                    string deleteQuery = "DELETE pi.*, pmh.* FROM patient_info pi" +
                       " JOIN patient_medicalhistory pmh ON pi.Patient_StudentNumber = pmh.Patient_StudentNumber" +
                      " WHERE pi.Patient_StudentNumber = @StudentNumber";
                    MySqlCommand deleteCommand = new MySqlCommand(deleteQuery, myConnection);
                    deleteCommand.Parameters.AddWithValue("@StudentNumber", studentNumber);
                    deleteCommand.ExecuteNonQuery();

                    this.Alert("Item moved to Recycle Bin", AlertBox.enmType.Success);

                    database.Rows.Clear();
                    ViewDatabase_Load(sender, e);



                }




            }


            else if (e.ColumnIndex == database.Columns["view"].Index && e.RowIndex >= 0)
            {
                string studentNumber = database.Rows[e.RowIndex].Cells["studNum"].Value.ToString();
                string lastName = database.Rows[e.RowIndex].Cells["lastName"].Value.ToString();
                string firstName = database.Rows[e.RowIndex].Cells["studName"].Value.ToString();
                string course = database.Rows[e.RowIndex].Cells["studCourse"].Value.ToString();

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
                    string middleName = reader["Patient_MiddleName"].ToString();

                    string college = reader["Patient_College"].ToString();
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

                    DateTime birthDate = DateTime.Parse(reader["Patient_Birthdate"].ToString());
                    string birthdate = birthDate.ToString("yyyy-MM-dd");

                    // Parse the birthDate string into a DateTime object


                    DateTime conDate = DateTime.Parse(reader["Patient_ConsultationDate"].ToString());
                    string dateOfCon = conDate.ToString("yyyy-MM-dd");

                    string timeOfCon = reader["Patient_ConsultationTime"].ToString();
                    string p_PEALF = reader["Patient_PhysicalExaminationAndLaboratoryFindings"].ToString();
                    string p_DAM = reader["Patient_DiagnosisAndManagement"].ToString();

                    DateTime conEditedDate = DateTime.Parse(reader["Patient_DateEdited"].ToString());
                    string dateEditedOfCon = conEditedDate.ToString("yyyy-MM-dd");

                    string timeEditedOfCon = reader["Patient_TimeEdited"].ToString();


                    ViewPatientRecord2 viewPatientRecord = new ViewPatientRecord2(studentNumber, lastName, firstName, middleName, birthdate, course,
                        college, age, sex, civStatus, address, contactNumber, contactPerson, contactPersonNum, famHisto, pastMedicalHisto, historyOfAllergies,
                        dateOfCon, timeOfCon, p_PEALF, p_DAM, dateEditedOfCon, timeEditedOfCon);
                    viewPatientRecord.Show();
                    this.Hide();
                }
            }


        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            ViewDatabase viewDatabase = new ViewDatabase();
            viewDatabase.Show();
            this.Hide();
        }

        private void deletedRecords_Click(object sender, EventArgs e)
        {
            DeletedPatientRecords deletedPatientRecords = new DeletedPatientRecords();
            deletedPatientRecords.Show();
            this.Hide();

        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            string searchString = searchTextBox.Text.Trim();

            string connectionString = ConfigurationManager.ConnectionStrings["ConString"].ToString();
            using (MySqlConnection myConnection = new MySqlConnection(connectionString))
            {
                myConnection.Open();

                // Construct the query with the search criteria
                string query = @"SELECT * FROM patient_info WHERE 
            Patient_StudentNumber LIKE @SearchString OR
            Patient_LastName LIKE @SearchString OR
            Patient_FirstName LIKE @SearchString OR
            Patient_Course LIKE @SearchString";

                MySqlCommand mySqlCommand = new MySqlCommand(query, myConnection);
                mySqlCommand.Parameters.AddWithValue("@SearchString", $"%{searchString}%");

                // Clear existing rows from the DataGridView
                database.Rows.Clear();

                using (MySqlDataReader reader = mySqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {


                        database.Rows.Add(reader["Patient_StudentNumber"], reader["Patient_LastName"], reader["Patient_FirstName"],
                            reader["Patient_Course"], "VIEW", "EDIT", "DELETE");
                    }
                }
            }
        }


        private void Course_SelectedIndexChanged(object sender, EventArgs e)
        {
            PerformSearch();
        }

        private void PerformSearch()
        {
            string searchString = searchTextBox.Text.Trim();
            string selectedCourse = Course.SelectedItem.ToString();

            string connectionString = ConfigurationManager.ConnectionStrings["ConString"].ToString();
            using (MySqlConnection myConnection = new MySqlConnection(connectionString))
            {
                myConnection.Open();

                // Construct the query with the search criteria
                string query = @"SELECT * FROM patient_info WHERE Patient_Course = @Course";

                MySqlCommand mySqlCommand = new MySqlCommand(query, myConnection);
                mySqlCommand.Parameters.AddWithValue("@Course", selectedCourse);

                // Clear existing rows from the DataGridView
                database.Rows.Clear();

                using (MySqlDataReader reader = mySqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        database.Rows.Add(reader["Patient_StudentNumber"], reader["Patient_LastName"], reader["Patient_FirstName"],
                            reader["Patient_Course"], "VIEW", "EDIT", "DELETE");
                    }
                }
            }
        }











        /*

        //Build the CSV file data as a Comma separated string.
        string csv = string.Empty;

        //Add the Header row for CSV file.
        foreach (DataGridViewColumn column in database.Columns)
        {
            csv += column.HeaderText + ',';
        }

        //Add new line.
        csv += "\r\n";

        //Adding the Rows
        foreach (DataGridViewRow row in database.Rows)
        {
            foreach (DataGridViewCell cell in row.Cells)
            {
                //Add the Data rows.
               // csv += cell.Value.ToString().Replace(",", ";") + ',';

                String connectionString = ConfigurationManager.ConnectionStrings["ConString"].ToString();
                MySqlConnection myConnection = new MySqlConnection(connectionString);

                myConnection.Open();
                string query = "SELECT * FROM patient_info ORDER BY Patient_DateRegistered DESC";

                MySqlCommand mySqlCommand = new MySqlCommand(query, myConnection);

                MySqlDataReader reader = mySqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    csv += database.Rows.Add(reader["Patient_StudentNumber"], reader["Patient_LastName"], reader["Patient_FirstName"],
                                        reader["Patient_Course"]);
                }

                myConnection.Close();
            }

            //Add new line.
            csv += "\r\n";
        }

        //Exporting to CSV.
        string folderPath = "C:\\CSV\\";
        File.WriteAllText(folderPath + "DataGridViewExport.csv", csv);
        */
    
        }
}



