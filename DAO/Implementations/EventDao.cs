using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAO.Interfaces;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DAO.Implementations
{
    public class EventDao : IEventDao
    {
        
        private readonly DbContextOptionsBuilder _optionsBuilder;

        public EventDao(string db)
        {
            _optionsBuilder = new DbContextOptionsBuilder<ContextManager>();
            _optionsBuilder.UseMySql(db);
        }
        
        public async Task<List<Event>> GetAllEvent()
        {
            await using var ctx = new ContextManager(_optionsBuilder.Options);
            return await ctx.Event.ToListAsync();
        }

        public async Task<Event> GetEventById(Guid? id)
        {
            await using var ctx = new ContextManager(_optionsBuilder.Options);
            return await ctx.Event.FirstOrDefaultAsync(e => e.Id.Equals(id));
        }

        public async Task<Event> AddEvent(Event @event)
        {
            await using var ctx = new ContextManager(_optionsBuilder.Options);
            await ctx.Event.AddAsync(@event);
            return @event;
        }

        public async Task<Event> UpdateEvent(Event @event)
        {
            await using var ctx = new ContextManager(_optionsBuilder.Options);
            ctx.Event.Update(@event);
            await ctx.SaveChangesAsync();
            return @event;
        }

        public async void DeleteEvent(Event @event)
        {
            await using var ctx = new ContextManager(_optionsBuilder.Options);
            ctx.Event.Remove(@event);
            await ctx.SaveChangesAsync();
        }
    }
}