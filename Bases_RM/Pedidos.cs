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
        public String hola = "";
        public Pedidos()
        {
            InitializeComponent();
            
        }

        private void Pedidos_Load(object sender, EventArgs e)
        {

        }

        private void btnimportar_Click(object sender, EventArgs e)
        {
            string direccion;
            //creamos un objeto OpenDialog que es un cuadro de dialogo para buscar archivos
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Archivos de Excel (*.xls;*.xlsx)|*.xls;*.xlsx"; //le indicamos el tipo de filtro en este caso que busque
            //solo los archivos excel

            dialog.Title = "Seleccione el archivo de Excel";//le damos un titulo a la ventana

            dialog.FileName = string.Empty;//inicializamos con vacio el nombre del archivo

            //si al seleccionar el archivo damos Ok
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //el nombre del archivo sera asignado al textbox
                direccion = dialog.FileName;
                LlenarGrid(direccion, "Hoja1"); //se manda a llamar al metodo

                dgpedido.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; //se ajustan las
                //columnas al ancho del DataGridview para que no quede espacio en blanco (opcional)
            }


        }
        private void LlenarGrid(string archivo, string hoja)
        {
            string strConnnectionOle = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
                    @"Data Source=" + archivo + ";" +
                    @"Extended Properties=" + '"' + "Excel 12.0;HDR=YES" + '"';
            string sqlExcel = "Select * From [" + hoja + "$]";
            DataTable DS = new DataTable();
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
    }

}