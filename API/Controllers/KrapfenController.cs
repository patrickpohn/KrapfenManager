using System;
using System.IO;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System.IO;  
using System.Drawing;
using System.Net.Mime;
using System.Threading.Tasks;

namespace API.Controllers

{
    [Route("krapfen")]
    public class KrapfenController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return Ok(await BL.BL.Instance.GetAllKrapfen());
        }
        
        [Route("add")]
        [HttpPost]
        public async Task<IActionResult> AddKrapfen([FromBody] Krapfen krapfen)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.Values);

            var existingKrapfen = await BL.BL.Instance.GetKrapfenByName(krapfen.Name);

            if (existingKrapfen != null) return Ok(existingKrapfen);
            
            krapfen.Id ??= Guid.NewGuid();
            return Ok(BL.BL.Instance.AddKrapfen(krapfen));
        }

        [Route("get")]
        [HttpGet]
        public async Task<IActionResult> GetKrapfen(Guid id)
        {
            return Ok(await BL.BL.Instance.GetKrapfenById(id));
        }
        
        [Route("edit")]
        [HttpPut]
        public async Task<IActionResult> EditKrapfen([FromBody] Krapfen krapfen)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.Values);
            if (await BL.BL.Instance.GetKrapfenById(krapfen.Id) == null) return NotFound("No Krapfen Found");
            return Ok(await BL.BL.Instance.UpdateKrapfen(krapfen));
        }

        [Route("getImage")]
        [HttpPost]
        public async Task<IActionResult> GetImageFromKrapfen(Guid guid)
        {
            var krapfen = await BL.BL.Instance.GetKrapfenById(guid);
            if (krapfen == null || string.IsNullOrEmpty(krapfen.Image)) return NotFound("No Krapfen Found");

            var imageBytes = Convert.FromBase64String(krapfen.Image);
            
            return File(imageBytes, "image/png");
        }

        [Route("delete")]
        [HttpDelete]
        public async Task<IActionResult> DeleteKrapfen([FromBody] Krapfen krapfen)
        {
            if (await BL.BL.Instance.GetKrapfenById(krapfen.Id) == null) return NotFound("No Krapfen Found");
            BL.BL.Instance.DeleteKrapfen(krapfen);
            return Ok("Krapfen deleted");
        }
    }
}