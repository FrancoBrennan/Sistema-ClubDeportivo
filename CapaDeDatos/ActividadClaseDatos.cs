using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class ActividadClaseDatos
    {
        private Conexion conexion;

        public ActividadClaseDatos()
        {
            conexion = new Conexion();
        }

        public SqliteDataReader listarRelaciones()
        {
            string query = "SELECT IDActividad, IDClase FROM ActividadClase";
            SqliteCommand command = new SqliteCommand(query);
            return conexion.ejecutarSelect(command);
        }

        
        public int removerRelacion(int idClase, int idAct)
        {
            string query = "DELETE FROM ActividadClase WHERE IDClase = (@IdClase) AND IDActividad = (@IdAct)";

            // Crear y configurar el comando SQL
            using (SqliteCommand cmd = new SqliteCommand(query))
            {
                // Agregar parámetros al comando
                cmd.Parameters.AddWithValue("@IdClase", idClase);
                cmd.Parameters.AddWithValue("@IdActividad", idAct);

                return this.conexion.ejecutarComando(cmd);
            }

        }
    }


}
