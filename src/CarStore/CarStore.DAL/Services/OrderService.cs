using CarStore.DAL.Entities;
using CarStore.DAL.Enums;
using CarStore.DAL.Interfaces;
using CarStore.DAL.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace CarStore.DAL.Services
{
    public class OrderService : IOrderService
    {
        private ICommandBuilder comandbuilder;
        public OrderService(ICommandBuilder comandbuilder)
        {
            this.comandbuilder = comandbuilder;
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
                    comandbuilder.DbDataScalarCommand(StoredProceduresNames.sp_InsertOrder.ToString(), parameters);
                }
                else
                {
                    parameters.Add(DBColumns.ID, order.OrderID);
                    comandbuilder.DbDataScalarCommand(StoredProceduresNames.sp_UpdateOrder.ToString(), parameters);
                }
            }
        public void DeleteOrder(int id)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>() { { DBColumns.ID, id } };
            comandbuilder.DbDataScalarCommand(StoredProceduresNames.sp_DeleteOrder.ToString(), parameters);
        }
        public Order GetOrder(int id)
        {
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
                  comandbuilder.DbDataScalarCommand(StoredProceduresNames.sp_InsertOrder.ToString(), parameters);
              }
              else
              {
                  comandbuilder.DbDataScalarCommand(StoredProceduresNames.sp_UpdateOrder.ToString(), parameters);
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
                using var dataTable = comandbuilder.DbDataReaderCommand(StoredProceduresNames.sp_GetOrders.ToString(), parameters);

                foreach (DataRow dataRow in dataTable.Rows)
                {
                    Order ord = new Order()
                    {
                        OrderID = Convert.ToInt32(dataRow[DBColumns.ORDER_ID.Replace("@", "")]),
                        OrderDate = Convert.ToDateTime(dataRow[DBColumns.ORDER_DATE.Replace("@", " ")]),
                        CarID = Convert.ToInt32(dataRow[DBColumns.CAR_ID.Replace("@", "")]),
                        PersonId = Convert.ToInt32(dataRow[DBColumns.PERSON_ID.Replace("@", "")])
                     };
                   orders.Add(ord);
                }

                return orders;
        }

        public int GetOrdersCount()
        {
            return comandbuilder.DbDataScalarCommand(StoredProceduresNames.sp_GetOrdersCount.ToString());
        }

    }
}
