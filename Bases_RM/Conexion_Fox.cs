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
        private Conexion_DB Conexion_DB;//Objeto de la clase Conexion_DB 
        private OleDbConnection Variable_Conexion;//Conexion con la base de Fox_Pro
        private OleDbCommand comando;//Variable en la cual se asignan los comando 
        private OleDbDataReader Variable_Lectura;//Variable de lectura de datos
        private OleDbDataAdapter Adaptador_Datos;//adaptador para  guardar los datos en un DataTable
        private DataTable Tabla_Datos;//tabla que almacena datos

        /// <summary>
        /// Metodo que se encarga de ingresar los codigos nuevos a la base de datos y modificar los codigos ya existentes en la base de datos
        /// </summary>
        /// <param name="barra">Progres bar que es aumentada segun el proceso de la actualizacion o insercion de codigos</param>
        /// <param name="etiqueta">etiqueta que contiene el progrteso de inserciones o modificaciones</param>
        public void Insertar_Codigos()
        {


            Conexion_DB = new Conexion_DB();//inicializamos el objeto de la clase Conexion_DB

            int codigos = cantidad_codigos();//obtenemos la cantidad de codigos en la base de MariaDB

            Pedidos progres = new Pedidos(codigos);//iniciamos un progresbar
            progres.Show();

            insertar(progres);//inserta los codigos de Fox a Maria

            existencias();

            progres.Close();
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
        private void insertar(Pedidos progres)
        {
            try
            {
                Variable_Conexion = new OleDbConnection("Provider=VFPOLEDB.1; Data Source=C:\\;");//parametros a la conexion con la base de datos de Fox_Pro
                comando = new OleDbCommand("SELECT codigo, codigobarr, articulo1, costo, venta1, marca1, marca2 FROM INVENT.DBF", Variable_Conexion);//se guarda la consulta para la tabla
                Variable_Conexion.Open();//Se abre la conexion con la base de datos
                Variable_Lectura = comando.ExecuteReader();//se guarda la iniformacion del comando
                int Cont = 0;
                while (Variable_Lectura.Read())//Se ejecuta el ciclo si existen datos por leer
                {
                    Cont++;
                    progres.progreso(Cont.ToString());
                    if (Conexion_DB.existe_Codigo(Variable_Lectura["codigo"].ToString().Trim()))//se compara si el codigo existe se modifica
                    {
                        Conexion_DB.modificacionProducto(Variable_Lectura["codigo"].ToString(), Variable_Lectura["codigobarr"].ToString(), Variable_Lectura["articulo1"].ToString(), Variable_Lectura["marca1"].ToString(),
                            Variable_Lectura["marca1"].ToString(), Variable_Lectura["marca2"].ToString(), double.Parse(Variable_Lectura["costo"].ToString()), double.Parse(Variable_Lectura["venta1"].ToString()));
                    }
                    else// si no existe el codigo se ingresa
                    {
                        Conexion_DB.ingresoProducto(Variable_Lectura["codigo"].ToString(), Variable_Lectura["codigobarr"].ToString(), Variable_Lectura["articulo1"].ToString(), Variable_Lectura["marca1"].ToString(),
                            Variable_Lectura["marca1"].ToString(), Variable_Lectura["marca2"].ToString(), double.Parse(Variable_Lectura["costo"].ToString()), double.Parse(Variable_Lectura["venta1"].ToString()));
                    }
                }
                Variable_Conexion.Close();//se cierra la conexion con la base de datos
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        private int cantidad_codigos()
        {
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

            return codigos;
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
        /// <summary>
        /// Verifica si exite in codigo en la base Fox_Pro
        /// </summary>
        /// <param name="codigo">Codigo que se busca</param>
        /// <returns>booleano que indica si se encontro o no el codigo</returns>
        private Boolean Exisete_Codigo(String codigo)
        {
            try
            {
                Boolean existe = false;

                Variable_Conexion = new OleDbConnection("Provider=VFPOLEDB.1; Data Source=C:\\;");//parametros a la conexion con la base de datos

                Variable_Conexion.Open();//abrimos la conexion 
                comando = new OleDbCommand("SELECT COUNT(*) FROM INVENT.DBF WHERE codigo='" + codigo + "'", Variable_Conexion);//Consulta para el conteo segun el codigo
                Variable_Lectura = comando.ExecuteReader();//Guardamos los datos en la variable de lectura

                int cuenta = 0;
                if (Variable_Lectura.Read())//Se comprueba si se realizo la consulta
                {
                    cuenta = int.Parse(Variable_Lectura[0].ToString());//cantidad  de veces que se repite el codigo
                }

                if (cuenta == 1)
                {
                    existe = true;//se dice que si existe el codigo
                }
                return existe;

            }
            catch (OleDbException e)
            {
                throw e;
            }
        }

        private void existencias()
        {
            Variable_Conexion = new OleDbConnection("Provider=VFPOLEDB.1; Data Source=C:\\;");//parametros a la conexion con la base de datos de Fox_Pro
            comando = new OleDbCommand("SELECT uni01 FROM INVENT.DBF", Variable_Conexion);//se guarda la consulta para la tabla
            Variable_Conexion.Open();//Se abre la conexion con la base de datos
            Variable_Lectura = comando.ExecuteReader();//se guarda la iniformacion del comando

            while (Variable_Lectura.Read())
            {
                
            }
        }
    }
}
