namespace rp3_caffeBar
{
    partial class Administration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Administration));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripLabel();
            this.button_blagajna = new System.Windows.Forms.ToolStripButton();
            this.button_skladiste = new System.Windows.Forms.ToolStripButton();
            this.button_administracija = new System.Windows.Forms.ToolStripButton();
            this.Logout = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.button_refresh = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Naziv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sifra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button_delete = new System.Windows.Forms.Button();
            this.button_dodaj = new System.Windows.Forms.Button();
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
            this.Logout});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 32);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(82, 29);
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
            this.button_blagajna.Size = new System.Drawing.Size(71, 24);
            this.button_blagajna.Text = "Blagajna";
            this.button_blagajna.Click += new System.EventHandler(this.button_blagajna_Click);
            // 
            // button_skladiste
            // 
            this.button_skladiste.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button_skladiste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.button_skladiste.Image = ((System.Drawing.Image)(resources.GetObject("button_skladiste.Image")));
            this.button_skladiste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.button_skladiste.Margin = new System.Windows.Forms.Padding(4);
            this.button_skladiste.Name = "button_skladiste";
            this.button_skladiste.Size = new System.Drawing.Size(72, 24);
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
            this.button_administracija.Size = new System.Drawing.Size(108, 24);
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
            this.Logout.Size = new System.Drawing.Size(60, 24);
            this.Logout.Text = "Logout";
            this.Logout.Click += new System.EventHandler(this.Logout_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitContainer1.Location = new System.Drawing.Point(0, 32);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.splitContainer1.Panel2.Controls.Add(this.button_delete);
            this.splitContainer1.Panel2.Controls.Add(this.button_dodaj);
            this.splitContainer1.Size = new System.Drawing.Size(800, 414);
            this.splitContainer1.SplitterDistance = 592;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 7;
            // 
            // button_refresh
            // 
            this.button_refresh.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button_refresh.Location = new System.Drawing.Point(4, 4);
            this.button_refresh.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_refresh.Name = "button_refresh";
            this.button_refresh.Size = new System.Drawing.Size(45, 32);
            this.button_refresh.TabIndex = 1;
            this.button_refresh.Text = "REFRESH";
            this.button_refresh.UseVisualStyleBackColor = false;
            this.button_refresh.Click += new System.EventHandler(this.button_refresh_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Info;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Naziv,
            this.Sifra});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(592, 414);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Naziv
            // 
            this.Naziv.HeaderText = "Korisničko ime zaposlenika";
            this.Naziv.MinimumWidth = 6;
            this.Naziv.Name = "Naziv";
            this.Naziv.ReadOnly = true;
            this.Naziv.Width = 130;
            // 
            // Sifra
            // 
            this.Sifra.HeaderText = "Šifra";
            this.Sifra.MinimumWidth = 6;
            this.Sifra.Name = "Sifra";
            this.Sifra.Width = 125;
            // 
            // button_delete
            // 
            this.button_delete.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button_delete.Location = new System.Drawing.Point(39, 209);
            this.button_delete.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(135, 55);
            this.button_delete.TabIndex = 2;
            this.button_delete.Text = "Obriši";
            this.button_delete.UseVisualStyleBackColor = false;
            this.button_delete.Click += new System.EventHandler(this.button_delete_Click);
            // 
            // button_dodaj
            // 
            this.button_dodaj.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button_dodaj.Location = new System.Drawing.Point(39, 133);
            this.button_dodaj.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_dodaj.Name = "button_dodaj";
            this.button_dodaj.Size = new System.Drawing.Size(135, 55);
            this.button_dodaj.TabIndex = 0;
            this.button_dodaj.Text = "Dodaj ";
            this.button_dodaj.UseVisualStyleBackColor = false;
            this.button_dodaj.Click += new System.EventHandler(this.button_dodaj_Click);
            // 
            // Administration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Administration";
            this.ShowIcon = false;
            this.Text = "Administracija";
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
        private System.Windows.Forms.DataGridViewTextBoxColumn Naziv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sifra;
        private System.Windows.Forms.Button button_refresh;
        private System.Windows.Forms.Button button_delete;
        private System.Windows.Forms.Button button_dodaj;
    }
}