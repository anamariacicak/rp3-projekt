namespace rp3_caffeBar
{
    partial class MainScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainScreen));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripLabel();
            this.button_blagajna = new System.Windows.Forms.ToolStripButton();
            this.button_skladiste = new System.Windows.Forms.ToolStripButton();
            this.button_administracija = new System.Windows.Forms.ToolStripButton();
            this.Logout = new System.Windows.Forms.ToolStripButton();
            this.button_statistika = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton_konobar = new System.Windows.Forms.RadioButton();
            this.radioButton_obicniKupac = new System.Windows.Forms.RadioButton();
            this.button_ispisPrometa = new System.Windows.Forms.Button();
            this.button_izdajRacun = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Naziv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Količina = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cijena = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ukupno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            this.toolStrip1.Size = new System.Drawing.Size(1067, 32);
            this.toolStrip1.TabIndex = 0;
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
            this.button_skladiste.Click += new System.EventHandler(this.Skladište_Click);
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
            // button_statistika
            // 
            this.button_statistika.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button_statistika.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.button_statistika.Image = ((System.Drawing.Image)(resources.GetObject("button_statistika.Image")));
            this.button_statistika.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.button_statistika.Margin = new System.Windows.Forms.Padding(4);
            this.button_statistika.Name = "button_statistika";
            this.button_statistika.Size = new System.Drawing.Size(73, 24);
            this.button_statistika.Text = "Statistika";
            this.button_statistika.Click += new System.EventHandler(this.button_statistika_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 32);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.button_ispisPrometa);
            this.splitContainer1.Panel1.Controls.Add(this.button_izdajRacun);
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.flowLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(1067, 522);
            this.splitContainer1.SplitterDistance = 732;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton_konobar);
            this.groupBox1.Controls.Add(this.radioButton_obicniKupac);
            this.groupBox1.Location = new System.Drawing.Point(35, 396);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(247, 58);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tip kupca";
            // 
            // radioButton_konobar
            // 
            this.radioButton_konobar.AutoSize = true;
            this.radioButton_konobar.Location = new System.Drawing.Point(132, 20);
            this.radioButton_konobar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButton_konobar.Name = "radioButton_konobar";
            this.radioButton_konobar.Size = new System.Drawing.Size(79, 20);
            this.radioButton_konobar.TabIndex = 1;
            this.radioButton_konobar.TabStop = true;
            this.radioButton_konobar.Text = "Konobar";
            this.radioButton_konobar.UseVisualStyleBackColor = true;
            // 
            // radioButton_obicniKupac
            // 
            this.radioButton_obicniKupac.AutoSize = true;
            this.radioButton_obicniKupac.Location = new System.Drawing.Point(11, 20);
            this.radioButton_obicniKupac.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButton_obicniKupac.Name = "radioButton_obicniKupac";
            this.radioButton_obicniKupac.Size = new System.Drawing.Size(106, 20);
            this.radioButton_obicniKupac.TabIndex = 0;
            this.radioButton_obicniKupac.TabStop = true;
            this.radioButton_obicniKupac.Text = "Obični kupac";
            this.radioButton_obicniKupac.UseVisualStyleBackColor = true;
            // 
            // button_ispisPrometa
            // 
            this.button_ispisPrometa.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button_ispisPrometa.Location = new System.Drawing.Point(94, 470);
            this.button_ispisPrometa.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_ispisPrometa.Name = "button_ispisPrometa";
            this.button_ispisPrometa.Size = new System.Drawing.Size(137, 33);
            this.button_ispisPrometa.TabIndex = 2;
            this.button_ispisPrometa.Text = "Ispis prometa";
            this.button_ispisPrometa.UseVisualStyleBackColor = false;
            this.button_ispisPrometa.Click += new System.EventHandler(this.button_ispisPrometa_Click);
            // 
            // button_izdajRacun
            // 
            this.button_izdajRacun.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button_izdajRacun.Location = new System.Drawing.Point(370, 416);
            this.button_izdajRacun.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_izdajRacun.Name = "button_izdajRacun";
            this.button_izdajRacun.Size = new System.Drawing.Size(327, 87);
            this.button_izdajRacun.TabIndex = 1;
            this.button_izdajRacun.Text = "IZDAJ RAČUN";
            this.button_izdajRacun.UseVisualStyleBackColor = false;
            this.button_izdajRacun.Click += new System.EventHandler(this.button_izdajRacun_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Info;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Naziv,
            this.Količina,
            this.Cijena,
            this.Ukupno});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(732, 389);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            // 
            // Naziv
            // 
            this.Naziv.HeaderText = "Naziv";
            this.Naziv.MinimumWidth = 6;
            this.Naziv.Name = "Naziv";
            this.Naziv.ReadOnly = true;
            this.Naziv.Width = 125;
            // 
            // Količina
            // 
            this.Količina.HeaderText = "Količina";
            this.Količina.MinimumWidth = 6;
            this.Količina.Name = "Količina";
            this.Količina.Width = 125;
            // 
            // Cijena
            // 
            this.Cijena.HeaderText = "Cijena";
            this.Cijena.MinimumWidth = 6;
            this.Cijena.Name = "Cijena";
            this.Cijena.ReadOnly = true;
            this.Cijena.Width = 125;
            // 
            // Ukupno
            // 
            this.Ukupno.HeaderText = "Ukupno";
            this.Ukupno.MinimumWidth = 6;
            this.Ukupno.Name = "Ukupno";
            this.Ukupno.ReadOnly = true;
            this.Ukupno.Width = 125;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(330, 522);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainScreen";
            this.Text = "OwnerMain";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton button_blagajna;
        private System.Windows.Forms.ToolStripButton button_skladiste;
        private System.Windows.Forms.ToolStripButton button_administracija;
        private System.Windows.Forms.ToolStripButton Logout;
        private System.Windows.Forms.ToolStripLabel toolStripButton1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button button_izdajRacun;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Naziv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Količina;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cijena;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ukupno;
        private System.Windows.Forms.Button button_ispisPrometa;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton_konobar;
        private System.Windows.Forms.RadioButton radioButton_obicniKupac;
        private System.Windows.Forms.ToolStripButton button_statistika;
    }
}