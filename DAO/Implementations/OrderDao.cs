using System;
using System.Collections.Generic;
using System.Linq;
using DAO.Interfaces;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DAO.Implementations
{
    public class OrderDao : IOrderDao
    {
        private readonly DbContextOptionsBuilder _optionsBuilder;
        
        public OrderDao(string db)
        {
            _optionsBuilder = new DbContextOptionsBuilder<ContextManager>();
            _optionsBuilder.UseMySql(db);
        }
        
        public List<Order> GetAllOrders()
        {
            using var ctx = new ContextManager(_optionsBuilder.Options);
            return ctx.DbSetOrder.ToList();
        }

        public Order GetOrderById(Guid? id)
        {
            using var ctx = new ContextManager(_optionsBuilder.Options);
            return ctx.DbSetOrder.FirstOrDefault(k => k.Id.Equals(id));
        }

        public Order AddOrder(Order order)
        {
            using var ctx = new ContextManager(_optionsBuilder.Options);
            ctx.DbSetOrder.Add(order);
            ctx.SaveChanges();
            return order;
        }

        public List<Order> AddOrderRange(List<Order> order)
        {
            using var ctx = new ContextManager(_optionsBuilder.Options);
            ctx.DbSetOrder.AddRange(order);
            ctx.SaveChanges();
            return order;
        }

        public Order UpdateOrder(Order order)
        {
            using var ctx = new ContextManager(_optionsBuilder.Options);
            ctx.DbSetOrder.Update(order);
            ctx.SaveChanges();
            return order;
        }

        public void DeleteOrder(Order order)
        {
            using var ctx = new ContextManager(_optionsBuilder.Options);
            ctx.DbSetOrder.Remove(order);
            ctx.SaveChanges();
        }
    }
}