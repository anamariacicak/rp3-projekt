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
                //select iz baze
                //koristeno https://learn.microsoft.com/en-us/dotnet/framework/data/adonet/retrieving-data-using-a-datareader
                using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
                {
                    connection.Open();
                    string query = "SELECT USER_ID, USERNAME, IS_OWNER FROM [USER] WHERE USERNAME=@username AND PASSWORD=@password";
                    SqlCommand command = new SqlCommand(query, connection);


                    //hashiranje passworda //TO DO u fju
                    byte[] data = Encoding.UTF8.GetBytes(textBox_password.Text.ToString());
                    byte[] result;
                    using (SHA256 sha256Hash = SHA256.Create()) //generia char(64)
                    {
                        result = sha256Hash.ComputeHash(data);
                    }
                    string hash = BitConverter.ToString(result).Replace("-", "");

                    //parametri
                    command.Parameters.AddWithValue("@username", textBox_username.Text.ToString());
                    command.Parameters.AddWithValue("@password", hash);

                    
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        this.Hide(); //sakrij ovu formu //TO DO 
                        
                        reader.Read(); //procitaj
               
                        //User
                        User.userId = reader.GetInt32(0);
                        User.username = reader.GetString(1);
                        User.isOwner = reader.GetInt32(2);

                        //main Screen Forma
                        var mainScreen = new MainScreen();
                        mainScreen.Show();
                       
                    }
                    else
                    {
                        MessageBox.Show("Neispravno uneseni podaci!");
                    }
                   
                    reader.Close();
                }

            }
            catch (Exception ex) 
            {
                MessageBox.Show("greska: " + ex.ToString());
            }
           
        }

        private void Login_Load(object sender, EventArgs e)
        {
 
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
