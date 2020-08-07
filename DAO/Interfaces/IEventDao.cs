using System;
using System.Collections.Generic;
using Entities;

namespace DAO.Interfaces
{
    public interface IEventDao
    {
        List<Event> GetAllEvent();
        Event GetEventById(Guid? id);
        Event AddEvent(Event @event);
        List<Event> AddEventRange(List<Event> @event);
        Event UpdateEvent(Event @event);
        void DeleteEvent(Event @event);
    }
}