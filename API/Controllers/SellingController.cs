using System;
using System.Threading.Tasks;
using Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [EnableCors("AllowCors"), Route("selling")]
    public class SellingController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return Ok(await BL.BL.Instance.GetAllSelling());
        }
        
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddSelling(Selling selling)
        {
            if (selling.Time.Day != DateTime.Now.Day)
            {
                selling.Time = DateTime.Now;
            } 
            if (!ModelState.IsValid) return BadRequest(ModelState.Values);
            
            selling.Id ??= Guid.NewGuid();
            return Ok(await BL.BL.Instance.AddSelling(selling));
        }
        
        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> GetSelling(Guid id)
        {
            return Ok(await BL.BL.Instance.GetSellingById(id));
        }

        [HttpPut]
        [Route("edit")]
        public async Task<IActionResult> EditSelling(Selling selling)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.Values);
            if (await BL.BL.Instance.GetSellingById(selling.Id) == null) return NotFound("Selling not Found");
            return Ok(await BL.BL.Instance.UpdateSelling(selling));
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteSelling(Selling selling)
        {
            if (await BL.BL.Instance.GetSellingById(selling.Id) == null) return NotFound("Selling not Found");
            BL.BL.Instance.DeleteSelling(selling);
            return Ok("Selling deleted");
        }
    }
}