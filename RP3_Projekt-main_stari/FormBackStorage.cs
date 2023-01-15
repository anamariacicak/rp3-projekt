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
    public partial class FormBackStorage : Form
    {
        private int previousAmount;
        public FormBackStorage()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormBackStorage_Load(object sender, EventArgs e)
        {
            if (User.authorisation.Contains("Konobar"))
            {
                this.buttonAddItem.Dispose();
                this.buttonEditItem.Dispose();
                this.buttonDeleteItem.Dispose();
            }
            UpdateStorageView();
        }

        private void UpdateStorageView(String filter = "")
        {
            SuspendLayout();
            SqlConnection connection = DB.getConnection();
            DataSet dataset = new DataSet();

            using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM dbo.Storage WHERE Deleted = 0", connection))
            {
                adapter.Fill(dataset);//, "Storage");
            }

            var dv = dataset.Tables[0].DefaultView;
            dv.RowFilter = filter;
            dataGridView1.DataSource = dv;

            // postavljamo da se editati može samo cooler i backstorage
            dataGridView1.ReadOnly = false;
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].ReadOnly = true;
            dataGridView1.Columns["Deleted"].Visible = false;

            DB.closeConnection();
            ResumeLayout();
        }

        #region Add, Edit, Delete, Filter item
        private void buttonNewItem_Click(object sender, EventArgs e)
        {
            FormItemStorage formItem = new FormItemStorage();
            formItem.ShowDialog();
            UpdateStorageView();
        }

        private void buttonEditItem_Click(object sender, EventArgs e)
        {

            FormItemStorage form = new FormItemStorage();

            if (dataGridView1.SelectedRows.Count == 1)
            {
                form.textBoxId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                form.textBoxItem.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                form.textBoxPrice.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString().Replace(",", ".");
                form.textBoxCooler.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                form.textBoxBackstorage.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                form.ShowDialog();
                UpdateStorageView();
            }
            else
                MessageBox.Show("Please select one row!");
        }

        private void buttonDeleteItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                SqlConnection connection = DB.getConnection();
                SqlCommand sqlcommand = new SqlCommand("update dbo.Storage set Deleted = 1 where Id =@id", connection);

                sqlcommand.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells[0].Value.ToString());

                try
                {
                    sqlcommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR:" + ex.Message);
                }
                finally
                {
                    DB.closeConnection();
                }
                UpdateStorageView();
            }
            else
                MessageBox.Show("Please select a row!");
        }

        private void textBoxFilter_TextChanged(object sender, EventArgs e)
        {
            if (textBoxFilter.Text != "")
                UpdateStorageView("Item LIKE '*" + textBoxFilter.Text + "*'");
            else
                UpdateStorageView();
        }
        #endregion

        #region Line edit implementation
        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            previousAmount = (int)dataGridView1[e.ColumnIndex, e.RowIndex].Value;
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            String errorMsg;
            if ((int)dataGridView1[e.ColumnIndex, e.RowIndex].Value < previousAmount)// provjera za oba slučaja da nije broj manji
            {
                dataGridView1[e.ColumnIndex, e.RowIndex].Value = previousAmount;
                MessageBox.Show(@"# of items lover than before!");
            }
            if (dataGridView1.Columns[e.ColumnIndex].HeaderText == "Cooler")
            {
                if ((int)dataGridView1[e.ColumnIndex + 1, e.RowIndex].Value < (int)dataGridView1[e.ColumnIndex, e.RowIndex].Value - previousAmount)
                {
                    dataGridView1[e.ColumnIndex, e.RowIndex].Value = previousAmount;
                    MessageBox.Show(@"Not enough items!");
                }
                else
                {
                    Service.addAmount(int.Parse(dataGridView1[0, e.RowIndex].Value.ToString()), (int)dataGridView1[e.ColumnIndex, e.RowIndex].Value - previousAmount, "Cooler", out errorMsg);
                    if (errorMsg != "")
                    { MessageBox.Show(errorMsg); return; }
                    dataGridView1[e.ColumnIndex + 1, e.RowIndex].Value = (int)dataGridView1[e.ColumnIndex + 1, e.RowIndex].Value - ((int)dataGridView1[e.ColumnIndex, e.RowIndex].Value - previousAmount);
                }
            }
            else //if(dataGridView1.Columns[e.ColumnIndex].HeaderText == "Backstorage")
            {
                Service.addAmount(int.Parse(dataGridView1[0, e.RowIndex].Value.ToString()), (int)dataGridView1[e.ColumnIndex, e.RowIndex].Value - previousAmount, "Backstorage", out errorMsg);
                if (errorMsg != "")
                    MessageBox.Show(errorMsg);
            }
        }

        #endregion

        private void buttonShowNotification_Click(object sender, EventArgs e)
        {
            User.showNotification = true;
        }
    }
}
