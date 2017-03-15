using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Timers;

namespace Bases_RM
{
    public partial class Menu : Form
    {
        public Usuario datos_us;
        public Menu(Usuario user)
        {

            InitializeComponent();

        //    btnpedidos.Enabled = false;
            Thread tare = new Thread(ejecutar);
            tare.Start();



            this.datos_us = user;
        }

        public void ejecutar(object pb)
        {
            Conexion_Fox fox = new Conexion_Fox();
            fox.Insertar_Codigos();
            //btnpedidos.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Clientes clientes = new Clientes();
            clientes.ShowDialog();

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Ordenes ordenes = new Ordenes();
            ordenes.ShowDialog();
        }

        private void btntrabajadores_Click(object sender, EventArgs e)
        {
            Trabajadores trab = new Trabajadores();
            trab.ShowDialog();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void btnseguridad_Click(object sender, EventArgs e)
        {
            this.Hide();
            Seguridad1 segu = new Seguridad1(datos_us);
            segu.Show();
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
