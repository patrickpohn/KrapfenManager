using System;
using System.Collections.Generic;
using System.Linq;
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
        
        public List<Krapfen> GetAllKrapfen()
        {
            using var ctx = new ContextManager(_optionsBuilder.Options);
            return ctx.DbSetKrapfen.ToList();
        }

        public Krapfen GetKrapfenById(Guid? id)
        {
            using var ctx = new ContextManager(_optionsBuilder.Options);
            return ctx.DbSetKrapfen.FirstOrDefault(k => k.Id.Equals(id));
        }

        public Krapfen AddKrapfen(Krapfen krapfen)
        {
            using var ctx = new ContextManager(_optionsBuilder.Options);
            ctx.DbSetKrapfen.Add(krapfen);
            ctx.SaveChanges();
            return krapfen;
        }

        public List<Krapfen> AddKrapfenRange(List<Krapfen> krapfen)
        {
            using var ctx = new ContextManager(_optionsBuilder.Options);
            ctx.DbSetKrapfen.AddRange(krapfen);
            ctx.SaveChanges();
            return krapfen;
        }

        public Krapfen UpdateKrapfen(Krapfen krapfen)
        { 
            using var ctx = new ContextManager(_optionsBuilder.Options);
            ctx.DbSetKrapfen.Update(krapfen);
            ctx.SaveChanges();
            return krapfen;
        }

        public void DeleteKrapfen(Krapfen krapfen)
        {
            using var ctx = new ContextManager(_optionsBuilder.Options);
            ctx.DbSetKrapfen.Remove(krapfen);
            ctx.SaveChanges();
        }
    }
}