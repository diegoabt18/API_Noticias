using API_Noticias.DAOModel;
using API_Noticias.Database;
using API_Noticias.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace API_Noticias.Data
{


    public class ImplementSqlDAO : NewsDAO
    {
        readonly string INSERT= "INSERT INTO news(id, author, title, description, url, urlToImage, publishedAt, content) VALUES (@val1, @val2, @val3, @val4, @val5, @val6, @val7, @val8);";
        readonly string UPDATE="UPDATE clientes SET clie_nombre=?, clie_apellido=?, clie_direccion=?, clie_fechanacimiento=?, clie_telefono=? WHERE clie_id=?;";
        readonly string DELETE="DELETE FROM clientes WHERE clie_id=?;";
        readonly string FINDALL="SELECT clie_id, clie_nombre, clie_apellido, clie_direccion, clie_fechanacimiento, clie_telefono FROM clientes;";
        readonly string FIND="SELECT clie_id, clie_nombre, clie_apellido, clie_direccion, clie_fechanacimiento, clie_telefono FROM clientes WHERE clie_id=?;";

        private Conexion con;
        private SqlCommand comando;

        public ImplementSqlDAO()
        {
            con = Conexion.SqlOpen();

        }

        public void deleted(news t)
        {
            throw new NotImplementedException();
        }

        public void edit(news t)
        {
            throw new NotImplementedException();
        }

        public news find(long id)
        {
            throw new NotImplementedException();
        }

        public List<news> findAll()
        {
            throw new NotImplementedException();
        }

        public void insert(news t)
        {

            try
            {
                comando = new SqlCommand(INSERT, con.GetConexion());
                comando.Parameters.AddWithValue("@val1", t.id);
                comando.Parameters.AddWithValue("@val2", t.author);
                comando.Parameters.AddWithValue("@val3", t.title);
                comando.Parameters.AddWithValue("@val4", t.description);
                comando.Parameters.AddWithValue("@val5", t.url);
                comando.Parameters.AddWithValue("@val6", t.urlToImage);
                comando.Parameters.AddWithValue("@val7", t.publishedAt);
                comando.Parameters.AddWithValue("@val8", t.content);
                comando.Prepare();
                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("error en sql",e);
            }
            finally
            {
                con.SqlClose();
            }

        }
    }

}
