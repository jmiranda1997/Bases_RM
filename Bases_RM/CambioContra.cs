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
        private Vigenere Vig = new Vigenere();
        private Conexion_DB Conexion = new Conexion_DB();
        public Usuario datos_us;
        public Usuario user;
        
        String clave = "3JOR";
        public lblRI(Usuario us)
        {
            InitializeComponent();
            this.user = us;
        }

        private void lblCC_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string mensaje = "", cifrado = "", usuario="";
            mensaje = txtCCN.Text.Trim();
            Vig.cifrar(mensaje, clave);
            cifrado = Vig.getMC();
            usuario = user.Nombre;
            Conexion.modificacionUsuario(usuario, cifrado);
        }

        private void lblRI_Load(object sender, EventArgs e)
        {

        }

        private void txtCCN_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
