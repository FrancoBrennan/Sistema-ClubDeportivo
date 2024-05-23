using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class SocioClaseDatos
    {
        private Conexion conexion;

        public SocioClaseDatos()
        {
            conexion = new Conexion();
        }

        public SqliteDataReader listarRelaciones()
        {
            string query = "SELECT SocioDNI,IDClase FROM SocioClase";
            SqliteCommand command = new SqliteCommand(query);
            return conexion.ejecutarSelect(command);
        }
    }


}
