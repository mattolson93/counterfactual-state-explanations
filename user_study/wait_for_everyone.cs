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
    public partial class wait_for_everyone : Form
    {
        public wait_for_everyone()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var next = new tutorial();
            next.Show();
            this.Hide();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.button1.Enabled = true;
        }
    }
}
