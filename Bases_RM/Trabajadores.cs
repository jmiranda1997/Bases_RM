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
    public partial class Trabajadores : Form
    {
      
        private Conexion_DB Conexion_DB;
        private TrabajadoresClass trab;
        private bool permitir = false;    
       

        public Trabajadores()
        {
            InitializeComponent();
            try
            {
                this.Conexion_DB = new Conexion_DB();
                String[] trabajadores = this.Conexion_DB.obtener_Trabajadores();
                for (int i = 0; i < trabajadores.Length; i++)
                {
                    trabajadoresTree.Nodes.Add(trabajadores[i]);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Error2", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            trabajadoresTree.SelectedNode = trabajadoresTree.SelectedNode.PrevNode;
            trabajadoresTree.Select();
        }

        private void TxtSala_TextChanged(object sender, EventArgs e)
        {

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            String Nombre = trabajadoresTree.SelectedNode.Text;
            trab = Conexion_DB.obtener_Trabajador(Nombre.Trim());
            if (trab != null) {
                String[] sucursales = Conexion_DB.obtener_sucursales();
                for (int i = 0; i < sucursales.Length; i++)
                {
                    ComboSucu.Items.Add(sucursales[i]);
                }
                TxtNom.Text = trab.Nombre;
                TxtSala.Text = trab.Salario.ToString();
            }
        }

        private void TxtNom_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtSucu_TextChanged(object sender, EventArgs e)
        {

        }

        private void ComboSucu_SelectedIndexChanged(object sender, EventArgs e)
        {
            Conexion_DB.obtener_sucursales();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            trabajadoresTree.SelectedNode = trabajadoresTree.SelectedNode.NextNode;
            trabajadoresTree.Select();
        }

        private void archivoToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void nuevoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!permitir)
            {
                permitir = true;
                nuevoToolStripMenuItem.Text = "Ver";
                btnMG.Text = "Guardar";
                btnEC.Text = "Cancelar";
                TxtNom.Enabled = true;
                TxtSala.Enabled = true;
            }
            else
            {
                permitir = false;
                nuevoToolStripMenuItem.Text = "Nuevo";
                btnMG.Text = "Modificar";
                btnEC.Text = "Eliminar";
                TxtNom.Enabled = false;
                TxtSala.Enabled = false;
            }
        }

        private void btnMG_Click(object sender, EventArgs e)
        {
            if (permitir)
            {
                if (campos_vacios())
                {
                    MessageBox.Show("Uno o mas campos estan vacios", "Error");
                }
                else
                {
                    try
                    {
                        String sucu = ComboSucu.Text; //////////////////////////////////////////////////////////////
                        Conexion_DB.ingresoTrabajador(TxtNom.Text, double.Parse(TxtSala.Text),int.Parse(sucu));/////////////////////////
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Algunos datos no son validos");
                    }
                }
                {

                }
            }
        }
        private bool campos_vacios()
        {
            bool campos_nulos = false;
            if (String.IsNullOrEmpty(TxtNom.Text))
                campos_nulos = true;
            if (String.IsNullOrEmpty(TxtSala.Text))
                campos_nulos = true;
            if (String.IsNullOrEmpty(ComboSucu.Text))
                campos_nulos = true;
            return campos_nulos;
        }
    }
}
