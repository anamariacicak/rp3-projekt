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
    public partial class PrintPromet : Form
    {
        public PrintPromet()
        {
            InitializeComponent();

            SuspendLayout(); //dodajemo user kontrole promeItem kao redove na flowLAyoutPanle1 forme za ispis racuna
            try
            {
                SqlConnection connection = new SqlConnection(ConnectionString.connectionString);
                String query = "SELECT RECEIPT_ID, COALESCE(USERNAME, 'NEPOZNATO'), TOTAL_AMOUNT, TIME FROM [RECEIPT] JOIN [USER] ON [RECEIPT].USER_ID=[USER].USER_ID WHERE CAST(TIME AS Date)=CAST(GETDATE() AS Date)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            //KONTROLA -> REDAK
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
            catch(Exception ex) { MessageBox.Show("Promet.cs: " + "\n" + ex.Message.ToString()); }
            ResumeLayout();
        }

        private void button1_Click(object sender, EventArgs e) //izlaz
        {
            this.Close();
        }
    }
}
