namespace Bases_RM
{
    partial class Trabajadores
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
            this.lblNom = new System.Windows.Forms.Label();
            this.lbSala = new System.Windows.Forms.Label();
            this.lblSucu = new System.Windows.Forms.Label();
            this.TxtNom = new System.Windows.Forms.TextBox();
            this.trabajadoresTree = new System.Windows.Forms.TreeView();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnEC = new System.Windows.Forms.Button();
            this.TxtSala = new System.Windows.Forms.TextBox();
            this.ComboSucu = new System.Windows.Forms.ComboBox();
            this.btnIzq = new System.Windows.Forms.Button();
            this.btnDer = new System.Windows.Forms.Button();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.consultaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.habilitadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deshabilitadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnMG = new System.Windows.Forms.Button();
            this.lblCod = new System.Windows.Forms.Label();
            this.TxtCod = new System.Windows.Forms.TextBox();
            this.grupo1 = new System.Windows.Forms.GroupBox();
            this.Habilitar = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.menuStrip2.SuspendLayout();
            this.grupo1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNom
            // 
            this.lblNom.AutoSize = true;
            this.lblNom.Location = new System.Drawing.Point(12, 16);
            this.lblNom.Name = "lblNom";
            this.lblNom.Size = new System.Drawing.Size(47, 13);
            this.lblNom.TabIndex = 0;
            this.lblNom.Text = "Nombre:";
            // 
            // lbSala
            // 
            this.lbSala.AutoSize = true;
            this.lbSala.Location = new System.Drawing.Point(12, 72);
            this.lbSala.Name = "lbSala";
            this.lbSala.Size = new System.Drawing.Size(42, 13);
            this.lbSala.TabIndex = 1;
            this.lbSala.Text = "Salario:";
            this.lbSala.Click += new System.EventHandler(this.lbSala_Click);
            // 
            // lblSucu
            // 
            this.lblSucu.AutoSize = true;
            this.lblSucu.Location = new System.Drawing.Point(12, 97);
            this.lblSucu.Name = "lblSucu";
            this.lblSucu.Size = new System.Drawing.Size(51, 13);
            this.lblSucu.TabIndex = 2;
            this.lblSucu.Text = "Sucursal:";
            // 
            // TxtNom
            // 
            this.TxtNom.Location = new System.Drawing.Point(69, 15);
            this.TxtNom.Name = "TxtNom";
            this.TxtNom.Size = new System.Drawing.Size(301, 20);
            this.TxtNom.TabIndex = 3;
            this.TxtNom.TextChanged += new System.EventHandler(this.TxtNom_TextChanged);
            // 
            // trabajadoresTree
            // 
            this.trabajadoresTree.Location = new System.Drawing.Point(12, 24);
            this.trabajadoresTree.Name = "trabajadoresTree";
            this.trabajadoresTree.Size = new System.Drawing.Size(183, 270);
            this.trabajadoresTree.TabIndex = 6;
            this.trabajadoresTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.archivoToolStripMenuItem.Text = "&Archivo";
            // 
            // nuevoToolStripMenuItem
            // 
            this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.nuevoToolStripMenuItem.Text = "&Nuevo ";
            // 
            // btnEC
            // 
            this.btnEC.Location = new System.Drawing.Point(474, 271);
            this.btnEC.Name = "btnEC";
            this.btnEC.Size = new System.Drawing.Size(109, 26);
            this.btnEC.TabIndex = 9;
            this.btnEC.Text = "Deshabilitar";
            this.btnEC.UseVisualStyleBackColor = true;
            this.btnEC.Click += new System.EventHandler(this.btnEC_Click);
            // 
            // TxtSala
            // 
            this.TxtSala.Location = new System.Drawing.Point(69, 68);
            this.TxtSala.Name = "TxtSala";
            this.TxtSala.Size = new System.Drawing.Size(100, 20);
            this.TxtSala.TabIndex = 4;
            this.TxtSala.Text = "0.00";
            this.TxtSala.TextChanged += new System.EventHandler(this.TxtSala_TextChanged);
            // 
            // ComboSucu
            // 
            this.ComboSucu.FormattingEnabled = true;
            this.ComboSucu.Location = new System.Drawing.Point(69, 94);
            this.ComboSucu.Name = "ComboSucu";
            this.ComboSucu.Size = new System.Drawing.Size(244, 21);
            this.ComboSucu.TabIndex = 10;
            this.ComboSucu.SelectedIndexChanged += new System.EventHandler(this.ComboSucu_SelectedIndexChanged);
            // 
            // btnIzq
            // 
            this.btnIzq.Location = new System.Drawing.Point(15, 156);
            this.btnIzq.Name = "btnIzq";
            this.btnIzq.Size = new System.Drawing.Size(29, 23);
            this.btnIzq.TabIndex = 11;
            this.btnIzq.Text = "<";
            this.btnIzq.UseVisualStyleBackColor = true;
            this.btnIzq.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnDer
            // 
            this.btnDer.Location = new System.Drawing.Point(50, 156);
            this.btnDer.Name = "btnDer";
            this.btnDer.Size = new System.Drawing.Size(30, 23);
            this.btnDer.TabIndex = 12;
            this.btnDer.Text = ">";
            this.btnDer.UseVisualStyleBackColor = true;
            this.btnDer.Click += new System.EventHandler(this.button4_Click);
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem1});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(630, 24);
            this.menuStrip2.TabIndex = 13;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // archivoToolStripMenuItem1
            // 
            this.archivoToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem1,
            this.consultaToolStripMenuItem});
            this.archivoToolStripMenuItem1.Name = "archivoToolStripMenuItem1";
            this.archivoToolStripMenuItem1.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem1.Text = "&Archivo";
            this.archivoToolStripMenuItem1.Click += new System.EventHandler(this.archivoToolStripMenuItem1_Click);
            // 
            // nuevoToolStripMenuItem1
            // 
            this.nuevoToolStripMenuItem1.Name = "nuevoToolStripMenuItem1";
            this.nuevoToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.nuevoToolStripMenuItem1.Text = "&Nuevo";
            this.nuevoToolStripMenuItem1.Click += new System.EventHandler(this.nuevoToolStripMenuItem1_Click);
            // 
            // consultaToolStripMenuItem
            // 
            this.consultaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.habilitadosToolStripMenuItem,
            this.deshabilitadosToolStripMenuItem});
            this.consultaToolStripMenuItem.Name = "consultaToolStripMenuItem";
            this.consultaToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.consultaToolStripMenuItem.Text = "&Consulta";
            // 
            // habilitadosToolStripMenuItem
            // 
            this.habilitadosToolStripMenuItem.Name = "habilitadosToolStripMenuItem";
            this.habilitadosToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.habilitadosToolStripMenuItem.Text = "&Habilitados";
            this.habilitadosToolStripMenuItem.Click += new System.EventHandler(this.habilitadosToolStripMenuItem_Click);
            // 
            // deshabilitadosToolStripMenuItem
            // 
            this.deshabilitadosToolStripMenuItem.Name = "deshabilitadosToolStripMenuItem";
            this.deshabilitadosToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.deshabilitadosToolStripMenuItem.Text = "&Deshabilitados";
            this.deshabilitadosToolStripMenuItem.Click += new System.EventHandler(this.deshabilitadosToolStripMenuItem_Click);
            // 
            // btnMG
            // 
            this.btnMG.Location = new System.Drawing.Point(364, 271);
            this.btnMG.Name = "btnMG";
            this.btnMG.Size = new System.Drawing.Size(104, 26);
            this.btnMG.TabIndex = 14;
            this.btnMG.Text = "Modificar";
            this.btnMG.UseVisualStyleBackColor = true;
            this.btnMG.Click += new System.EventHandler(this.btnMG_Click);
            // 
            // lblCod
            // 
            this.lblCod.AutoSize = true;
            this.lblCod.Location = new System.Drawing.Point(12, 46);
            this.lblCod.Name = "lblCod";
            this.lblCod.Size = new System.Drawing.Size(43, 13);
            this.lblCod.TabIndex = 15;
            this.lblCod.Text = "Código:";
            this.lblCod.Click += new System.EventHandler(this.label1_Click);
            // 
            // TxtCod
            // 
            this.TxtCod.Location = new System.Drawing.Point(68, 44);
            this.TxtCod.Name = "TxtCod";
            this.TxtCod.Size = new System.Drawing.Size(79, 20);
            this.TxtCod.TabIndex = 16;
            this.TxtCod.TextChanged += new System.EventHandler(this.TxtCod_TextChanged);
            // 
            // grupo1
            // 
            this.grupo1.Controls.Add(this.Habilitar);
            this.grupo1.Controls.Add(this.lblNom);
            this.grupo1.Controls.Add(this.TxtCod);
            this.grupo1.Controls.Add(this.lbSala);
            this.grupo1.Controls.Add(this.lblCod);
            this.grupo1.Controls.Add(this.lblSucu);
            this.grupo1.Controls.Add(this.TxtNom);
            this.grupo1.Controls.Add(this.btnDer);
            this.grupo1.Controls.Add(this.TxtSala);
            this.grupo1.Controls.Add(this.btnIzq);
            this.grupo1.Controls.Add(this.ComboSucu);
            this.grupo1.Location = new System.Drawing.Point(201, 24);
            this.grupo1.Name = "grupo1";
            this.grupo1.Size = new System.Drawing.Size(377, 215);
            this.grupo1.TabIndex = 17;
            this.grupo1.TabStop = false;
            this.grupo1.Enter += new System.EventHandler(this.grupo1_Enter);
            // 
            // Habilitar
            // 
            this.Habilitar.Enabled = false;
            this.Habilitar.Location = new System.Drawing.Point(266, 183);
            this.Habilitar.Name = "Habilitar";
            this.Habilitar.Size = new System.Drawing.Size(104, 26);
            this.Habilitar.TabIndex = 20;
            this.Habilitar.Text = "Habilitar";
            this.Habilitar.UseVisualStyleBackColor = true;
            this.Habilitar.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(229, 271);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(81, 23);
            this.button2.TabIndex = 19;
            this.button2.Text = "Pagos";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Trabajadores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 306);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.grupo1);
            this.Controls.Add(this.btnMG);
            this.Controls.Add(this.btnEC);
            this.Controls.Add(this.trabajadoresTree);
            this.Controls.Add(this.menuStrip2);
            this.Name = "Trabajadores";
            this.Text = "Trabajadores";
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.grupo1.ResumeLayout(false);
            this.grupo1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNom;
        private System.Windows.Forms.Label lbSala;
        private System.Windows.Forms.Label lblSucu;
        private System.Windows.Forms.TextBox TxtNom;
        private System.Windows.Forms.TreeView trabajadoresTree;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
        private System.Windows.Forms.Button btnEC;
        private System.Windows.Forms.TextBox TxtSala;
        private System.Windows.Forms.ComboBox ComboSucu;
        private System.Windows.Forms.Button btnIzq;
        private System.Windows.Forms.Button btnDer;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem1;
        private System.Windows.Forms.Button btnMG;
        private System.Windows.Forms.Label lblCod;
        private System.Windows.Forms.TextBox TxtCod;
        private System.Windows.Forms.ToolStripMenuItem consultaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem habilitadosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deshabilitadosToolStripMenuItem;
        private System.Windows.Forms.GroupBox grupo1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button Habilitar;
    }
}