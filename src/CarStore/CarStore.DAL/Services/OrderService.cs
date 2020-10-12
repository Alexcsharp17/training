using CarStore.DAL.Entities;
using CarStore.DAL.Enums;
using CarStore.DAL.Interfaces;
using CarStore.DAL.Util;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace CarStore.DAL.Services
{
    public class OrderService : IOrderService
    {
        private ICommandBuilder comandbuilder;
        private IServiceScopeFactory scopeFactory;
        public OrderService(IServiceScopeFactory scopeFactory)
        {
            this.scopeFactory = scopeFactory;
        }

        public void AddOrder(Order order)
        {
            using (var scope = scopeFactory.CreateScope())
            {
                var comandbuilder = scope.ServiceProvider.GetService<ICommandBuilder>();

                Dictionary<string, object> parameters = new Dictionary<string, object>()
                {
                    {DBColumns.PERSON_ID, order.PersonId },
                    {DBColumns.ORDER_DATE, order.OrderDate },
                    {DBColumns.CAR_ID, order.CarID }
                };

                if (order.OrderID == 0)
                {
                    comandbuilder.DbDataScalarCommand(StoredProceduresNames.sp_InsertOrder.ToString(), parameters);
                }
                else
                {
                    parameters.Add(DBColumns.ID, order.OrderID);
                    comandbuilder.DbDataScalarCommand(StoredProceduresNames.sp_UpdateOrder.ToString(), parameters);
                }
            }
           
        }
        public void DeleteOrder(int id)
        {
            using (var scope = scopeFactory.CreateScope())
            {
                var comandbuilder = scope.ServiceProvider.GetService<ICommandBuilder>();


                Dictionary<string, object> parameters = new Dictionary<string, object>() { { DBColumns.ID, id } };
                comandbuilder.DbDataScalarCommand(StoredProceduresNames.sp_DeleteOrder.ToString(), parameters);
            }

        }
        public Order GetOrder(int id)
        {
            using (var scope = scopeFactory.CreateScope())
            {
                var comandbuilder = scope.ServiceProvider.GetService<ICommandBuilder>();
                Dictionary<string, object> parameters = new Dictionary<string, object>() { { DBColumns.ID, id } };

                using (var dataTable = comandbuilder.DbDataReaderCommand(StoredProceduresNames.sp_GetOrder.ToString(), parameters))
                {
                    Order ord = new Order();

                    if (dataTable.Rows.Count == 1)
                    {
                        ord.OrderID =Convert.ToInt32(dataTable.Rows[0][DBColumns.ORDER_ID.Replace("@","")]);
                        ord.OrderDate = Convert.ToDateTime(dataTable.Rows[0][DBColumns.ORDER_DATE.Replace("@"," ")]);
                        ord.CarID = Convert.ToInt32(dataTable.Rows[0][DBColumns.CAR_ID.Replace("@","")]);
                        ord.PersonId = Convert.ToInt32(dataTable.Rows[0][DBColumns.PERSON_ID.Replace("@","")]);
                    }

                    return ord;
                }
            }

           

        }

        public void UpdateOrder(Order order)
        {
            using (var scope = scopeFactory.CreateScope())
            {
                var comandbuilder = scope.ServiceProvider.GetService<ICommandBuilder>();
                Dictionary<string, object> parameters = new Dictionary<string, object>()
                {
                    {DBColumns.PERSON_ID, order.PersonId },
                    {DBColumns.ORDER_DATE, order.OrderDate },
                    {DBColumns.CAR_ID, order.CarID }
                };

                if (order.OrderID == 0)
                {
                    comandbuilder.DbDataScalarCommand(StoredProceduresNames.sp_InsertOrder.ToString(), parameters);
                }
                else
                {
                    comandbuilder.DbDataScalarCommand(StoredProceduresNames.sp_UpdateOrder.ToString(), parameters);
                }
            }
           
        }

        public List<Order> GetOrders(int page, int pageSize, string sort)
        {
            using (var scope = scopeFactory.CreateScope())
            {
                var comandbuilder = scope.ServiceProvider.GetService<ICommandBuilder>();
                Dictionary<string, object> parameters = new Dictionary<string, object>()
                {
                    {DBColumns.PAGE,page },
                    {DBColumns.PAGE_SIZE,pageSize},
                    {DBColumns.SORT_COLUMN,sort}

                };
                List<Order> orders = new List<Order>();
                using var dataTable = comandbuilder.DbDataReaderCommand(StoredProceduresNames.sp_GetOrders.ToString(), parameters);

                foreach (var dataRow in dataTable.Rows)
                {
                    Order ord = new Order()
                    {
                        OrderID = Convert.ToInt32(dataTable.Rows[0][DBColumns.ORDER_ID.Replace("@", "")]),
                        OrderDate = Convert.ToDateTime(dataTable.Rows[0][DBColumns.ORDER_DATE.Replace("@", " ")]),
                        CarID = Convert.ToInt32(dataTable.Rows[0][DBColumns.CAR_ID.Replace("@", "")]),
                        PersonId = Convert.ToInt32(dataTable.Rows[0][DBColumns.PERSON_ID.Replace("@", "")])
                     };
                   orders.Add(ord);
                }

                return orders;
            }
            
        }

        public int GetOrdersCount()
        {
            using (var scope = scopeFactory.CreateScope())
            {
                var comandbuilder = scope.ServiceProvider.GetService<ICommandBuilder>();
                return comandbuilder.DbDataScalarCommand(StoredProceduresNames.sp_GetOrdersCount.ToString());
            }
        }

    }
}
