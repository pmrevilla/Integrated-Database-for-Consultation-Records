using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UPB_HSO_Student_Consultation_Records
{
    public partial class RecycleBin : Form
    {
        public RecycleBin()
        {
            InitializeComponent();
        }

        private void dashboard_Click(object sender, EventArgs e)
        {
            this.Hide();
            dashboard dashboard = new dashboard();
            dashboard.Show();
        }

        private void deletedPatientRecords_Click(object sender, EventArgs e)
        {
            this.Hide();
            DeletedPatientRecords deletedPatientRecords = new DeletedPatientRecords();
            deletedPatientRecords.Show();
        }

        private void deletedConsultations_Click(object sender, EventArgs e)
        {
            this.Hide();
            DeletedConsultations deletedConsultations = new DeletedConsultations();
            deletedConsultations.Show();
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }



        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            dashboard dashboard = new dashboard();
            dashboard.Show();
        }
    }
}
