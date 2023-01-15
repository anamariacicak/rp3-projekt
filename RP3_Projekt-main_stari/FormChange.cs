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
    public partial class FormChange : Form
    {
        double _total;
        public FormChange(in Double total)
        {
            InitializeComponent();
            _total = total;
        }
        private void FormChange_Load(object sender, EventArgs e)
        {
            textBoxPrice.Text = _total.ToString();
        }


        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            if (!validateForms())
                return;

            if (textBoxPayed.Text != "")
                textBoxChange.Text = (Convert.ToDouble(textBoxPayed.Text) - Convert.ToDouble(textBoxPrice.Text)).ToString();
            //this.Close();
        }

        #region Input validation
        private bool failedValidation(in string message)
        {
            MessageBox.Show("ERROR: Input " + message + " invalid!");
            return false;
        }
        private bool validateForms()
        {
            textBoxPayed.Text = textBoxPayed.Text.Replace(".", ",");

            if (/*!Regex.Match(textBoxPayed.Text, @"^([0-9]+)$", RegexOptions.IgnoreCase).Success &&*/
                textBoxPayed.Text == "" ||
                !double.TryParse(textBoxPayed.Text, out _)
                )
                return failedValidation("Payed");

            else if (_total > double.Parse(textBoxPayed.Text))
                return failedValidation("Payed (insuficient)");
            else
                return true;
        }
        #endregion

        private void buttonCancle_Click_1(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
