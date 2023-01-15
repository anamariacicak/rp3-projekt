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
    /// The entry point for the application - login.
    /// </summary>
    public partial class FormLogIn : Form
    {
        public FormLogIn()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {

            SqlConnection connection = DB.getConnection();
            SqlCommand command = new SqlCommand("SELECT Id, Password, Authorisation FROM [User] WHERE Username=@username;", connection);
            command.Parameters.Add("@username", SqlDbType.NChar);
            command.Parameters["@username"].Value = textBoxUsername.Text.ToString();

            SqlDataReader dataReader;
            String pass = "";

            try
            {
                dataReader = command.ExecuteReader();
                if (!dataReader.HasRows)
                {
                    MessageBox.Show("Invalid credentials!");
                    DB.closeConnection();

                    return;
                }
                dataReader.Read();
                User.id = dataReader.GetInt32(0);
                pass = (String)dataReader.GetValue(1);
                User.authorisation = dataReader.GetString(2);
                User.name = textBoxUsername.Text.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: Database connection unsuccessful!" + ex.ToString());
            }
            finally
            {
                DB.closeConnection();
            }


            if (pass == Hash(textBoxPassword.Text.ToString()))//if (pass == textBoxPassword.Text.ToString())
            {
                this.Hide();
                FormApp formApp = new FormApp();
                formApp.ShowDialog();
            }
            else
                MessageBox.Show("Invalid credentials!");
        }

        private void FormLogIn_Load(object sender, EventArgs e)
        {
            //za hash sptemit u bazu
            //textBoxUsername.Text = Hash("konobar");
        }

        private string Hash(string password)
        {
            var bytes = new UTF8Encoding().GetBytes(password);
            byte[] hashBytes;
            using (var algorithm = new System.Security.Cryptography.SHA512Managed())
            {
                hashBytes = algorithm.ComputeHash(bytes);
            }
            return Convert.ToBase64String(hashBytes);
        }
    }
}

