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
    /// Display add user form.
    /// </summary>
    public partial class FormAddUser : Form
    {
        public FormAddUser()
        {
            InitializeComponent();
        }
        private void FormAddUser_Load(object sender, EventArgs e)
        { }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("e");
            // validate 
            bool flag = true;
            SqlConnection connection = DB.getConnection();
            SqlCommand command = new SqlCommand("INSERT INTO [User](Username, Password)  VALUES(@Username, @Password)", connection);

            command.Parameters.AddWithValue("@Username", textBoxUsername.Text.ToString());
            command.Parameters.AddWithValue("@Password", Hash(textBoxPassword.Text.ToString()));

            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: Database error! " + ex.Message);
                flag = false;
            }
            finally
            {
                DB.closeConnection();
            }
            if (flag)
            {
                MessageBox.Show("User added!");
                this.Close();
            }
            
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

        #region Input validation


        #endregion



    }
}
