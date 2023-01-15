
namespace CaffeBar
{
    partial class FormAccounts
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
            this.buttonAddUser = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usernameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.passwordDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.authorisationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deletedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.caffeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.juiceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stateondateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.caffeBarDatabaseDataSet = new CaffeBar.CaffeBarDatabaseDataSet();
            this.storageBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.userTableAdapter = new CaffeBar.CaffeBarDatabaseDataSetTableAdapters.UserTableAdapter();
            this.storageTableAdapter = new CaffeBar.CaffeBarDatabaseDataSetTableAdapters.StorageTableAdapter();
            this.storageBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.buttonCloseFormStorage = new System.Windows.Forms.Button();
            this.userBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.caffeBarDatabaseDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.caffeBarDatabaseDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.storageBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.storageBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.caffeBarDatabaseDataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
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
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.usernameDataGridViewTextBoxColumn,
            this.passwordDataGridViewTextBoxColumn,
            this.authorisationDataGridViewTextBoxColumn,
            this.deletedDataGridViewTextBoxColumn,
            this.caffeDataGridViewTextBoxColumn,
            this.juiceDataGridViewTextBoxColumn,
            this.stateondateDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.userBindingSource1;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.dataGridView1.Location = new System.Drawing.Point(10, 117);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.PaleVioletRed;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Size = new System.Drawing.Size(584, 312);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.dataGridView1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowEnter);
            this.dataGridView1.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridView1_UserAddedRow);
            this.dataGridView1.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataGridView1_UserDeletingRow);
            // 
            // buttonAddUser
            // 
            this.buttonAddUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.buttonAddUser.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.buttonAddUser.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.buttonAddUser.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(57)))), ((int)(((byte)(63)))));
            this.buttonAddUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddUser.ForeColor = System.Drawing.Color.Silver;
            this.buttonAddUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAddUser.Location = new System.Drawing.Point(627, 117);
            this.buttonAddUser.Name = "buttonAddUser";
            this.buttonAddUser.Size = new System.Drawing.Size(102, 30);
            this.buttonAddUser.TabIndex = 3;
            this.buttonAddUser.Text = "Add user";
            this.buttonAddUser.UseVisualStyleBackColor = false;
            this.buttonAddUser.Click += new System.EventHandler(this.buttonAddUser_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelTitle);
            this.panel1.Controls.Add(this.buttonCloseFormStorage);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(741, 41);
            this.panel1.TabIndex = 10;
            // 
            // labelTitle
            // 
            this.labelTitle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.Location = new System.Drawing.Point(12, 3);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(126, 30);
            this.labelTitle.TabIndex = 11;
            this.labelTitle.Text = "Accounts";
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Width = 41;
            // 
            // usernameDataGridViewTextBoxColumn
            // 
            this.usernameDataGridViewTextBoxColumn.DataPropertyName = "Username";
            this.usernameDataGridViewTextBoxColumn.HeaderText = "Username";
            this.usernameDataGridViewTextBoxColumn.Name = "usernameDataGridViewTextBoxColumn";
            this.usernameDataGridViewTextBoxColumn.ReadOnly = true;
            this.usernameDataGridViewTextBoxColumn.Width = 89;
            // 
            // passwordDataGridViewTextBoxColumn
            // 
            this.passwordDataGridViewTextBoxColumn.DataPropertyName = "Password";
            this.passwordDataGridViewTextBoxColumn.HeaderText = "Password";
            this.passwordDataGridViewTextBoxColumn.Name = "passwordDataGridViewTextBoxColumn";
            this.passwordDataGridViewTextBoxColumn.ReadOnly = true;
            this.passwordDataGridViewTextBoxColumn.Width = 85;
            // 
            // authorisationDataGridViewTextBoxColumn
            // 
            this.authorisationDataGridViewTextBoxColumn.DataPropertyName = "Authorisation";
            this.authorisationDataGridViewTextBoxColumn.HeaderText = "Authorisation";
            this.authorisationDataGridViewTextBoxColumn.Name = "authorisationDataGridViewTextBoxColumn";
            this.authorisationDataGridViewTextBoxColumn.ReadOnly = true;
            this.authorisationDataGridViewTextBoxColumn.Width = 102;
            // 
            // deletedDataGridViewTextBoxColumn
            // 
            this.deletedDataGridViewTextBoxColumn.DataPropertyName = "Deleted";
            this.deletedDataGridViewTextBoxColumn.HeaderText = "Deleted";
            this.deletedDataGridViewTextBoxColumn.Name = "deletedDataGridViewTextBoxColumn";
            this.deletedDataGridViewTextBoxColumn.ReadOnly = true;
            this.deletedDataGridViewTextBoxColumn.Width = 74;
            // 
            // caffeDataGridViewTextBoxColumn
            // 
            this.caffeDataGridViewTextBoxColumn.DataPropertyName = "Caffe";
            this.caffeDataGridViewTextBoxColumn.HeaderText = "Caffe";
            this.caffeDataGridViewTextBoxColumn.Name = "caffeDataGridViewTextBoxColumn";
            this.caffeDataGridViewTextBoxColumn.ReadOnly = true;
            this.caffeDataGridViewTextBoxColumn.Width = 59;
            // 
            // juiceDataGridViewTextBoxColumn
            // 
            this.juiceDataGridViewTextBoxColumn.DataPropertyName = "Juice";
            this.juiceDataGridViewTextBoxColumn.HeaderText = "Juice";
            this.juiceDataGridViewTextBoxColumn.Name = "juiceDataGridViewTextBoxColumn";
            this.juiceDataGridViewTextBoxColumn.ReadOnly = true;
            this.juiceDataGridViewTextBoxColumn.Width = 60;
            // 
            // stateondateDataGridViewTextBoxColumn
            // 
            this.stateondateDataGridViewTextBoxColumn.DataPropertyName = "State_on_date";
            this.stateondateDataGridViewTextBoxColumn.HeaderText = "State_on_date";
            this.stateondateDataGridViewTextBoxColumn.Name = "stateondateDataGridViewTextBoxColumn";
            this.stateondateDataGridViewTextBoxColumn.ReadOnly = true;
            this.stateondateDataGridViewTextBoxColumn.Width = 111;
            // 
            // userBindingSource1
            // 
            this.userBindingSource1.DataMember = "User";
            this.userBindingSource1.DataSource = this.caffeBarDatabaseDataSet;
            // 
            // caffeBarDatabaseDataSet
            // 
            this.caffeBarDatabaseDataSet.DataSetName = "CaffeBarDatabaseDataSet";
            this.caffeBarDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // storageBindingSource
            // 
            this.storageBindingSource.DataMember = "Storage";
            this.storageBindingSource.DataSource = this.caffeBarDatabaseDataSet;
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
            // buttonCloseFormStorage
            // 
            this.buttonCloseFormStorage.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonCloseFormStorage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.buttonCloseFormStorage.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.buttonCloseFormStorage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.buttonCloseFormStorage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(57)))), ((int)(((byte)(63)))));
            this.buttonCloseFormStorage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCloseFormStorage.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCloseFormStorage.ForeColor = System.Drawing.Color.Red;
            this.buttonCloseFormStorage.Image = global::CaffeBar.Properties.Resources.close_removebg_preview;
            this.buttonCloseFormStorage.Location = new System.Drawing.Point(703, 9);
            this.buttonCloseFormStorage.Name = "buttonCloseFormStorage";
            this.buttonCloseFormStorage.Size = new System.Drawing.Size(26, 26);
            this.buttonCloseFormStorage.TabIndex = 7;
            this.buttonCloseFormStorage.UseVisualStyleBackColor = false;
            this.buttonCloseFormStorage.Click += new System.EventHandler(this.button4_Click);
            // 
            // FormAccounts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.ClientSize = new System.Drawing.Size(741, 441);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonAddUser);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FormAccounts";
            this.Text = "Accounts";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormAccounts_FormClosed);
            this.Load += new System.EventHandler(this.FormAccounts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.caffeBarDatabaseDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.storageBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.storageBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.caffeBarDatabaseDataSetBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonAddUser;
        private System.Windows.Forms.BindingSource userBindingSource;
        private System.Windows.Forms.BindingSource caffeBarDatabaseDataSetBindingSource;
        private CaffeBarDatabaseDataSet caffeBarDatabaseDataSet;
        private CaffeBarDatabaseDataSetTableAdapters.UserTableAdapter userTableAdapter;
        private System.Windows.Forms.BindingSource storageBindingSource;
        private CaffeBarDatabaseDataSetTableAdapters.StorageTableAdapter storageTableAdapter;
        private System.Windows.Forms.BindingSource storageBindingSource1;
        private System.Windows.Forms.Button buttonCloseFormStorage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.BindingSource userBindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usernameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn passwordDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn authorisationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn deletedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn caffeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn juiceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stateondateDataGridViewTextBoxColumn;
    }
}