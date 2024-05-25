using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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

        public int agregarRelacion(int socDni, int idClase)
        {
            string query = "INSERT INTO SocioClase (SocioDNI, IDClase) VALUES (@socDni, idClase)";

            // Crear y configurar el comando SQL
            using (SqliteCommand cmd = new SqliteCommand(query))
            {
                // Agregar parámetros al comando
                cmd.Parameters.AddWithValue("@socDni", socDni);
                cmd.Parameters.AddWithValue("@idClase", idClase);

                return this.conexion.ejecutarComando(cmd);
            }

        }

        public int removerRelacion(int socDni, int idClase)
        {
            string query = "DELETE FROM SocioClase WHERE IDClase = (@IdClase) AND SocioDNI = (@SocDni)";

            // Crear y configurar el comando SQL
            using (SqliteCommand cmd = new SqliteCommand(query))
            {
                // Agregar parámetros al comando
                cmd.Parameters.AddWithValue("@IdClase", idClase);
                cmd.Parameters.AddWithValue("@SocDni", socDni);

                return this.conexion.ejecutarComando(cmd);
            }

        }

        // REMOVER con unicamente Dni
        public int removerRelacionPorDni(int dni)
        {
            string query = "DELETE FROM SocioClase WHERE SocioDNI = (@SocDni)";

            // Crear y configurar el comando SQL
            using (SqliteCommand cmd = new SqliteCommand(query))
            {
                // Agregar parámetros al comando
                cmd.Parameters.AddWithValue("@SocDni", dni);

                return this.conexion.ejecutarComando(cmd);
            }
        }

        // REMOVER con unicamente idCom
        public int removerRelacionPorIdCom(int idClase)
        {
            string query = "DELETE FROM SocioClase WHERE IDClase = (@IdClase)";

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
