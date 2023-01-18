namespace rp3_caffeBar
{
    partial class CoolerRestore
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_proizvod = new System.Windows.Forms.TextBox();
            this.textBox_hladnjak = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_skladiste = new System.Windows.Forms.TextBox();
            this.textBox_dodati = new System.Windows.Forms.TextBox();
            this.button_dodaj = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Proizvod";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 26);
            this.label2.TabIndex = 1;
            this.label2.Text = "Trenutna količina \r\nu hladnjaku";
            // 
            // textBox_proizvod
            // 
            this.textBox_proizvod.Location = new System.Drawing.Point(133, 75);
            this.textBox_proizvod.Name = "textBox_proizvod";
            this.textBox_proizvod.Size = new System.Drawing.Size(100, 20);
            this.textBox_proizvod.TabIndex = 2;
            this.textBox_proizvod.TextChanged += new System.EventHandler(this.textBox_proizvod_TextChanged);
            // 
            // textBox_hladnjak
            // 
            this.textBox_hladnjak.Location = new System.Drawing.Point(133, 120);
            this.textBox_hladnjak.Name = "textBox_hladnjak";
            this.textBox_hladnjak.ReadOnly = true;
            this.textBox_hladnjak.Size = new System.Drawing.Size(100, 20);
            this.textBox_hladnjak.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 214);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 26);
            this.label3.TabIndex = 4;
            this.label3.Text = "Dodati iz\r\n skladišta";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 171);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 26);
            this.label4.TabIndex = 5;
            this.label4.Text = "Trenutna količina \r\nu skladištu";
            // 
            // textBox_skladiste
            // 
            this.textBox_skladiste.Location = new System.Drawing.Point(133, 171);
            this.textBox_skladiste.Name = "textBox_skladiste";
            this.textBox_skladiste.ReadOnly = true;
            this.textBox_skladiste.Size = new System.Drawing.Size(100, 20);
            this.textBox_skladiste.TabIndex = 6;
            // 
            // textBox_dodati
            // 
            this.textBox_dodati.Location = new System.Drawing.Point(133, 220);
            this.textBox_dodati.Name = "textBox_dodati";
            this.textBox_dodati.Size = new System.Drawing.Size(100, 20);
            this.textBox_dodati.TabIndex = 7;
            // 
            // button_dodaj
            // 
            this.button_dodaj.Location = new System.Drawing.Point(52, 291);
            this.button_dodaj.Name = "button_dodaj";
            this.button_dodaj.Size = new System.Drawing.Size(75, 23);
            this.button_dodaj.TabIndex = 8;
            this.button_dodaj.Text = "Dodaj!";
            this.button_dodaj.UseVisualStyleBackColor = true;
            this.button_dodaj.Click += new System.EventHandler(this.button_dodaj_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(155, 290);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Odustani";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // CoolerRestore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 375);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button_dodaj);
            this.Controls.Add(this.textBox_dodati);
            this.Controls.Add(this.textBox_skladiste);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_hladnjak);
            this.Controls.Add(this.textBox_proizvod);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CoolerRestore";
            this.Text = "CoolerRestore";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_proizvod;
        private System.Windows.Forms.TextBox textBox_hladnjak;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_skladiste;
        private System.Windows.Forms.TextBox textBox_dodati;
        private System.Windows.Forms.Button button_dodaj;
        private System.Windows.Forms.Button button2;
    }
}