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
    public partial class prometItem : UserControl
    {
        public prometItem()
        {
            InitializeComponent();
        }
        public string brojRacuna
        {
            get { return textBox_brRacuna.Text; }
            set { textBox_brRacuna.Text = value; }
        }

        public string username
        {
            get { return textBox_username.Text; }
            set { textBox_username.Text = value; }
        }

        public string cijena
        {
            get { return textBox_cijena.Text; }
            set { textBox_cijena.Text = value; }
        }

        public string vrijeme
        {
            get { return textBox_vrijeme.Text; }
            set { textBox_vrijeme.Text = value; }
        }
    }
}
