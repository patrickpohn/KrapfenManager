using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAO.Interfaces;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;

namespace DAO.Implementations
{
    public class KrapfenDao : IKrapfenDao
    {
        private readonly DbContextOptionsBuilder _optionsBuilder;

        public KrapfenDao(string db)
        {
            _optionsBuilder = new DbContextOptionsBuilder<ContextManager>();
            _optionsBuilder.UseMySql(db);
        }
        
        public async Task<List<Krapfen>> GetAllKrapfen()
        {
            await using var ctx = new ContextManager(_optionsBuilder.Options);
            return await ctx.Krapfen.ToListAsync();
        }

        public async Task<Krapfen> GetKrapfenById(Guid? id)
        {
            await using var ctx = new ContextManager(_optionsBuilder.Options);
            return await ctx.Krapfen.FirstOrDefaultAsync(k => k.Id.Equals(id));
        }

        public async Task<Krapfen> GetKrapfenByName(string name)
        {
            await using var ctx = new ContextManager(_optionsBuilder.Options);
            return await ctx.Krapfen.FirstOrDefaultAsync(k => k.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase));
        }

        public async Task<Krapfen> AddKrapfen(Krapfen krapfen)
        {
            await using var ctx = new ContextManager(_optionsBuilder.Options);
            await ctx.Krapfen.AddAsync(krapfen);
            await ctx.SaveChangesAsync();
            return krapfen;
        }

        public async Task<Krapfen> UpdateKrapfen(Krapfen krapfen)
        { 
            await using var ctx = new ContextManager(_optionsBuilder.Options);
            ctx.Krapfen.Update(krapfen);
            await ctx.SaveChangesAsync();
            return krapfen;
        }

        public async void DeleteKrapfen(Krapfen krapfen)
        {
            await using var ctx = new ContextManager(_optionsBuilder.Options);
            ctx.Krapfen.Remove(krapfen);
            await ctx.SaveChangesAsync();
        }
    }
}