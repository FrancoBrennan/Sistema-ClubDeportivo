using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class ProfesorClaseDatos
    {
        private Conexion conexion;

        public ProfesorClaseDatos()
        {
            conexion = new Conexion();
        }

        public SqliteDataReader listarRelaciones()
        {
            string query = "SELECT ProfeDNI, IDClase FROM ProfesorClase";
            SqliteCommand command = new SqliteCommand(query);
            return conexion.ejecutarSelect(command);
        }

        public int removerRelacion(int idClase, int DniProf)
        {
            string query = "DELETE FROM ProfesorClase WHERE IDClase = (@IdClase) AND profDNI = (@DniProf)";

            // Crear y configurar el comando SQL
            using (SqliteCommand cmd = new SqliteCommand(query))
            {
                // Agregar parámetros al comando
                cmd.Parameters.AddWithValue("@IdClase", idClase);
                cmd.Parameters.AddWithValue("@DniProf", DniProf);

                return this.conexion.ejecutarComando(cmd);
            }

        }

        public int agregarRelacion(int profDNI, int idClase)
        {
            string query = "INSERT INTO ProfesorClase (IDClase, ProfeDNI) VALUES (@IDClase, @ProfeDNI)";

            // Crear y configurar el comando SQL
            using (SqliteCommand cmd = new SqliteCommand(query))
            {
                // Agregar parámetros al comando
                cmd.Parameters.AddWithValue("@IDClase", idClase);
                cmd.Parameters.AddWithValue("@ProfeDNI", profDNI);

                return this.conexion.ejecutarComando(cmd);
            }
        }

        // REMOVER con unicamente idAct
        public int removerRelacionDniProf(int dni)
        {
            string query = "DELETE FROM ProfesorClase WHERE ProfeDNI = @dni";

            // Crear y configurar el comando SQL
            using (SqliteCommand cmd = new SqliteCommand(query))
            {
                // Agregar parámetros al comando
                cmd.Parameters.AddWithValue("@IDAct", dni);

                return this.conexion.ejecutarComando(cmd);
            }
        }

        // REMOVER con unicamente idCom
        public int removerRelacionIdClase(int idClase)
        {
            string query = "DELETE FROM ActividadClase WHERE IDClase = @IDClase";

            // Crear y configurar el comando SQL
            using (SqliteCommand cmd = new SqliteCommand(query))
            {
                // Agregar parámetros al comando
                cmd.Parameters.AddWithValue("@IdClase", idClase);

                return this.conexion.ejecutarComando(cmd);
            }
        }
    }

}
