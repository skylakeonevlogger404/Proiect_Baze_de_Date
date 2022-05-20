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
    public partial class Form4 : Form
    {
        private Point mousePosition;

        StandUPLogin.Form1.user s;
        public string sa;
        public string locuri_totale_public = "";
        public string get_id_user = "";

        public Form4(StandUPLogin.Form1.user s1)
        {
            InitializeComponent();
            s = s1;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            sa = s.username;
        }

        private void rezervare_locuri_TextChanged(object sender, EventArgs e)
        {
            //----------------Locuri ocupate---------------------------------
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NBIDGVO\SQLEXPRESS;Initial Catalog=CompanieStand_UP;Integrated Security=True");
            con.Open();

            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Rezervare", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            
            string sum = dt.Compute("Sum(locuri)", "").ToString();

            if ( sum == "" )
            {
                label8.Text = "0";
            } 
            else
            {
                label8.Text = sum;
            }
            //---------------------------------------------------------------

            SqlCommand cmd1 = new SqlCommand("SELECT locuri_total FROM Show WHERE id_show=@id_show", con);

            cmd1.Parameters.AddWithValue("@id_show", "434");

            using (SqlDataReader reader = cmd1.ExecuteReader())
            {
                if (reader.Read())
                {
                    locuri_totale_public = reader["locuri_total"].ToString();
                }
            }

            label4.Text = locuri_totale_public;
            Form4 f4 = new Form4(s);
            f4.locuri_totale_public = locuri_totale_public;

            if (int.Parse(label8.Text) == int.Parse(label4.Text))
            {
                rezervare_locuri.AppendText("0");
                MessageBox.Show("Stoc epuizat!");
                this.Hide();
                Form f3 = new Form3(s);
                f3.ShowDialog();
            }

            con.Close();
        }

        private void rezerva_button_Click(object sender, EventArgs e)
        {
            int locuri_ocupate = int.Parse(label8.Text);
            int locuri_totale = int.Parse(locuri_totale_public);
            locuri_ocupate = locuri_ocupate + int.Parse(rezervare_locuri.Text);

            if (locuri_ocupate > locuri_totale)
            {
                MessageBox.Show("Locuri indisponibile!");
            }
            else if ( locuri_ocupate <= locuri_totale )
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NBIDGVO\SQLEXPRESS;Initial Catalog=CompanieStand_UP;Integrated Security=True");
                con.Open();

                SqlCommand command = new SqlCommand("Select id_user FROM Login WHERE username=@username", con);
                command.Parameters.AddWithValue("@username", s.username);
                command.ExecuteNonQuery();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        get_id_user = String.Format("{0}", reader["id_user"]);
                    }
                }

                SqlCommand cmd = new SqlCommand("Insert into Rezervare values(@id_show,@id_user,@ora,@locuri)", con);
                cmd.Parameters.AddWithValue("@id_show", "434");
                cmd.Parameters.AddWithValue("@id_user", get_id_user);
                cmd.Parameters.AddWithValue("@ora", "18:00");
                cmd.Parameters.AddWithValue("@locuri", rezervare_locuri.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Rezervare realizata cu success!");

                Form f3 = new Form3(s);

                this.Hide();
                Form f5 = new Form5(s);
                f5.ShowDialog();
            }
        }

        private void gunaPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            this.mousePosition = new Point(-e.X, -e.Y);
        }

        private void gunaPanel1_MouseMove(object sender, MouseEventArgs e)
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
