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
    public partial class CashBackCalculator : Form
    {
        int total;
        public CashBackCalculator(int ukupno)
        {
            InitializeComponent();
            total= ukupno;
            textBox_iznosRacuna.Text = total.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*if (textBox_primljeniNovac.Text == "")
            {
                MessageBox.Show("unesi primljeni novac"); //TO DO tu po defaultu mozemo staviti 0- mozda konobar ne zeli kalkulator
            }*/

            int ostatak = int.Parse(textBox_primljeniNovac.Text) - int.Parse(textBox_iznosRacuna.Text);
            textBox_ostatak.Text=ostatak.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
