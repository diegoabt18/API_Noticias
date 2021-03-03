using API_Noticias.DAOModel;
using API_Noticias.Database;
using API_Noticias.Models;
using Newtonsoft.Json;
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
        readonly string UPDATE= "UPDATE news SET author=@val1, title=@val2, description=@val3, url=@val4, urlToImage=@val5, publishedAt=@val6, content=@val7 WHERE id=@val8;";
        readonly string DELETED= "DELETE FROM news WHERE id=@val1;";
        readonly string FINDALL= "SELECT * FROM news;";
        readonly string FIND= "SELECT * FROM news WHERE id=@val1;";

        private Conexion con;
        private SqlCommand comando;

        public ImplementSqlDAO()
        {
            con = Conexion.SqlOpen();
            
            Console.WriteLine("esto es una linea " + con);
        }

        public void deleted(news t)
        {
            try
            {
                comando = new SqlCommand(DELETED, con.GetConexion());
                comando.Parameters.AddWithValue("@val1", t.id);
                comando.Prepare();
                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("error en sql", e);
            }
            finally
            {
                con.SqlClose();
            }
        }

        public void edit(news t)
        {

            try
            {
                comando = new SqlCommand(UPDATE, con.GetConexion());
                comando.Parameters.AddWithValue("@val1", t.author);
                comando.Parameters.AddWithValue("@val2", t.title);
                comando.Parameters.AddWithValue("@val3", t.description);
                comando.Parameters.AddWithValue("@val4", t.url);
                comando.Parameters.AddWithValue("@val5", t.urlToImage);
                comando.Parameters.AddWithValue("@val6", t.publishedAt);
                comando.Parameters.AddWithValue("@val7", t.content);
                comando.Parameters.AddWithValue("@val8", t.id);
                comando.Prepare();
                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("error en sql", e);
            }
            finally
            {
                con.SqlClose();
            }
        }

        public news find(long id)
        {
            try
            {
                comando = new SqlCommand(FIND, con.GetConexion());
                comando.Parameters.AddWithValue("@val1", id);
                comando.Prepare();
                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("error en sql", e);
            }
            finally
            {
                con.SqlClose();
            }

            return null;
        }

        public List<news> findAll()
        {
            List<news> listNews = new List<news>();
            try
            {
                comando = new SqlCommand(FINDALL, con.GetConexion());
                Console.WriteLine(con.GetConexion() + "conexion sql");
                con.GetConexion().Open();
                comando.Prepare();
                SqlDataReader reader= comando.ExecuteReader();
                

               
                while (reader.Read())
                {

                    news n = new news();
                    n.id = Convert.ToInt32(reader[0]);
                    n.author = reader[1].ToString();
                    n.title = reader[2].ToString();
                    n.description = reader[3].ToString();
                    n.url = reader[4].ToString();
                    n.urlToImage = reader[5].ToString();
                    n.publishedAt = reader[6].ToString();
                    n.content = reader[7].ToString();
                    listNews.Add(n);
                }

            }
            catch (Exception e)
            {
                throw new Exception("error en sql", e);
            }
            finally
            {
                con.GetConexion().Close();
                con.SqlClose();
                
                
            }

            return listNews;
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
