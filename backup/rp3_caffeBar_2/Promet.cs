using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rp3_caffeBar
{
    public partial class Promet : Form
    {
        public Promet()
        {
            InitializeComponent();
           

            SuspendLayout();


            try
            {
                SqlConnection connection = new SqlConnection(ConnectionString.connectionString);
                String query = "SELECT RECEIPT_ID, COALESCE(USERNAME, 'NEPOZNATO'), TOTAL_AMOUNT, TIME FROM [RECEIPT] JOIN [USER] ON [RECEIPT].USER_ID=[USER].USER_ID WHERE CAST(TIME AS Date)=CAST(GETDATE() AS Date)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();



                    /*var time1 = dateTimePicker1.Value.ToString();
                    var time2 = dateTimePicker2.Value.ToString();
                    command.Parameters.AddWithValue("@time1", time1);
                    command.Parameters.AddWithValue("@time2", time2);*/
                    SqlDataReader reader = command.ExecuteReader();
                    
                    //MessageBox.Show("naziv: " + productId);
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            //KONTROLA REDAK
                            var stavka=new prometItem();
                            stavka.brojRacuna = reader.GetInt32(0).ToString();
                            stavka.username= reader.GetString(1).ToString();
                            stavka.cijena= reader.GetDecimal(2).ToString();
                            stavka.vrijeme= reader.GetDateTime(3).ToString();
                            stavka.Margin = new Padding(5, 5, 5, 5);

                            flowLayoutPanel1.Controls.Add(stavka);

                        }
                        

                    }
                    reader.Close();

                    connection.Close();

                }
            }
            catch(Exception ex) 
            {
                MessageBox.Show("gresak Promet.cs: " + ex.Message.ToString());
            }



            ResumeLayout();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
