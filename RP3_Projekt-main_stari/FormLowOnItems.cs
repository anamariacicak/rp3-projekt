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
    /// Display change form, used when payed with cash.
    /// </summary>
    public partial class FormLowOnItems : Form
    {
        DataSet ds;
        public FormLowOnItems(DataSet _ds)
        {
            InitializeComponent();
            ds = _ds;
        }
        private void FormLowOnItems_Load(object sender, EventArgs e)
        {
            SuspendLayout();
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
            ResumeLayout();
        }



        private void buttonCancle_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonTurnoff_Click(object sender, EventArgs e)
        {
            User.showNotification = false;
        }
    }
}
