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
            clientes = conexion.obtener_clientes();
            if(clientes!=null)
            {
                for(int i=0; i<clientes.Length/3;i++)
                {
                    arbolClientes.Nodes.Add(clientes[i,2].ToString());
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

        private void btnAbono_Click(object sender, EventArgs e)
        {
           formulario = new AbonoDeuda(false,null);
           formulario.ShowDialog();
        }

        private void btnDeuda_Click(object sender, EventArgs e)
        {
            formulario = new AbonoDeuda(true,null);
            formulario.ShowDialog();
        }
        public void cargarClientes()
        {
            if (clientes.Length > 0)
            {
                cliente_actual = conexion.getCliente(clientes[0, 2]);
                TxtApe.Text = cliente_actual.apellido;
                TxtNom.Text = cliente_actual.nombre;
                TxtDias.Text = cliente_actual.dias.ToString();
                TxtNit.Text = cliente_actual.dpi;
                TxtLimic.Text = cliente_actual.limite.ToString();
            }
        }

        private void Clientes_Load(object sender, EventArgs e)
        {
            cargarClientes();
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
                
            }
            else
            {
                nuevo = false;
                cargarClientes();
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
                        conexion.ingresoCliente(TxtNit.Text, TxtNom.Text,TxtApe.Text, int.Parse(TxtDias.Text), int.Parse(TxtLimic.Text),2);        
                    }
                    catch(Exception ex)
                        {
                            MessageBox.Show("Algunos datos no son validos");
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
                cliente_actual = conexion.getCliente(arbolClientes.SelectedNode.ToString());
                cargarClientes();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void archivoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
