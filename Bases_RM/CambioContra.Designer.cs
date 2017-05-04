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
            this.contraText1 = new System.Windows.Forms.TextBox();
            this.contraText2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblCN
            // 
            this.lblCN.AutoSize = true;
            this.lblCN.Location = new System.Drawing.Point(22, 19);
            this.lblCN.Name = "lblCN";
            this.lblCN.Size = new System.Drawing.Size(145, 13);
            this.lblCN.TabIndex = 1;
            this.lblCN.Text = "Ingrese la contraseña nueva:";
            // 
            // lblCC
            // 
            this.lblCC.AutoSize = true;
            this.lblCC.Location = new System.Drawing.Point(22, 52);
            this.lblCC.Name = "lblCC";
            this.lblCC.Size = new System.Drawing.Size(151, 13);
            this.lblCC.TabIndex = 2;
            this.lblCC.Text = "Confirme la nueva contraseña:";
            // 
            // contraText1
            // 
            this.contraText1.Location = new System.Drawing.Point(172, 16);
            this.contraText1.Name = "contraText1";
            this.contraText1.PasswordChar = '*';
            this.contraText1.Size = new System.Drawing.Size(164, 20);
            this.contraText1.TabIndex = 4;
            // 
            // contraText2
            // 
            this.contraText2.Location = new System.Drawing.Point(172, 49);
            this.contraText2.Name = "contraText2";
            this.contraText2.PasswordChar = '*';
            this.contraText2.Size = new System.Drawing.Size(164, 20);
            this.contraText2.TabIndex = 5;
            this.contraText2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCCN_KeyPress);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(172, 75);
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
            this.ClientSize = new System.Drawing.Size(354, 106);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.contraText2);
            this.Controls.Add(this.contraText1);
            this.Controls.Add(this.lblCC);
            this.Controls.Add(this.lblCN);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "lblRI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cambio de Contraseña";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCN;
        private System.Windows.Forms.Label lblCC;
        private System.Windows.Forms.TextBox contraText1;
        private System.Windows.Forms.TextBox contraText2;
        private System.Windows.Forms.Button button1;
    }
}