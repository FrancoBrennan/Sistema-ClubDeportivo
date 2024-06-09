using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data.OleDb;

namespace CapaDeDatos
{
    public class ActividadClaseDatos
    {
        private Conexion conexion;

        public ActividadClaseDatos()
        {
            conexion = new Conexion();
        }

        public OleDbDataReader listarRelaciones()
        {
            string query = "SELECT IDClase, IDActividad FROM ActividadClase";
            OleDbCommand command = new OleDbCommand(query);
            return conexion.ejecutarSelect(command);
        }

        
        public int removerRelacion(int idClase, int idAct)
        {
            string query = "DELETE FROM ActividadClase WHERE IDClase = (@IdClase) AND IDActividad = (@IdAct)";

            // Crear y configurar el comando SQL
            using (OleDbCommand cmd = new OleDbCommand(query))
            {
                // Agregar parámetros al comando
                cmd.Parameters.AddWithValue("@IdClase", idClase);
                cmd.Parameters.AddWithValue("@IdAct", idAct);

                return this.conexion.ejecutarComando(cmd);
            }

        }

        public int agregarRelacion(int idAct, int idClase)
        {
            string query = "INSERT INTO ActividadClase (IDClase, IDActividad) VALUES (@IDClase, @IdActividad)";

            // Crear y configurar el comando SQL
            using (OleDbCommand cmd = new OleDbCommand(query))
            {
                // Agregar parámetros al comando
                cmd.Parameters.AddWithValue("@IDClase", idClase);
                cmd.Parameters.AddWithValue("@IdActividad", idAct);

                return this.conexion.ejecutarComando(cmd);
            }
        }

        // REMOVER con unicamente idAct
        public int removerRelacionIdAct(int idAct)
        {
            string query = "DELETE FROM ActividadClase WHERE IDActividad = @IDAct";

            // Crear y configurar el comando SQL
            using (OleDbCommand cmd = new OleDbCommand(query))
            {
                // Agregar parámetros al comando
                cmd.Parameters.AddWithValue("@IDAct", idAct);

                return this.conexion.ejecutarComando(cmd);
            }
        }

        // REMOVER con unicamente idCom
        public int removerRelacionIdCom(int idClase)
        {
            string query = "DELETE FROM ActividadClase WHERE IDClase = @IDClase";

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
