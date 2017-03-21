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
            Constructor_Conexion.Server = "25.73.161.33";//Direccion IP del servidor
            Constructor_Conexion.UserID = "root";//Ususario de la base de datos
            Constructor_Conexion.Password = "@Sistemas2017";//Contraseña para la base de datos 
            Constructor_Conexion.Database = "rm_db";//Nombre de la base de datos
            Variable_Conexion = new MySqlConnection(Constructor_Conexion.ToString());//creacion de variable de conexion
        }
        /// <summary>
        /// Metodo que obtiene la contraseña de un usuario de la base de datos
        /// </summary>
        /// <param name="usuario">El usuario del cual se obtendrá la contraseña</param>
        /// <returns></returns>
        public string Us_con(string usuario)
        {
            try
            {
                string contraseña = "";                                //Variable que guarda la contraseña obtenida de la base
                comando = Variable_Conexion.CreateCommand();           //Inicializacion del comando 
                comando.CommandText = "SELECT Clave FROM usuario WHERE Nombre = '" + usuario + "';";   //Consulta para la base
                Variable_Conexion.Open();                              //se abre la conexion a la base
                Variable_Lectura = comando.ExecuteReader();            //se guarda la contraseña en la variable de lectura
                if (Variable_Lectura.Read() == true)                   //se verifica si se obtiene algun dato de la base
                {
                    contraseña = Variable_Lectura["Clave"].ToString();
                    Vig.descifrar(contraseña, Vig.getCP());//se guarda la contraseña
                    contraseña = Vig.getMD();
                }

                Variable_Conexion.Close();                                                               //se cierra la conexion
                return contraseña;                                    //regresa la contraseña obtenida de la base
            }
            catch (MySqlException e)
            {
                Variable_Conexion.Close();
                throw e;
            }
        }

        /// <summary>
        /// Obtiene los datos de los usuarios y devuelve los datos en un objeto de la clase Usuario 
        /// </summary>
        /// <param name="usuario">nombre del usuario</param>
        /// <returns>Objeto de tipo Usuario</returns>
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
            try
            {
                Variable_Conexion.Open();
                comando.ExecuteNonQuery();
                Variable_Conexion.Close();
            }
            catch (MySqlException e)
            {
                Variable_Conexion.Close();
                throw e;
            }
        }
        /// <summary>
        /// Ingresa los datos del Proveedor a la BD
        /// </summary>
        /// <param name="nombre">Nombre del proveedor</param>
        /// <param name="idPais">ID del país donde se encuentra el proveedor</param>
        public void ingresoProveedor(String nombre, int idPais){
            comando = Variable_Conexion.CreateCommand();
            comando.CommandText = "INSERT INTO proveedor (Nombre, Pais_ID) VALUES ('" + nombre + "'," + idPais.ToString() + ");";
            try
            {
                Variable_Conexion.Open();
                comando.ExecuteNonQuery();
                Variable_Conexion.Close();
            }
            catch (MySqlException e)
            {
                Variable_Conexion.Close();
                throw e;
            }
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
            try
            {
                Variable_Conexion.Open();
                comando.ExecuteNonQuery();
                Variable_Conexion.Close();
            }
            catch (MySqlException e)
            {
                Variable_Conexion.Close();
                throw e;
            }
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
            try
            {
                Variable_Conexion.Open();
                comando.ExecuteNonQuery();
                Variable_Conexion.Close();
            }
            catch (MySqlException e)
            {
                Variable_Conexion.Close();
                throw e;
            }
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
            try
            {
                Variable_Conexion.Open();
                comando.ExecuteNonQuery();
                Variable_Conexion.Close();
            }
            catch (MySqlException e)
            {
                Variable_Conexion.Close();
                throw e;
            }
        }
        /// <summary>
        /// Ingreso de los pagos a las deudas adquiridas
        /// </summary>
        /// <param name="fecha">Fecha en que se realiza el pago</param>
        /// <param name="monto">Monto a pagar</param>
        /// <param name="idDeuda">ID de la deuda a la cual se esta pagando</param>
        /// <param name="fechaIngreso">Fecha de ingreso del pago al sistema</param>
        public void ingresoPagoDeuda(DateTime fecha, double monto, int idDeuda, DateTime fechaIngreso)
        {
            comando = Variable_Conexion.CreateCommand();
            String fechaString = fecha.Year.ToString() + "-" + fecha.Month.ToString() + "-" + fecha.Day.ToString();
            String ingresoString = fechaIngreso.Year.ToString() + "-" + fechaIngreso.Month.ToString() + "-" + fechaIngreso.Day.ToString();
            comando.CommandText = "INSERT INTO pagos (Fecha, Monto, Deuda_ID, Fecha_Ingreso) VALUES ('" + fechaString + "'," + monto.ToString() + "," + idDeuda.ToString() + ",'" + ingresoString + "');";
            try
            {
                Variable_Conexion.Open();
                comando.ExecuteNonQuery();
                Variable_Conexion.Close();
            }
            catch (MySqlException e)
            {
                Variable_Conexion.Close();
                throw e;
            }
        }
        /// <summary>
        /// Ingreso de un nuevo usuario a la BD
        /// </summary>
        /// <param name="nombre">Nombre del nuevo usuario (ID, no utilizar espacios de preferencia)</param>
        /// <param name="clave">Contraseña de acceso al programa, del usuario a ingresar</param>
        /// <param name="pedidos">Cadena que valida el ingreso, modificación y/o eliminación de pedidos</param>
        /// <param name="clientes">Cadena que valida el ingreso, modificación y/o eliminación de clientes</param>
        /// <param name="trabajadores">Cadena que valida el ingreso, modificación y/o eliminación de trabajadores</param>
        /// <param name="seguridad">Cadena que valida la gestión de seguridad</param>
        public void ingresoUsuario(String nombre, String clave, String pedidos, String clientes, String trabajadores, String seguridad)
        {
            comando = Variable_Conexion.CreateCommand();
            comando.CommandText = "INSERT INTO usuario (Nombre, Clave, Acceso_Pedidos, Acceso_Clientes, Acceso_Trabajadores, Acceso_Seguridad) VALUES ('" + nombre + "','" + clave + "','" + pedidos + "','" + clientes + "','" + trabajadores + "','" + seguridad + "');";
            try
            {
                Variable_Conexion.Open();
                comando.ExecuteNonQuery();
                Variable_Conexion.Close();
            }
            catch (MySqlException e)
            {
                Variable_Conexion.Close();
                throw e;
            }
        }
        /// <summary>
        /// Ingreso de clasificación de usuarios
        /// </summary>
        /// <param name="tipo">Nombre del tipo de clasificación</param>
        public void ingresoClasificacion(String tipo)
        {
            comando = Variable_Conexion.CreateCommand();
            comando.CommandText = "INSERT INTO clasificacion (Tipo) VALUES ('" + tipo + "');"; 
            try
            {
                Variable_Conexion.Open();
                comando.ExecuteNonQuery();
                Variable_Conexion.Close();
            }
            catch (MySqlException e)
            {
                Variable_Conexion.Close();
                throw e;
            }
        }
        /// <summary>
        /// Ingreso de los paises donde se encuentran los proveedores
        /// </summary>
        /// <param name="nombre">Nombre del país a ingresar</param>
        public void ingresoPais(String nombre)
        {
            comando = Variable_Conexion.CreateCommand();
            comando.CommandText = "INSERT INTO pais (Nombre) VALUES ('" + nombre + "');";
            try
            {
                Variable_Conexion.Open();
                comando.ExecuteNonQuery();
                Variable_Conexion.Close();
            }
            catch (MySqlException e)
            {
                Variable_Conexion.Close();
                throw e;
            }
        }

        /// <summary>
        /// Ingreso de clientes nuevos
        /// </summary>
        /// <param name="NitDpi">NIT o DPI del cliente</param>
        /// <param name="nombre">Nombre del cliente</param>
        /// <param name="apellido">Apellido del cliente</param>
        /// <param name="diasCredito">Días de crédito para darle al cliente</param>
        /// <param name="limiteCredito">Monto máximo el cual el cliente puede debernos</param>
        /// <param name="clasificacionId">ID del la clasificación que será el cliente</param>
        public void ingresoCliente(String NitDpi, String nombre, String apellido, int diasCredito, int limiteCredito, int clasificacionId)
        {
            comando = Variable_Conexion.CreateCommand();
            comando.CommandText = "INSERT INTO cliente (NIT_DPI, Nombre, Apellido, Dias_Credito, Limite_Credito, Clasicacion_Id) VALUES ('" + NitDpi + "','" + nombre + "','"+apellido+"'," + diasCredito.ToString() + "," + limiteCredito.ToString() + "," + clasificacionId.ToString() + ");";
            try
            {
                Variable_Conexion.Open();
                comando.ExecuteNonQuery();
                Variable_Conexion.Close();
            }
            catch (MySqlException e)
            {
                Variable_Conexion.Close();
                throw e;
            }
        }
        /// <summary>
        /// Ingreso de pedidos de mercadería a los proveedores
        /// </summary>
        /// <param name="fecha">Fecha en que se realizó el pedido</param>
        /// <param name="total">Total a pagar en el pedido</param>
        /// <param name="idProveedor">ID del proveedor al cual se le esta comprando</param>
        public void ingresoPedido(DateTime fecha, double total, int idProveedor)
        {
            comando = Variable_Conexion.CreateCommand();
            String fechaString = fecha.Year.ToString() + "-" + fecha.Month.ToString() + "-" + fecha.Day.ToString();
            comando.CommandText = "INSERT INTO pedido (Fecha, Total, Proveedor_ID) VALUES ('"+fechaString+"'," + total.ToString() + "," + idProveedor.ToString() + ");";
            try
            {
                Variable_Conexion.Open();
                comando.ExecuteNonQuery();
                Variable_Conexion.Close();
            }
            catch (MySqlException e)
            {
                Variable_Conexion.Close();
                throw e;
            }
        }
        /// <summary>
        /// Ingreso de prestamos dados a los trabajadores
        /// </summary>
        /// <param name="monto">Cantidad que se le ha prestado al trabajador</param>
        /// <param name="idTrabajador">ID del trabajador al cual se le está prestando</param>
        public void ingresoPrestamo(double monto, int idTrabajador)
        {
            comando = Variable_Conexion.CreateCommand();
            comando.CommandText = "INSERT INTO prestamo (Monto, Trabajador_idTrabajador) VALUES (" + monto.ToString() + "," + idTrabajador + ");";
            try
            {
                Variable_Conexion.Open();
                comando.ExecuteNonQuery();
                Variable_Conexion.Close();
            }
            catch (MySqlException e)
            {
                Variable_Conexion.Close();
                throw e;
            }
        }
        /// <summary>
        /// Ingreso de sucursales
        /// </summary>
        /// <param name="nombre">Nombre de la sucursal</param>
        public void ingresoSucursal (String nombre)
        {
            comando = Variable_Conexion.CreateCommand();
            comando.CommandText = "INSERT INTO Sucursal (nombre) VALUES ('" + nombre + "');";
            try
            {
                Variable_Conexion.Open();
                comando.ExecuteNonQuery();
                Variable_Conexion.Close();
            }
            catch (MySqlException e)
            {
                Variable_Conexion.Close();
                throw e;
            }
        }
        /// <summary>
        /// Ingreso de deuda adquirida por un cliente hacia la empresa
        /// </summary>
        /// <param name="pago">Fecha límite de pago de la deuda</param>
        /// <param name="total">Total a pagar</param>
        /// <param name="nit">NIT o DPI del cliente que debe pagarnos</param>
        /// <param name="idSucursal">ID de la sucursal en donde se adquirió la deuda</param>
        /// <param name="ingreso">Fecha de ingreso de la deuda al sistema</param>
        public void ingresoDeuda(DateTime pago, double total, string nit, int idSucursal, DateTime ingreso)
        {
            comando = Variable_Conexion.CreateCommand();
            String pagoString = pago.Year.ToString() + "-" + pago.Month.ToString() + "-" + pago.Day.ToString();
            String ingresoString = ingreso.Year.ToString() + "-" + ingreso.Month.ToString() + "-" + ingreso.Day.ToString();
            comando.CommandText = "INSERT INTO  deuda (Fecha_Pago, Total, Cliente_NIT, Sucursal_ID, Fecha_Ingreso) VALUES ('" + pagoString + "'," + total.ToString() + ",'" + nit + "'," + idSucursal.ToString() + ",'" + ingresoString + "');";
            try
            {
                Variable_Conexion.Open();
                comando.ExecuteNonQuery();
                Variable_Conexion.Close();
            }
            catch (MySqlException e)
            {
                Variable_Conexion.Close();
                throw e;
            }
        }
        /// <summary>
        /// Ingreso de nuevos productos
        /// </summary>
        /// <param name="codInterno">Código interno en la empresa del producto</param>
        /// <param name="codFabricante">Código del fabricante</param>
        /// <param name="descripcion">Descripción del producto</param>
        /// <param name="marca">Marca del producto</param>
        /// <param name="fabricante">Fabricante del producto</param>
        /// <param name="departamento">Departamento (clasificación) al cual pertenece el producto</param>
        /// <param name="precioCosto">Precio de costo del producto</param>
        /// <param name="precioVenta">Precio de venta al público del producto</param>
        public void ingresoProducto(String codInterno, String codFabricante, String descripcion, String marca, String fabricante, String departamento, Double precioCosto, Double precioVenta)
        {
            comando = Variable_Conexion.CreateCommand();
            comando.CommandText = "INSERT INTO producto (Codigo_Interno, Codigo_Fabricante, Descripcion, Marca, Fabricante, Departamento, Precio_Costo, Precio_Venta) VALUES ('" + codInterno + "','" + codFabricante + "','" + descripcion + "','" + marca + "','" + fabricante + "','" + departamento + "'," + precioCosto.ToString() + "," + precioVenta.ToString() + ");";
            try{
                Variable_Conexion.Open();
                comando.ExecuteNonQuery();
                Variable_Conexion.Close();
            }
            catch(MySqlException e)
            {
                Variable_Conexion.Close();
                throw e;
            }
        }
        /// <summary>
        /// Ingreso de teléfonos para encargados de ventas de los proveedores
        /// </summary>
        /// <param name="telefono">Número de teléfono</param>
        /// <param name="idEncargado">ID del encargado de ventas del proveedor</param>
        public void ingresoTelefono(String telefono, int idEncargado)
        {
            comando = Variable_Conexion.CreateCommand();
            comando.CommandText = "INSERT INTO telefono (Telefono, Encargado_id) VALUES ('" + telefono + "'," + idEncargado.ToString() + ");";
            try
            {
                Variable_Conexion.Open();
                comando.ExecuteNonQuery();
                Variable_Conexion.Close();
            }
            catch (MySqlException e)
            {
                Variable_Conexion.Close();
                throw e;
            }
        }
        /// <summary>
        /// Ingreso de teléfonos para clientes
        /// </summary>
        /// <param name="telefono">Número de teléfono del cliente</param>
        /// <param name="nitDpiCliente">NIT o DPI del cliente al cual pertenece el teléfono</param>
        public void ingresoTelefono(String telefono, String nitDpiCliente)
        {
            comando = Variable_Conexion.CreateCommand();
            comando.CommandText = "INSERT INTO telefono (Telefono, Cliente_NIT) VALUES ('" + telefono + "','" + nitDpiCliente + "');";
            try
            {
                Variable_Conexion.Open();
                comando.ExecuteNonQuery();
                Variable_Conexion.Close();
            }
            catch (MySqlException e)
            {
                Variable_Conexion.Close();
                throw e;
            }
        }
            //--------------------INGRESO RELACIONES--------------------//


        /// <summary>
        /// Ingreso de los detalles de un pedido
        /// </summary>
        /// <param name="codInternoProducto">Código interno del producto</param>
        /// <param name="numeroPedido">Número del pedido el cual se está detallando</param>
        /// <param name="cantidad">Cantidad comprada del producto</param>
        /// <param name="precioCompra">Precio al cual se compró el producto en este pedido</param>
        public void ingresoDetallePedido(String codInternoProducto, int numeroPedido, int cantidad, double precioCompra)
        {
            comando = Variable_Conexion.CreateCommand();
            comando.CommandText = "INSERT INTO detalle_pedido (Producto_Codigo_Interno, Pedido_Numero, Cantidad, Precio_Compra) VALUES ('" + codInternoProducto + "'," + numeroPedido.ToString() + "," + cantidad.ToString() + ","+precioCompra.ToString()+");";
            try
            {
                Variable_Conexion.Open();
                comando.ExecuteNonQuery();
                Variable_Conexion.Close();
            }
            catch (MySqlException e)
            {
                Variable_Conexion.Close();
                throw e;
            }
        }
        /// <summary>
        /// Ingreso de inventario de un producto en cierta sucursal
        /// </summary>
        /// <param name="idSucursal">ID de la sucursal en la cual se encuentra el producto</param>
        /// <param name="codInternoProducto">Código interno del producto</param>
        /// <param name="existencia">Cantidad disponible en la sucursal de este producto</param>
        public void ingresoProductoSucursal(int idSucursal, String codInternoProducto, double existencia)
        {
            comando = Variable_Conexion.CreateCommand();
            comando.CommandText = "INSERT INTO prod_suc (Sucursal_ID, Producto_Codigo_Interno, Existencia) VALUES ('" + idSucursal.ToString() + "','" + codInternoProducto + "','" + existencia.ToString() + "');";
            try
            {
                Variable_Conexion.Open();
                comando.ExecuteNonQuery();
                Variable_Conexion.Close();
            }
            catch (MySqlException e)
            {
                Variable_Conexion.Close();
                throw e;
            }
        }
        /// <summary>
        /// Ingreso del precio al cual vende el proveedor cierto producto
        /// </summary>
        /// <param name="codInternoProducto">Codigo interno del producto</param>
        /// <param name="idProveedor">ID del proveedor que tiene este precio</param>
        /// <param name="precioProveedor">Precio que el proveedor le tiene al producto</param>
        public void ingresoProveedorProducto (String codInternoProducto, int idProveedor, double precioProveedor)
        {
            comando = Variable_Conexion.CreateCommand();
            comando.CommandText = "INSERT INTO prov_prod (Producto_Codigo_Interno, Proveedor_ID, Precio_Proveedor) VALUES ('" + codInternoProducto + "'," + idProveedor.ToString() + "," + precioProveedor.ToString() + ");";
            try
            {
                Variable_Conexion.Open();
                comando.ExecuteNonQuery();
                Variable_Conexion.Close();
            }
            catch (MySqlException e)
            {
                Variable_Conexion.Close();
                throw e;
            }
        }

        //---------------MODIFICACIONES--------------//


        /// <summary>
        /// Modifica los datos de un usuario
        /// </summary>
        /// <param name="ID">ID del trabajador a modificar</param>
        /// <param name="nombre">Nuevo nombre del trabajador</param>
        /// <param name="correo">Nuevo correo del trabajador</param>
        /// <param name="idProveedor">Nuevo ID del proveedor al que pertenece</param>
        public void modificacionEncargado(int ID, String nombre, String correo, int idProveedor)
        {
            comando = Variable_Conexion.CreateCommand();
            comando.CommandText = "UPDATE encargado SET Nombre='" + nombre + "', Correo='" + correo + "', Proveedor_ID=" + idProveedor.ToString() + " WHERE id="+ID.ToString()+";";
            try
            {
                Variable_Conexion.Open();
                comando.ExecuteNonQuery();
                Variable_Conexion.Close();
            }
            catch (MySqlException e)
            {
                Variable_Conexion.Close();
                throw e;
            }
        }
        /// <summary>
        /// Modifica los datos del proveedor
        /// </summary>
        /// <param name="ID">ID del proveedor a modificar</param>
        /// <param name="nombre">Nuevo nombre del proveedor</param>
        /// <param name="idPais">Nuevo ID de país</param>
        public void modificacionProveedor(int ID, String nombre, int idPais)
        {
            comando = Variable_Conexion.CreateCommand();
            comando.CommandText = "UPDATE proveedor SET Nombre='" + nombre + "', Pais_ID=" + idPais.ToString() + " WHERE ID="+ID.ToString()+";";
            try
            {
                Variable_Conexion.Open();
                comando.ExecuteNonQuery();
                Variable_Conexion.Close();
            }
            catch (MySqlException e)
            {
                Variable_Conexion.Close();
                throw e;
            }
        }
        /// <summary>
        /// Modifica los datos del trabajador
        /// </summary>
        /// <param name="ID">ID del trabajador a modificar</param>
        /// <param name="nombre">Nuevo nombre del trabajador</param>
        /// <param name="salario">Nuevo salario del trabajador</param>
        /// <param name="idSucursal">Nuevo ID de la sucursal donde trabaja</param>
        public void modificacionTrabajador(int ID, String nombre, double salario, int idSucursal)
        {
            comando = Variable_Conexion.CreateCommand();
            comando.CommandText = "UPDATE trabajador SET Nombre='" + nombre + "', Salario=" + salario + ", Sucursal_ID=" + idSucursal.ToString() + " WHERE ID=" + ID.ToString() + ";";
            try
            {
                Variable_Conexion.Open();
                comando.ExecuteNonQuery();
                Variable_Conexion.Close();
            }
            catch (MySqlException e)
            {
                Variable_Conexion.Close();
                throw e;
            }
        }
        /// <summary>
        /// Modifica los datos de una ausencia
        /// </summary>
        /// <param name="ID">ID de la ausencia a modificar</param>
        /// <param name="fecha">Nueva fecha de ausencia</param>
        /// <param name="idTrabajador">Nuevo ID del trabajador que se ausentó</param>
        public void modificacionAusencia(int ID, DateTime fecha, int idTrabajador)
        {
            comando = Variable_Conexion.CreateCommand();
            String fechaString = fecha.Year.ToString() + "-" + fecha.Month.ToString() + "-" + fecha.Day.ToString();
            comando.CommandText = "UPDATE ausencia SET Fecha='" + fechaString + "', Trabajador_idTrabajador=" + idTrabajador.ToString() + " WHERE Id=" + ID.ToString() + ";";
            try
            {
                Variable_Conexion.Open();
                comando.ExecuteNonQuery();
                Variable_Conexion.Close();
            }
            catch (MySqlException e)
            {
                Variable_Conexion.Close();
                throw e;
            }
        }
        /// <summary>
        /// Modifica los datos de un pago, de un prestamo a un trabajador
        /// </summary>
        /// <param name="ID">ID del pago</param>
        /// <param name="fecha">Nueva fecha de pago</param>
        /// <param name="monto">Nuevo monto pagado</param>
        /// <param name="idPrestamo">Nuevo ID del prestamo al cual corresponde el pago</param>
        /// <param name="fechaIngreso">Nueva fecha de ingreso del registro del pago</param>
        public void modificacionPagoPrestamo(int ID, DateTime fecha, double monto, int idPrestamo, DateTime fechaIngreso)
        {
            comando = Variable_Conexion.CreateCommand();
            String fechaString = fecha.Year.ToString() + "-" + fecha.Month.ToString() + "-" + fecha.Day.ToString();
            String ingresoString = fechaIngreso.Year.ToString() + "-" + fechaIngreso.Month.ToString() + "-" + fechaIngreso.Day.ToString();
            comando.CommandText = "UPDATE pagos SET Fecha='" + fechaString + "', Monto=" + monto.ToString() + ", Prestamo_ID=" + idPrestamo.ToString() + ", Fecha_Ingreso='" + ingresoString + "' WHERE ID=" + ID.ToString() + " AND Deuda_ID IS NULL;";
            try
            {
                Variable_Conexion.Open();
                comando.ExecuteNonQuery();
                Variable_Conexion.Close();
            }
            catch (MySqlException e)
            {
                Variable_Conexion.Close();
                throw e;
            }
        }
        /// <summary>
        /// Modifica el los datos de un pago, de un cliente
        /// </summary>
        /// <param name="ID">ID del pago</param>
        /// <param name="fecha">Nueva fecha de pago</param>
        /// <param name="monto">Nuevo monto a pagar</param>
        /// <param name="idDeuda">Nuevo ID de la deuda a la que corresponde el pago</param>
        /// <param name="fechaIngreso">Nueva fecha de ingreso del registro del pago</param>
        public void modificacionPagoDeuda(int ID, DateTime fecha, double monto, int idDeuda, DateTime fechaIngreso)
        {
            comando = Variable_Conexion.CreateCommand();
            String fechaString = fecha.Year.ToString() + "-" + fecha.Month.ToString() + "-" + fecha.Day.ToString();
            String ingresoString = fechaIngreso.Year.ToString() + "-" + fechaIngreso.Month.ToString() + "-" + fechaIngreso.Day.ToString();
            comando.CommandText = "UPDATE pagos SET Fecha='" + fechaString + "', Monto=" + monto.ToString() + ", Deuda_ID=" + idDeuda.ToString() + ", Fecha_Ingreso='" + ingresoString + "' WHERE ID=" + ID.ToString() + " AND Prestamo_ID IS NULL;";
            try
            {
                Variable_Conexion.Open();
                comando.ExecuteNonQuery();
                Variable_Conexion.Close();
            }
            catch (MySqlException e)
            {
                Variable_Conexion.Close();
                throw e;
            }
        }
        /// <summary>
        /// Modifica TODOS los datos del usuario
        /// </summary>
        /// <param name="nombre">Nombre del usuario a modificar</param>
        /// <param name="clave">Nueva contraseña</param>
        /// <param name="pedidos">Autorización de pedidos</param>
        /// <param name="clientes">Autorización de clientes</param>
        /// <param name="trabajadores">Autorización de trabajadores</param>
        /// <param name="seguridad">Autorización de seguridad</param>
        public void modificacionUsuario(String nombre, String clave, String pedidos, String clientes, String trabajadores, String seguridad)
        {
            comando = Variable_Conexion.CreateCommand();
            comando.CommandText = "UPDATE usuario SET Clave='" + clave + "', Acceso_Pedidos='" + pedidos + "', Acceso_Clientes='" + clientes + "', Acceso_Trabajadores='" + trabajadores + "', Acceso_Seguridad='" + seguridad + "' WHERE nombre='" + nombre + "';";
            try
            {
                Variable_Conexion.Open();
                comando.ExecuteNonQuery();
                Variable_Conexion.Close();
            }
            catch (MySqlException e)
            {
                Variable_Conexion.Close();
                throw e;
            }
        }
        /// <summary>
        /// Modifica los accesos del usuario
        /// </summary>
        /// <param name="nombre">Nombre del usuario a modificar</param>
        /// <param name="pedidos">Autorización de pedidos</param>
        /// <param name="clientes">Autorización de clientes</param>
        /// <param name="trabajadores">Autorización de trabajadores</param>
        /// <param name="seguridad">Autorización de seguridad</param>
        public void modificacionUsuario(String nombre, String pedidos, String clientes, String trabajadores, String seguridad)
        {
            comando = Variable_Conexion.CreateCommand();
            comando.CommandText = "UPDATE usuario SET Acceso_Pedidos='" + pedidos + "', Acceso_Clientes='" + clientes + "', Acceso_Trabajadores='" + trabajadores + "', Acceso_Seguridad='" + seguridad + "' WHERE nombre='" + nombre + "';";
            try
            {
                Variable_Conexion.Open();
                comando.ExecuteNonQuery();
                Variable_Conexion.Close();
            }
            catch (MySqlException e)
            {
                Variable_Conexion.Close();
                throw e;
            }
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
            try
            {
                Variable_Conexion.Open();
                comando.ExecuteNonQuery();
                Variable_Conexion.Close();
            }
            catch (MySqlException e)
            {
                Variable_Conexion.Close();
                throw e;
            }
        }
        /// <summary>
        /// Modifica los datos de una clasificacion
        /// </summary>
        /// <param name="ID">ID de la clasificación</param>
        /// <param name="tipo">Nuevo nombre de la clasificación</param>
        public void modificacionClasificacion(int ID, String tipo)
        {
            comando = Variable_Conexion.CreateCommand();
            comando.CommandText = "UPDATE clasificacion SET Tipo='" + tipo + "' WHERE ID=" + ID.ToString() + ";";
            try
            {
                Variable_Conexion.Open();
                comando.ExecuteNonQuery();
                Variable_Conexion.Close();
            }
            catch (MySqlException e)
            {
                Variable_Conexion.Close();
                throw e;
            }
        }
        /// <summary>
        /// Modifica los datos de un país
        /// </summary>
        /// <param name="ID">ID del país</param>
        /// <param name="nombre">Nuevo nombre del país</param>
        public void modificacionPais(int ID, String nombre)
        {
            comando = Variable_Conexion.CreateCommand();
            comando.CommandText = "UPDATE pais SET Nombre='" + nombre + "' WHERE ID="+ID.ToString()+";";
            try
            {
                Variable_Conexion.Open();
                comando.ExecuteNonQuery();
                Variable_Conexion.Close();
            }
            catch (MySqlException e)
            {
                Variable_Conexion.Close();
                throw e;
            }
        }
        /// <summary>
        /// Modifica los datos de un cliente
        /// </summary>
        /// <param name="NitDpi">NIT o DPI del cliente</param>
        /// <param name="nombre">Nuevo nombre del cliente</param>
        /// <param name="apellido">Nuevo apellido del cliente</param>
        /// <param name="diasCredito">Nuevo número de dias de crédito</param>
        /// <param name="limiteCredito">Nuevo límite de crédito</param>
        /// <param name="clasificacionId">Nuevo ID de la clasificación del cliente</param>
        public void modificacionCliente(String NitDpi, String nombre, String apellido, int diasCredito, int limiteCredito, int clasificacionId)
        {
            comando = Variable_Conexion.CreateCommand();
            comando.CommandText = "UPDATE cliente SET NIT_DPI='" + NitDpi + "', Nombre='" + nombre + "', Apellido='"+apellido+"', Dias_Credito=" + diasCredito.ToString() + ", Limite_Credito=" + limiteCredito.ToString() + ", Clasicacion_Id=" + clasificacionId.ToString() + " WHERE NIT_DPI='" + NitDpi + "';";
            try
            {
                Variable_Conexion.Open();
                comando.ExecuteNonQuery();
                Variable_Conexion.Close();
            }
            catch (MySqlException e)
            {
                Variable_Conexion.Close();
                throw e;
            }
        }
        /// <summary>
        /// Modifica los datos de un pedido
        /// </summary>
        /// <param name="Numero">Número de pedido a cambiar</param>
        /// <param name="fecha">Nueva fecha del pedido</param>
        /// <param name="total">Nuevo total del pedido</param>
        /// <param name="idProveedor">Nuevo ID del proveedor al que pertenece</param>
        public void modificacionPedido(int Numero, DateTime fecha, double total, int idProveedor)
        {
            comando = Variable_Conexion.CreateCommand();
            String fechaString = fecha.Year.ToString() + "-" + fecha.Month.ToString() + "-" + fecha.Day.ToString();
            comando.CommandText = "UPDATE pedido SET Fecha='" + fechaString + "', Total=" + total.ToString() + ", Proveedor_ID=" + idProveedor.ToString() + " WHERE Numero=" + Numero.ToString() + ";";
            try
            {
                Variable_Conexion.Open();
                comando.ExecuteNonQuery();
                Variable_Conexion.Close();
            }
            catch (MySqlException e)
            {
                Variable_Conexion.Close();
                throw e;
            }
        }
        /// <summary>
        /// Modifica los datos de un préstamo a un trabajador
        /// </summary>
        /// <param name="ID">ID del préstamo</param>
        /// <param name="monto">Nuevo monto del préstamo</param>
        /// <param name="idTrabajador">Nuevo ID del trabajador al que le pertenece el préstamo</param>
        public void modificacionPrestamo(int ID, double monto, int idTrabajador)
        {
            comando = Variable_Conexion.CreateCommand();
            comando.CommandText = "UPDATE prestamo SET Monto=" + monto.ToString() + ", Trabajador_idTrabajador=" + idTrabajador + " WHERE ID="+ID.ToString()+";";
            try
            {
                Variable_Conexion.Open();
                comando.ExecuteNonQuery();
                Variable_Conexion.Close();
            }
            catch (MySqlException e)
            {
                Variable_Conexion.Close();
                throw e;
            }
        }
        /// <summary>
        /// Modifica los datos de una sucursal
        /// </summary>
        /// <param name="ID">ID de la sucursal</param>
        /// <param name="nombre">Nuevo nombre de la sucursal</param>
        public void modificacionSucursal(int ID, String nombre)
        {
            comando = Variable_Conexion.CreateCommand();
            comando.CommandText = "UPDATE Sucursal SET nombre='" + nombre + "' WHERE ID='"+ID+"';";
            try
            {
                Variable_Conexion.Open();
                comando.ExecuteNonQuery();
                Variable_Conexion.Close();
            }
            catch (MySqlException e)
            {
                Variable_Conexion.Close();
                throw e;
            }
        }
        /// <summary>
        /// Modifica los datos de la deuda de un cliente
        /// </summary>
        /// <param name="ID">ID de la deuda</param>
        /// <param name="pago">Nueva fecha límite de pago</param>
        /// <param name="total">Nuevo total a pagar</param>
        /// <param name="nit">Nuevo NIT o DPI del cliente que va a pagar</param>
        /// <param name="idSucursal">Nueva ID de la sucursal</param>
        /// <param name="ingreso">Nueva fecha de ingreso del registro de la deuda</param>
        public void modificacionDeuda(int ID, DateTime pago, double total, string nit, int idSucursal, DateTime ingreso)
        {
            comando = Variable_Conexion.CreateCommand();
            String pagoString = pago.Year.ToString() + "-" + pago.Month.ToString() + "-" + pago.Day.ToString();
            String ingresoString = ingreso.Year.ToString() + "-" + ingreso.Month.ToString() + "-" + ingreso.Day.ToString();
            comando.CommandText = "UPDATE  deuda SET Fecha_Pago='" + pagoString + "', Total=" + total.ToString() + ", Cliente_NIT='" + nit + "', Sucursal_ID=" + idSucursal.ToString() + ", Fecha_Ingreso='" + ingresoString + "' WHERE ID="+ID.ToString()+";";
            try
            {
                Variable_Conexion.Open();
                comando.ExecuteNonQuery();
                Variable_Conexion.Close();
            }
            catch (MySqlException e)
            {
                Variable_Conexion.Close();
                throw e;
            }
        }
        /// <summary>
        /// Modifica el teléfono de un encargado de un proveedor
        /// </summary>
        /// <param name="ID">ID del teléfono a modificar</param>
        /// <param name="idEncargado">Nuevo ID del encargado</param>
        /// <param name="telefono">Nuevo teléfono</param>
        public void modificacionTelefono(int ID, int idEncargado, String telefono)
        {
            comando = Variable_Conexion.CreateCommand();
            comando.CommandText = "UPDATE telefono SET Telefono='" + telefono + "' WHERE Id=+"+ID.ToString()+" AND Encargado_id=" + idEncargado + " AND Cliente_NIT IS NULL;";
            try
            {
                Variable_Conexion.Open();
                comando.ExecuteNonQuery();
                Variable_Conexion.Close();
            }
            catch (MySqlException e)
            {
                Variable_Conexion.Close();
                throw e;
            }
        }
        /// <summary>
        /// Modifica el teléfono de un cliente
        /// </summary>
        /// <param name="ID">ID del teléfono</param>
        /// <param name="nitDpiCliente">Nuevo NIT o DPI del cliente</param>
        /// <param name="telefono">Nuevo teléfono</param>
        public void modificacionTelefono(int ID, String nitDpiCliente, String telefono)
        {
            comando = Variable_Conexion.CreateCommand();
            comando.CommandText = "UPDATE telefono SET Telefono='" + telefono + "' WHERE Id=+" + ID.ToString() + " AND Cliente_NIT='" + nitDpiCliente + "' AND Encargado_id IS NULL;";
            try
            {
                Variable_Conexion.Open();
                comando.ExecuteNonQuery();
                Variable_Conexion.Close();
            }
            catch (MySqlException e)
            {
                Variable_Conexion.Close();
                throw e;
            }
        }
        /// <summary>
        /// Modifica todos los datos de un producto
        /// </summary>
        /// <param name="CodInterno">Código interno del producto a modificar</param>
        /// <param name="codFabricante">Nuevo código de fabricante</param>
        /// <param name="descripcion">Nueva descripción del producto</param>
        /// <param name="marca">Nueva marca del producto</param>
        /// <param name="fabricante">Nuevo fabricante del producto</param>
        /// <param name="departamento">Nuevo departamento al que pertence</param>
        /// <param name="precioCosto">Nuevo precio de costo</param>
        /// <param name="precioVenta">Nuevo precio de venta</param>
        public void modificacionProducto(String CodInterno, String codFabricante, String descripcion, String marca, String fabricante, String departamento, Double precioCosto, Double precioVenta)
        {
            comando = Variable_Conexion.CreateCommand();
            comando.CommandText = "UPDATE producto SET Codigo_Fabricante='" + codFabricante + "', Descripcion='" + descripcion + "', Marca='" + marca + "', Fabricante='" + fabricante + "', Departamento='" + departamento + "', Precio_Costo='" + precioCosto + "', Precio_Venta='"+ precioVenta + "' WHERE Codigo_Interno='"+ CodInterno + "';";
            try
            {
                Variable_Conexion.Open();
                comando.ExecuteNonQuery();
                Variable_Conexion.Close();
            }
            catch (MySqlException e)
            {
                Variable_Conexion.Close();
                throw e;
            }
        }
        //--------------------MODIFICACION RELACIONES--------------------//


        public void modificacionDetallePedido(String codInternoProducto, int numeroPedido, int cantidad, double precioCompra)
        {
            comando = Variable_Conexion.CreateCommand();
            comando.CommandText = "UPDATE detalle_pedido (Producto_Codigo_Interno, Pedido_Numero, Cantidad, Precio_Compra) VALUES ('" + codInternoProducto + "'," + numeroPedido.ToString() + "," + cantidad.ToString() + ","+precioCompra.ToString()+");";
            try
            {
                Variable_Conexion.Open();
                comando.ExecuteNonQuery();
                Variable_Conexion.Close();
            }
            catch (MySqlException e)
            {
                Variable_Conexion.Close();
                throw e;
            }
        }
        /// <summary>
        /// Modificación del inventario de un producto en cierta sucursal
        /// </summary>
        /// <param name="idSucursal">ID de la sucursal</param>
        /// <param name="codInternoProducto">Código interno del producto</param>
        /// <param name="existencia">Nueva existencia del producto en la sucursal</param>
        public void modificacionProductoSucursal(int idSucursal, String codInternoProducto, double existencia)
        {
            comando = Variable_Conexion.CreateCommand();
            comando.CommandText = "UPDATE prod_suc SET Existencia='" + existencia.ToString() + "' WHERE Sucursal_ID='" + idSucursal.ToString() + "' AND Producto_Codigo_Interno='" + codInternoProducto + "';";
            try
            {
                Variable_Conexion.Open();
                comando.ExecuteNonQuery();
                Variable_Conexion.Close();
            }
            catch (MySqlException e)
            {
                Variable_Conexion.Close();
                throw e;
            }
        }
        public void modificacionProveedorProducto(String codInternoProducto, int idProveedor, double precioProveedor)
        {
            comando = Variable_Conexion.CreateCommand();
            comando.CommandText = "UPDATE prov_prod (Producto_Codigo_Interno, Proveedor_ID, Precio_Proveedor) VALUES ('" + codInternoProducto + "'," + idProveedor.ToString() + "," + precioProveedor.ToString() + ");";
            try
            {
                Variable_Conexion.Open();
                comando.ExecuteNonQuery();
                Variable_Conexion.Close();
            }
            catch (MySqlException e)
            {
                Variable_Conexion.Close();
                throw e;
            }
        }

        
        //---------------ELIMINACIONES--------------//


        /// <summary>
        /// Elimina un usuario de la base
        /// </summary>
        /// <param name="nombre">Nombre del usuario al cual se le cambiará la contraseña</param>
        public void eliminacionUsuario(String nombre)
        {
            comando = Variable_Conexion.CreateCommand();
            comando.CommandText = "DELETE FROM usuario WHERE Nombre='"+nombre+"';";
            try
            {
                Variable_Conexion.Open();
                comando.ExecuteNonQuery();
                Variable_Conexion.Close();
            }
            catch (MySqlException e)
            {
                Variable_Conexion.Close();
                throw e;
            }
        }

        //---------------CONSULTAS---------------//


        public String[] obtener_sucursales()
        {
            String[] sucursales=null;
            int total;
            comando = Variable_Conexion.CreateCommand();//Inicializacion del comando 
            comando.CommandText = "SELECT COUNT(*) FROM sucursal;";//Consulta para la base, obtener el numero de sucursales
            try
            {
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
                    while (Variable_Lectura.Read())
                    {
                        sucursales[contador] = Variable_Lectura[0].ToString();
                        contador++;
                    }
                }
                Variable_Conexion.Close();//se cierra la conexion
                return sucursales;
            }
            catch (MySqlException e)
            {
                Variable_Conexion.Close();
                throw e;
            }
        }

        public String[,] obtener_sucursales(String diferencia)
        {
            String[,] sucursales = null;
            int total;
            comando = Variable_Conexion.CreateCommand();//Inicializacion del comando 
            comando.CommandText = "SELECT COUNT(*) FROM sucursal;";//Consulta para la base, obtener el numero de sucursales
            try
            {
                Variable_Conexion.Open();//se abre la conexion a la base
                Variable_Lectura = comando.ExecuteReader();//se guarda el conteo en la variable de lectura
                if (Variable_Lectura.Read())//se verifica si se obtiene algun dato de la base
                {
                    total = int.Parse(Variable_Lectura[0].ToString());//se convierte el objeto reader en una cadena y luego un entero
                    sucursales = new String[2, total];//se crea un arreglo de cadenas del tamaño del conteo obtenido de sucursales
                    comando.CommandText = "SELECT * FROM sucursal;";
                    Variable_Conexion.Close();//se cierra la conexion
                    Variable_Conexion.Open();
                    Variable_Lectura = comando.ExecuteReader();
                    int contador = 0;
                    while (Variable_Lectura.Read())
                    {
                        sucursales[0, contador] = Variable_Lectura["ID"].ToString();
                        sucursales[1, contador] = Variable_Lectura["Nombre"].ToString();
                        contador++;
                    }
                }
                Variable_Conexion.Close();//se cierra la conexion
                return sucursales;
            }
            catch (MySqlException e)
            {
                Variable_Conexion.Close();
                throw e;
            }
        }
        public int obtener_Nbodegas()
        {
            int total = 0;
            try
            {

                comando = Variable_Conexion.CreateCommand();//Inicializacion del comando 
                comando.CommandText = "SELECT COUNT(*) FROM sucursal;";//Consulta para la base, obtener el numero de sucursales

                Variable_Conexion.Open();//se abre la conexion a la base
                Variable_Lectura = comando.ExecuteReader();//se guarda el conteo en la variable de lectura
                if (Variable_Lectura.Read())//se verifica si se obtiene algun dato de la base
                {
                    total = int.Parse(Variable_Lectura[0].ToString());//se convierte el objeto reader en una cadena y luego un entero
                }
               
                Variable_Conexion.Close();
            }
            catch (MySqlException e)
            {
                Variable_Conexion.Close();
                throw e;
            }
            return total;
        }

        /// <summary>
        /// obtiene la informacion del codigo que estan en la base de datos.
        /// </summary>
        /// <param name="Codigo">Codigo que se busca</param>
        /// <returns>Un objeto de tipo Producto que contiene los datos de cada producto</returns>
        
        public Producto obtener_Producto(String Codigo)
        {
            Producto Producto = null;
            
            comando = Variable_Conexion.CreateCommand();//Inicializacion del comando 
            try
            {
                comando.CommandText = "SELECT * FROM producto WHERE Codigo_Interno='" + Codigo + "';";//Consulta que obtiene todos los datos de un codigo codigos  de la base 
                Variable_Conexion.Open();//se abre nuevamente la conexion con la base
                Variable_Lectura = comando.ExecuteReader();//se ejecuta el comando
                if (Variable_Lectura.Read())//Se verifica si se hizo una lectura
                {
                    Producto = new Producto(Variable_Lectura["Codigo_Interno"].ToString(), Variable_Lectura["Codigo_Fabricante"].ToString(), Variable_Lectura["Descripcion"].ToString(), Variable_Lectura["Marca"].ToString(),
                        Variable_Lectura["Fabricante"].ToString(), Variable_Lectura["Departamento"].ToString(), double.Parse(Variable_Lectura["Precio_Costo"].ToString()), double.Parse(Variable_Lectura["Precio_Venta"].ToString())); //se almacena cada codigo a la posicion del arreglo
                }

                Variable_Conexion.Close();//se cierra la conexion
            }
            catch (MySqlException e)
            {
                Variable_Conexion.Close();//se cierra la conexion
                throw e;
            }
            return Producto;//regresamos el arreglo
        }

        public TrabajadoresClass obtener_Trabajador(String Nombre)
        {
            TrabajadoresClass Trabajador = null;

            comando = Variable_Conexion.CreateCommand();//Inicializacion del comando 
            try
            {
                comando.CommandText = "SELECT * FROM trabajador WHERE Nombre='" + Nombre + "';";  //Consulta que obtiene todos los datos de un codigo codigos  de la base 
                Variable_Conexion.Open();                                                     //se abre nuevamente la conexion con la base
                Variable_Lectura = comando.ExecuteReader();                                   //se ejecuta el comando
                if (Variable_Lectura.Read())                                                  //Se verifica si se hizo una lectura
                {
                    Trabajador = new TrabajadoresClass(Variable_Lectura["Nombre"].ToString(),double.Parse( Variable_Lectura["Salario"].ToString()),int.Parse(Variable_Lectura["Sucursal_ID"].ToString())); //se almacena cada codigo a la posicion del arreglo
                }

                Variable_Conexion.Close();//se cierra la conexion
            }
            catch (MySqlException e)
            {
                Variable_Conexion.Close();//se cierra la conexion
                throw e;
            }
            return Trabajador;//regresamos el arreglo
        }
        /// <summary>
        /// Obtiene los codigos que estan en la base de datos
        /// </summary>
        /// <returns>Arreglo con todos los codigos que estan en la base de datos</returns>
        
        public String[] obtener_codigos()
        {
            String[] Codigo = null;
            int total;
            comando = Variable_Conexion.CreateCommand();//Inicializacion del comando 
            comando.CommandText = "SELECT COUNT(*) FROM producto;";//Consulta para la base, obtener el numero de productos
            try
            {
                Variable_Conexion.Open();//se abre la conexion a la base
                Variable_Lectura = comando.ExecuteReader();//se guarda el conteo en la variable de lectura
                if (Variable_Lectura.Read())//se verifica si se obtiene algun dato de la base
                {
                    total = int.Parse(Variable_Lectura[0].ToString());//se convierte el objeto reader en una cadena y luego un entero
                    Codigo = new String[total];//se crea un arreglo de cadenas del tamaño del conteo de codigos 
                    comando.CommandText = "SELECT Codigo_Interno FROM producto;";//Consulta que obtiene todos los codigos en la base 
                    Variable_Conexion.Close();//se cierra la conexion
                    Variable_Conexion.Open();//se abre nuevamente la conexion con la base
                    Variable_Lectura = comando.ExecuteReader();//se ejecuta el comando
                    int contador = 0;//control de posicion en el arreglo
                    while (Variable_Lectura.Read())//ciclo tipo loop que se ejecuta mientras existan datos en la consulra
                    {
                        Codigo[contador] = Variable_Lectura[0].ToString(); //se almacena cada codigo a la posicion del arreglo
                        contador++;//se aumenta el contador
                    }
                }
                Variable_Conexion.Close();//se cierra la conexion
            }
            catch (MySqlException e)
            {
                Variable_Conexion.Close();//se cierra la conexion
                throw e;
            }
            return Codigo;//regresamos el arreglo
        }

        /// <summary>
        /// Obtiene los probedores que existen en la base de datos
        /// </summary>
        /// <returns>Arreglo con los proveedores</returns>
        
        public String[] obtener_proveedores()
        {
            String[] proveedores = null;
            int total;
            comando = Variable_Conexion.CreateCommand();//Inicializacion del comando 
            comando.CommandText = "SELECT COUNT(*) FROM proveedor;";//Consulta para la base, obtener la cantidad de proveedores
            try
            {
                Variable_Conexion.Open();//se abre la conexion a la base
                Variable_Lectura = comando.ExecuteReader();//se guarda el conteo en la variable de lectura
                if (Variable_Lectura.Read())//se verifica si se obtiene algun dato de la base
                {
                    total = int.Parse(Variable_Lectura[0].ToString());//se convierte el objeto reader en una cadena y luego un entero
                    proveedores = new String[total];//se crea un arreglo de cadenas del tamñano de proveedores en la base 
                    comando.CommandText = "SELECT Nombre FROM proveedor order by Nombre ASC;";//Consulta que obtiene todos los proveedores en la base 
                    Variable_Conexion.Close();//se cierra la conexion
                    Variable_Conexion.Open();//se abre nuevamente la conexion con la base
                    Variable_Lectura = comando.ExecuteReader();//se ejecuta el comando
                    int contador = 0;//control de posicion en el arreglo
                    while (Variable_Lectura.Read())//ciclo tipo loop que se ejecuta mientras existan datos en la consulra
                    {
                        proveedores[contador] = Variable_Lectura[0].ToString(); //se almacena cada prveedor a la posicion del arreglo
                        contador++;//se aumenta el contador
                    }
                }
                Variable_Conexion.Close();//se cierra la conexion
            }
            catch (MySqlException e)
            {
                Variable_Conexion.Close();//se cierra la conexion
                throw e;
            }
            return proveedores;//regresamos el arreglo
        }

        public int obtener_Existencias(String codigo)
        {
            int existencias = 0;

            try
            {
                comando.CommandText = "SELECT Existencia FROM prod_suc WHERE Producto_Codigo_Interno ='" + codigo + "';";//Consulta que obtiene todos los codigos en la base 
                Variable_Conexion.Open();//se abre nuevamente la conexion con la base
                Variable_Lectura = comando.ExecuteReader();//se ejecuta el comando
                while (Variable_Lectura.Read())//ciclo tipo loop que se ejecuta mientras existan datos en la consulra
                {
                    existencias += int.Parse(Variable_Lectura[0].ToString());
                }
                Variable_Conexion.Close();//se cierra la conexion
            }
            catch (MySqlException e)
            {
                
                throw e;
            }

            return existencias;
        }

        public String[] obtener_Trabajadores()
        {
            String[] trabajadores = null;
            int total;
            comando = Variable_Conexion.CreateCommand();                   //Inicializacion del comando 
            comando.CommandText = "SELECT COUNT(*) FROM trabajador;";    //Consulta para la base, obtener la cantidad de proveedores
            try
            {
                Variable_Conexion.Open();                          //se abre la conexion a la base
                Variable_Lectura = comando.ExecuteReader();        //se guarda el conteo en la variable de lectura
                if (Variable_Lectura.Read())                       //se verifica si se obtiene algun dato de la base
                {
                    total = int.Parse(Variable_Lectura[0].ToString());                              //se convierte el objeto reader en una cadena y luego un entero
                    trabajadores = new String[total];                                               //se crea un arreglo de cadenas del tamñano de proveedores en la base 
                    comando.CommandText = "SELECT Nombre FROM trabajador ORDER BY Nombre ASC;";   //Consulta que obtiene todos los proveedores en la base 
                    Variable_Conexion.Close();                                                      //se cierra la conexion
                    Variable_Conexion.Open();                                                       //se abre nuevamente la conexion con la base
                    Variable_Lectura = comando.ExecuteReader();                                     //se ejecuta el comando
                    int contador = 0;                                                               //control de posicion en el arreglo
                    while (Variable_Lectura.Read())                                                 //ciclo tipo loop que se ejecuta mientras existan datos en la consulta
                    {
                        trabajadores[contador] = Variable_Lectura[0].ToString();                    //se almacena cada prveedor a la posicion del arreglo
                        contador++;                                                                 //se aumenta el contador
                    }
                }
                Variable_Conexion.Close();                                                          //se cierra la conexion
            }
            catch (MySqlException e)
            {
                Variable_Conexion.Close();//se cierra la conexion
                throw e;
            }
         
            return trabajadores;
        }
        /// <summary>
        /// Obtiene el nombre de todos los usuarios en la BD
        /// </summary>
        /// <returns>Arreglo de Strings con los nombres de los usuarios</returns>
        public String[] obtenerUsuarios()
        {
            String[] usuarios = null;
            int total;
            comando = Variable_Conexion.CreateCommand();//Inicializacion del comando 
            comando.CommandText = "SELECT COUNT(*) FROM usuario;";//Consulta para la base, obtener el numero de usuarios
            try
            {
                Variable_Conexion.Open();//se abre la conexion a la base
                Variable_Lectura = comando.ExecuteReader();//se guarda el conteo en la variable de lectura
                if (Variable_Lectura.Read())//se verifica si se obtiene algun dato de la base
                {
                    total = int.Parse(Variable_Lectura[0].ToString());//se convierte el objeto reader en una cadena y luego un entero
                    usuarios = new String[total];//se crea un arreglo de cadenas del tamaño del conteo obtenido de usuarios
                    comando.CommandText = "SELECT Nombre FROM usuario ORDER BY Nombre ASC;";
                    Variable_Conexion.Close();//se cierra la conexion
                    Variable_Conexion.Open();
                    Variable_Lectura = comando.ExecuteReader();
                    int contador = 0;
                    while (Variable_Lectura.Read())
                    {
                        usuarios[contador] = Variable_Lectura[0].ToString();
                        contador++;
                    }
                }
                Variable_Conexion.Close();//se cierra la conexion
                return usuarios;
            }
            catch (MySqlException e)
            {
                Variable_Conexion.Close();
                throw e;
            }
        }

        //---------------OTROS---------------//

        /// <summary>
        /// Metodo que verifica si existe un codigo en la base de datos
        /// </summary>
        /// <param name="Codigo">Codigo que se busca</param>
        /// <returns>Un booleano que indica si existe o no un codigo en la base de datos</returns>
        public Boolean existe_Codigo(String Codigo_Interno)
        {
            Boolean Existe = false;
            try
            {
               
                int contador = 0;

                comando = Variable_Conexion.CreateCommand();//Inicializacion del comando 
                comando.CommandText = "SELECT COUNT(*) FROM producto WHERE Codigo_Interno='" + Codigo_Interno + "';";//Consulta para la base, obtener el numero de sucursales
                Variable_Conexion.Open();//se abre la conexion a la base
                Variable_Lectura = comando.ExecuteReader();//se guarda el conteo en la variable de lectura
                if (Variable_Lectura.Read())//se verifica si se obtiene algun dato de la base
                {
                    contador = int.Parse(Variable_Lectura[0].ToString());// se almacena la cantidad qeu se obtine de la base
                }
                Variable_Conexion.Close();//cerramos la conexion con la base

                if (contador != 0)//conparamos si el numero obtenido es diferente de 0 cambiamos el valor por que el codigo ya existe en la base
                {
                    Existe = true;
                }
       
            }
            catch (MySqlException e)
            {
                Variable_Conexion.Close();
                throw e;
            }
            return Existe;//regresamos el valor booleano de la consulta
        }

        public Boolean existe_exsitencias(String Codigo_Interno, int sucursal)
        {
            Boolean Existe = false;
            try
            {

                int contador = 0;

                comando = Variable_Conexion.CreateCommand();//Inicializacion del comando 
                comando.CommandText = "SELECT COUNT(*) FROM prod_suc WHERE Producto_Codigo_Interno='" + Codigo_Interno + "' AND Sucursal_ID='"+ sucursal.ToString() + "';";//Consulta para la base, obtener el numero de sucursales
                Variable_Conexion.Open();//se abre la conexion a la base
                Variable_Lectura = comando.ExecuteReader();//se guarda el conteo en la variable de lectura
                if (Variable_Lectura.Read())//se verifica si se obtiene algun dato de la base
                {
                    contador = int.Parse(Variable_Lectura[0].ToString());// se almacena la cantidad qeu se obtine de la base
                }
                Variable_Conexion.Close();//cerramos la conexion con la base

                if (contador != 0)//conparamos si el numero obtenido es diferente de 0 cambiamos el valor por que el codigo ya existe en la base
                {
                    Existe = true;
                }

            }
            catch (MySqlException e)
            {
                Variable_Conexion.Close();
                throw e;
            }
            return Existe;//regresamos el valor booleano de la consulta
        }

        public Boolean existe_bodega(String Nombre)
        {
            Boolean Existe = false;
            try
            {

                int contador = 0;

                comando = Variable_Conexion.CreateCommand();//Inicializacion del comando 
                comando.CommandText = "SELECT COUNT(*) FROM sucursal WHERE Nombre='" + Nombre + "';";//Consulta para la base, obtener el numero de sucursales
                Variable_Conexion.Open();//se abre la conexion a la base
                Variable_Lectura = comando.ExecuteReader();//se guarda el conteo en la variable de lectura
                if (Variable_Lectura.Read())//se verifica si se obtiene algun dato de la base
                {
                    contador = int.Parse(Variable_Lectura[0].ToString());// se almacena la cantidad qeu se obtine de la base
                }
                Variable_Conexion.Close();//cerramos la conexion con la base

                if (contador != 0)//conparamos si el numero obtenido es diferente de 0 cambiamos el valor por que el codigo ya existe en la base
                {
                    Existe = true;
                }


            }
            catch (MySqlException e)
            {
                Variable_Conexion.Close();
                throw e;
            }
            return Existe;//regresamos el valor booleano de la consulta
        }
        public String[,] obtener_clientes()
        {
            String[,] clientes = null;
            int total;
            comando = Variable_Conexion.CreateCommand();//Inicializacion del comando 
            comando.CommandText = "SELECT COUNT(*) FROM cliente;";//Consulta para la base, obtener el numero de clientes
            Variable_Conexion.Open();//se abre la conexion a la base
            Variable_Lectura = comando.ExecuteReader();//se guarda el conteo en la variable de lectura
            if (Variable_Lectura.Read())//se verifica si se obtiene algun dato de la base
            {
                total = int.Parse(Variable_Lectura[0].ToString());//se convierte el objeto reader en una cadena y luego un entero
                clientes = new String[total,3];//se crea un arreglo de cadenas del tamaño del conteo obtenido de clientes
                comando.CommandText = "SELECT Nombre,Apellido,NIT_DPI FROM cliente;";
                Variable_Conexion.Close();//se cierra la conexion
                Variable_Conexion.Open();
                Variable_Lectura = comando.ExecuteReader();
                int contador = 0;
                while (Variable_Lectura.Read())
                {
                    clientes[contador,0] = Variable_Lectura["Nombre"].ToString();
                    clientes[contador,1] = Variable_Lectura["Apellido"].ToString();
                    clientes[contador,2] = Variable_Lectura["NIT_DPI"].ToString();
                    contador++;
                }
            }
            Variable_Conexion.Close();//se cierra la conexion
            return clientes;
        }
        public Cliente datos_cliente()
        {
            Cliente cliente=null;
            
            return cliente;
        }

    }
    
}
