using System;
using System.Collections.Generic;
using System.Linq;
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
        
        public List<Selling> GetAllSelling()
        {
            using var ctx = new ContextManager(_optionsBuilder.Options);
            return ctx.Selling.ToList();
        }

        public Selling GetSellingById(Guid? id)
        {
            using var ctx = new ContextManager(_optionsBuilder.Options);
            return ctx.Selling.FirstOrDefault(k => k.Id.Equals(id));
        }

        public Selling AddSelling(Selling selling)
        {
            using var ctx = new ContextManager(_optionsBuilder.Options);
            ctx.Selling.Add(selling);
            ctx.SaveChanges();
            return selling;
        }

        public Selling UpdateSelling(Selling selling)
        {
            using var ctx = new ContextManager(_optionsBuilder.Options);
            ctx.Selling.Update(selling);
            ctx.SaveChanges();
            return selling;
        }

        public void DeleteSelling(Selling selling)
        {
            using var ctx = new ContextManager(_optionsBuilder.Options);
            ctx.Selling.Remove(selling);
            ctx.SaveChanges();
        }
    }
}