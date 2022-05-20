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

namespace StandUPLogin
{
    public partial class Form1 : Form
    {
        private Point mousePosition;

        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NBIDGVO\SQLEXPRESS;Initial Catalog=CompanieStand_UP;Integrated Security=True");

        public class user
        {
            public string username;
        }

        private void gunaGradientButton1_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text.Trim() != "" & txtPassword.Text.Trim() != "")
            {
                con.Close();
                con.Open();

                SqlCommand command = con.CreateCommand();
                command.CommandText = ("Select id_user,username,password,type FROM Login WHERE username=@username AND password=@password");
                command.Parameters.AddWithValue("@username",txtUserName.Text);
                command.Parameters.AddWithValue("@password",txtPassword.Text);


                SqlDataReader reader = command.ExecuteReader();
                if(reader.Read())
                {
                    if(reader.GetValue(3).ToString() == "admin")
                    {
                        MessageBox.Show("Admin logged!");
                        //----------ADMIN INTERFACE----------
                        this.Hide();
                        user s = new user();
                        s.username = txtUserName.Text;
                        Form6 f6 = new Form6(s);
                        f6.ShowDialog();
                        //----------------------------------
                    }
                    if (reader.GetValue(3).ToString() == "user")
                    {
                        MessageBox.Show("User logged!");
                        //----------USER INTERFACE----------
                        this.Hide();
                        user s = new user();
                        s.username = txtUserName.Text;
                        Form3 f3 = new Form3(s);
                        f3.ShowDialog();
                        //----------------------------------
                    }
                }
                else
                {
                    MessageBox.Show("Username or Password is Incorrect!");
                }
            }
            else 
            {
                MessageBox.Show("Inser username and password");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            con.Open();
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            this.mousePosition = new Point(-e.X, -e.Y);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                Point mousePos = Control.MousePosition;

                mousePos.Offset(this.mousePosition.X,this.mousePosition.Y);

                this.Location = mousePos;
            }
        }
    }
}
