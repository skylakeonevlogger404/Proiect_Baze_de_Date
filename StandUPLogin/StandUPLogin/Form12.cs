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
    public partial class Form12 : Form
    {
        private Point mousePosition;

        StandUPLogin.Form1.user s;
        public string sa;

        public Form12(StandUPLogin.Form1.user s1)
        {
            InitializeComponent();
            s = s1;
        }

        private void Form12_Load(object sender, EventArgs e)
        {
            BiletListdataGridView.DataSource = GetBiletList();
            sa = s.username;
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

        private DataTable GetBiletList()
        {
            DataTable dtBilet = new DataTable();

            string connectionString = ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Bilet", con))
                {
                    con.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    dtBilet.Load(reader);
                }
            }

            return dtBilet;
        }

        private void registerbutton_Click(object sender, EventArgs e) // Insert Button Bilete
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NBIDGVO\SQLEXPRESS;Initial Catalog=CompanieStand_UP;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Insert into Bilet values(@id_show,@pret,@nr_loc,@id_user)", con);
            cmd.Parameters.AddWithValue("@id_show", txtidshow.Text);
            cmd.Parameters.AddWithValue("@pret", txtpret.Text);
            cmd.Parameters.AddWithValue("@nr_loc", txtnrloc.Text);
            cmd.Parameters.AddWithValue("@id_user", txtiduser.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record inserted succesfully!");
        }

        private void gunaGradientButton1_Click(object sender, EventArgs e) // Update Button Bilete
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NBIDGVO\SQLEXPRESS;Initial Catalog=CompanieStand_UP;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Update Bilet id_show=@id_show, pret=@pret where id_user=@id_user and nr_loc=@nr_loc", con);
            cmd.Parameters.AddWithValue("@id_show", txtidshow.Text);
            cmd.Parameters.AddWithValue("@pret", txtpret.Text);
            cmd.Parameters.AddWithValue("@nr_loc", txtnrloc.Text);
            cmd.Parameters.AddWithValue("@id_user", txtiduser.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Update succesfully!");
        }

        private void gunaGradientButton3_Click(object sender, EventArgs e) // Search Button Bilete
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NBIDGVO\SQLEXPRESS;Initial Catalog=CompanieStand_UP;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from Bilet", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            BiletListdataGridView.DataSource = dt;
        }

        private void gunaGradientButton2_Click(object sender, EventArgs e) // Delete Button Bilete
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NBIDGVO\SQLEXPRESS;Initial Catalog=CompanieStand_UP;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Delete Bilet where nr_loc=@nr_loc and id_user=@id_user", con);
            cmd.Parameters.AddWithValue("@id_user", txtiduser.Text);
            cmd.Parameters.AddWithValue("@nr_loc", txtnrloc.Text);
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
