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
    public partial class FromReceipts : Form
    {
        private DataSet dataset;
        SqlDataAdapter adapter;

        public FromReceipts()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FromReceipts_Load(object sender, EventArgs e)
        {
            if (User.authorisation.Contains("Konobar"))
                this.buttonDeleteReceipt.Dispose();

            dataset = new DataSet();
            adapter = new SqlDataAdapter("", DB.connection_string);

            dateTimePickerFrom.Format = DateTimePickerFormat.Custom;
            dateTimePickerFrom.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            dateTimePickerTo.Format = DateTimePickerFormat.Custom;
            dateTimePickerTo.CustomFormat = "dd/MM/yyyy HH:mm:ss";

            UpdateReceiptsView(dateTimePickerFrom.Value, dateTimePickerTo.Value);
        }

        private void UpdateReceiptsView(DateTime from, DateTime to, String filter = "")
        {
            SuspendLayout();

            SqlCommand command = new SqlCommand("SELECT R.Id, R.Time, R.Total, R.Payment_method, R.Discount, U.Username as Waiter FROM  [Receipts] R, [User] U WHERE U.Id = R.Waiter_id AND @from<Time AND Time< @to AND R.Deleted = 0 ");
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
            ResumeLayout();

        }

        private void dateTimePickerFrom_ValueChanged(object sender, EventArgs e)
        {
            UpdateReceiptsView(dateTimePickerFrom.Value, dateTimePickerTo.Value);
        }

        private void FromReceipts_FormClosed(object sender, FormClosedEventArgs e)
        {
            adapter.Dispose();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                DataTable items;
                items = Service.getReceiptItems((int)dataGridView1.CurrentRow.Cells[0].Value).Tables[0];
                items.Columns["Price_per_unit"].ColumnName = "Price per unit";
                FormReceiptPrint formPrint = new FormReceiptPrint("receipt", items, Double.Parse(dataGridView1.CurrentRow.Cells[2].Value.ToString()), dataGridView1.CurrentRow.Cells[3].Value.ToString(), Int32.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()), dataGridView1.CurrentRow.Cells[4].Value.ToString());
                formPrint.ShowDialog();
            }
            else
                MessageBox.Show("Please select one row!");
        }

        private void buttonDeleteReceipt_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string errorMsg = "";
                Service.deleteReceipt(dataGridView1.CurrentRow.Cells[0].Value.ToString(), out errorMsg);
                UpdateReceiptsView(dateTimePickerFrom.Value, dateTimePickerTo.Value);
                if (errorMsg != "")
                    MessageBox.Show(errorMsg);
            }
            else
                MessageBox.Show("Please select a row!");
        }
    }
}
