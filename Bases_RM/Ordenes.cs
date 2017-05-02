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
        private ClasePedido pedido;
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
            String codigo = OrdenesTree.SelectedNode.Text.Trim();
            Producto producto = Conexion_DB.obtener_Producto(codigo);
            if (producto != null)
            {
                txtDesc.Text = producto.Descripcion;
                txtCI.Text = producto.Codigo_Interno;
                txtCF.Text = producto.Codigo_Barras;
                txtDepar.Text = producto.Departamento;
                txtMar.Text = producto.Marca;
                txtPC.Text = producto.Precio_Costo.ToString();
                txtPV.Text = producto.Precio_Venta.ToString();
                txtexistencias.Text = producto.Existencias.ToString();
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

        private void txtDesc_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void nuevoPedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Conexion_DB.ingresoPedido();
            String Nombre = Conexion_DB.obtenerNombrePedido();
            cambiarBtn(true, "Abierto", Color.Green, Nombre);
            pedido = Conexion_DB.obtenerPedido(Nombre);
            lbEstado.Visible = true;
        }
        private void cambiarBtn(Boolean estado, String Texto, Color color, String Titulo)
        {
            this.Text = Titulo;
            lbEstado.BackColor= color;
            lbEstado.Text = Texto;
            ListaProve.Enabled = estado;
            txtCantidad.Enabled = estado;
            txtComentario.Enabled = estado;
            btnPedir.Enabled = estado;
            cerrarPedidoToolStripMenuItem.Enabled = estado;

        }

        private void consultarPedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cerrarPedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pedido = null;
            cambiarBtn(false, "", Color.Green, "Pedidos");
            lbEstado.Visible = false;
        }

        private void menuStrip1_Click(object sender, EventArgs e)
        {
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void abrirPedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Abrir_Pedido Abrir = new Abrir_Pedido();
            Abrir.ShowDialog();
            if (Abrir.idSeleccion != -1)
            {
                pedido = Conexion_DB.obtenerPedido(Abrir.Nombre);
                String result = "Cerrado"; Color color = Color.Red; bool condicion = false;
                if (!pedido.finalizado) { result = "Abierto"; color = Color.Green; condicion = true;}
                lbEstado.Visible = true;
                cambiarBtn(condicion, result, color, Abrir.Nombre);
            }
        }

        private void consultarPedidoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
        }

        private void lbEstado_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Proveedores prov = new Proveedores();
            prov.ShowDialog();

        }
    }
}
