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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.OrdenesTree = new System.Windows.Forms.TreeView();
            this.FiltComboBx = new System.Windows.Forms.ComboBox();
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
            this.btnMod2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.salirToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1021, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "&Archivo";
            this.archivoToolStripMenuItem.Click += new System.EventHandler(this.archivoToolStripMenuItem_Click);
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
            this.OrdenesTree.Size = new System.Drawing.Size(190, 395);
            this.OrdenesTree.TabIndex = 1;
            this.OrdenesTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.OrdenesTree_AfterSelect);
            this.OrdenesTree.Click += new System.EventHandler(this.archivoToolStripMenuItem_Click);
            this.OrdenesTree.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OrdenesTree_MouseClick);
            // 
            // FiltComboBx
            // 
            this.FiltComboBx.FormattingEnabled = true;
            this.FiltComboBx.Items.AddRange(new object[] {
            "Código Interno",
            "Código Proveedor"});
            this.FiltComboBx.Location = new System.Drawing.Point(40, 428);
            this.FiltComboBx.Name = "FiltComboBx";
            this.FiltComboBx.Size = new System.Drawing.Size(107, 21);
            this.FiltComboBx.TabIndex = 2;
            // 
            // ListaProve
            // 
            this.ListaProve.FormattingEnabled = true;
            this.ListaProve.Location = new System.Drawing.Point(555, 123);
            this.ListaProve.Name = "ListaProve";
            this.ListaProve.Size = new System.Drawing.Size(262, 244);
            this.ListaProve.TabIndex = 4;
            // 
            // lblDescrip
            // 
            this.lblDescrip.AutoSize = true;
            this.lblDescrip.Location = new System.Drawing.Point(230, 44);
            this.lblDescrip.Name = "lblDescrip";
            this.lblDescrip.Size = new System.Drawing.Size(66, 13);
            this.lblDescrip.TabIndex = 5;
            this.lblDescrip.Text = "Descripción:";
            // 
            // lblCI
            // 
            this.lblCI.AutoSize = true;
            this.lblCI.Location = new System.Drawing.Point(230, 73);
            this.lblCI.Name = "lblCI";
            this.lblCI.Size = new System.Drawing.Size(79, 13);
            this.lblCI.TabIndex = 6;
            this.lblCI.Text = "Código Interno:";
            // 
            // lblCF
            // 
            this.lblCF.AutoSize = true;
            this.lblCF.Location = new System.Drawing.Point(230, 102);
            this.lblCF.Name = "lblCF";
            this.lblCF.Size = new System.Drawing.Size(96, 13);
            this.lblCF.TabIndex = 7;
            this.lblCF.Text = "Código Fabricante:";
            // 
            // lblPC
            // 
            this.lblPC.AutoSize = true;
            this.lblPC.Location = new System.Drawing.Point(230, 128);
            this.lblPC.Name = "lblPC";
            this.lblPC.Size = new System.Drawing.Size(70, 13);
            this.lblPC.TabIndex = 8;
            this.lblPC.Text = "Precio Costo:";
            // 
            // lblPV
            // 
            this.lblPV.AutoSize = true;
            this.lblPV.Location = new System.Drawing.Point(230, 154);
            this.lblPV.Name = "lblPV";
            this.lblPV.Size = new System.Drawing.Size(71, 13);
            this.lblPV.TabIndex = 9;
            this.lblPV.Text = "Precio Venta:";
            // 
            // lblmar
            // 
            this.lblmar.AutoSize = true;
            this.lblmar.Location = new System.Drawing.Point(230, 180);
            this.lblmar.Name = "lblmar";
            this.lblmar.Size = new System.Drawing.Size(40, 13);
            this.lblmar.TabIndex = 10;
            this.lblmar.Text = "Marca:";
            // 
            // lblDepa
            // 
            this.lblDepa.AutoSize = true;
            this.lblDepa.Location = new System.Drawing.Point(230, 210);
            this.lblDepa.Name = "lblDepa";
            this.lblDepa.Size = new System.Drawing.Size(77, 13);
            this.lblDepa.TabIndex = 11;
            this.lblDepa.Text = "Departamento:";
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(332, 41);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(367, 20);
            this.txtDesc.TabIndex = 13;
            // 
            // txtCI
            // 
            this.txtCI.Location = new System.Drawing.Point(332, 69);
            this.txtCI.Name = "txtCI";
            this.txtCI.Size = new System.Drawing.Size(103, 20);
            this.txtCI.TabIndex = 14;
            // 
            // txtCF
            // 
            this.txtCF.Location = new System.Drawing.Point(332, 97);
            this.txtCF.Name = "txtCF";
            this.txtCF.Size = new System.Drawing.Size(216, 20);
            this.txtCF.TabIndex = 15;
            // 
            // txtPC
            // 
            this.txtPC.Location = new System.Drawing.Point(332, 123);
            this.txtPC.Name = "txtPC";
            this.txtPC.Size = new System.Drawing.Size(216, 20);
            this.txtPC.TabIndex = 16;
            // 
            // txtPV
            // 
            this.txtPV.Location = new System.Drawing.Point(333, 149);
            this.txtPV.Name = "txtPV";
            this.txtPV.Size = new System.Drawing.Size(216, 20);
            this.txtPV.TabIndex = 17;
            // 
            // txtMar
            // 
            this.txtMar.Location = new System.Drawing.Point(332, 175);
            this.txtMar.Name = "txtMar";
            this.txtMar.Size = new System.Drawing.Size(216, 20);
            this.txtMar.TabIndex = 18;
            // 
            // txtDepar
            // 
            this.txtDepar.Location = new System.Drawing.Point(332, 205);
            this.txtDepar.Name = "txtDepar";
            this.txtDepar.Size = new System.Drawing.Size(216, 20);
            this.txtDepar.TabIndex = 19;
            // 
            // btnMod1
            // 
            this.btnMod1.Location = new System.Drawing.Point(724, 36);
            this.btnMod1.Name = "btnMod1";
            this.btnMod1.Size = new System.Drawing.Size(93, 28);
            this.btnMod1.TabIndex = 21;
            this.btnMod1.Text = "Modificar";
            this.btnMod1.UseVisualStyleBackColor = true;
            this.btnMod1.Click += new System.EventHandler(this.btnMod1_Click);
            // 
            // btnMod2
            // 
            this.btnMod2.Location = new System.Drawing.Point(554, 92);
            this.btnMod2.Name = "btnMod2";
            this.btnMod2.Size = new System.Drawing.Size(93, 28);
            this.btnMod2.TabIndex = 22;
            this.btnMod2.Text = "Modificar";
            this.btnMod2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(263, 342);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 23;
            this.button1.Text = "<";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(344, 342);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 24;
            this.button2.Text = ">";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Ordenes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1021, 461);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnMod2);
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
            this.Controls.Add(this.FiltComboBx);
            this.Controls.Add(this.OrdenesTree);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Ordenes";
            this.Text = "Ordenes";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
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
        private System.Windows.Forms.ComboBox FiltComboBx;
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
        private System.Windows.Forms.Button btnMod2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}