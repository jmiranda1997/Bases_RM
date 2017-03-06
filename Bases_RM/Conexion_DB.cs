using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Bases_RM
{
    class Conexion_DB
    {
        private MySqlConnectionStringBuilder Constructor_Conexion = new MySqlConnectionStringBuilder();
        private MySqlConnection Variable_Conexion;
        public Conexion_DB(){
            Constructor_Conexion.Server = "25.84.214.223";
            Constructor_Conexion.UserID = "root";
            Constructor_Conexion.Password = "@Sistemas2017";
            Constructor_Conexion.Database = "rm_db";
            //creacion de variable de conexion
            Variable_Conexion = new MySqlConnection(Constructor_Conexion.ToString());
        }
        public void Guardar()
        {
            MySqlCommand comando = Variable_Conexion.CreateCommand();
            comando.CommandText = "INSERT INTO sucursal (Nombre) VALUES('hola');";
            Variable_Conexion.Open();
            comando.ExecuteNonQuery();
            Variable_Conexion.Close();
        }
    }
    
}
