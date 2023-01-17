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
                using (SqlConnection connection = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = F:\Anamaria\rp3 - projekt\rp3_caffeBar\caffeBar.mdf; Integrated Security = True"))
                {
                    connection.Open();
                    string query = "SELECT IS_OWNER FROM [USER] WHERE USERNAME=@username AND PASSWORD=@password";
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
                        this.Hide(); //sakrij ovu formu
                       //prikazi glavnu formu
                       reader.Read(); //procitaj
                       if(reader.GetInt32(0) == 0) //konobar
                        {
                            var waiterForm=new WaiterMain();
                            waiterForm.Show();
                        }
                        else //vlasnik
                        {
                            var ownerForm = new OwnerMain();
                            ownerForm.Show();
                        }
                        //prikaz glavne forme
                        /*while (reader.Read())
                        {
                            MessageBox.Show("id: " + reader.GetInt32(0).ToString() + " username: " + reader.GetString(1).ToString() + " password: " + reader.GetString(2).ToString());
                         
                        }*/
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
                MessageBox.Show(ex.ToString());
            }

        }
    }
}
