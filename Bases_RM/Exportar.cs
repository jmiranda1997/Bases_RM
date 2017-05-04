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
    public partial class Exportar : Form
    {
        private Conexion_DB Conexion_DB = new Conexion_DB();
        private String[,] pedidos, proveedores;
        public String Nombreped, nombreprov;
        public int idPedido = -1, idProveedor;
        public Exportar()
        {
            InitializeComponent();
            pedidos = Conexion_DB.obtenerPedidos();
            if (pedidos != null && pedidos.Length > 0)
            {
                for (int i = 0; i < (pedidos.Length / 2); i++)
                {
                    comboBox1.Items.Add(pedidos[1, i]);

                }
            }
            else { MessageBox.Show("No hay pedidos para exportar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); this.Close(); }
            proveedores = Conexion_DB.obtenerArregloProveedores() ;
            if (pedidos != null && proveedores.Length > 0)
            {
                for (int i = 0; i < (proveedores.Length / 2); i++)
                {
                    comboBox2.Items.Add(proveedores[1, i]);
                }
            }
            else { MessageBox.Show("No hay Proveedores para exportar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); this.Close(); }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Exportar_Load(object sender, EventArgs e)
        {

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            idPedido = Int32.Parse(pedidos[0, comboBox1.SelectedIndex]);
            Nombreped = comboBox1.SelectedItem.ToString();
            idProveedor = Int32.Parse(pedidos[0, comboBox2.SelectedIndex]);
            nombreprov = comboBox2.SelectedItem.ToString();
            this.Close();
        }
    }
}
