﻿namespace rp3_caffeBar
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
            this.Blagajna = new System.Windows.Forms.ToolStripButton();
            this.Skladište = new System.Windows.Forms.ToolStripButton();
            this.Administracija = new System.Windows.Forms.ToolStripButton();
            this.Logout = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.button_izdajRacun = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.Naziv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Količina = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cijena = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ukupno = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.Blagajna,
            this.Skladište,
            this.Administracija,
            this.Logout});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(63, 24);
            this.toolStripButton1.Text = "CaffeBar A";
            // 
            // Blagajna
            // 
            this.Blagajna.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Blagajna.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Blagajna.Image = ((System.Drawing.Image)(resources.GetObject("Blagajna.Image")));
            this.Blagajna.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Blagajna.Margin = new System.Windows.Forms.Padding(4);
            this.Blagajna.Name = "Blagajna";
            this.Blagajna.Size = new System.Drawing.Size(56, 19);
            this.Blagajna.Text = "Blagajna";
            // 
            // Skladište
            // 
            this.Skladište.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Skladište.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Skladište.Image = ((System.Drawing.Image)(resources.GetObject("Skladište.Image")));
            this.Skladište.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Skladište.Margin = new System.Windows.Forms.Padding(4);
            this.Skladište.Name = "Skladište";
            this.Skladište.Size = new System.Drawing.Size(57, 19);
            this.Skladište.Text = "Skladište";
            // 
            // Administracija
            // 
            this.Administracija.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Administracija.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Administracija.Image = ((System.Drawing.Image)(resources.GetObject("Administracija.Image")));
            this.Administracija.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Administracija.Margin = new System.Windows.Forms.Padding(4);
            this.Administracija.Name = "Administracija";
            this.Administracija.Size = new System.Drawing.Size(87, 19);
            this.Administracija.Text = "Administracija";
            // 
            // Logout
            // 
            this.Logout.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.Logout.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Logout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Logout.Image = ((System.Drawing.Image)(resources.GetObject("Logout.Image")));
            this.Logout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Logout.Margin = new System.Windows.Forms.Padding(4);
            this.Logout.Name = "Logout";
            this.Logout.Size = new System.Drawing.Size(49, 19);
            this.Logout.Text = "Logout";
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
            this.splitContainer1.Panel1.Controls.Add(this.button_izdajRacun);
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.flowLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(800, 423);
            this.splitContainer1.SplitterDistance = 551;
            this.splitContainer1.TabIndex = 3;
            // 
            // button_izdajRacun
            // 
            this.button_izdajRacun.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button_izdajRacun.Dock = System.Windows.Forms.DockStyle.Top;
            this.button_izdajRacun.Location = new System.Drawing.Point(0, 316);
            this.button_izdajRacun.Name = "button_izdajRacun";
            this.button_izdajRacun.Size = new System.Drawing.Size(551, 28);
            this.button_izdajRacun.TabIndex = 1;
            this.button_izdajRacun.Text = "Izdaj Račun";
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
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(551, 316);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(245, 423);
            this.flowLayoutPanel1.TabIndex = 0;
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
            // OwnerMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "OwnerMain";
            this.Text = "OwnerMain";
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
        private System.Windows.Forms.ToolStripButton Blagajna;
        private System.Windows.Forms.ToolStripButton Skladište;
        private System.Windows.Forms.ToolStripButton Administracija;
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
    }
}