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
        private ClasePedido pedido = null;
        private Producto producto;
        public Ordenes(Usuario User)
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
            txtCantidad.Focus();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OrdenesTree.SelectedNode = OrdenesTree.SelectedNode.PrevNode;
            OrdenesTree.Select();
            txtCantidad.Focus();
        }

        private void Ordenes_Load(object sender, EventArgs e)
        {

        }

        private void OrdenesTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            String codigo = OrdenesTree.SelectedNode.Text.Trim();
            producto = Conexion_DB.obtener_Producto(codigo);
            if (producto != null)
            {
                
                desCheck();
                txtDesc.Text = producto.Descripcion;
                txtCI.Text = producto.Codigo_Interno;
                txtCF.Text = producto.Codigo_Barras;
                txtDepar.Text = producto.Departamento;
                txtMar.Text = producto.Marca;
                txtPC.Text = producto.Precio_Costo.ToString();
                txtPV.Text = producto.Precio_Venta.ToString();
                txtexistencias.Text = producto.Existencias.ToString();
                if (pedido != null)
                {
                    String[] Prove = Conexion_DB.obtenerProvPed(producto.id);
                    for (int i = 0; i < Prove.Length; i++)
                    {
                        if (ListaProve.Items.Contains(Prove[i]))
                        {
                            ListaProve.SetItemChecked(ListaProve.Items.IndexOf(Prove[i]), true);
                        }
                    }
                    if (Conexion_DB.existeDetalle(producto.id, pedido.id))
                    {
                        String[] datos = Conexion_DB.obtenerDetalle(producto.id , pedido.id);
                        txtCantidad.Text = datos[0];
                        txtPrecio.Text = datos[1];
                        txtComentario.Text = datos[2];
                    }
                    else
                    {
                        txtCantidad.Text = "0";
                        txtPrecio.Text = "0.00";
                        txtComentario.Text = "";
                    }
                }else
                {
                    txtCantidad.Text = "0";
                    txtPrecio.Text = "0.00";
                    txtComentario.Text = "";
                }
            
            }
            
           
        }

        private void desCheck(){
            for (int i = 0; i < ListaProve.Items.Count; i++)
            {
                ListaProve.SetItemChecked(i, false);
                
            }
        }
        private void btnMod1_Click(object sender, EventArgs e)
        {
            Conexion_DB.modificacionProducto(txtCI.Text, txtCF.Text, txtDesc.Text, txtMar.Text, txtDepar.Text, Double.Parse(txtPC.Text), Double.Parse(txtPV.Text));
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
            marcarComoFinalizadoToolStripMenuItem.Enabled = true;
            marcarComoNoFinalizadoToolStripMenuItem.Enabled = true;
        }
        private void cambiarBtn(Boolean estado, String Texto, Color color, String Titulo)
        {
            this.Text = Titulo;
            lbEstado.BackColor= color;
            lbEstado.Text = Texto;
            //ListaProve.Enabled = estado;
            txtCantidad.Enabled = estado;
            btnPedir.Enabled = estado;
            cerrarPedidoToolStripMenuItem.Enabled = estado;
            txtPrecio.Enabled = estado;
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
            marcarComoFinalizadoToolStripMenuItem.Enabled = false;
            marcarComoNoFinalizadoToolStripMenuItem.Enabled = false;
            txtCantidad.Text = "0";
            txtPrecio.Text = "0.00";
            txtComentario.Text = "";
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
                marcarComoFinalizadoToolStripMenuItem.Enabled = true;
                marcarComoNoFinalizadoToolStripMenuItem.Enabled = true;
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
            int est = ListaProve.SelectedIndex;
            Conexion_DB.eliminarProdProv(producto.id);
            for (int i = 0; i < ListaProve.Items.Count; i++)
            {
                ListaProve.SelectedIndex = i;
                if (ListaProve.GetItemChecked(i))
                {
                    Conexion_DB.ingresarProdProv(Conexion_DB.obtenerIdProveedor(ListaProve.Text), producto.id);
                }
            }
            ListaProve.SelectedIndex = est;
        }

        private void btnPedir_Click(object sender, EventArgs e)
        {
            
            if (txtCantidad.Text.Length > 0)
            {
                Double Precio = 0.00;
                String Comentario = "";
                int Cantidad;
                Cantidad = Int32.Parse(txtCantidad.Text);
                if (txtPrecio.Text.Length > 0)
                {
                    Precio = Double.Parse(txtPrecio.Text);
                } if (txtComentario.Text.Length > 0)
                {
                    Comentario = txtComentario.Text;
                }
                if (Conexion_DB.existeDetalle(producto.id, pedido.id))
                {
                    Conexion_DB.modificacionDetallePedido(producto.id, pedido.id, Int32.Parse(txtCantidad.Text), Double.Parse(txtPrecio.Text), txtComentario.Text);
                }
                else Conexion_DB.ingresoDetallePedido(Int32.Parse(txtCantidad.Text), Double.Parse(txtPrecio.Text), producto.id, pedido.id, txtComentario.Text);

                button2_Click(sender, e);
            }
            else MessageBox.Show("El campo \"Cantidad\" NO puede estar vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ListaProve_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ListaProve_DoubleClick(object sender, EventArgs e)
        {
         
        }

        private void ListaProve_ItemCheck(object sender, ItemCheckEventArgs e)
        {
          
        }

        private void ListaProve_Click(object sender, EventArgs e)
        {
          
        }

        private void pedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Proveedores prov = new Proveedores();
            prov.ShowDialog();
        }

        private void marcarComoFinalizadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Conexion_DB.estadoPedido(pedido.Nombre, "si");
            cambiarBtn(false, "Cerrado", Color.Red, pedido.Nombre);
        }

        private void marcarComoNoFinalizadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Conexion_DB.estadoPedido(pedido.Nombre, "no");
            cambiarBtn(true, "Abierto", Color.Green, pedido.Nombre);
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                btnPedir_Click(sender, e);
            }
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                btnPedir_Click(sender, e);
            }
        }

        private void txtComentario_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void exportarPedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Exportar ex = new Exportar();
            ex.ShowDialog();
            DataTable tabla = Conexion_DB.obtenerPedido(ex.idProveedor, ex.idPedido);
            String direccion = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "// "+ex.nombreprov + "PEDIDO:" + ex.Nombreped;
        }       
    }
}
