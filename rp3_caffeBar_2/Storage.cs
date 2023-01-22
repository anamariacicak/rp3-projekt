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

            SuspendLayout();
            
            if (User.isOwner == 0) //konobar
            {
                //tool strip
                button_administracija.Visible = false;
                button_statistika.Visible = false;
                //desni gumbi
                button_edit.Visible = false;
                button_delete.Visible = false;
                button_addProduct.Visible = false;
                button_happyHour.Visible = false; 
            }


            //napuniti data grid sa proizvodima -> dodajem kontrole 
            try
            {
                //prvo selectirajmo sva pica iz baze, postujuci happy hour
                using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
                {
                    connection.Open();
                    string query = "SELECT  [PRODUCT].PRODUCT_NAME, [PRODUCT].PRICE, [PRODUCT].COOLER_QUANTITY, [PRODUCT].STORAGE_QUANTITY, COALESCE([USER].USERNAME,'NEPOZNATO'), [PRODUCT].LAST_MODIFY_TIME, " +
                                    "COALESCE(CONVERT(VARCHAR(10),[HH].HAPPY_HOUR_PRICE),' '), COALESCE(CONVERT(VARCHAR(30),[HH].BEGIN_TIME, 120),' '), " +
                                    "COALESCE(CONVERT(VARCHAR(30),[HH].END_TIME, 120),' '), COALESCE([HH].USERNAME, ' ') " +
                                    "FROM [PRODUCT] " +
                                    "LEFT JOIN [USER] ON [PRODUCT].LAST_MODIFY_USER =[USER].USER_ID " +
                                    "LEFT JOIN " +
                                        "(SELECT PRODUCT_ID, HAPPY_HOUR_PRICE, BEGIN_TIME, END_TIME, USERNAME " + //imamo podupit za happy hour jer user koji je dodao happy hour, ne mora biti isti onaj koji je zadnji modificirao poizvo (mijenjao mu cijenu,...)
                                        "FROM [HAPPY_HOUR] " +
                                        "JOIN [USER] ON [HAPPY_HOUR].CREATE_USER_ID =[USER].USER_ID " +
                                        "WHERE END_TIME > getdate() AND " + //happy hour mora biti validan
                                        "BEGIN_TIME = (SELECT MAX(BEGIN_TIME) FROM [HAPPY_HOUR] AS H2 WHERE [H2].PRODUCT_ID = [HAPPY_HOUR].PRODUCT_ID)) [HH] " + //trazimo zadnji happy hour
                                    "ON [HH].PRODUCT_ID =[PRODUCT].PRODUCT_ID ";
                    SqlCommand command = new SqlCommand(query, connection);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows) 
                    {
                        while (reader.Read())
                        {
                            string hhBegin = reader.GetString(7), hhEnd = reader.GetString(8);
                            if (hhBegin != " " && hhEnd != " ") //ako postoji happy hour moramo ga fomratirati u zeljeni fomrat drugaciji od onoga u selectu
                            {
                                hhBegin = DateTime.Parse(reader.GetString(7)).ToString();
                                hhEnd = DateTime.Parse(reader.GetString(8)).ToString();
                            }

                            dataGridView1.Rows.Add(reader.GetString(0), reader.GetDecimal(1).ToString(), reader.GetInt32(2).ToString(), reader.GetInt32(3).ToString(),
                                reader.GetString(4), reader.GetDateTime(5).ToString(),
                                reader.GetString(6), hhBegin, hhEnd, reader.GetString(9));
                          
                        }
                    }
                    reader.Close();
                }
            }
            catch (Exception ex) { MessageBox.Show("Storage.cs: " + "\n" + ex.ToString()); }
            ResumeLayout();
        }

        //buttoni na toolStripu i njihovi eventi
        private void Blagajna_Click(object sender, EventArgs e)
        {
            this.Hide();
            var blagajna=new MainScreen();
            blagajna.Show();           
        }
        private void button_skladiste_Click(object sender, EventArgs e)
        {
            this.Hide();
            var storage = new Storage();
            storage.Show();
        }
        private void button_administracija_Click(object sender, EventArgs e)
        {
            this.Hide();
            var administration = new Administration();
            administration.Show();
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            this.Close();
            var login = new Login();
            login.Show();
        }

        //refresh button na DataGridu
        private void button_refresh_Click(object sender, EventArgs e)
        {
            this.Hide();
            var storage = new Storage();
            storage.Show();

        }

        //buttoni na desnom panelu
        private void button_hladnjak_Click(object sender, EventArgs e)
        {
            //treba iskociti forma koja ce ga traziti da upise proizvode 
            //potvrdom na tu formu treba se provjeriti da li postoje ti proizvodi u stanju na skladistu u toj kolicini -> upit na bazu
            var restoreCooler = new RestoreProduct("cooler");
            restoreCooler.ShowDialog();
        }

        private void button_storage_Click(object sender, EventArgs e)
        {
            var restoreStorage = new RestoreProduct("storage");
            restoreStorage.ShowDialog();
        }

        private void button_edit_Click(object sender, EventArgs e)
        {
            var changeNamePrice = new ChangeNamePrice();
            changeNamePrice.ShowDialog();
        }
        private void button_addProduct_Click(object sender, EventArgs e)
        {
            NewProduct Proizvod = new NewProduct();
            Proizvod.ShowDialog();
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            var deleteProduct = new DeleteProduct();
            deleteProduct.ShowDialog();
        }
        private void button_happyHour_Click(object sender, EventArgs e)
        {
            //kliknuo je na gumb happy hour
            //-> otvara se forma koja ga pita koji proizvod
            //-> gumb na formi disable dok ne unese ispravno vrijeme i proizvod 
            var happyHour = new HappyHour();
            happyHour.ShowDialog();
        }

       

       

        

    }
}
