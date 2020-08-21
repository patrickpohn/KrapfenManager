using System;
using System.Threading.Tasks;
using Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [EnableCors("AllowCors"), Route("event")]
    public class EventController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return Ok(await BL.BL.Instance.GetAllEvent());
        }
        
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddEvent([FromBody]Event @event)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.Values);
            @event.Id ??= Guid.NewGuid();
            return Ok(await BL.BL.Instance.AddEvent(@event));
        }
        
        [HttpPost]
        [Route("addKrapfen")]
        public async Task<IActionResult> AddKrapfenToEvent([FromBody]EventKrapfen eventKrapfen)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.Values);
            if (await BL.BL.Instance.GetKrapfenById(eventKrapfen.Krapfen) == null)
                return NotFound("Krapfen not Found");
            if (await BL.BL.Instance.GetEventById(eventKrapfen.Event) == null)
                return NotFound("Event not Found");
            var @event = await BL.BL.Instance.GetEventById(eventKrapfen.Event);
            @event.Krapfen.Add(eventKrapfen);
            return Ok(await BL.BL.Instance.UpdateEvent(@event));
        }
        
        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> GetEvent(Guid id)
        {
            return Ok(await BL.BL.Instance.GetEventById(id));
        }

        [HttpPut]
        [Route("edit")]
        public async Task<IActionResult> EditEvent([FromBody]Event @event)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.Values);
            if (await BL.BL.Instance.GetEventById(@event.Id) == null) return NotFound("Event not found");
            return Ok(await BL.BL.Instance.UpdateEvent(@event));
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteEvent(Guid id)
        {
            var @event = await BL.BL.Instance.GetEventById(id);
            if (@event == null) return NotFound("Event not found");
            BL.BL.Instance.DeleteEvent(@event);
            return Ok("Event deleted");
        }
    }
}