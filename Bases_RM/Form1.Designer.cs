namespace Bases_RM
{
    partial class Form1
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
            this.Sucu = new System.Windows.Forms.TextBox();
            this.btnDer = new System.Windows.Forms.Button();
            this.btnIzq = new System.Windows.Forms.Button();
            this.trabajadoresTree = new System.Windows.Forms.TreeView();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.BtnCan = new System.Windows.Forms.Button();
            this.BtnG = new System.Windows.Forms.Button();
            this.TxtSalActu = new System.Windows.Forms.TextBox();
            this.TxtMon = new System.Windows.Forms.TextBox();
            this.TxtSalMes = new System.Windows.Forms.TextBox();
            this.TxtNom = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Sa = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Sucu
            // 
            this.Sucu.Location = new System.Drawing.Point(292, 162);
            this.Sucu.Name = "Sucu";
            this.Sucu.Size = new System.Drawing.Size(193, 20);
            this.Sucu.TabIndex = 38;
            // 
            // btnDer
            // 
            this.btnDer.Location = new System.Drawing.Point(108, 201);
            this.btnDer.Name = "btnDer";
            this.btnDer.Size = new System.Drawing.Size(30, 23);
            this.btnDer.TabIndex = 37;
            this.btnDer.Text = ">";
            this.btnDer.UseVisualStyleBackColor = true;
            // 
            // btnIzq
            // 
            this.btnIzq.Location = new System.Drawing.Point(73, 201);
            this.btnIzq.Name = "btnIzq";
            this.btnIzq.Size = new System.Drawing.Size(29, 23);
            this.btnIzq.TabIndex = 36;
            this.btnIzq.Text = "<";
            this.btnIzq.UseVisualStyleBackColor = true;
            this.btnIzq.Click += new System.EventHandler(this.btnIzq_Click);
            // 
            // trabajadoresTree
            // 
            this.trabajadoresTree.Location = new System.Drawing.Point(12, 12);
            this.trabajadoresTree.Name = "trabajadoresTree";
            this.trabajadoresTree.Size = new System.Drawing.Size(183, 183);
            this.trabajadoresTree.TabIndex = 35;
            this.trabajadoresTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trabajadoresTree_AfterSelect);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(292, 44);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(102, 20);
            this.dateTimePicker1.TabIndex = 34;
            // 
            // BtnCan
            // 
            this.BtnCan.Location = new System.Drawing.Point(588, 164);
            this.BtnCan.Name = "BtnCan";
            this.BtnCan.Size = new System.Drawing.Size(70, 24);
            this.BtnCan.TabIndex = 33;
            this.BtnCan.Text = "Cancelar";
            this.BtnCan.UseVisualStyleBackColor = true;
            // 
            // BtnG
            // 
            this.BtnG.Location = new System.Drawing.Point(512, 164);
            this.BtnG.Name = "BtnG";
            this.BtnG.Size = new System.Drawing.Size(70, 24);
            this.BtnG.TabIndex = 32;
            this.BtnG.Text = "Guardar";
            this.BtnG.UseVisualStyleBackColor = true;
            this.BtnG.Click += new System.EventHandler(this.BtnG_Click);
            // 
            // TxtSalActu
            // 
            this.TxtSalActu.Location = new System.Drawing.Point(292, 136);
            this.TxtSalActu.Name = "TxtSalActu";
            this.TxtSalActu.Size = new System.Drawing.Size(100, 20);
            this.TxtSalActu.TabIndex = 31;
            this.TxtSalActu.Text = "0.00";
            // 
            // TxtMon
            // 
            this.TxtMon.Location = new System.Drawing.Point(292, 106);
            this.TxtMon.Name = "TxtMon";
            this.TxtMon.Size = new System.Drawing.Size(100, 20);
            this.TxtMon.TabIndex = 30;
            this.TxtMon.Text = "0.00";
            // 
            // TxtSalMes
            // 
            this.TxtSalMes.Location = new System.Drawing.Point(292, 75);
            this.TxtSalMes.Name = "TxtSalMes";
            this.TxtSalMes.Size = new System.Drawing.Size(100, 20);
            this.TxtSalMes.TabIndex = 29;
            this.TxtSalMes.Text = "0.00";
            // 
            // TxtNom
            // 
            this.TxtNom.Location = new System.Drawing.Point(292, 12);
            this.TxtNom.Name = "TxtNom";
            this.TxtNom.Size = new System.Drawing.Size(250, 20);
            this.TxtNom.TabIndex = 28;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(212, 167);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "Sucursal:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(212, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Saldo Actual:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(212, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Monto:";
            // 
            // Sa
            // 
            this.Sa.AutoSize = true;
            this.Sa.Location = new System.Drawing.Point(212, 77);
            this.Sa.Name = "Sa";
            this.Sa.Size = new System.Drawing.Size(37, 13);
            this.Sa.TabIndex = 24;
            this.Sa.Text = "Saldo:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(212, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Fecha:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(212, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Nombre:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 231);
            this.Controls.Add(this.Sucu);
            this.Controls.Add(this.btnDer);
            this.Controls.Add(this.btnIzq);
            this.Controls.Add(this.trabajadoresTree);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.BtnCan);
            this.Controls.Add(this.BtnG);
            this.Controls.Add(this.TxtSalActu);
            this.Controls.Add(this.TxtMon);
            this.Controls.Add(this.TxtSalMes);
            this.Controls.Add(this.TxtNom);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Sa);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Sucu;
        private System.Windows.Forms.Button btnDer;
        private System.Windows.Forms.Button btnIzq;
        private System.Windows.Forms.TreeView trabajadoresTree;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button BtnCan;
        private System.Windows.Forms.Button BtnG;
        private System.Windows.Forms.TextBox TxtSalActu;
        private System.Windows.Forms.TextBox TxtMon;
        private System.Windows.Forms.TextBox TxtSalMes;
        private System.Windows.Forms.TextBox TxtNom;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label Sa;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
    }
}