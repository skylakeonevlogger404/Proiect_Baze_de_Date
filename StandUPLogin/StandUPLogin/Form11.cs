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
    public partial class Form11 : Form
    {
        private Point mousePosition;

        StandUPLogin.Form1.user s;
        public string sa;

        public Form11(StandUPLogin.Form1.user s1)
        {
            InitializeComponent();
            s = s1;
        }

        private void Form11_Load(object sender, EventArgs e)
        {
            RezervareListdataGridView.DataSource = GetRezervareList();
            sa = s.username;
        }

        private DataTable GetRezervareList()
        {
            DataTable dtRezervare = new DataTable();

            string connectionString = ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Rezervare", con))
                {
                    con.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    dtRezervare.Load(reader);
                }
            }

            return dtRezervare;
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

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form6 f6 = new Form6(s);
            f6.ShowDialog();
        }

        private void registerbutton_Click(object sender, EventArgs e) // Insert Button Rezervare
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NBIDGVO\SQLEXPRESS;Initial Catalog=CompanieStand_UP;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Insert into Rezervare values(@id_show,@id_user,@ora,@locuri)", con);
            cmd.Parameters.AddWithValue("@id_show", txtidshow.Text);
            cmd.Parameters.AddWithValue("@id_user", txtiduser.Text);
            cmd.Parameters.AddWithValue("@ora", txtora.Text);
            cmd.Parameters.AddWithValue("@locuri", txtlocuri.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record inserted succesfully!");
        }

        private void gunaGradientButton1_Click(object sender, EventArgs e) // Update Button Rezervare
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NBIDGVO\SQLEXPRESS;Initial Catalog=CompanieStand_UP;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Update Rezervare set id_show=@id_show, ora=@ora, locuri=@locuri where id_user=@id_user", con);
            cmd.Parameters.AddWithValue("@id_show", txtidshow.Text);
            cmd.Parameters.AddWithValue("@id_user", txtiduser.Text);
            cmd.Parameters.AddWithValue("@ora", txtora.Text);
            cmd.Parameters.AddWithValue("@locuri", txtlocuri.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Update succesfully!");
        }

        private void gunaGradientButton3_Click(object sender, EventArgs e) // Search Button Rezervare
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NBIDGVO\SQLEXPRESS;Initial Catalog=CompanieStand_UP;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from Rezervare", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            RezervareListdataGridView.DataSource = dt;
        }

        private void gunaGradientButton2_Click(object sender, EventArgs e) // Delete Button Rezervare
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NBIDGVO\SQLEXPRESS;Initial Catalog=CompanieStand_UP;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Delete Rezervare where id_user=@id_user and locuri=@locuri", con);
            cmd.Parameters.AddWithValue("@id_user", txtiduser.Text);
            cmd.Parameters.AddWithValue("@locuri", txtlocuri.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Delete succesfully!");
        }
    }
}
