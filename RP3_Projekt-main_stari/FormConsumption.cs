/***************************************************************************************
 *      Copyright (C) 2021 Fran Vojković, Martina Gaćina, Matea Čotić, Mirna Keser     *
 *                                                                                     *
 *              This file is part of the RP3_Projekt project.                          *
 *                                                                                     *
 ***************************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CaffeBar
{
    /// <summary>
    /// Sorage display form.
    /// </summary>
    public partial class FormConsumption : Form
    {
        private DataSet dataset;
        SqlDataAdapter adapter;

        public FormConsumption()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormConsumption_Load(object sender, EventArgs e)
        {
            SuspendLayout();

            dataset = new DataSet();
            adapter = new SqlDataAdapter("", DB.connection_string);

            dateTimePickerFrom.Format = DateTimePickerFormat.Custom;
            dateTimePickerFrom.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            dateTimePickerTo.Format = DateTimePickerFormat.Custom;
            dateTimePickerTo.CustomFormat = "dd/MM/yyyy HH:mm:ss";

            UpdateConsumptionView(dateTimePickerFrom.Value, dateTimePickerTo.Value);

            ResumeLayout();

        }

        private void UpdateConsumptionView(DateTime from, DateTime to, String filter = "")
        {
            SqlCommand command = new SqlCommand("SELECT ST.Item,sum(RI.Amount) AS Amount,sum(R.Total) AS Total,  AVG(R.Discount) AS AvgDiscount FROM [Receipts_item] RI, [Receipts] R, [Storage] ST WHERE RI.Id_receiptFK = R.Id AND @from<Time AND Time< @to AND R.Deleted = 0 AND ST.Id = RI.Id_itemFK GROUP BY ST.Item");
            command.Parameters.AddWithValue("@from", from);
            command.Parameters.AddWithValue("@to", to);

            command.Connection = new SqlConnection(DB.connection_string);
            adapter.SelectCommand = command;

            dataset.Clear();
            adapter.Fill(dataset);

            var dv = dataset.Tables[0].DefaultView;
            var dv2 = dataset.Tables[0].DefaultView;
            dv.RowFilter = filter;
            dataGridView1.DataSource = dv;
            dataGridView1.ReadOnly = true;



            //chart1.Series["Series1"].XValueMember = "Item";
            //chart1.Series["Series1"].YValueMembers = "Amount";
            //chart1.DataBindTable(dataset.Tables[0].DefaultView, "Item");
            //chart1.Series.Add("Series");
            //foreach (DataRowCollection item in dataset.Tables[0].Rows)
            //{
            //    chart1.Series["Series"].Points.AddXY(item[0], item[1]);
            //}
            chart1.Series.Clear();
            chart1.Series.Add("Amount");
            chart1.Series["Amount"].XValueMember = "Item";
            chart1.Series["Amount"].YValueMembers = "Amount";
            chart1.DataSource = dataset.Tables[0];
            chart1.DataBind();

        }

        private void dateTimePickerFrom_ValueChanged(object sender, EventArgs e)
        {
            UpdateConsumptionView(dateTimePickerFrom.Value, dateTimePickerTo.Value);
        }

        private void FormConsumption_FormClosed(object sender, FormClosedEventArgs e)
        {
            adapter.Dispose();
        }
    }
}
