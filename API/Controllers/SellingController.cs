using System;
using System.Threading.Tasks;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class SellingController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return Ok("Selling");
        }
        
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
        
        public async Task<IActionResult> GetSelling(Guid id)
        {
            return Ok(await BL.BL.Instance.GetSellingById(id));
        }

        public async Task<IActionResult> GetAllSelling()
        {
            return Ok(await BL.BL.Instance.GetAllSelling());
        }

        public async Task<IActionResult> EditSelling(Selling selling)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.Values);
            if (await BL.BL.Instance.GetSellingById(selling.Id) == null) return NotFound("Selling not Found");
            return Ok(await BL.BL.Instance.UpdateSelling(selling));
        }

        public async Task<IActionResult> DeleteSelling(Selling selling)
        {
            if (await BL.BL.Instance.GetSellingById(selling.Id) == null) return NotFound("Selling not Found");
            BL.BL.Instance.DeleteSelling(selling);
            return Ok("Selling deleted");
        }
    }
}