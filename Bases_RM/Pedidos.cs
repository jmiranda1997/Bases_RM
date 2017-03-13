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
            Conexion_DB conexion = new Conexion_DB();
            OleDbConnection oleDbConnection1 = new OleDbConnection("Provider=VFPOLEDB.1; Data Source=C:\\;");
            DS = new DataTable();

            try
            {
                oleDbConnection1.Open();
                OleDbCommand comando = new OleDbCommand("SELECT Uni01 FROM INVENT.DBF WHERE Codigo = '01001'", oleDbConnection1);
                OleDbDataAdapter da = new OleDbDataAdapter(comando); 
                OleDbDataReader dato = comando.ExecuteReader();
                //da.Fill(DS);
                //dgpedido.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                //dgpedido.DataSource = DS;
                if (dato.Read())
                {
                    lbprogreso.Text = dato["Uni01"].ToString();
                }

                oleDbConnection1.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private string selector_Archivos()
        {
            string direccion = "";
            //creamos un objeto OpenDialog que es un cuadro de dialogo para buscar archivos
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Archivos de Excel (*.xls;*.xlsx)|*.xls;*.xlsx"; //le indicamos el tipo de filtro en este caso que busque
            //solo los archivos excel

            dialog.Title = "Seleccione el archivo de Excel";//le damos un titulo a la ventana

            dialog.FileName = string.Empty;//inicializamos con vacio el nombre del archivo

            //si al seleccionar el archivo damos Ok
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                direccion = dialog.FileName;
            }

            return direccion;
        }
        private void LlenarGrid(string archivo)
        {
            string strConnnectionOle = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
                    @"Data Source=" + archivo + ";" +
                    @"Extended Properties=" + '"' + "Excel 12.0;HDR=YES" + '"';
            string sqlExcel = "Select * From [Hoja1$]";
            DS = new DataTable();
            OleDbConnection oledbConn = new OleDbConnection(strConnnectionOle);
            try
            {
                oledbConn.Open();
                OleDbCommand oledbCmd = new OleDbCommand(sqlExcel, oledbConn);
                OleDbDataAdapter da = new OleDbDataAdapter(oledbCmd);

                da.Fill(DS);
                dgpedido.DataSource = DS;
                oledbConn.Close();
                dgpedido.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgpedido.HorizontalScrollingOffset = dgpedido.VerticalScrollingOffset;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
            Conexion_DB conexion = new Conexion_DB();
            OleDbConnection oleDbConnection1 = new OleDbConnection("Provider=VFPOLEDB.1; Data Source=C:\\;");
            int codigos=0;
            oleDbConnection1.Open();
            OleDbCommand comando = new OleDbCommand("SELECT COUNT(*) FROM INVENT.DBF", oleDbConnection1);

            OleDbDataReader dato = comando.ExecuteReader();
            if (dato.Read())
            {
                codigos=int.Parse(dato[0].ToString());
                oleDbConnection1.Close();
                oleDbConnection1.Open();
                comando = new OleDbCommand("SELECT codigo, codigobarr, articulo1, costo, venta1, marca1, marca2 FROM INVENT.DBF", oleDbConnection1);
                dato = comando.ExecuteReader();
                pbcargar.Maximum = codigos;
                while (dato.Read())
                {
                    pbcargar.Value += 1;
                    conexion.ingresoProducto(dato["codigo"].ToString(), dato["codigobarr"].ToString(), dato["marca1"].ToString(), dato["marca1"].ToString(), dato["marca2"].ToString(), double.Parse(dato["costo"].ToString()), double.Parse(dato["venta1"].ToString()));
                }
            }
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