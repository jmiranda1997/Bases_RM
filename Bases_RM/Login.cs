﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Reflection;
using MySql.Data.MySqlClient;

namespace Bases_RM
{
    public partial class Login : Form
    {
        private Conexion_DB Conexion;
        private Vigenere Vig;
        public Usuario datos_us;
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
                //this.Hide();
                InicioSesion();
            }
        }
        /**
        Metodo que cifra y descifra la clave 
        */

        //public void Cifrado_Usuario(String contraseña, String Usuario)
        //{
        //    Contra = txtContraseña.Text.Trim();
        //    Vig.cifrar(Contra, Contra_Vig);
        //}

        /*
         
         */
       
        private void InicioSesion()
        {
            try
            {
                if ((!txtUsuario.Text.Trim().Equals("")) && (!txtContraseña.Text.Trim().Equals("")))
                {
                    if (Conexion.login(txtUsuario.Text,txtContraseña.Text))
                    {
                        Usuario usernuevo = Conexion.Datos_De_User(txtUsuario.Text.Trim());
                        usernuevo.obtenerPermisos();
                        Menu men = new Menu(usernuevo);
                        men.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Contraseña Incorrecta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Show();
                        txtContraseña.SelectAll();
                        txtContraseña.Focus();
                    }
                }
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        

        private void pixLogo_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
