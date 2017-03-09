using System;
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
        public Login()
        {
            InitializeComponent();
            Conexion = new Conexion_DB();
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
        private void InicioSesion()
        {
            if ((txtUsuario.Text.Trim() != "") && (txtContraseña.Text.Trim() != ""))
            {
                string Clave_Usuario = Conexion.Us_con(txtUsuario.Text);
                if (Clave_Usuario.Equals(txtContraseña.Text))
                {
                    this.Hide();
                    Menu men = new Menu();
                    men.Show();
                }
                else
                {
                    MessageBox.Show("Contraseña Incorrecta","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
        }

        private void pixLogo_Click(object sender, EventArgs e)
        {

        }
    }
}
