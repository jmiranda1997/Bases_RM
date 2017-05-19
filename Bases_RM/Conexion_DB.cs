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

            Constructor_Conexion.Server = "localhost";//"25.3.39.210";//Direccion IP del servidor
            Constructor_Conexion.UserID = "root";//Ususario de la base de datos
            Constructor_Conexion.Password = "blackdiamond";//Contraseña para la base de datos 
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
        /// Metodo que verifica si la contraseña es válida para iniciar sesión
        /// </summary>
        /// <param name="usuario">El usuario del cual se obtendrá la contraseña</param>
        /// <param name="password">La contraseña ingresada para intentar iniciar sesión</param>
        /// <returns></returns>
        public bool login(String usuario, String password)
        {
            try
            {
                int valido = 0;
                comando = Variable_Conexion.CreateCommand();           //Inicializacion del comando 
                comando.CommandText = "SELECT LOGIN('"+usuario+"','"+password+"') \"R\";";   //Consulta para la base
                Variable_Conexion.Open();                              //se abre la conexion a la base
                Variable_Lectura = comando.ExecuteReader();            //se guarda la contraseña en la variable de lectura
                if (Variable_Lectura.Read() == true)                   //se verifica si se obtiene algun dato de la base
                {
                    valido = int.Parse(Variable_Lectura["R"].ToString());
                }

                Variable_Conexion.Close();                                                               //se cierra la conexion
                return valido==1;                                    //regresa la contraseña obtenida de la base
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
            }

            
            Variable_Conexion.Close();//se cierra la conexion
            temp = new Usuario(Nombre);
            return temp;
        }

      
        //---------------INGRESOS--------------//

        /// <summary>
        /// Ingresa los datos del encargado a la BD
        /// </summary>
        /// <param name="nombre">Nombre del encargado</param>
        /// <param name="correo">Correo del encargado</param>
        /// <param name="idProveedor">ID del proveedor al cual pertenece el encargado</param>
        public void ingresoEncargado(String nombre, String correo){
            comando = Variable_Conexion.CreateCommand();
            comando.CommandText = "INSERT INTO encargado (Nombre, Correo) VALUES ('"+nombre+"','"+correo+"');";
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
            comando.CommandText = "INSERT INTO proveedor (Nombre, Pais_id) VALUES ('" + nombre + "'," + idPais.ToString() + ");";
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

        public void ingresoEncargProv(int Encargado_id, int Proveedor_id)
        {
            comando = Variable_Conexion.CreateCommand();
            comando.CommandText = "INSERT INTO encargadosproveedor (Encargado_id, Proveedor_id) VALUES (" + Encargado_id.ToString() + ", " + Proveedor_id.ToString() + ");";
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
        public void ingresoTrabajador(String nombre, double salario, int idSucursal,int codigo){
            String habi = "SI";
            comando = Variable_Conexion.CreateCommand();
            comando.CommandText = "INSERT INTO trabajador (Codigo,Nombre, Salario, Sucursal_ID) VALUES (" + codigo.ToString() + ",'" + nombre + "'," + salario.ToString() + "," + idSucursal.ToString() + ");";
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
        /// <param name="idCliente">ID de la deuda a la cual se esta pagando</param>
        /// <param name="fechaIngreso">Fecha de ingreso del pago al sistema</param>
        public void ingresoPagoDeuda(DateTime fecha, double monto, int idCliente, int idSucursal)
        {
            comando = Variable_Conexion.CreateCommand();
            String fechaString = fecha.Year.ToString() + "-" + fecha.Month.ToString() + "-" + fecha.Day.ToString();
            comando.CommandText = "INSERT INTO pagos (Fecha, Monto, Cliente_id, Sucursal_id) VALUES ('" + fechaString + "'," + monto.ToString() + "," + idCliente.ToString() +","+idSucursal.ToString()+");";
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
            comando.CommandText = "INSERT INTO usuario (Nombre, Clave, Acceso_Pedidos, Acceso_Clientes, Acceso_Trabajadores, Acceso_Seguridad) VALUES ('" + nombre + "',AES_ENCRYPT('" + clave + "','" + clave + "'),'" + pedidos + "','" + clientes + "','" + trabajadores + "','" + seguridad + "');";
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
        /// Método que ingresa los usuarios
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="clave"></param>
        public void ingresoUsuario(String nombre, String clave)
        {
            comando = Variable_Conexion.CreateCommand();
            comando.CommandText = "INSERT INTO usuario (Nombre, Clave) VALUES ('" + nombre + "',AES_ENCRYPT('" + clave + "','" + clave + "'));";
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
        public void ingresoCliente(String NitDpi, String nombre, String apellido, int diasCredito, Double limiteCredito)
        {
            comando = Variable_Conexion.CreateCommand();
            comando.CommandText = "INSERT INTO cliente (NIT_DPI, Nombre, Apellido, Dias_Credito, Limite_Credito) VALUES ('" + NitDpi + "','" + nombre + "','"+apellido+"'," + diasCredito.ToString() + "," + limiteCredito.ToString() + ");";
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
        public void ingresoPedido()
        {
            comando = Variable_Conexion.CreateCommand();
            comando.CommandText = "INSERT INTO pedido (Total) VALUES ('" + 0 + "');";
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
        public void ingresoDeuda(String pago, double total, int id, int idSucursal)
        {
            comando = Variable_Conexion.CreateCommand();
            String[] pagoString = pago.Split("/".ToCharArray());
            pago = pagoString[2] + "/" + pagoString[1] + "/" + pagoString[0];
            comando.CommandText = "INSERT INTO  deuda (Fecha_Pago, Total, Cliente_id, Sucursal_id) VALUES ('" + pago + "'," + total+ "," + id + "," + idSucursal+");";
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
        public void ingresoProducto(String codInterno, String codFabricante, String descripcion, String marca, String fabricante, String departamento, Double precioCosto, Double precioVenta, Double Existencia)
        {
            comando = Variable_Conexion.CreateCommand();
            comando.CommandText = "INSERT INTO producto (Codigo_Interno, Codigo_Fabricante, Descripcion, Marca, Fabricante, Departamento, Precio_Costo, Precio_Venta, Existencia) VALUES ('" + codInterno + "','" + codFabricante + "','" + descripcion + "','" + marca + "','" + fabricante + "','" + departamento + "'," + precioCosto.ToString() + "," + precioVenta.ToString() + "," + Existencia.ToString() + ");";
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
        public void ingresoTelefonoProv(String telefono, int Provedor_id)
        {
            comando = Variable_Conexion.CreateCommand();
            comando.CommandText = "INSERT INTO telefono (Telefono, Encargado_id) VALUES ('" + telefono + "'," + Provedor_id.ToString() + ");";
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
        public void ingresoDetallePedido(int Cantidad, Double Precio, int Producto_id, int Pedido_id, String Comentario)
        {
            comando = Variable_Conexion.CreateCommand();
            comando.CommandText = "INSERT INTO detalle_pedido (Cantidad, Precio_Compra, Producto_id, Pedido_id, Comentario) VALUES ("+ Cantidad.ToString() +", "+ Precio.ToString()+ ", "+ Producto_id.ToString()+", "+ Pedido_id.ToString()+", '"+ Comentario +"');";
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
        public void ingresoProveedorProducto (String codInternoProducto, int idProveedor, Double precioProveedor)
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
        public void modificacionTrabajador(int ID, String nombre, double salario, int idSucursal, int codigo)
        {
            String habi = "Si";
            comando = Variable_Conexion.CreateCommand();
            comando.CommandText = "UPDATE trabajador SET Nombre='" + nombre +"', Habilitado='" +  habi + "', Salario=" + salario + ", Codigo=" + codigo +", Sucursal_ID=" + idSucursal.ToString() + " WHERE ID=" + ID.ToString() + ";";
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
            comando.CommandText = "UPDATE usuario SET Clave=AES_ENCRYPT('" + clave + "','" + clave + "'), Acceso_Pedidos='" + pedidos + "', Acceso_Clientes='" + clientes + "', Acceso_Trabajadores='" + trabajadores + "', Acceso_Seguridad='" + seguridad + "' WHERE nombre='" + nombre + "';";
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
            comando.CommandText = "UPDATE usuario SET Clave=AES_ENCRYPT('" + clave + "','" + clave + "') WHERE nombre='" + nombre + "';";
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
        /// <param name="id">Nuevo ID de la clasificación del cliente</param>
        public void modificacionCliente(String nombre, String apellido, int diasCredito, double limiteCredito, int id)
        {
            comando = Variable_Conexion.CreateCommand();
            comando.CommandText = "UPDATE cliente SET Nombre='" + nombre + "', Apellido='"+apellido+"', Dias_Credito=" + diasCredito.ToString() + ", Limite_Credito=" + limiteCredito.ToString() + " WHERE id= "+id+";";
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
        public int obtener_idDeuda(int mes, int anio, int clienteId, int sucursalId)
        {
            int id=0;
            try
            {
                comando.CommandText = "SELECT id FROM deuda WHERE Cliente_id="+clienteId+" AND Sucursal_id="+sucursalId+" AND MONTH(Fecha_pago)="+mes+" AND YEAR(Fecha_pago)="+anio+";";//Consulta que obtiene todos los codigos en la base 
                Variable_Conexion.Open();//se abre nuevamente la conexion con la base
                Variable_Lectura = comando.ExecuteReader();//se ejecuta el comando
                if (Variable_Lectura.Read())//ciclo tipo loop que se ejecuta mientras existan datos en la consulra
                {
                    id = int.Parse(Variable_Lectura[0].ToString());
                }
                Variable_Conexion.Close();//se cierra la conexion
                return id;
            }
            catch (MySqlException e)
            {

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
        public void modificacionDeuda(int idDeuda, DateTime pago, double total)
        {
            comando = Variable_Conexion.CreateCommand();
            String pagoString = pago.Year.ToString() + "-" + pago.Month.ToString() + "-" + pago.Day.ToString();
                       comando.CommandText = "UPDATE  deuda SET Fecha_Pago='" + pagoString + "', Total=" + total.ToString() + " WHERE id="+idDeuda.ToString()+";";
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
        public void modificacionProducto(String CodInterno, String codFabricante, String descripcion, String marca, String fabricante, String departamento, Double precioCosto, Double precioVenta, Double exi)
        {
            comando = Variable_Conexion.CreateCommand();
            comando.CommandText = "UPDATE producto SET Codigo_Fabricante='" + codFabricante + "', Descripcion='" + descripcion + "', Marca='" + marca + "', Fabricante='" + fabricante + "', Departamento='" + departamento + "', Precio_Costo='" + precioCosto.ToString() + "', Precio_Venta='" + precioVenta.ToString() + "', Existencia='" + exi.ToString() + "' WHERE Codigo_Interno='" + CodInterno + "';";
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


        public void modificacionDetallePedido(int Producto_id, int Pedido_id, int cantidad, double Precio_Compra, String Comentario)
        {
            comando = Variable_Conexion.CreateCommand();
            comando.CommandText = "UPDATE detalle_pedido SET Cantidad =" + cantidad.ToString() + ", Precio_Compra=" + Precio_Compra.ToString() + ", Comentario = '" + Comentario + "' WHERE Producto_id =" + Producto_id.ToString() + " AND Pedido_id =" + Pedido_id.ToString() + ";";
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

        public bool existeDetalle(int Producto_id, int Pedido_id)
        {
            bool existe= false;
            comando = Variable_Conexion.CreateCommand();
            comando.CommandText = "SELECT COUNT(*) FROM detalle_pedido WHERE Producto_id =" + Producto_id.ToString() + " AND Pedido_id =" + Pedido_id.ToString() + ";";
            try
            {
                Variable_Conexion.Open();
                Variable_Lectura = comando.ExecuteReader();
                if (Variable_Lectura.Read())
                {
                    int cantidad = Int32.Parse(Variable_Lectura[0].ToString());
                    if (cantidad > 0)
                    {
                        existe = true;
                    }
                }

                Variable_Conexion.Close();
                return existe;
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
        public void eliminacionTrabajadores(String nombre)
        {
            comando = Variable_Conexion.CreateCommand();
            comando.CommandText = "UPDATE trabajador SET Habilitado='NO', Codigo = -1 WHERE Nombre='" + nombre + "';"; 

            try
            {
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
        public String[] obtenerNombre (int nuevo)
        {
           String[]meronom=null;
           int total;
           comando = Variable_Conexion.CreateCommand();
           comando.CommandText = "SELECT COUNT(*) FROM sucursal;";

             try
             {
                 Variable_Conexion.Open();//se abre la conexion a la base
                 Variable_Lectura = comando.ExecuteReader();//se guarda el conteo en la variable de lectura
                 if (Variable_Lectura.Read())//se verifica si se obtiene algun dato de la base
                 {
                     total = int.Parse(Variable_Lectura[0].ToString());//se convierte el objeto reader en una cadena y luego un entero
                     meronom = new String[total];//se crea un arreglo de cadenas del tamaño del conteo obtenido de sucursales
                     comando.CommandText = "Select Nombre from sucursal where id ='" + nuevo + "';";
                     Variable_Conexion.Close();//se cierra la conexion
                     Variable_Conexion.Open();
                     Variable_Lectura = comando.ExecuteReader();
                     int contador = 0;
                     while (Variable_Lectura.Read())
                     {
                         meronom[contador] = Variable_Lectura[0].ToString();
                         contador++;
                     }
                }
                 Variable_Conexion.Close();//se cierra la conexion
                 return meronom;
             }
             catch (MySqlException e)
             {
                 Variable_Conexion.Close();
                 throw e;
             }
        
        
        }


        public String obtener_Nombredemens(int nuevo)
        {
             int total = 0;
             String men = "";
            try
            {

                comando = Variable_Conexion.CreateCommand();//Inicializacion del comando 
                comando.CommandText = "SELECT Nombre FROM sucursal WHERE id ='" + nuevo + "';";//Consulta para la base, obtener el numero de sucursales

                Variable_Conexion.Open();//se abre la conexion a la base
                Variable_Lectura = comando.ExecuteReader();//se guarda el conteo en la variable de lectura
                while (Variable_Lectura.Read())//se verifica si se obtiene algun dato de la base
                {
                    men = Variable_Lectura[0].ToString();//se convierte el objeto reader en una cadena y luego un entero
                }
              //  men = total.ToString();
                Variable_Conexion.Close();
            }
            catch (MySqlException e)
            {
                Variable_Conexion.Close();
                throw e;
            }
            return men;
        }
        //---------------CONSULTAS---------------//



        public String[,] obtenerPermisos(String usuario)
        {
            try
            {
                String clave = "";
                int ascii = usuario.ElementAt(0);
                clave += ascii.ToString();
                for (int i = 0; i < usuario.Length; i++)
                {
                    clave += usuario.ElementAt(usuario.Length - 1 - i);
                }
                ascii = usuario.ElementAt(usuario.Length - 1);
                clave += ascii.ToString();
                String[,] permisos = null;
                permisos = new String[1, 4];//se crea un arreglo de cadenas del tamaño del conteo obtenido de clientes
                for (int i = 0; i < 4; i++)
                {
                    comando = Variable_Conexion.CreateCommand();//Inicializacion del comando 
                    int temp = i + 1;
                    comando.CommandText = "SELECT descifraAccesos("+temp+",'"+clave+"','"+usuario+"') \"R\";";
                Variable_Conexion.Open();
                Variable_Lectura = comando.ExecuteReader();
                while (Variable_Lectura.Read())
                {
                        if (i == 0)
                            permisos[0, 0] = Variable_Lectura["R"].ToString();
                        else if(i==1)
                            permisos[0, 1] = Variable_Lectura["R"].ToString();
                        else if (i == 2)
                            permisos[0, 2] = Variable_Lectura["R"].ToString();
                        else if (i == 3)
                            permisos[0, 3] = Variable_Lectura["R"].ToString();                        
                }
                Variable_Conexion.Close();//se cierra la conexion
                }
                return permisos;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
        }

        public String[,] obtener_sucursales()
        {
            String[,] sucursales=null;
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
                    sucursales = new String[total,2];//se crea un arreglo de cadenas del tamaño del conteo obtenido de sucursales
                    comando.CommandText = "SELECT Nombre,id FROM sucursal;";
                    Variable_Conexion.Close();//se cierra la conexion
                    Variable_Conexion.Open();
                    Variable_Lectura = comando.ExecuteReader();
                    int contador = 0;
                    while (Variable_Lectura.Read())
                    {
                        sucursales[contador,0] = Variable_Lectura[0].ToString();
                        sucursales[contador,1] = Variable_Lectura[1].ToString();
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
                    Producto = new Producto(Int32.Parse(Variable_Lectura["id"].ToString()),Variable_Lectura["Codigo_Interno"].ToString(), Variable_Lectura["Codigo_Fabricante"].ToString(), Variable_Lectura["Descripcion"].ToString(), Variable_Lectura["Marca"].ToString(),
                        Variable_Lectura["Fabricante"].ToString(), Variable_Lectura["Departamento"].ToString(), double.Parse(Variable_Lectura["Precio_Costo"].ToString()), double.Parse(Variable_Lectura["Precio_Venta"].ToString()), Int32.Parse(Variable_Lectura["Existencia"].ToString())); //se almacena cada codigo a la posicion del arreglo
                }
                Variable_Conexion.Close();
               //se cierra la conexion
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
                    Trabajador = new TrabajadoresClass(Variable_Lectura["Nombre"].ToString(), double.Parse(Variable_Lectura["Salario"].ToString()), int.Parse(Variable_Lectura["Sucursal_ID"].ToString()), int.Parse(Variable_Lectura["Codigo"].ToString()), Variable_Lectura["Habilitado"].ToString()); //se almacena cada codigo a la posicion del arreglo
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
        public TrabajadoresClass obtener_Trabajadordesha()
        {
            TrabajadoresClass Trabajador = null;

            comando = Variable_Conexion.CreateCommand();//Inicializacion del comando 
            try
            {
                comando.CommandText = "SELECT Nombre from trabajador WHERE Codigo='-1';";  //Consulta que obtiene todos los datos de un codigo codigos  de la base 
                Variable_Conexion.Open();                                                     //se abre nuevamente la conexion con la base
                Variable_Lectura = comando.ExecuteReader();                                   //se ejecuta el comando
                if (Variable_Lectura.Read())                                                  //Se verifica si se hizo una lectura
                {
                    Trabajador = new TrabajadoresClass(Variable_Lectura["Nombre"].ToString(), double.Parse(Variable_Lectura["Salario"].ToString()), int.Parse(Variable_Lectura["Sucursal_ID"].ToString()), int.Parse(Variable_Lectura["Codigo"].ToString()), Variable_Lectura["Habilitado"].ToString()); //se almacena cada codigo a la posicion del arreglo
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
                    comando.CommandText = "SELECT Codigo_Interno FROM producto ORDER BY Codigo_Interno ASC;";//Consulta que obtiene todos los codigos en la base 
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
                comando.CommandText = "SELECT Existencia FROM producto WHERE Codigo_Interno ='" + codigo + "';";//Consulta que obtiene todos los codigos en la base 
                Variable_Conexion.Open();//se abre nuevamente la conexion con la base
                Variable_Lectura = comando.ExecuteReader();//se ejecuta el comando
                if (Variable_Lectura.Read())//ciclo tipo loop que se ejecuta mientras existan datos en la consulra
                {
                    existencias = int.Parse(Variable_Lectura[0].ToString());
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
        public String[,] obtenerPedidos()
        {
            String[,] pedidos = null;
            int total;
            comando = Variable_Conexion.CreateCommand();//Inicializacion del comando 
            comando.CommandText = "SELECT COUNT(*) FROM pedido;";//Consulta para la base, obtener el numero de sucursales
            try
            {
                Variable_Conexion.Open();//se abre la conexion a la base
                Variable_Lectura = comando.ExecuteReader();//se guarda el conteo en la variable de lectura
                if (Variable_Lectura.Read())//se verifica si se obtiene algun dato de la base
                {
                    total = int.Parse(Variable_Lectura[0].ToString());//se convierte el objeto reader en una cadena y luego un entero
                    pedidos = new String[2, total];//se crea un arreglo de cadenas del tamaño del conteo obtenido de sucursales
                    comando.CommandText = "SELECT id, Mes FROM pedido ORDER BY Mes DESC;";
                    Variable_Conexion.Close();//se cierra la conexion
                    Variable_Conexion.Open();
                    Variable_Lectura = comando.ExecuteReader();
                    int contador = 0;
                    while (Variable_Lectura.Read())
                    {
                        pedidos[0, contador] = Variable_Lectura[0].ToString();
                        pedidos[1, contador] = Variable_Lectura[1].ToString();
                        contador++;
                    }
                }
                Variable_Conexion.Close();//se cierra la conexion
                return pedidos;
            }
            catch (MySqlException e)
            {
                Variable_Conexion.Close();
                throw e;
            }
        }

        public String obtenerNombrePedido()
        {
            String Nombre = null;
            comando = Variable_Conexion.CreateCommand();//Inicializacion del comando 
            comando.CommandText = "SELECT Mes FROM pedido ORDER BY Mes DESC LIMIT 1;";//Consulta para la base, obtener el numero de productos
            try
            {
                Variable_Conexion.Open();//se abre la conexion a la base
                Variable_Lectura = comando.ExecuteReader();//se guarda el conteo en la variable de lectura
                if (Variable_Lectura.Read())//se verifica si se obtiene algun dato de la base
                {
                    Nombre = Variable_Lectura[0].ToString();//se convierte el objeto reader en una cadena y luego un entero
                    Variable_Conexion.Close();//se cierra la conexion
                } 
            }
            catch (MySqlException e)
            {
                Variable_Conexion.Close();//se cierra la conexion
                throw e;
            }
            return Nombre;//regresamos el arreglo
        }

        public ClasePedido obtenerPedido(String Nombre)
        {
            ClasePedido pedido = null;

            comando = Variable_Conexion.CreateCommand();//Inicializacion del comando 
            comando.CommandText = "SELECT * FROM pedido WHERE Mes ='" + Nombre + "';";
            try
            {
                Variable_Conexion.Open();//se abre la conexion a la base
                Variable_Lectura = comando.ExecuteReader();//se guarda el conteo en la variable de lectura
                if (Variable_Lectura.Read())//se verifica si se obtiene algun dato de la base
                {
                    bool fin = true;
                    if (Variable_Lectura["Finalizado"].ToString().Trim().Equals("no"))
                    {
                        fin = false;
                    }
                    pedido = new ClasePedido(Int32.Parse(Variable_Lectura["id"].ToString()), fin, Double.Parse(Variable_Lectura["Total"].ToString()), Variable_Lectura["Mes"].ToString());
                }
                Variable_Conexion.Close();
            }
            catch (MySqlException e)
            {
                Variable_Conexion.Close();//se cierra la conexion
                throw e;
            }

            return pedido;
        }
        
        public String[] obtenerProveedores()
        {
            String[] proveedores = null;
            int total;
            comando = Variable_Conexion.CreateCommand();//Inicializacion del comando 
            comando.CommandText = "SELECT COUNT(*) FROM proveedor;";//Consulta para la base, obtener el numero de sucursales
            try
            {
                Variable_Conexion.Open();//se abre la conexion a la base
                Variable_Lectura = comando.ExecuteReader();//se guarda el conteo en la variable de lectura
                if (Variable_Lectura.Read())//se verifica si se obtiene algun dato de la base
                {
                    total = int.Parse(Variable_Lectura[0].ToString());//se convierte el objeto reader en una cadena y luego un entero
                    proveedores = new String[total];//se crea un arreglo de cadenas del tamaño del conteo obtenido de sucursales
                    comando.CommandText = "SELECT Nombre FROM proveedor;";
                    Variable_Conexion.Close();//se cierra la conexion
                    Variable_Conexion.Open();
                    Variable_Lectura = comando.ExecuteReader();
                    int contador = 0;
                    while (Variable_Lectura.Read())
                    {
                        proveedores[contador] = Variable_Lectura["Nombre"].ToString();
                        contador++;
                    }
                }
                Variable_Conexion.Close();//se cierra la conexion
                return proveedores;
            }
            catch (MySqlException e)
            {
                Variable_Conexion.Close();
                throw e;
            }
        }
        public String[,] obtenerArregloProveedores()
        {
            String[,] proveedores = null;
            int total;
            comando = Variable_Conexion.CreateCommand();//Inicializacion del comando 
            comando.CommandText = "SELECT COUNT(*) FROM proveedor;";//Consulta para la base, obtener el numero de sucursales
            try
            {
                Variable_Conexion.Open();//se abre la conexion a la base
                Variable_Lectura = comando.ExecuteReader();//se guarda el conteo en la variable de lectura
                if (Variable_Lectura.Read())//se verifica si se obtiene algun dato de la base
                {
                    total = int.Parse(Variable_Lectura[0].ToString());//se convierte el objeto reader en una cadena y luego un entero
                    proveedores = new String[2, total];//se crea un arreglo de cadenas del tamaño del conteo obtenido de sucursales
                    comando.CommandText = "SELECT id, Nombre FROM proveedor;";
                    Variable_Conexion.Close();//se cierra la conexion
                    Variable_Conexion.Open();
                    Variable_Lectura = comando.ExecuteReader();
                    int contador = 0;
                    while (Variable_Lectura.Read())
                    {
                        proveedores[0, contador] = Variable_Lectura["id"].ToString();
                        proveedores[1, contador] = Variable_Lectura["Nombre"].ToString();
                        contador++;
                    }
                }
                Variable_Conexion.Close();//se cierra la conexion
                return proveedores;
            }
            catch (MySqlException e)
            {
                Variable_Conexion.Close();
                throw e;
            }
        }
        public String[] obtenerContactos()
        {
            String[] contacto = null;
            int total;
            comando = Variable_Conexion.CreateCommand();//Inicializacion del comando 
            comando.CommandText = "SELECT COUNT(*) FROM encargado;";//Consulta para la base, obtener el numero de sucursales
            try
            {
                Variable_Conexion.Open();//se abre la conexion a la base
                Variable_Lectura = comando.ExecuteReader();//se guarda el conteo en la variable de lectura
                if (Variable_Lectura.Read())//se verifica si se obtiene algun dato de la base
                {
                    total = int.Parse(Variable_Lectura[0].ToString());//se convierte el objeto reader en una cadena y luego un entero
                    contacto = new String[total];//se crea un arreglo de cadenas del tamaño del conteo obtenido de sucursales
                    comando.CommandText = "SELECT Nombre FROM encargado;";
                    Variable_Conexion.Close();//se cierra la conexion
                    Variable_Conexion.Open();
                    Variable_Lectura = comando.ExecuteReader();
                    int contador = 0;
                    while (Variable_Lectura.Read())
                    {
                        contacto[contador] = Variable_Lectura["Nombre"].ToString();
                        contador++;
                    }
                }
                Variable_Conexion.Close();//se cierra la conexion
                return contacto;
            }
            catch (MySqlException e)
            {
                Variable_Conexion.Close();
                throw e;
            }
        }
        public String[,] obtenerArregloContactos()
        {
            String[,] contacto = null;
            int total;
            comando = Variable_Conexion.CreateCommand();//Inicializacion del comando 
            comando.CommandText = "SELECT COUNT(*) FROM encargado;";//Consulta para la base, obtener el numero de sucursales
            try
            {
                Variable_Conexion.Open();//se abre la conexion a la base
                Variable_Lectura = comando.ExecuteReader();//se guarda el conteo en la variable de lectura
                if (Variable_Lectura.Read())//se verifica si se obtiene algun dato de la base
                {
                    total = int.Parse(Variable_Lectura[0].ToString());//se convierte el objeto reader en una cadena y luego un entero
                    contacto = new String[2, total];//se crea un arreglo de cadenas del tamaño del conteo obtenido de sucursales
                    comando.CommandText = "SELECT id, Nombre FROM encargado;";
                    Variable_Conexion.Close();//se cierra la conexion
                    Variable_Conexion.Open();
                    Variable_Lectura = comando.ExecuteReader();
                    int contador = 0;
                    while (Variable_Lectura.Read())
                    {
                        contacto[0, contador] = Variable_Lectura["id"].ToString();
                        contacto[1, contador] = Variable_Lectura["Nombre"].ToString();
                        contador++;
                    }
                }
                Variable_Conexion.Close();//se cierra la conexion
                return contacto;
            }
            catch (MySqlException e)
            {
                Variable_Conexion.Close();
                throw e;
            }
        }
        public String[] obtenerPaises()
        {
            String[] paises = null;
            int total;
            comando = Variable_Conexion.CreateCommand();//Inicializacion del comando 
            comando.CommandText = "SELECT COUNT(*) FROM pais;";//Consulta para la base, obtener el numero de sucursales
            try
            {
                Variable_Conexion.Open();//se abre la conexion a la base
                Variable_Lectura = comando.ExecuteReader();//se guarda el conteo en la variable de lectura
                if (Variable_Lectura.Read())//se verifica si se obtiene algun dato de la base
                {
                    total = int.Parse(Variable_Lectura[0].ToString());//se convierte el objeto reader en una cadena y luego un entero
                    paises = new String[total];//se crea un arreglo de cadenas del tamaño del conteo obtenido de sucursales
                    comando.CommandText = "SELECT Nombre FROM pais;";
                    Variable_Conexion.Close();//se cierra la conexion
                    Variable_Conexion.Open();
                    Variable_Lectura = comando.ExecuteReader();
                    int contador = 0;
                    while (Variable_Lectura.Read())
                    {
                        paises[contador] = Variable_Lectura["Nombre"].ToString();
                        contador++;
                    }
                }
                Variable_Conexion.Close();//se cierra la conexion
                return paises;
            }
            catch (MySqlException e)
            {
                Variable_Conexion.Close();
                throw e;
            }
        }
        public String[,] obtenerArregloPaises()
        {
            String[,] paises = null;
            int total;
            comando = Variable_Conexion.CreateCommand();//Inicializacion del comando 
            comando.CommandText = "SELECT COUNT(*) FROM pais;";//Consulta para la base, obtener el numero de sucursales
            try
            {
                Variable_Conexion.Open();//se abre la conexion a la base
                Variable_Lectura = comando.ExecuteReader();//se guarda el conteo en la variable de lectura
                if (Variable_Lectura.Read())//se verifica si se obtiene algun dato de la base
                {
                    total = int.Parse(Variable_Lectura[0].ToString());//se convierte el objeto reader en una cadena y luego un entero
                    paises = new String[2, total];//se crea un arreglo de cadenas del tamaño del conteo obtenido de sucursales
                    comando.CommandText = "SELECT id, Nombre FROM pais;";
                    Variable_Conexion.Close();//se cierra la conexion
                    Variable_Conexion.Open();
                    Variable_Lectura = comando.ExecuteReader();
                    int contador = 0;
                    while (Variable_Lectura.Read())
                    {
                        paises[0, contador] = Variable_Lectura["id"].ToString();
                        paises[1, contador] = Variable_Lectura["Nombre"].ToString();
                        contador++;
                    }
                }
                Variable_Conexion.Close();//se cierra la conexion
                return paises;
            }
            catch (MySqlException e)
            {
                Variable_Conexion.Close();
                throw e;
            }
        }
        public int obtenerIdPais(String Pais)
        {
            int id = 1;
            comando = Variable_Conexion.CreateCommand();//Inicializacion del comando 
            comando.CommandText = "SELECT id FROM pais WHERE Nombre ='"+ Pais + "';";//Consulta para la base, obtener el numero de sucursales
            try
            {
                Variable_Conexion.Open();//se abre la conexion a la base
                Variable_Lectura = comando.ExecuteReader();//se guarda el conteo en la variable de lectura
                if (Variable_Lectura.Read())//se verifica si se obtiene algun dato de la base
                {
                    id = int.Parse(Variable_Lectura[0].ToString());//se convierte el objeto reader en una cadena y luego un entero
                }
                Variable_Conexion.Close();//se cierra la conexion
                return id;
            }
            catch (MySqlException e)
            {
                Variable_Conexion.Close();
                throw e;
            }
        }

        public int obtenerIdProveedor(String proveedor)
        {
            int id = 1;
            comando = Variable_Conexion.CreateCommand();//Inicializacion del comando 
            comando.CommandText = "SELECT id FROM proveedor WHERE Nombre ='" + proveedor + "';";//Consulta para la base, obtener el numero de sucursales
            try
            {
                Variable_Conexion.Open();//se abre la conexion a la base
                Variable_Lectura = comando.ExecuteReader();//se guarda el conteo en la variable de lectura
                if (Variable_Lectura.Read())//se verifica si se obtiene algun dato de la base
                {
                    id = int.Parse(Variable_Lectura[0].ToString());//se convierte el objeto reader en una cadena y luego un entero
                }
                Variable_Conexion.Close();//se cierra la conexion
                return id;
            }
            catch (MySqlException e)
            {
                Variable_Conexion.Close();
                throw e;
            }
        }
        public String obtenerNombreProveedor(int proveedor)
        {
            String id = "";
            comando = Variable_Conexion.CreateCommand();//Inicializacion del comando 
            comando.CommandText = "SELECT Nombre FROM proveedor WHERE id ='" + proveedor + "';";//Consulta para la base, obtener el numero de sucursales
            try
            {
                Variable_Conexion.Open();//se abre la conexion a la base
                Variable_Lectura = comando.ExecuteReader();//se guarda el conteo en la variable de lectura
                if (Variable_Lectura.Read())//se verifica si se obtiene algun dato de la base
                {
                    id = Variable_Lectura[0].ToString();//se convierte el objeto reader en una cadena y luego un entero
                }
                Variable_Conexion.Close();//se cierra la conexion
                return id;
            }
            catch (MySqlException e)
            {
                Variable_Conexion.Close();
                throw e;
            }
        }

        public int obtenerIdEncargado(String encargado)
        {
            int id = 1;
            comando = Variable_Conexion.CreateCommand();//Inicializacion del comando 
            comando.CommandText = "SELECT id FROM encargado WHERE Nombre ='" + encargado + "';";//Consulta para la base, obtener el numero de sucursales
            try
            {
                Variable_Conexion.Open();//se abre la conexion a la base
                Variable_Lectura = comando.ExecuteReader();//se guarda el conteo en la variable de lectura
                if (Variable_Lectura.Read())//se verifica si se obtiene algun dato de la base
                {
                    id = int.Parse(Variable_Lectura[0].ToString());//se convierte el objeto reader en una cadena y luego un entero
                }
                Variable_Conexion.Close();//se cierra la conexion
                return id;
            }
            catch (MySqlException e)
            {
                Variable_Conexion.Close();
                throw e;
            }
        }

        public String[] obtenerDetalle(int Producto_id, int Pedido_id)
        {
            String[] detalle = null;
            comando = Variable_Conexion.CreateCommand();//Inicializacion del comando 
            comando.CommandText = "SELECT Cantidad, Precio_Compra, Comentario FROM detalle_pedido WHERE Producto_id = " + Producto_id + " AND Pedido_id = " + Pedido_id.ToString() + ";";//Consulta para la base, obtener el numero de sucursales
            try
            {
                Variable_Conexion.Open();//se abre la conexion a la base
                Variable_Lectura = comando.ExecuteReader();//se guarda el conteo en la variable de lectura
                detalle = new String[3];
                if (Variable_Lectura.Read())//se verifica si se obtiene algun dato de la base
                {                  
                    detalle[0] = Variable_Lectura["Cantidad"].ToString();
                    detalle[1] = Variable_Lectura["Precio_Compra"].ToString();
                    detalle[2] = Variable_Lectura["Comentario"].ToString();
                }
                //se cierra la conexion
                Variable_Conexion.Close();
                return detalle;
            }
            catch (MySqlException e)
            {
                Variable_Conexion.Close();
                throw e;
            }
        }
        public String[] obtenerProvPed(int Producto_id)
        {
            String[] prov = null;
            int total;
            comando = Variable_Conexion.CreateCommand();//Inicializacion del comando 
            comando.CommandText = "SELECT COUNT(*) FROM prov_prod WHERE Producto_id = " + Producto_id+ ";";//Consulta para la base, obtener el numero de sucursales
            try
            {
                Variable_Conexion.Open();//se abre la conexion a la base
                Variable_Lectura = comando.ExecuteReader();//se guarda el conteo en la variable de lectura
                if (Variable_Lectura.Read())//se verifica si se obtiene algun dato de la base
                {
                    total = int.Parse(Variable_Lectura[0].ToString());//se convierte el objeto reader en una cadena y luego un entero
                    prov = new String[total];//se crea un arreglo de cadenas del tamaño del conteo obtenido de sucursales
                    comando.CommandText = "SELECT p.Nombre  AS 'Nombre' FROM prov_prod r INNER JOIN proveedor p on r.Proveedor_id = p.id WHERE Producto_id = " + Producto_id + ";";
                    Variable_Conexion.Close();//se cierra la conexion
                    Variable_Conexion.Open();
                    Variable_Lectura = comando.ExecuteReader();
                    int contador = 0;
                    int id;
                    while (Variable_Lectura.Read())
                    {
                        prov[contador] = Variable_Lectura["Nombre"].ToString();
                        contador++;
                    }
                }
                //se cierra la conexion
                Variable_Conexion.Close();
                return prov;
            }
            catch (MySqlException e)
            {
                Variable_Conexion.Close();
                throw e;
            }
        }
        public void eliminarProdProv(int Producto_id)
        {
            comando = Variable_Conexion.CreateCommand();//Inicializacion del comando 
            comando.CommandText = "DELETE FROM prov_prod WHERE Producto_id = " + Producto_id + ";";//Consulta para la base, obtener el numero de sucursales
            try
            {
                Variable_Conexion.Open();//se abre la conexion a la base
                comando.ExecuteNonQuery();
                Variable_Conexion.Close();
            }
            catch (MySqlException e)
            {
                Variable_Conexion.Close();
                throw e;
            }
        }
        public void ingresarProdProv(int Proveedor_id, int Producto_id)
        {
            
            comando = Variable_Conexion.CreateCommand();//Inicializacion del comando 
            comando.CommandText = "INSERT INTO prov_prod (Proveedor_id, Producto_id) VALUES (" + Proveedor_id.ToString() + ", " + Producto_id.ToString() + ");";//Consulta para la base, obtener el numero de sucursales
            try
            {
                Variable_Conexion.Open();//se abre la conexion a la base
                comando.ExecuteNonQuery();
                Variable_Conexion.Close();
            }
            catch (MySqlException e)
            {
                Variable_Conexion.Close();
                throw e;
            }
        }
        public void estadoPedido(String Nombre, String Estado)
        {

            comando = Variable_Conexion.CreateCommand();//Inicializacion del comando 
            comando.CommandText = "UPDATE pedido SET Finalizado = '" + Estado + "' WHERE Mes = '" + Nombre + "';";//Consulta para la base, obtener el numero de sucursales
            try
            {
                Variable_Conexion.Open();//se abre la conexion a la base
                comando.ExecuteNonQuery();
                Variable_Conexion.Close();
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
             public Boolean existePais(String Pais)
        {
            Boolean Existe = false;
            try
            {
               
                int contador = 0;

                comando = Variable_Conexion.CreateCommand();//Inicializacion del comando 
                comando.CommandText = "SELECT COUNT(*) FROM pais WHERE Nombre='" + Pais + "';";//Consulta para la base, obtener el numero de sucursales
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
        public int obtener_IDTrabajador()
        {
            int total = 0;
            try
            {

                comando = Variable_Conexion.CreateCommand();//Inicializacion del comando 
                comando.CommandText = "SELECT COUNT(*) FROM trabajador ;";//Consulta para la base, obtener el numero de sucursales

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
        /// //////////////////
        public String[,] obtener_Trabajadores1(String diferencia)
        {
            String[,] sucursales = null;
            int total;
            comando = Variable_Conexion.CreateCommand();//Inicializacion del comando 
            comando.CommandText = "SELECT COUNT(*) FROM trabajador;";//Consulta para la base, obtener el numero de sucursales
            try
            {
                Variable_Conexion.Open();//se abre la conexion a la base
                Variable_Lectura = comando.ExecuteReader();//se guarda el conteo en la variable de lectura
                if (Variable_Lectura.Read())//se verifica si se obtiene algun dato de la base
                {
                    total = int.Parse(Variable_Lectura[0].ToString());//se convierte el objeto reader en una cadena y luego un entero
                    sucursales = new String[2, total];//se crea un arreglo de cadenas del tamaño del conteo obtenido de sucursales
                    comando.CommandText = "SELECT * FROM trabajador;";
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
        /// <summary>
        /// Funcion que devuelve un objeto de la Clase clientes, extrae los datos de un cliente por medio
        /// de su id y luego los ingresa en el objeto
        /// </summary>
        /// <param name="id"></param>Id del cliente que se busca
        /// <returns></returns>Objeto cliente
        public Cliente getCliente(String id)
        {
            Cliente clienteB = null;
            comando = Variable_Conexion.CreateCommand();//Inicializacion del comando 
            comando.CommandText = "SELECT * FROM cliente WHERE id = " + id+ ";";//Consulta para la base, obtener el numero de clientes
            Variable_Conexion.Open();//se abre la conexion a la base
            Variable_Lectura = comando.ExecuteReader();//se guarda el conteo en la variable de lectura
            if (Variable_Lectura.Read())//se verifica si se obtiene algun dato de la base
            {
                clienteB = new Cliente();
                clienteB.dpi = Variable_Lectura["NIT_DPI"].ToString();
                clienteB.nombre = Variable_Lectura["Nombre"].ToString();
                clienteB.apellido = Variable_Lectura["Apellido"].ToString();
                clienteB.clasificacion = int.Parse(Variable_Lectura["Clasificacion_id"].ToString());
                clienteB.limite = Double.Parse(Variable_Lectura["Limite_Credito"].ToString());
                clienteB.dias = int.Parse(Variable_Lectura["Dias_Credito"].ToString());
                clienteB.id = int.Parse(id);
             
            }
            Variable_Conexion.Close();
            return clienteB;
        }
        /// <summary>
        /// Funcion que retorna el saldo de un cliente
        /// </summary>
        /// <param name="idCliente"></param>Id del cliente
        /// <param name="idSucursal"></param>Id de la sucursal (si es 0) retorna toda la deuda
        /// <returns></returns>
        public double obtener_saldoTotal(int idCliente, int idSucursal)
        {
            double saldo=0;
            int deuda=0;
            comando = Variable_Conexion.CreateCommand();//Inicializacion del comando 
            if (idSucursal > 0)
            {
                comando.CommandText = "SELECT COUNT(*) FROM deuda WHERE Cliente_id=" + idCliente + " AND Sucursal_id=" + idSucursal + ";";//Consulta para la base, obtener el numero de deudas que concuerden 
                //con la id de la sucursal y del cliente
                Variable_Conexion.Open();//se abre la conexion a la base
                Variable_Lectura = comando.ExecuteReader();//se guarda el conteo en la variable de lectura
                if (Variable_Lectura.Read())//se verifica si se obtiene algun dato de la base
                {
                    deuda = int.Parse(Variable_Lectura[0].ToString());//se convierte el objeto reader en una cadena y luego un entero
                }
                Variable_Conexion.Close();//se cierra la conexion
                if (deuda > 0)
                {
                    comando.CommandText = "SELECT SUM(Saldo) FROM deuda WHERE Cliente_id=" + idCliente + " AND Sucursal_id=" + idSucursal + ";";
                    Variable_Conexion.Open();
                    Variable_Lectura = comando.ExecuteReader();
                    if (Variable_Lectura.Read())//se verifica si se obtiene algun dato de la base
                    {
                            saldo = double.Parse(Variable_Lectura[0].ToString());//se convierte el objeto reader en una cadena y luego un real
                    }
                    Variable_Conexion.Close();
                }
            }
            else
            {
                comando.CommandText = "SELECT SUM(Saldo) FROM deuda WHERE Cliente_id=" + idCliente+";";//Consulta para la base, obtener el total de deuda que concuerden 
                //con la id ddel cliente
                Variable_Conexion.Open();//se abre la conexion a la base
                Variable_Lectura = comando.ExecuteReader();//se guarda el conteo en la variable de lectura
                if (Variable_Lectura.Read())//se verifica si se obtiene algun dato de la base
                {
                    if (!String.IsNullOrEmpty(Variable_Lectura[0].ToString()))
                        saldo = double.Parse(Variable_Lectura[0].ToString());//se convierte el objeto reader en una cadena y luego un entero
                }
                Variable_Conexion.Close();//se cierra la conexion
            }
            return saldo;
        }
        /// <summary>
        /// Funcion que genera una matriz de cadenas de Nx4 que contiene en sus columnas 0,1,2,3 
        /// El nombre,apellido,id, sucursal de la deuda de un cliente respectivamente
        /// La consulta devuelve los datos necesarios de un cliente y la sucursal con la que tiene deuda
        /// 1- Si el cliente no tiene deuda en ninguna sucursal, se añade, pero sin sucursal
        /// 2- SI un cliente tiene deudas en varias sucursales, regresa un registro para cada caso
        /// </summary>
        /// <returns>Matriz de Strings de Clientes-sucursales</returns>
        public String[,] obtener_clientes_sucursal()
        {
            String[,] clientes = null;
            int total;
            comando = Variable_Conexion.CreateCommand();//Inicializacion del comando 
            comando.CommandText = "SELECT contarClienteSucursal()";//Consulta para la base, obtener el numero de registros
            //que tiene la consulta de clientes y sucursales
            Variable_Conexion.Open();//se abre la conexion a la base
            Variable_Lectura = comando.ExecuteReader();//se guarda el conteo en la variable de lectura
            if (Variable_Lectura.Read())//se verifica si se obtiene algun dato de la base
            {
                total = int.Parse(Variable_Lectura[0].ToString());//se convierte el objeto reader en una cadena y luego un entero
                clientes = new String[total, 4];//se crea un arreglo de cadenas del tamaño del conteo obtenido de clientes
                comando.CommandText = "SELECT c.Nombre,c.Apellido,c.id,s.Nombre AS Sucursal FROM cliente c LEFT JOIN "+
                    "deuda d ON c.id = d.Cliente_id LEFT JOIN sucursal s ON  s.id=d.Sucursal_id GROUP BY s.id, c.id HAVING SUM(c.Habilitado)>0;";
                Variable_Conexion.Close();//se cierra la conexion
                Variable_Conexion.Open();
                Variable_Lectura = comando.ExecuteReader();
                int contador = 0;
                while (Variable_Lectura.Read())
                {
                    clientes[contador, 0] = Variable_Lectura["Nombre"].ToString();
                    clientes[contador, 1] = Variable_Lectura["Apellido"].ToString();
                    clientes[contador, 2] = Variable_Lectura["id"].ToString();
                    clientes[contador, 3] = Variable_Lectura["Sucursal"].ToString();
                    contador++;
                }
            }
            Variable_Conexion.Close();//se cierra la conexion
            return clientes;
        }
        /// <summary>
        /// FUncion que devueve una matriz String de N x 3 que contiene el nombre, apellido e id de cada cliente 
        /// </summary>
        /// <returns></returns>
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
                comando.CommandText = "SELECT Nombre,Apellido,id FROM cliente WHERE Habilitado>0 ORDER BY Apellido ASC;";
                Variable_Conexion.Close();//se cierra la conexion
                Variable_Conexion.Open();
                Variable_Lectura = comando.ExecuteReader();
                int contador = 0;
                while (Variable_Lectura.Read())
                {
                    clientes[contador,0] = Variable_Lectura["Nombre"].ToString();
                    clientes[contador,1] = Variable_Lectura["Apellido"].ToString();
                    clientes[contador,2] = Variable_Lectura["id"].ToString();
                    contador++;
                }
            }
            Variable_Conexion.Close();//se cierra la conexion
            return clientes;
        }
        /// <summary>
        /// Funcion que retorna una DataTable para un datagrid
        /// dependiendo de la bandera y la id de la sucursal se genera la consulta de la tabla
        /// </summary>
        /// <param name="deuda"></param>Bandera booleana que indica si el registro es de deuda o no
        /// TRUE el registro es para deuda - FALSE el registro es de pagos
        /// <param name="idCliente"></param> Id del cliente del que se quiere el registro
        /// <param name="idSucursal"></param> Id de la sucursal de la que se quiere el registro
        /// Si es 0, se hace un registro general
        /// <returns></returns>
        public DataTable tabla(bool deuda, int idCliente, int idSucursal)
        {
            DataTable ds = new DataTable();
            String consulta="";
            if (deuda)
            {
                if(idSucursal>0)
                    consulta = "SELECT d.Fecha_Pago as 'Fecha Deuda',Fecha_Ingreso as 'Fecha de Ingreso',"+
                        "d.Total as 'Deuda', d.Saldo FROM deuda d WHERE d.Cliente_id="+idCliente+
                        " AND d.Sucursal_id="+idSucursal+";";
                else
                    consulta = "SELECT d.Fecha_Pago as 'Fecha Deuda',Fecha_Ingreso as 'Fecha de Ingreso',"+
                        "d.Total as 'Deuda', d.Saldo, s.Nombre as 'Sucursal' FROM deuda d INNER JOIN sucursal "+
                        "s ON s.id=d.Sucursal_id WHERE Cliente_id="+idCliente+" ORDER BY s.Nombre AND d.Fecha_Ingreso;";
            }
            else
            {
                if (idSucursal > 0)
                    consulta = "SELECT d.Fecha as 'Fecha Pago',Fecha_Ingreso as 'Fecha de Ingreso'," +
                        "d.Monto FROM pagos d WHERE d.Cliente_id=" + idCliente +
                        " AND d.Sucursal_id=" + idSucursal + ";";
                else
                    consulta = "SELECT d.Fecha as 'Fecha Pago',Fecha_Ingreso as 'Fecha de Ingreso'," +
                    "d.Monto, s.Nombre as 'Sucursal' FROM pagos d INNER JOIN sucursal " +
                    "s ON s.id=d.Sucursal_id WHERE Cliente_id=" + idCliente + " ORDER BY s.Nombre AND d.Fecha_Ingreso;";
            }
            MySqlDataAdapter data = new MySqlDataAdapter(consulta, Variable_Conexion);
            data.Fill(ds);
            return (ds);
        }
        public Cliente datos_cliente()
        {
            Cliente cliente=null;
            
            return cliente;
        }
        public DataTable exportarDeuda(int mesInicio, int mes)
        {
            DataTable tabla=new DataTable();
            String[,] clientes = obtener_clientes();
            String[,] sucursales= obtener_sucursales();
            if (sucursales.Length > 0)
            {
                tabla.Columns.Add("Nombres");
                for(int i=0;i<sucursales.Length/2;i++)
                {
                    tabla.Columns.Add(sucursales[i,0]);
                }
                DataRow filaNombre = tabla.NewRow();
                filaNombre[0] = "Nombre";
                for (int i = 0; i < sucursales.Length / 2; i++)
                {
                    filaNombre[i+1]=(sucursales[i, 0]);
                }
                tabla.Rows.Add(filaNombre);
                DataRow[] fila=new DataRow[clientes.Length/3];
                for(int i=0;i<clientes.Length/3;i++)
                {
                    fila[i] = tabla.NewRow();
                    fila[i][0]=clientes[i,0]+" "+clientes[i,1];
                    for(int o=1;o<tabla.Columns.Count;o++)
                    {
                        fila[i][o]=obtener_saldoTotal(int.Parse(clientes[i,2]),int.Parse(sucursales[o-1,1]));
                    }
                    tabla.Rows.Add(fila[i]);
                }
            }
            return tabla;
        }
        public void exportar(DataTable tabla, String direccion)
        {
            Microsoft.Office.Interop.Excel.Application aplicacion;
            Microsoft.Office.Interop.Excel.Workbook libros_trabajo;
            Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;
            aplicacion = new Microsoft.Office.Interop.Excel.Application();
            libros_trabajo = aplicacion.Workbooks.Add();
            hoja_trabajo =
                (Microsoft.Office.Interop.Excel.Worksheet)libros_trabajo.Worksheets[1];
            hoja_trabajo.Name = "Hoja1";
       
            //Recorremos el DataGridView rellenando la hoja de trabajo
            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                for (int j = 0; j < tabla.Columns.Count; j++)
                {
                    hoja_trabajo.Cells[i + 1, j + 1] = tabla.Rows[i][j];
                }
            }
            hoja_trabajo.Columns.AutoFit();
            libros_trabajo.SaveAs(direccion,
            Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
            libros_trabajo.Close(true);
            aplicacion.Quit();
        }
        /// <summary>
        /// Método que ingresa los permisos
        /// </summary>
        /// <param name="usuarios">Cadena de accesos de usuarios</param>
        /// <param name="clientes">Cadena </param>
        /// <param name="pedidos"></param>
        /// <param name="trabajadores"></param>
        /// <param name="clave"></param>
        /// <param name="usuario"></param>
        public void ingresaPermisos(String usuarios, String clientes, String pedidos, String trabajadores, String clave, String usuario)
        {
            comando = Variable_Conexion.CreateCommand();
            comando.CommandText = "CALL ingresaModificaUsuarios ('"+usuarios+"','"+clientes+"','"+pedidos+"','"+trabajadores+"','"+clave+"','"+usuario+"');";
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
    }
}

    
