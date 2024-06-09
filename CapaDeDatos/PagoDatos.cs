using System;
using System.Data.OleDb;

namespace CapaDeDatos
{
    public class PagoDatos
    {
        private Conexion con;

        public PagoDatos()
        {
            this.con = new Conexion();
        }

        public int agregar(int id, DateTime fechaPaga, float montoTotal)
        {
            string query = "INSERT INTO Pago (ID, FechaPaga, MontoTotal) VALUES (@ID, @FechaPaga, @MontoTotal)";

            // Crear y configurar el comando SQL
            using (OleDbCommand cmd = new OleDbCommand(query))
            {
                // Agregar parámetros al comando
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@FechaPaga", fechaPaga);
                cmd.Parameters.AddWithValue("@MontoTotal", montoTotal);

                return con.ejecutarComando(cmd);
            }


        }

        public int modificar(int id, DateTime fechaPaga, float montoTotal)
        {
            string query = "UPDATE Pago SET FechaPaga = @fechaPaga, MontoTotal = @montoTotal WHERE ID = @id";

            // Crear y configurar el comando SQL
            using (OleDbCommand cmd = new OleDbCommand(query))
            {
                // Agregar parámetros al comando
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@fechaPaga", fechaPaga);
                cmd.Parameters.AddWithValue("@MontoTotal", montoTotal);

                return con.ejecutarComando(cmd);
            }

        }

        public int eliminar(int id)
        {
            string query = "DELETE from Pago WHERE ID = @ID";

            // Crear y configurar el comando SQL
            using (OleDbCommand cmd = new OleDbCommand(query))
            {
                // Agregar parámetros al comando
                cmd.Parameters.AddWithValue("@ID", id);

                return con.ejecutarComando(cmd);
            }

        }

        public OleDbDataReader listar()
        {
            return this.con.ejecutarSelect(new OleDbCommand("SELECT * FROM Pago"));
        }

    }
}
