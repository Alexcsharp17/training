using CarStore.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CarStore.DAL.Enums;
using System.Text;
using CarStore.DAL.Interfaces;

namespace CarStore.DAL
{
    public class StoredProceduresService : IStoredProceduresService
    {
        public string DefaultConnection { get; set; }
       
        public  Order GetOrder(int id)
        {
            using (SqlConnection connection = new SqlConnection(DefaultConnection))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(StoredProceduresNames.sp_GetOrder.ToString(), connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = id
                };
                command.Parameters.Add(idParam);
                var reader = command.ExecuteReader();
                Order ord = new Order();
                while (reader.Read())
                {
                  ord.OrderID=  reader.GetInt32(0);
                    ord.OrderDate = reader.GetDateTime(1);
                    ord.CarID = reader.GetInt32(2);
                    ord.PersonId = reader.GetInt32(3);
                }
                             
                return ord;
            }
         }
        public  Person GetPerson(int id)
        {
            using (SqlConnection connection = new SqlConnection(DefaultConnection))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(StoredProceduresNames.sp_GetPerson.ToString(), connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = id
                };
                command.Parameters.Add(idParam);
                var reader = command.ExecuteReader();
                Person pers = new Person();
                while (reader.Read())
                {
                    pers.PersonID = reader.GetInt32(0);
                    pers.FirstName = reader.GetString(1);
                    pers.LastName = reader.GetString(2);
                    pers.Phone = reader.GetString(3);
                }

                return pers;
            }
            
        }
        public  void AddOrder(Order order)
        {
            using (SqlConnection connection = new SqlConnection(DefaultConnection))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(StoredProceduresNames.sp_InsertOrder.ToString(), connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter orderDate = new SqlParameter
                {
                    ParameterName = "@OrderDate",
                    Value = order.OrderDate
                };
                command.Parameters.Add(orderDate);

                SqlParameter CarID = new SqlParameter
                {
                    ParameterName = "@CarID",
                    Value = order.CarID
                };
                command.Parameters.Add(CarID);

                SqlParameter PersonID = new SqlParameter
                {
                    ParameterName = "@PersonID",
                    Value = order.PersonId
                };
                command.Parameters.Add(PersonID);
                command.ExecuteScalar();
                
            }
        }
        public  void AddPerson(Person person)
        {
            using (SqlConnection connection = new SqlConnection(DefaultConnection))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(StoredProceduresNames.sp_InsertPerson.ToString(), connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter FirstName = new SqlParameter
                {
                    ParameterName = "@FirstName",
                    Value = person.FirstName
                };
                command.Parameters.Add(FirstName);

                SqlParameter LastName = new SqlParameter
                {
                    ParameterName = "@LastName",
                    Value = person.LastName
                };
                command.Parameters.Add(LastName);

                SqlParameter Phone = new SqlParameter
                {
                    ParameterName = "@PersonID",
                    Value = person.Phone
                };
                command.Parameters.Add(Phone);
                command.ExecuteScalar();

            }
        }
        public  void DeletePerson(int id)
        {
            using (SqlConnection connection = new SqlConnection(DefaultConnection))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(StoredProceduresNames.sp_DeletePerson.ToString(), connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@id",
                    Value =id
                };
                command.Parameters.Add(idParam);              
                command.ExecuteScalar();
            }
        }
        public  void DeleteOrder(int id)
        {
            using (SqlConnection connection = new SqlConnection(DefaultConnection))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(StoredProceduresNames.sp_DeleteOrder.ToString(), connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = id
                };
                command.Parameters.Add(idParam);
                command.ExecuteScalar();
            }
        }

        public  void UpdateOrder(Order order)
        {
            using (SqlConnection connection = new SqlConnection(DefaultConnection))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(StoredProceduresNames.sp_UpdateOrder.ToString(), connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = order.OrderID
                };
                command.Parameters.Add(idParam);

                SqlParameter OrderDate = new SqlParameter
                {
                    ParameterName = "@OrderDate",
                    Value = order.OrderDate
                };
                command.Parameters.Add(OrderDate);

                SqlParameter CarID = new SqlParameter
                {
                    ParameterName = "@CarID",
                    Value = order.CarID
                };
                command.Parameters.Add(CarID);

                SqlParameter PersonID = new SqlParameter
                {
                    ParameterName = "@PersonID",
                    Value = order.PersonId
                };
                command.Parameters.Add(PersonID);
                command.ExecuteScalar();
            }
        }

        public  void UpdatePerson(Person person)
        {
            using (SqlConnection connection = new SqlConnection(DefaultConnection))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(StoredProceduresNames.sp_UpdatePerson.ToString(), connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = person.PersonID
                };
                command.Parameters.Add(idParam);

                SqlParameter FirstName = new SqlParameter
                {
                    ParameterName = "@OrderDate",
                    Value = person.FirstName
                };
                command.Parameters.Add(FirstName);

                SqlParameter LastName = new SqlParameter
                {
                    ParameterName = "@CarID",
                    Value = person.LastName
                };
                command.Parameters.Add(LastName);

                SqlParameter Phone = new SqlParameter
                {
                    ParameterName = "@Phone",
                    Value = person.Phone
                };
                command.Parameters.Add(Phone);
                command.ExecuteScalar();
            }
        }
    }
}
