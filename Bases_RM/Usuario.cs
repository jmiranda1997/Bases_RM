using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bases_RM
{
    public class Usuario
    {
        public String Nombre = "", Clave = "",Cadena_Pedido="",Cadena_Seguridad="", Cadena_Cliente="", Cadena_Trabajador="";
        public Usuario(String nombre, String clave, String seguridad, String cliente, String trabajador, String pedido)
        {
            this.Nombre = nombre;
            this.Clave = clave;
            this.Cadena_Seguridad = seguridad;
            this.Cadena_Cliente = cliente;
            this.Cadena_Trabajador = trabajador;
            this.Cadena_Pedido = pedido;
        }

    }
}
