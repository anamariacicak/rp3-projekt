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
    public partial class Storage : Form
    {
        public Storage()
        {
            InitializeComponent();

            refresh_storage();


        }

        private void Blagajna_Click(object sender, EventArgs e)
        {
            this.Close(); //TOD close ili hide
            var blagajna=new MainScreen();
            blagajna.Show();
            
        }



        private void button_hladnjak_Click(object sender, EventArgs e)
        {
            //treba iskociti forma koja ce ga traziti da upise proizvode //TO DO drop down
            //potvrdom na tu formu treba provjeriti da li postoje ti proizvodi u stanju na skladistu u toj kolicini
            //ako ne postoje, izlazi mu message box diaol da  ne postoji dani proizvod ili dana kolicina te da ponovno unese
           // this.Hide();
            var restoreCooler = new CoolerRestore();
            restoreCooler.Show();
            refresh_storage();




        }

        private void refresh_storage()
        {
            SuspendLayout();
            if (User.isOwner == 0) //konobar -> ne moze vidjeti gumbe button_edit i button_delete
            {
                button_edit.Visible = false;
                button_delete.Visible = false;
            }


            //napuniti data grid sa proizvodima -> dodajem kontrole -> bolje staviti u kontruktor
            try
            {
                //prvo selectirajmo sva pica iz baze
                using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM [PRODUCT]";
                    SqlCommand command = new SqlCommand(query, connection);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            dataGridView1.Rows.Add(reader.GetString(1).ToString(), reader.GetDecimal(2).ToString(), reader.GetInt32(3).ToString(), reader.GetInt32(4).ToString()); //n,c,h,s
                        }
                    }
                    reader.Close();
                }
            }
            catch (Exception ex) { MessageBox.Show("Greska u radu blagajne - dodavanje proizvoda: " + "\n" + ex.ToString()); }
            //to do iskljuciti da se ne vidi zadnji redak u data grid koji je prazan
            ResumeLayout();
        }

        private void button_skladiste_Click(object sender, EventArgs e)
        {
            ///glumi refresh button
            this.Hide();
            var storage = new Storage();
            storage.Show();
        }

        private void button_refresh_Click(object sender, EventArgs e)
        {
            this.Hide();
            var storage = new Storage();
            storage.Show();
        }
    }
}
