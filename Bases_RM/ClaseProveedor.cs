using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bases_RM
{
    class ClaseProveedor
    {
        public int id, pais_id;
        public String Nombre;
        public ClaseContacto[] contactos;
        public ClaseProveedor(int id, String Nombre, int pais_id)
        {
            this.id = id;
            this.Nombre = Nombre;
            this.pais_id = pais_id;
        }

    }
}
