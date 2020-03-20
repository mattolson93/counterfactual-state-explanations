using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace user_study
{
    public class explanation
    {
        public Image original_state;
        public Image changed_state;
        public Image highlighted_diff;
        public Image gif;
        public string original_action;
        public string changed_action;
        public int which_image = 0;

        public string uniq_id;

        public bool ship       = false;
        public bool alien      = false;
        public bool barrier    = false;
        public bool bullets    = false;


        private Image str_to_img(string img)
        {
            string full_path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, img);
            Image ret = Image.FromFile(full_path);

            return ret;
        }

        public explanation(string og_img, string changed_img, string highlights, string g, string a, string a_prime, string id)
        {
            original_state = str_to_img(og_img);
            changed_state = str_to_img(changed_img);
            highlighted_diff = str_to_img(highlights);
            gif = str_to_img(g);
            original_action = a;
            changed_action = a_prime;
            uniq_id = id;
        }

    }
}
