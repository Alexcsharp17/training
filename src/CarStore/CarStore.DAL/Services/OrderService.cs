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
            Dictionary<string, object> d = new Dictionary<string, object>();
            foreach(var prop in order.GetType().GetProperties())
            {
                d.Add(prop.Name.ToString(), prop.GetValue(order));
            }
            using SqlCommand command = comandbuilder.Create(StoredProceduresNames.sp_InsertOrder.ToString(),d);
           
            command.ExecuteScalar();
        }
        public void DeleteOrder(int id)
        {
            Dictionary<string, object> d = new Dictionary<string, object>(){ { "id", id } };

            using SqlCommand command = comandbuilder.Create(StoredProceduresNames.sp_DeleteOrder.ToString(),d);

            command.ExecuteScalar();
        }
        public Order GetOrder(int id)
        {
            Dictionary<string, object> d = new Dictionary<string, object>() { { "id", id } };

            using SqlCommand command = comandbuilder.Create(StoredProceduresNames.sp_GetOrder.ToString(),d);
            var reader = command.ExecuteReader();
            Order ord = new Order();
            while(reader.Read())
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
            Dictionary<string, object> d = new Dictionary<string, object>();
            foreach(var prop in order.GetType().GetProperties())
            {
                d.Add(prop.Name.ToString(), prop.GetValue(order));
            }

            using SqlCommand command = comandbuilder.Create(StoredProceduresNames.sp_UpdateOrder.ToString(),d);
            
            command.ExecuteScalar();
        }
    }
}
