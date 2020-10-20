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
        private IRepository<Order> orderRepo;
        public OrderService(IRepository<Order> orderRepo)
        {
            this.orderRepo = orderRepo;
        }

        public void AddOrder(Order order)
        {
            if (order.OrderID == 0)
            {
                orderRepo.Add(order);
            }
            else
            {
                orderRepo.Update(order, order.OrderID);
            }
            
        }
        public void DeleteOrder(int id)
        {
            orderRepo.Delete(id);
        }
        public Order GetOrder(int id)
        {
            return orderRepo.Get(id);         
        }

        public List<Order> GetOrders(int page, int pageSize, string sort)
        {
            return orderRepo.GetByPaging(page,pageSize,sort);
        }

        public int GetOrdersCount()
        {
            return orderRepo.GetCount();
        }
    }
}
