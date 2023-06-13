using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UPB_HSO_Student_Consultation_Records
{
    public partial class dashboard : Form
    {
        public dashboard()
        {
            InitializeComponent();
            this.exitBtn.Click += new EventHandler(exitBtn_Click);
        }


        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void addNewPatientBtn_Click(object sender, EventArgs e)
        {
            AddNewPatient addNewPatient = new AddNewPatient();
            addNewPatient.Show();
            this.Hide();
        }

        private void dashboard_Load(object sender, EventArgs e)
        {
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(w, h);
            this.Size = new Size(w, h);
        }

        private void addNewConsult_Click(object sender, EventArgs e)
        {
            AddNewConsultation_updated addNewConsultation = new AddNewConsultation_updated();
            addNewConsultation.Show();
            this.Hide();
        }

        private void viewDatabase_Click(object sender, EventArgs e)
        {
            ViewDatabase viewDatabase = new ViewDatabase();
            viewDatabase.Show();
            this.Hide();
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            var popup = System.Windows.Forms.MessageBox.Show("Logout of your account?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (popup == DialogResult.Yes)
            {
                this.Hide();
                Login login = new Login();
                login.Show();
            }


        }

        private void recentConsultations_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewRecentConsultation viewRecentConsultation = new ViewRecentConsultation();
            viewRecentConsultation.Show();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            var popup = System.Windows.Forms.MessageBox.Show("You will automatically be logged out of your account. Exit application?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (popup == DialogResult.Yes)
            {
                this.Hide();
                Application.Exit();
            }
        }

        private void recycleBin_Click(object sender, EventArgs e)
        {
            this.Hide();
            RecycleBin recycleBin = new RecycleBin();
            recycleBin.Show();
        }

        private void exitBtn_Click_1(object sender, EventArgs e)
        {
            
        }
    }
}
