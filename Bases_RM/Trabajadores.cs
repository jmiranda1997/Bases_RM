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

        }

        private void button4_Click(object sender, EventArgs e)
        {
            trabajadoresTree.SelectedNode = trabajadoresTree.SelectedNode.NextNode;
            trabajadoresTree.Select();
        }
    }
}
