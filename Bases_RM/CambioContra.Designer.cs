namespace Bases_RM
{
    partial class lblRI
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
            this.lblCN = new System.Windows.Forms.Label();
            this.lblCC = new System.Windows.Forms.Label();
            this.txtCN = new System.Windows.Forms.TextBox();
            this.txtCCN = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblCN
            // 
            this.lblCN.AutoSize = true;
            this.lblCN.Location = new System.Drawing.Point(22, 19);
            this.lblCN.Name = "lblCN";
            this.lblCN.Size = new System.Drawing.Size(102, 13);
            this.lblCN.TabIndex = 1;
            this.lblCN.Text = "Contraseña Nueva :";
            // 
            // lblCC
            // 
            this.lblCC.AutoSize = true;
            this.lblCC.Location = new System.Drawing.Point(22, 52);
            this.lblCC.Name = "lblCC";
            this.lblCC.Size = new System.Drawing.Size(151, 13);
            this.lblCC.TabIndex = 2;
            this.lblCC.Text = "Confirme la nueva contraseña:";
            this.lblCC.Click += new System.EventHandler(this.lblCC_Click);
            // 
            // txtCN
            // 
            this.txtCN.Location = new System.Drawing.Point(130, 16);
            this.txtCN.Name = "txtCN";
            this.txtCN.Size = new System.Drawing.Size(206, 20);
            this.txtCN.TabIndex = 4;
            // 
            // txtCCN
            // 
            this.txtCCN.Location = new System.Drawing.Point(172, 49);
            this.txtCCN.Name = "txtCCN";
            this.txtCCN.Size = new System.Drawing.Size(164, 20);
            this.txtCCN.TabIndex = 5;
            this.txtCCN.TextChanged += new System.EventHandler(this.txtCCN_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(186, 105);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Confirmar nueva Contraseña";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblRI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 145);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtCCN);
            this.Controls.Add(this.txtCN);
            this.Controls.Add(this.lblCC);
            this.Controls.Add(this.lblCN);
            this.Name = "lblRI";
            this.Text = "CambioContraUsuario";
            this.Load += new System.EventHandler(this.lblRI_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCN;
        private System.Windows.Forms.Label lblCC;
        private System.Windows.Forms.TextBox txtCN;
        private System.Windows.Forms.TextBox txtCCN;
        private System.Windows.Forms.Button button1;
    }
}