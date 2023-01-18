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


        private void refresh_storage() //to do treba li nam ova fja
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
                    string query = "SELECT PRODUCT_NAME, PRICE, COOLER_QUANTITY, STORAGE_QUANTITY, USERNAME, LAST_MODIFY_TIME FROM [PRODUCT] JOIN [USER] ON LAST_MODIFY_USER=USER_ID";
                    SqlCommand command = new SqlCommand(query, connection);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            dataGridView1.Rows.Add(reader.GetString(0).ToString(), reader.GetDecimal(1).ToString(), reader.GetInt32(2).ToString(), reader.GetInt32(3).ToString(), reader.GetString(4).ToString(), reader.GetDateTime(5).ToString()); //n,c,h,s, user, vrijeme
                        }
                    }
                    reader.Close();
                }
            }
            catch (Exception ex) { MessageBox.Show("Greska u radu blagajne - dodavanje proizvoda: " + "\n" + ex.ToString()); }
            //to do iskljuciti da se ne vidi zadnji redak u data grid koji je prazan
            ResumeLayout();
        }

        //buttoni na toolStripu i njihovi eventi
        private void Blagajna_Click(object sender, EventArgs e)
        {
            this.Close(); //TOD close ili hide
            var blagajna=new MainScreen();
            blagajna.Show();
            
        }

        private void button_skladiste_Click(object sender, EventArgs e)
        {
            ///glumi refresh button
            this.Hide();
            var storage = new Storage();
            storage.Show();
        }

        private void button_administracija_Click(object sender, EventArgs e)
        {
            this.Hide();
            var administration = new Administracija();
            administration.Show();
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            this.Close();
            var login = new Login();
            login.Show();
        }

        //buttoni na desnom panelu

        private void button_hladnjak_Click(object sender, EventArgs e)
        {
            //treba iskociti forma koja ce ga traziti da upise proizvode //TO DO drop down
            //potvrdom na tu formu treba provjeriti da li postoje ti proizvodi u stanju na skladistu u toj kolicini
            //ako ne postoje, izlazi mu message box diaol da  ne postoji dani proizvod ili dana kolicina te da ponovno unese
           // this.Hide();
            var restoreCooler = new RestoreProduct("cooler");
            restoreCooler.Show();
           // refresh_storage(); //TO DO TREBALI MI OVO U FJI


        }

        private void button_storage_Click(object sender, EventArgs e)
        {
            var restoreStorage = new RestoreProduct("storage");
            restoreStorage.Show();
           // refresh_storage(); //TO DO TREBALI MI OVO U FJI
        }

        private void button_edit_Click(object sender, EventArgs e)
        {
            //PROMIJENI NAZIV CIJENU GUMB
            var changeNamePrice = new ChangeNamePrice();
            changeNamePrice.Show();
           // refresh_storage(); //TO DO TREBALI MI OVO U FJI
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            var deleteProduct = new DeleteProduct();
            deleteProduct.Show();
        }

        private void button_refresh_Click(object sender, EventArgs e)
        {
            this.Hide();
            var storage = new Storage();
            storage.Show();
        }

        
    }
}
