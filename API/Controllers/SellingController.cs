using System;
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
        
        public IActionResult AddSelling(Selling selling)
        {
            selling.Id ??= Guid.NewGuid();
            return Ok(BL.BL.Instance.AddSelling(selling));
        }
        
        public IActionResult GetSelling(Guid id)
        {
            return Ok(BL.BL.Instance.GetSellingById(id));
        }

        public IActionResult GetAllSelling()
        {
            return Ok(BL.BL.Instance.GetAllSelling());
        }

        public IActionResult EditSelling(Selling selling)
        {
            return Ok(BL.BL.Instance.UpdateSelling(selling));
        }

        public IActionResult DeleteSelling(Selling selling)
        {
            BL.BL.Instance.DeleteSelling(selling);
            return Ok("Selling deleted");
        }
    }
}