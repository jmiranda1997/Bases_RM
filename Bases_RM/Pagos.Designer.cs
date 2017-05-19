namespace Bases_RM
{
    partial class Pagos
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
            this.label3 = new System.Windows.Forms.Label();
            this.Sa = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtNom = new System.Windows.Forms.TextBox();
            this.TxtSalMes = new System.Windows.Forms.TextBox();
            this.TxtMon = new System.Windows.Forms.TextBox();
            this.TxtSalActu = new System.Windows.Forms.TextBox();
            this.TxtSalTot = new System.Windows.Forms.TextBox();
            this.ComboSucu = new System.Windows.Forms.ComboBox();
            this.BtnG = new System.Windows.Forms.Button();
            this.BtnCan = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Fecha:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // Sa
            // 
            this.Sa.AutoSize = true;
            this.Sa.Location = new System.Drawing.Point(12, 80);
            this.Sa.Name = "Sa";
            this.Sa.Size = new System.Drawing.Size(77, 13);
            this.Sa.TabIndex = 3;
            this.Sa.Text = "Saldo del Mes:";
            this.Sa.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Monto:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Saldo Actual:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(278, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Saldo Total:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 170);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Sucursal:";
            // 
            // TxtNom
            // 
            this.TxtNom.Location = new System.Drawing.Point(92, 15);
            this.TxtNom.Name = "TxtNom";
            this.TxtNom.Size = new System.Drawing.Size(250, 20);
            this.TxtNom.TabIndex = 9;
            this.TxtNom.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // TxtSalMes
            // 
            this.TxtSalMes.Location = new System.Drawing.Point(92, 78);
            this.TxtSalMes.Name = "TxtSalMes";
            this.TxtSalMes.Size = new System.Drawing.Size(100, 20);
            this.TxtSalMes.TabIndex = 10;
            this.TxtSalMes.Text = "0.00";
            // 
            // TxtMon
            // 
            this.TxtMon.Location = new System.Drawing.Point(92, 109);
            this.TxtMon.Name = "TxtMon";
            this.TxtMon.Size = new System.Drawing.Size(100, 20);
            this.TxtMon.TabIndex = 11;
            this.TxtMon.Text = "0.00";
            // 
            // TxtSalActu
            // 
            this.TxtSalActu.Location = new System.Drawing.Point(92, 139);
            this.TxtSalActu.Name = "TxtSalActu";
            this.TxtSalActu.Size = new System.Drawing.Size(100, 20);
            this.TxtSalActu.TabIndex = 12;
            this.TxtSalActu.Text = "0.00";
            // 
            // TxtSalTot
            // 
            this.TxtSalTot.Location = new System.Drawing.Point(348, 82);
            this.TxtSalTot.Name = "TxtSalTot";
            this.TxtSalTot.Size = new System.Drawing.Size(100, 20);
            this.TxtSalTot.TabIndex = 13;
            this.TxtSalTot.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // ComboSucu
            // 
            this.ComboSucu.FormattingEnabled = true;
            this.ComboSucu.Location = new System.Drawing.Point(92, 170);
            this.ComboSucu.Name = "ComboSucu";
            this.ComboSucu.Size = new System.Drawing.Size(200, 21);
            this.ComboSucu.TabIndex = 14;
            // 
            // BtnG
            // 
            this.BtnG.Location = new System.Drawing.Point(312, 167);
            this.BtnG.Name = "BtnG";
            this.BtnG.Size = new System.Drawing.Size(70, 24);
            this.BtnG.TabIndex = 15;
            this.BtnG.Text = "Guardar";
            this.BtnG.UseVisualStyleBackColor = true;
            // 
            // BtnCan
            // 
            this.BtnCan.Location = new System.Drawing.Point(388, 167);
            this.BtnCan.Name = "BtnCan";
            this.BtnCan.Size = new System.Drawing.Size(70, 24);
            this.BtnCan.TabIndex = 16;
            this.BtnCan.Text = "Cancelar";
            this.BtnCan.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(92, 47);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(102, 20);
            this.dateTimePicker1.TabIndex = 17;
            // 
            // Pagos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 205);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.BtnCan);
            this.Controls.Add(this.BtnG);
            this.Controls.Add(this.ComboSucu);
            this.Controls.Add(this.TxtSalTot);
            this.Controls.Add(this.TxtSalActu);
            this.Controls.Add(this.TxtMon);
            this.Controls.Add(this.TxtSalMes);
            this.Controls.Add(this.TxtNom);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Sa);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "Pagos";
            this.Text = "Pagos";
            this.Load += new System.EventHandler(this.Pagos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label Sa;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TxtNom;
        private System.Windows.Forms.TextBox TxtSalMes;
        private System.Windows.Forms.TextBox TxtMon;
        private System.Windows.Forms.TextBox TxtSalActu;
        private System.Windows.Forms.TextBox TxtSalTot;
        private System.Windows.Forms.ComboBox ComboSucu;
        private System.Windows.Forms.Button BtnG;
        private System.Windows.Forms.Button BtnCan;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}