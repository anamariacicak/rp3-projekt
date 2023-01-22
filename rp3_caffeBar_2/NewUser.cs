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
    public partial class NewUser : Form
    {
        public NewUser()
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
                String query = "INSERT INTO [USER] (USERNAME,PASSWORD,IS_OWNER ) VALUES (@username,@password,@isOwner)";
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
                    command.Parameters.AddWithValue("@isOwner", Int32.Parse(textBox3.Text));

                    //execute
                    command.ExecuteNonQuery();
                }

                connection.Close();
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show("NewUser.cs: " + "\n" + ex.Message); }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
