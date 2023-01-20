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
        public Receipt(int receip_id, List<string> naziv_konstruktor, List<string> kolicina_konstruktor, List<string> cijena_konstruktor, List<string> ukupno_konstruktor, decimal iznos_racuna_konstruktor)
        {
            InitializeComponent();
            naziv = naziv_konstruktor;
            kolicina = kolicina_konstruktor;
            cijena = cijena_konstruktor;
            ukupno = ukupno_konstruktor;
            receiptId= receip_id;
      

            SuspendLayout();

            //postavljamo vrijednost textboxa za broj racuna -> textBox_idRacuna 
            


            //dodajemo stavke racuna kao user controlu recepitItem
            for(int i=0;i<naziv.Count;i++) 
            {
                var item = new recepitItem();
                item.naziv= naziv[i];
                item.kolicina= kolicina[i];
                item.cijena= cijena[i];
                item.ukupno= ukupno[i];

                //add
                flowLayoutPanel1.Controls.Add(item);    
            }

            //postavljamo vrijednost textboxa za iznos racuna
            textBox_ukupno.Text=iznos_racuna_konstruktor.ToString();
            textBox_idRacuna.Text = receiptId.ToString();
            textBox_blagajnikId.Text = User.username.ToString();
            ResumeLayout();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close(); //to do koja je razlika izmedu hide i close
        }

      
    }
}
