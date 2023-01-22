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
                    string query = "SELECT USER_ID, USERNAME, IS_OWNER FROM [USER] " +
                                   "WHERE USERNAME=@username AND PASSWORD=@password AND [USER].IS_ACTIVE=1";
                    SqlCommand command = new SqlCommand(query, connection);

                    //hashiranje passworda 
                    byte[] data = Encoding.UTF8.GetBytes(textBox_password.Text.ToString());
                    byte[] result;
                    using (SHA256 sha256Hash = SHA256.Create()) //generia char(64) -> stupac username u tablici USER varchar(64)
                    {
                        result = sha256Hash.ComputeHash(data);
                    }
                    string hash = BitConverter.ToString(result).Replace("-", "");

                    //parametri
                    command.Parameters.AddWithValue("@username", textBox_username.Text.ToString());
                    command.Parameters.AddWithValue("@password", hash);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows) //upit je vratio nesto -> nalazi se u bazi
                    {
                        //procitaj
                        reader.Read(); 
               
                        //pospremi podatke za usera
                        User.userId = reader.GetInt32(0);
                        User.username = reader.GetString(1);
                        User.isOwner = reader.GetInt32(2);

                        //sakrij ovu formu 
                        this.Hide(); 
                        //prikazi mainScreenForma -> froma koja se prikazuje nakon ulogiravnja, na njoj se prvotno nalazi blagajna
                        var mainScreen = new MainScreen();
                        mainScreen.Show();   
                    }
                    else //upit nije vratio nista -> upozorenje
                    {
                        MessageBox.Show("Neispravno uneseni podaci!");
                    }
                   
                    connection.Close();
                    reader.Close();
                }

            }
            catch (Exception ex) 
            {
                MessageBox.Show("Login.cs: " + "\n"+ ex.Message.ToString());
            }
           
        }

    }
}
