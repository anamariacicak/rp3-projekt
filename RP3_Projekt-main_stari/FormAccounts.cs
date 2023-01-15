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
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaffeBar
{
    /// <summary>
    /// Sorage display form.
    /// </summary>
    public partial class FormAccounts : Form
    {
        DataTable table;

        SqlDataAdapter adapter;

        public FormAccounts()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormAccounts_Load(object sender, EventArgs e)
        {
            SuspendLayout();

            //dataGridView1.AllowUserToAddRows = true;
            dataGridView1.AllowUserToDeleteRows = true;
            adapter =
                new SqlDataAdapter("SELECT * FROM [User] WHERE Deleted = 0",
                    DB.connection_string);

            //////SqlCommandBuilder()
            ////SqlCommand command = new SqlCommand("INSERT INTO [User] (Username,Password) VALUES (@Username,@Password)", DB.getConnection());
            ////command.Parameters.Add("@Username", SqlDbType.NChar, 20, "Username");
            ////command.Parameters.Add("@Password", SqlDbType.NVarChar, 20, "Password");
            //////command.Parameters.Add("@Authorisation", SqlDbType.NChar, 10, "Authorisation");
            ////adapter.InsertCommand = command;
            ////command = new SqlCommand("UPDATE [User] SET Deleted = 1 WHERE Id=@Id)");
            ////command.Parameters.Add("@Id", SqlDbType.Int, sizeof(int), "Id");
            ////adapter.DeleteCommand = command;
            table = new DataTable();
            adapter.Fill(table);

            this.dataGridView1.DataSource = table;

            //LoadData();
            ResumeLayout();
        }

        private void LoadData()
        {
            SqlConnection connection = DB.getConnection();
            DataSet dataset = new DataSet();

            using (
                SqlDataAdapter adapter =
                    new SqlDataAdapter("SELECT * FROM [User] WHERE Deleted = 0",
                        connection)
            )
            {
                adapter.Fill(dataset); //, "Storage");
            }

            var dv = dataset.Tables[0].DefaultView;

            //dv.RowFilter = filter;
            dataGridView1.DataSource = dv;

            // postavljamo da se editati može samo cooler i backstorage
            //dataGridView1.ReadOnly = true;
            //dataGridView1.Columns[0].ReadOnly = true;
            //dataGridView1.Columns[1].ReadOnly = true;
            //dataGridView1.Columns[2].ReadOnly = true;
            //dataGridView1.Columns["Deleted"].Visible = false;
            dataGridView1.AllowUserToAddRows = true;

            DB.closeConnection();
        }

        private void nodeletedToolStripButton_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    this.userTableAdapter.Nodeleted(this.caffeBarDatabaseDataSet.User);
            //}
            //catch (System.Exception ex)
            //{
            //    System.Windows.Forms.MessageBox.Show(ex.Message);
            //}
        }

        private void dataGridView1_UserDeletingRow(
            object sender,
            DataGridViewRowCancelEventArgs e
        )
        {
            e.Cancel = true;
            SqlConnection connection = DB.getConnection();
            SqlCommand command3 =
                new SqlCommand("UPDATE [User] SET Deleted = 1 WHERE Id=@id",
                    connection);
            command3.Parameters.AddWithValue("@id", (int)e.Row.Cells[0].Value);

            try
            {
                command3.ExecuteNonQuery();
                e.Row.Dispose();
                DataSet dataset = new DataSet();
                adapter.Fill(dataset);
                dataGridView1.DataSource = dataset.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: Database error! " + ex.Message);
            }
            finally
            {
                DB.closeConnection();
            }
            //LoadData();
            //adapter.Update(table);
        }

        private void FormAccounts_FormClosed(
            object sender,
            FormClosedEventArgs e
        )
        {
            adapter.Dispose();
        }

        private void dataGridView1_UserAddedRow(
            object sender,
            DataGridViewRowEventArgs e
        )
        {
        }

        private void dataGridView1_RowEnter(
            object sender,
            DataGridViewCellEventArgs e
        )
        {
            //if (dataGridView1.NewRowIndex == e.RowIndex && (e.ColumnIndex == 1 || e.ColumnIndex == 2))
            //    dataGridView1[e.ColumnIndex, e.RowIndex].ReadOnly = false;
            //else
            //    dataGridView1[e.ColumnIndex, e.RowIndex].ReadOnly = true;
        }

        private void dataGridView1_CellEndEdit(
            object sender,
            DataGridViewCellEventArgs e
        )
        {
            // check if username and pass are entered
            ////if(dataGridView1[1,e.RowIndex].Value.ToString() != "" && dataGridView1[2, e.RowIndex].Value.ToString() !="" && dataGridView1[3, e.RowIndex].Value.ToString() != "")
            ////{
            ////    // validate ..
            ////    try
            ////    {
            ////        MessageBox.Show(dataGridView1[1, e.RowIndex].Value.ToString() + "|" + dataGridView1[2, e.RowIndex].Value.ToString() + "|" + dataGridView1[3, e.RowIndex].Value.ToString());
            ////        MessageBox.Show(adapter.Update(table).ToString());
            ////    }
            ////    catch (Exception ex)
            ////    {
            ////        MessageBox.Show(ex.Message);
            ////    }
            ////}
        }

        private void buttonAddUser_Click(object sender, EventArgs e)
        {
            FormAddUser form = new FormAddUser();
            form.ShowDialog();
            DataSet dataset = new DataSet();
            adapter.Fill(dataset);
            dataGridView1.DataSource = dataset.Tables[0].DefaultView;
        }
    }
}
