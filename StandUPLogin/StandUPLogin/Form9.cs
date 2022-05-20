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
    public partial class Form9 : Form
    {
        private Point mousePosition;

        StandUPLogin.Form1.user s;
        public string sa;

        public Form9(StandUPLogin.Form1.user s1)
        {
            InitializeComponent();
            s = s1;
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            ShowListdataGridView.DataSource = GetShowList();
            sa = s.username;
        }

        private DataTable GetShowList()
        {
            DataTable dtShow = new DataTable();

            string connectionString = ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Show", con))
                {
                    con.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    dtShow.Load(reader);
                }
            }

            return dtShow;
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

        private void registerbutton_Click(object sender, EventArgs e) // Insert Button Show
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NBIDGVO\SQLEXPRESS;Initial Catalog=CompanieStand_UP;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Insert into Show values(@id_show,@id_locatie,@timp,@limba,@data,@nume_show,@locuri_total)", con);
            cmd.Parameters.AddWithValue("@id_show", int.Parse(txtidshow.Text));
            cmd.Parameters.AddWithValue("@id_locatie", int.Parse(txtidloc.Text));
            cmd.Parameters.AddWithValue("@timp", txttimp.Text);
            cmd.Parameters.AddWithValue("@limba", txtlimba.Text);
            cmd.Parameters.AddWithValue("@data", txtdata.Text);
            cmd.Parameters.AddWithValue("@nume_show", txtnumeshow.Text);
            cmd.Parameters.AddWithValue("@locuri_total", txtloctotal.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record inserted succesfully!");
        }

        private void gunaGradientButton1_Click(object sender, EventArgs e) // Update Button Show
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NBIDGVO\SQLEXPRESS;Initial Catalog=CompanieStand_UP;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Update Show set id_locatie=@id_locatie, timp=@timp, limba=@limba, data=@data, nume_show=@nume_show, locuri_total=@locuri_total where id_show=@id_show", con);
            cmd.Parameters.AddWithValue("@id_show", int.Parse(txtidshow.Text));
            cmd.Parameters.AddWithValue("@id_locatie", int.Parse(txtidloc.Text));
            cmd.Parameters.AddWithValue("@timp", txttimp.Text);
            cmd.Parameters.AddWithValue("@limba", txtlimba.Text);
            cmd.Parameters.AddWithValue("@data", txtdata.Text);
            cmd.Parameters.AddWithValue("@nume_show", txtnumeshow.Text);
            cmd.Parameters.AddWithValue("@locuri_total", txtloctotal.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Update succesfully!");
        }

        private void gunaGradientButton3_Click(object sender, EventArgs e) // Search Button Show
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NBIDGVO\SQLEXPRESS;Initial Catalog=CompanieStand_UP;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from Show", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ShowListdataGridView.DataSource = dt;
        }

        private void gunaGradientButton2_Click(object sender, EventArgs e) // Delete Button Show
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NBIDGVO\SQLEXPRESS;Initial Catalog=CompanieStand_UP;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Delete Show where id_show=@id_show", con);
            cmd.Parameters.AddWithValue("@id_show", int.Parse(txtidshow.Text));
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Delete succesfully!");
        }

        private void gunaButton1_Click(object sender, EventArgs e) // Back Button
        {
            this.Hide();
            Form6 f6 = new Form6(s);
            f6.ShowDialog();
        }
    }
}
