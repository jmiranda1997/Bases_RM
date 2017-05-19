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
        private String[,] sucursales;
        String[,] clientes = null;
        private bool modificar = false;
        public Clientes()
        {
            InitializeComponent();
            filtroGeneral();
            
        }
        public void actualizar(int id)
        {
            int i=0;
            while(int.Parse(clientes[i,2])!=id)
            {
                i++;
            }
            if (rbtnGeneral.Checked)
                filtroGeneral();
            else
                filtroSucursal();
            cargarClientes(i);
        }
        /// <summary>
        /// Metodo que llena el TreeNode con los nombres y apellidos de los clientes en forma secuencial
        /// recibe por medio de la conexion una matriz String de n x 3, donde la primera columna tiene 
        /// nombres, la segunda apellidos y la tercera la id del cliente
        /// </summary>
        private void filtroGeneral()
        {
            arbolClientes.Nodes.Clear();
            clientes = conexion.obtener_clientes();
            if (clientes.Length>0)
            {
                for (int i = 0; i < clientes.Length / 3; i++)
                {
                    arbolClientes.Nodes.Add(clientes[i, 0].ToString()+" "+clientes[i,1].ToString());
                }

            }
        }
        /// <summary>
        /// Metodo que llena el TreeNode con las sucursales y dentro de esos nodos, todos los clientes
        /// que tienen deudas dentro de ellas
        /// </summary>
        private void filtroSucursal()
        {
            arbolClientes.Nodes.Clear();//limpia el arbol
            clientes = conexion.obtener_clientes_sucursal();//LLama al metodo de conexion para obtener clientes y sucursales
            if (clientes.Length > 0)//Si la matriz obtenida tiene elementos, se ejecuta
            {
                bool bandera = false;//La bandera sirve para indicar si al menos hay un cliente que puede realizar
                TreeNode nodo;
                if (!String.IsNullOrEmpty(clientes[0, 3]))
                    nodo = new TreeNode(clientes[0, 3]);//si la primera sucursal de la matriz esta en blanco, significa que 
                    //el cliente aun no ha adquirido ninguna deuda
                else
                    nodo = new TreeNode("SIN DEUDAS");
                for (int i = 0; i < clientes.Length / 4; i++)
                {
                    if(!bandera)
                        nodo.Name = (i).ToString();// le coloca nombre al nodo  padre (sucursal), su nombre sera
                    //la primera posicion en la que se encontro esta sucursal en la matriz
                    if ((nodo.Text.Equals("SIN DEUDAS") && String.IsNullOrEmpty(clientes[i, 3]))||nodo.Text.Equals(clientes[i, 3]))//si el nombre de la sucursal concuerda con el nodo padre actual
                    //añade
                    {
                        nodo.Nodes.Add(clientes[i, 0].ToString() + " " + clientes[i, 1].ToString());//añade nodos al nodo padre (sucursal)
                        //y los nodos agregados son Clientes
                        bandera = true;
                    }
                    else//si no coincide se debe agregar la nueva sucursal
                    {
                        if (bandera)
                        {
                            arbolClientes.Nodes.Add(nodo);//se añade el nodo padre (sucursal) al TreeNode (arbol)
                            bandera = false;
                        }
                        nodo = new TreeNode(clientes[i, 3]);//se genera un nuevo nodo padre
                        i--;//se resta uno del iterador para volver a analizar el cliente que pertencia a otra sucursal
                    }
                }
                if (bandera)
                {
                    arbolClientes.Nodes.Add(nodo);//añade el ultimo nodo
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
                if (double.Parse(TxtDeuda.Text) > 0)
                {
                    formulario = new AbonoDeuda(false, cliente_actual,this);
                    formulario.ShowDialog();
                }
                else
                    MessageBox.Show("Este cliente no tiene una deuda", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                formulario = new AbonoDeuda(true, cliente_actual,this);
                formulario.ShowDialog();
            }
            else
                MessageBox.Show("No se ha seleccionado ningun cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        /// <summary>
        /// Metodo que carga el cliente de la posicion indicada en los campos del formulario
        /// </summary>
        /// <param name="posicion"></param>posicion del cliente en la matriz
        private void cargarClientes(int posicion)
        {

            int columnas;//Variable que indica el numero de columnas de la matriz de clientes (depende del filtro)
            if (rbtnGeneral.Checked)
            {
                columnas = 3;//Si el filtro es general la matriz tiene 3 columnas
                
            }
            else
            {
                columnas = 4;//si no, el filtro tiene 4
                
            }
            if (clientes.Length > 0)
            {
                if (posicion < clientes.Length / columnas)//se comprueba que la posicion no sobrepase el numero de filas
                {//si no hay un objeto de cliente actual
                    cliente_actual = conexion.getCliente(clientes[posicion, 2]);//se llama  a la funcion get cliente, enviandole la id
                    //se llenan los campos con los datos extraidos de la base
                    TxtApe.Text = cliente_actual.apellido;
                    TxtNom.Text = cliente_actual.nombre;
                    TxtDias.Text = cliente_actual.dias.ToString();
                    TxtNit.Text = cliente_actual.dpi;
                    TxtLimic.Text = cliente_actual.limite.ToString("N2");
                    TxtDeuda.Text = conexion.obtener_saldoTotal(cliente_actual.id, 0).ToString("N2");
                    cbSucursal.Text = "";

                }
            }

        }
        /// <summary>
        /// Cargar cliente actual, llena los campos del formulario con los datos del cliente ya cargado
        /// </summary>
        private void cargarClientesActual()
        {
            if (cliente_actual!=null)
            {       
                TxtApe.Text = cliente_actual.apellido;
                TxtNom.Text = cliente_actual.nombre;
                TxtDias.Text = cliente_actual.dias.ToString();
                TxtNit.Text = cliente_actual.dpi;
                TxtLimic.Text = cliente_actual.limite.ToString("N2");
                cbSucursal.Text = "";
            }
        }
        private void Clientes_Load(object sender, EventArgs e)
        {
            sucursales = conexion.obtener_sucursales();
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
                modificar = false;
                nuevoToolStripMenuItem.Text = "Ver";
                guardar_modificar();
                TxtNit.Enabled = true;
            }
            else
            {
                nuevo = false;
                nuevoToolStripMenuItem.Text = "Nuevo";
                cargarClientes(0);
                modo_vista();
            }
        }
        /// <summary>
        /// Desabilita los campos para dejar el formulario solo apto para visualizar datos de clientes
        /// </summary>
        private void modo_vista()
        {
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
        /// <summary>
        /// Habilita y limpia los campos modificables para insercion o modificacion de clientes
        /// </summary>
        private void guardar_modificar()
        {
            btnMG.Text = "Guardar";
            btnEC.Text = "Cancelar";
            txtBuscar.Visible = false;
            TxtNom.Enabled = true;
            TxtNit.Enabled = false;
            TxtDias.Enabled = true;
            TxtLimic.Enabled = true;
            TxtApe.Enabled = true;
            TxtNom.Text = "";
            TxtNit.Text = "";
            TxtDias.Text = "";
            TxtLimic.Text = "";
            TxtApe.Text = "";
            btnDeuda.Visible = false;
            btnAbono.Visible = false;
            lbBuscar.Visible = false;
            lblSucursal.Visible = false;
            cbSucursal.Visible = false;
        }
        /// <summary>
        /// Boton utilizado para guardar un nuevo cliente o las modificaciones de este
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMG_Click(object sender, EventArgs e)
        {
            
            if(nuevo || modificar)//si una de las dos banderas es TRUE se esta ingreando o modificando un cliente
            {
                if(campos_vacios())//Se verifica que no existan campos vacios
                {
                    MessageBox.Show("Uno o mas campos estan vacios", "Error");     
                }
                else
                {
                    try
                    {
                        if (nuevo == true)//si la bandera nuevo es true, trata de guardar el nuevo cliente
                        {
                            conexion.ingresoCliente(TxtNit.Text, TxtNom.Text, TxtApe.Text, int.Parse(TxtDias.Text), Double.Parse(TxtLimic.Text));// llama al ingreso de clientes
                            arbolClientes.Nodes.Clear();//Limpia el TreeNode
                            if (rbtnGeneral.Checked)
                                filtroGeneral();//vuelve a carga a los clientes
                            else
                                filtroSucursal();
                            nuevoToolStripMenuItem_Click(sender, e);//Vuelve a colocar el formulario en modo visualizacion de datos
                            MessageBox.Show("Se ha añadido correctamente");
                        }
                        if(modificar && cliente_actual!=null)//si la bandera es de modifcacion y el cliente actual no es nulo, trata de modificarse
                        {
                            conexion.modificacionCliente(TxtNom.Text, TxtApe.Text, int.Parse(TxtDias.Text), double.Parse(TxtLimic.Text), cliente_actual.id);//llama al UPDATE de clientes de la clase conexion
                            arbolClientes.Nodes.Clear();//Limpia el TreeNode
                            if (rbtnGeneral.Checked)
                                filtroGeneral();//vuelve a cargar los clientes
                            else
                                filtroSucursal();
                            modificar = false;//cambia la bandera de modificacion
                            modo_vista();//poine el formulario en modo vista
                            cliente_actual = conexion.getCliente(cliente_actual.id.ToString());//actualiza el cliente actual
                            cargarClientesActual();//Carga los datos en el formulario
                            MessageBox.Show("Se ha modificado correctamente");
                        }
                    }
                    catch(Exception ex)
                        {
                            MessageBox.Show("Algunos datos no son validos "+ex.ToString());
                        }
                }
            }
            else if (!modificar && cliente_actual != null)//si la bandera de modificar no esta actitvada y no entro al if anterior
            {
                modificar = true;//cambia la bandera de modificacion
                guardar_modificar();//pone el formulario en modo guardar o modificar (limpia yy habilita los campos correspondientes)
                cargarClientesActual();//carga los datos del cliente actual
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
                if (rbtnSucursal.Checked)
                {
                    if (arbolClientes.SelectedNode.Parent != null)
                        cargarClientes(int.Parse(arbolClientes.SelectedNode.Parent.Name) + arbolClientes.SelectedNode.Index);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
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
            if(modificar)
            {
                modificar = false;
                cargarClientesActual();
                modo_vista();
            }
        }

        private void cbSucursal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cliente_actual!=null)
            {
                TxtSaldo.Text = conexion.obtener_saldoTotal(cliente_actual.id, int.Parse(sucursales[cbSucursal.SelectedIndex, 1])).ToString("N2");
            }
        }

        private void TxtLimic_Leave(object sender, EventArgs e)
        {
            try
            {
                TxtLimic.Text = double.Parse(TxtLimic.Text).ToString("N2");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Este no es un numero valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtLimic.Focus();
            }


        }

        private void registroDeDeudasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(cliente_actual!=null)
            {
                Registro res = new Registro(true, cliente_actual);
                res.Show();
            }
            else
                MessageBox.Show("No se ha seleccionado un cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }

        private void registroDePagosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cliente_actual != null)
            {
                Registro res = new Registro(false, cliente_actual);
                res.Show();
            }
            else
                MessageBox.Show("No se ha seleccionado un cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void exportarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog fichero = new SaveFileDialog();
                fichero.Filter = "Excel (*.xls)|*.xls";
                if (fichero.ShowDialog() == DialogResult.OK)
                {
                    conexion.exportar(conexion.exportarDeuda(0, 0), fichero.FileName);
                    MessageBox.Show("Se ha guardado correctamente", "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ocurrio un error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rbtnSucursal_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnSucursal.Checked)
                filtroSucursal();
        }

        private void rbtnGeneral_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnGeneral.Checked)
                filtroGeneral();
        }
    }
}
