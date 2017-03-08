namespace Bases_RM
{
    partial class Panel_Menu
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
            this.btnProve = new System.Windows.Forms.Button();
            this.btnUsu = new System.Windows.Forms.Button();
            this.btnClien = new System.Windows.Forms.Button();
            this.btnTraba = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnProve
            // 
            this.btnProve.Location = new System.Drawing.Point(107, 168);
            this.btnProve.Name = "btnProve";
            this.btnProve.Size = new System.Drawing.Size(148, 50);
            this.btnProve.TabIndex = 0;
            this.btnProve.Text = "Proveedores";
            this.btnProve.UseVisualStyleBackColor = true;
            this.btnProve.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnUsu
            // 
            this.btnUsu.Location = new System.Drawing.Point(280, 168);
            this.btnUsu.Name = "btnUsu";
            this.btnUsu.Size = new System.Drawing.Size(134, 50);
            this.btnUsu.TabIndex = 1;
            this.btnUsu.Text = "Usuarios";
            this.btnUsu.UseVisualStyleBackColor = true;
            this.btnUsu.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnClien
            // 
            this.btnClien.Location = new System.Drawing.Point(107, 234);
            this.btnClien.Name = "btnClien";
            this.btnClien.Size = new System.Drawing.Size(148, 50);
            this.btnClien.TabIndex = 2;
            this.btnClien.Text = "Clientes";
            this.btnClien.UseVisualStyleBackColor = true;
            this.btnClien.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnTraba
            // 
            this.btnTraba.Location = new System.Drawing.Point(280, 234);
            this.btnTraba.Name = "btnTraba";
            this.btnTraba.Size = new System.Drawing.Size(134, 50);
            this.btnTraba.TabIndex = 3;
            this.btnTraba.Text = "Trabajadores";
            this.btnTraba.UseVisualStyleBackColor = true;
            this.btnTraba.Click += new System.EventHandler(this.button4_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Bases_RM.Properties.Resources.logoRM;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(487, 137);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // Panel_Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 298);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnTraba);
            this.Controls.Add(this.btnClien);
            this.Controls.Add(this.btnUsu);
            this.Controls.Add(this.btnProve);
            this.Name = "Panel_Menu";
            this.Text = "Menú";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnProve;
        private System.Windows.Forms.Button btnUsu;
        private System.Windows.Forms.Button btnClien;
        private System.Windows.Forms.Button btnTraba;
        private System.Windows.Forms.PictureBox pictureBox1;

    }
}