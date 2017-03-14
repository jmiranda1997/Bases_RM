using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bases_RM
{
    class Producto
    {
        public String Codigo_Interno = "", Codigo_Barras = "", Descripcion="",  Marca = "", Proveedor = "", Fabricante = "", Departamento = "";
        public double Precio_Costo = 0.00, Precio_Venta = 0.00;
        public int[] Existencias = null;

        public Producto(String Codigo_Interno, String Codigo_Barras, String Descripcion,String Marca, String Fabricante, String Departamento, double Precio_Costo, double Precio_Venta)
        {
            this.Codigo_Interno = Codigo_Interno;
            this.Codigo_Barras = Codigo_Barras;
            this.Descripcion = Descripcion;
            this.Marca = Marca;
            this.Fabricante = Fabricante;
            this.Departamento = Departamento;
            this.Precio_Costo = Precio_Costo;
            this.Precio_Venta = Precio_Venta;
        }
        public Producto(String Codigo_Interno, String Codigo_Barras, String Descripcion, String Marca, String Fabricante, String Departamento, double Precio_Costo, double Precio_Venta, int[] Existencias)
        {
            this.Codigo_Interno = Codigo_Interno;
            this.Codigo_Barras = Codigo_Barras;
            this.Descripcion = Descripcion;
            this.Marca = Marca;
            this.Fabricante = Fabricante;
            this.Departamento = Departamento;
            this.Precio_Costo = Precio_Costo;
            this.Precio_Venta = Precio_Venta;
            this.Existencias = Existencias;
        }
    }
}
