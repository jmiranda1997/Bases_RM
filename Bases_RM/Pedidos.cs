using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Threading;

namespace Bases_RM
{
    public partial class Pedidos : Form
    {
        public DataTable DS;
        public Pedidos(int maximo)
        {
            InitializeComponent();
            pbprogreso.Maximum = maximo;
            pbprogreso.Minimum = 0;
        }

        public void progreso( String Progreso)
        {
            pbprogreso.Value++;
            lbprogreso.Text = Progreso + "/"+ pbprogreso.Maximum;
        }
        private void Pedidos_Load(object sender, EventArgs e)
        {

        }

        private void btnimportar_Click(object sender, EventArgs e)
        {
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dgpedido_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void listoToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
            
        }

        private void archivoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        
        private void btnabrir_Click(object sender, EventArgs e)
        {

        }

        private void btnexportar_Click(object sender, EventArgs e)
        {
        
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           
        }
        public void hilo(ProgressBar p, Label l)
        {
            
        }
       
    }


}