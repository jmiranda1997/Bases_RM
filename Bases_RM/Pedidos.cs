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

namespace Bases_RM
{
    public partial class Pedidos : Form
    {
        public DataTable DS;
        public Pedidos()
        {
            InitializeComponent();
        }
        private void Pedidos_Load(object sender, EventArgs e)
        {

        }

        private void btnimportar_Click(object sender, EventArgs e)
        {
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();

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
           
            Conexion_Fox con = new Conexion_Fox();
            con.Insertar_Codigos(pbcargar, lbprogreso);
            
        }

        private void btnexportar_Click(object sender, EventArgs e)
        {
        
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            float[] dec = decimales(lbprogreso.Text);
            label1.Text = dec[0].ToString();
            label2.Text = dec[1].ToString();
            label3.Text = dec[2].ToString();
            label4.Text = dec[3].ToString();
            label5.Text = dec[4].ToString();
            label6.Text = dec[5].ToString();
            label7.Text = dec[6].ToString();
            label8.Text = dec[7].ToString();
            label9.Text = dec[8].ToString();
            label10.Text = dec[9].ToString();
        }
        public float[] decimales(String texto)
        {
            float[] deci = null;

            string cadena = lbprogreso.Text.Trim(), txt = "";
            char[] letras = cadena.ToCharArray();
            int cont = 0;
            for (int i = 0; i < cadena.Length; i++)
            {
                if (letras[i] == ' ' && cont == 0)
                {
                    cont++;
                    txt += ",";
                }
                if (letras[i] != ' ')
                {
                    cont = 0;
                    txt += letras[i];
                }
            }
            string[] cad = txt.Split(',');
            float[] dec = new float[cad.Length];
            for (int i = 0; i < cad.Length; i++)
            {
                dec[i] = float.Parse(cad[i]);
            }

            return deci;
        }
    }


}