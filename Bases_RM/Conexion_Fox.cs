﻿using System;
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
        private  OleDbConnection VARIABLE_CONEXION = new OleDbConnection("Provider=VFPOLEDB.1; Data Source=" + System.Windows.Forms.Application.StartupPath.ToString() + "\\..\\..\\Bases_Fox;");//Conexion con la base de Fox_Pro
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
            Sucursales();
            try
            {
                insertar(progres);//inserta los codigos de Fox a Maria
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //existencias();

            

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
                comando = new OleDbCommand("SELECT codigo, codigobarr, articulo1, costo, venta1, marca1, marca2, Uni01 FROM INVENT.DBF", VARIABLE_CONEXION);//se guarda la consulta para la tabla
                VARIABLE_CONEXION.Open();//Se abre la conexion con la base de datos
                Variable_Lectura = comando.ExecuteReader();//se guarda la iniformacion del comando
                int Cont = 0;
                while (Variable_Lectura.Read())//Se ejecuta el ciclo si existen datos por leer
                {
                    Cont++;
                    progres.progreso(Cont.ToString());
                    Double exi = existencias(Variable_Lectura["Uni01"].ToString()); 
                    if (Conexion_DB.existe_Codigo(Variable_Lectura["codigo"].ToString().Trim()))//se compara si el codigo existe se modifica
                    {
                        Conexion_DB.modificacionProducto(caracteresespeciales(Variable_Lectura["codigo"].ToString().Trim()), caracteresespeciales(Variable_Lectura["codigobarr"].ToString().Trim()), caracteresespeciales(Variable_Lectura["articulo1"].ToString().Trim()), caracteresespeciales(Variable_Lectura["marca1"].ToString().Trim()),
                            caracteresespeciales(Variable_Lectura["marca1"].ToString().Trim()), caracteresespeciales(Variable_Lectura["marca2"].ToString().Trim()), double.Parse(Variable_Lectura["costo"].ToString().Trim()), double.Parse(Variable_Lectura["venta1"].ToString().Trim()), exi);
                    }
                    else// si no existe el codigo se ingresa
                    {
                        Conexion_DB.ingresoProducto(caracteresespeciales(Variable_Lectura["codigo"].ToString().Trim()), caracteresespeciales(Variable_Lectura["codigobarr"].ToString().Trim()), caracteresespeciales(Variable_Lectura["articulo1"].ToString().Trim()), caracteresespeciales(Variable_Lectura["marca1"].ToString().Trim()),
                            caracteresespeciales(Variable_Lectura["marca1"].ToString().Trim()), caracteresespeciales(Variable_Lectura["marca2"].ToString().Trim()), double.Parse(Variable_Lectura["costo"].ToString().Trim()), double.Parse(Variable_Lectura["venta1"].ToString().Trim()), exi);
                    }
                }
                VARIABLE_CONEXION.Close();//se cierra la conexion con la base de datos
           }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        private int cantidad_codigos()
        {
            comando = new OleDbCommand("SELECT COUNT(*) FROM INVENT.DBF", VARIABLE_CONEXION);
            VARIABLE_CONEXION.Open();
            Variable_Lectura = comando.ExecuteReader();
            int codigos = 0;
            if (Variable_Lectura.Read())
            {
                codigos = int.Parse(Variable_Lectura[0].ToString());
            }
            VARIABLE_CONEXION.Close();

            return codigos;
        }


        /// <summary>
        /// Metodo que convierte la cadena de existencias en unarreglo de existencias
        /// </summary>
        /// <param name="texto">Cadena con los decimales separados por espacios</param>
        /// <returns>Arreglo con 10 decimales</returns>
        private Double existencias(String texto)
        {
            Double[] deci;
            Double exi = 0;
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
            deci = new Double[cad.Length];
            for (int i = 0; i < cad.Length; i++)
            {
                deci[i] = Double.Parse(cad[i]);//se convierten a decimales 
            }
            for (int i = 0; i < deci.Length; i++)
            {
                exi += deci[i];
            }
            return exi;
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
                comando = new OleDbCommand("SELECT COUNT(*) FROM INVENT.DBF WHERE codigo =='" + codigo + "'", VARIABLE_CONEXION);//Consulta para el conteo segun el codigo
                VARIABLE_CONEXION.Open();//abrimos la conexion 
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
                VARIABLE_CONEXION.Close();
                return existe;

            }
            catch (OleDbException e)
            {
                throw e;
            }
        }

        private void existencias()
        {
            comando = new OleDbCommand("SELECT uni01 FROM INVENT.DBF", VARIABLE_CONEXION);//se guarda la consulta para la tabla
            VARIABLE_CONEXION.Open();//Se abre la conexion con la base de datos
            Variable_Lectura = comando.ExecuteReader();//se guarda la iniformacion del comando

            while (Variable_Lectura.Read())
            {

            }
        }
        private void Sucursales()
        {

            try
            {
                comando = new OleDbCommand("SELECT COUNT(*) FROM CORDOC.DBF WHERE Nombrebode != ' '", VARIABLE_CONEXION);//se guarda la consulta para la tabla
                VARIABLE_CONEXION.Open();
                Variable_Lectura = comando.ExecuteReader();
                int bodegas = 0;
                if (Variable_Lectura.Read())
                {
                    bodegas = int.Parse(Variable_Lectura[0].ToString());
                }
                VARIABLE_CONEXION.Close();

                comando = new OleDbCommand("SELECT Nombrebode FROM CORDOC.DBF WHERE Nombrebode != ' '", VARIABLE_CONEXION);//se guarda la consulta para la tabla
                VARIABLE_CONEXION.Open();
                Variable_Lectura = comando.ExecuteReader();
                String[,] sucur;
                String[] sucurFox = new String[bodegas];
                int cont = 0;
                while (Variable_Lectura.Read())
                {
                    sucurFox[cont] = Variable_Lectura[0].ToString().Trim();
                    cont++;
                }
                VARIABLE_CONEXION.Close();

                sucur = modificarsucursales(Conexion_DB.obtener_sucursales(""), sucurFox);
                for (int i = 0; i < bodegas; i++)
                {
                    if (!sucur[0,i].Equals("-1"))
                    {
                        Conexion_DB.modificacionSucursal(int.Parse(sucur[0, i].Trim()), sucur[1, i].Trim());
                    }
                    else
                    {
                        Conexion_DB.ingresoSucursal(sucur[1, i].Trim());
                    }
                }
                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private String caracteresespeciales(String Cadena)
        {
            String especial = "";

            char[] temp = Cadena.ToCharArray();
            for (int i = 0; i < Cadena.Length; i++)
            {
                if (temp[i].Equals('\''))
                {
                    especial += "\\'";
                }
                else if (temp[i].Equals('\"'))
                {
                    especial += "\\\"";
                }else
                {
                    especial += temp[i];
                } 
            }

            return especial;
        }
        private String[,] modificarsucursales(String[,] sucursales, String[] lectura)
        {

            int bMaria = Conexion_DB.obtener_Nbodegas();
            String[,] nuevo = new String[2, bMaria];
            
            for (int i = 0; i < lectura.Length; i++)
            {
                String[,] aux;
                if (bMaria > i)
                {
                    nuevo[0, i] = sucursales[0, i];
                    nuevo[1, i] = lectura[i];
                }
                else
                {
                    aux = matrizmas(nuevo, lectura[i], (i + 1));
                    nuevo = aux;
                }
            }
                return nuevo;
        }
        private String[,] matrizmas(String[,] matriz, String nombre, int cantidad)
        {
            String[,] nueva = new String[2, cantidad];
            for (int i = 0; i < (cantidad - 1); i++)
            {
                nueva[0, i] = matriz[0, i];
                nueva[1, i] = matriz[1, i];
            }
            nueva[0, cantidad - 1] = "-1"; 
            nueva[1, cantidad -1 ] = nombre; 
            return nueva;
        }
       
    }
}
