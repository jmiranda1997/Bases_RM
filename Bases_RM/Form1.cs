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
    
    public partial class Form1 : Form
    {
        private Conexion_DB Conexion_DB;
        public Form1()
        {
            InitializeComponent();
            try
            {
                Conexion_DB = new Conexion_DB();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Conexion_DB.Guardar();
        }
    }
}
