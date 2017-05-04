using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bases_RM
{
    public class Usuario
    {
        public String Nombre = "";
        public List<bool> pUsuarios= new List<bool>();
        public List<bool> pClientes = new List<bool>();
        public List<bool> pPedidos = new List<bool>();
        public List<bool> pTrabajadores = new List<bool>();
        private Conexion_DB conexion = new Conexion_DB();

        public Usuario(String nombre)
        {
            this.Nombre = nombre;
        }
        public void obtenerPermisos()
        {
            //Reinicializa las listas de accesos para guardar la nueva información
            this.pUsuarios = new List<bool>();
            this.pClientes = new List<bool>();
            this.pPedidos = new List<bool>();
            this.pTrabajadores = new List<bool>();
            String[,] cadena = conexion.obtenerPermisos(this.Nombre);//Consulta los accesos desde la base de datos
            //Crea los arrays para determinar los permisos
            Char[] usuario = cadena[0, 0].ToCharArray();
            Char[] clientes = cadena[0, 1].ToCharArray();
            Char[] pedidos = cadena[0, 2].ToCharArray();
            Char[] trabajadores = cadena[0, 3].ToCharArray();
            /*Los permisos están en el mismo orden que los CheckBoxes que están en la ventana de 'Seguridad.cs'*/
            //Carga de los accesos de usuarios
            if (usuario.Length > 0)
            {
                if (usuario[0] == '1')
                    this.pUsuarios.Add(true);
                else
                    this.pUsuarios.Add(false);
                if (usuario[1] == '1')
                    this.pUsuarios.Add(true);
                else
                    this.pUsuarios.Add(false);
                if (usuario[2] == '1')
                    this.pUsuarios.Add(true);
                else
                    this.pUsuarios.Add(false);
            }
            //Carga de accesos de clientes
            if (clientes.Length > 0)
            {
                if (clientes[0] == '1')
                    this.pClientes.Add(true);
                else
                    this.pClientes.Add(false);
                if (clientes[1] == '1')
                    this.pClientes.Add(true);
                else
                    this.pClientes.Add(false);
                if (clientes[2] == '1')
                    this.pClientes.Add(true);
                else
                    this.pClientes.Add(false);
                if (clientes[3] == '1')
                    this.pClientes.Add(true);
                else
                    this.pClientes.Add(false);
                if (clientes[4] == '1')
                    this.pClientes.Add(true);
                else
                    this.pClientes.Add(false);
                if (clientes[5] == '1')
                    this.pClientes.Add(true);
                else
                    this.pClientes.Add(false);
                if (clientes[6] == '1')
                    this.pClientes.Add(true);
                else
                    this.pClientes.Add(false);
                if (clientes[7] == '1')
                    this.pClientes.Add(true);
                else
                    this.pClientes.Add(false);
                if (clientes[8] == '1')
                    this.pClientes.Add(true);
                else
                    this.pClientes.Add(false);
                if (clientes[9] == '1')
                    this.pClientes.Add(true);
                else
                    this.pClientes.Add(false);
            }
            //Carga de accesos de pedidos
            if (pedidos.Length > 0)
            {
                if (pedidos[0] == '1')
                    this.pPedidos.Add(true);
                else
                    this.pPedidos.Add(false);
                if (pedidos[1] == '1')
                    this.pPedidos.Add(true);
                else
                    this.pPedidos.Add(false);
                if (pedidos[2] == '1')
                    this.pPedidos.Add(true);
                else
                    this.pPedidos.Add(false);
                if (pedidos[3] == '1')
                    this.pPedidos.Add(true);
                else
                    this.pPedidos.Add(false);
            }
            //Carga de accesos de trabajadores
            if (trabajadores.Length > 0)
            {
                if (trabajadores[0] == '1')
                    this.pTrabajadores.Add(true);
                else
                    this.pTrabajadores.Add(false);
                if (trabajadores[1] == '1')
                    this.pTrabajadores.Add(true);
                else
                    this.pTrabajadores.Add(false);
                if (trabajadores[2] == '1')
                    this.pTrabajadores.Add(true);
                else
                    this.pTrabajadores.Add(false);
                if (trabajadores[3] == '1')
                    this.pTrabajadores.Add(true);
                else
                    this.pTrabajadores.Add(false);
                if (trabajadores[4] == '1')
                    this.pTrabajadores.Add(true);
                else
                    this.pTrabajadores.Add(false);
                if (trabajadores[5] == '1')
                    this.pTrabajadores.Add(true);
                else
                    this.pTrabajadores.Add(false);
                if (trabajadores[6] == '1')
                    this.pTrabajadores.Add(true);
                else
                    this.pTrabajadores.Add(false);
                if (trabajadores[7] == '1')
                    this.pTrabajadores.Add(true);
                else
                    this.pTrabajadores.Add(false);
                if (trabajadores[8] == '1')
                    this.pTrabajadores.Add(true);
                else
                    this.pTrabajadores.Add(false);
            }
        }
    }
}
