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
    public class PostOfficeManager : IRepository<PostOffice, OperationDetails>  // Manager<T, T1> where T : class where T1 : Infrastructure.OperationDetails
    {
        private SqlConnectionManager sqlConnectionManager = new SqlConnectionManager();
        public OperationDetails Create(PostOffice item)
        {
            throw new NotImplementedException();
        }

        public OperationDetails Delete(int id)
        {
            throw new NotImplementedException();
        }

              public PostOffice GetById(string id)
              {
                  var answer = sqlConnectionManager.ExecuteReaderSqlQuery("SELECT * FROM PostOffice WHERE postOffice = '" + id + "';");
                  PostOffice itemPostOffice;
                  if (answer.Read())
                  {
                      itemPostOffice = new PostOffice
                      {
                          postOffice = answer.GetString(0),
                          postalCode = Convert.ToUInt16(answer.GetInt32(1)),
                          post = answer.GetString(2),

                      };
                  }
                  else
                  {
                      itemPostOffice = new PostOffice();
                  }
                  return itemPostOffice;
              }
   
        public IEnumerable<PostOffice> Read()
        {
            //var answer = sqlConnectionManager.ExecuteReaderSqlQuery("SELECT * FROM ICC;");
            var connection = sqlConnectionManager.Connection();
            List<PostOffice> itemsPostOffice = new List<PostOffice>();
            using (connection)
            {
                SqlCommand command = new SqlCommand(
                  "SELECT * FROM PostOffice;",
                  connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        itemsPostOffice.Add(new PostOffice
                        {
                            postOffice = reader.GetString(0),
                            postalCode = Convert.ToInt32(reader.GetInt32(1)),
                            post = reader.GetString(2),
                            
                        });
                    }
                }
                else
                {
                    return null;
                }
                reader.Close();
            }
            return itemsPostOffice;
        }

        public OperationDetails Update(PostOffice item)
        {
            throw new NotImplementedException();
        }
    }
}
