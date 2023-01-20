using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rp3_caffeBar
{
    public partial class Administracija : Form
    {
        string zaposlenik; int indeks;
        public Administracija()
        {
            InitializeComponent();

            SuspendLayout();

            button_delete.Enabled = false;  

            //prikažimo sve zaposlenike  koji se nalaze u bazi
            using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM [USER]";
                SqlCommand command = new SqlCommand(query, connection);

                SqlDataReader reader = command.ExecuteReader();
               
                while (reader.Read())
                {
                    var ime = reader.GetString(1).ToString();
                    var sifra = reader.GetString(2).ToString();

                    dataGridView1.Rows.Add(ime, sifra);

                    
                }
                
                reader.Close(); ResumeLayout();
            }
        }

        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            button_delete.Enabled = true;

                zaposlenik = dataGridView1.Rows[e.RowIndex].Cells[0].ToString();
                indeks = e.RowIndex;
        }

        private void button_dodaj_Click(object sender, EventArgs e)
        {
            //dodajemo novog korisnika, otvara se nova forma
            NoviKorisnik novi = new NoviKorisnik();
            novi.Show();
        }

        private void button_refresh_Click(object sender, EventArgs e)
        {
            this.Hide();
            var administracija = new Administracija();
            administracija.Show();
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
            {

                connection.Open();
                string query = "DELETE * FROM [USER] WHERE USERNAME=@username";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", zaposlenik);

                command.ExecuteNonQuery();
                //dataGridView1.Rows[indeks].Visible = false;
                connection.Close();
            }
           //button_delete.Enabled=false;
        }
    }
}
