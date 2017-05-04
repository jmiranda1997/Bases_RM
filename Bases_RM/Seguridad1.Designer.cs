namespace Bases_RM
{
    partial class Seguridad1
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
            this.btnCambioContra = new System.Windows.Forms.Button();
            this.btnConfig = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCambioContra
            // 
            this.btnCambioContra.Location = new System.Drawing.Point(12, 12);
            this.btnCambioContra.Name = "btnCambioContra";
            this.btnCambioContra.Size = new System.Drawing.Size(132, 43);
            this.btnCambioContra.TabIndex = 0;
            this.btnCambioContra.Text = "Cambio de Contraseña";
            this.btnCambioContra.UseVisualStyleBackColor = true;
            this.btnCambioContra.Click += new System.EventHandler(this.btnCambioContra_Click);
            // 
            // btnConfig
            // 
            this.btnConfig.Location = new System.Drawing.Point(150, 12);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(105, 43);
            this.btnConfig.TabIndex = 1;
            this.btnConfig.Text = "Configuraciones";
            this.btnConfig.UseVisualStyleBackColor = true;
            this.btnConfig.Click += new System.EventHandler(this.button2_Click);
            // 
            // Seguridad1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(265, 67);
            this.Controls.Add(this.btnConfig);
            this.Controls.Add(this.btnCambioContra);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Seguridad1";
            this.Text = "Seguridad";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Seguridad1_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCambioContra;
        private System.Windows.Forms.Button btnConfig;
    }
}