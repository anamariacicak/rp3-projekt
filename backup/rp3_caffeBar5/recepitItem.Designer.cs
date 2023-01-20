namespace rp3_caffeBar
{
    partial class recepitItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox_naziv = new System.Windows.Forms.TextBox();
            this.textBox_kolicina = new System.Windows.Forms.TextBox();
            this.textBox_ukupno = new System.Windows.Forms.TextBox();
            this.textBox_cijena = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox_naziv
            // 
            this.textBox_naziv.Location = new System.Drawing.Point(0, 0);
            this.textBox_naziv.Name = "textBox_naziv";
            this.textBox_naziv.Size = new System.Drawing.Size(100, 20);
            this.textBox_naziv.TabIndex = 0;
            // 
            // textBox_kolicina
            // 
            this.textBox_kolicina.Location = new System.Drawing.Point(97, 0);
            this.textBox_kolicina.Name = "textBox_kolicina";
            this.textBox_kolicina.Size = new System.Drawing.Size(100, 20);
            this.textBox_kolicina.TabIndex = 1;
            // 
            // textBox_ukupno
            // 
            this.textBox_ukupno.Location = new System.Drawing.Point(291, 0);
            this.textBox_ukupno.Name = "textBox_ukupno";
            this.textBox_ukupno.Size = new System.Drawing.Size(100, 20);
            this.textBox_ukupno.TabIndex = 2;
            // 
            // textBox_cijena
            // 
            this.textBox_cijena.Location = new System.Drawing.Point(193, 0);
            this.textBox_cijena.Name = "textBox_cijena";
            this.textBox_cijena.Size = new System.Drawing.Size(100, 20);
            this.textBox_cijena.TabIndex = 3;
            // 
            // recepitItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBox_cijena);
            this.Controls.Add(this.textBox_ukupno);
            this.Controls.Add(this.textBox_kolicina);
            this.Controls.Add(this.textBox_naziv);
            this.Name = "recepitItem";
            this.Size = new System.Drawing.Size(394, 22);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_naziv;
        private System.Windows.Forms.TextBox textBox_kolicina;
        private System.Windows.Forms.TextBox textBox_ukupno;
        private System.Windows.Forms.TextBox textBox_cijena;
    }
}
