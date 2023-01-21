using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rp3_caffeBar
{

    public partial class MainScreen : Form
    {
        

        public MainScreen()
        {
            InitializeComponent();
           
            //sakrivanje pojednih kontrola ako je user tipa konobar, tj. ako nije vlasnik
            if(User.isOwner == 0 ) { //konobar je
                button_administracija.Visible= false; 
                button_statistika.Visible= false;
            }

            //defaultna vrijednost radio buttona u group boxu za tip kupca je Običan kupac
            radioButton_obicniKupac.Checked = true;

            //dodavanje buttona pica -> na blagajna1.flowLayout1
            SuspendLayout();
            try
            {
                //prvo selectirajmo sva pica iz baze, sprpadajucim cijenama, ukljucujuci i happy hour cijenu
                using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
                {
                    connection.Open();
                    string query = "SELECT [PRODUCT].PRODUCT_NAME, [PRODUCT].PRICE, [PRODUCT].COOLER_QUANTITY, " +
                                        "COALESCE(CONVERT(VARCHAR(10),[HH].HAPPY_HOUR_PRICE),' ') " +
                                    "FROM [PRODUCT] " +
                                    "LEFT JOIN [USER] ON [PRODUCT].LAST_MODIFY_USER =[USER].USER_ID " +
                                    "LEFT JOIN " +
                                        "(SELECT PRODUCT_ID, HAPPY_HOUR_PRICE, BEGIN_TIME, END_TIME, USERNAME " +
                                        "FROM [HAPPY_HOUR] " +
                                        "JOIN [USER] ON [HAPPY_HOUR].CREATE_USER_ID =[USER].USER_ID " +
                                        "WHERE END_TIME > getdate()  AND " +
                                        "BEGIN_TIME = (SELECT MAX(BEGIN_TIME) FROM [HAPPY_HOUR] AS H2 WHERE [H2].PRODUCT_ID = [HAPPY_HOUR].PRODUCT_ID)) [HH] " +
                                    "ON [HH].PRODUCT_ID =[PRODUCT].PRODUCT_ID ";
                    
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            //button svojstva -> pica na flowLayoutPanelu koji se nalazi na desnom dijelu ekrana
                            var btn = new Button();
                            btn.Text = reader.GetString(0).ToString();
                            btn.Margin = new Padding(5, 5, 5, 5);
                            btn.Width = 210;
                          
                            
                            var cooler = reader.GetInt32(2);
                            var naziv = reader.GetString(0).ToString();
                            var productCijena = reader.GetDecimal(1);

                            decimal hhCijena; //moramo provjeriti je li za dani proizvod u tijeku happy hour
                            if(reader.GetString(3)!=" ")
                            {
                                hhCijena =decimal.Parse(reader.GetString(3), CultureInfo.InvariantCulture);
                                if (hhCijena < productCijena) { //ako postoji hhCijena, ona ce biti i povoljnija
                                    productCijena = hhCijena;
                                }  
                            }

                            //sta ako se dogodio klik na button -> dodaj to pice na racun, pazeci na cijenu - happy hour ili regularna
                            btn.Click += (_sender, _e) =>
                            {
                                dataGridView1.Rows.Add(naziv, 1, productCijena.ToString(), productCijena.ToString());
                            };
                            
                            //dodavanje buttona
                            flowLayoutPanel1.Controls.Add(btn);
                            
                            if (cooler < 1) //ako ga ima vise od jedan moze ga nuditi gostima //TO DO TEST
                            {
                                btn.Enabled=false;
                            }
                            
                            if(cooler <= 2)
                            {
                                MessageBox.Show("U hladnjaku nedostaje " + naziv + ", molimo te nadopuni hladnjak!");
                            }
                       }
                    }
                    reader.Close();
                }
            }
            catch (Exception ex) { MessageBox.Show("MainScreen.cs - proizvodi i cijena: " + "\n" + ex.Message.ToString()); }
            ResumeLayout();
        }


        private void button_izdajRacun_Click(object sender, EventArgs e) //izdaj racun gumb
        {

            //Ima li racun stavki?
           

            if (dataGridView1.RowCount - 1 <= 0) //racun nema stavki
            {
                MessageBox.Show("Nemoguce izdati prazan racun");
            }

            else //ako postoje stavke na racunu // TO DO i ako ga ima dovoljno u hladnjaku
            {



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

                SqlConnection connection = new SqlConnection(ConnectionString.connectionString);

                //treba na popust u slucaj da je kupac konobar 
                //1. je li kupac konobar 2. da, provjeri koliko je kava i cijedenih sokova danas popio, odvojeno
                //3. daj mu popust na onoliko kava koliko ih nije popio i eventualno na 1 sok, inace daj mu popust 20%

                int kavaCnt = 0, sokCnt = 0; //koliko ih je popio
                if (radioButton_konobar.Checked == true) //konobar //gledamo gdje je user id == customer_id 
                {
     
                    try
                    {
                        connection.Open();
                        string query = "SELECT [PRODUCT].PRODUCT_NAME, SUM([RECEIPT_ITEM].ITEM_QUANTITY) " +
                                       "FROM [PRODUCT] " +
                                       "JOIN [RECEIPT_ITEM] ON [PRODUCT].PRODUCT_ID=[RECEIPT_ITEM].PRODUCT_ID " +
                                       "JOIN [RECEIPT] ON [RECEIPT].RECEIPT_ID=[RECEIPT_ITEM].RECEIPT_ID " +
                                       "WHERE [PRODUCT].PRODUCT_NAME IN ('KAVA', 'PRIRODNI SOKOVI') " +
                                       "AND CAST([RECEIPT].TIME AS DATE)=CAST(GETDATE() AS DATE) " +
                                       "AND [RECEIPT].CUSTOMER_ID=[RECEIPT].USER_ID AND [RECEIPT].USER_ID=@userId " +
                                       "GROUP BY [PRODUCT].PRODUCT_NAME";

                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@userId", User.userId);
                        SqlDataReader reader = command.ExecuteReader();


                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                //MessageBox.Show("usao cnt" + reader.GetInt32(1).ToString());
                                if (reader.GetString(0) == "KAVA")
                                {
                                    kavaCnt = reader.GetInt32(1);
                                }
                                else if (reader.GetString(0) == "PRIRODNI SOKOVI")
                                {
                                    sokCnt = reader.GetInt32(1);
                                }
                            }
                        }
                        reader.Close();
                        connection.Close();
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }

                    //koliko je kava  i cijedenih sokova dns popio 
                    //smanji iznos racuna za onoliko koliko je potrebno -> prikazi kao popust
                    int cnt = naziv.Count;
                    for (int i = 0; i < cnt; i++)
                    {
                        if (naziv[i] == "KAVA" && kavaCnt < 2)
                        {
                            //kolika je kolicina //cijena i ukupno
                            if (int.Parse(kolicina[i]) <= 2 - kavaCnt)
                            {
                                naziv.Add(naziv[i]);
                                kolicina.Add(kolicina[i]);
                                cijena.Add(cijena[i]);

                                decimal popust = decimal.Parse(kolicina[i]) * decimal.Parse(cijena[i]) * decimal.Parse("-1");
                                ukupno.Add(popust.ToString());

                                kavaCnt += int.Parse(kolicina[i]);

                               
                            }

                            else if (int.Parse(kolicina[i]) > 2 - kavaCnt && kavaCnt < 2) //dodajem popust za 2-kavaCnt
                            {
                                int popustCnt = 2 - kavaCnt;

                                naziv.Add(naziv[i]);
                                kolicina.Add(popustCnt.ToString());
                                cijena.Add(cijena[i]);

                                decimal popust = decimal.Parse(popustCnt.ToString()) * decimal.Parse(cijena[i]) * decimal.Parse("-1");
                                ukupno.Add(popust.ToString());

                                kavaCnt = 2;
                            }

                        }

                        else if (naziv[i] == "KAVA" && kavaCnt >= 2)
                        {


                            naziv.Add(naziv[i]);
                            kolicina.Add(kolicina[i]);
                            cijena.Add(cijena[i]);

                            decimal popust = decimal.Multiply(decimal.Multiply(decimal.Parse(kolicina[i]) , decimal.Parse(cijena[i])) , decimal.Parse("-2"))/10;
                            //MessageBox.Show("usao" + popust.ToString());
                            ukupno.Add(popust.ToString());

                            kavaCnt += int.Parse(kolicina[i]);
                        }

                       if (naziv[i] == "PRIRODNI SOKOVI" && sokCnt < 1)
                        {

                            int popustCnt = 1;

                            naziv.Add(naziv[i]);
                            kolicina.Add(popustCnt.ToString());
                            cijena.Add(cijena[i]);

                            decimal popust = decimal.Parse(popustCnt.ToString()) * decimal.Parse(cijena[i]) * decimal.Parse("-1");
                            ukupno.Add(popust.ToString());

                            sokCnt = 1;
                        }

                        else if (naziv[i] == "PRIRODNI SOKOVI" && sokCnt >= 1)
                        {

                            naziv.Add(naziv[i]);
                            kolicina.Add(kolicina[i]);
                            cijena.Add(cijena[i]);

                            decimal popust = decimal.Multiply(decimal.Multiply(decimal.Parse(kolicina[i]), decimal.Parse(cijena[i])),(decimal)(-2))/10;
                            ukupno.Add(popust.ToString());

                            sokCnt += int.Parse(kolicina[i]);
                        }

                    }


                }

                //radimo insert u tablicu RECEIPT i RECEIPT ITEM kako bismo dodali stavke racuna
                //insert into RECEIPT
                decimal iznos_racuna = 0;
                for (int i = 0; i < ukupno.Count; i++)//RowCount-1 jer zadnji redak je prazan u dataGrid
                {
                    iznos_racuna += decimal.Parse(ukupno[i]);
                }
               
                try
                {
                    connection.Open();

                    //unesi u tablicu
                    String query = "INSERT INTO [RECEIPT] (USER_ID,TOTAL_AMOUNT, CUSTOMER_ID) VALUES (@userId,@totalAmount, @customerId)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        //parametri
                        int customerId = 0;
                        if (radioButton_konobar.Checked == true) { customerId = User.userId; }
                        command.Parameters.AddWithValue("@userId", User.userId);
                        command.Parameters.AddWithValue("@totalAmount", iznos_racuna);
                        command.Parameters.AddWithValue("@customerId", customerId);

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
                        int productId = -1, coolerQuantity = -1;

                        //product id -> za insert u RECEIPT_ITEM
                        try
                        {
                            String query = "SELECT PRODUCT_ID, COOLER_QUANTITY FROM [PRODUCT] WHERE PRODUCT_NAME=@productName";
                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                connection.Open();
                                command.Parameters.AddWithValue("@productName", naziv[i]); //dohvati iz baze 
                                SqlDataReader reader = command.ExecuteReader();
                                //MessageBox.Show("naziv: " + productId);
                                if (reader.HasRows)
                                {
                                    reader.Read();
                                    productId = reader.GetInt32(0);
                                    coolerQuantity = reader.GetInt32(1);

                                }
                                reader.Close();

                                connection.Close();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("greska select product: " + ex.ToString());
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
                                command.Parameters.AddWithValue("@itemAmount", decimal.Parse(ukupno[i])); //username: vlasnik password: vlasnik

                                command.ExecuteNonQuery();

                                connection.Close();

                            }
                        }
                        catch
                        {
                            MessageBox.Show("gresak insert receipt");
                        }

                        //naplati se makni se iz hladnjaka
                        try
                        {
                            String query = "UPDATE [PRODUCT] SET COOLER_QUANTITY=@newCoolerQuantity WHERE PRODUCT_ID=@productId";
                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                connection.Open();
                                //parametri
                                coolerQuantity = coolerQuantity - int.Parse(kolicina[i]);
                                command.Parameters.AddWithValue("@newCoolerQuantity", coolerQuantity); //dohvati iz baze 
                                command.Parameters.AddWithValue("@productId", productId); //dohvati iz baze


                                command.ExecuteNonQuery();

                                connection.Close();

                            }
                        }
                        catch
                        {
                            MessageBox.Show("gresak update hladnjaka");
                        }

                    }

                    /***********************KALKULATOR***********************/
                    CashBackCalculator kalkulator = new CashBackCalculator(iznos_racuna);
                    kalkulator.ShowDialog();

                    //prikaz racuna prema korisniku i update racuna u tablicu //TO DO
                    //prvo treba pozvati formu za ispis racuna kojoj cemo slati sve sto pise u dataGridu + ukupno iznos racuna -> konstruktor te frome
                    //treba napraviti formu za ispis racuna-> svaka stavka racuna moze biti user kontrola - i onda to dodajemo na racun
                    //prikazujemo kao show dialog


                    /***********************RAČUN FORMA***********************/

                    //racun
                    Receipt racun = new Receipt(receiptId, naziv, kolicina, cijena, ukupno);
                    racun.ShowDialog();

                    //na kraju ocisti sve iz dataGrid
                    dataGridView1.DataSource = null;
                    dataGridView1.Rows.Clear();

                    //radio button
                    radioButton_obicniKupac.Checked = true;
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
                var  cijena = decimal.Parse(dataGridView1[2, e.RowIndex].Value.ToString());
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

        private void Skladište_Click(object sender, EventArgs e)
        {
            //TO DO treba li provjeriti je li iznos 0 racuna
            this.Close();
            //skladiste forma
            var storage=new Storage();
            storage.Show();
        }

        private void button_administracija_Click(object sender, EventArgs e)
        {
            // ulaz u novu formu administracija
            this.Close();
            var administracija = new Administration();
            administracija.Show();
        }

        private void button_ispisPrometa_Click(object sender, EventArgs e)
        {
            var promet = new Promet();
            promet.Show();
        }

     

       

    

        private void button_statistika_Click(object sender, EventArgs e)
        {
            //ekran statistika
            this.Hide();
            var stat = new Statistics();
            stat.Show();
        }
    }
}

//TO DO 
// postaviti neke stupce u dataGridView na read only
//connection string
//connection open
//try exceptione


