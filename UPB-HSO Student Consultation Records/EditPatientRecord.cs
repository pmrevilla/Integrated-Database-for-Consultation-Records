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
    public partial class EditPatientRecord : Form
    {
        private string patientStudentNumber;
        DB dB = new DB();

        public EditPatientRecord(string studentNumber, string lastName, string firstName, string middleName, string birthDate, string course,
            string college, string age, string sex, string civStatus, string address, string contactNumber, string contactPerson, string contactPersonNum, 
            string famHisto, string pastMedicalHisto, string historyOfAllergies, string formattedDate, string editedDate, string timeEdited)
        {
            InitializeComponent();
            this.confirmBtn.Click += new EventHandler(confirmBtn_Click);

            // Set the patient's information in the form controls
            this.patientStudentNumber = studentNumber;
            this.studentNo.Text = studentNumber;
            this.lastName.Text = lastName;
            this.firstName.Text = firstName;
            this.middleName.Text = middleName;
            this.birthDate.Text = birthDate;
            this.age.Text = age;
            this.sex.SelectedItem = sex;
            this.civStatus.SelectedItem = civStatus;
            this.address.Text = address;
            this.contactNo.Text = contactNumber;
            this.contactPerson.Text = contactPerson;
            this.contactPersonNo.Text = contactPersonNum;
            this.college.SelectedItem = college;
            this.course.SelectedItem = course;
            
            this.pastMedicalHisto.Text = pastMedicalHisto;
            this.historyOfAllergies.Text = historyOfAllergies;

            string famHistoValues = famHisto;

            // Split the string into individual values
            string[] famHistoArray = famHistoValues.Split(',');

            // Check the corresponding checkboxes based on the retrieved values
            foreach (string value in famHistoArray)
            {
                if (value.Trim().Equals("Hypertension"))
                    hypertension.Checked = true;
                if (value.Trim().Equals("Stroke"))
                    stroke.Checked = true;
                if (value.Trim().Equals("Cancer"))
                    cancer.Checked = true;
                if (value.Trim().Equals("Diabetes"))
                    diabetes.Checked = true;
                if (value.Trim().Equals("Bronchial Asthma"))
                    bronchialAsthma.Checked = true;
                if (value.Trim().Equals("Heart Disease"))
                    heartDisease.Checked = true;

            }

            this.registeredDate.Text = formattedDate;
            this.editedDateTime.Text = editedDate + " " + timeEdited;


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

            var popup = System.Windows.Forms.MessageBox.Show("Changes you made may not be saved. Exit window?", "Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (popup == DialogResult.Yes)
            {
                // Get the existing instance of ViewDatabase form
                ViewDatabase viewDatabase = Application.OpenForms.OfType<ViewDatabase>().FirstOrDefault();

                // Show the existing instance of ViewDatabase form
                viewDatabase?.Show();

                // Close the current EditPatientRecord form
                this.Close();
            }

        }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConString"].ToString();

            using (MySqlConnection myConnection = new MySqlConnection(connectionString))
            {
                try
                {
                    myConnection.Open();

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
                    if (birthDate.Value == null)
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
                    if (string.IsNullOrEmpty(contactPersonNo.Text))
                    {
                        this.Alert("Please Enter Contact Person Number", AlertBox.enmType.Error);
                        this.contactPersonNo.Focus();
                        return;
                    }
                    if (string.IsNullOrEmpty(pastMedicalHisto.Text))
                    {
                        this.Alert("Please Enter Past Medical History", AlertBox.enmType.Error);
                        this.contactPersonNo.Focus();
                        return;
                    }
                    if (string.IsNullOrEmpty(historyOfAllergies.Text))
                    {
                        this.Alert("Please Enter History of Allergies", AlertBox.enmType.Error);
                        this.contactPersonNo.Focus();
                        return;
                    }


                    List<string> checkedValues = new List<string>();

                    if (hypertension.Checked) checkedValues.Add("Hypertension");
                    if (diabetes.Checked) checkedValues.Add("Diabetes");
                    if (cancer.Checked) checkedValues.Add("Cancer");
                    if (bronchialAsthma.Checked) checkedValues.Add("Bronchial Asthma");
                    if (stroke.Checked) checkedValues.Add("Stroke");
                    if (heartDisease.Checked) checkedValues.Add("Heart Disease");

                    string famHisto = string.Join(", ", checkedValues);

                    string updateQuery = "UPDATE patient_info SET " +
                        "Patient_LastName = @lastName, " +
                        "Patient_FirstName = @firstName, " +
                        "Patient_MiddleName = @middleName, " +
                        "Patient_Address = @address, " +
                        "Patient_ContactNumber = @contactNumber, " +
                        "Patient_Age = @age, " +
                        "Patient_Sex = @sex, " +
                        "Patient_Birthdate = @birthDate, " +
                        "Patient_CivilStatus = @civStatus, " +
                        "Patient_College = @college, " +
                        "Patient_Course = @course, " +
                        "Patient_ContactPerson = @contactPerson, " +
                        "Patient_ContactPersonNum = @contactPersonNumber, " +
                        "Patient_DateEdited = @dateEdited, " +
                        "Patient_TimeEdited = @timeEdited " +
                        "WHERE Patient_StudentNumber = @StudentNumber";

                    string updateQuery2 = @"UPDATE patient_medicalhistory
                                            SET Patient_FamilyHistory = @famHisto,
                                                Patient_PastMedicalHistory = @pastMedHisto,
                                                Patient_HistoryOfAllergies = @histoAllergy,
                                                Patient_DateEdited = @dateEdited,
                                                Patient_TimeEdited = @timeEdited
                                                WHERE Patient_StudentNumber = @StudentNumber";

                    // Create a MySqlCommand object with the update query and connection
                    MySqlCommand updateCommand = new MySqlCommand(updateQuery, myConnection);

                    // Set the parameter values
                    updateCommand.Parameters.AddWithValue("@lastName", lastName.Text);
                    updateCommand.Parameters.AddWithValue("@firstName", firstName.Text);
                    updateCommand.Parameters.AddWithValue("@middleName", middleName.Text);
                    updateCommand.Parameters.AddWithValue("@birthDate", birthDate.Value.Date);
                    updateCommand.Parameters.AddWithValue("@age", age.Text);
                    updateCommand.Parameters.AddWithValue("@sex", sex.SelectedItem);
                    updateCommand.Parameters.AddWithValue("@civStatus", civStatus.SelectedItem);
                    updateCommand.Parameters.AddWithValue("@address", address.Text);
                    updateCommand.Parameters.AddWithValue("@college", college.SelectedItem);
                    updateCommand.Parameters.AddWithValue("@course", course.SelectedItem);
                    updateCommand.Parameters.AddWithValue("@contactNumber", contactNo.Text);
                    updateCommand.Parameters.AddWithValue("@contactPerson", contactPerson.Text);
                    updateCommand.Parameters.AddWithValue("@contactPersonNumber", contactPersonNo.Text);
                    updateCommand.Parameters.AddWithValue("@dateEdited", DateTime.Now.Date);
                    updateCommand.Parameters.AddWithValue("@timeEdited", DateTime.Now.TimeOfDay);
                    updateCommand.Parameters.AddWithValue("@StudentNumber", patientStudentNumber);

                    // Execute the update query
                    int rowsAffected = updateCommand.ExecuteNonQuery();

                    MySqlCommand updatePatientMedicalHistoryCommand = new MySqlCommand(updateQuery2, myConnection);
                    updatePatientMedicalHistoryCommand.Parameters.AddWithValue("@famHisto", famHisto);
                    updatePatientMedicalHistoryCommand.Parameters.AddWithValue("@pastMedHisto", pastMedicalHisto.Text);
                    updatePatientMedicalHistoryCommand.Parameters.AddWithValue("@histoAllergy", historyOfAllergies.Text);
                    updatePatientMedicalHistoryCommand.Parameters.AddWithValue("@dateEdited", DateTime.Now.Date);
                    updatePatientMedicalHistoryCommand.Parameters.AddWithValue("@timeEdited", DateTime.Now.TimeOfDay);
                    updatePatientMedicalHistoryCommand.Parameters.AddWithValue("@StudentNumber", patientStudentNumber);


                    int rowsAffectedPatientMedicalHistory = updatePatientMedicalHistoryCommand.ExecuteNonQuery();


                    if (rowsAffected > 0)
                    {
                        string pwdBox = null;

                        var msgBox = InputBox("Confirm changes?", "Password:", ref pwdBox);
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

                            this.Alert("Patient information updated successfully!", AlertBox.enmType.Success);

                            this.Hide();
                            ViewDatabase viewDatabase = new ViewDatabase();
                            viewDatabase.Show();
                        }

                    }

                    else
                    {
                        this.Alert("Failed to update patient information.", AlertBox.enmType.Error);
                    }
                }
                catch (Exception ex)
                {
                    this.Alert("An error occurred: " + ex.Message, AlertBox.enmType.Error);
                }
            }
        }

        private void confirmBtn_Click_1(object sender, EventArgs e)
        {

        }
    }
}
