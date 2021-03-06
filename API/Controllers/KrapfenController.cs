﻿using System;
using System.IO;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System.IO;  
using System.Drawing;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;

namespace API.Controllers

{
    [EnableCors("AllowCors"), Route("krapfen")]
    public class KrapfenController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var krapfen = await BL.BL.Instance.GetAllKrapfen();
            foreach (var k in krapfen)
            {
                k.Image = string.Empty;
            }
            return Ok(krapfen);
        }
        
        [Route("add")]
        [HttpPost]
        public IActionResult AddKrapfen([FromBody] Krapfen krapfen)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.Values);

            var existingKrapfen = BL.BL.Instance.GetKrapfenByName(krapfen.Name);

            krapfen.Id ??= Guid.NewGuid();
            if (existingKrapfen.Result != null) return Ok(existingKrapfen);
            
           
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
        [HttpGet]
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
            
            BL.BL.Instance.RemoveEventKrapfen(krapfen.Id);
            BL.BL.Instance.DeleteKrapfen(krapfen);
            return Ok("Krapfen deleted");
        }
    }
}