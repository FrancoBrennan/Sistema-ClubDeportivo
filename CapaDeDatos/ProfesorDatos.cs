using System;
using System.Data.OleDb;

namespace CapaDeDatos
{
    public class ProfesorDatos
    {
        private Conexion con;

        public ProfesorDatos()
        {
            this.con = new Conexion();
        }

        public int agregar(int dni, string nom, DateTime fechaNac, int legajo)
        {
            string query = "INSERT INTO Profesor (DNI, Nombre, FechaNacimiento, Legajo) VALUES (@dni, @nombre, @fechaNac, @legajo)";

            // Crear y configurar el comando SQL
            using (OleDbCommand cmd = new OleDbCommand(query))
            {
                // Agregar parámetros al comando
                cmd.Parameters.AddWithValue("@dni", dni);
                cmd.Parameters.AddWithValue("@nombre", nom);
                cmd.Parameters.AddWithValue("@fechaNac", fechaNac);
                cmd.Parameters.AddWithValue("@legajo", legajo);

                return con.ejecutarComando(cmd);
            }


        }

        public int modificar(int dni, string nom, DateTime fechaNac, int legajo)
        {
            string query = "UPDATE Profesor SET Nombre = @nombre, FechaNacimiento = @fechaNac WHERE DNI = @dni";

            // Crear y configurar el comando SQL
            using (OleDbCommand cmd = new OleDbCommand(query))
            {
                // Agregar parámetros al comando
                cmd.Parameters.AddWithValue("@dni", dni);
                cmd.Parameters.AddWithValue("@nombre", nom);
                cmd.Parameters.AddWithValue("@fechaNac", fechaNac);

                return con.ejecutarComando(cmd);
            }

        }

        public int eliminar(int dni)
        {
            string query = "DELETE from Profesor WHERE DNI = @dni";

            // Crear y configurar el comando SQL
            using (OleDbCommand cmd = new OleDbCommand(query))
            {
                // Agregar parámetros al comando
                cmd.Parameters.AddWithValue("@dni", dni);

                return con.ejecutarComando(cmd);
            }

        }

        public OleDbDataReader listarProfesores()
        {
            return this.con.ejecutarSelect(new OleDbCommand("SELECT * FROM Profesor"));
        }

        

    }
}
