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
    public partial class HappyHour : Form
    {
        public HappyHour()
        {
            InitializeComponent();
            button_potvrdi.Enabled = false;
            dateTimePicker_begin.Format = DateTimePickerFormat.Custom;
            dateTimePicker_begin.CustomFormat = "dd.MM.yyyy. HH:mm:ss";
            dateTimePicker_end.Format = DateTimePickerFormat.Custom;
            dateTimePicker_end.CustomFormat = "dd.MM.yyyy. HH:mm:ss";
        }

        private void textBox_proizvod_TextChanged(object sender, EventArgs e)
        {
            //utipkao je tekst u textbox->provjerimo je li ispravan, ako je ispravan, onda mu napunimo druga dva tekxtboxa
            var productName = "";
            textBox_trenutnaCijena.Text = "";
            try
            {
                //prvo selectirajmo sva pica iz baze
                using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
                {
                    connection.Open();
                    string query = "SELECT PRICE FROM [PRODUCT] WHERE PRODUCT_NAME=@productName";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        //parametri
                        productName = textBox_proizvod.Text.ToString();
                        command.Parameters.AddWithValue("@productName", productName);

                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows) //tocno jedan redak bi trebao imati
                        {
                            reader.Read();
                            decimal trenutnaCijena = reader.GetDecimal(0);
                            decimal hhCijena = Math.Round((decimal)0.8 * trenutnaCijena, 2); //automatski mu ispunjava sa cijenom nizom od 0.2
                            textBox_trenutnaCijena.Text = trenutnaCijena.ToString();
                            textBox_hhCijena.Text = hhCijena.ToString();
                            button_potvrdi.Enabled = true;

                        }
                        reader.Close();
                    }
                    connection.Close();
                }
            }
            catch (Exception ex) { MessageBox.Show("HappyHour.cs - textBox_proizvod_TextChanged: " + "\n" + ex.ToString()); }
        }

        private void button_potvrdi_Click(object sender, EventArgs e)
        {
            //treba provjeriti je li ispravno unesen datum te je li unesna hh cijena i je li ona niza od trenutne

            var beginTime=dateTimePicker_begin.Text.ToString();
            var endTime=dateTimePicker_end.Text.ToString();
            var hhCijena = Math.Round(decimal.Parse(textBox_hhCijena.Text.ToString()),2);
            var trenutnaCijena = Math.Round(decimal.Parse(textBox_trenutnaCijena.Text.ToString()),2);

            if (string.Compare(beginTime,endTime)<0  && string.Compare(endTime,DateTime.Now.ToString())>0 
                && hhCijena<trenutnaCijena) //mora trajati u buducnosti, pocetak moze biti i u proslosti - no ako je pocetak manji od DateTime.now postavit ce se u tablici pocetak kada korisnik stisne gumb potvrdi - mozda mu se nije dalo mijenjati prvi picker
            {
                //insert u tablicu happy hour 
                SqlConnection connection = new SqlConnection(ConnectionString.connectionString);
                try
                {
                    connection.Open();

                    //dohvat potrebnog product idja
                    int productId = -1;
                    string query = "SELECT PRODUCT_ID FROM [PRODUCT] WHERE PRODUCT_NAME=@productName";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        //parametri
                        var productName = textBox_proizvod.Text.ToString();
                        command.Parameters.AddWithValue("@productName", productName);

                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows) //tocno jedan redak bi trebao imati
                        {
                            reader.Read();
                            productId = reader.GetInt32(0);
                            //MessageBox.Show("usao " + productId.ToString());

                        }
                        reader.Close();
                    }

                    if (productId != -1)
                    {
                        
                        //unesi u tablicu
                        query = "INSERT INTO [HAPPY_HOUR] (PRODUCT_ID, HAPPY_HOUR_PRICE, CREATE_USER_ID, BEGIN_TIME, END_TIME) VALUES (@productId, @hhCijena, @userId, @begin, @end)";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            //parametri
                            var begin= DateTime.Now;
                            var end = dateTimePicker_end.Value;
                            if(string.Compare(beginTime, DateTime.Now.ToString()) > 0)
                            {
                                begin=dateTimePicker_begin.Value;
                            }
                            command.Parameters.AddWithValue("@productId", productId);
                            command.Parameters.AddWithValue("@hhCijena", hhCijena);
                            command.Parameters.AddWithValue("@userId", User.userId);
                            command.Parameters.AddWithValue("@begin", begin);
                            command.Parameters.AddWithValue("@end", end);

                            //execute
                            command.ExecuteNonQuery();
                        }
                    }
                    connection.Close();
                    this.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("button_potvrdi_Click: " + ex.Message);
                }


            }
            else if(string.Compare(beginTime, endTime) > 0 || string.Compare(endTime, DateTime.Now.ToString()) < 0)
            {
                MessageBox.Show("Neispravno unesena datumi!");
            }
            else if(hhCijena >= trenutnaCijena)
            {
                MessageBox.Show("Neispravna Happy Hour cijena!");
            }
        }

        private void button_odustani_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
