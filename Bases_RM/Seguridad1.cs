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
        public Usuario user;

   
        public Seguridad1(Usuario uso)
        {
            InitializeComponent();
            this.user = uso;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String contrasena = Interaction.InputBox("Ingrese la Contraseña actual, para poder realizar el cambio:", "Ingreso de Contraseña Actual");
            if (!contrasena.Trim().Equals(""))
            {
                string Clave_Usuario = Conexion.Us_con(user.Nombre);
                if (Clave_Usuario.Equals(contrasena))
                {
                    this.Hide();
                    Seguridad segu = new Seguridad(datos_us);
                    segu.Show();

                }
                else
                {
                    MessageBox.Show("Contraseña Incorrecta\nIngresada " + contrasena + "\nConsultada " + Clave_Usuario, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Show();

                }
            }
          
        }

        private void btnCambioContra_Click(object sender, EventArgs e)
        {
            String contrasena = Interaction.InputBox("Ingrese la Contraseña actual, para poder realizar el cambio:", "Ingreso de Contraseña Actual");
            if (!contrasena.Trim().Equals(""))
            {
                string Clave_Usuario = Conexion.Us_con(user.Nombre);
                if (Clave_Usuario.Equals(contrasena))
                {
                    lblRI lb = new lblRI(user);
                    lb.Show();
                   
                    //Menu men = new Menu(user);
                    //men.Show();

                }
                else
                {
                    MessageBox.Show("Contraseña Incorrecta\nIngresada " + contrasena + "\nConsultada " + Clave_Usuario, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Show();

                }
            }
        }
    }
}
