namespace rp3_caffeBar
{
    partial class HappyHour
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
            this.button_potvrdi = new System.Windows.Forms.Button();
            this.button_odustani = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker_end = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_begin = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_proizvod = new System.Windows.Forms.TextBox();
            this.textBox_trenutnaCijena = new System.Windows.Forms.TextBox();
            this.textBox_hhCijena = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Happy Hour cijena";
            // 
            // button_potvrdi
            // 
            this.button_potvrdi.Location = new System.Drawing.Point(32, 263);
            this.button_potvrdi.Name = "button_potvrdi";
            this.button_potvrdi.Size = new System.Drawing.Size(75, 23);
            this.button_potvrdi.TabIndex = 1;
            this.button_potvrdi.Text = "Potvrdi!";
            this.button_potvrdi.UseVisualStyleBackColor = true;
            this.button_potvrdi.Click += new System.EventHandler(this.button_potvrdi_Click);
            // 
            // button_odustani
            // 
            this.button_odustani.Location = new System.Drawing.Point(164, 263);
            this.button_odustani.Name = "button_odustani";
            this.button_odustani.Size = new System.Drawing.Size(75, 23);
            this.button_odustani.TabIndex = 2;
            this.button_odustani.Text = "Odustani";
            this.button_odustani.UseVisualStyleBackColor = true;
            this.button_odustani.Click += new System.EventHandler(this.button_odustani_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Početak";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 191);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Kraj";
            // 
            // dateTimePicker_end
            // 
            this.dateTimePicker_end.Location = new System.Drawing.Point(121, 185);
            this.dateTimePicker_end.Name = "dateTimePicker_end";
            this.dateTimePicker_end.Size = new System.Drawing.Size(148, 20);
            this.dateTimePicker_end.TabIndex = 5;
            // 
            // dateTimePicker_begin
            // 
            this.dateTimePicker_begin.Location = new System.Drawing.Point(121, 152);
            this.dateTimePicker_begin.Name = "dateTimePicker_begin";
            this.dateTimePicker_begin.Size = new System.Drawing.Size(148, 20);
            this.dateTimePicker_begin.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Proizvod";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Trenutna cijena";
            // 
            // textBox_proizvod
            // 
            this.textBox_proizvod.Location = new System.Drawing.Point(121, 38);
            this.textBox_proizvod.Name = "textBox_proizvod";
            this.textBox_proizvod.Size = new System.Drawing.Size(148, 20);
            this.textBox_proizvod.TabIndex = 9;
            this.textBox_proizvod.TextChanged += new System.EventHandler(this.textBox_proizvod_TextChanged);
            // 
            // textBox_trenutnaCijena
            // 
            this.textBox_trenutnaCijena.Location = new System.Drawing.Point(121, 74);
            this.textBox_trenutnaCijena.Name = "textBox_trenutnaCijena";
            this.textBox_trenutnaCijena.ReadOnly = true;
            this.textBox_trenutnaCijena.Size = new System.Drawing.Size(148, 20);
            this.textBox_trenutnaCijena.TabIndex = 10;
            // 
            // textBox_hhCijena
            // 
            this.textBox_hhCijena.Location = new System.Drawing.Point(121, 114);
            this.textBox_hhCijena.Name = "textBox_hhCijena";
            this.textBox_hhCijena.Size = new System.Drawing.Size(148, 20);
            this.textBox_hhCijena.TabIndex = 11;
            // 
            // HappyHour
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 331);
            this.Controls.Add(this.textBox_hhCijena);
            this.Controls.Add(this.textBox_trenutnaCijena);
            this.Controls.Add(this.textBox_proizvod);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dateTimePicker_begin);
            this.Controls.Add(this.dateTimePicker_end);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_odustani);
            this.Controls.Add(this.button_potvrdi);
            this.Controls.Add(this.label1);
            this.Name = "HappyHour";
            this.Text = "HappyHour";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_potvrdi;
        private System.Windows.Forms.Button button_odustani;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker_end;
        private System.Windows.Forms.DateTimePicker dateTimePicker_begin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_proizvod;
        private System.Windows.Forms.TextBox textBox_trenutnaCijena;
        private System.Windows.Forms.TextBox textBox_hhCijena;
    }
}