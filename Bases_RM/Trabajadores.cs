using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Bases_RM
{
    public partial class Trabajadores : Form
    {

        private Conexion_DB Conexion_DB;
        private TrabajadoresClass trab;
        private TrabajadoresClass trab1;
        private bool permitir = false;
        private Pagos paguitos = new Pagos(null);
        private MySqlConnectionStringBuilder Constructor_Conexion = new MySqlConnectionStringBuilder();//Constructor de la conexion
        private MySqlConnection Variable_Conexion;//Variable que se utiliza para realizar la conexion
        private MySqlDataReader Variable_Lectura;//Variable que se usa para leer datos
        private MySqlCommand comando;//Comando SQL para hacer las consultas


        public Trabajadores()
        {
            InitializeComponent();
            try
            {
                this.Conexion_DB = new Conexion_DB();
                String[] trabajadores = this.Conexion_DB.obtener_Trabajadordesha1();
                for (int i = 0; i < trabajadores.Length; i++)
                {
                    trabajadoresTree.Nodes.Add(trabajadores[i]);
                }
                String[,] sucus = this.Conexion_DB.obtener_sucursales("");
                for (int i = 0; i < Conexion_DB.obtener_Nbodegas(); i++)
                {
                    ComboSucu.Items.Add(sucus[1, i]);
                }
                Habilitar.Visible = false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Error2", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void iniciar()
        {
            try
            {
                this.Conexion_DB = new Conexion_DB();
                String[] trabajadores = this.Conexion_DB.obtener_Trabajadordesha1();
                for (int i = 0; i < trabajadores.Length; i++)
                {
                    trabajadoresTree.Nodes.Add(trabajadores[i]);
                }
               
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Error2", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void iniciar2()
        {
            try
            {
                this.Conexion_DB = new Conexion_DB();
                String[] trabajadores = this.Conexion_DB.obtener_Trabajadordesha();
                for (int i = 0; i < trabajadores.Length; i++)
                {
                    trabajadoresTree.Nodes.Add(trabajadores[i]);
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Error2", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            trabajadoresTree.SelectedNode = trabajadoresTree.SelectedNode.PrevNode;
            trabajadoresTree.Select();
        }

        private void TxtSala_TextChanged(object sender, EventArgs e)
        {

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            String Nombre = trabajadoresTree.SelectedNode.Text;
            trab = Conexion_DB.obtener_Trabajador(Nombre.Trim());
            //trab1 = Conexion_DB.obtener_Trabajadordesha();

            if (trab != null)
            {
                //String[] sucursales = Conexion_DB.obtener_sucursales();
                //for (int i = 0; i < sucursales.Length; i++)
                //{
                //    ComboSucu.Items.Add(sucursales[i]);
                //}

                TxtNom.Text = trab.Nombre.Trim();
                TxtSala.Text = trab.Salario.ToString();
                ComboSucu.Text = Conexion_DB.obtener_Nombredemens(trab.Sucursal_ID);
                TxtCod.Text = trab.codigo.ToString();
                if (!trab.codigo.ToString().Equals("-1")) TxtCod.Text = trab.codigo.ToString();
                else
                {
                    Habilitar.Enabled = false;
                    TxtCod.Text = "";
                }
            }
        }

        private void TxtNom_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtSucu_TextChanged(object sender, EventArgs e)
        {

        }

        private void ComboSucu_SelectedIndexChanged(object sender, EventArgs e)
        {
            Conexion_DB.obtener_sucursales();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            trabajadoresTree.SelectedNode = trabajadoresTree.SelectedNode.NextNode;
            trabajadoresTree.Select();
        }

        private void archivoToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void nuevoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            button2.Visible = true;
            btnMG.Visible = true;
            btnEC.Visible = true;
            if (!permitir)
            {
                permitir = true;
                nuevoToolStripMenuItem1.Text = "Modificar";
                btnMG.Text = "Guardar";
                btnEC.Text = "Cancelar";
                TxtNom.Text = "";
                TxtSala.Text = "";
                ComboSucu.Text = "";
                Habilitar.Visible = false;
                TxtCod.Text = "";
                TxtNom.Enabled = true;
                TxtSala.Enabled = true;
                trabajadoresTree.Enabled = false;
                btnDer.Visible = false;
                btnIzq.Visible = false;
                trabajadoresTree.EndUpdate();
            }
            else
            {
                permitir = false;
                nuevoToolStripMenuItem1.Text = "Nuevo";
                btnMG.Text = "Modificar";
                btnEC.Text = "Eliminar";
                TxtNom.Enabled = true;
                Habilitar.Visible = false;
                TxtSala.Enabled = true;
                TxtNom.Text = "";
                TxtSala.Text = "";
                ComboSucu.Text = "";
                TxtCod.Text = "";
                trabajadoresTree.Enabled = true;
                btnDer.Visible = true;
                btnIzq.Visible = true;
                trabajadoresTree.EndUpdate();
            }
        }

        private void btnMG_Click(object sender, EventArgs e)
        {
            if (permitir)
            {
                if (campos_vacios())
                {
                    MessageBox.Show("Uno o mas campos estan vacios", "Error");
                }
                else
                {
                    try
                    {
                        String SucuSucu = ComboSucu.Text;
                        Conexion_DB.ingresoTrabajador(TxtNom.Text, double.Parse(TxtSala.Text), obtener_IDSucu(SucuSucu),int.Parse(TxtCod.Text));     /////////////////////////
                        MessageBox.Show("Trabajador Nuevo ingresado");
                        TxtNom.Text = "";
                        TxtSala.Text = "";
                        ComboSucu.Text = "";
                        TxtCod.Text = "";

                    }
                 catch (Exception ex)
                    {
                        MessageBox.Show("Algunos datos no son validos");
                   }
                }
                {

                }
            }
            else
            {
                if (campos_vacios())
                {
                    MessageBox.Show("Uno o mas campos estan vacios", "Error");
                }
                else
                {
                    try
                   {
                        String SucuSucu = ComboSucu.Text;
                        //trabajadoresTree.SelectedNode.BeginEdit();
                        String Nombre = trabajadoresTree.SelectedNode.Text;
                        trab = Conexion_DB.obtener_Trabajador(Nombre.Trim());
                        Conexion_DB.modificacionTrabajador(obtener_TrabajadorID(Nombre), TxtNom.Text, double.Parse(TxtSala.Text), obtener_IDSucu(SucuSucu),int.Parse(TxtCod.Text));
                        MessageBox.Show("Trabajador Modificado");
                        TxtNom.Text = "";
                        TxtSala.Text = "";
                        ComboSucu.Text = "";
                        TxtCod.Text = "";
                        //trabajadoresTree.SelectedNode.EndEdit(true);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Algunos datos no son validos");
                    }
                }
                {

                }
            }
            trabajadoresTree.BeginUpdate();
            trabajadoresTree.Nodes.Clear();
            trabajadoresTree.EndUpdate();
            iniciar();
        }
        private void deshabilitadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            trabajadoresTree.BeginUpdate();
            trabajadoresTree.Nodes.Clear();
            trabajadoresTree.EndUpdate();
            Habilitar.Visible = true;
            button2.Visible = false;
            btnMG.Visible = false;
            btnEC.Visible = false;
            TxtSala.Enabled = false;
            TxtCod.Enabled = true;
            TxtNom.Enabled = false;
            ComboSucu.Enabled = false;
            TxtSala.Text = "";
            TxtCod.Text = "";
            TxtNom.Text = "";
            ComboSucu.Text = "";
            iniciar2();

        }
        private void habilitadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TxtSala.Text = "";
            TxtCod.Text = "";
            TxtNom.Text = "";
            ComboSucu.Text = "";
            TxtSala.Enabled = true;
            TxtCod.Enabled = true;
            TxtNom.Enabled = true;
            ComboSucu.Enabled = true;
            trabajadoresTree.BeginUpdate();
            trabajadoresTree.Nodes.Clear();
            trabajadoresTree.EndUpdate();
            Habilitar.Visible = false;
            button2.Visible = true;
            btnMG.Visible = true;
            btnEC.Visible = true;
            iniciar();
        }
        public int obtener_IDSucu(String Nom)
        {
            int cont = 0;
            String[,] Sucu = Conexion_DB.obtener_sucursales("");
            while (cont < Conexion_DB.obtener_Nbodegas())
            {
                if (Nom == Sucu[1, cont])
                {
                    break;
                }
                cont++;
            }
            return int.Parse(Sucu[0, cont]);

        }
        public int obtener_TrabajadorID(String Nom)
        {
            int cont = 0;
            String[,] Sucu = Conexion_DB.obtener_Trabajadores1("");
            while (cont < Conexion_DB.obtener_IDTrabajador())
            {
                if (Nom == Sucu[1, cont])
                {
                    break;
                }
                cont++;
            }
            return int.Parse(Sucu[0, cont]);
        }


        private bool campos_vacios()
        {
            bool campos_nulos = false;
            if (String.IsNullOrEmpty(TxtNom.Text))
                campos_nulos = true;
            if (String.IsNullOrEmpty(TxtSala.Text))
                campos_nulos = true;
            if (String.IsNullOrEmpty(ComboSucu.Text))
                campos_nulos = true;
            return campos_nulos;
        }

        private void btnEC_Click(object sender, EventArgs e)
        {
            if (permitir)
            {

            }

            else
            {
                if (campos_vacios())
                {
                    MessageBox.Show("Uno o mas campos estan vacios", "Error");
                }
                else
                {
                    try
                    {
                        String cadenita = TxtNom.Text;
                        Conexion_DB.eliminacionTrabajadores(cadenita);
                        MessageBox.Show("Trabajador Deshabilitado ");
                        TxtNom.Text = "";
                        TxtSala.Text = "";
                        ComboSucu.Text = "";
                        TxtCod.Text = "";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Algunos datos no son validos la verga");
                    }
                }


            }
            trabajadoresTree.BeginUpdate();
            trabajadoresTree.Nodes.Clear();
            trabajadoresTree.EndUpdate();
            iniciar();
        }

        private void exportarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lbSala_Click(object sender, EventArgs e)
        {

        }

        private void grupo1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Pagos pg = new Pagos(null);
            pg.Show();
        }

        private void trabajadoresTree_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
    
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (campos_vacios())
            {
                MessageBox.Show("Codigo no puede ser ''-1'' ", "Error");
            }
            else
            {
                try
                {
                    String SucuSucu = ComboSucu.Text;
                    if(TxtCod.Text == ""){
                        MessageBox.Show("Ingrese codigo de trabajador...", "Error");
                    }
                    else
                    {
                        string hola = TxtCod.Text;
                        Conexion_DB.HabilitarUsuario(trabajadoresTree.SelectedNode.Text, hola);   /////////////////////////
                        MessageBox.Show("Trabajador Habilitado");
                        TxtNom.Text = "";
                        TxtSala.Text = "";
                        ComboSucu.Text = "";
                        TxtCod.Text = "";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            trabajadoresTree.BeginUpdate();
            trabajadoresTree.Nodes.Clear();
            trabajadoresTree.EndUpdate();
            iniciar2();
        }

        private void TxtCod_TextChanged(object sender, EventArgs e)
        {
            if (TxtCod.Text!="")
            {
                Habilitar.Enabled = true;
            }
        }
    }
}
