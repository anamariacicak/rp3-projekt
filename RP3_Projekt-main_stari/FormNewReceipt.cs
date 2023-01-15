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
{        /// <summary>
         /// New receipt form.
         /// </summary>

    public partial class FormNewReceipt : Form
    {
        protected DataTable dataTableReceipt;
        protected double totaldiscount;
        protected int lineditprevamount;
        public FormNewReceipt()
        {
            InitializeComponent();
            dataTableReceipt = new DataTable();
            label2.Hide();
            textBoxDiscount.Hide();
        }
        #region Initialisation
        private void FormNewReceipt_Load(object sender, EventArgs e)
        {
            SuspendLayout();


            //  Initilise bill 
            dataTableReceipt.Columns.Add("Id", Type.GetType("System.Int32"));
            dataTableReceipt.Columns.Add("Item", Type.GetType("System.String"));
            dataTableReceipt.Columns.Add("Amount", Type.GetType("System.Int32"));
            dataTableReceipt.Columns.Add("Price per unit", Type.GetType("System.Decimal"));
            addItemButtons();

            BindingSource bs = new BindingSource();
            bs.DataSource = dataTableReceipt;

            dataGridView1.DataSource = bs;
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].ReadOnly = false;
            dataGridView1.Columns[3].ReadOnly = true;
            comboBoxPaymentMethod.SelectedIndex = 0;
            comboBoxCustomer.SelectedIndex = 0;

            // add waiter to combobox
            String errorMessage;
            var list = Service.getAllEmployeData(out errorMessage);
            if (errorMessage != "")
            {
                MessageBox.Show("ERROR:Database error! " + errorMessage);
                ResumeLayout();
                return;
            }
            else
                foreach (var item in list)
                    comboBoxCustomer.Items.Add(item.Item2);

            ResumeLayout();
            //resetCheck4Notiffications();
        }
        private void addItemButtons()
        {
            String errorMessage;
            var list = Service.getMenuItems(out errorMessage);

            if (errorMessage != "")
                MessageBox.Show(errorMessage);
            else
            {
                SuspendLayout();
                foreach (var item in list)
                {
                    AddItemButton btn = new AddItemButton();
                    btn.Name = item.Item1.ToString();
                    btn.Id = item.Item1;
                    btn.Text = item.Item2;
                    btn.Item = item.Item2;
                    btn.Click += new EventHandler(buttonAddItemToReceipt_Click);
                    btn.AutoSize = true;
                    flowLayoutPanelItems.Controls.Add(btn);
                }
                ResumeLayout();
            }
        }

        private void resetCheck4Notiffications()
        {
            dataTableReceipt.Rows.Clear();
            totaldiscount = 0.0;

            // chek for low items
            DataSet ds = Service.getItemCount();
            if (ds.Tables[0].Rows.Count > 0 && User.showNotification)
            {
                FormLowOnItems formItemcount = new FormLowOnItems(ds);
                formItemcount.ShowDialog();
            }
        }
        #endregion

        private void buttonCloseForm_Click(object sender, EventArgs e)
        {
            dataTableReceipt.Clear();
            this.Close();
        }

        #region Add item to receipt
        // Add item to receipt - button react function
        private void buttonAddItemToReceipt_Click(object sender, EventArgs e)
        {
            var toadd = ((AddItemButton)sender);
            DataRow[] findItem = dataTableReceipt.Select("Id = '" + toadd.Id + "'");/// treba odvojit količinu i cijenu i gledat u ovisnosti o tenutnoj na računu, u varijablu stavit trenutnu kol. na računu i onda na tu dodat jedan, tako se pokriju svi sl. te na kraju dodat cijenu u ovisnosti ako su na happy houru
            var currentAmmount = 0;
            if (findItem.Length != 0)   // curent amount on receipt 
                currentAmmount = (int)findItem[0]["Amount"];


            // CHECK IF THERE IS ENOUGH IN COOLER
            String errorMessage;
            var tuple = Service.getPriceCooler(toadd.Id, out errorMessage);
            var price = tuple.Item2;

            if (errorMessage != "")
            {
                MessageBox.Show(errorMessage);
                return;
            }
            if (tuple.Item1 < currentAmmount + 1)
            {
                MessageBox.Show("Insufficient amount of " + toadd.Text + "in cooler. Can not add item to receipt!");
                return;
            }


            // CHECK IF ITEM IS ON HAPPY HOUR
            decimal newPrice;
            Service.onHappyHour(toadd.Id, out newPrice, out errorMessage);
            if (errorMessage != "")
            {
                MessageBox.Show(errorMessage);
                return;
            }
            if (newPrice.ToString() != "-1")
                price = newPrice;

            if (findItem.Length != 0)// slučaj kada artikl nije vec na racunu
                findItem[0]["Amount"] = currentAmmount + 1;
            else// slučaj kada je artikl vec na racunu
            {
                DataRow newRow = dataTableReceipt.NewRow();

                newRow["Id"] = toadd.Id;
                newRow["Item"] = toadd.Item;
                newRow["Price per unit"] = price;
                newRow["Amount"] = currentAmmount + 1;

                if (errorMessage == "")
                    dataTableReceipt.Rows.Add(newRow);
                else
                    MessageBox.Show(errorMessage);
            }
            return;
        }
        #endregion

        #region Edit quantity of items on receipt
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (lineditprevamount < (int)dataGridView1[e.ColumnIndex, e.RowIndex].Value)
            {

                AddItemButton btn = new AddItemButton();
                btn.Name = dataGridView1[1, e.RowIndex].Value.ToString();
                btn.Id = (int)dataGridView1[0, e.RowIndex].Value;
                btn.Text = dataGridView1[1, e.RowIndex].Value.ToString();
                btn.Item = dataGridView1[1, e.RowIndex].Value.ToString();
                int new_val = (int)dataGridView1[e.ColumnIndex, e.RowIndex].Value, fail_flag;
                dataGridView1[e.ColumnIndex, e.RowIndex].Value = fail_flag = lineditprevamount;

                for (int i = lineditprevamount; i < new_val; i++)
                {
                    buttonAddItemToReceipt_Click(btn, EventArgs.Empty);
                    if ((int)dataGridView1[e.ColumnIndex, e.RowIndex].Value == fail_flag)
                        break;
                    else
                        fail_flag = (int)dataGridView1[e.ColumnIndex, e.RowIndex].Value;
                }
            }
            else if((int)dataGridView1[e.ColumnIndex, e.RowIndex].Value <= 0)
                dataGridView1[e.ColumnIndex, e.RowIndex].Value = lineditprevamount;


        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            lineditprevamount = (int)dataGridView1[e.ColumnIndex, e.RowIndex].Value;
        }
        #endregion

        #region Print receipt
        private void buttonPrint_Click(object sender, EventArgs e)
        {
            SuspendLayout();
            if (dataTableReceipt.Rows.Count == 0)
            {
                MessageBox.Show("No items added!");
                ResumeLayout();
                return;
            }

            //insert into database
            Double total;
            String errorMessage;
            Int32 receiptId;
            ///////////////////////////////////////////////////////////////////////////za zaposlenike
            if (comboBoxCustomer.SelectedIndex > 0)
                addDiscount(comboBoxCustomer.SelectedItem.ToString());


            errorMessage = Service.newReceipt(dataTableReceipt, comboBoxPaymentMethod.SelectedItem.ToString(), out total, out receiptId, totaldiscount);

            if (errorMessage != "")
            {
                MessageBox.Show(errorMessage);
                ResumeLayout();
                return;
            }
            // print
            FormReceiptPrint formPrint = new FormReceiptPrint("receipt", dataTableReceipt, total, comboBoxPaymentMethod.SelectedItem.ToString(), receiptId, totaldiscount.ToString());
            formPrint.ShowDialog();

            //check if payed cash - print combo 
            if (comboBoxPaymentMethod.SelectedItem.ToString() == "Gotovina")
            {
                FormChange formChange = new FormChange(in total);
                ResumeLayout();
                formChange.ShowDialog();
            }
            ResumeLayout();
            resetCheck4Notiffications();
        }
        #endregion

        #region Delete item from receipt
        private void buttonDeleteItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataRow[] findItem = dataTableReceipt.Select("Id = '" + dataGridView1.CurrentRow.Cells[0].Value + "'");
                findItem[0].Delete();
            }
            else
                MessageBox.Show("Please select a row!");
        }

        #endregion

        #region New button with properties |id,item |
        class AddItemButton : Button
        {
            public AddItemButton()
            {
                this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
                this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
                this.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
                this.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
                this.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(57)))), ((int)(((byte)(63)))));
                this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                this.ForeColor = System.Drawing.Color.Silver;
                this.Size = new System.Drawing.Size(100, 30);
                this.Size = new System.Drawing.Size(100, 30);
                this.UseVisualStyleBackColor = false;
            }
            public int Id { get; set; }
            public String Item { get; set; }
        }
        #endregion

        #region Free stuff for staff
        private void addDiscount(string employe)
        {
            // get today discount count on juice and coffee for employee ->name 
            string errorMessage;
            Tuple<int, int> discount = Service.getDiscount(comboBoxCustomer.SelectedItem.ToString(), out errorMessage);
            if (errorMessage != "")
            { MessageBox.Show(errorMessage); return; }


            //for
            // if caffe: has free caffe if not get him 20% disc
            // if juice: has free juice if not get him 20% disc
            int freeAmount = 0;
            DataTable tmp = new DataTable();
            tmp = dataTableReceipt.Clone();
            foreach (DataRow row in dataTableReceipt.Rows)
            {
                if (row["item"].ToString().IndexOf("kava", StringComparison.CurrentCultureIgnoreCase) != -1)    // there's some coffee 
                {
                    if (discount.Item1 > 0)
                    {
                        freeAmount = ((int)row["Amount"]) == 1 ? 1 : discount.Item1;
                        Service.useDiscount(employe, out errorMessage, "Caffe", freeAmount);
                        if (errorMessage != "")
                        { MessageBox.Show(errorMessage); return; }
                        if ((int)row["Amount"] > freeAmount)// dodaj ostatak na kraj
                        {
                            row["Amount"] = (int)row["Amount"] - freeAmount;
                            tmp.ImportRow(row);
                            row["Amount"] = freeAmount;
                            row["Price per unit"] = decimal.Parse("0");
                        }
                        else
                        {
                            row["Price per unit"] = 0.0;
                        }

                    }
                }
                else if (row["item"].ToString().IndexOf("cijeđeni sok", StringComparison.CurrentCultureIgnoreCase) != -1)    // there's some juice 
                {
                    if (discount.Item2 > 0)
                    {
                        Service.useDiscount(employe, out errorMessage, "Juice", 1);
                        if (errorMessage != "")
                        { MessageBox.Show(errorMessage); return; }
                        if ((int)row["Amount"] > 1)// dodaj ostatak na kraj
                        {
                            row["Amount"] = (int)row["Amount"] - 1;
                            tmp.ImportRow(row);
                            row["Amount"] = 1;
                            row["Price per unit"] = decimal.Parse("0");
                        }
                        else
                        {
                            row["Price per unit"] = 0.0;

                        }

                    }
                }
            }

            if (tmp.Rows.Count > 0)
                dataTableReceipt.Merge(tmp);


            // add 20% off everything
            totaldiscount = 20;
        }


        #endregion

        private void buttonCloseRegister_Click(object sender, EventArgs e)
        {
            FormReceiptPrint formPrint = new FormReceiptPrint("report");
            formPrint.ShowDialog();
        }
    }
}
