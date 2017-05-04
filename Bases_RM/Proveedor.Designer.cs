namespace Bases_RM
{
    partial class Proveedor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Proveedor));
            this.btnQContacto = new System.Windows.Forms.Button();
            this.comboPais = new System.Windows.Forms.ComboBox();
            this.btnAContacto = new System.Windows.Forms.Button();
            this.comboContacto = new System.Windows.Forms.ComboBox();
            this.lbPais = new System.Windows.Forms.Label();
            this.lbNproveedor = new System.Windows.Forms.Label();
            this.txtNombreProv = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupProveedor = new System.Windows.Forms.GroupBox();
            this.groupContacto = new System.Windows.Forms.GroupBox();
            this.btnQCorreo = new System.Windows.Forms.Button();
            this.lblNom = new System.Windows.Forms.Label();
            this.TxtNombreContac = new System.Windows.Forms.TextBox();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.comboTelefono = new System.Windows.Forms.ComboBox();
            this.lbCorreo = new System.Windows.Forms.Label();
            this.lbTelefono = new System.Windows.Forms.Label();
            this.btnACorreo = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.treeView = new System.Windows.Forms.TreeView();
            this.groupProveedor.SuspendLayout();
            this.groupContacto.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnQContacto
            // 
            this.btnQContacto.Location = new System.Drawing.Point(205, 74);
            this.btnQContacto.Name = "btnQContacto";
            this.btnQContacto.Size = new System.Drawing.Size(143, 23);
            this.btnQContacto.TabIndex = 28;
            this.btnQContacto.Text = "Quitar";
            this.btnQContacto.UseVisualStyleBackColor = true;
            this.btnQContacto.Click += new System.EventHandler(this.btnQContacto_Click);
            // 
            // comboPais
            // 
            this.comboPais.FormattingEnabled = true;
            this.comboPais.Location = new System.Drawing.Point(66, 103);
            this.comboPais.Name = "comboPais";
            this.comboPais.Size = new System.Drawing.Size(282, 21);
            this.comboPais.TabIndex = 27;
            // 
            // btnAContacto
            // 
            this.btnAContacto.Location = new System.Drawing.Point(66, 74);
            this.btnAContacto.Name = "btnAContacto";
            this.btnAContacto.Size = new System.Drawing.Size(133, 23);
            this.btnAContacto.TabIndex = 26;
            this.btnAContacto.Text = "Agregar";
            this.btnAContacto.UseVisualStyleBackColor = true;
            this.btnAContacto.Click += new System.EventHandler(this.btnAContacto_Click);
            // 
            // comboContacto
            // 
            this.comboContacto.FormattingEnabled = true;
            this.comboContacto.Location = new System.Drawing.Point(66, 47);
            this.comboContacto.Name = "comboContacto";
            this.comboContacto.Size = new System.Drawing.Size(282, 21);
            this.comboContacto.TabIndex = 24;
            // 
            // lbPais
            // 
            this.lbPais.AutoSize = true;
            this.lbPais.Location = new System.Drawing.Point(35, 107);
            this.lbPais.Name = "lbPais";
            this.lbPais.Size = new System.Drawing.Size(30, 13);
            this.lbPais.TabIndex = 25;
            this.lbPais.Text = "Pais:";
            // 
            // lbNproveedor
            // 
            this.lbNproveedor.AutoSize = true;
            this.lbNproveedor.Location = new System.Drawing.Point(18, 23);
            this.lbNproveedor.Name = "lbNproveedor";
            this.lbNproveedor.Size = new System.Drawing.Size(47, 13);
            this.lbNproveedor.TabIndex = 21;
            this.lbNproveedor.Text = "Nombre:";
            // 
            // txtNombreProv
            // 
            this.txtNombreProv.Location = new System.Drawing.Point(66, 21);
            this.txtNombreProv.Name = "txtNombreProv";
            this.txtNombreProv.Size = new System.Drawing.Size(281, 20);
            this.txtNombreProv.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Contactos:";
            // 
            // groupProveedor
            // 
            this.groupProveedor.Controls.Add(this.lbNproveedor);
            this.groupProveedor.Controls.Add(this.label4);
            this.groupProveedor.Controls.Add(this.btnQContacto);
            this.groupProveedor.Controls.Add(this.txtNombreProv);
            this.groupProveedor.Controls.Add(this.comboPais);
            this.groupProveedor.Controls.Add(this.lbPais);
            this.groupProveedor.Controls.Add(this.btnAContacto);
            this.groupProveedor.Controls.Add(this.comboContacto);
            this.groupProveedor.Location = new System.Drawing.Point(193, 12);
            this.groupProveedor.Name = "groupProveedor";
            this.groupProveedor.Size = new System.Drawing.Size(360, 137);
            this.groupProveedor.TabIndex = 29;
            this.groupProveedor.TabStop = false;
            this.groupProveedor.Text = "Nuevo Proveedor";
            // 
            // groupContacto
            // 
            this.groupContacto.Controls.Add(this.btnQCorreo);
            this.groupContacto.Controls.Add(this.lblNom);
            this.groupContacto.Controls.Add(this.TxtNombreContac);
            this.groupContacto.Controls.Add(this.txtCorreo);
            this.groupContacto.Controls.Add(this.comboTelefono);
            this.groupContacto.Controls.Add(this.lbCorreo);
            this.groupContacto.Controls.Add(this.lbTelefono);
            this.groupContacto.Controls.Add(this.btnACorreo);
            this.groupContacto.Location = new System.Drawing.Point(193, 11);
            this.groupContacto.Name = "groupContacto";
            this.groupContacto.Size = new System.Drawing.Size(360, 138);
            this.groupContacto.TabIndex = 0;
            this.groupContacto.TabStop = false;
            this.groupContacto.Text = "Nuevo Contacto";
            // 
            // btnQCorreo
            // 
            this.btnQCorreo.Location = new System.Drawing.Point(206, 104);
            this.btnQCorreo.Name = "btnQCorreo";
            this.btnQCorreo.Size = new System.Drawing.Size(143, 23);
            this.btnQCorreo.TabIndex = 41;
            this.btnQCorreo.Text = "Quitar";
            this.btnQCorreo.UseVisualStyleBackColor = true;
            // 
            // lblNom
            // 
            this.lblNom.AutoSize = true;
            this.lblNom.Location = new System.Drawing.Point(30, 20);
            this.lblNom.Name = "lblNom";
            this.lblNom.Size = new System.Drawing.Size(47, 13);
            this.lblNom.TabIndex = 30;
            this.lblNom.Text = "Nombre:";
            // 
            // TxtNombreContac
            // 
            this.TxtNombreContac.Location = new System.Drawing.Point(78, 17);
            this.TxtNombreContac.Name = "TxtNombreContac";
            this.TxtNombreContac.Size = new System.Drawing.Size(272, 20);
            this.TxtNombreContac.TabIndex = 31;
            // 
            // txtCorreo
            // 
            this.txtCorreo.Location = new System.Drawing.Point(78, 47);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(272, 20);
            this.txtCorreo.TabIndex = 38;
            // 
            // comboTelefono
            // 
            this.comboTelefono.FormattingEnabled = true;
            this.comboTelefono.Location = new System.Drawing.Point(77, 75);
            this.comboTelefono.Name = "comboTelefono";
            this.comboTelefono.Size = new System.Drawing.Size(272, 21);
            this.comboTelefono.TabIndex = 39;
            // 
            // lbCorreo
            // 
            this.lbCorreo.AutoSize = true;
            this.lbCorreo.Location = new System.Drawing.Point(30, 50);
            this.lbCorreo.Name = "lbCorreo";
            this.lbCorreo.Size = new System.Drawing.Size(46, 13);
            this.lbCorreo.TabIndex = 34;
            this.lbCorreo.Text = "Correos:";
            // 
            // lbTelefono
            // 
            this.lbTelefono.AutoSize = true;
            this.lbTelefono.Location = new System.Drawing.Point(24, 80);
            this.lbTelefono.Name = "lbTelefono";
            this.lbTelefono.Size = new System.Drawing.Size(52, 13);
            this.lbTelefono.TabIndex = 35;
            this.lbTelefono.Text = "Telefono:";
            // 
            // btnACorreo
            // 
            this.btnACorreo.Location = new System.Drawing.Point(76, 104);
            this.btnACorreo.Name = "btnACorreo";
            this.btnACorreo.Size = new System.Drawing.Size(123, 23);
            this.btnACorreo.TabIndex = 37;
            this.btnACorreo.Text = "Agregar";
            this.btnACorreo.UseVisualStyleBackColor = true;
            this.btnACorreo.Click += new System.EventHandler(this.btnACorreo_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(193, 155);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(178, 23);
            this.btnCancelar.TabIndex = 42;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(377, 155);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(176, 23);
            this.btnGuardar.TabIndex = 43;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // treeView
            // 
            this.treeView.Location = new System.Drawing.Point(12, 12);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(175, 166);
            this.treeView.TabIndex = 29;
            // 
            // Proveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 189);
            this.Controls.Add(this.treeView);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.groupContacto);
            this.Controls.Add(this.groupProveedor);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Proveedor";
            this.Text = "Proveedor";
            this.Load += new System.EventHandler(this.Proveedor_Load);
            this.groupProveedor.ResumeLayout(false);
            this.groupProveedor.PerformLayout();
            this.groupContacto.ResumeLayout(false);
            this.groupContacto.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnQContacto;
        private System.Windows.Forms.ComboBox comboPais;
        private System.Windows.Forms.Button btnAContacto;
        private System.Windows.Forms.ComboBox comboContacto;
        private System.Windows.Forms.Label lbPais;
        private System.Windows.Forms.Label lbNproveedor;
        private System.Windows.Forms.TextBox txtNombreProv;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupProveedor;
        private System.Windows.Forms.GroupBox groupContacto;
        private System.Windows.Forms.Button btnQCorreo;
        private System.Windows.Forms.Label lblNom;
        private System.Windows.Forms.ComboBox comboTelefono;
        private System.Windows.Forms.TextBox TxtNombreContac;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.Label lbCorreo;
        private System.Windows.Forms.Button btnACorreo;
        private System.Windows.Forms.Label lbTelefono;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TreeView treeView;
    }
}