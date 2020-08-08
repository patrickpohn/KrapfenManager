using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;

namespace DAO.Interfaces
{
    public interface IOrderDao
    {
        Task<List<Order>> GetAllOrders();
        Task<Order> GetOrderById(Guid? id);
        Task<Order> AddOrder(Order order);
        Task<Order> UpdateOrder(Order order);
        void DeleteOrder(Order order);
    }
}