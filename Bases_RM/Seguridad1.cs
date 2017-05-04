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
                if (Conexion.login(user.Nombre,contrasena))
                {
                    this.Hide();
                    Seguridad segu = new Seguridad(user);
                    segu.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Contraseña Incorrecta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
          
        }

        private void btnCambioContra_Click(object sender, EventArgs e)
        {
            String contrasena = Interaction.InputBox("Ingrese la Contraseña actual, para poder realizar el cambio:", "Ingreso de Contraseña Actual");
            if (!contrasena.Trim().Equals(""))
            {
                if (Conexion.login(user.Nombre,contrasena))
                {
                    lblRI lb = new lblRI(user);
                    this.Close();
                    lb.ShowDialog();
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
            Menu menu = new Menu(user);
            menu.Show();
        }
    }
}
