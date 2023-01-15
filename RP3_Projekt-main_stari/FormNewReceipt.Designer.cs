
namespace CaffeBar
{
    partial class FormNewReceipt
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonPrint = new System.Windows.Forms.Button();
            this.storageBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.caffeBarDatabaseDataSet = new CaffeBar.CaffeBarDatabaseDataSet();
            this.userTableAdapter = new CaffeBar.CaffeBarDatabaseDataSetTableAdapters.UserTableAdapter();
            this.storageTableAdapter = new CaffeBar.CaffeBarDatabaseDataSetTableAdapters.StorageTableAdapter();
            this.storageBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.buttonDeleteItem = new System.Windows.Forms.Button();
            this.buttonCloseRegister = new System.Windows.Forms.Button();
            this.buttonCloseForm = new System.Windows.Forms.Button();
            this.userBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.caffeBarDatabaseDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.flowLayoutPanelItems = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBoxDiscount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxCustomer = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxPaymentMethod = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.storageBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.caffeBarDatabaseDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.storageBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.caffeBarDatabaseDataSetBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(61)))), ((int)(((byte)(69)))));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeight = 30;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.PaleVioletRed;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Size = new System.Drawing.Size(442, 223);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView1_CellBeginEdit);
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            // 
            // buttonPrint
            // 
            this.buttonPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.buttonPrint.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.buttonPrint.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.buttonPrint.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(57)))), ((int)(((byte)(63)))));
            this.buttonPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPrint.ForeColor = System.Drawing.Color.Silver;
            this.buttonPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonPrint.Location = new System.Drawing.Point(34, 160);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(233, 60);
            this.buttonPrint.TabIndex = 3;
            this.buttonPrint.Text = "Print receipt";
            this.buttonPrint.UseVisualStyleBackColor = false;
            this.buttonPrint.Click += new System.EventHandler(this.buttonPrint_Click);
            // 
            // storageBindingSource
            // 
            this.storageBindingSource.DataMember = "Storage";
            this.storageBindingSource.DataSource = this.caffeBarDatabaseDataSet;
            // 
            // caffeBarDatabaseDataSet
            // 
            this.caffeBarDatabaseDataSet.DataSetName = "CaffeBarDatabaseDataSet";
            this.caffeBarDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // userTableAdapter
            // 
            this.userTableAdapter.ClearBeforeFill = true;
            // 
            // storageTableAdapter
            // 
            this.storageTableAdapter.ClearBeforeFill = true;
            // 
            // storageBindingSource1
            // 
            this.storageBindingSource1.DataMember = "Storage";
            this.storageBindingSource1.DataSource = this.caffeBarDatabaseDataSet;
            // 
            // buttonDeleteItem
            // 
            this.buttonDeleteItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDeleteItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.buttonDeleteItem.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.buttonDeleteItem.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.buttonDeleteItem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(57)))), ((int)(((byte)(63)))));
            this.buttonDeleteItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDeleteItem.ForeColor = System.Drawing.Color.Silver;
            this.buttonDeleteItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDeleteItem.Location = new System.Drawing.Point(167, 124);
            this.buttonDeleteItem.Name = "buttonDeleteItem";
            this.buttonDeleteItem.Size = new System.Drawing.Size(100, 30);
            this.buttonDeleteItem.TabIndex = 5;
            this.buttonDeleteItem.Text = "Delete item";
            this.buttonDeleteItem.UseVisualStyleBackColor = false;
            this.buttonDeleteItem.Click += new System.EventHandler(this.buttonDeleteItem_Click);
            // 
            // buttonCloseRegister
            // 
            this.buttonCloseRegister.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCloseRegister.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.buttonCloseRegister.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.buttonCloseRegister.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.buttonCloseRegister.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(57)))), ((int)(((byte)(63)))));
            this.buttonCloseRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCloseRegister.ForeColor = System.Drawing.Color.Silver;
            this.buttonCloseRegister.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCloseRegister.Location = new System.Drawing.Point(34, 124);
            this.buttonCloseRegister.Name = "buttonCloseRegister";
            this.buttonCloseRegister.Size = new System.Drawing.Size(116, 30);
            this.buttonCloseRegister.TabIndex = 6;
            this.buttonCloseRegister.Text = "Close register";
            this.buttonCloseRegister.UseVisualStyleBackColor = false;
            this.buttonCloseRegister.Click += new System.EventHandler(this.buttonCloseRegister_Click);
            // 
            // buttonCloseForm
            // 
            this.buttonCloseForm.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonCloseForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.buttonCloseForm.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.buttonCloseForm.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.buttonCloseForm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(57)))), ((int)(((byte)(63)))));
            this.buttonCloseForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCloseForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCloseForm.ForeColor = System.Drawing.Color.Red;
            this.buttonCloseForm.Image = global::CaffeBar.Properties.Resources.close_removebg_preview;
            this.buttonCloseForm.Location = new System.Drawing.Point(693, 9);
            this.buttonCloseForm.Name = "buttonCloseForm";
            this.buttonCloseForm.Size = new System.Drawing.Size(26, 26);
            this.buttonCloseForm.TabIndex = 7;
            this.buttonCloseForm.UseVisualStyleBackColor = false;
            this.buttonCloseForm.Click += new System.EventHandler(this.buttonCloseForm_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelTitle);
            this.panel1.Controls.Add(this.buttonCloseForm);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(731, 41);
            this.panel1.TabIndex = 8;
            // 
            // labelTitle
            // 
            this.labelTitle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.Location = new System.Drawing.Point(12, 3);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(159, 30);
            this.labelTitle.TabIndex = 8;
            this.labelTitle.Text = "New receipt";
            // 
            // flowLayoutPanelItems
            // 
            this.flowLayoutPanelItems.AutoScroll = true;
            this.flowLayoutPanelItems.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.flowLayoutPanelItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelItems.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelItems.Name = "flowLayoutPanelItems";
            this.flowLayoutPanelItems.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.flowLayoutPanelItems.Size = new System.Drawing.Size(731, 149);
            this.flowLayoutPanelItems.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.textBoxDiscount);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.comboBoxCustomer);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.comboBoxPaymentMethod);
            this.panel2.Controls.Add(this.buttonCloseRegister);
            this.panel2.Controls.Add(this.buttonPrint);
            this.panel2.Controls.Add(this.buttonDeleteItem);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(452, 10);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(279, 223);
            this.panel2.TabIndex = 10;
            // 
            // textBoxDiscount
            // 
            this.textBoxDiscount.ForeColor = System.Drawing.Color.Silver;
            this.textBoxDiscount.Location = new System.Drawing.Point(167, 28);
            this.textBoxDiscount.Name = "textBoxDiscount";
            this.textBoxDiscount.Size = new System.Drawing.Size(100, 20);
            this.textBoxDiscount.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(30, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 19);
            this.label2.TabIndex = 19;
            this.label2.Text = "Discount:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(30, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 19);
            this.label1.TabIndex = 18;
            this.label1.Text = "Customer:";
            // 
            // comboBoxCustomer
            // 
            this.comboBoxCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxCustomer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxCustomer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.comboBoxCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxCustomer.ForeColor = System.Drawing.Color.Silver;
            this.comboBoxCustomer.FormattingEnabled = true;
            this.comboBoxCustomer.Items.AddRange(new object[] {
            "Regular customer"});
            this.comboBoxCustomer.Location = new System.Drawing.Point(167, 60);
            this.comboBoxCustomer.Name = "comboBoxCustomer";
            this.comboBoxCustomer.Size = new System.Drawing.Size(100, 21);
            this.comboBoxCustomer.TabIndex = 17;
            this.comboBoxCustomer.Tag = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(30, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 19);
            this.label5.TabIndex = 16;
            this.label5.Text = "Payment type:";
            // 
            // comboBoxPaymentMethod
            // 
            this.comboBoxPaymentMethod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxPaymentMethod.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxPaymentMethod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.comboBoxPaymentMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPaymentMethod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxPaymentMethod.ForeColor = System.Drawing.Color.Silver;
            this.comboBoxPaymentMethod.FormattingEnabled = true;
            this.comboBoxPaymentMethod.Items.AddRange(new object[] {
            "Gotovina",
            "Kartica"});
            this.comboBoxPaymentMethod.Location = new System.Drawing.Point(167, 91);
            this.comboBoxPaymentMethod.Name = "comboBoxPaymentMethod";
            this.comboBoxPaymentMethod.Size = new System.Drawing.Size(100, 21);
            this.comboBoxPaymentMethod.TabIndex = 7;
            this.comboBoxPaymentMethod.Tag = "";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(10, 10, 0, 10);
            this.panel3.Size = new System.Drawing.Size(731, 243);
            this.panel3.TabIndex = 11;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.dataGridView1);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(10, 10);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(442, 223);
            this.panel6.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 190);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(731, 243);
            this.panel4.TabIndex = 10;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.flowLayoutPanelItems);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 41);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(731, 149);
            this.panel5.TabIndex = 3;
            // 
            // FormNewReceipt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.ClientSize = new System.Drawing.Size(731, 433);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Name = "FormNewReceipt";
            this.Text = "FormStorage";
            this.Load += new System.EventHandler(this.FormNewReceipt_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.storageBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.caffeBarDatabaseDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.storageBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.caffeBarDatabaseDataSetBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonPrint;
        private System.Windows.Forms.BindingSource userBindingSource;
        private System.Windows.Forms.BindingSource caffeBarDatabaseDataSetBindingSource;
        private CaffeBarDatabaseDataSet caffeBarDatabaseDataSet;
        private CaffeBarDatabaseDataSetTableAdapters.UserTableAdapter userTableAdapter;
        private System.Windows.Forms.BindingSource storageBindingSource;
        private CaffeBarDatabaseDataSetTableAdapters.StorageTableAdapter storageTableAdapter;
        private System.Windows.Forms.BindingSource storageBindingSource1;
        private System.Windows.Forms.Button buttonDeleteItem;
        private System.Windows.Forms.Button buttonCloseRegister;
        private System.Windows.Forms.Button buttonCloseForm;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelItems;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox comboBoxPaymentMethod;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxCustomer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxDiscount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
    }
}