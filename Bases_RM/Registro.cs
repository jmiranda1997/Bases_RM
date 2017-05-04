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
    public partial class Registro : Form
    {
        private bool deuda;
        Conexion_DB conexion = new Conexion_DB();
        String[,] sucursales;
        Cliente cliente = null;
        public Registro(bool deuda, Cliente cliente)
        {
            InitializeComponent();
            this.deuda = deuda;
            sucursales = conexion.obtener_sucursales();
            this.cliente = cliente;
        }

        private void Registro_Load(object sender, EventArgs e)
        {
            txtNombre.Text = cliente.nombre;
            txtApe.Text = cliente.apellido;
            cbSucursales.Items.Add("General");
            for(int i=0;i<sucursales.Length/2;i++)
            {
                cbSucursales.Items.Add(sucursales[i, 0]);
            }
            cbSucursales.SelectedIndex = 0;
            dataGridView1.DataSource = conexion.tabla(deuda, cliente.id, 0);

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void cbSucursales_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(cbSucursales.Text))
            {
                if(cbSucursales.SelectedIndex==0)
                {
                    dataGridView1.DataSource = conexion.tabla(deuda,cliente.id,0);
                }
                else
                {
                    dataGridView1.DataSource = conexion.tabla(deuda, cliente.id, int.Parse(sucursales[cbSucursales.SelectedIndex-1,1]));
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
