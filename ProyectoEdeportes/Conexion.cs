using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ProyectoEdeportes
{
    public class Conexion
    {
        public MySqlConnection databaseConnection { get; set; }
        public Conexion()
        {
            
            const string ConnectionString = "server = localhost; port= 3306; username = root; password =1234; database = esports_team";
            databaseConnection = new MySqlConnection(ConnectionString);
        }
        public bool ProbarConexion() // Metodo para verificar la conexion de la base de datos
        {
            try
            {
                databaseConnection.Open(); // Establecer conexion
                databaseConnection.Close(); // Cerrar la conexion
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void ConectarConBaseDeDatos() //Metodo para establecer la conexion 
        {
            databaseConnection.Open();
        }
        public void DesconectarBaseDeDatos()
        {
            databaseConnection.Close();
        }

    }
}
