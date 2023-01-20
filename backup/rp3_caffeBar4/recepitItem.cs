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
    public partial class recepitItem : UserControl
    {
        public recepitItem()
        {
            InitializeComponent();
        }

        public string naziv
        {
            get { return textBox_naziv.Text; }
            set { textBox_naziv.Text= value; }
        }

        public string kolicina 
        {
            get { return textBox_kolicina.Text; }
            set { textBox_kolicina.Text= value; }
        }

        public string cijena
        {
            get { return textBox_cijena.Text; }
            set { textBox_cijena.Text = value; }
        }

        public string ukupno 
        {
            get { return textBox_ukupno.Text; }
            set { textBox_ukupno.Text = value; }
        }

    }
}
