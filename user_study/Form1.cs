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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load1;

            

        }

        private void Form1_Load1(object sender, EventArgs e)
        {
            //return;
            //this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text == "")
            {
                MessageBox.Show("Your proctor forgot to put in your ID, please raise your hand.");
                return;
            }
            UserId.uid = this.textBox1.Text;
            var vid = new video();
            vid.Show();
            this.Hide();
        }

    }
}
