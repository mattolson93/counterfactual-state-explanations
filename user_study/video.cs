using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace user_study
{
    public partial class video : Form
    {
        public video()
        {
            InitializeComponent();
            this.axWindowsMediaPlayer1.URL = System.IO.Path.Combine(Application.StartupPath, "ai_one.mp4");
            this.axWindowsMediaPlayer2.URL = System.IO.Path.Combine(Application.StartupPath, "ai_two.mp4");
            this.axWindowsMediaPlayer1.Ctlcontrols.stop();
            this.axWindowsMediaPlayer2.Ctlcontrols.stop();

            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

        }


        private void button3_Click(object sender, EventArgs e)
        {

            int which_AI = 1;
            if (radioButton2.Checked) which_AI = 2;
            if (radioButton3.Checked) which_AI = 3;

            int which_sensor = 8;
            if (radioButton4.Checked) which_sensor = 4;
            if (radioButton5.Checked) which_sensor = 5;
            if (radioButton6.Checked) which_sensor = 6;
            if (radioButton7.Checked) which_sensor = 7;


            string out_line = String.Format("{0},{1},{2}", UserId.uid, which_AI, which_sensor);
            string out_file = System.IO.Path.Combine(Application.StartupPath, "user_questions_pre.txt");

            using (StreamWriter sw = File.AppendText(out_file))
            {
                sw.WriteLine(out_line);
            }


            var wait = new wait_for_everyone();
            wait.Show();
            this.Hide();
        }


        private void btnShowNextAbl_Click(object sender, EventArgs e)
        {
            disableRadios();

            if (this.pictureBox1.Visible == false){
                this.pictureBox1.Visible = true;
                this.btnShowNextAbl.Location = new Point(500, 160);
            } else if (this.pictureBox2.Visible == false)
            {
                this.pictureBox2.Visible = true;
                this.btnShowNextAbl.Location = new Point(125, 540);

            }
            else if (this.pictureBox3.Visible == false)
            {
                this.pictureBox3.Visible = true;
                this.btnShowNextAbl.Location = new Point(500, 540);


            }
            else if (this.pictureBox4.Visible == false)
            {
                this.pictureBox4.Visible = true;

                this.btnShowNextAbl.Location = new Point(293, 876);
                this.btnShowNextAbl.Text = "Okay...";
            }
            else
            {
                this.label7.Visible = true;
                this.btnNext.Visible = true;


                this.btnShowNextAbl.Visible = false;


                this.radioButton4.Visible = true;
                this.radioButton5.Visible = true;
                this.radioButton6.Visible = true;
                this.radioButton7.Visible = true;
                this.radioButton8.Visible = true;

                this.radioButton4.Enabled = true;
                this.radioButton5.Enabled = true;
                this.radioButton6.Enabled = true;
                this.radioButton7.Enabled = true;
                this.radioButton8.Enabled = true;
            }
        }

        private void btnFinishedWatching_Click(object sender, EventArgs e)
        {
            this.gboxChooseAI.Visible = true;
            this.btnFinishedWatching.Visible = false;
        }

        private void disableRadios()
        {
            this.radioButton1.Enabled = false;
            this.radioButton2.Enabled = false;
            this.radioButton3.Enabled = false;
        }
        //these buttons are for "which AI is broken sensor"
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            this.image_panel.Visible = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            this.image_panel.Visible = true;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            this.image_panel.Visible = true;
        }

        //these buttons are for "choose the gif"

        private void radioButton5_CheckedChanged(object sender, EventArgs e) => this.btnNext.Enabled = true;
        private void radioButton4_CheckedChanged(object sender, EventArgs e) => this.btnNext.Enabled = true;
       
        private void radioButton6_CheckedChanged(object sender, EventArgs e) => this.btnNext.Enabled = true;
        private void radioButton7_CheckedChanged(object sender, EventArgs e) => this.btnNext.Enabled = true;
        private void radioButton8_CheckedChanged(object sender, EventArgs e) => this.btnNext.Enabled = true;
        

        private void button1_Click(object sender, EventArgs e)
        {
           

            if (label5.Visible == true)
            {
                axWindowsMediaPlayer1.Visible = true;
                axWindowsMediaPlayer2.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label6.Visible = true;
                btnFinishedWatching.Visible = true;
                button1.Visible = false;

            }
            else if (label8.Visible == true)
            {
                label5.Visible = true;
            }
            else
            {
                label8.Visible = true;
            }

            button1.Location = new Point(button1.Location.X, button1.Location.Y + 26);


        }

        
    }
}
