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
    public partial class DeletedPatientRecords : Form
    {
        DB dB = new DB();

        public DeletedPatientRecords()
        {
            InitializeComponent();
            searchBtn.Click += searchBtn_Click;

        }

        public static DialogResult InputBox(string title, string promptText, ref string pwdBox)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = pwdBox;

            buttonOk.Text = "Confirm";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            // Set the PasswordChar property of the TextBox control to display masked characters
            textBox.UseSystemPasswordChar = true;

            DialogResult dialogResult = form.ShowDialog();
            pwdBox = textBox.Text;
            return dialogResult;
        }


        public void Alert(string msg, AlertBox.enmType type)
        {
            AlertBox alert = new AlertBox();
            alert.showAlert(msg, type);
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewDatabase viewDatabase = new ViewDatabase();
            viewDatabase.Show();
        }
        private void DeletedPatientRecords_Load(object sender, EventArgs e)
        {
            String connectionString = ConfigurationManager.ConnectionStrings["ConString"].ToString();
            MySqlConnection myConnection = new MySqlConnection(connectionString);

            myConnection.Open();
            string query = "SELECT DATE(Patient_DateDeleted) AS DateDeleted, Patient_TimeDeleted, Patient_StudentNumber, " +
                           "Patient_LastName, Patient_FirstName, Patient_Course " +
                           "FROM patient_recycledbin " +
                           "ORDER BY Patient_DateDeleted DESC";

            MySqlCommand mySqlCommand = new MySqlCommand(query, myConnection);

            MySqlDataReader reader = mySqlCommand.ExecuteReader();

            while (reader.Read())
            {
                DateTime dateDeleted = DateTime.Parse(reader["DateDeleted"].ToString());
                string formattedDateDeleted = dateDeleted.ToString("yyyy-MM-dd");

                database.Rows.Add(formattedDateDeleted, reader["Patient_TimeDeleted"], reader["Patient_StudentNumber"],
                                  reader["Patient_LastName"], reader["Patient_FirstName"], reader["Patient_Course"], "RESTORE", "DELETE");
            }

            myConnection.Close();
        }




        private void refreshBtn_Click(object sender, EventArgs e)
        {
            DeletedPatientRecords deletedPatientRecords = new DeletedPatientRecords();
            deletedPatientRecords.Show();
            this.Hide();
        }

        private void recyclebinBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            RecycleBin recycleBin = new RecycleBin();
            recycleBin.Show();
        }

        private void database_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == database.Columns["RESTORE"].Index && e.RowIndex >= 0)
            {
                var popup = System.Windows.Forms.MessageBox.Show("Restore this item?", "Restore", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (popup == DialogResult.Yes)
                {

                    string dateDeleted = database.Rows[e.RowIndex].Cells["date"].Value.ToString();
                    string timeDeleted = database.Rows[e.RowIndex].Cells["time"].Value.ToString();
                    string studentNumber = database.Rows[e.RowIndex].Cells["studNum"].Value.ToString();
                    string lastName = database.Rows[e.RowIndex].Cells["lastName"].Value.ToString();
                    string firstName = database.Rows[e.RowIndex].Cells["studName"].Value.ToString();
                    string course = database.Rows[e.RowIndex].Cells["studCourse"].Value.ToString();

                    string connectionString = ConfigurationManager.ConnectionStrings["ConString"].ToString();
                    MySqlConnection myConnection = new MySqlConnection(connectionString);

                    myConnection.Open();
                    string query = @"SELECT Patient_StudentNumber, Patient_LastName, Patient_FirstName, Patient_MiddleName, " +
                        "Patient_Birthdate, Patient_Age, Patient_Sex, Patient_CivilStatus, Patient_Address, " +
                        "Patient_ContactNumber, Patient_ContactPerson, Patient_ContactPersonNum, " +
                        "Patient_DateRegistered, Patient_College, Patient_Course, " +
                        "Patient_DateEdited, Patient_TimeEdited FROM patient_recycledbin WHERE Patient_StudentNumber = @StudentNumber";

                    MySqlCommand mySqlCommand = new MySqlCommand(query, myConnection);
                    mySqlCommand.Parameters.AddWithValue("@StudentNumber", studentNumber);

                    MySqlDataReader reader = mySqlCommand.ExecuteReader();


                    if (reader.Read())
                    {

                        // Move the patient's information to the patient_recycledbin table
                        string insertQuery = "INSERT INTO patient_info" +
                        "(Patient_StudentNumber, Patient_LastName, Patient_FirstName, Patient_MiddleName, " +
                        "Patient_Birthdate, Patient_Age, Patient_Sex, Patient_CivilStatus, Patient_Address, " +
                        "Patient_ContactNumber, Patient_ContactPerson, Patient_ContactPersonNum, " +
                        "Patient_DateRegistered, Patient_College, Patient_Course, " +
                        "Patient_DateEdited, Patient_TimeEdited) " +
                        "VALUES (@StudentNumber, @LastName, @FirstName, @MiddleName, " +
                        "@Birthdate, @Age, @Sex, @CivilStatus, @Address, " +
                        "@ContactNumber, @ContactPerson, @ContactPersonNum, " +
                        "@DateRegistered, @College, @Course, " +
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
                        insertCommand.Parameters.AddWithValue("@DateEdited", reader["Patient_DateEdited"]);
                        insertCommand.Parameters.AddWithValue("@TimeEdited", reader["Patient_TimeEdited"]);
                        reader.Close();
                        insertCommand.ExecuteNonQuery();

                    }
                    myConnection.Close();
                    reader.Close();
                    myConnection.Open();
                    string query1 = @"SELECT Patient_StudentNumber, Patient_FamilyHistory, Patient_PastMedicalHistory, Patient_HistoryOfAllergies, " +
                        "Patient_DateEdited, Patient_TimeEdited FROM patient_recycledbin WHERE Patient_StudentNumber = @StudentNumber";

                    MySqlCommand mySqlCommand1 = new MySqlCommand(query1, myConnection);
                    mySqlCommand1.Parameters.AddWithValue("@StudentNumber", studentNumber);

                    MySqlDataReader reader1 = mySqlCommand1.ExecuteReader();


                    if (reader1.Read())
                    {

                        // Move the patient's information to the patient_recycledbin table
                        string insertQuery1 = "INSERT INTO patient_medicalhistory " +
                        "(Patient_StudentNumber, Patient_FamilyHistory, Patient_PastMedicalHistory, Patient_HistoryOfAllergies, " +
                        "Patient_DateEdited, Patient_TimeEdited) " +
                        "VALUES (@StudentNumber, @famHisto, @medHisto, @histoAllergy, " +
                        "@DateEdited, @TimeEdited)";

                        MySqlCommand insertCommand1 = new MySqlCommand(insertQuery1, myConnection);
                        insertCommand1.Parameters.AddWithValue("@StudentNumber", reader1["Patient_StudentNumber"]);
                        insertCommand1.Parameters.AddWithValue("@famHisto", reader1["Patient_FamilyHistory"]);
                        insertCommand1.Parameters.AddWithValue("@medHisto", reader1["Patient_PastMedicalHistory"]);
                        insertCommand1.Parameters.AddWithValue("@histoAllergy", reader1["Patient_HistoryOfAllergies"]);
                        insertCommand1.Parameters.AddWithValue("@DateEdited", reader1["Patient_DateEdited"]);
                        insertCommand1.Parameters.AddWithValue("@TimeEdited", reader1["Patient_DateEdited"]);
                        reader1.Close();
                        insertCommand1.ExecuteNonQuery();
                    }


                    reader.Close();
                    // Delete the patient's information from the patient_info table
                    string deleteQuery = "DELETE FROM patient_recycledbin WHERE Patient_StudentNumber = @StudentNumber";
                    MySqlCommand deleteCommand = new MySqlCommand(deleteQuery, myConnection);
                    deleteCommand.Parameters.AddWithValue("@StudentNumber", studentNumber);
                    deleteCommand.ExecuteNonQuery();

                    this.Alert("Item restored", AlertBox.enmType.Success);

                    database.Rows.Clear();
                    DeletedPatientRecords_Load(sender, e);

                    myConnection.Close();
                }

                

            }
            else if (e.ColumnIndex == database.Columns["delete"].Index && e.RowIndex >= 0)
            {
                string pwdBox = null;

                var msgBox = InputBox("Delete this item permanently?", "Password:", ref pwdBox);
                if (msgBox == DialogResult.OK)
                {
                    if (pwdBox == null)
                    {
                        this.Alert("Please Enter Password", AlertBox.enmType.Error);
                        return;
                    }

                    string query = string.Concat("SELECT COUNT(*) FROM admin_creds WHERE Admin_Password = '", pwdBox, "'");
                    if (Convert.ToInt16(dB.QueryScalar(query)) <= 0)
                    {
                        this.Alert("Incorrect Password", AlertBox.enmType.Error);
                        return;
                    }

                    string dateDeleted = database.Rows[e.RowIndex].Cells["date"].Value.ToString();
                    string timeDeleted = database.Rows[e.RowIndex].Cells["time"].Value.ToString();
                    string studentNumber = database.Rows[e.RowIndex].Cells["studNum"].Value.ToString();
                    string lastName = database.Rows[e.RowIndex].Cells["lastName"].Value.ToString();
                    string firstName = database.Rows[e.RowIndex].Cells["studName"].Value.ToString();
                    string course = database.Rows[e.RowIndex].Cells["studCourse"].Value.ToString();

                    string connectionString = ConfigurationManager.ConnectionStrings["ConString"].ToString();
                    MySqlConnection myConnection = new MySqlConnection(connectionString);

                    myConnection.Open();
                    string queryselect = @"SELECT * FROM patient_recycledbin WHERE Patient_StudentNumber = @StudentNumber";

                    MySqlCommand mySqlCommand = new MySqlCommand(queryselect, myConnection);
                    mySqlCommand.Parameters.AddWithValue("@StudentNumber", studentNumber);

                    MySqlDataReader reader = mySqlCommand.ExecuteReader();

                    if (reader.Read())
                    {
                        string deleteQuery = "DELETE FROM patient_recycledbin WHERE Patient_StudentNumber = @StudentNumber";
                        MySqlCommand deleteCommand = new MySqlCommand(deleteQuery, myConnection);
                        deleteCommand.Parameters.AddWithValue("@StudentNumber", studentNumber);
                        reader.Close();
                        deleteCommand.ExecuteNonQuery();

                        this.Alert("Item deleted permanently", AlertBox.enmType.Success);

                        database.Rows.Clear();
                        DeletedPatientRecords_Load(sender, e);
                    }
                }

               
            }

        }
        private void searchBtn_Click(object sender, EventArgs e)
        {
            string searchString = searchTextBox.Text.Trim();

            string connectionString = ConfigurationManager.ConnectionStrings["ConString"].ToString();
            using (MySqlConnection myConnection = new MySqlConnection(connectionString))
            {
                myConnection.Open();

                // Construct the query with the search criteria
                string query = @"SELECT * FROM patient_recycledbin WHERE 
            Patient_DateDeleted LIKE @SearchString OR
            Patient_TimeDeleted LIKE @SearchString OR
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


                        DateTime dateDeleted = DateTime.Parse(reader["Patient_DateDeleted"].ToString());
                        string formattedDateDeleted = dateDeleted.ToString("yyyy-MM-dd");

                        database.Rows.Add(formattedDateDeleted, reader["Patient_TimeDeleted"], reader["Patient_StudentNumber"],
                                         reader["Patient_LastName"], reader["Patient_FirstName"], reader["Patient_Course"], "RESTORE", "DELETE");
                    }
                }
                
            }
            searchTextBox.Text = string.Empty;
        }
       



    }

}

