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

            //dodavanje buttona pica -> desni flowLayout1
            SuspendLayout();
            try
            {
                //prvo selectirajmo sva pica iz baze, s prpadajucim cijenama, ukljucujuci i happy hour cijenu
                using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
                {
                    connection.Open();
                    string query = "SELECT [PRODUCT].PRODUCT_NAME, [PRODUCT].PRICE, [PRODUCT].COOLER_QUANTITY, " +
                                        "COALESCE(CONVERT(VARCHAR(10),[HH].HAPPY_HOUR_PRICE),' ') " +
                                    "FROM [PRODUCT] " +
                                    "LEFT JOIN " +
                                        "(SELECT PRODUCT_ID, HAPPY_HOUR_PRICE, BEGIN_TIME, END_TIME " + 
                                        "FROM [HAPPY_HOUR] " +
                                        "WHERE END_TIME > getdate()  AND " + //happy hour mora biti validan
                                        "BEGIN_TIME = (SELECT MAX(BEGIN_TIME) FROM [HAPPY_HOUR] AS H2 WHERE [H2].PRODUCT_ID = [HAPPY_HOUR].PRODUCT_ID)) [HH] " + //dohvacamo zadnji dodani happy hour za taj product -> zadnji je dodan, dakle najtocniji je 
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
                            
                            if (cooler < 1) //ako ga barem jedan moze ga nuditi gostima 
                            {
                                btn.Enabled=false;
                            }
                            
                            if(cooler <= 2) //ako je u hladnjaku manje od dva pica te vrste
                            {
                                MessageBox.Show("U hladnjaku nedostaje " + naziv + ", molimo te nadopuni hladnjak!");
                            }
                       }
                    }
                    reader.Close();
                }
            }
            catch (Exception ex) { MessageBox.Show("MainScreen.cs - MainScreen(): " + "\n" + ex.Message.ToString()); }
            ResumeLayout();
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e) //azuriranje dataGrida ako je konobar upisao kolicinu direktno u stupac
        {
            if (e.ColumnIndex == 1 && e.RowIndex >= 0)
            {
                var cijena = decimal.Parse(dataGridView1[2, e.RowIndex].Value.ToString());
                int kolicina = int.Parse(dataGridView1[1, e.RowIndex].Value.ToString());

                dataGridView1[3, e.RowIndex].Value = cijena * kolicina;
            }
        }
        private void button_izdajRacun_Click(object sender, EventArgs e) //izdaj racun gumb
        {

            //Ima li racun stavki?
            if (dataGridView1.RowCount - 1 <= 0) //racun nema stavki
            {
                MessageBox.Show("Nemoguce izdati prazan racun");
            }

            else //ako postoje stavke na racunu 
            {

                //napravit cemo 4 liste za 4 stupca naseg racuna koje cemo poslati formi Racun koja ce prikazati Racun
                //koristit cemo ih i pri izracunu popusta ovisno o kupcu
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

                                    /***********************konekcija za upite***********************/
                SqlConnection connection = new SqlConnection(ConnectionString.connectionString);

                                    /***********************IZRACUN POPUSTA ZA KONOBARA***********************/
                //treba nam popust u slucaj da je kupac konobar 
                //1. je li kupac konobar
                //2. da, provjeri koliko je kava i cijedenih sokova danas popio, odvojeno
                //3. daj mu popust na onoliko kava koliko ih nije popio i eventualno na 1 sok, inace daj mu popust 20%
                
                int kavaCnt = 0, sokCnt = 0; //koliko ih je popio -> pretpostavimo 0
                if (radioButton_konobar.Checked == true) //konobar //gledamo gdje je user id == customer_id 
                {
                    try
                    {
                        connection.Open();
                        string query = "SELECT [PRODUCT].PRODUCT_NAME, SUM([RECEIPT_ITEM].ITEM_QUANTITY) " + //ispisi ime proizvoda i sumu od danas
                                       "FROM [PRODUCT] " +
                                       "JOIN [RECEIPT_ITEM] ON [PRODUCT].PRODUCT_ID=[RECEIPT_ITEM].PRODUCT_ID " +
                                       "JOIN [RECEIPT] ON [RECEIPT].RECEIPT_ID=[RECEIPT_ITEM].RECEIPT_ID " +
                                       "WHERE [PRODUCT].PRODUCT_NAME IN ('KAVA', 'PRIRODNI SOKOVI') " + //kave i prirodni sokovi
                                       "AND CAST([RECEIPT].TIME AS DATE)=CAST(GETDATE() AS DATE) " + //danas
                                       "AND [RECEIPT].CUSTOMER_ID=[RECEIPT].USER_ID AND [RECEIPT].USER_ID=@userId " +
                                       "GROUP BY [PRODUCT].PRODUCT_NAME"; //po produktu

                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@userId", User.userId);
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
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
                    catch (Exception ex) { MessageBox.Show("MainScreen.cs - POPUST ZA KONOBARA: " + "\n" + ex.Message.ToString()); }

                    
                    //smanji iznos racuna za onoliko koliko je potrebno -> prikazi kao novu stavku na formi racun
                    int cnt = naziv.Count; //dinamicki se mijenja zbog minus stavki za popust, stoga ga moramo pospremiti
                    for (int i = 0; i < cnt; i++) //prodi kroz sve stavke racuna
                    {
                        if (naziv[i] == "KAVA" && kavaCnt < 2) //ima pravo na besplatnu kavu, samo je pitanje na koliko njih
                        {
                            if (int.Parse(kolicina[i]) <= 2 - kavaCnt) //moze dobiti popust za cijelu kolicinu navedene stavke racuna
                            {
                                //dodaj u racun, ali sa MINUS CIJENOM
                                naziv.Add(naziv[i]);
                                kolicina.Add(kolicina[i]);
                                cijena.Add(cijena[i]);

                                //POPUST -> minus cijena
                                decimal popust = decimal.Parse(kolicina[i]) * decimal.Parse(cijena[i]) * decimal.Parse("-1");
                                ukupno.Add(popust.ToString());
                                
                                //azuriraj kavaCnt
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
                        else if (naziv[i] == "KAVA" && kavaCnt >= 2) //ima pravo samo na popust za kavu
                        {
                            naziv.Add(naziv[i]);
                            kolicina.Add(kolicina[i]);
                            cijena.Add(cijena[i]);

                            decimal popust = decimal.Multiply(decimal.Multiply(decimal.Parse(kolicina[i]) , decimal.Parse(cijena[i])) , decimal.Parse("-2"))/10;
                            ukupno.Add(popust.ToString());

                            kavaCnt += int.Parse(kolicina[i]);
                        }

                        if (naziv[i] == "PRIRODNI SOKOVI" && sokCnt < 1) //besplatan jedan sok
                        {
                            int popustCnt = 1; //samo jedan sok

                            naziv.Add(naziv[i]);
                            kolicina.Add(popustCnt.ToString());
                            cijena.Add(cijena[i]);

                            decimal popust = decimal.Parse(popustCnt.ToString()) * decimal.Parse(cijena[i]) * decimal.Parse("-1");
                            ukupno.Add(popust.ToString());

                            sokCnt = 1;
                        }

                        else if (naziv[i] == "PRIRODNI SOKOVI" && sokCnt >= 1) //popust za sok samo
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

                            /***********************insert u tablicu RECEIPT i RECEIPT ITEM***********************/
                //radimo insert u tablicu RECEIPT i RECEIPT ITEM kako bismo dodali stavke racuna
                
                //[RECEIPT] insert
                decimal iznos_racuna = 0;
                for (int i = 0; i < ukupno.Count; i++) //RowCount-1 jer zadnji redak je prazan u dataGrid
                {
                    iznos_racuna += decimal.Parse(ukupno[i]);
                }
               
                try
                {
                    connection.Open();
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
                catch (Exception ex){   MessageBox.Show("MainScreen.cs - prvi upit - INSERT INTO [RECEIPT]: " + "\n" + ex.Message.ToString()); }

                //dohvati id upravo unesena racuna -> treba nam za insert u RECEIPT_ITEM
                int receiptId = -1;
                try
                {
                    String query = "SELECT MAX(RECEIPT_ID) FROM [RECEIPT]"; //to je zadnji racun
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
                catch (Exception ex){ MessageBox.Show("MainScreen.cs - drugi upit: " + "\n" + ex.Message.ToString()); }


                
                for (int i = 0; i < naziv.Count; i++)
                {
                    int productId = -1, coolerQuantity = -1; //product id -> za insert u RECEIPT_ITEM, collerQuantity -> za update [PRODUCT] tablice, tj. micanje pica iz hladnjaka

                    try
                    {
                        String query = "SELECT PRODUCT_ID, COOLER_QUANTITY FROM [PRODUCT] WHERE PRODUCT_NAME=@productName";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            connection.Open();
                            command.Parameters.AddWithValue("@productName", naziv[i]); 
                            SqlDataReader reader = command.ExecuteReader();
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
                    catch (Exception ex) { MessageBox.Show("MainScreen.cs - treci upit: " + "\n" + ex.Message.ToString()); }

                    //[RECEIPT ITEM] insert
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
                    catch(Exception ex) { MessageBox.Show("MainScreen.cs - cetvrti upit - INSERT INTO [RECEIPT_ITEM]: " + "\n" + ex.Message.ToString()); }

                                /***********************update tablice PRODUCT***********************/
                    //naplati -> makni iz hladnjaka -> update kolicine producta u hladnjaku
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
                    catch (Exception ex) { MessageBox.Show("MainScreen.cs - peti upit - UPDATE [PRODUCT]: " + "\n" + ex.Message.ToString()); }

                }

                                        
                                                   /***********************KALKULATOR***********************/
                CashBackCalculator kalkulator = new CashBackCalculator(iznos_racuna);
                kalkulator.ShowDialog();

                //prvo treba pozvati formu za ispis racuna kojoj cemo slati sve sto pise u dataGridu + popusti
                //-> saljemo liste naziv, kolicina, cije, ukupno (tu su spremljene i stavke popust za konobara, ako ih ima)
                //treba napraviti formu za ispis racuna-> svaka stavka racuna moze biti user kontrola - i onda to dodajemo na racun
                //prikazujemo kao show dialog

                                                    /***********************RAČUN FORMA***********************/
                Receipt racun = new Receipt(receiptId, naziv, kolicina, cijena, ukupno);
                racun.ShowDialog();

                //na kraju ocisti sve iz dataGrid
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();

                //radio button na defaultnu vrijednost
                radioButton_obicniKupac.Checked = true;

            }
 
        }

        //ispis Prometa gumb
        private void button_ispisPrometa_Click(object sender, EventArgs e)
        {
            var promet = new PrintPromet();
            promet.Show();
        }


        //gumbi toolStripa vode na novu formu
        private void Skladište_Click(object sender, EventArgs e)
        {
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
        private void button_statistika_Click(object sender, EventArgs e)
        {
            //ekran statistika
            this.Hide();
            var stat = new Statistics();
            stat.Show();
        }
        private void Logout_Click(object sender, EventArgs e)
        {
            this.Close();
            var login = new Login();
            login.Show();

        }



    }
}



