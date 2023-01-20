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
    public partial class NoviKorisnik : Form
    {
        public NoviKorisnik()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //insert into USER
            SqlConnection connection = new SqlConnection(ConnectionString.connectionString);
            try
            {
                connection.Open();

                //unesi u tablicu
                String query = "INSERT INTO [USER] (USERNAME,PASSWORD) VALUES (@username,@password)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    //hashiranje passworda //TO DO u fju
                    byte[] data = Encoding.UTF8.GetBytes(textBox2.Text.ToString());
                    byte[] result;
                    using (SHA256 sha256Hash = SHA256.Create()) //generia char(64)
                    {
                        result = sha256Hash.ComputeHash(data);
                    }
                    string hash = BitConverter.ToString(result).Replace("-", "");

                    //parametri
                    command.Parameters.AddWithValue("@username", textBox1.Text);
                    command.Parameters.AddWithValue("@password", hash); //username: vlasnik password: vlasnik

                    //execute
                    command.ExecuteNonQuery();
                }

                connection.Close();
                this.Close();
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}
