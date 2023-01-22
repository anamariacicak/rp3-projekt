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
    public partial class DeleteProduct : Form
    {
        public DeleteProduct()
        {
            InitializeComponent();
            button_delete.Enabled = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //provjeriti je li upisan ispravan naziv proizvoda
            var productName = "";
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM [PRODUCT] WHERE PRODUCT_NAME=@productName";
                    SqlCommand command = new SqlCommand(query, connection);

                    //parametri
                    productName = textBox_nazivProizvoda.Text.ToString();
                    command.Parameters.AddWithValue("@productName", productName);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows) //upit je vratio nesto -> ispravan naziv proizvoda
                    {
                        button_delete.Enabled = true;
                    }
                    else  //mozda je obrisao nesto iz textBoxa pa treba onemoguciti opet gumb za potvrdu brisanja
                    {
                        button_delete.Enabled = false;
                    }
                    reader.Close();
                    connection.Close();
                }
            }
            catch (Exception ex) { MessageBox.Show("DeleteProducts.cs - textBox_proizvod_TextChanged: " + "\n" + ex.ToString()); }
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            //kliknuo je na button delete
            if (button_delete.Enabled == true) 
            {
                //obrisi
                try
                {
                    using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
                    {
                        connection.Open();
                        string query = "DELETE FROM [PRODUCT] WHERE PRODUCT_NAME=@productName";
                        SqlCommand command = new SqlCommand(query, connection);

                        //parametri
                        command.Parameters.AddWithValue("@productName", textBox_nazivProizvoda.Text.ToString());

                        command.ExecuteNonQuery();
                        connection.Close();
                    }

                    this.Close(); //brisanje gototvo, zatvori
                }
                catch (Exception ex) { MessageBox.Show("DeleteProducts.cs - button_delete_Click: " + "\n" + ex.ToString()); } 
            }
        }

        private void button_cancel_Click(object sender, EventArgs e) //odbaci
        {
            this.Close();
        }
    }
}
