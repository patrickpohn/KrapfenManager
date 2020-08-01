using System;
using System.Collections.Generic;
using Entities;

namespace DAO.Interfaces
{
    public interface IOrderDao
    {
        List<Order> GetAllOrders();
        Order GetOrderById(Guid? id);
        Order AddOrder(Order order);
        List<Order> AddOrderRange(List<Order> order);
        Order UpdateOrder(Order order);
        void DeleteOrder(Order order);
    }
}