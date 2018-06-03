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
    public class ICCManager : IRepository<ICC,OperationDetails>  // Manager<T, T1> where T : class where T1 : Infrastructure.OperationDetails
    {
        private SqlConnectionManager sqlConnectionManager = new SqlConnectionManager();
        public OperationDetails Create(ICC item)
        {
            throw new NotImplementedException();
        }

        public OperationDetails Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ICC GetById(int id)
        {
            var answer = sqlConnectionManager.ExecuteReaderSqlQuery("SELECT * FROM ICC WHERE idObject = '"+ id +"';");
            ICC itemICC;
            if(answer.Read())
            {
                itemICC = new ICC
                {
                    idObject = answer.GetInt16(0),
                    typeOfService = answer.GetString(1),
                    internetSpeed = answer.GetInt16(2),
                    lastMileType = answer.GetString(3),
                    postOffice = answer.GetString(4)
                };
            }
            else
            {
                itemICC = new ICC();
            }
            return itemICC;
        }

        public IEnumerable<ICC> Read()
        {
            //var answer = sqlConnectionManager.ExecuteReaderSqlQuery("SELECT * FROM ICC;");
            var connection = sqlConnectionManager.Connection();
            List<ICC> itemsICC = new List<ICC>();
            using (connection)
            {
                SqlCommand command = new SqlCommand(
                  "SELECT * FROM ICC;",
                  connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {                    
                    while (reader.Read())
                    {
                        itemsICC.Add(new ICC
                        {
                            idObject = reader.GetInt32(0),
                            typeOfService = reader.GetString(1),
                            internetSpeed = reader.GetInt32(2),
                            lastMileType = reader.GetString(3),
                            postOffice = reader.GetString(4)
                        });
                    }
                }
                else
                {
                    return null;
                }
                reader.Close();
            }                        
            return itemsICC;
        }

        public OperationDetails Update(ICC item)
        {
            throw new NotImplementedException();
        }
    }
}
