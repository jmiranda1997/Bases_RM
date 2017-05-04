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
            this.txtApe = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.txtSaldoT = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbNom
            // 
            this.lbNom.AutoSize = true;
            this.lbNom.Location = new System.Drawing.Point(12, 21);
            this.lbNom.Name = "lbNom";
            this.lbNom.Size = new System.Drawing.Size(52, 13);
            this.lbNom.TabIndex = 0;
            this.lbNom.Text = "Nombres:";
            // 
            // lbFecha
            // 
            this.lbFecha.AutoSize = true;
            this.lbFecha.Location = new System.Drawing.Point(12, 85);
            this.lbFecha.Name = "lbFecha";
            this.lbFecha.Size = new System.Drawing.Size(40, 13);
            this.lbFecha.TabIndex = 1;
            this.lbFecha.Text = "Fecha:";
            // 
            // lbSaldoant
            // 
            this.lbSaldoant.AutoSize = true;
            this.lbSaldoant.Location = new System.Drawing.Point(12, 109);
            this.lbSaldoant.Name = "lbSaldoant";
            this.lbSaldoant.Size = new System.Drawing.Size(77, 13);
            this.lbSaldoant.TabIndex = 2;
            this.lbSaldoant.Text = "Saldo del Mes:";
            this.lbSaldoant.Click += new System.EventHandler(this.lbSaldoant_Click);
            // 
            // lbMont
            // 
            this.lbMont.AutoSize = true;
            this.lbMont.Location = new System.Drawing.Point(12, 138);
            this.lbMont.Name = "lbMont";
            this.lbMont.Size = new System.Drawing.Size(40, 13);
            this.lbMont.TabIndex = 3;
            this.lbMont.Text = "Monto:";
            // 
            // lbSaldoactu
            // 
            this.lbSaldoactu.AutoSize = true;
            this.lbSaldoactu.Location = new System.Drawing.Point(12, 164);
            this.lbSaldoactu.Name = "lbSaldoactu";
            this.lbSaldoactu.Size = new System.Drawing.Size(70, 13);
            this.lbSaldoactu.TabIndex = 4;
            this.lbSaldoactu.Text = "Saldo Actual:";
            // 
            // txtNom
            // 
            this.txtNom.Enabled = false;
            this.txtNom.Location = new System.Drawing.Point(94, 18);
            this.txtNom.Name = "txtNom";
            this.txtNom.Size = new System.Drawing.Size(238, 20);
            this.txtNom.TabIndex = 5;

            //this.txtNom.TextChanged += new System.EventHandler(this.txtNom_TextChanged);

            // 
            // Datetimepic
            // 
            this.Datetimepic.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Datetimepic.Location = new System.Drawing.Point(94, 79);
            this.Datetimepic.Name = "Datetimepic";
            this.Datetimepic.Size = new System.Drawing.Size(105, 20);
            this.Datetimepic.TabIndex = 6;
            // 
            // TxtSaldoA
            // 
            this.TxtSaldoA.Enabled = false;
            this.TxtSaldoA.Location = new System.Drawing.Point(95, 106);
            this.TxtSaldoA.Name = "TxtSaldoA";
            this.TxtSaldoA.Size = new System.Drawing.Size(105, 20);
            this.TxtSaldoA.TabIndex = 7;
            this.TxtSaldoA.Text = "0.00";
            this.TxtSaldoA.TextChanged += new System.EventHandler(this.TxtSaldoA_TextChanged);
            // 
            // TxtMonto
            // 
            this.TxtMonto.Location = new System.Drawing.Point(95, 135);
            this.TxtMonto.Name = "TxtMonto";
            this.TxtMonto.Size = new System.Drawing.Size(105, 20);
            this.TxtMonto.TabIndex = 8;
            this.TxtMonto.Text = "0.00";
            this.TxtMonto.TextChanged += new System.EventHandler(this.TxtMonto_TextChanged);
            this.TxtMonto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtMonto_KeyPress);
            this.TxtMonto.Leave += new System.EventHandler(this.TxtMonto_Leave);
            // 
            // TxtSaldoActu
            // 
            this.TxtSaldoActu.Enabled = false;
            this.TxtSaldoActu.Location = new System.Drawing.Point(95, 161);
            this.TxtSaldoActu.Name = "TxtSaldoActu";
            this.TxtSaldoActu.Size = new System.Drawing.Size(105, 20);
            this.TxtSaldoActu.TabIndex = 9;
            this.TxtSaldoActu.Text = "0.00";
            this.TxtSaldoActu.TextChanged += new System.EventHandler(this.TxtSaldoActu_TextChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(395, 152);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnguar
            // 
            this.btnguar.Location = new System.Drawing.Point(314, 152);
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
            this.lbSucursal.Location = new System.Drawing.Point(244, 109);
            this.lbSucursal.Name = "lbSucursal";
            this.lbSucursal.Size = new System.Drawing.Size(51, 13);
            this.lbSucursal.TabIndex = 12;
            this.lbSucursal.Text = "Sucursal:";
            // 
            // cbSucursales
            // 
            this.cbSucursales.FormattingEnabled = true;
            this.cbSucursales.Location = new System.Drawing.Point(314, 106);
            this.cbSucursales.Name = "cbSucursales";
            this.cbSucursales.Size = new System.Drawing.Size(154, 21);
            this.cbSucursales.TabIndex = 13;
            this.cbSucursales.SelectedIndexChanged += new System.EventHandler(this.cbSucursales_SelectedIndexChanged);
            // 
            // txtApe
            // 
            this.txtApe.Enabled = false;
            this.txtApe.Location = new System.Drawing.Point(94, 44);
            this.txtApe.Name = "txtApe";
            this.txtApe.Size = new System.Drawing.Size(238, 20);
            this.txtApe.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Apellidos";
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(12, 217);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 13);
            this.lblError.TabIndex = 16;
            // 
            // txtSaldoT
            // 
            this.txtSaldoT.Enabled = false;
            this.txtSaldoT.Location = new System.Drawing.Point(314, 82);
            this.txtSaldoT.Name = "txtSaldoT";
            this.txtSaldoT.Size = new System.Drawing.Size(105, 20);
            this.txtSaldoT.TabIndex = 18;
            this.txtSaldoT.Text = "0.00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(244, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Saldo Total:";
            // 
            // AbonoDeuda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 239);
            this.Controls.Add(this.txtSaldoT);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.txtApe);
            this.Controls.Add(this.label1);
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
        private System.Windows.Forms.TextBox txtApe;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.TextBox txtSaldoT;
        private System.Windows.Forms.Label label2;
    }
}