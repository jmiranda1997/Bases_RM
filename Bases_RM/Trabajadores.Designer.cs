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
            this.TxtSucu = new System.Windows.Forms.TextBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.TxtSala = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
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
            // 
            // TxtSucu
            // 
            this.TxtSucu.Location = new System.Drawing.Point(282, 91);
            this.TxtSucu.Name = "TxtSucu";
            this.TxtSucu.Size = new System.Drawing.Size(100, 20);
            this.TxtSucu.TabIndex = 5;
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(12, 28);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(183, 225);
            this.treeView1.TabIndex = 6;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(359, 271);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 26);
            this.button1.TabIndex = 8;
            this.button1.Text = "Modificar/Guardar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(474, 271);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(109, 26);
            this.button2.TabIndex = 9;
            this.button2.Text = "Eliminar/Cancelar";
            this.button2.UseVisualStyleBackColor = true;
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
            // Trabajadores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 316);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.TxtSucu);
            this.Controls.Add(this.TxtSala);
            this.Controls.Add(this.TxtNom);
            this.Controls.Add(this.lblSucu);
            this.Controls.Add(this.lbSala);
            this.Controls.Add(this.lblNom);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Trabajadores";
            this.Text = "Trabajadores";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNom;
        private System.Windows.Forms.Label lbSala;
        private System.Windows.Forms.Label lblSucu;
        private System.Windows.Forms.TextBox TxtNom;
        private System.Windows.Forms.TextBox TxtSucu;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox TxtSala;
    }
}