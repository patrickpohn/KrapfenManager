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
            return await ctx.Event.Include(e => e.Krapfen).ToListAsync();
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
            await ctx.SaveChangesAsync();
            return @event;
        }

        public async Task<Event> UpdateEvent(Event @event)
        {
            await using var ctx = new ContextManager(_optionsBuilder.Options);
            return @event;
        }

        public async void RemoveEventKrapfen(Guid? guid)
        {
            await using var ctx = new ContextManager(_optionsBuilder.Options);
            var toRemove = ctx.EventKrapfen.Where(ek => ek.Krapfen.Equals(guid));
            ctx.EventKrapfen.RemoveRange(toRemove);
            await ctx.SaveChangesAsync();
        }

        public async void DeleteEvent(Event @event)
        {
            await using var ctx = new ContextManager(_optionsBuilder.Options);

            if (!@event.Krapfen.Any())
            {
                @event.Krapfen = null;
            }
            
            ctx.Event.Attach(@event);
            ctx.Event.Remove(@event);
            await ctx.SaveChangesAsync();
        }
    }
}