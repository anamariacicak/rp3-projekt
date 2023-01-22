using System;
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
    public partial class NewProduct : Form
    {
        public NewProduct()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //insert into PRODUCT
            SqlConnection connection = new SqlConnection(ConnectionString.connectionString);
            try
            {
                connection.Open();

                //unesi u tablicu
                String query = "INSERT INTO [PRODUCT] (PRODUCT_NAME,PRICE,COOLER_QUANTITY,STORAGE_QUANTITY) VALUES (@productName,@price,@coolerQuantity,@storageQuantity)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    //parametri
                    command.Parameters.AddWithValue("@productName", textBox1.Text);
                    command.Parameters.AddWithValue("@price", Int32.Parse(textBox2.Text));
                    command.Parameters.AddWithValue("@coolerQuantity", 0);
                    command.Parameters.AddWithValue("@storageQuantity", Int32.Parse(textBox3.Text));

                    //execute
                    command.ExecuteNonQuery();
                }

                connection.Close();
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show("NoviProizvod.cs: " + "\n" + ex.Message.ToString()); }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
