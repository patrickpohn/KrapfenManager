using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        
        public async Task<List<Order>> GetAllOrders()
        {
            await using var ctx = new ContextManager(_optionsBuilder.Options);
            return await ctx.Order.Include(o => o.KrapfenOrder).ToListAsync();
        }

        public async Task<Order> GetOrderById(Guid? id)
        {
            await using var ctx = new ContextManager(_optionsBuilder.Options);
            return await ctx.Order.Include(o => o.KrapfenOrder).FirstOrDefaultAsync(k => k.Id.Equals(id));
        }

        public async Task<Order> AddOrder(Order order)
        {
            await using var ctx = new ContextManager(_optionsBuilder.Options);
            await ctx.Order.AddAsync(order);
            await ctx.SaveChangesAsync();
            return order;
        }

        public async Task<Order> UpdateOrder(Order order)
        {
            await using var ctx = new ContextManager(_optionsBuilder.Options);
            ctx.Order.Update(order);
            await ctx.SaveChangesAsync();
            return order;
        }

        public async void DeleteOrder(Order order)
        {
            await using var ctx = new ContextManager(_optionsBuilder.Options);
            ctx.Order.Remove(order);
            await ctx.SaveChangesAsync();
        }
    }
}