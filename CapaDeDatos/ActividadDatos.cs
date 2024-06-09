using System;
using System.Data.OleDb;
namespace CapaDeDatos
{
    public class ActividadDatos
    {
        private Conexion con;

        public ActividadDatos()
        {
            this.con = new Conexion();
        }

        public int agregar(int ID, string nombre, float precio)
        {
            string query = "INSERT INTO Actividad (ID, Nombre, Precio) VALUES (@ID, @Nombre, @Precio)";

            // Crear y configurar el comando SQL
            using (OleDbCommand cmd = new OleDbCommand(query))
            {
                // Agregar parámetros al comando
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@Precio", precio);

                return con.ejecutarComando(cmd);
            }


        }

        public int modificar(int ID, string nombre, float precio)
        {
            string query = "UPDATE Actividad SET Nombre = @Nombre, Precio = @Precio WHERE ID = @ID";

            // Crear y configurar el comando SQL
            using (OleDbCommand cmd = new OleDbCommand(query))
            {
                // Agregar parámetros al comando
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@Precio", precio);

                return con.ejecutarComando(cmd);
            }

        }

        public int eliminar(int id)
        {
            string query = "DELETE from Actividad WHERE ID = @ID";

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
            return this.con.ejecutarSelect(new OleDbCommand("SELECT * FROM Actividad"));
        }

        public OleDbDataReader enlazar(int id)
        {
            string query = "SELECT IDActividad FROM ActividadClase WHERE IDClase = @ID";

            // Crear y configurar el comando SQL
            using (OleDbCommand cmd = new OleDbCommand(query))
            {
                // Agregar parámetros al comando
                cmd.Parameters.AddWithValue("@ID", id);

                return this.con.ejecutarSelect(cmd);
            }

            
        }

    }
}
