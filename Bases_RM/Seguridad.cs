using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Bases_RM
{
    public partial class Seguridad : Form
    {
        private Conexion_DB conexion=new Conexion_DB();
        private Usuario user;
        private String clave = "3JOR";
        private bool modificacion = false;
        public Seguridad(/*Usuario user*/)
        {
            InitializeComponent();
            //this.user = user;
            user = new Usuario("a", "q", null, null, null, null);
        }
        private void modificaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String[] usuarios = conexion.obtenerUsuarios();
            if (usuarios.Length != 0)
            {
                for (int i = 0; i < usuarios.Length; i++)
                {
                    userCombo.Items.Add(usuarios[i]);
                }
                modificarPanel.Visible = true;
                aceptarButton.Enabled = true;
                cancelarButton.Enabled = true;
                menuStrip1.Enabled = false;
                modificacion = true;
            }
           
        }

        private void userCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((userCombo.SelectedIndex != -1)&&modificacion)
            {
                todoGroup.Enabled = true;
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limpiar();
            this.Close();
        }

        private void ingresoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ingresoPanel.Visible = true;
            aceptarButton.Enabled = true;
            cancelarButton.Enabled = true;
            menuStrip1.Enabled = false;
            todoGroup.Enabled = true;
        }

        private void aceptarButton_Click(object sender, EventArgs e)
        {
            if (ingresoPanel.Visible)
            {
                if (contraText1.Text == contraText2.Text)
                {
                    //Ingreso a la cadena de todos los permisos de usuarios
                    String usuarios = "";
                    if (uIngresoCheck.Checked == true)
                        usuarios += "1";
                    else
                        usuarios += "0";
                    if (uModificacionCheck.Checked == true)
                        usuarios += "1";
                    else
                        usuarios += "0";
                    if (uEliminacionCheck.Checked == true)
                        usuarios += "1";
                    else
                        usuarios += "0";
                    //Ingreso a la cadena de todos los permisos de clientes
                    String clientes = "";
                    if (cIngresoCheck.Checked == true)
                        clientes += "1";
                    else
                        clientes += "0";
                    if (cModificacionCheck.Checked == true)
                        clientes += "1";
                    else
                        clientes += "0";
                    if (cExportarCheck.Checked == true)
                        clientes += "1";
                    else
                        clientes += "0";
                    if (cIDeudasCheck.Checked == true)
                        clientes += "1";
                    else
                        clientes += "0";
                    if (cIPagosCheck.Checked == true)
                        clientes += "1";
                    else
                        clientes += "0";
                    if (cMDeudasCheck.Checked == true)
                        clientes += "1";
                    else
                        clientes += "0";
                    if (cMPagosCheck.Checked == true)
                        clientes += "1";
                    else
                        clientes += "0";
                    if (cADeudasCheck.Checked == true)
                        clientes += "1";
                    else
                        clientes += "0";
                    if (cAPagosCheck.Checked == true)
                        clientes += "1";
                    else
                        clientes += "0";
                    if (cCuentaCheck.Checked == true)
                        clientes += "1";
                    else
                        clientes += "0";
                    //Ingreso cadena de todos los permisos de pedidos
                    String pedidos = "";
                    if (pIngresoCheck.Checked == true)
                        pedidos += "1";
                    else
                        pedidos += "0";
                    if (pModificacionCheck.Checked == true)
                        pedidos += "1";
                    else
                        pedidos += "0";
                    if (pConsultaCheck.Checked == true)
                        pedidos += "1";
                    else
                        pedidos += "0";
                    if (pExportarCheck.Checked == true)
                        pedidos += "1";
                    else
                        pedidos += "0";
                    //Ingreso cadena de todos los permisos de trabajadores
                    String trabajadores = "";
                    if (tIngresoCheck.Checked == true)
                        trabajadores += "1";
                    else
                        trabajadores += "0";
                    if (tModificacionCheck.Checked == true)
                        trabajadores += "1";
                    else
                        trabajadores += "0";
                    if (tEliminacionCheck.Checked == true)
                        trabajadores += "1";
                    else
                        trabajadores += "0";
                    if (tIPrestamoCheck.Checked == true)
                        trabajadores += "1";
                    else
                        trabajadores += "0";
                    if (tIPagosCheck.Checked == true)
                        trabajadores += "1";
                    else
                        trabajadores += "0";
                    if (tMPrestamoCheck.Checked == true)
                        trabajadores += "1";
                    else
                        trabajadores += "0";
                    if (tMPagosCheck.Checked == true)
                        trabajadores += "1";
                    else
                        trabajadores += "0";
                    if (tAPrestamoCheck.Checked == true)
                        trabajadores += "1";
                    else
                        trabajadores += "0";
                    if (tAPagoCheck.Checked == true)
                        trabajadores += "1";
                    else
                        trabajadores += "0";
                    //Comprobación de que por lo menos tenga 1 permiso
                    if (!usuarios.Equals("000") || !clientes.Equals("0000000000") || !pedidos.Equals("0000") || !trabajadores.Equals("000000000"))
                    {
                        Vigenere seg = new Vigenere();
                        seg.cifrar(usuarios, clave);
                        String sUsuarios = seg.getMC();
                        seg.cifrar(clientes, clave);
                        String sClientes = seg.getMC();
                        seg.cifrar(pedidos, clave);
                        String sPedidos = seg.getMC();
                        seg.cifrar(trabajadores, clave);
                        String sTrabajadores = seg.getMC();
                        try{
                            conexion.ingresoUsuario(userText.Text, contraText1.Text, sPedidos, sClientes, sTrabajadores,sUsuarios);
                            MessageBox.Show("Ingreso exitoso", "Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            limpiar();
                        }catch(Exception ex)
                        {
                            MessageBox.Show(ex.ToString(),"Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar al menos un permiso", "Atencíón", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Las contraseñas no coinciden","Error",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                    contraText1.SelectAll();
                    contraText2.Clear();
                    contraText1.Focus();
                }
            }
            else if (modificacion&&modificarPanel.Visible)
            {
                //Ingreso a la cadena de todos los permisos de usuarios
                String usuarios = "";
                if (uIngresoCheck.Checked == true)
                    usuarios += "1";
                else
                    usuarios += "0";
                if (uModificacionCheck.Checked == true)
                    usuarios += "1";
                else
                    usuarios += "0";
                if (uEliminacionCheck.Checked == true)
                    usuarios += "1";
                else
                    usuarios += "0";
                //Ingreso a la cadena de todos los permisos de clientes
                String clientes = "";
                if (cIngresoCheck.Checked == true)
                    clientes += "1";
                else
                    clientes += "0";
                if (cModificacionCheck.Checked == true)
                    clientes += "1";
                else
                    clientes += "0";
                if (cExportarCheck.Checked == true)
                    clientes += "1";
                else
                    clientes += "0";
                if (cIDeudasCheck.Checked == true)
                    clientes += "1";
                else
                    clientes += "0";
                if (cIPagosCheck.Checked == true)
                    clientes += "1";
                else
                    clientes += "0";
                if (cMDeudasCheck.Checked == true)
                    clientes += "1";
                else
                    clientes += "0";
                if (cMPagosCheck.Checked == true)
                    clientes += "1";
                else
                    clientes += "0";
                if (cADeudasCheck.Checked == true)
                    clientes += "1";
                else
                    clientes += "0";
                if (cAPagosCheck.Checked == true)
                    clientes += "1";
                else
                    clientes += "0";
                if (cCuentaCheck.Checked == true)
                    clientes += "1";
                else
                    clientes += "0";
                //Ingreso cadena de todos los permisos de pedidos
                String pedidos = "";
                if (pIngresoCheck.Checked == true)
                    pedidos += "1";
                else
                    pedidos += "0";
                if (pModificacionCheck.Checked == true)
                    pedidos += "1";
                else
                    pedidos += "0";
                if (pConsultaCheck.Checked == true)
                    pedidos += "1";
                else
                    pedidos += "0";
                if (pExportarCheck.Checked == true)
                    pedidos += "1";
                else
                    pedidos += "0";
                //Ingreso cadena de todos los permisos de trabajadores
                String trabajadores = "";
                if (tIngresoCheck.Checked == true)
                    trabajadores += "1";
                else
                    trabajadores += "0";
                if (tModificacionCheck.Checked == true)
                    trabajadores += "1";
                else
                    trabajadores += "0";
                if (tEliminacionCheck.Checked == true)
                    trabajadores += "1";
                else
                    trabajadores += "0";
                if (tIPrestamoCheck.Checked == true)
                    trabajadores += "1";
                else
                    trabajadores += "0";
                if (tIPagosCheck.Checked == true)
                    trabajadores += "1";
                else
                    trabajadores += "0";
                if (tMPrestamoCheck.Checked == true)
                    trabajadores += "1";
                else
                    trabajadores += "0";
                if (tMPagosCheck.Checked == true)
                    trabajadores += "1";
                else
                    trabajadores += "0";
                if (tAPrestamoCheck.Checked == true)
                    trabajadores += "1";
                else
                    trabajadores += "0";
                if (tAPagoCheck.Checked == true)
                    trabajadores += "1";
                else
                    trabajadores += "0";
                 //Comprobación de que por lo menos tenga 1 permiso
                if (!usuarios.Equals("000") || !clientes.Equals("0000000000") || !pedidos.Equals("0000") || !trabajadores.Equals("000000000"))
                {
                    Vigenere seg = new Vigenere();
                    seg.cifrar(usuarios, clave);
                    String sUsuarios = seg.getMC();
                    seg.cifrar(clientes, clave);
                    String sClientes = seg.getMC();
                    seg.cifrar(pedidos, clave);
                    String sPedidos = seg.getMC();
                    seg.cifrar(trabajadores, clave);
                    String sTrabajadores = seg.getMC();
                    try
                    {
                        conexion.modificacionUsuario(userCombo.Text, sPedidos, sClientes, sTrabajadores, sUsuarios);
                        MessageBox.Show("Modificación exitosa", "Modificación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        limpiar();
                    }catch(Exception ex)
                    {
                        MessageBox.Show(ex.ToString(),"Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    }
                }
            }
            else if (!modificacion&&modificarPanel.Enabled)
            {
                if (userCombo.SelectedIndex != -1)
                {
                    if (MessageBox.Show("¿Esta seguro que desea eliminar al usuario '" + userCombo.Text+"'?", "Precaución", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        try
                        {
                            conexion.eliminacionUsuario(userCombo.Text);
                            MessageBox.Show("Eliminación exitosa", "Eliminación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            limpiar();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Debe elegír un usuario de la lista", "Elimininación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    userCombo.Focus();
                }
            }
        }

        private void uTodosButton_Click(object sender, EventArgs e)
        {
            uIngresoCheck.Checked = true;
            uModificacionCheck.Checked = true;
            uEliminacionCheck.Checked = true;
        }

        private void uNingunoButton_Click(object sender, EventArgs e)
        {
            uIngresoCheck.Checked = false;
            uModificacionCheck.Checked = false;
            uEliminacionCheck.Checked = false;
        }

        private void cTodosButton_Click(object sender, EventArgs e)
        {
            cIngresoCheck.Checked = true;
            cModificacionCheck.Checked = true;
            cExportarCheck.Checked = true;
            cIDeudasCheck.Checked = true;
            cIPagosCheck.Checked = true;
            cMDeudasCheck.Checked = true;
            cMPagosCheck.Checked = true;
            cADeudasCheck.Checked = true;
            cAPagosCheck.Checked = true;
            cCuentaCheck.Checked = true;
        }

        private void cNingunoButton_Click(object sender, EventArgs e)
        {
            cIngresoCheck.Checked = false;
            cModificacionCheck.Checked = false;
            cExportarCheck.Checked = false;
            cIDeudasCheck.Checked = false;
            cIPagosCheck.Checked = false;
            cMDeudasCheck.Checked = false;
            cMPagosCheck.Checked = false;
            cADeudasCheck.Checked = false;
            cAPagosCheck.Checked = false;
            cCuentaCheck.Checked = false;
        }

        private void pTodosButton_Click(object sender, EventArgs e)
        {
            pIngresoCheck.Checked = true;
            pModificacionCheck.Checked = true;
            pConsultaCheck.Checked = true;
            pExportarCheck.Checked = true;
        }

        private void pNingunoButton_Click(object sender, EventArgs e)
        {
            pIngresoCheck.Checked = false;
            pModificacionCheck.Checked = false;
            pConsultaCheck.Checked = false;
            pExportarCheck.Checked = false;
        }

        private void tTodosButton_Click(object sender, EventArgs e)
        {
            tIngresoCheck.Checked = true;
            tModificacionCheck.Checked = true;
            tEliminacionCheck.Checked = true;
            tIPrestamoCheck.Checked = true;
            tIPagosCheck.Checked = true;
            tMPrestamoCheck.Checked = true;
            tMPagosCheck.Checked = true;
            tAPrestamoCheck.Checked = true;
            tAPagoCheck.Checked = true;
        }

        private void tNingunoButton_Click(object sender, EventArgs e)
        {
            tIngresoCheck.Checked = false;
            tModificacionCheck.Checked = false;
            tEliminacionCheck.Checked = false;
            tIPrestamoCheck.Checked = false;
            tIPagosCheck.Checked = false;
            tMPrestamoCheck.Checked = false;
            tMPagosCheck.Checked = false;
            tAPrestamoCheck.Checked = false;
            tAPagoCheck.Checked = false;
        }
        private void limpiar()
        {
            userText.Clear();
            contraText1.Clear();
            contraText2.Clear();
            for (int i = 0; i < userCombo.Items.Count; i++)
			{
                userCombo.Items.RemoveAt(i);
			}
            uIngresoCheck.Checked = false;
            uModificacionCheck.Checked = false;
            uEliminacionCheck.Checked = false;
            cIngresoCheck.Checked = false;
            cModificacionCheck.Checked = false;
            cExportarCheck.Checked = false;
            cIDeudasCheck.Checked = false;
            cIPagosCheck.Checked = false;
            cMDeudasCheck.Checked = false;
            cMPagosCheck.Checked = false;
            cADeudasCheck.Checked = false;
            cAPagosCheck.Checked = false;
            cCuentaCheck.Checked = false;
            pIngresoCheck.Checked = false;
            pModificacionCheck.Checked = false;
            pConsultaCheck.Checked = false;
            pExportarCheck.Checked = false;
            tIngresoCheck.Checked = false;
            tModificacionCheck.Checked = false;
            tEliminacionCheck.Checked = false;
            tIPrestamoCheck.Checked = false;
            tIPagosCheck.Checked = false;
            tMPrestamoCheck.Checked = false;
            tMPagosCheck.Checked = false;
            tAPrestamoCheck.Checked = false;
            tAPagoCheck.Checked = false;
            modificarPanel.Visible = false;
            aceptarButton.Enabled = false;
            menuStrip1.Enabled = true;
            ingresoPanel.Visible = false;
            todoGroup.Enabled = false;
            cancelarButton.Enabled = false;
            modificacion = false;
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String[] usuarios = conexion.obtenerUsuarios();
            if (usuarios.Length != 0)
            {
                for (int i = 0; i < usuarios.Length; i++)
                {
                    userCombo.Items.Add(usuarios[i]);
                }
                modificarPanel.Visible = true;
                aceptarButton.Enabled = true;
                cancelarButton.Enabled = true;
                menuStrip1.Enabled = false;
                modificacion = false;
            }
        }
        
    }
}
