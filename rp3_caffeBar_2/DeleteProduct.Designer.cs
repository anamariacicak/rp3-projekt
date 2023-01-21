namespace rp3_caffeBar
{
    partial class DeleteProduct
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
            this.textBox_nazivProizvoda = new System.Windows.Forms.TextBox();
            this.button_delete = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 86);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Naziv proizvoda:";
            // 
            // textBox_nazivProizvoda
            // 
            this.textBox_nazivProizvoda.Location = new System.Drawing.Point(211, 86);
            this.textBox_nazivProizvoda.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_nazivProizvoda.Name = "textBox_nazivProizvoda";
            this.textBox_nazivProizvoda.Size = new System.Drawing.Size(132, 22);
            this.textBox_nazivProizvoda.TabIndex = 1;
            this.textBox_nazivProizvoda.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button_delete
            // 
            this.button_delete.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button_delete.Location = new System.Drawing.Point(56, 171);
            this.button_delete.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(100, 28);
            this.button_delete.TabIndex = 2;
            this.button_delete.Text = "Obriši";
            this.button_delete.UseVisualStyleBackColor = false;
            this.button_delete.Click += new System.EventHandler(this.button_delete_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button_cancel.Location = new System.Drawing.Point(243, 171);
            this.button_cancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(100, 28);
            this.button_cancel.TabIndex = 3;
            this.button_cancel.Text = "Odustani";
            this.button_cancel.UseVisualStyleBackColor = false;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // DeleteProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(393, 238);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_delete);
            this.Controls.Add(this.textBox_nazivProizvoda);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "DeleteProduct";
            this.ShowIcon = false;
            this.Text = "DeleteProduct";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_nazivProizvoda;
        private System.Windows.Forms.Button button_delete;
        private System.Windows.Forms.Button button_cancel;
    }
}