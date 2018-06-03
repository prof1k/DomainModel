using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;

namespace DomainModel.Manager
{
    class SqlConnectionManager
    {
        Constants constants = new Constants();
        public SqlConnection Connection()
        {
            return new SqlConnection(constants.getConnection());
        }
        public SqlDataReader ExecuteReaderSqlQuery(string sqlQuery)
        {
            var connection = Connection();
            using (connection)
            {
                SqlCommand command = new SqlCommand(
                  sqlQuery,
                  connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    return reader;
                    /*while (reader.Read())
                    {
                        Console.WriteLine("{0}\t{1}", reader.GetInt32(0),
                            reader.GetString(1));
                    }*/
                }
                else
                {
                    return null;
                    //Console.WriteLine("No rows found.");
                }
                //reader.Close();
            }
        }
    }
}
