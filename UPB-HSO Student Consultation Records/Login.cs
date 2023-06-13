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
    public partial class Login : Form
    {
        DB dB = new DB();
        public Login()
        {
            InitializeComponent();
            this.loginBtn.Click += new EventHandler(loginBtn_Click);
            this.loginBtn.PreviewKeyDown += new PreviewKeyDownEventHandler(loginBtn_PreviewKeyDown);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.AcceptButton = loginBtn;

        }
        public void Alert(string msg, AlertBox.enmType type)
        {
            AlertBox alert = new AlertBox();
            alert.showAlert(msg, type);
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(guna2TextBox2.Text))
            {
                this.Alert("Please Enter Username", AlertBox.enmType.Error);
                this.guna2TextBox2.Focus();
                return;
            }
            if (string.IsNullOrEmpty(guna2TextBox1.Text))
            {
                this.Alert("Please Enter Password", AlertBox.enmType.Error);
                this.guna2TextBox1.Focus();
                return;
            }
            string query = string.Concat("SELECT COUNT(*) FROM admin_creds WHERE Admin_UserName = '", this.guna2TextBox2.Text, "' and Admin_Password = '", this.guna2TextBox1.Text, "'");
            if (Convert.ToInt16(dB.QueryScalar(query)) <= 0)
            {
                this.Alert("Incorrect Username/Password", AlertBox.enmType.Error);
                return;
            }

            dashboard dashboard = new dashboard();
            dashboard.Show();
            this.Hide();
        }
        private void loginBtn_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Perform login action here
                dashboard dashboard = new dashboard();
                dashboard.Show();
                this.Hide();
                e.IsInputKey = true; // Prevent further processing of the Enter key
            }
        }



        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

  

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}