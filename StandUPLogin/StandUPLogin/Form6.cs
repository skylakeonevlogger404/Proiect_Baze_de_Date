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
    public partial class Form6 : Form
    {
        private Point mousePosition;

        StandUPLogin.Form1.user s;
        public string sa;

        public Form6(StandUPLogin.Form1.user s1)
        {
            InitializeComponent();
            s = s1;
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            sa = s.username;
        }

        private void gunaButton1_Click(object sender, EventArgs e) // Log out Button
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.ShowDialog();
        }

        private void gunaGradientButton1_Click(object sender, EventArgs e) // Actori Button
        {
            this.Hide();
            Form7 f7 = new Form7(s);
            f7.ShowDialog();
        }

        private void gunaGradientButton3_Click(object sender, EventArgs e) // Locatii Button
        {
            this.Hide();
            Form8 f8 = new Form8(s);
            f8.ShowDialog();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            this.mousePosition = new Point(-e.X, -e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePos = Control.MousePosition;

                mousePos.Offset(this.mousePosition.X, this.mousePosition.Y);

                this.Location = mousePos;
            }
        }

        private void gunaGradientButton6_Click(object sender, EventArgs e) // Show Button
        {
            this.Hide();
            Form9 f9 = new Form9(s);
            f9.ShowDialog();
        }

        private void gunaGradientButton5_Click(object sender, EventArgs e) // Conturi Button
        {
            this.Hide();
            Form10 f10 = new Form10(s);
            f10.ShowDialog();
        }

        private void gunaGradientButton4_Click(object sender, EventArgs e) // Rezervare Button
        {
            this.Hide();
            Form11 f11 = new Form11(s);
            f11.ShowDialog();
        }

        private void gunaGradientButton2_Click(object sender, EventArgs e) // Bilete Button
        {
            this.Hide();
            Form12 f12 = new Form12(s);
            f12.ShowDialog();
        }

        private void gunaGradientButton7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form13 f13 = new Form13(s);
            f13.ShowDialog();
        }
    }
}
