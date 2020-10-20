using CarStore.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarStore.DAL.Interfaces
{
    public interface IOrderService
    {
        Order GetOrder(int id);

        void AddOrder(Order order);

        void DeleteOrder(int id);

        List<Order> GetOrders(int page, int pageSize, string sort);

        public int GetOrdersCount();
    }
}
