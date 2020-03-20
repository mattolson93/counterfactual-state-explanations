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
using System.Windows.Forms.DataVisualization.Charting;


namespace user_study
{
    public partial class Results : Form
    {

        explanation_examples full_explanation_form;

        public Results(explanation_examples ex_form)
        {
            InitializeComponent();
            full_explanation_form = ex_form;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            full_explanation_form.FormBorderStyle = FormBorderStyle.FixedSingle;
            full_explanation_form.WindowState = FormWindowState.Normal;


            this.axWindowsMediaPlayer1.URL = System.IO.Path.Combine(Application.StartupPath, "ai_one.mp4");
            this.axWindowsMediaPlayer2.URL = System.IO.Path.Combine(Application.StartupPath, "ai_two.mp4");
            this.axWindowsMediaPlayer1.Ctlcontrols.stop();
            this.axWindowsMediaPlayer2.Ctlcontrols.stop();

            int good_ship = 0;
            int good_alien = 0;
            int good_barrier = 0;
            int good_bullet = 0;

            foreach (var ex in ex_form.good_explanations)
            {
                good_ship    += Convert.ToInt32(ex.ship);
                good_alien   += Convert.ToInt32(ex.alien);
                good_barrier += Convert.ToInt32(ex.barrier);
                good_bullet  += Convert.ToInt32(ex.bullets);
            }

            this.lbl_ONE_ship.Text      = good_ship.ToString();
            this.lbl_ONE_aliens.Text    = good_alien.ToString();
            this.lbl_ONE_barrier.Text   = good_barrier.ToString();
            this.lbl_ONE_bullets.Text   = good_bullet.ToString();


            int bad_ship = 0;
            int bad_alien = 0;
            int bad_barrier = 0;
            int bad_bullet = 0;

            foreach (var ex in ex_form.bad_explanations)
            {
                bad_ship += Convert.ToInt32(ex.ship);
                bad_alien += Convert.ToInt32(ex.alien);
                bad_barrier += Convert.ToInt32(ex.barrier);
                bad_bullet += Convert.ToInt32(ex.bullets);
            }

            this.lbl_TWO_ship.Text = bad_ship.ToString();
            this.lbl_TWO_aliens.Text = bad_alien.ToString();
            this.lbl_TWO_barrier.Text = bad_barrier.ToString();
            this.lbl_TWO_bullets.Text = bad_bullet.ToString();

            string[] xData = new string[] { "alien", "bullet", "ship", "barrier" };
            int[] yData = new int[] { good_alien, good_bullet, good_ship, good_barrier };
            int[] yData2 = new int[] { bad_alien, bad_bullet, bad_ship, bad_barrier  };


            //Create a series using the data
            Series barSeries = new Series();
            barSeries.Points.DataBindXY(xData, yData);
            barSeries.Name = "AI ONE";
            barSeries.ChartType = SeriesChartType.Column;
            chart1.Series.Add(barSeries);

            Series barSeries2 = new Series();
            barSeries2.Points.DataBindXY(xData, yData2);
            barSeries2.Name = "AI TWO";
            barSeries2.ChartType = SeriesChartType.Column;
            chart1.Series.Add(barSeries2);

            chart1.Titles.Add("What AI ONE/TWO pays attention to:");


        }

        private void button1_Click(object sender, EventArgs e)
        {
            full_explanation_form.WindowState = FormWindowState.Minimized;
            full_explanation_form.Show();
            full_explanation_form.WindowState = FormWindowState.Normal;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            gboxChooseAI.Visible = true;
            button2.Visible = false;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e) => image_panel.Visible = true;
        private void radioButton2_CheckedChanged(object sender, EventArgs e) => image_panel.Visible = true;
        private void radioButton3_CheckedChanged(object sender, EventArgs e) => image_panel.Visible = true;


        private void radioButton4_CheckedChanged(object sender, EventArgs e) => groupBox3.Visible = true;
        private void radioButton5_CheckedChanged(object sender, EventArgs e) => groupBox3.Visible = true;

        private void radioButton6_CheckedChanged(object sender, EventArgs e) => groupBox3.Visible = true;

        private void radioButton7_CheckedChanged(object sender, EventArgs e) => groupBox3.Visible = true;
        private void radioButton8_CheckedChanged(object sender, EventArgs e) => groupBox3.Visible = true;

        private void button3_Click(object sender, EventArgs e)
        {
            int which_AI = 0;
            if (radioButton1.Checked) which_AI = 1;
            if (radioButton2.Checked) which_AI = 2;
            if (radioButton3.Checked) which_AI = 3;

            int which_sensor = 9;
            if (radioButton4.Checked) which_sensor = 4;
            if (radioButton5.Checked) which_sensor = 5;
            if (radioButton6.Checked) which_sensor = 6;
            if (radioButton7.Checked) which_sensor = 7;
            if (radioButton8.Checked) which_sensor = 8;


            string out_line = String.Format("{0},{1},{2}", UserId.uid, which_AI, which_sensor);
            string out_file = System.IO.Path.Combine(Application.StartupPath, "user_questions_post.txt");

            using (StreamWriter sw = File.AppendText(out_file))
            {
                sw.WriteLine(out_line);
            }

            System.Windows.Forms.MessageBox.Show("Study complete! Please quietly head to the front desk to get your payment.");
            System.Windows.Forms.MessageBox.Show("About to shutdown the program...");


            full_explanation_form.app_closing = true;
            Application.Exit();
        }

        private void btnTutorial_Click(object sender, EventArgs e)
        {
            this.axWindowsMediaPlayer1.Visible = true;
            this.axWindowsMediaPlayer2.Visible = true;
            this.label13.Visible = true;
            this.label11.Visible = true;
            this.button7.Visible = true;

            this.btnTutorial.Visible = false;

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.button7.Visible = false;
            this.label15.Visible = true;
            this.button4.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.button4.Visible = false;
            this.button1.Visible = true;
            this.label16.Visible = true;
            this.button5.Visible = true;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.button5.Visible = false;
            this.groupBox1.Visible = true;
            this.groupBox2.Visible = true;
            this.label17.Visible = true;
            this.button6.Visible = true;


        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.button6.Visible = false;
            this.button2.Visible = true;
            this.label4.Visible = true;
            this.chart1.Visible = true;
            this.pictureBox5.Visible = true;
            this.pictureBox6.Visible = true;
            this.pictureBox7.Visible = true;
            this.pictureBox8.Visible = true;


        }

       
    }
}
