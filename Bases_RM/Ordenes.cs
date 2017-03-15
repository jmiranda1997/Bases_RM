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
            String[] codigos = this.Conexion_DB.obtener_codigos();
            String[] proveedores = this.Conexion_DB.obtener_proveedores();
            for (int i = 0; i < codigos.Length; i++)
            {
                OrdenesTree.Nodes.Add(new TreeNode(codigos[i]));
            }
            for (int i = 0; i < proveedores.Length; i++)
            {
                ListaProve.Items.Add(proveedores[i]);
            }
        }

        private void archivoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OrdenesTree.SelectedNode= OrdenesTree.SelectedNode.NextNode;
            OrdenesTree.Select();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OrdenesTree.SelectedNode = OrdenesTree.SelectedNode.PrevNode;
            OrdenesTree.Select();
        }

        private void Ordenes_Load(object sender, EventArgs e)
        {

        }

        private void OrdenesTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            String codigo = OrdenesTree.SelectedNode.Text;
            Producto producto = Conexion_DB.obtener_Producto(codigo.Trim());
            if (producto != null)
            {
                txtDesc.Text = producto.Descripcion;
                txtCI.Text = producto.Codigo_Interno;
                txtCF.Text = producto.Codigo_Barras;
                txtDepar.Text = producto.Departamento;
                txtMar.Text = producto.Marca;
                txtPC.Text = producto.Precio_Costo.ToString();
                txtPV.Text = producto.Precio_Venta.ToString();
            }
           
        }

        private void btnMod1_Click(object sender, EventArgs e)
        {

        }

        private void salirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OrdenesTree_MouseClick(object sender, MouseEventArgs e)
        {
            
        }
    }
}
