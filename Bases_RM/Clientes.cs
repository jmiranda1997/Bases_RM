﻿using System;
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
    public partial class Clientes : Form
    {
        private AbonoDeuda formulario=null;
        public Clientes()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lbLimiq_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbBuscar_Click(object sender, EventArgs e)
        {

        }

        private void lbNom_Click(object sender, EventArgs e)
        {

        }

        private void btnAbono_Click(object sender, EventArgs e)
        {
            formulario = new AbonoDeuda(false);
        }

        private void btnDeuda_Click(object sender, EventArgs e)
        {
            formulario = new AbonoDeuda(true);
        }

    }
}
