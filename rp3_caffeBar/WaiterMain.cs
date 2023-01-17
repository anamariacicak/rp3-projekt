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
    public partial class WaiterMain : Form
    {
        public WaiterMain()
        {
            InitializeComponent();


            //dodavanje buttona pica-> na blagajna1.flowLayout1
            //prvo selectirajmo sva pica iz baze
            SuspendLayout();
            try
            {

                using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=F:\\Anamaria\\rp3-projekt\\rp3_caffeBar\\caffeBar.mdf;Integrated Security=True"))
                {

                    connection.Open();
                    string query = "SELECT * FROM [PRODUCT]";
                    SqlCommand command = new SqlCommand(query, connection);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {

                       
                        
                            while (reader.Read())
                            {
                                for (int i = 0; i < 10; i++)
                                {
                                    var btn = new Button();
                                    btn.Text = reader.GetString(1).ToString();
                                    btn.Margin = new Padding(5, 5, 5, 5);

                                    btn.Click += (_sender, _e) =>
                                    {
                                        MessageBox.Show(btn.Text.ToString());
                                    };
                                    flowLayoutPanel1.Controls.Add(btn);
                                }
                            }
                        

                    }


                    reader.Close();
                }

            }
            catch (Exception e){ MessageBox.Show(e.ToString()); }


            ResumeLayout();

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void WaiterMain_Load(object sender, EventArgs e)
        {
            
           
        }
    }
}
