using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bases_RM
{
    class TrabajadoresClass
    {
      
        public String Nombre = "";
        public double Salario = 0.00;
        public int Sucursal_ID;
        public int codigo;
        public String Habilitado = "";
         public TrabajadoresClass(String Nombre, double Salario, int Sucursal_ID, int codigo, String Habilitado)
        {
            this.Nombre = Nombre;
            this.Salario = Salario;
            this.Sucursal_ID = Sucursal_ID;
            this.codigo = codigo;
            this.Habilitado = Habilitado;

        }

    }
}
