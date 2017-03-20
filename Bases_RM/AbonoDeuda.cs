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
    public partial class AbonoDeuda : Form
    {
        private bool deuda;//bandera booleana para diferenciar si se utilizara el form para deudas o pagos
        Conexion_DB conexion = new Conexion_DB();
        private String nombre_tabla = "";//cadena que guardar el nombre de la tabla en que se debe agregar la informacion ingresada
        public AbonoDeuda(bool deuda, Cliente persona)
        {
            this.deuda=deuda;
            InitializeComponent();
            if (deuda)//Si la bandera booleana es verdadera, se usara el modo ingreso de deudas
            {
                nombre_tabla = "Deuda";
            }
            else//si la bandera es falsa se usara el modo de ingreso de pagos (ocultar los campos de saldo)
            {
                nombre_tabla = "Pago";
            }
            this.Text = nombre_tabla;
            String[] sucursales = conexion.obtener_sucursales();
            for (int i = 0; i < sucursales.Length; i++)
            {
                cbSucursales.Items.Add(sucursales[i]);
            }
        }
        private void AbonoDeuda_Load(object sender, EventArgs e)
        {
            if(cbSucursales.Items.Count>0)
                cbSucursales.SelectedIndex=0;
        }

        private void btnguar_Click(object sender, EventArgs e)
        {
            //conexion.ingresoPagos(1,Datetimepic.Text,Double.Parse(TxtMonto.Text),);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
