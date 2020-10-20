using CarStore.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarStore.DAL.Procedures
{
    public class OrderProceduresNames : IProceduresNames<Order>
    {
        private const string SP_INSERT_ORDER = "sp_InsertOrder";
        private const string SP_UPDATE_ORDER = "sp_UpdateOrder";
        private const string SP_DELETE_ORDER = "sp_DeleteOrder";
        private const string SP_GET_ORDER = "sp_GetOrder";
        private const string SP_GET_ORDERS = "sp_GetOrders";
        private const string SP_FIND_ORDERS = "sp_FindOrders";
        private const string SP_GET_ORDERS_COUNT = "sp_GetOrdersCount";

        public string Insert => SP_INSERT_ORDER;
        public string Update => SP_UPDATE_ORDER;
        public string Delete => SP_DELETE_ORDER;
        public string Get => SP_GET_ORDER;
        public string GetEntities => SP_GET_ORDERS;
        public string Find => SP_FIND_ORDERS;
        public string Count => SP_GET_ORDERS_COUNT;

    }
    
}
