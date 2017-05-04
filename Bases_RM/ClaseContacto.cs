using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bases_RM
{
    class ClaseContacto
    {
        public int id;
        public String Nombre, Correo;
        public ClaseProveedor[] proveedores;
        public ClaseContacto(int id, String Nombre, String Correo)
        {
            this.id = id;
            this.Nombre = Nombre;
            this.Correo = Correo;
        }
    }
}
