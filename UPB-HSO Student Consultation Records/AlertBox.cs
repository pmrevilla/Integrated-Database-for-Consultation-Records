using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UPB_HSO_Student_Consultation_Records.Properties;

namespace UPB_HSO_Student_Consultation_Records
{
    public partial class AlertBox : Form
    {
        public AlertBox()
        {
            InitializeComponent();
        }

        public enum enmAction
        {
            wait,
            start,
            close
     
        }

        public enum enmType
        {
            Success,
            Warning,
            Error,
            Info
        }

        private AlertBox.enmAction action;
        private int x, y;

        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (this.action)
            {
                case enmAction.wait:
                    timer1.Interval = 5000;
                    action = enmAction.close;
                    break;
                case enmAction.start:
                    timer1.Interval = 1;
                    this.Opacity += 0.1;
                    if (this.x < this.Location.X)
                    {
                        this.Left--;
                    }
                    else
                    {
                        if(this.Opacity == 1.0)
                        {
                            action = enmAction.wait;
                        }
                    }
                    break;
                case enmAction.close:
                    timer1.Interval = 1;
                    this.Opacity -= 0.1;
                    this.Left -=3;
                    if(base.Opacity == 0.0)
                    {
                        base.Close();
                    }

                    break;
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            timer1.Interval = 1;
            action = enmAction.close;
        }

        private void messageText_Click(object sender, EventArgs e)
        {

        }

        public void showAlert (string msg, enmType type)
        {
            this.Opacity = 0.0;
            this.StartPosition = FormStartPosition.Manual;
            string fname;

            for (int i = 1; i < 10; i++)
            {
                fname = "alert" + i.ToString();
                AlertBox frm = (AlertBox)Application.OpenForms[fname];

                if(frm == null){
                    this.Name = fname;
                    this.x = Screen.PrimaryScreen.WorkingArea.Width - this.Width + 15;
                    this.y = Screen.PrimaryScreen.WorkingArea.Height - this.Height * i;
                    this.Location = new Point(this.x, this.y);
                    break;
                }
            }
            this.x = Screen.PrimaryScreen.WorkingArea.Width - base.Width - 5;

            switch (type)
            {
                case enmType.Success:
                    this.picture.BackgroundImage = Resources.success;
                    this.BackColor = Color.SeaGreen;
                    break;
                case enmType.Error:
                    this.picture.BackgroundImage = Resources.error;
                    this.BackColor = Color.DarkRed;
                    break;
                case enmType.Warning:
                    this.picture.BackgroundImage = Resources.warning;
                    this.BackColor = Color.DarkOrange;
                    break;
            }

            this.messageText.Text = msg;
            this.TopMost = true;
            this.Show();
            this.BringToFront();
            this.action = enmAction.start;
            this.timer1.Interval = 1;
            timer1.Start();


        }
    }
}
