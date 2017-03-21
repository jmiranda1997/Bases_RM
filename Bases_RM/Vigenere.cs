using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bases_RM
{
    class Vigenere
    {
        char[] mensaje;
        char[] mensajeDes;
        char[] clave;
        char[] resultado;
        char[] lista;
        String mensajeDescifrado = "", CP = "3JOR", mensajeCifrado = "";

        public Vigenere()
        {
        }

        /*
            método que genera el abcedario basado en el código ascii
            @return lista que es el abcdario
        */

        public char[] generarAbecedario()
        {
            lista = new char[256];
            for (int i = 0; i <= 255; i++)
            {
                lista[i] = (char)i;
            }
            return lista;
        }

        /*
          método que es el encargado de cifrar el mensaje recibido con la clave
          @param message
          @param Clave 
        */
        public void cifrar(String message, String Clave)
        {
            int cont = 0, x = 0, k = 0;
            String cadena = "", cadena1 = message;
            this.mensaje = message.ToCharArray();
            char[] claveTemporal = Clave.ToCharArray();
            this.clave = new char[mensaje.Length];
            for (int i = 0; i < mensaje.Length; i++)
            {
                this.clave[i] = claveTemporal[cont];
                cont++;
                if (cont == claveTemporal.Length)
                    cont = 0;
            }
            char[] a = new char[message.Length];
            for (int i = 0; i < message.Length; i++)
            {
                x = (int)this.mensaje[i];
                k = (int)this.clave[i];
                a[i] = ((char)((x + k) % generarAbecedario().Length));
            }
            CP = Clave;
            cadena = Convert.ToString(clave);
            mensajeCifrado = "";
            for (int i = 0; i < a.Length; i++)
            {
                mensajeCifrado += a[i] + "";
            }
        }
        public void descifrar(String mesajeCifrado, String CP)
        {
            this.mensaje = mesajeCifrado.ToCharArray();
            String cadena = "";
            int c = 0, k = 0, cont = 0;
            char[] claveTemporal = CP.ToCharArray();
            this.clave = new char[mensaje.Length];
            for (int i = 0; i < mensaje.Length; i++)
            {
                this.clave[i] = claveTemporal[cont];
                cont++;
                if (cont == claveTemporal.Length)
                    cont = 0;
            }
            char[] a = new char[mesajeCifrado.Length];
            for (int i = 0; i < mesajeCifrado.Length; i++)
            {
                c = (int)this.mensaje[i];
                k = (int)this.clave[i];
                if ((c - k) >= 0)
                {
                    a[i] = ((char)((c - k) % generarAbecedario().Length));
                }
                else if ((c - k) < 0)
                {
                    a[i] = ((char)(((c - k) + generarAbecedario().Length) % generarAbecedario().Length));
                }
            }
            cadena = clave.ToString();
            mensajeDescifrado = "";
            for (int i = 0; i < a.Length; i++)
            {
                mensajeDescifrado += a[i] + "";
            }
        }
        /// <summary>
        /// Devuelve el mensaje descifrado
        /// </summary>
        /// <returns>Mensaje descifrado</returns>
        public String getMD()
        {
            return mensajeDescifrado;
        }
        /// <summary>
        /// Devuelve el mensaje cifrado
        /// </summary>
        /// <returns>Mensaje cifrado</returns>
        public String getMC()
        {
            return mensajeCifrado;
        }
        /**
         * 
         * @return la clave 
         */
        public String getCP()
        {
            return CP;
        }
    }
}

