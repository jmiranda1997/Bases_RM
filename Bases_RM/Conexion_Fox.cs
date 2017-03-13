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

    class Conexion_Fox
    {
        private Conexion_DB Conexion_DB;
        private OleDbConnection Variable_Conexion;
        private OleDbCommand comando;
        private OleDbDataReader Variable_Lectura;

        //private OleDbDataAdapter Variable_Datos;
        //private DataTable DS;

        /// <summary>
        /// Metodo que se encarga de ingresar los codigos nuevos a la base de datos y modificar los codigos ya existentes en la base de datos
        /// </summary>
        /// <param name="barra">Progres bar que es aumentada segun el proceso de la actualizacion o insercion de codigos</param>
        /// <param name="etiqueta">etiqueta que contiene el progrteso de inserciones o modificaciones</param>
        public void Insertar_Codigos(ProgressBar barra, Label etiqueta)
        {
            Conexion_DB = new Conexion_DB();//inicializamos el objeto de la clase Conexion_DB
            Variable_Conexion = new OleDbConnection("Provider=VFPOLEDB.1; Data Source=C:\\;");//parametros a la conexion con la base de datos de Fox_Pro

            Variable_Conexion.Open();
            comando = new OleDbCommand("SELECT COUNT(*) FROM INVENT.DBF", Variable_Conexion);
            Variable_Lectura = comando.ExecuteReader();
            int codigos = 0;
            if (Variable_Lectura.Read())
            {
                codigos = int.Parse(Variable_Lectura[0].ToString());
            }
            Variable_Conexion.Close();

            barra.Maximum = codigos;
            barra.Minimum = 0;
            int cont =0;
            Variable_Conexion.Open();
            comando = new OleDbCommand("SELECT codigo, codigobarr, articulo1, costo, venta1, marca1, marca2 FROM INVENT.DBF", Variable_Conexion);
            Variable_Lectura = comando.ExecuteReader();
            while (Variable_Lectura.Read())
            {
                cont++;
                barra.Value++;
                etiqueta.Text = cont + "/" + codigos;
                if (Conexion_DB.Existe_Codigo(Variable_Lectura["codigo"].ToString().Trim()))
                {
                    Conexion_DB.modificacionProducto(Variable_Lectura["codigo"].ToString(), Variable_Lectura["codigobarr"].ToString(), Variable_Lectura["articulo1"].ToString(), Variable_Lectura["marca1"].ToString(),
                        Variable_Lectura["marca1"].ToString(), Variable_Lectura["marca2"].ToString(), double.Parse(Variable_Lectura["costo"].ToString()), double.Parse(Variable_Lectura["venta1"].ToString()));
                }
                else
                {
                    Conexion_DB.ingresoProducto(Variable_Lectura["codigo"].ToString(), Variable_Lectura["codigobarr"].ToString(), Variable_Lectura["articulo1"].ToString(), Variable_Lectura["marca1"].ToString(),
                        Variable_Lectura["marca1"].ToString(), Variable_Lectura["marca2"].ToString(), double.Parse(Variable_Lectura["costo"].ToString()), double.Parse(Variable_Lectura["venta1"].ToString()));
                }
            }
            Variable_Conexion.Close();
        }

        /// <summary>
        /// Selector de archivos excel
        /// </summary>
        /// <returns>Direccion del archivo seleccionado</returns>
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
        /// <summary>
        /// Metodo que convierte la cadena de existencias en unarreglo de existencias
        /// </summary>
        /// <param name="texto">Cadena con los decimales separados por espacios</param>
        /// <returns>Arreglo con 10 decimales</returns>
        private double[] decimales(String texto)
        {
            double[] deci = null;

            string cadena = texto.Trim(), txt = "";//elimino los espacios inecesarios
            char[] letras = cadena.ToCharArray();//convierte la cadena a un arreglo de caracteres
            int cont = 0;//bandera para poner una coma
            for (int i = 0; i < cadena.Length; i++)
            {
                if (letras[i] == ' ' && cont == 0)//inserta una coma es donde hay varios espacios
                {
                    cont++;
                    txt += ",";
                }
                if (letras[i] != ' ')//consume los espacios
                {
                    cont = 0;
                    txt += letras[i];
                }
            }
            string[] cad = txt.Split(',');//se separan los numeros
            double[] dec = new double[cad.Length];
            for (int i = 0; i < cad.Length; i++)
            {
                dec[i] = double.Parse(cad[i]);//se convierten a decimales 
            }

            return deci;
        }
        private Boolean Exisete_Codigo(String codigo)
        {
            Boolean existe = false;

            return existe;
        }
    }
}
