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
// For MessageBox


namespace UPB_HSO_Student_Consultation_Records
{
    public partial class DeletedConsultations : Form
    {
        DB dB = new DB();
        public DeletedConsultations()
        {
            InitializeComponent();
            searchBtn.Click += searchBtn_Click;
            databaseCon.CellContentClick += databaseCon_CellContentClick;
            string connectionString = ConfigurationManager.ConnectionStrings["ConString"].ToString();
            MySqlConnection myConnection = new MySqlConnection(connectionString);

            myConnection.Open();
            string query = "SELECT conRecycleBinID, Patient_DateDeleted, Patient_TimeDeleted, Patient_StudentNumber, Patient_PhysicalExaminationAndLaboratoryFindings, " +
                           "Patient_DiagnosisAndManagement " +
                           "FROM consultation_recycledbin " +
                           "ORDER BY Patient_DateDeleted DESC";

            MySqlCommand mySqlCommand = new MySqlCommand(query, myConnection);
            


            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            databaseCon.AutoGenerateColumns = false;

            while (reader.Read())
            {
                DateTime date = DateTime.Parse(reader["Patient_DateDeleted"].ToString());
                string formattedConsultationDate = date.ToString("yyyy-MM-dd");


                string timeDeleted = reader["Patient_TimeDeleted"].ToString();
                string studentNo = reader["Patient_StudentNumber"].ToString();
                string lab = reader["Patient_PhysicalExaminationAndLaboratoryFindings"].ToString();
                string diag = reader["Patient_DiagnosisAndManagement"].ToString();
                string conId = reader["conRecycleBinID"].ToString();

                databaseCon.Rows.Add(conId, formattedConsultationDate, timeDeleted, studentNo, lab, diag, "RESTORE", "DELETE");
            }

            myConnection.Close();
        }

        public void Alert(string msg, AlertBox.enmType type)
        {
            AlertBox alert = new AlertBox();
            alert.showAlert(msg, type);
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


        private void databaseCon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0) // Check if a valid cell is clicked
            {
                DataGridViewCell cell = databaseCon.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (cell.Value != null && cell.Value.ToString() == "RESTORE")
                {
                    var popup = System.Windows.Forms.MessageBox.Show("Restore this item?", "Restore", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (popup == DialogResult.Yes)
                    {
                        string conID = databaseCon.Rows[e.RowIndex].Cells["con"].Value.ToString();
                        string dateDeleted = databaseCon.Rows[e.RowIndex].Cells["deleted"].ToString();
                        string timeDeleted = databaseCon.Rows[e.RowIndex].Cells["timeDeleted"].Value.ToString();
                        string studentNumber = databaseCon.Rows[e.RowIndex].Cells["studentNo"].Value.ToString();
                        string physicalExamination = databaseCon.Rows[e.RowIndex].Cells["lab"].Value.ToString();
                        string diagnosisAndManagement = databaseCon.Rows[e.RowIndex].Cells["diag"].Value.ToString();

                        string connectionString = ConfigurationManager.ConnectionStrings["ConString"].ToString();
                        MySqlConnection myConnection = new MySqlConnection(connectionString);

                        myConnection.Open();

                        string query = "SELECT * FROM consultation_recycledbin WHERE Patient_StudentNumber = @StudentNumber " +
                        "AND conRecycleBinID = @conID";
                        MySqlCommand mySqlCommand = new MySqlCommand(query, myConnection);
                        mySqlCommand.Parameters.AddWithValue("@StudentNumber", studentNumber);
                        mySqlCommand.Parameters.AddWithValue("@dateDeleted", dateDeleted);
                        mySqlCommand.Parameters.AddWithValue("@timeDeleted", timeDeleted);
                        mySqlCommand.Parameters.AddWithValue("@conID", conID);


                        MySqlDataReader reader = mySqlCommand.ExecuteReader();

                        if (reader.Read())
                        {
                            // Move the patient's information to the patient_consultation table
                            string insertQuery = "INSERT INTO patient_consultation " +
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

                        // Delete the consultation from the consultation_recycledbin table
                        string deleteQuery = "DELETE FROM consultation_recycledbin WHERE Patient_StudentNumber = @StudentNumber " +
                        "AND conRecycleBinID = @conID";
                        MySqlCommand deleteCommand = new MySqlCommand(deleteQuery, myConnection);
                        deleteCommand.Parameters.AddWithValue("@StudentNumber", studentNumber);
                        deleteCommand.Parameters.AddWithValue("@dateDeleted", dateDeleted);
                        deleteCommand.Parameters.AddWithValue("@timeDeleted", timeDeleted);
                        deleteCommand.Parameters.AddWithValue("@conID", conID);
                        reader.Close();
                        deleteCommand.ExecuteNonQuery();

                        this.Alert("Item restored", AlertBox.enmType.Success);

                       

                        // Clear the DataGridView and reload the data
                        databaseCon.Rows.Clear();
                        DeletedConsultations deletedConsultations = new DeletedConsultations();
                        deletedConsultations.Show();
                        this.Hide();

                    }


                }
                else if (e.ColumnIndex == databaseCon.Columns["delete"].Index && e.RowIndex >= 0)
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

                        string conID = databaseCon.Rows[e.RowIndex].Cells["con"].Value.ToString();
                        string dateDeleted = databaseCon.Rows[e.RowIndex].Cells["deleted"].Value.ToString();
                        string timeDeleted = databaseCon.Rows[e.RowIndex].Cells["timeDeleted"].Value.ToString();
                        string studentNumber = databaseCon.Rows[e.RowIndex].Cells["studentNo"].Value.ToString();
                        string physicalExamination = databaseCon.Rows[e.RowIndex].Cells["lab"].Value.ToString();
                        string diagnosisAndManagement = databaseCon.Rows[e.RowIndex].Cells["diag"].Value.ToString();

                        string connectionString = ConfigurationManager.ConnectionStrings["ConString"].ToString();
                        using (MySqlConnection myConnection = new MySqlConnection(connectionString))
                        {
                            myConnection.Open();

                            // Delete the patient's information from the consultation_recycledbin table
                            string deleteQuery = "DELETE FROM consultation_recycledbin WHERE Patient_StudentNumber = @StudentNumber " +
                                "AND conRecycleBinID = @conID";
                            MySqlCommand deleteCommand = new MySqlCommand(deleteQuery, myConnection);
                            deleteCommand.Parameters.AddWithValue("@StudentNumber", studentNumber);
                            deleteCommand.Parameters.AddWithValue("@dateDeleted", dateDeleted);
                            deleteCommand.Parameters.AddWithValue("@timeDeleted", timeDeleted);
                            deleteCommand.Parameters.AddWithValue("@conID", conID);
                            deleteCommand.ExecuteNonQuery();

                            refreshBtn_Click(sender, e);
                            // Clear the DataGridView and reload the data
                            databaseCon.Rows.Clear();
                            //   DeletedConsultations_Load(sender, e);
                            DeletedConsultations deletedConsultations = new DeletedConsultations();
                            deletedConsultations.Show();
                            this.Hide();
                            
                        }
                        
                    }
                }
            }
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            // Close the current form
            this.Close();
        }

        private void DeletedConsultations_Load(object sender, EventArgs e)
        {
            // Subscribe the event handler to the CellContentClick event
            databaseCon.CellContentClick += databaseCon_CellContentClick;

           
            
        }






        private void refreshBtn_Click(object sender, EventArgs e)
        {
            DeletedConsultations deletedConsultations = new DeletedConsultations();
            deletedConsultations.Show();
            this.Hide();
        }

        private void databaseBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewRecentConsultation viewRecentConsultation = new ViewRecentConsultation();
            viewRecentConsultation.Show();

        }

        private void recyclebinBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            RecycleBin recycleBin = new RecycleBin();
            recycleBin.Show();
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            string searchString = FilterSearch.Text.Trim();

            string connectionString = ConfigurationManager.ConnectionStrings["ConString"].ToString();
            using (MySqlConnection myConnection = new MySqlConnection(connectionString))
            {
                myConnection.Open();

                // Construct the query with the search criteria
                string query = @"SELECT * FROM consultation_recycledbin WHERE 
                    Patient_StudentNumber LIKE @SearchString OR
                    Patient_DateDeleted LIKE @SearchString OR
                    Patient_TimeDeleted LIKE @SearchString OR
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
                        DateTime deleted = DateTime.Parse(reader["Patient_DateDeleted"].ToString());
                        string deletedDate = deleted.ToString("yyyy-MM-dd");
                       

                        databaseCon.Rows.Add(
                            reader["conRecycleBinID"],
                            deletedDate,
                            reader["Patient_TimeDeleted"],
                            reader["Patient_StudentNumber"],
                            reader["Patient_PhysicalExaminationAndLaboratoryFindings"],
                            reader["Patient_DiagnosisAndManagement"],
                            "RESTORE",
                            "DELETE"
                        );
                    }
                }
                FilterSearch.Text = string.Empty;
            }
        }

        private void searchBtn_Click_1(object sender, EventArgs e)
        {

        }
    }
}
