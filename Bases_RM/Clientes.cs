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
    public partial class Clientes : Form
    {
        private bool nuevo=false;//bandera booleana que sirve para alternar el formulario entre consultar clientes o ingresar Cliente
        private AbonoDeuda formulario=null;
        private Conexion_DB conexion=new Conexion_DB();
        private Cliente cliente_actual=null;
        String[,] clientes = null;
        public Clientes()
        {
            InitializeComponent();
            filtroGeneral();
            
        }
        /// <summary>
        /// Metodo que llena el TreeNode con los nombres y apellidos de los clientes en forma secuencial
        /// recibe por medio de la conexion una matriz String de n x 3, donde la primera columna tiene 
        /// nombres, la segunda apellidos y la tercera la id del cliente
        /// </summary>
        private void filtroGeneral()
        {
            clientes = conexion.obtener_clientes();
            if (clientes != null)
            {
                for (int i = 0; i < clientes.Length / 3; i++)
                {
                    arbolClientes.Nodes.Add(clientes[i, 0].ToString()+" "+clientes[i,1].ToString());
                }

            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lbLimiq_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbBuscar_Click(object sender, EventArgs e)
        {

        }

        private void lbNom_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Si se hace click sobre el boton abono, este abrira la ventana AbonoDeuda
        /// en modo de abono, enviandole un FALSE como primer parametro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAbono_Click(object sender, EventArgs e)
        {
            if (cliente_actual != null)
            {
                formulario = new AbonoDeuda(false, cliente_actual);
                formulario.ShowDialog();
            }
            else
                MessageBox.Show("No se ha seleccionado ningun cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        /// <summary>
        /// Si se hace click en boton deuda, se abre el formulario AbonoDeuda en modo Deuda
        /// enviandole un TRUE como´primer parametro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeuda_Click(object sender, EventArgs e)
        {
            if (cliente_actual != null)
            {
                formulario = new AbonoDeuda(true, cliente_actual);
                formulario.ShowDialog();
            }
            else
                MessageBox.Show("No se ha seleccionado ningun cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        /// <summary>
        /// Metodo que carga el cliente de la posicion indicada en los campos del formulario
        /// </summary>
        /// <param name="posicion"></param>posicion del cliente en la matriz
        public void cargarClientes(int posicion)
        {
            if (clientes != null && rbtnGeneral.Checked)
            {
                if(posicion<clientes.Length/3)
                cliente_actual = conexion.getCliente(clientes[posicion, 2]);//se llama  a la funcion get cliente, enviandole la id
                //se llenan los campos con los datos extraidos de la base
                TxtApe.Text = cliente_actual.apellido;
                TxtNom.Text = cliente_actual.nombre;
                TxtDias.Text = cliente_actual.dias.ToString();
                TxtNit.Text = cliente_actual.dpi;
                TxtLimic.Text = cliente_actual.limite.ToString();
            }
        }

        private void Clientes_Load(object sender, EventArgs e)
        {
            String[,] sucursales = conexion.obtener_sucursales();
            cbSucursal.Items.Add("Total");
            for (int i = 0; i < sucursales.Length/2; i++)
            {
                cbSucursal.Items.Add(sucursales[i,0]);
            }
            cargarClientes(0);    
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(!nuevo)//Si la bandera es falsa, el formulario esta en modo ver, cambia a nuevo bloquea los textbox
            {
                nuevo = true;
                nuevoToolStripMenuItem.Text = "Ver";
                btnMG.Text = "Guardar";
                btnEC.Text = "Cancelar";
                txtBuscar.Visible = false;
                TxtNom.Enabled = true;
                TxtNit.Enabled = true;
                TxtDias.Enabled = true;
                TxtLimic.Enabled = true;
                TxtApe.Enabled = true;
                TxtNom.Text = "";
                TxtNit.Text = "" ;
                TxtDias.Text="";
                TxtLimic.Text="";
                TxtApe.Text="";
                btnDeuda.Visible = false;
                btnAbono.Visible = false;
                lbBuscar.Visible = false;
                lblSucursal.Visible = false;
                cbSucursal.Visible = false;
            }
            else
            {
                nuevo = false;
                cargarClientes(0);
                nuevoToolStripMenuItem.Text = "Nuevo";
                btnMG.Text = "Modificar";
                btnEC.Text = "Eliminar";
                txtBuscar.Visible = true;
                TxtNom.Enabled = false;
                TxtNit.Enabled = false;
                TxtDias.Enabled = false;
                TxtLimic.Enabled = false;
                TxtApe.Enabled =   false;
                btnDeuda.Visible = true;
                btnAbono.Visible = true;
                lbBuscar.Visible = true;
                lblSucursal.Visible = true;
                cbSucursal.Visible = true;
            }
        }

        private void btnMG_Click(object sender, EventArgs e)
        {
            if(nuevo)
            {
                if(campos_vacios())
                {
                    MessageBox.Show("Uno o mas campos estan vacios", "Error");     
                }
                else
                {
                    try
                    {
                        conexion.ingresoCliente(TxtNit.Text, TxtNom.Text,TxtApe.Text, int.Parse(TxtDias.Text), Double.Parse(TxtLimic.Text));
                        arbolClientes.Nodes.Clear();
                        filtroGeneral();
                        nuevoToolStripMenuItem_Click(sender, e);
                        MessageBox.Show("Se ha añadido correctamente");
                        
                    }
                    catch(Exception ex)
                        {
                            MessageBox.Show("Algunos datos no son validos "+ex.ToString());
                        }
                }
                
            }
        }

        private void TxtDeuda_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Funcion boolean, que verifica si todos los campos necesarios son nulos o vacios
        /// </summary>
        /// <returns>RetornaTRUE si hay campos vacios- FALSE si ningun campo necesario es vacio o nulo</returns>
        private bool campos_vacios()
        {
            bool campos_nulos = false;
            if (String.IsNullOrEmpty(TxtDeuda.Text))
                campos_nulos = true;
            if (String.IsNullOrEmpty(TxtDias.Text))
                campos_nulos = true;
            if (String.IsNullOrEmpty(TxtLimic.Text))
                campos_nulos = true;
            if (String.IsNullOrEmpty(TxtNit.Text))
                campos_nulos = true;
            if (String.IsNullOrEmpty(TxtNom.Text))
                campos_nulos = true;
            return campos_nulos;
        }

        private void lbDeuda_Click(object sender, EventArgs e)
        {

        }

        private void arbolClientes_AfterSelect(object sender, TreeViewEventArgs e)
        {

            try
            {
                if(rbtnGeneral.Checked)
                {
                    cargarClientes(arbolClientes.SelectedNode.Index);
                }
            }
            catch(Exception ex)
            {

            }
            
        }

        private void archivoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnEC_Click(object sender, EventArgs e)
        {
            if(nuevo)
            {
                nuevoToolStripMenuItem_Click(sender, e);
            }
        }
    }
}
