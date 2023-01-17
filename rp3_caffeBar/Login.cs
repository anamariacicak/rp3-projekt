using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rp3_caffeBar
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void login_button_Click(object sender, EventArgs e) //klik na gumb Login
        {
            //je li unio username/password
            if(textBox_username.Text=="" || textBox_password.Text == "") 
            {
                MessageBox.Show("Unesi sve potrebne podatke!"); 
            }


            try
            {
                using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=F:\\Anamaria\\rp3-projekt\\rp3_caffeBar\\caffeBar.mdf;Integrated Security=True"))
                {
                    connection.Open();
                    //SqlCommand command = new SqlCommand("INSERT INTO [USER](USERNAME, PASSWORD)  VALUES(@username, @password)", connection);
                    SqlCommand command = new SqlCommand("SELECT * FROM [USER]", connection);


                    byte[] data = Encoding.UTF8.GetBytes(textBox_password.Text.ToString());
                    byte[] result;

                    using (SHA256 sha256Hash = SHA256.Create())
                    {
                        result = sha256Hash.ComputeHash(data);
                    }

                    string hash = BitConverter.ToString(result).Replace("-", "");
                   


                    command.Parameters.AddWithValue("@username", textBox_username.Text.ToString());
                    command.Parameters.AddWithValue("@password", hash);

                    command.ExecuteNonQuery();

                    var dataReader = command.ExecuteReader();
                    dataReader.Read();
                    var id = dataReader.GetInt32(0);
                    MessageBox.Show(id.ToString());

                    /*try
                    {
                        command.ExecuteNonQuery();
                    }*/
                    //using (SqlCommand command = new SqlCommand("SELECT * FROM [dbo].[LOGIN]", connection))
                    //{
                    /*using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string username = reader.GetString(1);
                            int password = reader.GetInt32(2);
                            Console.WriteLine("ID: {0}, USERNAME: {1}, PASSWORD: {2}", id, username, password);
                        }
                    }*/
                    //}
                }

            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.ToString());
            }

        }
    }
}
