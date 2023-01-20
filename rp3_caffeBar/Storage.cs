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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

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
                button_addProduct.Visible = false;
                button_happyHour.Visible = false; //to do
            }


            //napuniti data grid sa proizvodima -> dodajem kontrole -> bolje staviti u kontruktor
            try
            {
                //prvo selectirajmo sva pica iz baze
                using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
                {
                    connection.Open();
                    string query = "SELECT  [PRODUCT].PRODUCT_NAME, [PRODUCT].PRICE, [PRODUCT].COOLER_QUANTITY, [PRODUCT].STORAGE_QUANTITY, COALESCE([USER].USERNAME,'NEPOZNATO'), [PRODUCT].LAST_MODIFY_TIME, " +
                                    "COALESCE(CONVERT(VARCHAR(10),[HH].HAPPY_HOUR_PRICE),' '), COALESCE(CONVERT(VARCHAR(30),[HH].BEGIN_TIME, 120),' '), " +
                                    "COALESCE(CONVERT(VARCHAR(30),[HH].END_TIME, 120),' '), COALESCE([HH].USERNAME, ' ') " +
                                    "FROM [PRODUCT] " +
                                    "LEFT JOIN [USER] ON [PRODUCT].LAST_MODIFY_USER =[USER].USER_ID " +
                                    "LEFT JOIN " +
                                        "(SELECT PRODUCT_ID, HAPPY_HOUR_PRICE, BEGIN_TIME, END_TIME, USERNAME "+ 
                                        "FROM [HAPPY_HOUR] "+
                                        "JOIN [USER] ON [HAPPY_HOUR].CREATE_USER_ID =[USER].USER_ID "+
                                        "WHERE CAST(END_TIME as Date)> CAST(getdate() AS Date) AND " +
                                        "BEGIN_TIME = (SELECT MAX(BEGIN_TIME) FROM [HAPPY_HOUR] AS H2 WHERE [H2].PRODUCT_ID = PRODUCT_ID)) [HH] " +
                                    "ON [HH].PRODUCT_ID =[PRODUCT].PRODUCT_ID ";
                    SqlCommand command = new SqlCommand(query, connection);
                   // SqlCommand command2 = new SqlCommand(query2, connection);

                    SqlDataReader reader = command.ExecuteReader();
                    //SqlDataReader reader2 = command2.ExecuteReader();
                    if (reader.HasRows)// && reader2.HasRows) // isti broj redaka ni trebali imati jer radimo left join na istu pocetnu tablic PRODUCT
                    {
                       // while (reader.Read() && reader2.Read())
                       while(reader.Read()) 
                        {
                            string hhBegin= reader.GetString(7), hhEnd= reader.GetString(8);
                            if (hhBegin!=" " && hhEnd!=" ")
                            {
                                hhBegin = DateTime.Parse(reader.GetString(7)).ToString();
                                hhEnd = DateTime.Parse(reader.GetString(8)).ToString();
                            }


                            dataGridView1.Rows.Add(reader.GetString(0), reader.GetDecimal(1).ToString(), reader.GetInt32(2).ToString(), reader.GetInt32(3).ToString(),
                                reader.GetString(4), reader.GetDateTime(5).ToString(),
                                reader.GetString(6), hhBegin, hhEnd , reader.GetString(9));
                                //,reader.GetDateTime(7).ToString(),reader.GetDateTime(8).ToString(),reader.GetString(9));
                                //reader2.GetInt32(0).ToString(), reader2.GetDateTime(1).ToString(), reader2.GetDateTime(2).ToString(), reader2.GetString(3).ToString()); //n,c,h,s, user, vrijeme
                        }
                    }
                    reader.Close();
                   // reader2.Close();
                }
            }
            catch (Exception ex) { MessageBox.Show("Greska u radu STORAGE - DATAGRID: " + "\n" + ex.ToString()); }
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

        private void button_happyHour_Click(object sender, EventArgs e)
        {
            //kliknuo je na gumb happy hour -> otvara se forma koja ga pita koji proizvod -> gumb na formi disable dok ne unese ispravno vrijeme i proizvod 
            var happyHour=new HappyHour();
            happyHour.Show();
        }
    }
}
