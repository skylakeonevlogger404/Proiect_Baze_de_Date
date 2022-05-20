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
    public partial class Form8 : Form
    {
        private Point mousePosition;

        StandUPLogin.Form1.user s;
        public string sa;

        public Form8(StandUPLogin.Form1.user s1)
        {
            InitializeComponent();
            s = s1;
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            LocatiiListdataGridView.DataSource = GetLocatiiList();
            sa = s.username;
        }

        private DataTable GetLocatiiList()
        {
            DataTable dtLocatii = new DataTable();

            string connectionString = ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Locatie", con))
                {
                    con.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    dtLocatii.Load(reader);
                }
            }

            return dtLocatii;
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form6 f6 = new Form6(s);
            f6.ShowDialog();
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

        private void registerbutton_Click(object sender, EventArgs e) // Insert Button Locatie
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NBIDGVO\SQLEXPRESS;Initial Catalog=CompanieStand_UP;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Insert into Locatie values(@id_locatie,@nume_locatie,@adresa_locatie)", con);
            cmd.Parameters.AddWithValue("@id_locatie", int.Parse(txtidloc.Text));
            cmd.Parameters.AddWithValue("@nume_locatie", txtnmloc.Text);
            cmd.Parameters.AddWithValue("@adresa_locatie", txtadrloc.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record inserted succesfully!");
        }

        private void gunaGradientButton1_Click(object sender, EventArgs e) // Update Button Locatie
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NBIDGVO\SQLEXPRESS;Initial Catalog=CompanieStand_UP;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Update Locatie set nume_locatie=@nume_locatie, adresa_locatie=@adresa_locatie where id_locatie=@id_locatie", con);
            cmd.Parameters.AddWithValue("@id_locatie", int.Parse(txtidloc.Text));
            cmd.Parameters.AddWithValue("@nume_locatie", txtnmloc.Text);
            cmd.Parameters.AddWithValue("@adresa_locatie", txtadrloc.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Update succesfully!");
        }

        private void gunaGradientButton2_Click(object sender, EventArgs e) // Delete Button Locatie
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NBIDGVO\SQLEXPRESS;Initial Catalog=CompanieStand_UP;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Delete Locatie where id_locatie=@id_locatie", con);
            cmd.Parameters.AddWithValue("@id_locatie", int.Parse(txtidloc.Text));
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Delete succesfully!");
        }

        private void gunaGradientButton3_Click(object sender, EventArgs e) // Search Button Locatie
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NBIDGVO\SQLEXPRESS;Initial Catalog=CompanieStand_UP;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from Locatie", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            LocatiiListdataGridView.DataSource = dt;
        }
    }
}
