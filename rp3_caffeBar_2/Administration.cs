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
    public partial class Administration : Form
    {
        string zaposlenik; int indeks;
        public Administration()
        {
            InitializeComponent();

           

            SuspendLayout();
            button_delete.Enabled = false; //nije kliknuo na celiju koju zeli obrisati

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
                
                reader.Close(); 
            }
            
            ResumeLayout();
        }

        //toolStrip button
        private void button_blagajna_Click(object sender, EventArgs e)
        {
            this.Hide();
            var blagajna = new MainScreen();
            blagajna.Show();

        }

        private void button_skladiste_Click(object sender, EventArgs e)
        {
            this.Hide();
            var skladiste = new Storage();
            skladiste.Show();
        }

        private void button_administracija_Click(object sender, EventArgs e)
        {
            this.Hide();
            var administracija = new Administration();
            administracija.Show();
        }
        private void button_statistika_Click(object sender, EventArgs e)
        {
            this.Hide();
            var stat = new Statistics();
            stat.Show();
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            this.Hide();
            var login = new Login();
            login.Show();
        }

        //ADD USER
        private void button_dodaj_Click(object sender, EventArgs e)
        {
            //dodajemo novog korisnika, otvara se nova forma
            NewUser novi = new NewUser();
            novi.ShowDialog();
        }


        //DELETE USER
        //da bismo odabrali usera kojeg zelimo obrisati prvo ga trebamo oznaciti u tablici
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) //klikom brise zaposlenike
        {
            button_delete.Enabled = true;
            zaposlenik = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            indeks = e.RowIndex; //koji redak treba obrisati
        }
       private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            button_delete.Enabled = true;
            zaposlenik = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            indeks = e.RowIndex;  //koji redak treba obrisati 
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
            {

                connection.Open();
                string query = "DELETE FROM [USER] WHERE USERNAME=@username";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", zaposlenik);

                command.ExecuteNonQuery();
                dataGridView1.Rows[indeks].Visible = false;
                connection.Close();
            }
            button_delete.Enabled = false;
        }

        //refresh button
        private void button_refresh_Click(object sender, EventArgs e)
        {
            this.Hide();
            var administracija = new Administration();
            administracija.Show();
        }

    }
}
