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
    public partial class Proveedor : Form
    {
        private int estado;
        private Conexion_DB Conexion_DB;
        private String [,] lista;
        String[,] lista2;
        public Proveedor(int estado)
        {
            InitializeComponent();
            this.estado = estado;
            Conexion_DB = new Conexion_DB();
            if (this.estado == 0)
            {
                this.Text = "Nuevo Proveedor";
                groupContacto.Visible = false;
                groupProveedor.Visible = true;
                lista = Conexion_DB.obtenerArregloContactos();
                for (int i = 0; i < lista.Length / 2; i++)
                {
                    treeView.Nodes.Add(lista[1, i]);
                }
                lista2 = Conexion_DB.obtenerArregloPaises();
                for (int i = 0; i < lista2.Length / 2; i++)
                {
                    comboPais.Items.Add(lista2[1, i]);
                }
            }
            else
            {
                this.Text = "Nuevo Contacto";
                groupContacto.Visible = true;
                groupProveedor.Visible = false;
                lista = Conexion_DB.obtenerArregloContactos();
                for (int i = 0; i < lista.Length / 2; i++)
                {
                    treeView.Nodes.Add(lista[1, i]);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Proveedor_Load(object sender, EventArgs e)
        {

        }

        private void btnAContacto_Click(object sender, EventArgs e)
        {
            if(treeView.SelectedNode.Index != -1){
                comboContacto.Items.Add(treeView.SelectedNode.Text);
            }
        }

        private void btnQContacto_Click(object sender, EventArgs e)
        {
            if (comboContacto.SelectedIndex != -1)
            {
                comboContacto.Items.Remove(comboContacto.SelectedItem);
                comboContacto.Text = "";
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (estado == 0)
            {
                Conexion_DB.ingresoProveedor(txtNombreProv.Text, obtenerIdPais(comboPais.Text));
                int id = Conexion_DB.obtenerIdProveedor(txtNombreProv.Text);
                for (int i = 0; i < comboContacto.Items.Count; i++)
                {
                    comboContacto.SelectedIndex = i;
                    Conexion_DB.ingresoEncargProv(obtenerIdContacto(comboContacto.Text), id);
                }
                MessageBox.Show("Proeveedor creado", "Enhorabuena", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Conexion_DB.ingresoEncargado(TxtNombreContac.Text, txtCorreo.Text);
                int id = Conexion_DB.obtenerIdEncargado(TxtNombreContac.Text);
                for (int i = 0; i < comboTelefono.Items.Count; i++)
                {
                    comboTelefono.SelectedIndex = i;
                    Conexion_DB.ingresoTelefonoProv(comboTelefono.Text, id);
                }
                MessageBox.Show("Contacto Creado", "Enhorabuena", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.Close();
        
        }
        private int obtenerIdPais(String Nombre)
        {
            int id = 0;
            for (int i = 0; i < lista2.Length / 2; i++)
            {
                if (Nombre.Equals(lista2[1, i]))
                {
                    id = Int32.Parse(lista2[0,i]);
                    return id;
                }
            }
            return 0;
        }
        private int obtenerIdContacto(String Contacto)
        {
            int id = 0;
            for (int i = 0; i < lista.Length / 2; i++)
            {
                if (Contacto.Equals(lista[1, i]))
                {
                    id = Int32.Parse(lista[0, i]);
                    return id;
                }
            }
            return 0;
        }

        private void btnACorreo_Click(object sender, EventArgs e)
        {
            String NuevoNum = Interaction.InputBox("Ingrese el nuevo número de telefono:", "Nuevo Telefono");
            comboTelefono.Items.Add(NuevoNum);
        }
    }
}
