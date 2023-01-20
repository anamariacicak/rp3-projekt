namespace rp3_caffeBar
{
    partial class prometItem
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
            this.textBox_cijena = new System.Windows.Forms.TextBox();
            this.textBox_vrijeme = new System.Windows.Forms.TextBox();
            this.textBox_username = new System.Windows.Forms.TextBox();
            this.textBox_brRacuna = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox_cijena
            // 
            this.textBox_cijena.Location = new System.Drawing.Point(193, 3);
            this.textBox_cijena.Name = "textBox_cijena";
            this.textBox_cijena.Size = new System.Drawing.Size(100, 20);
            this.textBox_cijena.TabIndex = 7;
            // 
            // textBox_vrijeme
            // 
            this.textBox_vrijeme.Location = new System.Drawing.Point(291, 3);
            this.textBox_vrijeme.Name = "textBox_vrijeme";
            this.textBox_vrijeme.Size = new System.Drawing.Size(100, 20);
            this.textBox_vrijeme.TabIndex = 6;
            // 
            // textBox_username
            // 
            this.textBox_username.Location = new System.Drawing.Point(97, 3);
            this.textBox_username.Name = "textBox_username";
            this.textBox_username.Size = new System.Drawing.Size(100, 20);
            this.textBox_username.TabIndex = 5;
            // 
            // textBox_brRacuna
            // 
            this.textBox_brRacuna.Location = new System.Drawing.Point(0, 3);
            this.textBox_brRacuna.Name = "textBox_brRacuna";
            this.textBox_brRacuna.Size = new System.Drawing.Size(100, 20);
            this.textBox_brRacuna.TabIndex = 4;
            // 
            // prometItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBox_cijena);
            this.Controls.Add(this.textBox_vrijeme);
            this.Controls.Add(this.textBox_username);
            this.Controls.Add(this.textBox_brRacuna);
            this.Name = "prometItem";
            this.Size = new System.Drawing.Size(391, 25);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_cijena;
        private System.Windows.Forms.TextBox textBox_vrijeme;
        private System.Windows.Forms.TextBox textBox_username;
        private System.Windows.Forms.TextBox textBox_brRacuna;
    }
}
