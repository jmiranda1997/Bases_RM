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
        Conexion_DB conexion = new Conexion_DB();
        private String nombre_tabla = "";
        public Pagos(Trabajadores Trab)
        {
            InitializeComponent();

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
    }
}
