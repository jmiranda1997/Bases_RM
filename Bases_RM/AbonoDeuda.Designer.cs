namespace Bases_RM
{
    partial class AbonoDeuda
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
            this.lbNom = new System.Windows.Forms.Label();
            this.lbFecha = new System.Windows.Forms.Label();
            this.lbSaldoant = new System.Windows.Forms.Label();
            this.lbMont = new System.Windows.Forms.Label();
            this.lbSaldoactu = new System.Windows.Forms.Label();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.Datetimepic = new System.Windows.Forms.DateTimePicker();
            this.TxtSaldoA = new System.Windows.Forms.TextBox();
            this.TxtMonto = new System.Windows.Forms.TextBox();
            this.TxtSaldoActu = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnguar = new System.Windows.Forms.Button();
            this.lbSucursal = new System.Windows.Forms.Label();
            this.cbSucursales = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lbNom
            // 
            this.lbNom.AutoSize = true;
            this.lbNom.Location = new System.Drawing.Point(12, 21);
            this.lbNom.Name = "lbNom";
            this.lbNom.Size = new System.Drawing.Size(47, 13);
            this.lbNom.TabIndex = 0;
            this.lbNom.Text = "Nombre:";
            // 
            // lbFecha
            // 
            this.lbFecha.AutoSize = true;
            this.lbFecha.Location = new System.Drawing.Point(12, 50);
            this.lbFecha.Name = "lbFecha";
            this.lbFecha.Size = new System.Drawing.Size(40, 13);
            this.lbFecha.TabIndex = 1;
            this.lbFecha.Text = "Fecha:";
            // 
            // lbSaldoant
            // 
            this.lbSaldoant.AutoSize = true;
            this.lbSaldoant.Location = new System.Drawing.Point(12, 74);
            this.lbSaldoant.Name = "lbSaldoant";
            this.lbSaldoant.Size = new System.Drawing.Size(76, 13);
            this.lbSaldoant.TabIndex = 2;
            this.lbSaldoant.Text = "Saldo Anterior:";
            // 
            // lbMont
            // 
            this.lbMont.AutoSize = true;
            this.lbMont.Location = new System.Drawing.Point(12, 103);
            this.lbMont.Name = "lbMont";
            this.lbMont.Size = new System.Drawing.Size(40, 13);
            this.lbMont.TabIndex = 3;
            this.lbMont.Text = "Monto:";
            // 
            // lbSaldoactu
            // 
            this.lbSaldoactu.AutoSize = true;
            this.lbSaldoactu.Location = new System.Drawing.Point(12, 132);
            this.lbSaldoactu.Name = "lbSaldoactu";
            this.lbSaldoactu.Size = new System.Drawing.Size(70, 13);
            this.lbSaldoactu.TabIndex = 4;
            this.lbSaldoactu.Text = "Saldo Actual:";
            // 
            // txtNom
            // 
            this.txtNom.Location = new System.Drawing.Point(94, 18);
            this.txtNom.Name = "txtNom";
            this.txtNom.Size = new System.Drawing.Size(378, 20);
            this.txtNom.TabIndex = 5;
            // 
            // Datetimepic
            // 
            this.Datetimepic.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Datetimepic.Location = new System.Drawing.Point(94, 44);
            this.Datetimepic.Name = "Datetimepic";
            this.Datetimepic.Size = new System.Drawing.Size(105, 20);
            this.Datetimepic.TabIndex = 6;
            // 
            // TxtSaldoA
            // 
            this.TxtSaldoA.Location = new System.Drawing.Point(94, 74);
            this.TxtSaldoA.Name = "TxtSaldoA";
            this.TxtSaldoA.Size = new System.Drawing.Size(100, 20);
            this.TxtSaldoA.TabIndex = 7;
            this.TxtSaldoA.Text = "0.00";
            // 
            // TxtMonto
            // 
            this.TxtMonto.Location = new System.Drawing.Point(94, 103);
            this.TxtMonto.Name = "TxtMonto";
            this.TxtMonto.Size = new System.Drawing.Size(100, 20);
            this.TxtMonto.TabIndex = 8;
            this.TxtMonto.Text = "0.00";
            // 
            // TxtSaldoActu
            // 
            this.TxtSaldoActu.Location = new System.Drawing.Point(94, 132);
            this.TxtSaldoActu.Name = "TxtSaldoActu";
            this.TxtSaldoActu.Size = new System.Drawing.Size(100, 20);
            this.TxtSaldoActu.TabIndex = 9;
            this.TxtSaldoActu.Text = "0.00";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(316, 212);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnguar
            // 
            this.btnguar.Location = new System.Drawing.Point(397, 212);
            this.btnguar.Name = "btnguar";
            this.btnguar.Size = new System.Drawing.Size(75, 23);
            this.btnguar.TabIndex = 11;
            this.btnguar.Text = "Guardar";
            this.btnguar.UseVisualStyleBackColor = true;
            this.btnguar.Click += new System.EventHandler(this.btnguar_Click);
            // 
            // lbSucursal
            // 
            this.lbSucursal.AutoSize = true;
            this.lbSucursal.Location = new System.Drawing.Point(12, 161);
            this.lbSucursal.Name = "lbSucursal";
            this.lbSucursal.Size = new System.Drawing.Size(51, 13);
            this.lbSucursal.TabIndex = 12;
            this.lbSucursal.Text = "Sucursal:";
            // 
            // cbSucursales
            // 
            this.cbSucursales.FormattingEnabled = true;
            this.cbSucursales.Location = new System.Drawing.Point(94, 161);
            this.cbSucursales.Name = "cbSucursales";
            this.cbSucursales.Size = new System.Drawing.Size(127, 21);
            this.cbSucursales.TabIndex = 13;
            // 
            // AbonoDeuda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 247);
            this.Controls.Add(this.cbSucursales);
            this.Controls.Add(this.lbSucursal);
            this.Controls.Add(this.btnguar);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.TxtSaldoActu);
            this.Controls.Add(this.TxtMonto);
            this.Controls.Add(this.TxtSaldoA);
            this.Controls.Add(this.Datetimepic);
            this.Controls.Add(this.txtNom);
            this.Controls.Add(this.lbSaldoactu);
            this.Controls.Add(this.lbMont);
            this.Controls.Add(this.lbSaldoant);
            this.Controls.Add(this.lbFecha);
            this.Controls.Add(this.lbNom);
            this.Name = "AbonoDeuda";
            this.Text = "AbonoDeuda";
            this.Load += new System.EventHandler(this.AbonoDeuda_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbNom;
        private System.Windows.Forms.Label lbFecha;
        private System.Windows.Forms.Label lbSaldoant;
        private System.Windows.Forms.Label lbMont;
        private System.Windows.Forms.Label lbSaldoactu;
        private System.Windows.Forms.TextBox txtNom;
        private System.Windows.Forms.DateTimePicker Datetimepic;
        private System.Windows.Forms.TextBox TxtSaldoA;
        private System.Windows.Forms.TextBox TxtMonto;
        private System.Windows.Forms.TextBox TxtSaldoActu;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnguar;
        private System.Windows.Forms.Label lbSucursal;
        private System.Windows.Forms.ComboBox cbSucursales;
    }
}