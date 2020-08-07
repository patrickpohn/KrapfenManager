using System;
using System.Collections.Generic;
using System.Linq;
using DAO.Interfaces;
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
        
        public List<Entities.Event> GetAllEvent()
        {
            using var ctx = new ContextManager(_optionsBuilder.Options);
            return ctx.Event.ToList();
        }

        public Entities.Event GetEventById(Guid? id)
        {
            using var ctx = new ContextManager(_optionsBuilder.Options);
            return ctx.Event.FirstOrDefault(e => e.Id.Equals(id));
        }

        public Entities.Event AddEvent(Entities.Event @event)
        {
            using var ctx = new ContextManager(_optionsBuilder.Options);
            ctx.Event.Add(@event);
            return @event;
        }

        public List<Entities.Event> AddEventRange(List<Entities.Event> @event)
        {
            using var ctx = new ContextManager(_optionsBuilder.Options);
            ctx.Event.AddRange(@event);
            return @event;
        }

        public Entities.Event UpdateEvent(Entities.Event @event)
        {
            using var ctx = new ContextManager(_optionsBuilder.Options);
            ctx.Event.Update(@event);
            ctx.SaveChanges();
            return @event;
        }

        public void DeleteEvent(Entities.Event @event)
        {
            using var ctx = new ContextManager(_optionsBuilder.Options);
            ctx.Event.Remove(@event);
        }
    }
}