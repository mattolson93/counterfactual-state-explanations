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

    public partial class explanation_examples : Form
    {

        List<explanation> all_explanations = new List<explanation>();
        public List<explanation> good_explanations = new List<explanation>();
        public List<explanation> bad_explanations = new List<explanation>();


        int cur_ex = 0;
        public bool app_closing = false;
        private void myClosing(object sender, FormClosingEventArgs e)
        {
            if (this.app_closing)
            {
                return;
            }
            else
            {
                e.Cancel = true;
                this.Hide();
            }
        }


        public explanation_examples()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

            this.FormClosing += new FormClosingEventHandler(myClosing);


            //load all the images

            string cur_dir = "abl_none";

            var action_descriptions = new string[] { "Do nothing", "Shoot", "Move right", "Move left", "Move right and shoot", "Move left and shoot" };

            var good_original_actions = new int[] { 4, 4, 1, 4, 4, 4, 2, 2, 4, 4 };
            var good_cf_actions = new int[] { 3, 2, 2, 3, 3, 3, 1, 1, 3, 3 };

            //string[] good_actions = new string[] { "move left", "move left", "move left", "move left", "move left", "move left", "move left", "move left", "move left", "move left" };
            //string[] good_cf_actions = new string[] { "move right", "move right", "move right", "move right", "move right", "move right", "move right", "move right", "move right", "move right" };

            for (int i = 0; i < 10; i++)
            {
                string ex_num = (i + 1).ToString();
                string cur_path = Path.Combine(cur_dir, "example" + ex_num);
                string original_state = Path.Combine(cur_path, "output1.png");
                string highlighted_diff = Path.Combine(cur_path, "output2.png");
                string changed_state = Path.Combine(cur_path, "output3.png");
                string gif = Path.Combine(cur_path, "gif.gif");

                var cur_ex = new explanation(original_state, changed_state, highlighted_diff, gif, action_descriptions[good_original_actions[i]], action_descriptions[good_cf_actions[i]], "good" + ex_num);
                all_explanations.Add(cur_ex);
                good_explanations.Add(cur_ex);

            }

            var bad_original_actions = new int[] { 3, 1, 4, 4, 4, 4, 5, 5, 5, 5 };
            var bad_cf_actions = new int[] { 2, 2, 3, 3, 2, 2, 2, 2, 2, 2 };

            cur_dir = "abl_agent";

            for (int i = 0; i < 10; i++)
            {
                string ex_num = (i + 1).ToString();
                string cur_path = Path.Combine(cur_dir, "example" + ex_num);
                string original_state = Path.Combine(cur_path, "output1.png");
                string highlighted_diff = Path.Combine(cur_path, "output2.png");
                string changed_state = Path.Combine(cur_path, "output3.png");
                string gif = Path.Combine(cur_path, "gif.gif");


                var cur_ex = new explanation(original_state, changed_state, highlighted_diff, gif, action_descriptions[bad_original_actions[i]], action_descriptions[bad_cf_actions[i]], "bad" + ex_num);

                all_explanations.Add(cur_ex);
                bad_explanations.Add(cur_ex);
            }


            Utils.Shuffle(all_explanations);
            cur_ex = 0;
            set_cur_ex_labeling(all_explanations[cur_ex]);

        }

        private void save_cur_ex_data(explanation ex)
        {
            int radio = 0;

            if (this.radioButton1.Checked == true)
            {
                radio = 1;
            } else if (this.radioButton2.Checked == true)
            {
                radio = 2;
            }
            else if (this.radioButton3.Checked == true)
            {
                radio = 3;
            }
            else if (this.radioButton4.Checked == true)
            {
                radio = 4;
            }
            else if (this.radioButton5.Checked == true)
            {
                radio = 5;
            }
            else if (this.radioButton6.Checked == true)
            {
                radio = 6;
            }

            //probably should save this to file...
            ex.ship = this.chkShip.Checked;
            ex.alien = this.chkAliens.Checked;
            ex.barrier = this.chkBarriers.Checked;
            ex.bullets = this.chkBullets.Checked;

            ex.which_image = radio;

            string out_line = String.Format("{0},{1},{2},{3},{4},{5},{6}", UserId.uid, ex.uniq_id, ex.ship, ex.alien, ex.barrier, ex.bullets, ex.which_image);
            string out_file = System.IO.Path.Combine(Application.StartupPath, "user_output.txt");

            using (StreamWriter sw = File.AppendText(out_file))
            {
                sw.WriteLine(out_line);
            }

        }

        private int secondsToWait = 30;
        private DateTime startTime;

        private void set_cur_ex_labeling(explanation ex, bool do_timer = true)
        {
            //set the labels and images
            this.chkShip.Checked = false;
            this.chkAliens.Checked = false;
            this.chkBarriers.Checked = false;
            this.chkBullets.Checked = false;

            var radios = new List<RadioButton>() { this.radioButton1, this.radioButton2, this.radioButton3, this.radioButton4, this.radioButton5, this.radioButton6 };

            foreach (var r in radios) { r.Checked = false; }

            this.lblSteps.Text = "example " + (cur_ex + 1).ToString() + " out of 20";

            this.lbl_action.Text = ex.original_action;
            this.lbl_actionPrime1.Text = ex.changed_action;
            this.lbl_actionPrime2.Text = ex.changed_action;
            this.lbl_actionPrime3.Text = ex.changed_action;

            this.pictureBox1.Image = ex.original_state;
            this.pictureBox2.Image = ex.highlighted_diff;
            this.pictureBox3.Image = ex.changed_state;
            this.pictureBox5.Image = ex.gif;


            this.button1.Enabled = false;
            timer1.Start(); // start timer (you can do it on form load, if you need)
            startTime = DateTime.Now;


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

        private void set_cur_ex(explanation ex)
        {
            //set the labels and images
            this.chkShip.Checked = ex.ship;
            this.chkAliens.Checked = ex.alien;
            this.chkBarriers.Checked = ex.barrier;
            this.chkBullets.Checked = ex.bullets;



            this.lbl_action.Text = ex.original_action;
            this.lbl_actionPrime1.Text = ex.changed_action;
            this.lbl_actionPrime2.Text = ex.changed_action;
            this.lbl_actionPrime3.Text = ex.changed_action;

            this.pictureBox1.Image = ex.original_state;
            this.pictureBox2.Image = ex.highlighted_diff;
            this.pictureBox3.Image = ex.changed_state;
            this.pictureBox5.Image = ex.gif;

            var radios = new List<RadioButton>() { this.radioButton1, this.radioButton2, this.radioButton3, this.radioButton4, this.radioButton5, this.radioButton6 };

            foreach (var r in radios)
            {
                r.Checked = false;
            }
            if (ex.which_image != 0)
                radios[ex.which_image - 1].Checked = true;



        }

        private int remainingSeconds = 30;

        private void timer1_Tick(object sender, EventArgs e)
        {
            int elapsedSeconds = (int)(DateTime.Now - startTime).TotalSeconds;
            remainingSeconds = Math.Max(0, secondsToWait - elapsedSeconds);
            this.lblTime.Text = "Time remaining - " + remainingSeconds.ToString();

            if (remainingSeconds <= 0)
            {
                // run your function
                timer1.Stop();

                var radios = new List<RadioButton>() { this.radioButton1, this.radioButton2, this.radioButton3, this.radioButton4, this.radioButton5, this.radioButton6 };
                bool done = false;
                foreach (var r in radios)
                {
                    done = done || r.Checked;
                }

                if (done)
                    this.button1.Enabled = true;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {

            cur_ex += 1;
            if (cur_ex < 20)
            {
                save_cur_ex_data(all_explanations[cur_ex - 1]);

                set_cur_ex_labeling(all_explanations[cur_ex]);
            }
            else if (cur_ex == 20)
            {
                var next = new Results(this);
                next.Show();


                this.chkShip.Enabled = false;
                this.chkAliens.Enabled = false;
                this.chkBarriers.Enabled = false;
                this.chkBullets.Enabled = false;
                this.radioButton1.Enabled = false;
                this.radioButton2.Enabled = false;
                this.radioButton3.Enabled = false;
                this.radioButton4.Enabled = false;
                this.radioButton5.Enabled = false;
                this.radioButton6.Enabled = false;

                timer1.Stop();
                this.lblSteps.Text = "";
                this.button1.Text = "Close";
                this.lblTime.Text = "";
                this.button1.Enabled = true;
                this.groupBox1.Visible = true;
                this.groupBox2.Visible = true;
                this.Hide();

            }
            else
            {
                this.Hide();
            }
        }

        private void btnShow_1_1_Click(object sender, EventArgs e) => set_cur_ex(good_explanations[0]);

        private void btnShow_1_2_Click(object sender, EventArgs e) => set_cur_ex(good_explanations[1]);

        private void btnShow_1_3_Click(object sender, EventArgs e) => set_cur_ex(good_explanations[2]);

        private void btnShow_1_4_Click(object sender, EventArgs e) => set_cur_ex(good_explanations[3]);

        private void btnShow_1_5_Click(object sender, EventArgs e) => set_cur_ex(good_explanations[4]);

        private void btnShow_1_6_Click(object sender, EventArgs e) => set_cur_ex(good_explanations[5]);

        private void btnShow_1_7_Click(object sender, EventArgs e) => set_cur_ex(good_explanations[6]);

        private void btnShow_1_8_Click(object sender, EventArgs e) => set_cur_ex(good_explanations[7]);

        private void btnShow_1_9_Click(object sender, EventArgs e) => set_cur_ex(good_explanations[8]);

        private void btnShow_1_10_Click(object sender, EventArgs e) => set_cur_ex(good_explanations[9]);

        private void btnShow_2_1_Click(object sender, EventArgs e) => set_cur_ex(bad_explanations[0]);

        private void btnShow_2_2_Click(object sender, EventArgs e) => set_cur_ex(bad_explanations[1]);
        private void btnShow_2_3_Click(object sender, EventArgs e) => set_cur_ex(bad_explanations[2]);
        private void btnShow_2_4_Click(object sender, EventArgs e) => set_cur_ex(bad_explanations[3]);

        private void btnShow_2_5_Click(object sender, EventArgs e) => set_cur_ex(bad_explanations[4]);

        private void btnShow_2_6_Click(object sender, EventArgs e) => set_cur_ex(bad_explanations[5]);

        private void btnShow_2_7_Click(object sender, EventArgs e) => set_cur_ex(bad_explanations[6]);

        private void btnShow_2_8_Click(object sender, EventArgs e) => set_cur_ex(bad_explanations[7]);

        private void btnShow_2_9_Click(object sender, EventArgs e) => set_cur_ex(bad_explanations[8]);

        private void btnShow_2_10_Click(object sender, EventArgs e) => set_cur_ex(bad_explanations[9]);

        private void radioButton1_CheckedChanged(object sender, EventArgs e){if (remainingSeconds <= 0) this.button1.Enabled = true;}
        private void radioButton2_CheckedChanged(object sender, EventArgs e) { if (remainingSeconds <= 0) this.button1.Enabled = true; }
        private void radioButton3_CheckedChanged(object sender, EventArgs e){if (remainingSeconds <= 0) this.button1.Enabled = true;}
        private void radioButton4_CheckedChanged(object sender, EventArgs e){if (remainingSeconds <= 0) this.button1.Enabled = true;}
        private void radioButton5_CheckedChanged(object sender, EventArgs e){if (remainingSeconds <= 0) this.button1.Enabled = true;}
        private void radioButton6_CheckedChanged(object sender, EventArgs e) { if (remainingSeconds <= 0) this.button1.Enabled = true; }
}
}
