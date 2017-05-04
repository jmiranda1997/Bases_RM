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
    public partial class lblRI : Form
    {
        private Conexion_DB Conexion = new Conexion_DB();
        public Usuario user;
        public lblRI(Usuario us)
        {
            InitializeComponent();
            this.user = us;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            cambio();
        }
        private void txtCCN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                cambio();
            }
        }
        private void cambio()
        {
            if ((contraText1.Text == contraText2.Text) && !contraText1.Text.Trim().Equals(""))
            {
                if (contraText1.Text.Length < 45)
                {
                    Conexion.modificacionUsuario(user.Nombre, contraText1.Text);
                    MessageBox.Show("Contraseña modificada", "Contraseña modificada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("La contraseña debe ser menor a 45 carácteres", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    contraText2.Clear();
                    contraText1.Focus();
                    contraText1.SelectAll();
                }
            }
            else
            {
                MessageBox.Show("Las contraseñas no coinciden", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                contraText1.Clear();
                contraText2.Clear();
                contraText1.Focus();
            }
        }
    }
}
