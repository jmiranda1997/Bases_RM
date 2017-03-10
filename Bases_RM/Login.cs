﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bases_RM
{
    public partial class Login : Form
    {
        private Conexion_DB Conexion;
        private Vigenere Vig;
        String Contra = "", User = "", Contra_Vig = "3JOR";
        public Login()
        {
            InitializeComponent();
            Conexion = new Conexion_DB();
            Vig = new Vigenere();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            InicioSesion();
        }

        private void txtContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                this.Hide();
                InicioSesion();
            }
        }
        /**
        Metodo que cifra y descifra la clave 
        */
        public void Cifrado_Usuario(String contraseña, String Usuario)
        {
            Contra = txtContraseña.Text.Trim();
            Vig.cifrar(Contra, Contra_Vig);
        }
        /*
         
         */
       
        private void InicioSesion()
        {

            if ((txtUsuario.Text.Trim() != "") && (txtContraseña.Text.Trim() != ""))
            {
                string Clave_Usuario = Conexion.Us_con(txtUsuario.Text);
                if (Clave_Usuario.Equals(txtContraseña.Text))
                {
                    this.Hide();
                    Usuario usernuevo = Conexion.Datos_De_User(txtUsuario.Text.Trim());
                    Menu men = new Menu(usernuevo);
                    men.Show();

                }
                else
                {
                    MessageBox.Show("Contraseña Incorrecta\nIngresada "+ txtContraseña.Text + "\nConsultada "+ Clave_Usuario,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
        }

        private void pixLogo_Click(object sender, EventArgs e)
        {

        }
    }
}
