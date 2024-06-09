using System.Data.OleDb;

namespace CapaDeDatos
{
    public class SocioPagoDatos
    {
        private Conexion conexion;

        public SocioPagoDatos()
        {
            conexion = new Conexion();
        }

        public OleDbDataReader listarRelaciones()
        {
            string query = "SELECT SocioDNI, PagoId FROM SocioPago";
            OleDbCommand command = new OleDbCommand(query);
            return conexion.ejecutarSelect(command);
        }

        public int agregarRelacion(int socDni, int idPago)
        {
            string query = "INSERT INTO SocioPago (SocioDNI, PagoId) VALUES (@socDni, @idPago)";

            // Crear y configurar el comando SQL
            using (OleDbCommand cmd = new OleDbCommand(query))
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
            using (OleDbCommand cmd = new OleDbCommand(query))
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
            using (OleDbCommand cmd = new OleDbCommand(query))
            {
                // Agregar parámetros al comando
                cmd.Parameters.AddWithValue("@idPago", idPago);

                return this.conexion.ejecutarComando(cmd);
            }
        }

    }


}
