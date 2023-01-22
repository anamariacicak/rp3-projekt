using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rp3_caffeBar
{
    public partial class Receipt : Form
    {
        List<string> naziv = new List<string>();
        List<string> kolicina = new List<string>();
        List<string> cijena = new List<string>();
        List<string> ukupno = new List<string>();
        int receiptId;
        
        public Receipt(int receipt_id, List<string> naziv_konstruktor, List<string> kolicina_konstruktor, List<string> cijena_konstruktor, List<string> ukupno_konstruktor)
        {
            InitializeComponent();
            naziv = naziv_konstruktor;
            kolicina = kolicina_konstruktor;
            cijena = cijena_konstruktor;
            ukupno = ukupno_konstruktor;
            receiptId= receipt_id;

            SuspendLayout();

            decimal iznos_racuna = 0;
            for (int i = 0; i < ukupno.Count; i++)
            {
                iznos_racuna += decimal.Parse(ukupno[i]);
            }

            //postavljamo vrijednost textboxa 
            textBox_ukupno.Text = iznos_racuna.ToString();
            textBox_idRacuna.Text = receiptId.ToString();
            textBox_blagajnikId.Text = User.username.ToString();

            //dodajemo stavke racuna kao user controlu recepitItem
            for (int i=0;i<naziv.Count;i++) 
            {
                var item = new recepitItem();
                item.naziv= naziv[i];
                item.kolicina= kolicina[i];
                item.cijena= cijena[i];
                item.ukupno= ukupno[i];

                //add
                flowLayoutPanel1.Controls.Add(item);    
            }

            ResumeLayout();

        }

        private void button1_Click(object sender, EventArgs e) //Izlaz
        {
            this.Close(); 
        }

    }
}
