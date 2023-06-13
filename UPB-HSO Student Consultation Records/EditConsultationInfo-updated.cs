using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities.Collections;
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
    public partial class EditConsultationInfo_updated : Form
    {
        DB dB = new DB();

        public EditConsultationInfo_updated(string studentNumber, string registeredDate
                        ,string timeEdited, string p_PEALF, string p_DAM, string timeOfCon, string editedDate)
        {
            InitializeComponent();
            this.studentNo.Text = studentNumber;
            this.consultationDate.Text = registeredDate;
            this.consultationTime.Text = timeOfCon;
            this.findings.Text = p_PEALF;
            this.diagnosis.Text = p_DAM;
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
                ViewRecentConsultation viewRecentConsultation = new ViewRecentConsultation();
                viewRecentConsultation.Show();
                this.Hide();
            }
        }
        private void confirmBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(findings.Text))
            {
                this.Alert("Please Enter Physical Examination and Laboratory Findings", AlertBox.enmType.Error);
                this.findings.Focus();
                return;
            }

            if (string.IsNullOrEmpty(diagnosis.Text))
            {
                this.Alert("Please Enter Diagnosis and Management", AlertBox.enmType.Error);
                this.diagnosis.Focus();
                return;
            }

            String connectionString = ConfigurationManager.ConnectionStrings["ConString"].ToString();
            MySqlConnection myConnection = new MySqlConnection(connectionString);

            myConnection.Open();

            string updatequery = @"UPDATE patient_consultation SET
                        Patient_ConsultationDate = @consultationDate,
                        Patient_PhysicalExaminationAndLaboratoryFindings = @findings,
                        Patient_DiagnosisAndManagement = @diagnosis,
                        Patient_DateEdited = @dateEdited,
                        Patient_TimeEdited = @timeEdited
                        WHERE Patient_StudentNumber = @studentNumber 
                        AND Patient_ConsultationTime = @consultationTime";

            MySqlCommand updateCommand = new MySqlCommand(updatequery, myConnection);
            updateCommand.Parameters.AddWithValue("@consultationDate", consultationDate.Value.ToString("yyyy-MM-dd"));
            //updateCommand.Parameters.AddWithValue("@consultationDate", consultationDate.Text);
            updateCommand.Parameters.AddWithValue("@consultationTime", consultationTime.Text);
            updateCommand.Parameters.AddWithValue("@findings", findings.Text);
            updateCommand.Parameters.AddWithValue("@diagnosis", diagnosis.Text);
            updateCommand.Parameters.AddWithValue("@dateEdited", DateTime.Now.Date);
            updateCommand.Parameters.AddWithValue("@timeEdited", DateTime.Now.TimeOfDay);
            updateCommand.Parameters.AddWithValue("@studentNumber", studentNo.Text);

            // Execute the update query
            int rowsAffected = updateCommand.ExecuteNonQuery();
            myConnection.Close();

            // Show a message box to indicate the update result
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

                    this.Alert("Consultation record updated successfully!", AlertBox.enmType.Success);

                    this.Hide();
                    ViewRecentConsultation viewRecentConsultation = new ViewRecentConsultation();
                    viewRecentConsultation.Show();
                }
            }
            else
            {
                this.Alert("Failed to update consultation record.", AlertBox.enmType.Error);
            }
        }


        private void dtEdited_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void studentNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void consultationDate_TextChanged(object sender, EventArgs e)
        {

        }

        private void confirmBtn_Click_1(object sender, EventArgs e)
        {

        }
    }
}
