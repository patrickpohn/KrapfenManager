using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;

namespace DAO.Interfaces
{
    public interface IEventDao
    {
        Task<List<Event>> GetAllEvent();
        Task<Event> GetEventById(Guid? id);
        Task<Event> AddEvent(Event @event);
        Task<Event> UpdateEvent(Event @event);
        void RemoveEventKrapfen(Guid? guid);
        void DeleteEvent(Event @event);
    }
}