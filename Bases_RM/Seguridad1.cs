using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Bases_RM
{
    public partial class Seguridad1 : Form
    {
        public Usuario datos_us;
        private Conexion_DB Conexion = new Conexion_DB();

   
        public Seguridad1(Usuario uso)
        {
            InitializeComponent();
            this.datos_us = uso;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String contrasena = Interaction.InputBox("Ingrese la Contraseña actual, para poder realizar el cambio:", "Ingreso de Contraseña Actual");
            if (!contrasena.Trim().Equals(""))
            {

                if (Conexion.login(datos_us.Nombre, contrasena))

                {
                    this.Hide();
                    Seguridad segu = new Seguridad(datos_us);
                    segu.ShowDialog();

                }
                else
                {
                    MessageBox.Show("Contraseña Incorrecta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //this.Show();

                }
            }
          
        }

        private void btnCambioContra_Click(object sender, EventArgs e)
        {
            String contrasena = Interaction.InputBox("Ingrese la Contraseña actual, para poder realizar el cambio:", "Ingreso de Contraseña Actual");
            if (!contrasena.Trim().Equals(""))
            {

                if (Conexion.login(datos_us.Nombre,contrasena))
                {
                    lblRI lb = new lblRI(datos_us);
                    this.Close();
                    lb.Show();

                   
                    //Menu men = new Menu(user);
                    //men.Show();

                }
                else
                {
                    MessageBox.Show("Contraseña Incorrecta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Show();

                }
            }
        }

       private void Seguridad1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Menu menu = new Menu(datos_us);
            menu.Show();
        }
        private void Seguridad1_Load(object sender, EventArgs e)
        {

        }
    }
}
