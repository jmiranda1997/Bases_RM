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
            string Clave_Usuario = Conexion.Us_con(txtUsuario.Text);
            if (Clave_Usuario.Equals(txtContraseña.Text))
            {
                this.Hide();

            }
            else
            {
                MessageBox.Show("Contraseña Incorrecta");
            }
        }
    }
}
