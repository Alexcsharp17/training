using CarStore.DAL.Entities;
using CarStore.DAL.Enums;
using CarStore.DAL.Interfaces;
using CarStore.DAL.Util;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace CarStore.DAL.Services
{
    public class OrderService : IOrderService
    {
        private SqlCommandBuild comandbuilder;
        public OrderService(SqlCommandBuild commandBuild)
        {
            this.comandbuilder = commandBuild;
        }

        public void AddOrder(Order order)
        {
            using SqlCommand command = comandbuilder.Create(StoredProceduresNames.sp_InsertOrder.ToString());
            SqlParameter orderDate = new SqlParameter
            {
                ParameterName = "@"+DBColumns.OrderDate,
                Value = order.OrderDate
            };
            command.Parameters.Add(orderDate);

            SqlParameter CarID = new SqlParameter
            {
                ParameterName = "@"+DBColumns.OrderDate,
                Value = order.CarID
            };
            command.Parameters.Add(CarID);

            SqlParameter PersonID = new SqlParameter
            {
                ParameterName = "@"+DBColumns.OrderDate,
                Value = order.PersonId
            };
            command.Parameters.Add(PersonID);
            command.ExecuteScalar();
        }
        public void DeleteOrder(int id)
        {
            using SqlCommand command = comandbuilder.Create(StoredProceduresNames.sp_DeleteOrder.ToString());
            SqlParameter idParam = new SqlParameter
            {
                ParameterName = "@"+DBColumns.id,
                Value = id
            };
            command.Parameters.Add(idParam);
            command.ExecuteScalar();
        }
        public Order GetOrder(int id)
        {
            using SqlCommand command = comandbuilder.Create(StoredProceduresNames.sp_GetOrder.ToString());
            SqlParameter idParam = new SqlParameter
            {
                ParameterName = "@"+DBColumns.id,
                Value = id
            };
            command.Parameters.Add(idParam);
            var reader = command.ExecuteReader();
            Order ord = new Order();
            while (reader.Read())
            {
                ord.OrderID = reader.GetInt32(0);
                ord.OrderDate = reader.GetDateTime(1);
                ord.CarID = reader.GetInt32(2);
                ord.PersonId = reader.GetInt32(3);
            }
            return ord;
        }

        public void UpdateOrder(Order order)
        {
            using SqlCommand command = comandbuilder.Create(StoredProceduresNames.sp_UpdateOrder.ToString());
            SqlParameter idParam = new SqlParameter
            {
                ParameterName = "@"+DBColumns.id,
                Value = order.OrderID
            };
            command.Parameters.Add(idParam);

            SqlParameter OrderDate = new SqlParameter
            {
                ParameterName = "@"+DBColumns.OrderDate,
                Value = order.OrderDate
            };
            command.Parameters.Add(OrderDate);

            SqlParameter CarID = new SqlParameter
            {
                ParameterName = "@"+DBColumns.CarID,
                Value = order.CarID
            };
            command.Parameters.Add(CarID);

            SqlParameter PersonID = new SqlParameter
            {
                ParameterName = "@"+DBColumns.PersonID,
                Value = order.PersonId
            };
            command.Parameters.Add(PersonID);
            command.ExecuteScalar();
        }
    }
}
