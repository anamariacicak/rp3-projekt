using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rp3_caffeBar
{

    public partial class MainScreen : Form
    {
        String connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=F:\\Anamaria\\rp3-projekt\\rp3_caffeBar\\caffeBar.mdf;Integrated Security=True";
        //String connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Dea\\Documents\\GitHub\\rp3-projekt\\rp3_caffeBar\\caffeBar.mdf;Integrated Security=True";

        public MainScreen()
        {
            InitializeComponent();
           
            if(User.isOwner == 0 ) { 
                Administracija.Visible= false;
            
            }
            //dodavanje buttona pica-> na blagajna1.flowLayout1
            
            SuspendLayout();
            try
            {
                //prvo selectirajmo sva pica iz baze
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM [PRODUCT]";
                    SqlCommand command = new SqlCommand(query, connection);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var btn = new Button();
                            btn.Text = reader.GetString(1).ToString();
                            btn.Margin = new Padding(5, 5, 5, 5);
                            btn.Width = 210;
                            var naziv = reader.GetString(1).ToString();
                            var cijena = reader.GetDecimal(2).ToString();

                            btn.Click += (_sender, _e) =>
                            {

                                dataGridView1.Rows.Add(naziv, 1, cijena, cijena);
                            };
                            flowLayoutPanel1.Controls.Add(btn);

                        }
                    }
                    reader.Close();
                }
            }
            catch (Exception e) { MessageBox.Show("Greska u radu blagajne - dodavanje proizvoda: " + "\n" + e.ToString()); }
            ResumeLayout();
        }


        private void button_izdajRacun_Click(object sender, EventArgs e) //izdaj racun gumb
        {

            //Ima li racun stavki?
            int iznos_racuna = 0;
            for (int i = 0; i < dataGridView1.RowCount - 1; i++)//RowCount-1 jer zadnji redak je prazan u dataGrid
            {
                iznos_racuna += int.Parse(dataGridView1[3, i].Value.ToString());
            }

            if (iznos_racuna == 0) //racun nema stavki
            {
                MessageBox.Show("Nemoguce izdati prazan racun");
            }

            else //ako postoje stavke na racunu
            {
                /***********************KALKULATOR***********************/
                CashBackCalculator kalkulator = new CashBackCalculator(iznos_racuna);
                kalkulator.ShowDialog();

                //prikaz racuna prema korisniku i update racuna u tablicu //TO DO
                //prvo treba pozvati formu za ispis racuna kojoj cemo slati sve sto pise u dataGridu + ukupno iznos racuna -> konstruktor te frome
                //treba napraviti formu za ispis racuna-> svaka stavka racuna moze biti user kontrola - i onda to dodajemo na racun
                //prikazujemo kao show dialog


                /***********************RAČUN FORMA***********************/

                //napravit cemo 4 liste za 4 stupca naseg racuna koje cemo poslati formi racun
                List<string> naziv = new List<string>();
                List<string> kolicina = new List<string>();
                List<string> cijena = new List<string>();
                List<string> ukupno = new List<string>();
                for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                {
                    naziv.Add(dataGridView1[0, i].Value.ToString());
                    kolicina.Add(dataGridView1[1, i].Value.ToString());
                    cijena.Add(dataGridView1[2, i].Value.ToString());
                    ukupno.Add(dataGridView1[3, i].Value.ToString());
                }

                //radimo insert u tablicu RECEIPT i RECEIPT ITEM kako bismo dodali stavke racuna
                //insert into RECEIPT
                SqlConnection connection = new SqlConnection(connectionString);
                try
                {
                    connection.Open();

                    //unesi u tablicu
                    String query = "INSERT INTO [RECEIPT] (USER_ID,TOTAL_AMOUNT) VALUES (@userId,@totalAmount)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        //parametri
                        command.Parameters.AddWithValue("@userId", User.userId);
                        command.Parameters.AddWithValue("@totalAmount", iznos_racuna); //username: vlasnik password: vlasnik

                        //execute
                        command.ExecuteNonQuery();
                    }

                    connection.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("prvi upit - INSERT INTO [RECEIPT]: " + ex.Message);
                }

                //dohvati id upravo uneseno racuna -> treba nam za insert u RECEIPT_ITEM
                int receiptId = -1;
                try
                {
                    String query = "SELECT MAX(RECEIPT_ID) FROM [RECEIPT]";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();

                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            reader.Read();
                            receiptId = reader.GetInt32(0);
                        }
                        reader.Close();

                        connection.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("select from receipt: " + ex.Message);
                }

                if (receiptId != -1)
                {
                    for (int i = 0; i < naziv.Count; i++)
                    {
                        int productId = -1;

                        //product id -> za insert u RECEIPT_ITEM
                        try
                        {
                            String query = "SELECT PRODUCT_ID FROM [PRODUCT] WHERE PRODUCT_NAME=@productName";
                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                connection.Open();
                                //parametri
                                //MessageBox.Show("naziv: " + naziv[i]);
                                command.Parameters.AddWithValue("@productName", naziv[i]); //dohvati iz baze 
                                SqlDataReader reader = command.ExecuteReader();
                                //MessageBox.Show("naziv: " + productId);
                                if (reader.HasRows)
                                {
                                    reader.Read();
                                    productId = reader.GetInt32(0);

                                }
                                reader.Close();

                                connection.Close();
                            }
                        }
                        catch (Exception exx)
                        {
                            MessageBox.Show("greska select product");
                        }

                        try
                        {
                            String query = "INSERT INTO [RECEIPT_ITEM] (RECEIPT_ID,PRODUCT_ID, ITEM_QUANTITY, ITEM_AMOUNT) VALUES (@receiptId,@productId, @itemQuantity, @itemAmount)";
                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                connection.Open();
                                //parametri
                                command.Parameters.AddWithValue("@receiptId", receiptId); //dohvati iz baze 
                                command.Parameters.AddWithValue("@productId", productId); //dohvati iz baze
                                command.Parameters.AddWithValue("@itemQuantity", int.Parse(kolicina[i]));
                                command.Parameters.AddWithValue("@itemAmount", int.Parse(ukupno[i])); //username: vlasnik password: vlasnik

                                command.ExecuteNonQuery();

                                connection.Close();

                            }
                        }
                        catch
                        {
                            MessageBox.Show("gresak insert receipt");
                        }

                    }
                    //poziv forme
                    Receipt racun = new Receipt(receiptId, naziv, kolicina, cijena, ukupno, iznos_racuna);
                    racun.ShowDialog();

                    //na kraju ocisti sve iz dataGrid
                    dataGridView1.DataSource = null;
                    dataGridView1.Rows.Clear();
                }

                else
                {
                    MessageBox.Show("greska u dohvatu receipt id else");
                }

            }

        }

    

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.RowIndex >= 0)
            {
                //da bi dobili cijenu po komadu trebam podijeliti sa najvecim mogucim brojem sto mogu 4 (3 ind) stupac sa 3 (ind2)
                int cijena = int.Parse(dataGridView1[2, e.RowIndex].Value.ToString());
                int kolicina = int.Parse(dataGridView1[1, e.RowIndex].Value.ToString());

                dataGridView1[3, e.RowIndex].Value = cijena * kolicina;

            }
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            this.Close();
            var login=new Login();
            login.Show();

        }
    }
}

//TO DO 
// postaviti neke stupce u dataGridView na read only
//connection string
//connection open
//try exceptione
//for petlja za dodavanje na flowlayout kada andrea doda proizvode

