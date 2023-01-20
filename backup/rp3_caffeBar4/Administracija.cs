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
        public Administracija()
        {
            InitializeComponent();

            SuspendLayout();


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
            
        }

        private void button_dodaj_Click(object sender, EventArgs e)
        {
            //dodajemo novog korisnika, otvara se nova forma
            //NoviKorisnik novi = new NoviKorisnik();
           // novi.Show();
        }
    }
}
