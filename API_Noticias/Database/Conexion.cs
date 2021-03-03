using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace API_Noticias.Database
{

    public class Conexion
    {
        private static Conexion con = null;
        private SqlConnection Sqlcon;

    
        public Conexion(){
            Sqlcon = new SqlConnection("Data Source=DESKTOP-LLQIFUO;Initial Catalog=CrudApiNoticias;Integrated Security=True");
        }

        public SqlConnection GetConexion()
        {
            return Sqlcon;
        }

        public static Conexion SqlOpen()
        {
           
            if (con == null)
            {
                con = new Conexion();
            }
            Console.WriteLine("esta es la con "+ con+" exion");
            return con;
        }

     

        public void SqlClose(){
            con=null;
        }
    }
}
