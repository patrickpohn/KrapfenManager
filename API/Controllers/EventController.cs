using System;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class EventController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return Ok("Event");
        }
        
        public IActionResult AddEvent(Event @event)
        {
            @event.Id ??= Guid.NewGuid();
            return Ok(BL.BL.Instance.AddEvent(@event));
        }
        
        public IActionResult GetEvent(Guid id)
        {
            return Ok(BL.BL.Instance.GetEventById(id));
        }

        public IActionResult GetAllEvent()
        {
            return Ok(BL.BL.Instance.GetAllEvent());
        }

        public IActionResult EditEvent(Event @event)
        {
            return Ok(BL.BL.Instance.UpdateEvent(@event));
        }

        public IActionResult DeleteEvent(Event @event)
        {
            BL.BL.Instance.DeleteEvent(@event);
            return Ok("Event deleted");
        }
    }
}