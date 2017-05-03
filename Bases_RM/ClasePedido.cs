using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bases_RM
{
    class ClasePedido
    {
        public int id;
        public bool finalizado;
        public Double total;
        public String Nombre;

        public ClasePedido(int id, bool finalizado, Double total, String Nombre)
        {
            this.id = id;
            this.finalizado = finalizado;
            this.total = total;
            this.Nombre = Nombre;
        }

    }
}
