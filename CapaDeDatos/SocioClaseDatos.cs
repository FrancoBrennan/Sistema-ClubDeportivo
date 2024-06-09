using System;
using System.Data.OleDb;

namespace CapaDeDatos
{
    public class SocioClaseDatos
    {
        private Conexion conexion;

        public SocioClaseDatos()
        {
            conexion = new Conexion();
        }

        public OleDbDataReader listarRelaciones()
        {
            string query = "SELECT SocioDNI,IDClase FROM SocioClase";
            OleDbCommand command = new OleDbCommand(query);
            return conexion.ejecutarSelect(command);
        }

        public int agregarRelacion(int socDni, int idClase)
        {
            string query = "INSERT INTO SocioClase (SocioDNI, IDClase) VALUES (@socDni, @idClase)";

            // Crear y configurar el comando SQL
            using (OleDbCommand cmd = new OleDbCommand(query))
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
            using (OleDbCommand cmd = new OleDbCommand(query))
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
            using (OleDbCommand cmd = new OleDbCommand(query))
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
            using (OleDbCommand cmd = new OleDbCommand(query))
            {
                // Agregar parámetros al comando
                cmd.Parameters.AddWithValue("@IdClase", idClase);

                return this.conexion.ejecutarComando(cmd);
            }
        }

    }


}
