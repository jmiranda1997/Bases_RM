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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
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
            this.exportarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnMG = new System.Windows.Forms.Button();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNom
            // 
            this.lblNom.AutoSize = true;
            this.lblNom.Location = new System.Drawing.Point(225, 28);
            this.lblNom.Name = "lblNom";
            this.lblNom.Size = new System.Drawing.Size(47, 13);
            this.lblNom.TabIndex = 0;
            this.lblNom.Text = "Nombre:";
            // 
            // lbSala
            // 
            this.lbSala.AutoSize = true;
            this.lbSala.Location = new System.Drawing.Point(225, 62);
            this.lbSala.Name = "lbSala";
            this.lbSala.Size = new System.Drawing.Size(42, 13);
            this.lbSala.TabIndex = 1;
            this.lbSala.Text = "Salario:";
            // 
            // lblSucu
            // 
            this.lblSucu.AutoSize = true;
            this.lblSucu.Location = new System.Drawing.Point(225, 91);
            this.lblSucu.Name = "lblSucu";
            this.lblSucu.Size = new System.Drawing.Size(51, 13);
            this.lblSucu.TabIndex = 2;
            this.lblSucu.Text = "Sucursal:";
            // 
            // TxtNom
            // 
            this.TxtNom.Location = new System.Drawing.Point(282, 27);
            this.TxtNom.Name = "TxtNom";
            this.TxtNom.Size = new System.Drawing.Size(301, 20);
            this.TxtNom.TabIndex = 3;
            this.TxtNom.TextChanged += new System.EventHandler(this.TxtNom_TextChanged);
            // 
            // trabajadoresTree
            // 
            this.trabajadoresTree.Location = new System.Drawing.Point(12, 27);
            this.trabajadoresTree.Name = "trabajadoresTree";
            this.trabajadoresTree.Size = new System.Drawing.Size(183, 270);
            this.trabajadoresTree.TabIndex = 6;
            this.trabajadoresTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 24);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(590, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
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
            this.btnEC.Text = "Eliminar/Cancelar";
            this.btnEC.UseVisualStyleBackColor = true;
            // 
            // TxtSala
            // 
            this.TxtSala.Location = new System.Drawing.Point(282, 59);
            this.TxtSala.Name = "TxtSala";
            this.TxtSala.Size = new System.Drawing.Size(100, 20);
            this.TxtSala.TabIndex = 4;
            this.TxtSala.Text = "0.00";
            this.TxtSala.TextChanged += new System.EventHandler(this.TxtSala_TextChanged);
            // 
            // ComboSucu
            // 
            this.ComboSucu.FormattingEnabled = true;
            this.ComboSucu.Location = new System.Drawing.Point(282, 88);
            this.ComboSucu.Name = "ComboSucu";
            this.ComboSucu.Size = new System.Drawing.Size(121, 21);
            this.ComboSucu.TabIndex = 10;
            this.ComboSucu.SelectedIndexChanged += new System.EventHandler(this.ComboSucu_SelectedIndexChanged);
            // 
            // btnIzq
            // 
            this.btnIzq.Location = new System.Drawing.Point(238, 148);
            this.btnIzq.Name = "btnIzq";
            this.btnIzq.Size = new System.Drawing.Size(29, 23);
            this.btnIzq.TabIndex = 11;
            this.btnIzq.Text = "<";
            this.btnIzq.UseVisualStyleBackColor = true;
            this.btnIzq.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnDer
            // 
            this.btnDer.Location = new System.Drawing.Point(273, 148);
            this.btnDer.Name = "btnDer";
            this.btnDer.Size = new System.Drawing.Size(26, 23);
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
            this.menuStrip2.Size = new System.Drawing.Size(590, 24);
            this.menuStrip2.TabIndex = 13;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // archivoToolStripMenuItem1
            // 
            this.archivoToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem1,
            this.exportarToolStripMenuItem});
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
            // exportarToolStripMenuItem
            // 
            this.exportarToolStripMenuItem.Name = "exportarToolStripMenuItem";
            this.exportarToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exportarToolStripMenuItem.Text = "&Exportar";
            // 
            // btnMG
            // 
            this.btnMG.Location = new System.Drawing.Point(364, 271);
            this.btnMG.Name = "btnMG";
            this.btnMG.Size = new System.Drawing.Size(104, 26);
            this.btnMG.TabIndex = 14;
            this.btnMG.Text = "Modificar/Guardar";
            this.btnMG.UseVisualStyleBackColor = true;
            this.btnMG.Click += new System.EventHandler(this.btnMG_Click);
            // 
            // Trabajadores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 316);
            this.Controls.Add(this.btnMG);
            this.Controls.Add(this.btnDer);
            this.Controls.Add(this.btnIzq);
            this.Controls.Add(this.ComboSucu);
            this.Controls.Add(this.btnEC);
            this.Controls.Add(this.trabajadoresTree);
            this.Controls.Add(this.TxtSala);
            this.Controls.Add(this.TxtNom);
            this.Controls.Add(this.lblSucu);
            this.Controls.Add(this.lbSala);
            this.Controls.Add(this.lblNom);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.menuStrip2);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Trabajadores";
            this.Text = "Trabajadores";
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNom;
        private System.Windows.Forms.Label lbSala;
        private System.Windows.Forms.Label lblSucu;
        private System.Windows.Forms.TextBox TxtNom;
        private System.Windows.Forms.TreeView trabajadoresTree;
        private System.Windows.Forms.MenuStrip menuStrip1;
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
        private System.Windows.Forms.ToolStripMenuItem exportarToolStripMenuItem;
        private System.Windows.Forms.Button btnMG;
    }
}