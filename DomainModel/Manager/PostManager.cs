using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Entity;
using DomainModel.Interface;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Globalization;
using DomainModel.Infrastructure;

namespace DomainModel.Manager
{
    public class PostManager : IRepository<Post,OperationDetails>  // Manager<T, T1> where T : class where T1 : Infrastructure.OperationDetails
    {
        private SqlConnectionManager sqlConnectionManager = new SqlConnectionManager();
        public OperationDetails Create(Post item)
        {
            var connection = sqlConnectionManager.Connection();
            Post itemsPost = new Post();
            using (connection)
            {
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand command = new SqlCommand(
                  "INSERT INTO Post (post) VALUES (@post);",
                  connection);
                /*da.InsertCommand = command;
                da.InsertCommand.Parameters.Add("@idObject",item.idObject);*/
                command.Parameters.AddWithValue("@post", item.post);
                connection.Open();
                try
                {
                    int i = command.ExecuteNonQuery();
                    return new OperationDetails { flag = true, msg = "Insert completed!" };
                }
                catch (Exception e)
                {
                    return new OperationDetails { flag = false, msg = e.Message };
                }
            }
        }

        public OperationDetails Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Post GetById(string id)
        {
            var answer = sqlConnectionManager.ExecuteReaderSqlQuery("SELECT * FROM Post WHERE Post = '"+ id +"';");
            Post itemPost = new Post();
            if (answer != null)
            {
                if (answer.Read())
                {
                    itemPost = new Post
                    {
                        post = answer.GetString(0)
                    };
                }
                else
                {
                    itemPost = new Post();
                }
            }
            return itemPost;
        }

        public IEnumerable<Post> Read()
        {
            //var answer = sqlConnectionManager.ExecuteReaderSqlQuery("SELECT * FROM ICC;");
            var connection = sqlConnectionManager.Connection();
            List<Post> itemsPost = new List<Post>();
            using (connection)
            {
                SqlCommand command = new SqlCommand(
                  "SELECT * FROM Post;",
                  connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {                    
                    while (reader.Read())
                    {
                        itemsPost.Add(new Post
                        {
                            post = reader.GetString(0)
                        });
                    }
                }
                else
                {
                    return null;
                }
                reader.Close();
            }                        
            return itemsPost;
        }

        public OperationDetails Update(Post item)
        {
            throw new NotImplementedException();
        }
    }
}
