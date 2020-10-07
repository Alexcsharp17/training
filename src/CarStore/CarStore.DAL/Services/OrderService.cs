using CarStore.DAL.Entities;
using CarStore.DAL.Enums;
using CarStore.DAL.Interfaces;
using CarStore.DAL.Util;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace CarStore.DAL.Services
{
    public class OrderService : IOrderService
    {
        private ICommandBuilder comandbuilder;
        public OrderService(ICommandBuilder commandBuild)
        {
            this.comandbuilder = commandBuild;
        }

        public void AddOrder(Order order)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {DBColumns.PERSON_ID, order.PersonId },
                {DBColumns.ORDER_DATE, order.OrderDate },
                {DBColumns.CAR_ID, order.CarID }
            };

            if (order.OrderID == 0)
            {
                comandbuilder.DbDataPostCommand(StoredProceduresNames.sp_InsertOrder.ToString(), parameters);
            }
            else
            {
                parameters.Add(DBColumns.ID, order.OrderID);
                comandbuilder.DbDataPostCommand(StoredProceduresNames.sp_UpdateOrder.ToString(), parameters);
            }
        }
        public void DeleteOrder(int id)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>() { { DBColumns.ID, id } };
            comandbuilder.DbDataPostCommand(StoredProceduresNames.sp_DeleteOrder.ToString(), parameters);
        }
        public Order GetOrder(int id)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>() { { DBColumns.ID, id } };

            using (var reader = comandbuilder.DbDataRequestCommand(StoredProceduresNames.sp_GetOrder.ToString(), parameters))
            {
                Order ord = new Order();

                if (reader.Read())
                {
                    ord.OrderID = reader.GetInt32(0);
                    ord.OrderDate = reader.GetDateTime(1);
                    ord.CarID = reader.GetInt32(2);
                    ord.PersonId = reader.GetInt32(3);
                }
                return ord;
            }

        }

        public void UpdateOrder(Order order)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {DBColumns.PERSON_ID, order.PersonId },
                {DBColumns.ORDER_DATE, order.OrderDate },
                {DBColumns.CAR_ID, order.CarID }
            };

            if (order.OrderID == 0)
            {
                comandbuilder.DbDataPostCommand(StoredProceduresNames.sp_InsertOrder.ToString(), parameters);
            }
            else
            {
                comandbuilder.DbDataPostCommand(StoredProceduresNames.sp_UpdateOrder.ToString(), parameters);
            }
        }

        public List<Order> GetOrders(int page, int pageSize, string sort)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {DBColumns.PAGE,page },
                {DBColumns.PAGE_SIZE,pageSize},
                {DBColumns.SORT_COLUMN,sort}

            };
            List<Order> orders = new List<Order>();
            using var reader = comandbuilder.DbDataRequestCommand(StoredProceduresNames.sp_GetOrders.ToString(), parameters);

            while (reader.Read())
            {
                Order ord = new Order
                {
                    OrderID = reader.GetInt32(0),
                    OrderDate = reader.GetDateTime(1),
                    CarID = reader.GetInt32(2),
                    PersonId = reader.GetInt32(3)
                };
                orders.Add(ord);
            }
            return orders;
        }

        public int GetOrdersCount()
        {
            return comandbuilder.DbDataPostCommand(StoredProceduresNames.sp_GetOrdersCount.ToString());
        }

    }
}
