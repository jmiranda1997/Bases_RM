namespace Bases_RM
{
    partial class Pedidos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pedidos));
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnabrir = new System.Windows.Forms.ToolStripMenuItem();
            this.btnimportar = new System.Windows.Forms.ToolStripMenuItem();
            this.btnexportar = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pbprogreso = new System.Windows.Forms.ProgressBar();
            this.lbprogreso = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "&Archivo";
            this.archivoToolStripMenuItem.Click += new System.EventHandler(this.archivoToolStripMenuItem_Click);
            // 
            // btnabrir
            // 
            this.btnabrir.Name = "btnabrir";
            this.btnabrir.Size = new System.Drawing.Size(152, 22);
            this.btnabrir.Click += new System.EventHandler(this.btnabrir_Click);
            // 
            // btnimportar
            // 
            this.btnimportar.Name = "btnimportar";
            this.btnimportar.Size = new System.Drawing.Size(152, 22);
            this.btnimportar.Text = "&Importar";
            this.btnimportar.Click += new System.EventHandler(this.btnimportar_Click);
            // 
            // btnexportar
            // 
            this.btnexportar.Name = "btnexportar";
            this.btnexportar.Size = new System.Drawing.Size(152, 22);
            this.btnexportar.Text = "&Exportar";
            this.btnexportar.Click += new System.EventHandler(this.btnexportar_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.salirToolStripMenuItem.Text = "&Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // listoToolStripMenuItem
            // 
            this.listoToolStripMenuItem.Name = "listoToolStripMenuItem";
            this.listoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.listoToolStripMenuItem.Text = "&Listo";
            this.listoToolStripMenuItem.Click += new System.EventHandler(this.listoToolStripMenuItem_Click);
            // 
            // pbprogreso
            // 
            this.pbprogreso.Location = new System.Drawing.Point(9, 7);
            this.pbprogreso.Name = "pbprogreso";
            this.pbprogreso.Size = new System.Drawing.Size(418, 23);
            this.pbprogreso.TabIndex = 0;
            this.pbprogreso.Click += new System.EventHandler(this.pbprogreso_Click);
            // 
            // lbprogreso
            // 
            this.lbprogreso.AutoSize = true;
            this.lbprogreso.Location = new System.Drawing.Point(195, 38);
            this.lbprogreso.Name = "lbprogreso";
            this.lbprogreso.Size = new System.Drawing.Size(0, 13);
            this.lbprogreso.TabIndex = 1;
            this.lbprogreso.Click += new System.EventHandler(this.label1_Click);
            // 
            // Pedidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 37);
            this.Controls.Add(this.lbprogreso);
            this.Controls.Add(this.pbprogreso);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Pedidos";
            this.Text = "Actualizacion  de Base";
            this.Load += new System.EventHandler(this.Pedidos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnabrir;
        private System.Windows.Forms.ToolStripMenuItem btnimportar;
        private System.Windows.Forms.ToolStripMenuItem btnexportar;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listoToolStripMenuItem;
        private System.Windows.Forms.ProgressBar pbprogreso;
        private System.Windows.Forms.Label lbprogreso;
    }
}