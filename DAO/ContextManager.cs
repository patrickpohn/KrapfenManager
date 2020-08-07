using System.Reflection.Metadata.Ecma335;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DAO
{
    public class ContextManager : DbContext
    {
        public ContextManager(DbContextOptions options)
            : base(options)
        { }

        public DbSet<Krapfen> Krapfen { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Selling> Selling { get; set; }
        public DbSet<Event> Event { get; set; }
    }
}