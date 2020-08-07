using System;
using System.IO;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System.IO;  
using System.Drawing;
using System.Net.Mime;

namespace API.Controllers
{
    public class KrapfenController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return Ok("Krapfen");
        }
        
        public IActionResult AddKrapfen([FromBody] Krapfen krapfen)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.Values);

            var existingKrapfen = BL.BL.Instance.GetKrapfenByName(krapfen.Name);

            if (existingKrapfen != null) return Ok(existingKrapfen);
            
            krapfen.Id ??= Guid.NewGuid();
            return Ok(BL.BL.Instance.AddKrapfen(krapfen));
        }
        
        public IActionResult GetKrapfen([FromBody] Guid id)
        {
            return Ok(BL.BL.Instance.GetKrapfenById(id));
        }

        public IActionResult GetAllKrapfen()
        {
            return Ok(BL.BL.Instance.GetAllKrapfen());
        }

        public IActionResult EditKrapfen([FromBody] Krapfen krapfen)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.Values);
            if (BL.BL.Instance.GetKrapfenById(krapfen.Id) == null) return NotFound("No Krapfen Found");
            return Ok(BL.BL.Instance.UpdateKrapfen(krapfen));
        }

        public IActionResult GetImageFromKrapfen([FromBody] Guid guid)
        {
            var krapfen = BL.BL.Instance.GetKrapfenById(guid);
            if (krapfen == null || string.IsNullOrEmpty(krapfen.Image)) return NotFound("No Krapfen Found");

            var imageBytes = Convert.FromBase64String(krapfen.Image);
            
            return File(imageBytes, "image/png");
        }

        public IActionResult DeleteKrapfen([FromBody] Krapfen krapfen)
        {
            BL.BL.Instance.DeleteKrapfen(krapfen);
            return Ok("Krapfen deleted");
        }
    }
}