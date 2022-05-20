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
using System.Text.RegularExpressions;

namespace StandUPLogin
{
    public partial class Form2 : Form
    {
        private Point mousePosition;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //
        }

        private void registerbutton_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NBIDGVO\SQLEXPRESS;Initial Catalog=CompanieStand_UP;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Insert into Login values(@nume,@prenume,@username,@password,@password2,@mail,@type)", con);
            cmd.Parameters.AddWithValue("@nume", txtregnume.Text);
            cmd.Parameters.AddWithValue("@prenume", txtregprenume.Text);
            cmd.Parameters.AddWithValue("@username", txtregusername.Text);
            cmd.Parameters.AddWithValue("@password", txtregpassword.Text);
            cmd.Parameters.AddWithValue("@password2", txtregretypepassword.Text);
            cmd.Parameters.AddWithValue("@mail", txtregmail.Text);
            cmd.Parameters.AddWithValue("@type", "user");
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Registered successfully!");

            this.Hide();
            Form1 f1 = new Form1();
            f1.ShowDialog();
        }

        private void gunaButton1_Click(object sender, EventArgs e) //------------BACK BUTTON FROM REGISTER------------
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.ShowDialog();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NBIDGVO\SQLEXPRESS;Initial Catalog=CompanieStand_UP;Integrated Security=True");
            con.Open();
            bool exists = false;
            SqlCommand cmd = new SqlCommand("Select count(*) from Login where username=@username", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@username", txtregusername.Text);
            exists = (int)cmd.ExecuteScalar() > 0;
            if( txtregusername.Text.Length == 0)
            {
                label7.Text = "";
            }
            else if ( exists )
            {
                label7.ForeColor = System.Drawing.Color.Red;
                label7.Text = "User already taken!"; 
            }
            else
            {
                label7.ForeColor = System.Drawing.Color.Green;
                label7.Text = "OK!";
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {
            if( txtregpassword.Text.Length == 0 )
            {
                label9.Text = "";
            }
            else if ( txtregpassword.Text.Length > 8 )
            {
                label9.ForeColor = System.Drawing.Color.Green;
                label9.Text = "Password is strength!";
            }
            else
            {
                label9.ForeColor = System.Drawing.Color.Red;
                label9.Text = "Password too weak!";
            }

            if ( txtregretypepassword.Text.Length == 0 )
            {
                label8.Text = "";
            }
            else if ( txtregretypepassword.Text == txtregpassword.Text )
            {
                label8.ForeColor = System.Drawing.Color.Green;
                label8.Text = "OK!";
            }
            else
            {
                label8.ForeColor = System.Drawing.Color.Red;
                label8.Text = "Passwords doesn`t match!";
            }
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

        private void label10_Click(object sender, EventArgs e)
        {
            string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";

            if (txtregmail.Text.Length == 0)
            {
                label10.Text = "";
            }
            else if (Regex.IsMatch(txtregmail.Text, pattern))
            {
                label10.ForeColor = System.Drawing.Color.Green;
                label10.Text = "OK!";
            }
            else
            {
                label10.ForeColor = System.Drawing.Color.Red;
                label10.Text = "Inser a valid mail address!";
            }
        }
    }
}
