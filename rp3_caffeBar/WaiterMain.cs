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
                                    var naziv = reader.GetString(1).ToString();
                                    var cijena = reader.GetDecimal(2).ToString();
                                    
                                    btn.Click += (_sender, _e) =>
                                    {
                                        
                                        dataGridView1.Rows.Add(naziv, 1, cijena, cijena);
                                    };
                                    flowLayoutPanel1.Controls.Add(btn);
                                }
                            }
                        

                    }


                    //reader.Close();
                }

            }
            catch (Exception e){ MessageBox.Show(e.ToString()); }


            ResumeLayout();

        }

        private void button1_Click(object sender, EventArgs e) //izdaj racun gumb
        {
            //prvo iskoci kalkulator

            //trebamo prvo izracunati ukupnu sumu
            int iznos_racuna = 0;
            for(int i=0; i < dataGridView1.RowCount-1; i++)
            { //RowCount-1 jer zadnji redak je prazan
                iznos_racuna += int.Parse(dataGridView1[3, i].Value.ToString());
                
            }
            if(iznos_racuna == 0)
            {
                MessageBox.Show("Nemoguce izdati prazan racun");
            }
            //MessageBox.Show(ukupno.ToString());
            else //ako postoje stavke na racunu
            {
                //forma za kalkulator
                CashBackCalculator kalkulator = new CashBackCalculator(iznos_racuna);
                kalkulator.ShowDialog();

                //prikaz racuna prema korisniku i update racuna u tablicu //TO DO
                //prvo treba pozvati formu za ispis racuna kojoj cemo slati sve sto pise u dataGridu + ukupno iznos racuna -> konstruktor te frome
                //treba napraviti formu za ispis racuna-> svaka stavka racuna moze biti user kontrola - i onda to dodajemo na racun
                //prikazujemo kao show dialog

                //napravit cemo 4 liste 
                List<string> naziv = new List<string>();
                List<string> kolicina = new List<string>();
                List<string> cijena = new List<string>();
                List<string> ukupno = new List<string>();
                for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                {
                    naziv.Add(dataGridView1[0, i].Value.ToString() );
                    kolicina.Add(dataGridView1[1, i].Value.ToString());
                    cijena.Add(dataGridView1[2, i].Value.ToString());
                    ukupno.Add(dataGridView1[3, i].Value.ToString());
                }


                Receipt racun=new Receipt(naziv, kolicina,cijena, ukupno, iznos_racuna);
                racun.ShowDialog();

                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();


                //na kraju ocisti sve iz dataGrid
                
            }
            

            
        }

        private void WaiterMain_Load(object sender, EventArgs e)
        {
            
           
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex==1  && e.RowIndex>=0) 
            {
                //da bi dobili cijenu po komadu trebam podijeliti sa najvecim mogucim brojem sto mogu 4 (3 ind) stupac sa 3 (ind2)
                int cijena = int.Parse(dataGridView1[2, e.RowIndex].Value.ToString());
                int kolicina = int.Parse(dataGridView1[1, e.RowIndex].Value.ToString());

                dataGridView1[3, e.RowIndex].Value = cijena*kolicina;

            }
        }
    }
}

//TO DO 
// postaviti neke stupce u dataGridView na read only

