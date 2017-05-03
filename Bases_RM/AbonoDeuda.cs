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
        private double saldoSucursal, totalSaldo;//variables double para guardar el saldo total del cliente y el saldo total en una sucursal
        Conexion_DB conexion = new Conexion_DB();
        String[,] sucursales;
        Cliente cliente = null;
        public AbonoDeuda(bool deuda, Cliente persona)
        {
            this.deuda=deuda;
            cliente = persona;
            InitializeComponent();
            totalSaldo = conexion.obtener_saldoTotal(cliente.id, 0);
            if (deuda)//Si la bandera booleana es verdadera, se usara el modo ingreso de deudas
            {
                this.Text = "Deuda";
                if (totalSaldo > cliente.limite)
                {
                    lblError.Text = "ESTE CLIENTE HA SOBREPASADO SU LIMITE DE CREDITO POR: " + (-cliente.limite + totalSaldo).ToString("N2");
                }
            }
            else//si la bandera es falsa se usara el modo de ingreso de pagos (ocultar los campos de saldo)
            {
                this.Text = "Pago";
            }
            sucursales = conexion.obtener_sucursales();
            for (int i = 0; i < sucursales.Length/2; i++)
            {
                cbSucursales.Items.Add(sucursales[i,0]);
            }
            
        }
        private void AbonoDeuda_Load(object sender, EventArgs e)
        {
            txtNom.Text = cliente.nombre;
            txtApe.Text = cliente.apellido;
            txtSaldoT.Text = totalSaldo.ToString("N2");
            
  
        }
        private void btnguar_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(cbSucursales.Text))//Se comprueba si la cadena no es vacia ni nula
            {
                if(double.Parse(TxtMonto.Text)>0)//se verifica que el monto sea mayor a 0
                {
                    if (deuda)//Si la bandera es true, el formulario esta en modo deuda
                    {
                        try
                        {
                            int idDeuda=conexion.obtener_idDeuda(Datetimepic.Value.Month,Datetimepic.Value.Year,cliente.id,int.Parse(sucursales[cbSucursales.SelectedIndex,1]));
                            if (idDeuda == 0)//Si el saldo anterior es igual a 0, es una nueva deuda
                            {
                                conexion.ingresoDeuda(Datetimepic.Text, double.Parse(TxtMonto.Text), cliente.id, int.Parse(sucursales[cbSucursales.SelectedIndex, 1])); 
                            }
                            else
                            {
                                conexion.modificacionDeuda(idDeuda, Datetimepic.Value, double.Parse(TxtMonto.Text));
                            }
                            MessageBox.Show("Deuda ingresada con exito", "Deuda");
                            this.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ocurrio un error" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        try
                        {
                            if (double.Parse(TxtMonto.Text) <= saldoSucursal)
                            {
                                conexion.ingresoPagoDeuda(Datetimepic.Value, double.Parse(TxtMonto.Text), cliente.id, int.Parse(sucursales[cbSucursales.SelectedIndex, 1]));
                                MessageBox.Show("Pago ingresado con exito", "Pago");
                                this.Close();
                            }
                            else
                                MessageBox.Show("El monto no es valido", "Pago");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ocurrio un error" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                    MessageBox.Show("No se ingreso un monto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("No se ha seleccionado una sucursal","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbSucursales_SelectedIndexChanged(object sender, EventArgs e)
        {
            saldoSucursal = conexion.obtener_saldoTotal(cliente.id, int.Parse(sucursales[cbSucursales.SelectedIndex, 1]));
            TxtSaldoA.Text = saldoSucursal + "";
            TxtSaldoA.Text = saldoSucursal.ToString("N2");
            if (deuda)
            {     
                TxtSaldoActu.Text = (saldoSucursal + double.Parse(TxtMonto.Text)).ToString("N2");
            }
            else
            {
                TxtSaldoActu.Text = (saldoSucursal - double.Parse(TxtMonto.Text)).ToString("N2");
                if (saldoSucursal < double.Parse(TxtMonto.Text) && !String.IsNullOrEmpty(cbSucursales.Text))
                    lblError.Text = "ESTE MONTO SUPERA LA DEUDA DE LA SUCURSAL POR: " + (-saldoSucursal + double.Parse(TxtMonto.Text)).ToString("N2");
                else
                    lblError.Text = "";
            }
        }

        private void TxtMonto_Leave(object sender, EventArgs e)
        {
            if(TxtMonto.Text!="")
                TxtMonto.Text = double.Parse(TxtMonto.Text).ToString("N2");
            else
                TxtMonto.Text = double.Parse("0").ToString("N2");
            if(deuda)
            {
                TxtSaldoActu.Text = (saldoSucursal + double.Parse(TxtMonto.Text)).ToString("N2");
                if (totalSaldo > cliente.limite)
                    lblError.Text = "ESTE CLIENTE HA SOBREPASADO SU LIMITE DE CREDITO POR: " + (-cliente.limite + totalSaldo).ToString("N2");
                else if (double.Parse(TxtMonto.Text) + totalSaldo > cliente.limite)
                    lblError.Text = "CON ESTA DEUDA SE HA SOBREPASADO EL LIMITE DE CREDITO POR: " + (double.Parse(TxtMonto.Text) + totalSaldo - cliente.limite).ToString("N2");
                else
                    lblError.Text = "";
            }
            else
            {
                TxtSaldoActu.Text = (saldoSucursal - double.Parse(TxtMonto.Text)).ToString("N2");
                if (saldoSucursal<double.Parse(TxtMonto.Text) && !String.IsNullOrEmpty(cbSucursales.Text))
                    lblError.Text = "ESTE MONTO SUPERA LA DEUDA EN LA SUCURSAL POR: " + (-saldoSucursal + double.Parse(TxtMonto.Text)).ToString("N2");
                else
                    lblError.Text = "";
            }

        }

        private void TxtMonto_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==(char)Keys.Return)
            {
                btnguar.Focus();
            }
        }

        private void lbSaldoant_Click(object sender, EventArgs e)
        {

        }

        private void TxtSaldoA_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtSaldoActu_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
