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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UPB_HSO_Student_Consultation_Records
{
    public partial class AddNewConsultation_updated : Form
    {
        DB dB = new DB();

        public AddNewConsultation_updated()
        {
            InitializeComponent();
            DateTime dateTimeNow = DateTime.Now;
            this.consultationTime.Text = dateTimeNow.ToString("HH:mm:ss");
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        public void Alert(string msg, AlertBox.enmType type)
        {
            AlertBox alert = new AlertBox();
            alert.showAlert(msg, type);
        }

        /*
        public void Message(string msg, MessageBox.enmType type)
        {
            MessageBox message = new MessageBox();
            message.showMessage(msg,type);
        
        }
        */
        

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            string queryStudNo = string.Concat("SELECT COUNT(*) FROM patient_info WHERE Patient_StudentNumber = '", this.studentNo.Text, "'");
            if (Convert.ToInt16(dB.QueryScalar(queryStudNo)) <= 0)
            {
                this.Alert("Student Number Does Not Exist", AlertBox.enmType.Error);
                this.studentNo.Focus();
                return;
            }

            else if (string.IsNullOrEmpty(studentNo.Text))
            {
                this.Alert("Please Enter Student Number", AlertBox.enmType.Error);
                this.studentNo.Focus();
                return;
            }

            if (string.IsNullOrEmpty(consultationDate.Value.ToString()))
            {
                this.Alert("Please Enter Consultation Date", AlertBox.enmType.Error);
                this.consultationDate.Focus();
                return;
            }

            if (string.IsNullOrEmpty(consultationTime.Text))
            {
                this.Alert("Please Enter Consultation Time", AlertBox.enmType.Error);
                this.consultationTime.Focus();
                return;
            }

            if (string.IsNullOrEmpty(PELF.Text))
            {
                this.Alert("Please Enter Physical Examination and Laboratory Findings", AlertBox.enmType.Error);
                this.PELF.Focus();
                return;
            }

            if (string.IsNullOrEmpty(DAM.Text))
            {
                this.Alert("Please Enter Diagnosis and Management", AlertBox.enmType.Error);
                this.DAM.Focus();
                return;
            }

            String connectionString = ConfigurationManager.ConnectionStrings["ConString"].ToString();
            MySqlConnection myConnection = new MySqlConnection(connectionString);

            myConnection.Open();
            string query = "INSERT INTO patient_consultation (Patient_StudentNumber, Patient_ConsultationDate, Patient_ConsultationTime, Patient_PhysicalExaminationAndLaboratoryFindings, Patient_DiagnosisAndManagement) " +
                "VALUES (@studentNumber, @conDate, @conTime, @PELF, @DAM)";

            MySqlCommand myCommand = new MySqlCommand(query, myConnection);
            myCommand.Parameters.AddWithValue("@studentNumber", studentNo.Text);
            myCommand.Parameters.AddWithValue("@conDate", consultationDate.Value.ToString("yyyy-MM-dd"));
            myCommand.Parameters.AddWithValue("@conTime", consultationTime.Text);
            myCommand.Parameters.AddWithValue("@PELF", PELF.Text);
            myCommand.Parameters.AddWithValue("@DAM", DAM.Text);
            myCommand.ExecuteNonQuery();
            myConnection.Close();

            //System.Windows.Forms.MessageBox.Show("Consultation record added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Alert("Consultation record added successfully!", AlertBox.enmType.Success);

         //   AddNewConsultation_updated addNewConsultation_Updated = new AddNewConsultation_updated();
         //   addNewConsultation_Updated.Show();
            this.Hide();
            dashboard dashboard = new dashboard();
            dashboard.Show();

        }

        private void label5_Click(object sender, EventArgs e)
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

            //this.Message("Information you entered may not be saved.Exit window?", MessageBox.enmType.Warning);
            
            


            //this.Message("Information you entered may not be saved. Exit window?", MessageBox.enmType.Warning);
        }

        private void consultationDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void diabetes_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void consultationTime_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
