namespace rp3_caffeBar
{
    partial class ChangeNamePrice
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
            this.button2 = new System.Windows.Forms.Button();
            this.button_primjeni = new System.Windows.Forms.Button();
            this.textBox_cijenaNova = new System.Windows.Forms.TextBox();
            this.textBox_proizvodNovi = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_cijenaStara = new System.Windows.Forms.TextBox();
            this.textBox_proizvodStari = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button2.Location = new System.Drawing.Point(154, 283);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 19;
            this.button2.Text = "Odustani";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button_primjeni
            // 
            this.button_primjeni.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button_primjeni.Location = new System.Drawing.Point(51, 283);
            this.button_primjeni.Name = "button_primjeni";
            this.button_primjeni.Size = new System.Drawing.Size(75, 23);
            this.button_primjeni.TabIndex = 18;
            this.button_primjeni.Text = "Primjeni!";
            this.button_primjeni.UseVisualStyleBackColor = false;
            this.button_primjeni.Click += new System.EventHandler(this.button_primjeni_Click);
            // 
            // textBox_cijenaNova
            // 
            this.textBox_cijenaNova.Location = new System.Drawing.Point(144, 213);
            this.textBox_cijenaNova.Name = "textBox_cijenaNova";
            this.textBox_cijenaNova.Size = new System.Drawing.Size(100, 20);
            this.textBox_cijenaNova.TabIndex = 17;
            // 
            // textBox_proizvodNovi
            // 
            this.textBox_proizvodNovi.Location = new System.Drawing.Point(144, 164);
            this.textBox_proizvodNovi.Name = "textBox_proizvodNovi";
            this.textBox_proizvodNovi.Size = new System.Drawing.Size(100, 20);
            this.textBox_proizvodNovi.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(46, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 26);
            this.label4.TabIndex = 15;
            this.label4.Text = "Novi naziv \r\nproizvoda";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 207);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 26);
            this.label3.TabIndex = 14;
            this.label3.Text = "Nova cijena\r\nproizvoda";
            // 
            // textBox_cijenaStara
            // 
            this.textBox_cijenaStara.Location = new System.Drawing.Point(144, 113);
            this.textBox_cijenaStara.Name = "textBox_cijenaStara";
            this.textBox_cijenaStara.ReadOnly = true;
            this.textBox_cijenaStara.Size = new System.Drawing.Size(100, 20);
            this.textBox_cijenaStara.TabIndex = 13;
            // 
            // textBox_proizvodStari
            // 
            this.textBox_proizvodStari.Location = new System.Drawing.Point(144, 68);
            this.textBox_proizvodStari.Name = "textBox_proizvodStari";
            this.textBox_proizvodStari.Size = new System.Drawing.Size(100, 20);
            this.textBox_proizvodStari.TabIndex = 12;
            this.textBox_proizvodStari.TextChanged += new System.EventHandler(this.textBox_proizvodStari_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 26);
            this.label2.TabIndex = 11;
            this.label2.Text = "Trenutna cijena\r\nproizvoda";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 26);
            this.label1.TabIndex = 10;
            this.label1.Text = "Trenutni naziv \r\nproizvoda";
            // 
            // ChangeNamePrice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 375);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button_primjeni);
            this.Controls.Add(this.textBox_cijenaNova);
            this.Controls.Add(this.textBox_proizvodNovi);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_cijenaStara);
            this.Controls.Add(this.textBox_proizvodStari);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ChangeNamePrice";
            this.Text = "ChangeNamePrice";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button_primjeni;
        private System.Windows.Forms.TextBox textBox_cijenaNova;
        private System.Windows.Forms.TextBox textBox_proizvodNovi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_cijenaStara;
        private System.Windows.Forms.TextBox textBox_proizvodStari;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}