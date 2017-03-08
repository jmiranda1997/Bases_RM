using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Bases_RM
{
    class Conexion_DB
    {
        private MySqlConnectionStringBuilder Constructor_Conexion = new MySqlConnectionStringBuilder();
        private MySqlConnection Variable_Conexion;
        private MySqlDataReader Variable_Lectura;
        private MySqlCommand comando;
        public Conexion_DB(){
            Constructor_Conexion.Server = "25.84.214.223";
            Constructor_Conexion.UserID = "root";
            Constructor_Conexion.Password = "@Sistemas2017";
            Constructor_Conexion.Database = "rm_db";
            //creacion de variable de conexion
            Variable_Conexion = new MySqlConnection(Constructor_Conexion.ToString());
        }
        public void Guardar()
        {
            comando = Variable_Conexion.CreateCommand();
            comando.CommandText = "INSERT INTO sucursal (Nombre) VALUES('hola');";
            Variable_Conexion.Open();
            try
            {
                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                
            }
            Variable_Conexion.Close();
        }

        public string Us_con(string usuario)
        {
            string contraseña = "";
            comando = Variable_Conexion.CreateCommand();
            comando.CommandText = "SELECT Clave FROM usuario WHERE Nombre = '" + usuario + "';";
            Variable_Conexion.Open();
            Variable_Lectura = comando.ExecuteReader();
            if (Variable_Lectura.Read() == true)
            {
                contraseña = Variable_Lectura["Clave"].ToString();
            }
            Variable_Conexion.Close();
            return contraseña;
        }

        //---------------INGRESOS--------------//

        public void ingresoEncargado(String nombre, String correo, int idProveedor){
            comando = Variable_Conexion.CreateCommand();
            comando.CommandText = "INSERT INTO encargado (Nombre, Correo, Proveedor_ID) VALUES ('"+nombre+"','"+correo+"',"+idProveedor.ToString()+");";
            Variable_Conexion.Open();
            try
            {
                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                  
            }
            Variable_Conexion.Close();
        }
        public void ingresoProveedor(String nombre, DateTime fecha, int idPais){
            comando = Variable_Conexion.CreateCommand();
            comando.CommandText = "INSERT INTO proveedor (Nombre, Fecha, Pais_ID) VALUES ('"+nombre+"','"+fecha.ToShortDateString()+"',"+idPais.ToString()+");";
            Variable_Conexion.Open();
            try
            {
                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                  
            }
            Variable_Conexion.Close();
        }
        public void ingresoTrabajador(String nombre, String salario, int idSucursal){
            comando = Variable_Conexion.CreateCommand();
            comando.CommandText = "INSERT INTO trabajador (Nombre, Salario, Sucursal_ID) VALUES ('" + nombre + "','" + salario + "'," + idSucursal.ToString() + ");";
            Variable_Conexion.Open();
            try
            {
                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                  
            }
            Variable_Conexion.Close();
        }
        public void ingresoAusencia(int id, DateTime fecha, int idTrabajador)
        {
            comando = Variable_Conexion.CreateCommand();
            comando.CommandText = "INSERT INTO ausencia (Id, Fecha, Trabajador_idTrabajador) VALUES ("+id.ToString()+",'"+fecha.ToShortDateString()+"',"+idTrabajador.ToString()+");";
            Variable_Conexion.Open();
            try
            {
                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {

            }
            Variable_Conexion.Close();
        }
        public void ingresoPagos(int id, DateTime fecha, double monto, int idPrestamo, int idDeuda)
        {
            comando = Variable_Conexion.CreateCommand();
            comando.CommandText = "INSERT INTO pagos (ID, Fecha, Monto, Prestamo_ID, Deuda_ID) VALUES (" + id.ToString() + ",'" + fecha.ToShortDateString() + "'," + monto.ToString() + "," + idPrestamo.ToString() + "," + idDeuda.ToString() + ");";
            Variable_Conexion.Open();
            try
            {
                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {

            }
            Variable_Conexion.Close();
        }


        public void ingresoClasificacion(int id, String tipo)
        {
            comando = Variable_Conexion.CreateCommand();
            comando.CommandText = "INSERT INTO clasicacion (Id, Tipo) VALUES (" + id + ",'" + tipo + "');"; 
            Variable_Conexion.Open();
            try
            {
                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {

            }
            Variable_Conexion.Close();
        }
        public void ingresoPais(String nombre)
        {
            comando = Variable_Conexion.CreateCommand();
            comando.CommandText = "INSERT INTO pais (Nombre) VALUES ('" + nombre + "');";
            Variable_Conexion.Open();
            try
            {
                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {

            }
            Variable_Conexion.Close();
        }
        public void ingresoCliente()
        {

        }
        public void ingresoSucursal (String nombre)
        {
            comando = Variable_Conexion.CreateCommand();
            comando.CommandText = "INSERT INTO Sucursal (nombre) VALUES ('" + nombre + "');";
            Variable_Conexion.Open();
            try
            {
                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
               
            }
            Variable_Conexion.Close();
        }
        public void ingresoProducto(String codInterno, String codFabricante, String marca, String fabricante, String departamento, Double precioCosto, Double precioVenta)
        {
            comando = Variable_Conexion.CreateCommand();
            comando.CommandText = "INSERT INTO producto (Codigo_Interno, Codigo_Fabricante, Marca, Fabricante, Departamento, Precio_Costo, Precio_Venta) VALUES ('" + codInterno + "','" + codFabricante + "','" + marca + "','" + fabricante + "','" + departamento + "'," + precioCosto.ToString() + "," + precioVenta.ToString() + ");";
            Variable_Conexion.Open();
            try{
                comando.ExecuteNonQuery();
            }catch(Exception e){

            }
            Variable_Conexion.Close();
        }
       
    }
    
}
