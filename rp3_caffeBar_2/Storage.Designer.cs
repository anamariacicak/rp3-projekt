namespace rp3_caffeBar
{
    partial class Storage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Storage));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripLabel();
            this.button_blagajna = new System.Windows.Forms.ToolStripButton();
            this.button_skladiste = new System.Windows.Forms.ToolStripButton();
            this.button_administracija = new System.Windows.Forms.ToolStripButton();
            this.Logout = new System.Windows.Forms.ToolStripButton();
            this.button_statistika = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.button_refresh = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Naziv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cijena = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hladnjak = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Skladište = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.promjena = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vrijeme = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hhPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hhBegin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hhEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hhCreate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button_happyHour = new System.Windows.Forms.Button();
            this.button_addProduct = new System.Windows.Forms.Button();
            this.button_edit = new System.Windows.Forms.Button();
            this.button_delete = new System.Windows.Forms.Button();
            this.button_storage = new System.Windows.Forms.Button();
            this.button_hladnjak = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.button_blagajna,
            this.button_skladiste,
            this.button_administracija,
            this.Logout,
            this.button_statistika});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 27);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(66, 24);
            this.toolStripButton1.Text = "CAFFE BAR";
            // 
            // button_blagajna
            // 
            this.button_blagajna.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button_blagajna.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.button_blagajna.Image = ((System.Drawing.Image)(resources.GetObject("button_blagajna.Image")));
            this.button_blagajna.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.button_blagajna.Margin = new System.Windows.Forms.Padding(4);
            this.button_blagajna.Name = "button_blagajna";
            this.button_blagajna.Size = new System.Drawing.Size(56, 19);
            this.button_blagajna.Text = "Blagajna";
            this.button_blagajna.Click += new System.EventHandler(this.Blagajna_Click);
            // 
            // button_skladiste
            // 
            this.button_skladiste.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button_skladiste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.button_skladiste.Image = ((System.Drawing.Image)(resources.GetObject("button_skladiste.Image")));
            this.button_skladiste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.button_skladiste.Margin = new System.Windows.Forms.Padding(4);
            this.button_skladiste.Name = "button_skladiste";
            this.button_skladiste.Size = new System.Drawing.Size(57, 19);
            this.button_skladiste.Text = "Skladište";
            this.button_skladiste.Click += new System.EventHandler(this.button_skladiste_Click);
            // 
            // button_administracija
            // 
            this.button_administracija.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button_administracija.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.button_administracija.Image = ((System.Drawing.Image)(resources.GetObject("button_administracija.Image")));
            this.button_administracija.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.button_administracija.Margin = new System.Windows.Forms.Padding(4);
            this.button_administracija.Name = "button_administracija";
            this.button_administracija.Size = new System.Drawing.Size(87, 19);
            this.button_administracija.Text = "Administracija";
            this.button_administracija.Click += new System.EventHandler(this.button_administracija_Click);
            // 
            // Logout
            // 
            this.Logout.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.Logout.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Logout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Logout.Image = ((System.Drawing.Image)(resources.GetObject("Logout.Image")));
            this.Logout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Logout.Margin = new System.Windows.Forms.Padding(4);
            this.Logout.Name = "Logout";
            this.Logout.Size = new System.Drawing.Size(49, 19);
            this.Logout.Text = "Logout";
            this.Logout.Click += new System.EventHandler(this.Logout_Click);
            // 
            // button_statistika
            // 
            this.button_statistika.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button_statistika.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.button_statistika.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button_statistika.Image = ((System.Drawing.Image)(resources.GetObject("button_statistika.Image")));
            this.button_statistika.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.button_statistika.Margin = new System.Windows.Forms.Padding(4);
            this.button_statistika.Name = "button_statistika";
            this.button_statistika.Size = new System.Drawing.Size(58, 19);
            this.button_statistika.Text = "Statistika";
            this.button_statistika.Click += new System.EventHandler(this.button_statistika_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 27);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.splitContainer1.Panel1.Controls.Add(this.button_refresh);
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.splitContainer1.Panel2.Controls.Add(this.button_happyHour);
            this.splitContainer1.Panel2.Controls.Add(this.button_addProduct);
            this.splitContainer1.Panel2.Controls.Add(this.button_edit);
            this.splitContainer1.Panel2.Controls.Add(this.button_delete);
            this.splitContainer1.Panel2.Controls.Add(this.button_storage);
            this.splitContainer1.Panel2.Controls.Add(this.button_hladnjak);
            this.splitContainer1.Size = new System.Drawing.Size(800, 423);
            this.splitContainer1.SplitterDistance = 674;
            this.splitContainer1.TabIndex = 4;
            // 
            // button_refresh
            // 
            this.button_refresh.BackColor = System.Drawing.SystemColors.Control;
            this.button_refresh.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_refresh.BackgroundImage")));
            this.button_refresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_refresh.Image = ((System.Drawing.Image)(resources.GetObject("button_refresh.Image")));
            this.button_refresh.Location = new System.Drawing.Point(3, 3);
            this.button_refresh.Name = "button_refresh";
            this.button_refresh.Size = new System.Drawing.Size(43, 28);
            this.button_refresh.TabIndex = 1;
            this.button_refresh.UseVisualStyleBackColor = false;
            this.button_refresh.Click += new System.EventHandler(this.button_refresh_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Info;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Naziv,
            this.Cijena,
            this.Hladnjak,
            this.Skladište,
            this.promjena,
            this.vrijeme,
            this.hhPrice,
            this.hhBegin,
            this.hhEnd,
            this.hhCreate});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(674, 423);
            this.dataGridView1.TabIndex = 0;
            // 
            // Naziv
            // 
            this.Naziv.HeaderText = "Naziv";
            this.Naziv.MinimumWidth = 6;
            this.Naziv.Name = "Naziv";
            this.Naziv.ReadOnly = true;
            this.Naziv.Width = 125;
            // 
            // Cijena
            // 
            this.Cijena.HeaderText = "Cijena";
            this.Cijena.MinimumWidth = 6;
            this.Cijena.Name = "Cijena";
            this.Cijena.ReadOnly = true;
            this.Cijena.Width = 125;
            // 
            // Hladnjak
            // 
            this.Hladnjak.HeaderText = "Hladnjak";
            this.Hladnjak.MinimumWidth = 6;
            this.Hladnjak.Name = "Hladnjak";
            this.Hladnjak.ReadOnly = true;
            this.Hladnjak.Width = 125;
            // 
            // Skladište
            // 
            this.Skladište.HeaderText = "Skladište";
            this.Skladište.MinimumWidth = 6;
            this.Skladište.Name = "Skladište";
            this.Skladište.ReadOnly = true;
            this.Skladište.Width = 125;
            // 
            // promjena
            // 
            this.promjena.HeaderText = "Zadnju promjenu napravio";
            this.promjena.MinimumWidth = 6;
            this.promjena.Name = "promjena";
            this.promjena.ReadOnly = true;
            this.promjena.Width = 125;
            // 
            // vrijeme
            // 
            this.vrijeme.HeaderText = "Vrijeme zadnje promjene";
            this.vrijeme.MinimumWidth = 6;
            this.vrijeme.Name = "vrijeme";
            this.vrijeme.ReadOnly = true;
            this.vrijeme.Width = 125;
            // 
            // hhPrice
            // 
            this.hhPrice.HeaderText = "Happy Hour Cijena";
            this.hhPrice.MinimumWidth = 6;
            this.hhPrice.Name = "hhPrice";
            this.hhPrice.ReadOnly = true;
            this.hhPrice.Width = 125;
            // 
            // hhBegin
            // 
            this.hhBegin.HeaderText = "Početak Happy Hour";
            this.hhBegin.MinimumWidth = 6;
            this.hhBegin.Name = "hhBegin";
            this.hhBegin.ReadOnly = true;
            this.hhBegin.Width = 125;
            // 
            // hhEnd
            // 
            this.hhEnd.HeaderText = "Kraj Happy Hour";
            this.hhEnd.MinimumWidth = 6;
            this.hhEnd.Name = "hhEnd";
            this.hhEnd.ReadOnly = true;
            this.hhEnd.Width = 125;
            // 
            // hhCreate
            // 
            this.hhCreate.HeaderText = "Happy Hour dodao";
            this.hhCreate.MinimumWidth = 6;
            this.hhCreate.Name = "hhCreate";
            this.hhCreate.ReadOnly = true;
            this.hhCreate.Width = 125;
            // 
            // button_happyHour
            // 
            this.button_happyHour.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button_happyHour.Location = new System.Drawing.Point(13, 305);
            this.button_happyHour.Name = "button_happyHour";
            this.button_happyHour.Size = new System.Drawing.Size(101, 45);
            this.button_happyHour.TabIndex = 5;
            this.button_happyHour.Text = "Dodaj Happy Hour";
            this.button_happyHour.UseVisualStyleBackColor = false;
            this.button_happyHour.Click += new System.EventHandler(this.button_happyHour_Click);
            // 
            // button_addProduct
            // 
            this.button_addProduct.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button_addProduct.Location = new System.Drawing.Point(13, 202);
            this.button_addProduct.Name = "button_addProduct";
            this.button_addProduct.Size = new System.Drawing.Size(101, 45);
            this.button_addProduct.TabIndex = 4;
            this.button_addProduct.Text = "Dodaj proizvod";
            this.button_addProduct.UseVisualStyleBackColor = false;
            this.button_addProduct.Click += new System.EventHandler(this.button_addProduct_Click);
            // 
            // button_edit
            // 
            this.button_edit.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button_edit.Location = new System.Drawing.Point(13, 151);
            this.button_edit.Name = "button_edit";
            this.button_edit.Size = new System.Drawing.Size(101, 45);
            this.button_edit.TabIndex = 3;
            this.button_edit.Text = "Promijeni naziv/cijenu";
            this.button_edit.UseVisualStyleBackColor = false;
            this.button_edit.Click += new System.EventHandler(this.button_edit_Click);
            // 
            // button_delete
            // 
            this.button_delete.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button_delete.Location = new System.Drawing.Point(13, 254);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(101, 45);
            this.button_delete.TabIndex = 2;
            this.button_delete.Text = "Obriši proizvod";
            this.button_delete.UseVisualStyleBackColor = false;
            this.button_delete.Click += new System.EventHandler(this.button_delete_Click);
            // 
            // button_storage
            // 
            this.button_storage.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button_storage.Location = new System.Drawing.Point(13, 100);
            this.button_storage.Name = "button_storage";
            this.button_storage.Size = new System.Drawing.Size(101, 45);
            this.button_storage.TabIndex = 1;
            this.button_storage.Text = "Naruči proizvod";
            this.button_storage.UseVisualStyleBackColor = false;
            this.button_storage.Click += new System.EventHandler(this.button_storage_Click);
            // 
            // button_hladnjak
            // 
            this.button_hladnjak.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button_hladnjak.Location = new System.Drawing.Point(13, 45);
            this.button_hladnjak.Name = "button_hladnjak";
            this.button_hladnjak.Size = new System.Drawing.Size(101, 49);
            this.button_hladnjak.TabIndex = 0;
            this.button_hladnjak.Text = "Napuni hladnjak";
            this.button_hladnjak.UseVisualStyleBackColor = false;
            this.button_hladnjak.Click += new System.EventHandler(this.button_hladnjak_Click);
            // 
            // Storage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Storage";
            this.ShowIcon = false;
            this.Text = "Skladište";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripButton1;
        private System.Windows.Forms.ToolStripButton button_blagajna;
        private System.Windows.Forms.ToolStripButton button_skladiste;
        private System.Windows.Forms.ToolStripButton button_administracija;
        private System.Windows.Forms.ToolStripButton Logout;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button_edit;
        private System.Windows.Forms.Button button_delete;
        private System.Windows.Forms.Button button_storage;
        private System.Windows.Forms.Button button_hladnjak;
        private System.Windows.Forms.Button button_refresh;
        private System.Windows.Forms.Button button_happyHour;
        private System.Windows.Forms.Button button_addProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn Naziv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cijena;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hladnjak;
        private System.Windows.Forms.DataGridViewTextBoxColumn Skladište;
        private System.Windows.Forms.DataGridViewTextBoxColumn promjena;
        private System.Windows.Forms.DataGridViewTextBoxColumn vrijeme;
        private System.Windows.Forms.DataGridViewTextBoxColumn hhPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn hhBegin;
        private System.Windows.Forms.DataGridViewTextBoxColumn hhEnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn hhCreate;
        private System.Windows.Forms.ToolStripButton button_statistika;
    }
}