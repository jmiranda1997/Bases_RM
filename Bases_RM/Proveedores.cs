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
    public partial class Proveedores : Form
    {
        private Conexion_DB Conexion_DB;
        private bool bandera = false;
        public Proveedores()
        {
            this.Conexion_DB = new Conexion_DB();
            InitializeComponent();
            listaProv();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {


        }

        private void Proveedores_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void archivoToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void nuevoToolStripMenuItem3_Click(object sender, EventArgs e)
        {
           
        }

        private void contactoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void listaProv()
        {
            this.Text = "Provedores";
            this.groupContacto.Visible = false;
            this.groupPais.Visible = false;
            this.groupProveedor.Visible = true;
            this.treeProveedores.Visible = true;
            this.treeContacto.Visible = false;
            this.treePais.Visible = false;
            String[] proveedores = this.Conexion_DB.obtenerProveedores();
            this.treeProveedores.Nodes.Clear();
            for (int i = 0; i < proveedores.Length; i++)
            {
                this.treeProveedores.Nodes.Add(proveedores[i]);
            }
            
        }
        private void listaContac()
        {
            this.Text = "Contactos";
            this.groupProveedor.Visible = false;
            this.groupPais.Visible = false;
            this.groupContacto.Visible = true;
            this.treeProveedores.Visible = false;
            this.treeContacto.Visible = true;
            this.treePais.Visible = false;
            String[] contactos = this.Conexion_DB.obtenerContactos();
            this.treeContacto.Nodes.Clear();
            for (int i = 0; i < contactos.Length; i++)
            {
                this.treeContacto.Nodes.Add(contactos[i]);
            }
        }
        private void listaPais()
        {
            this.Text = "Paises";
            this.groupProveedor.Visible = false;
            this.groupContacto.Visible = false;
            this.groupPais.Visible = true;
            this.treeProveedores.Visible = false;
            this.treeContacto.Visible = false;
            this.treePais.Visible = true;
            String[] paises = this.Conexion_DB.obtenerPaises();
            this.treePais.Nodes.Clear();
            for (int i = 0; i < paises.Length; i++)
            {
                this.treePais.Nodes.Add(paises[i]);
            }
        }


        private void btnAPais_Click(object sender, EventArgs e)
        {

        }

        private void btnNPais_Click(object sender, EventArgs e)
        {
            
        }

        private void paisesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listaPais();
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listaProv();
        }

        private void contactosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listaContac();
        }
        private void vaciarProve()
        {
            txtNombreProv.Text = "";
            comboContacto.Items.Clear();
            comboPais.Items.Clear();
            listaProv();
            String[] paises = this.Conexion_DB.obtenerPaises();
            for (int i = 0; i < paises.Length; i++)
            {
                this.comboPais.Items.Add(paises[i]);
            }
        }
        private void vaciarContact()
        {
            TxtNombreContac.Text = "";
            txtTelefono.Text = "";
            comboProveedores.Items.Clear();
            comboCorreos.Items.Clear();
            listaContac();
        }

        private void btnNuevoProveedor_Click(object sender, EventArgs e)
        {
            if (!bandera)
            {
                vaciarProve();
                bandera = true;
            }
            else
            {
                if (txtNombreProv.Text.Length > 0)
                {
                    Conexion_DB.ingresoProveedor(txtNombreProv.Text, Conexion_DB.obtenerIdPais(comboPais.SelectedItem.ToString()));
                    vaciarProve();
                }
                else MessageBox.Show("El campo \"Nombre\" NO puede esta vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnNContacto_Click(object sender, EventArgs e)
        {
            vaciarContact();
        }


        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void treeContacto_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void treePais_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void pedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void consultaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listaProv();

        }

        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listaContac();
        }

        private void consultaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            listaPais();
        }

        private void nuevoToolStripMenuItem3_Click_1(object sender, EventArgs e)
        {
            String nuevoPais = Interaction.InputBox("Ingrese el nuevo país:", "Nuevo País");
            if (!Conexion_DB.existePais(nuevoPais)) Conexion_DB.ingresoPais(nuevoPais);
            else MessageBox.Show("El país ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            listaPais();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void nuevoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Proveedor prov = new Proveedor(0);
            prov.ShowDialog();
        }

        private void nuevoToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Proveedor prov = new Proveedor(1);
            prov.ShowDialog();
        }


    }
}
