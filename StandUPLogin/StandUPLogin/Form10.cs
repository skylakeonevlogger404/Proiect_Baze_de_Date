using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace StandUPLogin
{
    public partial class Form10 : Form
    {
        private Point mousePosition;

        StandUPLogin.Form1.user s;
        public string sa;

        public Form10(StandUPLogin.Form1.user s1)
        {
            InitializeComponent();
            s = s1;
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            ConturiListdataGridView.DataSource = GetConturiList();
            sa = s.username;
        }

        private DataTable GetConturiList()
        {
            DataTable dtLogin = new DataTable();

            string connectionString = ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Login", con))
                {
                    con.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    dtLogin.Load(reader);
                }
            }

            return dtLogin ;
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

        private void gunaButton1_Click(object sender, EventArgs e) // Back Button
        {
            this.Hide();
            Form6 f6 = new Form6(s);
            f6.ShowDialog();
        }

        private void registerbutton_Click(object sender, EventArgs e) // Insert Button Login
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NBIDGVO\SQLEXPRESS;Initial Catalog=CompanieStand_UP;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Insert into Login values(@nume,@prenume,@username,@password,@password2,@mail,@type)", con);
            //cmd.Parameters.AddWithValue("@id_user", int.Parse(txtiduser.Text));
            cmd.Parameters.AddWithValue("@nume", txtnume.Text);
            cmd.Parameters.AddWithValue("@prenume", txtprenume.Text);
            cmd.Parameters.AddWithValue("@username", txtusername.Text);
            cmd.Parameters.AddWithValue("@password", txtpassword.Text);
            cmd.Parameters.AddWithValue("@password2", txtpassword2.Text);
            cmd.Parameters.AddWithValue("@mail", txtmail.Text);
            cmd.Parameters.AddWithValue("@type", txttype.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record inserted succesfully!");
        }

        private void gunaGradientButton1_Click(object sender, EventArgs e) // Update Button Login
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NBIDGVO\SQLEXPRESS;Initial Catalog=CompanieStand_UP;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Update Login set nume=@nume, prenume=@prenume, password=@password, password2=@password2, mail=@mail, type=@type where username=@username", con);
            cmd.Parameters.AddWithValue("@username", txtusername.Text);
            cmd.Parameters.AddWithValue("@nume", txtnume.Text);
            cmd.Parameters.AddWithValue("@prenume", txtprenume.Text);
            cmd.Parameters.AddWithValue("@password", txtpassword.Text);
            cmd.Parameters.AddWithValue("@password2", txtpassword2.Text);
            cmd.Parameters.AddWithValue("@mail", txtmail.Text);
            cmd.Parameters.AddWithValue("@type", txttype.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Update succesfully!");
        }

        private void gunaGradientButton3_Click(object sender, EventArgs e) // Search Button Login
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NBIDGVO\SQLEXPRESS;Initial Catalog=CompanieStand_UP;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from Login", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ConturiListdataGridView.DataSource = dt;
        }

        private void gunaGradientButton2_Click(object sender, EventArgs e) // Delete Button Login
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NBIDGVO\SQLEXPRESS;Initial Catalog=CompanieStand_UP;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Delete Login where username=@username", con);
            cmd.Parameters.AddWithValue("@username", txtusername.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Delete succesfully!");
        }
    }
}
