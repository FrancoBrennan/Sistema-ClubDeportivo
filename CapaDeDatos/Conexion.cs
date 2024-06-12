/* using Microsoft.Data.Sqlite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLitePCL;
using System.IO;
using System.Data.OleDb;

namespace CapaDeDatos
{
    public class Conexion
    {
        private SqliteConnection conexion;
        public SqliteConnection establecerConexion()
        {
            // Cadena de conexión a la base de datos SQLite
            // string connectionString = "Data Source=C:\\Proyecto Club Deportivo\\TPClubDeportivo\\CapaDeDatos\\BD.db";
            string connectionString = "Data Source=C:\\Users\\Lvt\\Downloads\\electiva de programacion\\TP-ElectivaProgram\\CapaDeDatos\\BD.db";

            //File.Copy("C:\\Users\\Lvt\\Downloads\\electiva de programacion\\TP-ElectivaProgram\\\\CapaDeUsuario\\bin\\Debug\\e_sqlite3.dll", "C:\\Users\\Lvt\\AppData\\Local\\Temp\\Temporary ASP.NET Files\\vs\\46d55b2a\\ca5cfd68\\assembly\\dl3\\3d4b3a5d\\00652a31_7958da01\\e_sqlite3.dll");

            //Batteries.raw.SetProvider(new SQLitePCL.SQLite3Provider_e_sqlite3());

            //Batteries.Init();
            //Batteries_V2.Init();

            SQLitePCL.raw.SetProvider(new SQLitePCL.SQLite3Provider_e_sqlite3());
            SQLitePCL.raw.FreezeProvider();

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
} */

using System;
using System.Data.OleDb;

namespace CapaDeDatos
{
    public class Conexion
    {
        private OleDbConnection conexion;

        public OleDbConnection establecerConexion()
        {
            // https://download.cnet.com/microsoft-access-database-engine-2010-redistributable-64-bit/3001-10254_4-75452796.html?dt=internalDownload
            // string connectionString = "Data Source=C:\\Proyecto Club Deportivo\\TPClubDeportivo\\CapaDeDatos\\BD.db";
            // Cadena de conexión a la base de datos Access
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Proyecto Club Deportivo\\TPClubDeportivo\\CapaDeDatos\\BD.accdb";

            this.conexion = new OleDbConnection(connectionString);
            return conexion;
        }

        public int ejecutarComando(OleDbCommand comando) // Insert - Delete - Update
        {
            try
            {
                comando.Connection = establecerConexion();

                this.conexion.Open();

                int resultado = comando.ExecuteNonQuery(); // Devuelve el número de filas afectadas

                this.conexion.Close();

                return resultado;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }

        public OleDbDataReader ejecutarSelect(OleDbCommand comando)
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
