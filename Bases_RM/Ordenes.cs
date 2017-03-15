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
    public partial class Ordenes : Form
    {
        private Conexion_DB Conexion_DB;
        public Ordenes()
        {
            InitializeComponent();
            this.Conexion_DB = new Conexion_DB();
            Producto[] Producto = this.Conexion_DB.obtener_Codigos();
            for (int i = 0; i < Producto.Length; i++)
            {

                OrdenesTree.Nodes.Add(new TreeNode(Producto[i].Codigo_Interno));
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void archivoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Ordenes_Load(object sender, EventArgs e)
        {

        }
    }
}
