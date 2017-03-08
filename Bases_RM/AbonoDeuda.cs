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
        private String nombre_tabla = "";//cadena que guardar el nombre de la tabla en que se debe agregar la informacion ingresada
        public AbonoDeuda(bool deuda)
        {
            InitializeComponent();
            this.deuda = deuda;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void AbonoDeuda_Load(object sender, EventArgs e)
        {
            if (deuda)//Si la bandera booleana es verdadera, se usara el modo ingreso de deudas
            {
                nombre_tabla = "Deuda";
            }
            else//si la bandera es falsa se usara el modo de ingreso de pagos (ocultar los campos de saldo)
            {
                nombre_tabla = "Pagos";
                lbSaldoactu.Visible = false;
                lbSaldoant.Visible = false;
                TxtSaldoA.Visible = false;
                TxtSaldoA.Visible = false;
            }
        }
    }
}
