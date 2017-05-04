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
        public Usuario usuario;
        public Menu(Usuario user)
        {
            InitializeComponent();
            this.usuario = user;
        }

        public void ejecutar()
        {
            Conexion_Fox fox = new Conexion_Fox();
            fox.Insertar_Codigos();
        }
        public void ejecutar2()
        {
            Conexion_Fox fox = new Conexion_Fox();
            fox.Insertar_Codigos();
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
            for (int i = 0; i < usuario.pClientes.Count; i++)
			{
                if (usuario.pClientes.ElementAt(i))
                {
                    btnclientes.Enabled = true;
                }
			}
            for (int i = 0; i < usuario.pPedidos.Count; i++)
            {
                if (usuario.pPedidos.ElementAt(i))
                {
                    btnpedidos.Enabled = true;
                }
            }
            for (int i = 0; i < usuario.pTrabajadores.Count; i++)
            {
                if (usuario.pTrabajadores.ElementAt(i))
                {
                    btntrabajadores.Enabled = true;
                }
            }
        }

        private void btnseguridad_Click(object sender, EventArgs e)
        {
            Seguridad1 segu = new Seguridad1(usuario);
            segu.ShowDialog();
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            actualizar();
            btnactualizarpedidos.Enabled = false;
        }
        private void actualizar()
        {
            Thread tare = new Thread(ejecutar);
            tare.Start();
        }

        private void Menu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == Convert.ToChar(Keys.F10))
            {
                if (btnactualizarpedidos.Enabled)
                {
                    actualizar();
                    btnactualizarpedidos.Enabled = false;
                }
            }
        }

        private void btnclientes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == Convert.ToChar(Keys.F10))
            {
                if (btnactualizarpedidos.Enabled)
                {
                    actualizar();
                    btnactualizarpedidos.Enabled = false;
                }
            }
        }

        private void btnpedidos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == Convert.ToChar(Keys.F10))
            {
                if (btnactualizarpedidos.Enabled)
                {
                    actualizar();
                    btnactualizarpedidos.Enabled = false;
                }
            }
        }

        private void btntrabajadores_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == Convert.ToChar(Keys.F10))
            {
                if (btnactualizarpedidos.Enabled)
                {
                    actualizar();
                    btnactualizarpedidos.Enabled = false;
                }
            }
        }

        private void btnseguridad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == Convert.ToChar(Keys.F10))
            {
                if (btnactualizarpedidos.Enabled)
                {
                    actualizar();
                    btnactualizarpedidos.Enabled = false;
                }
            }
        }

        private void btnsalir_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == Convert.ToChar(Keys.F10))
            {
                if (btnactualizarpedidos.Enabled)
                {
                    actualizar();
                    btnactualizarpedidos.Enabled = false;
                }
            }
        }

        private void btnactualizarpedidos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == Convert.ToChar(Keys.F10))
            {
                if (btnactualizarpedidos.Enabled)
                {
                    actualizar();
                    btnactualizarpedidos.Enabled = false;
                }
            }
        }
    }
}
