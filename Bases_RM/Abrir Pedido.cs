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
    public partial class Abrir_Pedido : Form
    {
        private Conexion_DB Conexion_DB = new Conexion_DB();
        private String[,] pedidos;
        public String Nombre;
        public int idSeleccion = -1;
        public Abrir_Pedido()
        {
            InitializeComponent();
            pedidos = Conexion_DB.obtenerPedidos();
            if (pedidos != null && pedidos.Length > 0)
            {
                for (int i = 0; i < (pedidos.Length / 2); i++)
                {
                    comboPedidos.Items.Add(pedidos[1, i]);

                }
            }
            else comboPedidos.Items.Add("No hay Pedidos en la base de datos");

        }
        private int existe(String elemento)
        {
            int cant = 0;

            for (int i = 0; i < comboPedidos.Items.Count; i++)
            {
                if (comboPedidos.Items[i].Equals(elemento)) cant++;
            }

            return cant;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Abrir_Pedido_Load(object sender, EventArgs e)
        {

        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            idSeleccion = Int32.Parse(pedidos[0, comboPedidos.SelectedIndex]);
            Nombre = comboPedidos.SelectedItem.ToString();
            this.Close();
        }
    }
}
