using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class SocioClubDatos
    {
        private Conexion con;

        public SocioClubDatos()
        {
            this.con = new Conexion();
        }

        public int agregar(int dni, string nom, DateTime fechaNac, float CuotaSocial, string Email, string Direccion)
        {
            string query = "INSERT INTO SocioClub (DNI, Nombre, FechaNacimiento, CuotaSocial, Email, Direccion) VALUES (@dni, @nombre, @fechaNac, @CuotaSocial, @Email, @Direccion)";

            // Crear y configurar el comando SQL
            using (SqliteCommand cmd = new SqliteCommand(query))
            {
                // Agregar parámetros al comando
                cmd.Parameters.AddWithValue("@dni", dni);
                cmd.Parameters.AddWithValue("@nombre", nom);
                cmd.Parameters.AddWithValue("@fechaNac", fechaNac);
                cmd.Parameters.AddWithValue("@CuotaSocial", CuotaSocial);
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@Direccion", Direccion);

                return con.ejecutarComando(cmd);
            }


        }

        public int modificar(int dni, string nom, DateTime fechaNac, float CuotaSocial, string Email, string Direccion)
        {
            string query = "UPDATE SocioClub SET Nombre = @nombre, FechaNacimiento = @fechaNac, CuotaSocial = @CuotaSocial, Email = @Email, Direccion = @Direccion  WHERE DNI = @dni";

            // Crear y configurar el comando SQL
            using (SqliteCommand cmd = new SqliteCommand(query))
            {
                // Agregar parámetros al comando
                cmd.Parameters.AddWithValue("@dni", dni);
                cmd.Parameters.AddWithValue("@nombre", nom);
                cmd.Parameters.AddWithValue("@fechaNac", fechaNac);
                cmd.Parameters.AddWithValue("@CuotaSocial", CuotaSocial);
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@Direccion", Direccion);

                return con.ejecutarComando(cmd);
            }

        }

        public int eliminar(int dni)
        {
            string query = "DELETE from SocioClub WHERE DNI = @dni";

            // Crear y configurar el comando SQL
            using (SqliteCommand cmd = new SqliteCommand(query))
            {
                // Agregar parámetros al comando
                cmd.Parameters.AddWithValue("@dni", dni);

                return con.ejecutarComando(cmd);
            }

        }

        public SqliteDataReader listar()
        {
            return this.con.ejecutarSelect(new SqliteCommand("SELECT * FROM SocioClub"));
        }

    }
}
