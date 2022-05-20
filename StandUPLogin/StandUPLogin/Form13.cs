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
    public partial class Form13 : Form
    {
        private Point mousePosition;

        StandUPLogin.Form1.user s;
        public string sa;

        public Form13(StandUPLogin.Form1.user s1)
        {
            InitializeComponent();
            s = s1;
        }

        private void Form13_Load(object sender, EventArgs e)
        {
            Join1ListdataGridView.DataSource = GetJoin1List(); // id-urile si numele show-urilor
            Join2ListdataGridView.DataSource = GetJoin2List(); // locuri ocupate per utilizator
            Join3ListdataGridView.DataSource = GetJoin3List(); // actori si sume incasate
            Join4ListdataGridView.DataSource = GetJoin4List(); // nume show-uri si nume locatii
            Join5ListdataGridView.DataSource = GetJoin5List(); // ora la care s-au facut cele mai multe rezervari
            Join6ListdataGridView.DataSource = GetJoin6List(); // limba care a prins cel mai bine la locatia X
        }

        private DataTable GetJoin1List()
        {
            DataTable dtJoin = new DataTable();

            string connectionString = ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Show.nume_show, Rezervare.id_user FROM Show INNER JOIN Rezervare ON Show.id_show = Rezervare.id_show", con))
                {
                    con.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    dtJoin.Load(reader);
                }
            }

            return dtJoin;
        }

        private DataTable GetJoin2List()
        {
            DataTable dtJoin = new DataTable();

            string connectionString = ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Login.nume, Login.prenume, Rezervare.locuri FROM Login INNER JOIN Rezervare ON Login.id_user = Rezervare.id_user", con))
                {
                    con.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    dtJoin.Load(reader);
                }
            }

            return dtJoin;
        }

        private DataTable GetJoin3List()
        {
            DataTable dtJoin = new DataTable();

            string connectionString = ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Actor.nume_actor, Actor.prenume_actor, Show_actor.suma_incasata_actor FROM Actor INNER JOIN Show_actor ON Actor.id_actor = Show_actor.id_actor", con))
                {
                    con.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    dtJoin.Load(reader);
                }
            }

            return dtJoin;
        }

        private DataTable GetJoin4List()
        {
            DataTable dtJoin = new DataTable();

            string connectionString = ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Show.nume_show, Locatie.nume_locatie FROM Show INNER JOIN Locatie ON Show.id_locatie = Locatie.id_locatie", con))
                {
                    con.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    dtJoin.Load(reader);
                }
            }

            return dtJoin;
        }

        private DataTable GetJoin5List()
        {
            DataTable dtJoin = new DataTable();

            string connectionString = ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Bilet.pret, Rezervare.ora FROM Bilet INNER JOIN Rezervare ON Bilet.id_user = Rezervare.id_user", con))
                {
                    con.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    dtJoin.Load(reader);
                }
            }

            return dtJoin;
        }

        private DataTable GetJoin6List()
        {
            DataTable dtJoin = new DataTable();

            string connectionString = ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Show.limba, Locatie.nume_locatie FROM Show INNER JOIN Locatie ON Show.id_locatie = Locatie.id_locatie", con))
                {
                    con.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    dtJoin.Load(reader);
                }
            }

            return dtJoin;
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
    }
}
