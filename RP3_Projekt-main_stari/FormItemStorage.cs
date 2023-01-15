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
using System.Text.RegularExpressions;
using System.Data.SqlClient;


namespace CaffeBar
{
    /// <summary>
    /// Display item from storage form.
    /// </summary>
    public partial class FormItemStorage : Form
    {
        public FormItemStorage()
        {
            InitializeComponent();
        }

        private void butttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            if (!validateForms())
                return;


            if (textBoxId.Text == "")   //  dodajem novi zapis
            {
                SqlConnection connection = DB.getConnection();
                SqlCommand sqlcommand = new SqlCommand("INSERT INTO dbo.Storage([Item], [Price], [Cooler],[Backstorage]) VALUES(@item, @price, @cooler,@backstorage)", connection);

                sqlcommand.Parameters.AddWithValue("@item", textBoxItem.Text);
                sqlcommand.Parameters.AddWithValue("@price", textBoxPrice.Text);
                sqlcommand.Parameters.AddWithValue("@cooler", textBoxCooler.Text);
                sqlcommand.Parameters.AddWithValue("@backstorage", textBoxBackstorage.Text);
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
            }
            else // mjenjam stari zapis
            {
                SqlConnection connection = DB.getConnection();
                SqlCommand sqlcommand = new SqlCommand("UPDATE dbo.Storage SET [Item]=@item, [Price]=@price, [Cooler]=@cooler ,[Backstorage]=@backstorage WHERE Id = @id", connection);
                sqlcommand.Parameters.AddWithValue("@id", textBoxId.Text);
                sqlcommand.Parameters.AddWithValue("@item", textBoxItem.Text);
                sqlcommand.Parameters.AddWithValue("@price", textBoxPrice.Text);
                sqlcommand.Parameters.AddWithValue("@cooler", textBoxCooler.Text);
                sqlcommand.Parameters.AddWithValue("@backstorage", textBoxBackstorage.Text);
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
            }

            this.Close();
        }

        #region Input validation
        private bool failedValidation(in string message)
        {
            MessageBox.Show("ERROR: Input " + message + " invalid!");
            return false;
        }
        private bool validateForms()
        {
            textBoxPrice.Text = textBoxPrice.Text.Replace(",", ".");
            if (!Regex.Match(textBoxPrice.Text, @"^([1-9]{1}[0-9]{0,7})(\.)([0-9]{1,2})$", RegexOptions.IgnoreCase).Success)
                return failedValidation("price");
            if (!Regex.Match(textBoxBackstorage.Text, @"^([0-9]+)$", RegexOptions.IgnoreCase).Success)
                return failedValidation("backstorage");
            if (!Regex.Match(textBoxCooler.Text, @"^([0-9]+)$", RegexOptions.IgnoreCase).Success)
                return failedValidation("cooler");
            else
                return true;
        }
        #endregion





    }
}
