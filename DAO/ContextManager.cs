using System.IO;
using System.Reflection.Metadata.Ecma335;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DAO
{
    public class ContextManager : DbContext
    {
        public ContextManager(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Krapfen> Krapfen { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Selling> Selling { get; set; }
        public DbSet<Event> Event { get; set; }
        public DbSet<EventKrapfen> EventKrapfen { get; set; }
    }
    
    public class BloggingContextFactory : IDesignTimeDbContextFactory<ContextManager>
    {
        public ContextManager CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ContextManager>();
            optionsBuilder.UseMySql("Server=192.168.178.44;Port=3306;Uid=krapfen;Pwd=raspberry;Database=KrapfenDb");

            return new ContextManager(optionsBuilder.Options);
        }
    }
}