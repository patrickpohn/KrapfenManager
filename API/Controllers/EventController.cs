using System;
using System.Threading.Tasks;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("event")]
    public class EventController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return Ok(await BL.BL.Instance.GetAllEvent());
        }
        
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddEvent(Event @event)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.Values);
            @event.Id ??= Guid.NewGuid();
            return Ok(await BL.BL.Instance.AddEvent(@event));
        }
        
        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> GetEvent(Guid id)
        {
            return Ok(await BL.BL.Instance.GetEventById(id));
        }

        [HttpPut]
        [Route("edit")]
        public async Task<IActionResult> EditEvent(Event @event)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.Values);
            if (await BL.BL.Instance.GetEventById(@event.Id) == null) return NotFound("Event not found");
            return Ok(await BL.BL.Instance.UpdateEvent(@event));
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteEvent(Event @event)
        {
            if (await BL.BL.Instance.GetEventById(@event.Id) == null) return NotFound("Event not found");
            BL.BL.Instance.DeleteEvent(@event);
            return Ok("Event deleted");
        }
    }
}