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
        private Vigenere Vig = new Vigenere();
        private MySqlConnectionStringBuilder Constructor_Conexion = new MySqlConnectionStringBuilder();//Constructor de la conexion
        private MySqlConnection Variable_Conexion;//Variable que se utiliza para realizar la conexion
        private MySqlDataReader Variable_Lectura;//Variable que se usa para leer datos
        private MySqlCommand comando;//Comando SQL para hacer las consultas
        public Conexion_DB(){
            Constructor_Conexion.Server = "25.84.214.223";//Direccion IP del servidor
            Constructor_Conexion.UserID = "root";//Ususario de la base de datos
            Constructor_Conexion.Password = "@Sistemas2017";//Contraseña para la base de datos 
            Constructor_Conexion.Database = "rm_db";//Nombre de la base de datos
            Variable_Conexion = new MySqlConnection(Constructor_Conexion.ToString());//creacion de variable de conexion
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
        /**
         * Metodo que obtiene la contraseña de un usuario de la base de datos
         */
        public string Us_con(string usuario)
        {
            string contraseña = "";                                //Variable que guarda la contraseña obtenida de la base
            comando = Variable_Conexion.CreateCommand();           //Inicializacion del comando 
            comando.CommandText = "SELECT Clave FROM usuario WHERE Nombre = '" + usuario + "';";   //Consulta para la base
            Variable_Conexion.Open();                              //se abre la conexion a la base
            Variable_Lectura = comando.ExecuteReader();            //se guarda la contraseña en la variable de lectura
            if (Variable_Lectura.Read() == true)                   //se verifica si se obtiene algun dato de la base
            {
                contraseña = Variable_Lectura["Clave"].ToString();
               //Vig.descifrar(contraseña, Vig.getCP());//se guarda la contraseña
               //contraseña = Vig.getMD();
            }
            
            Variable_Conexion.Close();                                                               //se cierra la conexion
           return contraseña;                                    //regresa la contraseña obtenida de la base

        }
        public Usuario Datos_De_User(string usuario)
        {
            Usuario temp = null;
            string clave = "", Nombre = "", Pedidos= "", Clientes= "", Trabajadores = "", Seguridad="";
            comando = Variable_Conexion.CreateCommand();                                     //Inicializacion del comando 
            comando.CommandText = "SELECT * FROM usuario WHERE Nombre = '" + usuario + "';"; //Consulta para la base
            Variable_Conexion.Open();                                  //se abre la conexion a la base
            Variable_Lectura = comando.ExecuteReader();


            if (Variable_Lectura.Read() == true)                        //se verifica si se obtiene algun dato de la base
            {
                Nombre = Variable_Lectura["Nombre"].ToString();
                clave = Variable_Lectura["Clave"].ToString();
                Pedidos = Variable_Lectura["Acceso_Pedidos"].ToString();
                Clientes = Variable_Lectura["Acceso_Clientes"].ToString();
                Trabajadores = Variable_Lectura["Acceso_Trabajadores"].ToString();
                Seguridad = Variable_Lectura["Acceso_Seguridad"].ToString();
                //se guarda el nombre
            }

            
            Variable_Conexion.Close();//se cierra la conexion
            temp = new Usuario(Nombre,clave,Seguridad,Clientes,Trabajadores,Pedidos);
            return temp;
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
        public void ingresoPagos(int id, DateTime fecha, double monto, int idPrestamo, int idDeuda, DateTime fechaIngreso)
        {
            comando = Variable_Conexion.CreateCommand();
            comando.CommandText = "INSERT INTO pagos (ID, Fecha, Monto, Prestamo_ID, Deuda_ID, Fecha_Ingreso) VALUES (" + id.ToString() + ",'" + fecha.ToShortDateString() + "'," + monto.ToString() + "," + idPrestamo.ToString() + "," + idDeuda.ToString() + ",'"+fechaIngreso.ToShortDateString()+"');";
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
        public void ingresoCliente(String NitDpi, String nombre, int diasCredito, int limiteCredito, int clasificacionId)
        {
            comando = Variable_Conexion.CreateCommand();
            comando.CommandText = "INSERT INTO cliente (NIT/DPI, Nombre, Dias_Credito, Limite_Credito, Clasicacion_Id) VALUES ('" + NitDpi + "','" + nombre + "'," + diasCredito.ToString() + "," + limiteCredito.ToString() + "," + clasificacionId.ToString() + ");";
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
        public void ingresoPedido(double total, int idProveedor)
        {
            comando = Variable_Conexion.CreateCommand();
            comando.CommandText = "INSERT INTO pedido (Total, Proveedor_ID) VALUES (" + total.ToString() + "," + idProveedor.ToString() + ");";
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
        public void ingresoPrestamo(double monto, int idTrabajador)
        {
            comando = Variable_Conexion.CreateCommand();
            comando.CommandText = "INSERT INTO prestamo (Monto, Trabajador_idTrabajador) VALUES (" + monto.ToString() + "," + idTrabajador + ");";
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
        public void ingresoDeuda(DateTime pago, double total, string nit, int idSucursal, DateTime ingreso)
        {
            comando = Variable_Conexion.CreateCommand();
            comando.CommandText = "INSERT INTO  deuda (Fecha_Pago, Total, Cliente_NIT, Sucursal_ID, Fecha_Ingreso) VALUES ('" + pago.ToShortDateString() + "'," + total.ToString() + ",'" + nit + "'," + idSucursal.ToString() + ",'" + ingreso.ToShortDateString() + "');";
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
        public void ingresoTelefono(String telefono, int idEncargado, String nitCliente)
        {
            comando = Variable_Conexion.CreateCommand();
            comando.CommandText = "INSERT INTO telefono (Telefono, Encargado_id, Cliente_NIT) VALUES ('" + telefono + "'," + idEncargado.ToString() + ",'" + nitCliente + "');";
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
            //--------------------INGRESO RELACIONES--------------------//


        public void ingresoDetallePedido(String codInternoProducto, int numeroPedido, int cantidad)
        {
            comando = Variable_Conexion.CreateCommand();
            comando.CommandText = "INSERT INTO detalle_pedido (Producto_Codigo_Interno, Pedido_Numero, Cantidad) VALUES ('" + codInternoProducto + "'," + numeroPedido.ToString() + "," + cantidad.ToString() + ");";
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
        public void ingresoProductoSucursal(int idSucursal, String codInternoProducto, int existencia)
        {
            comando = Variable_Conexion.CreateCommand();
            comando.CommandText = "INSERT INTO prod_suc (Sucursal_ID, Producto_Codigo_Interno, Existencia) VALUES (" + idSucursal.ToString() + ",'" + codInternoProducto + "'," + existencia.ToString() + ");";
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
        public void ingresoProveedoresProducto(String codInternoProducto, int idProveedor, double precioProveedor)
        {
            comando = Variable_Conexion.CreateCommand();
            comando.CommandText = "INSERT INTO `prov_prod`(`Producto_Codigo_Interno`, `Proveedor_ID`, `Precio_Proveedor`) VALUES ('" + codInternoProducto + "'," + idProveedor.ToString() + "," + precioProveedor.ToString() + ");";
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
    }
    
}
