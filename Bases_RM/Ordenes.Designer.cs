namespace Bases_RM
{
    partial class Ordenes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ordenes));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoPedidoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirPedidoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarPedidoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pedidosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pedidoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.marcarComoFinalizadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.marcarComoNoFinalizadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enviarCorreosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportarPedidoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.OrdenesTree = new System.Windows.Forms.TreeView();
            this.ListaProve = new System.Windows.Forms.CheckedListBox();
            this.lblDescrip = new System.Windows.Forms.Label();
            this.lblCI = new System.Windows.Forms.Label();
            this.lblCF = new System.Windows.Forms.Label();
            this.lblPC = new System.Windows.Forms.Label();
            this.lblPV = new System.Windows.Forms.Label();
            this.lblmar = new System.Windows.Forms.Label();
            this.lblDepa = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.txtCI = new System.Windows.Forms.TextBox();
            this.txtCF = new System.Windows.Forms.TextBox();
            this.txtPC = new System.Windows.Forms.TextBox();
            this.txtPV = new System.Windows.Forms.TextBox();
            this.txtMar = new System.Windows.Forms.TextBox();
            this.txtDepar = new System.Windows.Forms.TextBox();
            this.btnMod1 = new System.Windows.Forms.Button();
            this.btnPedir = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.lbexistencias = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.txtexistencias = new System.Windows.Forms.TextBox();
            this.btnAcutalizar = new System.Windows.Forms.Button();
            this.lbEstado = new System.Windows.Forms.Label();
            this.lbPrecio = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtComentario = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.pedidoToolStripMenuItem,
            this.salirToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(781, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            this.menuStrip1.Click += new System.EventHandler(this.menuStrip1_Click);
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoPedidoToolStripMenuItem,
            this.abrirPedidoToolStripMenuItem,
            this.cerrarPedidoToolStripMenuItem,
            this.pedidosToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "&Archivo";
            this.archivoToolStripMenuItem.Click += new System.EventHandler(this.archivoToolStripMenuItem_Click);
            // 
            // nuevoPedidoToolStripMenuItem
            // 
            this.nuevoPedidoToolStripMenuItem.Name = "nuevoPedidoToolStripMenuItem";
            this.nuevoPedidoToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.nuevoPedidoToolStripMenuItem.Text = "&Nuevo Pedido";
            this.nuevoPedidoToolStripMenuItem.Click += new System.EventHandler(this.nuevoPedidoToolStripMenuItem_Click);
            // 
            // abrirPedidoToolStripMenuItem
            // 
            this.abrirPedidoToolStripMenuItem.Name = "abrirPedidoToolStripMenuItem";
            this.abrirPedidoToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.abrirPedidoToolStripMenuItem.Text = "&Abrir Pedido";
            this.abrirPedidoToolStripMenuItem.Click += new System.EventHandler(this.abrirPedidoToolStripMenuItem_Click);
            // 
            // cerrarPedidoToolStripMenuItem
            // 
            this.cerrarPedidoToolStripMenuItem.Enabled = false;
            this.cerrarPedidoToolStripMenuItem.Name = "cerrarPedidoToolStripMenuItem";
            this.cerrarPedidoToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.cerrarPedidoToolStripMenuItem.Text = "&Cerrar Pedido";
            this.cerrarPedidoToolStripMenuItem.Click += new System.EventHandler(this.cerrarPedidoToolStripMenuItem_Click);
            // 
            // pedidosToolStripMenuItem
            // 
            this.pedidosToolStripMenuItem.Name = "pedidosToolStripMenuItem";
            this.pedidosToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.pedidosToolStripMenuItem.Text = "&Proveedores";
            this.pedidosToolStripMenuItem.Click += new System.EventHandler(this.pedidosToolStripMenuItem_Click);
            // 
            // pedidoToolStripMenuItem
            // 
            this.pedidoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.marcarComoFinalizadoToolStripMenuItem,
            this.marcarComoNoFinalizadoToolStripMenuItem,
            this.enviarCorreosToolStripMenuItem,
            this.exportarPedidoToolStripMenuItem});
            this.pedidoToolStripMenuItem.Name = "pedidoToolStripMenuItem";
            this.pedidoToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.pedidoToolStripMenuItem.Text = "&Pedido";
            this.pedidoToolStripMenuItem.Click += new System.EventHandler(this.pedidoToolStripMenuItem_Click);
            // 
            // marcarComoFinalizadoToolStripMenuItem
            // 
            this.marcarComoFinalizadoToolStripMenuItem.Enabled = false;
            this.marcarComoFinalizadoToolStripMenuItem.Name = "marcarComoFinalizadoToolStripMenuItem";
            this.marcarComoFinalizadoToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.marcarComoFinalizadoToolStripMenuItem.Text = "&Marcar como Finalizado";
            this.marcarComoFinalizadoToolStripMenuItem.Click += new System.EventHandler(this.marcarComoFinalizadoToolStripMenuItem_Click);
            // 
            // marcarComoNoFinalizadoToolStripMenuItem
            // 
            this.marcarComoNoFinalizadoToolStripMenuItem.Enabled = false;
            this.marcarComoNoFinalizadoToolStripMenuItem.Name = "marcarComoNoFinalizadoToolStripMenuItem";
            this.marcarComoNoFinalizadoToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.marcarComoNoFinalizadoToolStripMenuItem.Text = "Marcar como &No Finalizado ";
            this.marcarComoNoFinalizadoToolStripMenuItem.Click += new System.EventHandler(this.marcarComoNoFinalizadoToolStripMenuItem_Click);
            // 
            // enviarCorreosToolStripMenuItem
            // 
            this.enviarCorreosToolStripMenuItem.Name = "enviarCorreosToolStripMenuItem";
            this.enviarCorreosToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.enviarCorreosToolStripMenuItem.Text = "&Enviar Correos";
            // 
            // exportarPedidoToolStripMenuItem
            // 
            this.exportarPedidoToolStripMenuItem.Name = "exportarPedidoToolStripMenuItem";
            this.exportarPedidoToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.exportarPedidoToolStripMenuItem.Text = "E&xportar Pedido";
            // 
            // salirToolStripMenuItem1
            // 
            this.salirToolStripMenuItem1.Name = "salirToolStripMenuItem1";
            this.salirToolStripMenuItem1.Size = new System.Drawing.Size(41, 20);
            this.salirToolStripMenuItem1.Text = "&Salir";
            this.salirToolStripMenuItem1.Click += new System.EventHandler(this.salirToolStripMenuItem1_Click);
            // 
            // OrdenesTree
            // 
            this.OrdenesTree.Location = new System.Drawing.Point(12, 26);
            this.OrdenesTree.Name = "OrdenesTree";
            this.OrdenesTree.Size = new System.Drawing.Size(190, 444);
            this.OrdenesTree.TabIndex = 1;
            this.OrdenesTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.OrdenesTree_AfterSelect);
            this.OrdenesTree.Click += new System.EventHandler(this.archivoToolStripMenuItem_Click);
            this.OrdenesTree.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OrdenesTree_MouseClick);
            // 
            // ListaProve
            // 
            this.ListaProve.FormattingEnabled = true;
            this.ListaProve.Location = new System.Drawing.Point(542, 65);
            this.ListaProve.Name = "ListaProve";
            this.ListaProve.Size = new System.Drawing.Size(212, 379);
            this.ListaProve.TabIndex = 4;
            this.ListaProve.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ListaProve_ItemCheck);
            this.ListaProve.Click += new System.EventHandler(this.ListaProve_Click);
            this.ListaProve.SelectedIndexChanged += new System.EventHandler(this.ListaProve_SelectedIndexChanged);
            this.ListaProve.DoubleClick += new System.EventHandler(this.ListaProve_DoubleClick);
            // 
            // lblDescrip
            // 
            this.lblDescrip.AutoSize = true;
            this.lblDescrip.Location = new System.Drawing.Point(245, 42);
            this.lblDescrip.Name = "lblDescrip";
            this.lblDescrip.Size = new System.Drawing.Size(66, 13);
            this.lblDescrip.TabIndex = 5;
            this.lblDescrip.Text = "Descripción:";
            // 
            // lblCI
            // 
            this.lblCI.AutoSize = true;
            this.lblCI.Location = new System.Drawing.Point(227, 71);
            this.lblCI.Name = "lblCI";
            this.lblCI.Size = new System.Drawing.Size(79, 13);
            this.lblCI.TabIndex = 6;
            this.lblCI.Text = "Código Interno:";
            // 
            // lblCF
            // 
            this.lblCF.AutoSize = true;
            this.lblCF.Location = new System.Drawing.Point(215, 98);
            this.lblCF.Name = "lblCF";
            this.lblCF.Size = new System.Drawing.Size(96, 13);
            this.lblCF.TabIndex = 7;
            this.lblCF.Text = "Código Fabricante:";
            // 
            // lblPC
            // 
            this.lblPC.AutoSize = true;
            this.lblPC.Location = new System.Drawing.Point(241, 124);
            this.lblPC.Name = "lblPC";
            this.lblPC.Size = new System.Drawing.Size(70, 13);
            this.lblPC.TabIndex = 8;
            this.lblPC.Text = "Precio Costo:";
            // 
            // lblPV
            // 
            this.lblPV.AutoSize = true;
            this.lblPV.Location = new System.Drawing.Point(240, 154);
            this.lblPV.Name = "lblPV";
            this.lblPV.Size = new System.Drawing.Size(71, 13);
            this.lblPV.TabIndex = 9;
            this.lblPV.Text = "Precio Venta:";
            // 
            // lblmar
            // 
            this.lblmar.AutoSize = true;
            this.lblmar.Location = new System.Drawing.Point(271, 180);
            this.lblmar.Name = "lblmar";
            this.lblmar.Size = new System.Drawing.Size(40, 13);
            this.lblmar.TabIndex = 10;
            this.lblmar.Text = "Marca:";
            // 
            // lblDepa
            // 
            this.lblDepa.AutoSize = true;
            this.lblDepa.Location = new System.Drawing.Point(234, 206);
            this.lblDepa.Name = "lblDepa";
            this.lblDepa.Size = new System.Drawing.Size(77, 13);
            this.lblDepa.TabIndex = 11;
            this.lblDepa.Text = "Departamento:";
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(312, 39);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(442, 20);
            this.txtDesc.TabIndex = 13;
            this.txtDesc.TextChanged += new System.EventHandler(this.txtDesc_TextChanged);
            // 
            // txtCI
            // 
            this.txtCI.Location = new System.Drawing.Point(312, 67);
            this.txtCI.Name = "txtCI";
            this.txtCI.Size = new System.Drawing.Size(224, 20);
            this.txtCI.TabIndex = 14;
            // 
            // txtCF
            // 
            this.txtCF.Location = new System.Drawing.Point(312, 95);
            this.txtCF.Name = "txtCF";
            this.txtCF.Size = new System.Drawing.Size(224, 20);
            this.txtCF.TabIndex = 15;
            // 
            // txtPC
            // 
            this.txtPC.Location = new System.Drawing.Point(312, 121);
            this.txtPC.Name = "txtPC";
            this.txtPC.Size = new System.Drawing.Size(224, 20);
            this.txtPC.TabIndex = 16;
            // 
            // txtPV
            // 
            this.txtPV.Location = new System.Drawing.Point(313, 147);
            this.txtPV.Name = "txtPV";
            this.txtPV.Size = new System.Drawing.Size(223, 20);
            this.txtPV.TabIndex = 17;
            // 
            // txtMar
            // 
            this.txtMar.Location = new System.Drawing.Point(312, 173);
            this.txtMar.Name = "txtMar";
            this.txtMar.Size = new System.Drawing.Size(224, 20);
            this.txtMar.TabIndex = 18;
            // 
            // txtDepar
            // 
            this.txtDepar.Location = new System.Drawing.Point(312, 203);
            this.txtDepar.Name = "txtDepar";
            this.txtDepar.Size = new System.Drawing.Size(224, 20);
            this.txtDepar.TabIndex = 19;
            // 
            // btnMod1
            // 
            this.btnMod1.Location = new System.Drawing.Point(213, 268);
            this.btnMod1.Name = "btnMod1";
            this.btnMod1.Size = new System.Drawing.Size(324, 28);
            this.btnMod1.TabIndex = 21;
            this.btnMod1.Text = "Modificar Codigo";
            this.btnMod1.UseVisualStyleBackColor = true;
            this.btnMod1.Click += new System.EventHandler(this.btnMod1_Click);
            // 
            // btnPedir
            // 
            this.btnPedir.Enabled = false;
            this.btnPedir.Location = new System.Drawing.Point(213, 413);
            this.btnPedir.Name = "btnPedir";
            this.btnPedir.Size = new System.Drawing.Size(323, 28);
            this.btnPedir.TabIndex = 22;
            this.btnPedir.Text = "Pedir / Actualizar";
            this.btnPedir.UseVisualStyleBackColor = true;
            this.btnPedir.Click += new System.EventHandler(this.btnPedir_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(213, 447);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(161, 23);
            this.button1.TabIndex = 23;
            this.button1.Text = "<";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(380, 447);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(156, 23);
            this.button2.TabIndex = 24;
            this.button2.Text = ">";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lbexistencias
            // 
            this.lbexistencias.AutoSize = true;
            this.lbexistencias.Location = new System.Drawing.Point(245, 238);
            this.lbexistencias.Name = "lbexistencias";
            this.lbexistencias.Size = new System.Drawing.Size(66, 13);
            this.lbexistencias.TabIndex = 25;
            this.lbexistencias.Text = "Existencias: ";
            this.lbexistencias.Click += new System.EventHandler(this.label1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(259, 309);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "Cantidad:";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // txtCantidad
            // 
            this.txtCantidad.Enabled = false;
            this.txtCantidad.Location = new System.Drawing.Point(312, 306);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(225, 20);
            this.txtCantidad.TabIndex = 30;
            this.txtCantidad.Text = "0";
            this.txtCantidad.TextChanged += new System.EventHandler(this.txtCantidad_TextChanged);
            this.txtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
            // 
            // txtexistencias
            // 
            this.txtexistencias.Enabled = false;
            this.txtexistencias.Location = new System.Drawing.Point(313, 235);
            this.txtexistencias.Name = "txtexistencias";
            this.txtexistencias.Size = new System.Drawing.Size(224, 20);
            this.txtexistencias.TabIndex = 32;
            // 
            // btnAcutalizar
            // 
            this.btnAcutalizar.Location = new System.Drawing.Point(542, 447);
            this.btnAcutalizar.Name = "btnAcutalizar";
            this.btnAcutalizar.Size = new System.Drawing.Size(212, 23);
            this.btnAcutalizar.TabIndex = 33;
            this.btnAcutalizar.Text = "Atualizar Proveedores";
            this.btnAcutalizar.UseVisualStyleBackColor = true;
            this.btnAcutalizar.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // lbEstado
            // 
            this.lbEstado.AutoSize = true;
            this.lbEstado.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbEstado.Location = new System.Drawing.Point(704, 42);
            this.lbEstado.Name = "lbEstado";
            this.lbEstado.Size = new System.Drawing.Size(0, 13);
            this.lbEstado.TabIndex = 34;
            this.lbEstado.Visible = false;
            this.lbEstado.Click += new System.EventHandler(this.lbEstado_Click);
            // 
            // lbPrecio
            // 
            this.lbPrecio.AutoSize = true;
            this.lbPrecio.Location = new System.Drawing.Point(271, 335);
            this.lbPrecio.Name = "lbPrecio";
            this.lbPrecio.Size = new System.Drawing.Size(40, 13);
            this.lbPrecio.TabIndex = 35;
            this.lbPrecio.Text = "Precio:";
            // 
            // txtPrecio
            // 
            this.txtPrecio.Enabled = false;
            this.txtPrecio.Location = new System.Drawing.Point(312, 332);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(224, 20);
            this.txtPrecio.TabIndex = 36;
            this.txtPrecio.Text = "0.00";
            this.txtPrecio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecio_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(248, 361);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 37;
            this.label2.Text = "Comentario:";
            // 
            // txtComentario
            // 
            this.txtComentario.Location = new System.Drawing.Point(312, 358);
            this.txtComentario.Multiline = true;
            this.txtComentario.Name = "txtComentario";
            this.txtComentario.Size = new System.Drawing.Size(225, 49);
            this.txtComentario.TabIndex = 38;
            this.txtComentario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtComentario_KeyPress);
            // 
            // Ordenes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 485);
            this.Controls.Add(this.txtComentario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.lbPrecio);
            this.Controls.Add(this.lbEstado);
            this.Controls.Add(this.btnAcutalizar);
            this.Controls.Add(this.txtexistencias);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbexistencias);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnPedir);
            this.Controls.Add(this.btnMod1);
            this.Controls.Add(this.txtDepar);
            this.Controls.Add(this.txtMar);
            this.Controls.Add(this.txtPV);
            this.Controls.Add(this.txtPC);
            this.Controls.Add(this.txtCF);
            this.Controls.Add(this.txtCI);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.lblDepa);
            this.Controls.Add(this.lblmar);
            this.Controls.Add(this.lblPV);
            this.Controls.Add(this.lblPC);
            this.Controls.Add(this.lblCF);
            this.Controls.Add(this.lblCI);
            this.Controls.Add(this.lblDescrip);
            this.Controls.Add(this.ListaProve);
            this.Controls.Add(this.OrdenesTree);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Ordenes";
            this.Text = "Ordenes";
            this.Load += new System.EventHandler(this.Ordenes_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.TreeView OrdenesTree;
        private System.Windows.Forms.CheckedListBox ListaProve;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem1;
        private System.Windows.Forms.Label lblDescrip;
        private System.Windows.Forms.Label lblCI;
        private System.Windows.Forms.Label lblCF;
        private System.Windows.Forms.Label lblPC;
        private System.Windows.Forms.Label lblPV;
        private System.Windows.Forms.Label lblmar;
        private System.Windows.Forms.Label lblDepa;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.TextBox txtCI;
        private System.Windows.Forms.TextBox txtCF;
        private System.Windows.Forms.TextBox txtPC;
        private System.Windows.Forms.TextBox txtPV;
        private System.Windows.Forms.TextBox txtMar;
        private System.Windows.Forms.TextBox txtDepar;
        private System.Windows.Forms.Button btnMod1;
        private System.Windows.Forms.Button btnPedir;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lbexistencias;
        private System.Windows.Forms.ToolStripMenuItem nuevoPedidoToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.TextBox txtexistencias;
        private System.Windows.Forms.Button btnAcutalizar;
        private System.Windows.Forms.ToolStripMenuItem pedidoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem marcarComoFinalizadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem marcarComoNoFinalizadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarPedidoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enviarCorreosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportarPedidoToolStripMenuItem;
        private System.Windows.Forms.Label lbEstado;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem abrirPedidoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pedidosToolStripMenuItem;
        private System.Windows.Forms.Label lbPrecio;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtComentario;
    }
}