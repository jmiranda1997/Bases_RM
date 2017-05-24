namespace Bases_RM
{
    partial class Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.ptbLogo = new System.Windows.Forms.PictureBox();
            this.btnpedidos = new System.Windows.Forms.Button();
            this.btntrabajadores = new System.Windows.Forms.Button();
            this.btnclientes = new System.Windows.Forms.Button();
            this.btnseguridad = new System.Windows.Forms.Button();
            this.btnsalir = new System.Windows.Forms.Button();
            this.btnactualizarpedidos = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ptbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // ptbLogo
            // 
            this.ptbLogo.Image = ((System.Drawing.Image)(resources.GetObject("ptbLogo.Image")));
            this.ptbLogo.Location = new System.Drawing.Point(12, 12);
            this.ptbLogo.Name = "ptbLogo";
            this.ptbLogo.Size = new System.Drawing.Size(464, 125);
            this.ptbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbLogo.TabIndex = 0;
            this.ptbLogo.TabStop = false;
            // 
            // btnpedidos
            // 
            this.btnpedidos.Enabled = false;
            this.btnpedidos.Location = new System.Drawing.Point(12, 157);
            this.btnpedidos.Name = "btnpedidos";
            this.btnpedidos.Size = new System.Drawing.Size(229, 74);
            this.btnpedidos.TabIndex = 0;
            this.btnpedidos.Text = "Pedidos";
            this.btnpedidos.UseVisualStyleBackColor = true;
            this.btnpedidos.Click += new System.EventHandler(this.button1_Click);
            this.btnpedidos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnpedidos_KeyDown);
            // 
            // btntrabajadores
            // 
            this.btntrabajadores.Enabled = false;
            this.btntrabajadores.Location = new System.Drawing.Point(12, 237);
            this.btntrabajadores.Name = "btntrabajadores";
            this.btntrabajadores.Size = new System.Drawing.Size(229, 74);
            this.btntrabajadores.TabIndex = 2;
            this.btntrabajadores.Text = "Trabajadores";
            this.btntrabajadores.UseVisualStyleBackColor = true;
            this.btntrabajadores.Click += new System.EventHandler(this.btntrabajadores_Click);
            this.btntrabajadores.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btntrabajadores_KeyDown);
            // 
            // btnclientes
            // 
            this.btnclientes.Enabled = false;
            this.btnclientes.Location = new System.Drawing.Point(247, 157);
            this.btnclientes.Name = "btnclientes";
            this.btnclientes.Size = new System.Drawing.Size(229, 74);
            this.btnclientes.TabIndex = 1;
            this.btnclientes.Text = "Clientes";
            this.btnclientes.UseVisualStyleBackColor = true;
            this.btnclientes.Click += new System.EventHandler(this.button3_Click);
            this.btnclientes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnclientes_KeyDown);
            // 
            // btnseguridad
            // 
            this.btnseguridad.Location = new System.Drawing.Point(247, 237);
            this.btnseguridad.Name = "btnseguridad";
            this.btnseguridad.Size = new System.Drawing.Size(229, 74);
            this.btnseguridad.TabIndex = 3;
            this.btnseguridad.Text = "Seguridad";
            this.btnseguridad.UseVisualStyleBackColor = true;
            this.btnseguridad.Click += new System.EventHandler(this.btnseguridad_Click);
            this.btnseguridad.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnseguridad_KeyDown);
            // 
            // btnsalir
            // 
            this.btnsalir.Location = new System.Drawing.Point(12, 317);
            this.btnsalir.Name = "btnsalir";
            this.btnsalir.Size = new System.Drawing.Size(229, 45);
            this.btnsalir.TabIndex = 4;
            this.btnsalir.Text = "Salir";
            this.btnsalir.UseVisualStyleBackColor = true;
            this.btnsalir.Click += new System.EventHandler(this.btnsalir_Click);
            this.btnsalir.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnsalir_KeyDown);
            // 
            // btnactualizarpedidos
            // 
            this.btnactualizarpedidos.Location = new System.Drawing.Point(248, 317);
            this.btnactualizarpedidos.Name = "btnactualizarpedidos";
            this.btnactualizarpedidos.Size = new System.Drawing.Size(228, 45);
            this.btnactualizarpedidos.TabIndex = 5;
            this.btnactualizarpedidos.Text = "Actualizar Pedidos";
            this.btnactualizarpedidos.UseVisualStyleBackColor = true;
            this.btnactualizarpedidos.Click += new System.EventHandler(this.button1_Click_1);
            this.btnactualizarpedidos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnactualizarpedidos_KeyDown);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 382);
            this.Controls.Add(this.btnactualizarpedidos);
            this.Controls.Add(this.btnsalir);
            this.Controls.Add(this.btnseguridad);
            this.Controls.Add(this.btnclientes);
            this.Controls.Add(this.btntrabajadores);
            this.Controls.Add(this.btnpedidos);
            this.Controls.Add(this.ptbLogo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Menu_FormClosed);
            this.Load += new System.EventHandler(this.Menu_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Menu_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.ptbLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox ptbLogo;
        private System.Windows.Forms.Button btnpedidos;
        private System.Windows.Forms.Button btntrabajadores;
        private System.Windows.Forms.Button btnclientes;
        private System.Windows.Forms.Button btnseguridad;
        private System.Windows.Forms.Button btnsalir;
        private System.Windows.Forms.Button btnactualizarpedidos;
    }
}