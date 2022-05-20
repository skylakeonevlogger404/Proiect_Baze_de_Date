using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics;

namespace StandUPLogin
{
    public partial class Form3 : Form
    {
        private Point mousePosition;

        StandUPLogin.Form1.user s;
        public string sa;

        public Form3(StandUPLogin.Form1.user s1)
        {
            InitializeComponent();
            s = s1;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            sa = s.username;
        }

        private void Form3_MouseDown(object sender, MouseEventArgs e)
        {
            this.mousePosition = new Point(-e.X, -e.Y);
        }

        private void Form3_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePos = Control.MousePosition;

                mousePos.Offset(this.mousePosition.X, this.mousePosition.Y);

                this.Location = mousePos;
            }
        }

        private void gunaButton9_Click(object sender, EventArgs e)//----cheia sucesului----
        {
            this.Hide();
            Form4 f4 = new Form4(s);
            f4.ShowDialog();
        }

        private void gunaButton1_Click(object sender, EventArgs e)//----cheia sucesului----
        {   //teatru national bucuresti
            Process.Start("https://www.google.com/maps/place/Teatrul+Na%C8%9Bional+%22I.+L.+Caragiale%22+Bucure%C8%99ti/@44.4364936,26.1009943,17z/data=!3m1!4b1!4m5!3m4!1s0x40b1ff3881ef1975:0x67bb35b30f843224!8m2!3d44.4364898!4d26.103183");
        }

        private void gunaButton2_Click(object sender, EventArgs e)//----mahmur pe strada----
        {   //teatru masca
            Process.Start("https://www.google.com/maps/place/Teatrul+Masca/@44.4387589,26.0282059,17z/data=!3m1!4b1!4m5!3m4!1s0x40b201a6e5693efd:0xba14b144cb46ae6f!8m2!3d44.4387551!4d26.0303946?hl=ro-RO");
        }

        private void gunaButton3_Click(object sender, EventArgs e)//----marea plictiseala----
        {   //comics club
            Process.Start("https://www.google.com/maps/place/Comics+Club+-+Stand-up+comedy/@44.4243511,26.1161969,17z/data=!3m1!4b1!4m5!3m4!1s0x40b1ffe3c0f47841:0x25ced7581b9c2dd8!8m2!3d44.4243498!4d26.1183262?hl=ro-RO");
        }

        private void gunaButton4_Click(object sender, EventArgs e)//----scoala vietii----
        {   //sala palatului
            Process.Start("https://www.google.com/maps/place/Sala+Palatului/@44.4391281,26.092793,17z/data=!3m1!4b1!4m5!3m4!1s0x40b1ff453d5735db:0x2c539f3aae8a4115!8m2!3d44.4390356!4d26.0946654?hl=ro-RO");
        }
    }
}
