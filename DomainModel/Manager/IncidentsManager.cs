using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Entity;
using DomainModel.Interface;
using System.Data.SqlClient;
using DomainModel.Infrastructure;

namespace DomainModel.Manager
{
    public class IncidentsManager : IRepository<Incidents, OperationDetails>
    {
        private SqlConnectionManager sqlConnectionManager = new SqlConnectionManager();
        public OperationDetails Create(Incidents item)
        {
            var connection = sqlConnectionManager.Connection();
            Incidents itemsIncidents = new Incidents();
            using (connection)
            {
                SqlDataAdapter da = new SqlDataAdapter();                
                SqlCommand command = new SqlCommand(
                  "INSERT INTO Incidents (idObject, incidentOpening, incidentClose, incidentNumberIteko, incidentNumberRT, description,timestamp) VALUES (@idObject,@incidentOpening,@incidentClose,@incidentNumberIteko,@incidentNumberRT,@description,@timestamp);",
                  connection);
                /*da.InsertCommand = command;
                da.InsertCommand.Parameters.Add("@idObject",item.idObject);*/
                command.Parameters.AddWithValue("@idObject", item.idObject);
                command.Parameters.AddWithValue("@incidentOpening", item.incidentOpening);
                if (item.IncidentClose == null)
                {
                    command.Parameters.AddWithValue("@incidentClose", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@incidentClose", item.IncidentClose);
                }
                if (item.incidentNumberIteko == null)
                {
                    command.Parameters.AddWithValue("@incidentNumberIteko", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@incidentNumberIteko", item.incidentNumberIteko);
                }
                command.Parameters.AddWithValue("@incidentNumberRT", item.incidentNumberRT);
                command.Parameters.AddWithValue("@description", item.description);
                command.Parameters.AddWithValue("@timestamp", Convert.ToDateTime(DateTime.Now.ToString()));
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

        public Incidents GetById(int id)
        {
            var connection = sqlConnectionManager.Connection();
            Incidents itemsIncidents = new Incidents();
            using (connection)
            {
                SqlCommand command = new SqlCommand(
                  "SELECT * FROM Incidents WHERE idIncident = "+ id +";",
                  connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        DateTime? dateClose;
                        if (reader[3] == DBNull.Value)
                        {
                            dateClose = null;
                        }
                        else
                        {
                            dateClose = reader.GetDateTime(3);
                        }
                        itemsIncidents = new Incidents
                        {
                            idIncident = reader.GetInt32(0),
                            idObject = reader.GetInt32(1),
                            incidentOpening = reader.GetDateTime(2),
                            IncidentClose = dateClose,
                            //incidentNumberIteko = reader.GetString(4),
                            incidentNumberIteko = reader[4].ToString(),
                            incidentNumberRT = reader.GetInt32(5),
                            description = reader.GetString(6),
                            timestamp = reader.GetDateTime(7)
                        };
                    }
                }
                reader.Close();
            }
            return itemsIncidents;
        }

        public IEnumerable<Incidents> Read()
        {
            var connection = sqlConnectionManager.Connection();
            List<Incidents> itemsIncidents = new List<Incidents>();
            using (connection)
            {
                SqlCommand command = new SqlCommand(
                  "SELECT * FROM Incidents;",
                  connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        DateTime? dateClose;
                        if (reader[3] == DBNull.Value)
                        {
                            dateClose = null;
                        }
                        else
                        {
                            dateClose = reader.GetDateTime(3);
                        }
                        itemsIncidents.Add(new Incidents
                        {
                            idIncident = reader.GetInt32(0),
                            idObject = reader.GetInt32(1),
                            incidentOpening = reader.GetDateTime(2),
                            IncidentClose = dateClose,
                            //incidentNumberIteko = reader.GetString(4),
                            incidentNumberIteko = reader[4].ToString(),
                            incidentNumberRT = reader.GetInt32(5),
                            description = reader.GetString(6),
                            timestamp = reader.GetDateTime(7)//Convert.ToDateTime(DateTime.Now.ToString())
                        });
                    }
                }
                reader.Close();
            }
            return itemsIncidents;
        }

        public OperationDetails Update(Incidents item)
        {
            var connection = sqlConnectionManager.Connection();
            Incidents itemsIncidents = new Incidents();
            using (connection)
            {
                SqlDataAdapter da = new SqlDataAdapter();
                /*SqlCommand command = new SqlCommand(
                  "UPDATE Incidents set incidentOpening = @incidentOpening, incidentClose = @incidentClose, incidentNumberIteko = @incidentNumberIteko, incidentNumberRT = @incidentNumberRT, description = @description where idObject = " + item.idObject +";",
                  connection);*/
                SqlCommand command = new SqlCommand(
                  "UPDATE Incidents set idObject = @idObject, incidentOpening = @incidentOpening, incidentClose = @incidentClose,incidentNumberIteko = @incidentNumberIteko, incidentNumberRT = @incidentNumberRT, description = @description where idIncident = " + item.idIncident + ";",
                  connection);
                /*da.InsertCommand = command;
                da.InsertCommand.Parameters.Add("@idObject",item.idObject);*/
                command.Parameters.AddWithValue("@idObject", item.idObject);
                command.Parameters.AddWithValue("@incidentOpening", item.incidentOpening);
                if (item.IncidentClose == null)
                {
                    command.Parameters.AddWithValue("@incidentClose", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@incidentClose", item.IncidentClose);
                }
                if (item.incidentNumberIteko == null)
                {
                    command.Parameters.AddWithValue("@incidentNumberIteko", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@incidentNumberIteko", item.incidentNumberIteko);
                }
                command.Parameters.AddWithValue("@incidentNumberRT", item.incidentNumberRT);
                command.Parameters.AddWithValue("@description", item.description);
                //command.Parameters.AddWithValue("@timestamp", Convert.ToDateTime(DateTime.Now.ToString()));
                connection.Open();
                try
                {
                    int i = command.ExecuteNonQuery();
                    return new OperationDetails { flag = true, msg = "Update completed!" };
                }
                catch (Exception e)
                {
                    return new OperationDetails { flag = false, msg = e.Message };
                }
            }
        }
    }
}
