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
    public class SocioPagoDatos
    {
        private Conexion conexion;

        public SocioPagoDatos()
        {
            conexion = new Conexion();
        }

        public SqliteDataReader listarRelaciones()
        {
            string query = "SELECT SocioDNI, PagoId FROM SocioPago";
            SqliteCommand command = new SqliteCommand(query);
            return conexion.ejecutarSelect(command);
        }

        public int agregarRelacion(int socDni, int idPago)
        {
            string query = "INSERT INTO SocioPago (SocioDNI, PagoId) VALUES (@socDni, @idPago)";

            // Crear y configurar el comando SQL
            using (SqliteCommand cmd = new SqliteCommand(query))
            {
                // Agregar parámetros al comando
                cmd.Parameters.AddWithValue("@socDni", socDni);
                cmd.Parameters.AddWithValue("@idPago", idPago);

                return this.conexion.ejecutarComando(cmd);
            }

        }

        // REMOVER con unicamente Dni
        public int removerRelacionPorDni(int dni)
        {
            string query = "DELETE FROM SocioPago WHERE SocioDNI = (@SocDni)";

            // Crear y configurar el comando SQL
            using (SqliteCommand cmd = new SqliteCommand(query))
            {
                // Agregar parámetros al comando
                cmd.Parameters.AddWithValue("@SocDni", dni);

                return this.conexion.ejecutarComando(cmd);
            }
        }

        // REMOVER por el id de pago
        public int removerRelacionPorPago(int idPago)
        {
            string query = "DELETE FROM SocioPago WHERE PagoId = (@idPago)";

            // Crear y configurar el comando SQL
            using (SqliteCommand cmd = new SqliteCommand(query))
            {
                // Agregar parámetros al comando
                cmd.Parameters.AddWithValue("@idPago", idPago);

                return this.conexion.ejecutarComando(cmd);
            }
        }

    }


}
