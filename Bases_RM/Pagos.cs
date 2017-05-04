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
    public partial class Pagos : Form
    {
        private bool deuda;
        Conexion_DB Conexion_DB = new Conexion_DB();
        private TrabajadoresClass trab;
        private String nombre_tabla = "";
        public Pagos(Trabajadores Trab)
        {
            InitializeComponent();
            try
            {
                this.Conexion_DB = new Conexion_DB();
                String[] trabajadores = this.Conexion_DB.obtener_Trabajadordesha1();
                for (int i = 0; i < trabajadores.Length; i++)
                {
                    trabajadoresTree.Nodes.Add(trabajadores[i]);
                }
                String[,] sucus = this.Conexion_DB.obtener_sucursales("");
                for (int i = 0; i < Conexion_DB.obtener_Nbodegas(); i++)
                {
                    Sucu.Text = (sucus[1, i]).ToString();
                }
                TxtNom.Enabled = false;
                Sucu.Enabled = false;
                TxtSalMes.Enabled = false;
                TxtSalActu.Enabled = false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Error2", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
       }

        public int obtener_TrabajadorID(String Nom)
        {
            int cont = 0;
            String[,] Sucu = Conexion_DB.obtener_Trabajadores1("");
            while (cont < Conexion_DB.obtener_IDTrabajador())
            {
                if (Nom == Sucu[1, cont])
                {
                    break;
                }
                cont++;
            }
            return int.Parse(Sucu[0, cont]);




            //String[,] sucursales = conexion.obtener_sucursales();
            //for (int i = 0; i < sucursales.Length/2; i++)
            //{
            //    ComboSucu.Items.Add(sucursales[1,i]);
            //}




        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Pagos_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void trabajadoresTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            String Nombre = trabajadoresTree.SelectedNode.Text;
            trab = Conexion_DB.obtener_Trabajador(Nombre.Trim());
            if (trab != null)
            {
                TxtNom.Text = trab.Nombre.Trim();
                Sucu.Text = Conexion_DB.obtener_Nombredemens(trab.Sucursal_ID);
                TxtSalMes.Text = Conexion_DB.Obtener_MontoTrab(obtener_TrabajadorID(TxtNom.Text).ToString()).ToString();
                TxtSalActu.Text = TxtSalMes.Text;
            }

        }

        private void btnIzq_Click(object sender, EventArgs e)
        {
            trabajadoresTree.SelectedNode = trabajadoresTree.SelectedNode.PrevNode;
            trabajadoresTree.Select();
        }

        private void btnDer_Click(object sender, EventArgs e)
        {
            trabajadoresTree.SelectedNode = trabajadoresTree.SelectedNode.NextNode;
            trabajadoresTree.Select();
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void BtnCan_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnG_Click(object sender, EventArgs e)
        {
            double cancelar = 0, actual = 0, nuevo = 0;
            cancelar = double.Parse(TxtMon.Text);
            actual = double.Parse(TxtSalMes.Text);
            nuevo = actual - cancelar;
            if (nuevo < 0)
            {
                MessageBox.Show("No puede descontar ya que el saldo es '0' o le desconto mas de la cuenta...", "¡ERROR!");
            }
            else
            {
                TxtSalActu.Text = nuevo.ToString();
                Conexion_DB.ActualizarMonto(obtener_TrabajadorID(TxtNom.Text).ToString(), nuevo.ToString());
                TxtSalMes.Text = nuevo.ToString();
                MessageBox.Show("Monto descontado exitosamente...", "¡EXITO!");
            }

        }
    }
}
