using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace user_study
{
    public partial class tutorial : Form
    {
        int step = 0;
        public tutorial()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            step += 1;
            this.label_tutorial.Text = "AI Explanations Tutorial step " + step + " of 12";
            switch (step)
            {
                case 1:
                    this.tableLayoutPanel1.Visible = true;
                    break;
                case 2:
                    this.label4.Visible = true;
                    this.pictureBox1.Visible = true;
                    this.panel5.Visible = true;
                    break;
                case 3:
                    this.lbl_gifmode.Visible = true;

                    break;
                case 4:
                    this.panel1.Visible = true;
                    break;
                case 5:
                    this.label1.Visible = true;
                    this.label2.Visible = true;
                    this.label3.Visible = true;
                    this.label8.Visible = true;
                    this.lbl_actionPrime1.Visible = true;

                    break;
                case 6:
                    this.label6.Visible = true;
                    this.panel3.Visible = true;

                    break;
                case 7:
                    this.pictureBox3.Visible = true;
                    break;
                case 8:
                    this.label5.Visible = true;
                    this.panel2.Visible = true;
                    break;
                case 9:
                    this.label5.Visible = true;
                    this.pictureBox2.Visible = true;
                    break;
                case 10:
                    this.panel4.Visible = true;
                    break;
                case 11:
                    this.label15.Visible = true;
                    this.radioButton1.Visible = true;
                    this.radioButton2.Visible = true;
                    this.radioButton3.Visible = true;
                    this.radioButton4.Visible = true;
                    this.radioButton5.Visible = true;
                    this.radioButton6.Visible = true;
                    //this.panel_end.Visible = true;
                    //this.panel5.Visible = false;
                    break;
                case 12:
                    this.button2.Visible = true;
                    this.button1.Visible = false;
                    break;

            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.pictureBox1.Visible = false;
            this.pictureBox5.Visible = true;
            this.lbl_gifmode.Text = "Original State mode: gif";
        }
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.pictureBox1.Visible = true;
            this.pictureBox5.Visible = false;
            this.lbl_gifmode.Text = "Original State mode: image";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var next = new explanation_examples();
            next.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
