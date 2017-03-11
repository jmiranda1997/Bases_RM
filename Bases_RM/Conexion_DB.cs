using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

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
        /// <summary>
        /// Metodo que obtiene la contraseña de un usuario de la base de datos
        /// </summary>
        /// <param name="usuario">El usuario del cual se obtendrá la contraseña</param>
        /// <returns></returns>
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

        /// <summary>
        /// Ingresa los datos del encargado a la BD
        /// </summary>
        /// <param name="nombre">Nombre del encargado</param>
        /// <param name="correo">Correo del encargado</param>
        /// <param name="idProveedor">ID del proveedor al cual pertenece el encargado</param>
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
        /// <summary>
        /// Ingresa los datos del Proveedor a la BD
        /// </summary>
        /// <param name="nombre">Nombre del proveedor</param>
        /// <param name="fecha">Fecha</param>
        /// <param name="idPais">ID del país donde se encuentra el proveedor</param>
        public void ingresoProveedor(String nombre, DateTime fecha, int idPais){
            comando = Variable_Conexion.CreateCommand();
            String fechaString = fecha.Year.ToString() + "-" + fecha.Month.ToString() + "-" + fecha.Day.ToString();
            comando.CommandText = "INSERT INTO proveedor (Nombre, Fecha, Pais_ID) VALUES ('" + nombre + "','" + fechaString + "'," + idPais.ToString() + ");";
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
        /// <summary>
        /// Ingresa los datos del Trabajador en la BD
        /// </summary>
        /// <param name="nombre">Nombre del trabajador</param>
        /// <param name="salario">Salario que recibe el trabajador</param>
        /// <param name="idSucursal">ID de la sucursal en donde trabaja</param>
        public void ingresoTrabajador(String nombre, double salario, int idSucursal){
            comando = Variable_Conexion.CreateCommand();
            comando.CommandText = "INSERT INTO trabajador (Nombre, Salario, Sucursal_ID) VALUES ('" + nombre + "'," + salario + "," + idSucursal.ToString() + ");";
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
        /// <summary>
        /// Ingreso de las ausencias de los trabajadores
        /// </summary>
        /// <param name="fecha">Fecha en que el trabajador se ausentó</param>
        /// <param name="idTrabajador">ID del trabajador que se ha ausentado</param>
        public void ingresoAusencia(DateTime fecha, int idTrabajador)
        {
            comando = Variable_Conexion.CreateCommand();
            String fechaString = fecha.Year.ToString() + "-" + fecha.Month.ToString() + "-" + fecha.Day.ToString();
            comando.CommandText = "INSERT INTO ausencia (Fecha, Trabajador_idTrabajador) VALUES ('" + fechaString + "'," + idTrabajador.ToString() + ");";
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
        /// <summary>
        /// Ingreso de los pagos a los prestamos realizados
        /// </summary>
        /// <param name="fecha"></param>
        /// <param name="monto"></param>
        /// <param name="idPrestamo"></param>
        /// <param name="fechaIngreso"></param>
        public void ingresoPagoPrestamo(DateTime fecha, double monto, int idPrestamo, DateTime fechaIngreso)
        {
            comando = Variable_Conexion.CreateCommand();
            String fechaString = fecha.Year.ToString() + "-" + fecha.Month.ToString() + "-" + fecha.Day.ToString();
            String ingresoString = fechaIngreso.Year.ToString() + "-" + fechaIngreso.Month.ToString() + "-" + fechaIngreso.Day.ToString();
            comando.CommandText = "INSERT INTO pagos (Fecha, Monto, Prestamo_ID, Fecha_Ingreso) VALUES ('" + fechaString + "'," + monto.ToString() + "," + idPrestamo.ToString() + ",'"+ingresoString+"');";
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
        public void ingresoPagoDeuda(DateTime fecha, double monto, int idDeuda, DateTime fechaIngreso)
        {
            comando = Variable_Conexion.CreateCommand();
            String fechaString = fecha.Year.ToString() + "-" + fecha.Month.ToString() + "-" + fecha.Day.ToString();
            String ingresoString = fechaIngreso.Year.ToString() + "-" + fechaIngreso.Month.ToString() + "-" + fechaIngreso.Day.ToString();
            comando.CommandText = "INSERT INTO pagos (Fecha, Monto, Deuda_ID, Fecha_Ingreso) VALUES ('" + fechaString + "'," + monto.ToString() + "," + idDeuda.ToString() + ",'" + ingresoString + "');";
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
        public void ingresoUsuario(String nombre, String clave, String pedidos, String clientes, String trabajadores, String seguridad)
        {
            comando = Variable_Conexion.CreateCommand();
            comando.CommandText = "INSERT INTO usuario (Nombre, Clave, Acceso_Pedidos, Acceso_Clientes, Acceso_Trabajadores, Acceso_Seguridad) VALUES ('" + nombre + "','" + clave + "','" + pedidos + "','" + clientes + "','" + trabajadores + "','" + seguridad + "');";
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
        public void ingresoClasificacion(String tipo)
        {
            comando = Variable_Conexion.CreateCommand();
            comando.CommandText = "INSERT INTO clasicacion (Tipo) VALUES ('" + tipo + "');"; 
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
            comando.CommandText = "INSERT INTO cliente (NIT_DPI, Nombre, Dias_Credito, Limite_Credito, Clasicacion_Id) VALUES ('" + NitDpi + "','" + nombre + "'," + diasCredito.ToString() + "," + limiteCredito.ToString() + "," + clasificacionId.ToString() + ");";
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
            String pagoString = pago.Year.ToString() + "-" + pago.Month.ToString() + "-" + pago.Day.ToString();
            String ingresoString = ingreso.Year.ToString() + "-" + ingreso.Month.ToString() + "-" + ingreso.Day.ToString();
            comando.CommandText = "INSERT INTO  deuda (Fecha_Pago, Total, Cliente_NIT, Sucursal_ID, Fecha_Ingreso) VALUES ('" + pagoString + "'," + total.ToString() + ",'" + nit + "'," + idSucursal.ToString() + ",'" + ingresoString + "');";
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
        public void ingresoTelefono(String telefono, int idEncargado)
        {
            comando = Variable_Conexion.CreateCommand();
            comando.CommandText = "INSERT INTO telefono (Telefono, Encargado_id) VALUES ('" + telefono + "'," + idEncargado.ToString() + ");";
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
        public void ingresoTelefono(String telefono, String nitDpiCliente)
        {
            comando = Variable_Conexion.CreateCommand();
            comando.CommandText = "INSERT INTO telefono (Telefono, Cliente_NIT) VALUES ('" + telefono + "','" + nitDpiCliente + "');";
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
        public void ingresoProveedorProducto (String codInternoProducto, int idProveedor, double precioProveedor)
        {
            comando = Variable_Conexion.CreateCommand();
            comando.CommandText = "INSERT INTO prov_prod (Producto_Codigo_Interno, Proveedor_ID, Precio_Proveedor) VALUES ('" + codInternoProducto + "'," + idProveedor.ToString() + "," + precioProveedor.ToString() + ");";
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

        //---------------MODIFICACIONES--------------//


        public void modificacionEncargado(int ID, String nombre, String correo, int idProveedor)
        {
            comando = Variable_Conexion.CreateCommand();
            comando.CommandText = "UPDATE encargado SET Nombre='" + nombre + "', Correo='" + correo + "', Proveedor_ID=" + idProveedor.ToString() + " WHERE id="+ID.ToString()+";";
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
        public void modificacionProveedor(int ID, String nombre, DateTime fecha, int idPais)
        {
            comando = Variable_Conexion.CreateCommand();
            String fechaString = fecha.Year.ToString() + "-" + fecha.Month.ToString() + "-" + fecha.Day.ToString();
            comando.CommandText = "UPDATE proveedor SET Nombre='" + nombre + "', Fecha='" + fechaString + "', Pais_ID=" + idPais.ToString() + " WHERE ID="+ID.ToString()+";";
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
        public void modificacionTrabajador(int ID, String nombre, double salario, int idSucursal)
        {
            comando = Variable_Conexion.CreateCommand();
            comando.CommandText = "UPDATE trabajador SET Nombre='" + nombre + "', Salario=" + salario + ", Sucursal_ID=" + idSucursal.ToString() + " WHERE ID=" + ID.ToString() + ";";
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
        public void modificacionAusencia(int ID, DateTime fecha, int idTrabajador)
        {
            comando = Variable_Conexion.CreateCommand();
            String fechaString = fecha.Year.ToString() + "-" + fecha.Month.ToString() + "-" + fecha.Day.ToString();
            comando.CommandText = "UPDATE ausencia SET Fecha='" + fechaString + "', Trabajador_idTrabajador=" + idTrabajador.ToString() + " WHERE Id=" + ID.ToString() + ";";
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
        public void modificacionPagoPrestamo(int ID, DateTime fecha, double monto, int idPrestamo, DateTime fechaIngreso)
        {
            comando = Variable_Conexion.CreateCommand();
            String fechaString = fecha.Year.ToString() + "-" + fecha.Month.ToString() + "-" + fecha.Day.ToString();
            String ingresoString = fechaIngreso.Year.ToString() + "-" + fechaIngreso.Month.ToString() + "-" + fechaIngreso.Day.ToString();
            comando.CommandText = "UPDATE pagos SET (Fecha='" + fechaString + "', Monto=" + monto.ToString() + ", Prestamo_ID=" + idPrestamo.ToString() + ", Fecha_Ingreso='" + ingresoString + "') WHERE ID=" + ID.ToString() + " AND Prestamo_ID != NULL;";
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
        public void modificacionPagoDeuda(DateTime fecha, double monto, int idDeuda, DateTime fechaIngreso)
        {
            comando = Variable_Conexion.CreateCommand();
            String fechaString = fecha.Year.ToString() + "-" + fecha.Month.ToString() + "-" + fecha.Day.ToString();
            String ingresoString = fechaIngreso.Year.ToString() + "-" + fechaIngreso.Month.ToString() + "-" + fechaIngreso.Day.ToString();
            comando.CommandText = "UPDATE pagos (Fecha, Monto, Deuda_ID, Fecha_Ingreso) VALUES ('" + fechaString + "'," + monto.ToString() + "," + idDeuda.ToString() + ",'" + ingresoString + "');";
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
        public void modificacionUsuario(String nombre, String clave, String pedidos, String clientes, String trabajadores, String seguridad)
        {
            comando = Variable_Conexion.CreateCommand();
            comando.CommandText = "UPDATE usuario SET Clave='" + clave + "', Acceso_Pedidos='" + pedidos + "', Acceso_Clientes='" + clientes + "', Acceso_Trabajadores='" + trabajadores + "', Acceso_Seguridad='" + seguridad + "' WHERE nombre='" + nombre + "';";
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
        /// <summary>
        /// Cambia la contraseña del usuario
        /// </summary>
        /// <param name="nombre">Nombre del usuario al cual se le cambiará la contraseña</param>
        /// <param name="clave">Nueva contraseña</param>
        public void modificacionUsuario(String nombre, String clave)
        {
            comando = Variable_Conexion.CreateCommand();
            comando.CommandText = "UPDATE usuario SET Clave='" + clave + "' WHERE nombre='" + nombre + "';";
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
        public void modificacionClasificacion(int ID, String tipo)
        {
            comando = Variable_Conexion.CreateCommand();
            comando.CommandText = "UPDATE clasicacion SET Tipo='" + tipo + "' WHERE ID="+ID.ToString()+";";
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
        public void modificacionPais(int ID, String nombre)
        {
            comando = Variable_Conexion.CreateCommand();
            comando.CommandText = "UPDATE pais SET Nombre='" + nombre + "' WHERE ID="+ID.ToString()+";";
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
        public void modificacionCliente(String NitDpi, String nombre, int diasCredito, int limiteCredito, int clasificacionId)
        {
            comando = Variable_Conexion.CreateCommand();
            comando.CommandText = "UPDATE cliente SET NIT_DPI='" + NitDpi + "', Nombre='" + nombre + "', Dias_Credito=" + diasCredito.ToString() + ", Limite_Credito=" + limiteCredito.ToString() + ", Clasicacion_Id=" + clasificacionId.ToString() + ") WHERE NIT_DPI='" + NitDpi + "';";
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
        public void modificacionPedido(double total, int idProveedor)
        {
            comando = Variable_Conexion.CreateCommand();
            comando.CommandText = "UPDATE pedido (Total, Proveedor_ID) VALUES (" + total.ToString() + "," + idProveedor.ToString() + ");";
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
        public void modificacionPrestamo(double monto, int idTrabajador)
        {
            comando = Variable_Conexion.CreateCommand();
            comando.CommandText = "UPDATE prestamo (Monto, Trabajador_idTrabajador) VALUES (" + monto.ToString() + "," + idTrabajador + ");";
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
        public void modificacionSucursal(String nombre)
        {
            comando = Variable_Conexion.CreateCommand();
            comando.CommandText = "UPDATE Sucursal (nombre) VALUES ('" + nombre + "');";
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
        public void modificacionDeuda(DateTime pago, double total, string nit, int idSucursal, DateTime ingreso)
        {
            comando = Variable_Conexion.CreateCommand();
            String pagoString = pago.Year.ToString() + "-" + pago.Month.ToString() + "-" + pago.Day.ToString();
            String ingresoString = ingreso.Year.ToString() + "-" + ingreso.Month.ToString() + "-" + ingreso.Day.ToString();
            comando.CommandText = "UPDATE  deuda (Fecha_Pago, Total, Cliente_NIT, Sucursal_ID, Fecha_Ingreso) VALUES ('" + pagoString + "'," + total.ToString() + ",'" + nit + "'," + idSucursal.ToString() + ",'" + ingresoString + "');";
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
        public void modificacionProducto(String codInterno, String codFabricante, String marca, String fabricante, String departamento, Double precioCosto, Double precioVenta)
        {
            comando = Variable_Conexion.CreateCommand();
            comando.CommandText = "UPDATE producto (Codigo_Interno, Codigo_Fabricante, Marca, Fabricante, Departamento, Precio_Costo, Precio_Venta) VALUES ('" + codInterno + "','" + codFabricante + "','" + marca + "','" + fabricante + "','" + departamento + "'," + precioCosto.ToString() + "," + precioVenta.ToString() + ");";
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
        public void modificacionTelefono(String telefono, int idEncargado)
        {
            comando = Variable_Conexion.CreateCommand();
            comando.CommandText = "UPDATE telefono (Telefono, Encargado_id) VALUES ('" + telefono + "'," + idEncargado.ToString() + ");";
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
        public void modificacionTelefono(String telefono, String nitDpiCliente)
        {
            comando = Variable_Conexion.CreateCommand();
            comando.CommandText = "UPDATE telefono (Telefono, Cliente_NIT) VALUES ('" + telefono + "','" + nitDpiCliente + "');";
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


        //--------------------MODIFICACION RELACIONES--------------------//


        public void modificacionDetallePedido(String codInternoProducto, int numeroPedido, int cantidad)
        {
            comando = Variable_Conexion.CreateCommand();
            comando.CommandText = "UPDATE detalle_pedido (Producto_Codigo_Interno, Pedido_Numero, Cantidad) VALUES ('" + codInternoProducto + "'," + numeroPedido.ToString() + "," + cantidad.ToString() + ");";
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
        public void modificacionProductoSucursal(int idSucursal, String codInternoProducto, int existencia)
        {
            comando = Variable_Conexion.CreateCommand();
            comando.CommandText = "UPDATE prod_suc (Sucursal_ID, Producto_Codigo_Interno, Existencia) VALUES (" + idSucursal.ToString() + ",'" + codInternoProducto + "'," + existencia.ToString() + ");";
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
        public void modificacionProveedorProducto(String codInternoProducto, int idProveedor, double precioProveedor)
        {
            comando = Variable_Conexion.CreateCommand();
            comando.CommandText = "UPDATE prov_prod (Producto_Codigo_Interno, Proveedor_ID, Precio_Proveedor) VALUES ('" + codInternoProducto + "'," + idProveedor.ToString() + "," + precioProveedor.ToString() + ");";
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


        //---------------OTROS---------------//


        public String[] obtener_sucursales()
        {
            String[] sucursales=null;
            int total;
            comando = Variable_Conexion.CreateCommand();//Inicializacion del comando 
            comando.CommandText = "SELECT COUNT(*) FROM sucursal;";//Consulta para la base, obtener el numero de sucursales
            Variable_Conexion.Open();//se abre la conexion a la base
            Variable_Lectura = comando.ExecuteReader();//se guarda el conteo en la variable de lectura
            if (Variable_Lectura.Read())//se verifica si se obtiene algun dato de la base
            {
                total = int.Parse(Variable_Lectura[0].ToString());//se convierte el objeto reader en una cadena y luego un entero
                sucursales = new String[total];//se crea un arreglo de cadenas del tamaño del conteo obtenido de sucursales
                comando.CommandText = "SELECT Nombre FROM sucursal;";
                Variable_Conexion.Close();//se cierra la conexion
                Variable_Conexion.Open();
                Variable_Lectura = comando.ExecuteReader();
                int contador = 0;
                while(Variable_Lectura.Read())
                {
                   sucursales[contador] = Variable_Lectura[0].ToString();
                   contador++;
                }
            }
            Variable_Conexion.Close();//se cierra la conexion
            return sucursales;
        }

    }
    
}
