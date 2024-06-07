using Microsoft.Data.Sqlite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLitePCL;

namespace CapaDeDatos
{
    public class Conexion
    {
        private SqliteConnection conexion;
        public SqliteConnection establecerConexion()
        {
            // Cadena de conexión a la base de datos SQLite
            string connectionString = "Data Source=C:\\Proyecto Club Deportivo\\TPClubDeportivo\\CapaDeDatos\\BD.db";

            //Batteries.raw.SetProvider(new SQLitePCL.SQLite3Provider_e_sqlite3());

            //Batteries.Init();
            Batteries_V2.Init();

            this.conexion = new SqliteConnection(connectionString);
            // Crear la conexión
            return conexion;
        }

        public int ejecutarComando(SqliteCommand comando) //Insert - Delete -Update
        {
            try
            {
                comando.Connection = establecerConexion();

                this.conexion.Open();

                int resultado = Convert.ToInt32(comando.ExecuteScalar()); //Si sale bien devuelve 1 y devuelve 0 si sale mal

                this.conexion.Close();

                return resultado;
                
            }
            catch (Exception ex) 
            {
                return 0;
            }
        }


        public SqliteDataReader ejecutarSelect(SqliteCommand comando)
        {
            try
            {
                comando.Connection = establecerConexion();

                this.conexion.Open();

                return comando.ExecuteReader();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine(ex.Message);
                return null;
            }
        }



    }
}
