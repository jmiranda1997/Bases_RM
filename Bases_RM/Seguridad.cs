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
    public partial class Seguridad : Form
    {
        private Conexion_DB Conexion;
        public Usuario user;
        public Seguridad(Usuario user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
