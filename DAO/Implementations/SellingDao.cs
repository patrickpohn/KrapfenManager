using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAO.Interfaces;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DAO.Implementations
{
    public class SellingDao : ISellingDao
    {
        private readonly DbContextOptionsBuilder _optionsBuilder;
        
        public SellingDao(string db)
        {
            _optionsBuilder = new DbContextOptionsBuilder<ContextManager>();
            _optionsBuilder.UseMySql(db);
        }
        
        public async Task<List<Selling>> GetAllSelling()
        {
            await using var ctx = new ContextManager(_optionsBuilder.Options);
            return await ctx.Selling.ToListAsync();
        }

        public async Task<Selling> GetSellingById(Guid? id)
        {
            await using var ctx = new ContextManager(_optionsBuilder.Options);
            return await ctx.Selling.FirstOrDefaultAsync(k => k.Id.Equals(id));
        }

        public async Task<Selling> AddSelling(Selling selling)
        {
            await using var ctx = new ContextManager(_optionsBuilder.Options);
            await ctx.Selling.AddAsync(selling);
            await ctx.SaveChangesAsync();
            return selling;
        }

        public async Task<Selling> UpdateSelling(Selling selling)
        {
            await using var ctx = new ContextManager(_optionsBuilder.Options);
            ctx.Selling.Update(selling);
            await ctx.SaveChangesAsync();
            return selling;
        }

        public async void DeleteSelling(Selling selling)
        {
            await using var ctx = new ContextManager(_optionsBuilder.Options);
            ctx.Selling.Remove(selling);
            await ctx.SaveChangesAsync();
        }
    }
}