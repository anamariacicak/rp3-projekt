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
    public partial class ProductRestore : Form
    {
        string restoreType;
        public ProductRestore(string coolerOrStorage)
        {
            InitializeComponent();

            if (coolerOrStorage == "storage")
            {
                button_dodaj.Text = "Naruči!";
                label3.Text = "Količina za \nnaručiti: ";
            }

            //nema ga dok ne unese ispravno ime
            button_dodaj.Enabled= false;
            restoreType= coolerOrStorage;

        }

        private void textBox_proizvod_TextChanged(object sender, EventArgs e)
        {

            //utipkao je tekst u textbox->provjerimo je li ispravan, ako je ispravan, onda mu napunimo druga dva tekxtboxa
            var productName = "";
            textBox_hladnjak.Text = "";
            textBox_skladiste.Text = "";
            try
            {
                //prvo selectirajmo sva pica iz baze
                using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
                {
                    connection.Open();
                    string query = "SELECT COOLER_QUANTITY, STORAGE_QUANTITY FROM [PRODUCT] WHERE PRODUCT_NAME=@productName";
                    SqlCommand command = new SqlCommand(query, connection);

                    //parametri
                    productName = textBox_proizvod.Text.ToString();
                    command.Parameters.AddWithValue("@productName", productName);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        textBox_hladnjak.Text=reader.GetInt32(0).ToString();
                        textBox_skladiste.Text=reader.GetInt32(1).ToString();
                        button_dodaj.Enabled = true;

                    }
                    reader.Close();
                    connection.Close();
                }
            }
            catch (Exception ex) { MessageBox.Show("CoolerRestore.cs - textBox_proizvod_TextChanged: " + "\n" + ex.ToString()); }

            
        }

        private void button_dodaj_Click(object sender, EventArgs e)
        {
            if(textBox_proizvod.Text!="" && textBox_hladnjak.Text != "" && textBox_skladiste.Text != "" && textBox_dodati.Text!=""
                && int.Parse(textBox_dodati.Text.ToString()) <= int.Parse(textBox_skladiste.Text.ToString()) && restoreType=="cooler")  //ako nesto pise i ispravno je
            {
                //radimo update u bazu na hladnjak
                try
                {
                    //prvo selectirajmo sva pica iz baze
                    using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
                    {
                        connection.Open();
                        string query = "UPDATE [PRODUCT] SET COOLER_QUANTITY=@newQuantityCooler, STORAGE_QUANTITY=@newQuantityStorage, LAST_MODIFY_USER=@userId, LAST_MODIFY_TIME=@modfiyTime WHERE PRODUCT_NAME=@productName";
                        SqlCommand command = new SqlCommand(query, connection);

                        //parametri
                        //if (int.Parse(textBox_dodati.Text.ToString()) <= int.Parse(textBox_skladiste.Text.ToString())){
                        int newQuantity = int.Parse(textBox_hladnjak.Text.ToString()) + int.Parse(textBox_dodati.Text.ToString());
                        int newQuantityStorage = int.Parse(textBox_skladiste.Text.ToString()) - int.Parse(textBox_dodati.Text.ToString());
                        var modfiyTime = DateTime.Now;
                        var productName = textBox_proizvod.Text.ToString();
                        command.Parameters.AddWithValue("@newQuantityCooler", newQuantity);
                        command.Parameters.AddWithValue("@newQuantityStorage", newQuantityStorage);
                        command.Parameters.AddWithValue("@userId", User.userId);
                        command.Parameters.AddWithValue("@modfiyTime", modfiyTime);
                        command.Parameters.AddWithValue("@productName", productName);

                        command.ExecuteNonQuery();

                        connection.Close();
                        //zatvori ovu formu otvori novu storage
                        this.Close();
                        /*var storage=new Storage(); //to do sinkronizacija
                        storage.Show();*/
                        //}
                        //else
                        //{
                       
                        //}
                    }
  
                }
                catch (Exception ex) { MessageBox.Show("CoolerRestore.cs - button_dodaj_Click: " + "\n" + ex.ToString()); }
            }
            else if (textBox_proizvod.Text != "" && textBox_hladnjak.Text != "" && textBox_skladiste.Text != "" && textBox_dodati.Text != ""
                && restoreType == "storage")  //ako nesto pise i ispravno je
            {
                //radimo update u bazu na storage
                try
                {
                    //prvo selectirajmo sva pica iz baze
                    using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
                    {
                        connection.Open();
                        string query = "UPDATE [PRODUCT] SET STORAGE_QUANTITY=@newQuantityStorage, LAST_MODIFY_USER=@userId, LAST_MODIFY_TIME=@modfiyTime WHERE PRODUCT_NAME=@productName";
                        SqlCommand command = new SqlCommand(query, connection);

                        //parametri
                        //if (int.Parse(textBox_dodati.Text.ToString()) <= int.Parse(textBox_skladiste.Text.ToString())){
                        int newQuantityStorage = int.Parse(textBox_skladiste.Text.ToString()) + int.Parse(textBox_dodati.Text.ToString());
                        var modfiyTime = DateTime.Now;
                        var productName = textBox_proizvod.Text.ToString();
                        command.Parameters.AddWithValue("@newQuantityStorage", newQuantityStorage);
                        command.Parameters.AddWithValue("@userId", User.userId);
                        command.Parameters.AddWithValue("@modfiyTime", modfiyTime);
                        command.Parameters.AddWithValue("@productName", productName);

                        command.ExecuteNonQuery();

                        connection.Close();
                        
                        //zatvori ovu formu otvori novu storage
                        this.Close();
                   
                    }

                }
                catch (Exception ex) { MessageBox.Show("StorageRestore.cs - button_dodaj_Click: " + "\n" + ex.ToString()); }
            }
            else
            {
                MessageBox.Show("Nedovoljno proizvoda u skladistu");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
