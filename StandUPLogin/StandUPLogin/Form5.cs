using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StandUPLogin
{
    public partial class Form5 : Form
    {
        StandUPLogin.Form1.user s;
        public string sa;

        public Form5(StandUPLogin.Form1.user s1)
        {
            InitializeComponent();
            s = s1;
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            sa = s.username;
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 f3 = new Form3(s);
            f3.ShowDialog();
        }
    }
}
