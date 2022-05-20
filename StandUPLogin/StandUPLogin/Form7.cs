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
using System.Configuration;

namespace StandUPLogin
{
    public partial class Form7 : Form
    {
        private Point mousePosition;

        StandUPLogin.Form1.user s;
        public string sa;

        public Form7(StandUPLogin.Form1.user s1)
        {
            InitializeComponent();
            s = s1;
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            ActoriListdataGridView.DataSource = GetActoriList();
            sa = s.username;
        }

        private DataTable GetActoriList()
        {
            DataTable dtActori = new DataTable();

            string connectionString = ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Actor", con))
                {
                    con.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    dtActori.Load(reader);
                }
            }

            return dtActori;
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

        private void gunaGradientButton1_Click(object sender, EventArgs e) // Update Button Actori
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NBIDGVO\SQLEXPRESS;Initial Catalog=CompanieStand_UP;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Update Actor set nume_actor=@nume_actor, prenume_actor=@prenume_actor, sex_actor=@sex_actor, total_show=@total_show where id_actor=@id_actor", con);
            cmd.Parameters.AddWithValue("@id_actor", int.Parse(txtidact.Text));
            cmd.Parameters.AddWithValue("@nume_actor", txtnumeact.Text);
            cmd.Parameters.AddWithValue("@prenume_actor", txtprenumeact.Text);
            cmd.Parameters.AddWithValue("@sex_actor", txtsxact.Text);
            cmd.Parameters.AddWithValue("@total_show", int.Parse(txttotsh.Text));
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Update succesfully!");
        }

        private void registerbutton_Click(object sender, EventArgs e) // Insert Button Actori
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NBIDGVO\SQLEXPRESS;Initial Catalog=CompanieStand_UP;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Insert into Actor values(@id_actor,@nume_actor,@prenume_actor,@sex_actor,@total_show)", con);
            cmd.Parameters.AddWithValue("@id_actor", int.Parse(txtidact.Text));
            cmd.Parameters.AddWithValue("@nume_actor", txtnumeact.Text);
            cmd.Parameters.AddWithValue("@prenume_actor", txtprenumeact.Text);
            cmd.Parameters.AddWithValue("@sex_actor", txtsxact.Text);
            cmd.Parameters.AddWithValue("@total_show", int.Parse(txttotsh.Text));
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record inserted succesfully!");
        }

        private void gunaGradientButton3_Click(object sender, EventArgs e) // Search Button Actori
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NBIDGVO\SQLEXPRESS;Initial Catalog=CompanieStand_UP;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from Actor", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ActoriListdataGridView.DataSource = dt;
        }

        private void gunaGradientButton2_Click(object sender, EventArgs e) // Delete Button Actori
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NBIDGVO\SQLEXPRESS;Initial Catalog=CompanieStand_UP;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Delete Actor where id_actor=@id_actor", con);
            cmd.Parameters.AddWithValue("@id_actor", int.Parse(txtidact.Text));
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Delete succesfully!");
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form6 f6 = new Form6(s);
            f6.ShowDialog();
        }
    }
}
