using System;
using System.Data.OleDb;

namespace CapaDeDatos
{
    public class ClaseDatos
    {
        private Conexion con;

        public ClaseDatos()
        {
            this.con = new Conexion();
        }

        public int agregar(int ID, string dia, int hora, int cupoMax)
        {
            string query = "INSERT INTO Clase (ID, Dia, Hora, CupoMaximo) VALUES (@ID, @Dia, @Hora, @CupoMaximo)";

            // Crear y configurar el comando SQL
            using (OleDbCommand cmd = new OleDbCommand(query))
            {
                // Agregar parámetros al comando
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.Parameters.AddWithValue("@Dia", dia);
                cmd.Parameters.AddWithValue("@Hora", hora);
                cmd.Parameters.AddWithValue("@CupoMaximo", cupoMax);

                return con.ejecutarComando(cmd);
            }


        }

        public int modificar(int ID, string dia, int hora, int cupoMax)
        {
            string query = "UPDATE Clase SET Dia = @Dia, Hora = @Hora, CupoMax = @CupoMax WHERE ID = @ID";

            // Crear y configurar el comando SQL
            using (OleDbCommand cmd = new OleDbCommand(query))
            {
                // Agregar parámetros al comando
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.Parameters.AddWithValue("@Dia", dia);
                cmd.Parameters.AddWithValue("@Hora", hora);
                cmd.Parameters.AddWithValue("@CupoMaximo", cupoMax);

                return con.ejecutarComando(cmd);
            }

        }

        public int eliminar(int id)
        {
            string query = "DELETE from Clase WHERE ID = @ID";

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
            return this.con.ejecutarSelect(new OleDbCommand("SELECT * FROM Clase"));
        }

    }
}
