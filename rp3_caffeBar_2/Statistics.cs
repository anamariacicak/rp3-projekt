using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace rp3_caffeBar
{
    public partial class Statistics : Form
    {
        public Statistics()
        {
            InitializeComponent();         

            SuspendLayout();

            //prvi dijagram
            DataSet1TableAdapters.PRODUCT1TableAdapter adapter = new DataSet1TableAdapters.PRODUCT1TableAdapter();
            DataTable tablica = adapter.GetData();

            chart1.DataSource = tablica;
            chart1.Series["Series1"].XValueMember = "PRODUCT_NAME"; // naziv stupca za X os
            chart1.Series["Series1"].YValueMembers = "QUANTITY"; // naziv stupca za Y os
            chart1.Series["Series1"].ChartType = SeriesChartType.RangeBar; // tip grafikona
            chart1.ChartAreas[0].AxisX.Title = "proizvodi";
            chart1.ChartAreas[0].AxisY.Title = "broj prodanih";
            chart1.Titles.Add("Top 5 prodanih");
            chart1.Legends.Clear();
            chart1.DataBind();

            //drugi dijagram
            DataSet1TableAdapters.PRODUCTTableAdapter adapter2 = new DataSet1TableAdapters.PRODUCTTableAdapter();
            DataTable tablica2 = adapter2.GetData();

            chart2.DataSource = tablica2;
            chart2.Series["Series1"].XValueMember = "PRODUCT_NAME"; // naziv stupca za X os
            chart2.Series["Series1"].YValueMembers = "ITEM_QUANTITY"; // naziv stupca za Y os
            chart2.Series["Series1"].ChartType = SeriesChartType.Line; // tip grafikona
            chart2.ChartAreas[0].AxisX.Title = "proizvodi";
            chart2.ChartAreas[0].AxisY.Title = "broj prodanih";
            chart2.Titles.Add("Analiza");
            chart2.Legends.Clear();
            chart2.DataBind();


            ResumeLayout();

        }

        //toolstrip buttoni
        private void button_blagajna_Click(object sender, EventArgs e)
        {
            this.Hide();
            var blagajna = new MainScreen();
            blagajna.Show();
        }

        private void button_skladiste_Click(object sender, EventArgs e)
        {
            this.Hide();
            var skladiste = new Storage();
            skladiste.Show();
        }

        private void button_administracija_Click(object sender, EventArgs e)
        {
            this.Hide();
            var admin = new Administration();
            admin.Show();
        }

        private void button_statistika_Click(object sender, EventArgs e)
        {
            //ekran statistika
            this.Hide();
            var stat = new Statistics();
            stat.Show();
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            this.Close();
            var login = new Login();
            login.Show();
        }
    }
}
