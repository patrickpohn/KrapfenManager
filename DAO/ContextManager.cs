using Entities;
using Microsoft.EntityFrameworkCore;

namespace DAO
{
    public class ContextManager : DbContext
    {
        public ContextManager(DbContextOptions options)
            : base(options)
        { }

        public DbSet<Krapfen> DbSetKrapfen { get; set; }
        public DbSet<Order> DbSetOrder { get; set; }
    }
}