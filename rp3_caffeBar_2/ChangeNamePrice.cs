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
    public partial class ChangeNamePrice : Form
    {
        public ChangeNamePrice()
        {
            InitializeComponent();

            button_primjeni.Enabled = false; //nema gumba primjeni nisu uneseni ispravni podaci 
        }

        private void textBox_proizvodStari_TextChanged(object sender, EventArgs e)
        {

            //utipkao je tekst u textbox->provjerimo je li ispravanxa
            var productName = "";
            textBox_cijenaStara.Text = "";
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
                {
                    connection.Open();
                    string query = "SELECT PRICE FROM [PRODUCT] WHERE PRODUCT_NAME=@productName";
                    SqlCommand command = new SqlCommand(query, connection);

                    //parametri
                    productName = textBox_proizvodStari.Text.ToString();
                    command.Parameters.AddWithValue("@productName", productName);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        textBox_cijenaStara.Text = reader.GetDecimal(0).ToString();
                        button_primjeni.Enabled = true; //enable

                    }
                    else { button_primjeni.Enabled = false; } //mozda je mijenjao text u texboxu
                    reader.Close();
                    connection.Close();
                }
            }
            catch (Exception ex) { MessageBox.Show("CoolerRestore.cs - textBox_proizvod_TextChanged: " + "\n" + ex.ToString()); }

        }

        private void button_primjeni_Click(object sender, EventArgs e)
        {
            decimal novaCijena=0;
            try
            {
                novaCijena = decimal.Parse(textBox_cijenaNova.Text.ToString());
            }
            catch{}

            if (textBox_cijenaStara.Text != "" && textBox_cijenaNova.Text!="" && textBox_proizvodNovi.Text!="" && novaCijena > 0)  //ako nesto pise i ispravno je
            {
                //radimo update u bazu na storage
                try
                {
                    using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
                    {
                        connection.Open();
                        string query = "UPDATE [PRODUCT] SET PRODUCT_NAME=@productNewName, PRICE=@price, LAST_MODIFY_USER=@userId, LAST_MODIFY_TIME=@modfiyTime WHERE PRODUCT_NAME=@productOldName";
                        SqlCommand command = new SqlCommand(query, connection);

                        //parametri
                        var productNewName = textBox_proizvodNovi.Text.ToString();
                        decimal price = decimal.Parse(textBox_cijenaNova.Text.ToString());
                        var modfiyTime = DateTime.Now;
                        var productOldName = textBox_proizvodStari.Text.ToString();
                        command.Parameters.AddWithValue("@productNewName", productNewName);
                        command.Parameters.AddWithValue("@price", price);
                        command.Parameters.AddWithValue("@userId", User.userId);
                        command.Parameters.AddWithValue("@modfiyTime", modfiyTime);
                        command.Parameters.AddWithValue("@productOldName", productOldName);

                        command.ExecuteNonQuery();

                        connection.Close();

                        //zatvori ovu formu 
                        this.Close();
                    }
                }
                catch (Exception ex) { MessageBox.Show("chaneNamePrice.cs - button_primjeni_Click: " + "\n" + ex.ToString()); }
            }
            else
            {
                if(novaCijena==0)
                {
                    MessageBox.Show("Neispravno unesena nova cijena ili u neispravnom formatu!");
                }
                else
                    MessageBox.Show("Provjeri unesene podatke! \n Svi podaci nisu unesi ili su u neispravnom formatu");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
