namespace Bases_RM
{
    partial class IngresoClientes
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
            this.lbusu = new System.Windows.Forms.Label();
            this.lbpass = new System.Windows.Forms.Label();
            this.TxtUsu = new System.Windows.Forms.TextBox();
            this.TxtPass = new System.Windows.Forms.TextBox();
            this.GBUsuario = new System.Windows.Forms.GroupBox();
            this.GBCLientes = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.GBPedidos = new System.Windows.Forms.GroupBox();
            this.GBTraba = new System.Windows.Forms.GroupBox();
            this.btnsave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbusu
            // 
            this.lbusu.AutoSize = true;
            this.lbusu.Location = new System.Drawing.Point(207, 20);
            this.lbusu.Name = "lbusu";
            this.lbusu.Size = new System.Drawing.Size(46, 13);
            this.lbusu.TabIndex = 0;
            this.lbusu.Text = "Usuario:";
            // 
            // lbpass
            // 
            this.lbpass.AutoSize = true;
            this.lbpass.Location = new System.Drawing.Point(207, 52);
            this.lbpass.Name = "lbpass";
            this.lbpass.Size = new System.Drawing.Size(56, 13);
            this.lbpass.TabIndex = 1;
            this.lbpass.Text = "Password:";
            // 
            // TxtUsu
            // 
            this.TxtUsu.Location = new System.Drawing.Point(269, 17);
            this.TxtUsu.Name = "TxtUsu";
            this.TxtUsu.Size = new System.Drawing.Size(158, 20);
            this.TxtUsu.TabIndex = 2;
            // 
            // TxtPass
            // 
            this.TxtPass.Location = new System.Drawing.Point(269, 49);
            this.TxtPass.Name = "TxtPass";
            this.TxtPass.Size = new System.Drawing.Size(158, 20);
            this.TxtPass.TabIndex = 3;
            // 
            // GBUsuario
            // 
            this.GBUsuario.Location = new System.Drawing.Point(14, 95);
            this.GBUsuario.Name = "GBUsuario";
            this.GBUsuario.Size = new System.Drawing.Size(139, 224);
            this.GBUsuario.TabIndex = 4;
            this.GBUsuario.TabStop = false;
            this.GBUsuario.Text = "Usuario";
            // 
            // GBCLientes
            // 
            this.GBCLientes.Location = new System.Drawing.Point(168, 95);
            this.GBCLientes.Name = "GBCLientes";
            this.GBCLientes.Size = new System.Drawing.Size(150, 224);
            this.GBCLientes.TabIndex = 5;
            this.GBCLientes.TabStop = false;
            this.GBCLientes.Text = "Clientes";
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(485, 186);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(8, 8);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "groupBox3";
            // 
            // GBPedidos
            // 
            this.GBPedidos.Location = new System.Drawing.Point(347, 95);
            this.GBPedidos.Name = "GBPedidos";
            this.GBPedidos.Size = new System.Drawing.Size(146, 224);
            this.GBPedidos.TabIndex = 6;
            this.GBPedidos.TabStop = false;
            this.GBPedidos.Text = "Pedidos";
            // 
            // GBTraba
            // 
            this.GBTraba.Location = new System.Drawing.Point(527, 95);
            this.GBTraba.Name = "GBTraba";
            this.GBTraba.Size = new System.Drawing.Size(154, 224);
            this.GBTraba.TabIndex = 6;
            this.GBTraba.TabStop = false;
            this.GBTraba.Text = "Trabajadores";
            // 
            // btnsave
            // 
            this.btnsave.Location = new System.Drawing.Point(612, 352);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(69, 25);
            this.btnsave.TabIndex = 7;
            this.btnsave.Text = "Guardar";
            this.btnsave.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(537, 352);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(69, 25);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // IngresoClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 384);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.GBTraba);
            this.Controls.Add(this.GBPedidos);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.GBCLientes);
            this.Controls.Add(this.GBUsuario);
            this.Controls.Add(this.TxtPass);
            this.Controls.Add(this.TxtUsu);
            this.Controls.Add(this.lbpass);
            this.Controls.Add(this.lbusu);
            this.Name = "IngresoClientes";
            this.Text = "IngresoClientes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbusu;
        private System.Windows.Forms.Label lbpass;
        private System.Windows.Forms.TextBox TxtUsu;
        private System.Windows.Forms.TextBox TxtPass;
        private System.Windows.Forms.GroupBox GBUsuario;
        private System.Windows.Forms.GroupBox GBCLientes;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox GBPedidos;
        private System.Windows.Forms.GroupBox GBTraba;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Button btnCancel;
    }
}