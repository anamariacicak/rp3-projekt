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
using Microsoft.Reporting.WinForms;
using System.Data.SqlClient;

namespace CaffeBar
{
    /// <summary>
    /// Print receipt form.
    /// </summary>
    public partial class FormReceiptPrint : Form
    {
        String _total, _paymentMethod, _receiptId, _date, _discount;

        private void FormReceiptPrint_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (toggle == "report")
                Application.Restart();
        }

        DataTable items;
        string toggle;
        public FormReceiptPrint(string _toggle, DataTable dataTableReceipt = null, Double total = 0.0, String paymentMethod = "", Int32 receiptId = 0, String discount = "")
        {
            InitializeComponent();
            toggle = _toggle;
            if (toggle == "receipt")
            {
                _total = total.ToString();
                _paymentMethod = paymentMethod.ToString();
                _receiptId = receiptId.ToString();
                _discount = discount;
                items = new DataTable();
                items = dataTableReceipt.Copy();
            }
        }

        private void FormReceiptPrint_Load(object sender, EventArgs e)
        {
            SuspendLayout();
            if (toggle == "receipt")
            {
                items.Columns["Price per unit"].ColumnName = "Price_per_unit";
                items.Columns.Add("Total", typeof(System.Double));
                Double amount, price;
                foreach (DataRow row in items.Rows)
                {
                    Double.TryParse(row["Amount"].ToString(), out amount); Double.TryParse(row["Price_per_unit"].ToString(), out price);
                    row["Total"] = amount * price;
                }

                
                String errorMsg, waiter="";
                List<String> l = Service.getReceiptDetails((Int32.Parse(_receiptId)), out errorMsg);
                int _waiterid = int.Parse(l[6]);
                _date = l[1];

                List<Tuple<String, String>> list2 = Service.getAllEmployeData(out errorMsg);
                foreach (var item in list2)
                    if (_waiterid == int.Parse(item.Item1))
                    {
                        waiter = item.Item2;
                    }

                if (errorMsg != "")
                { MessageBox.Show(errorMsg); ResumeLayout(); return; }

                ReportDataSource rds = new ReportDataSource("DataSet2", items);
                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(rds);

                ReportParameter[] para = new ReportParameter[]
                {
                new ReportParameter("parameterTotal",_total),
                new ReportParameter("parameterDate", _date),
                new ReportParameter("parameterDiscount", _discount),
                new ReportParameter("parameterId", _receiptId),
                new ReportParameter("parameterPaymentMethod", _paymentMethod),
                new ReportParameter("paremeterIzdao", waiter),
                };
                this.reportViewer1.LocalReport.SetParameters(para);
                this.reportViewer1.RefreshReport();
            }
            else if (toggle == "report")
            {
                reportViewer1.LocalReport.ReportEmbeddedResource = "CaffeBar.RegisterClose.rdlc";
                //Select ST.Item,sum(RI.Amount) as amount, sum(R.Total) as total  from [Receipts_item] RI, [Receipts] R, [Storage] ST where RI.Id_receiptFK = R.Id AND Time >= cast( floor( cast( getdate() as float)) as datetime)and R.Deleted = 0 AND ST.Id = RI.Id_itemFK group by ST.Item
                DataSet dataset = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter("Select ST.Item,sum(RI.Amount) as Amount, sum(R.Total) as Total  from [Receipts_item] RI, [Receipts] R, [Storage] ST where RI.Id_receiptFK = R.Id AND Time >= cast( floor( cast( getdate() as float)) as datetime)and R.Deleted = 0 AND ST.Id = RI.Id_itemFK group by ST.Item", DB.connection_string);

                adapter.Fill(dataset);
                ReportDataSource rds = new ReportDataSource("DataSet1", dataset.Tables[0]);
                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(rds);


                ReportParameter[] para = new ReportParameter[]
                {
                new ReportParameter("parameterTotal",dataset.Tables[0].Compute("Sum(Total)", string.Empty).ToString()),
                new ReportParameter("parameterDate", DateTime.Now.ToString()),
                new ReportParameter("paremeterIzdao", User.name)
                };
                this.reportViewer1.LocalReport.SetParameters(para);
                this.reportViewer1.RefreshReport();
            }

            ResumeLayout();
        }
    }
}
