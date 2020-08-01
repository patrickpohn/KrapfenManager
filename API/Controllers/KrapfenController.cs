using System;
using System.Collections.Generic;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class KrapfenController : Controller
    {
        // GET
        public string Index()
        {
            return "hi";
        }

        
        public Krapfen AddKrapfen(Krapfen krapfen)
        {
            krapfen.Id ??= Guid.NewGuid();
            return BL.BL.Instance.AddKrapfen(krapfen);
        }
        
        public List<Krapfen> AddKrapfenRange(List<Krapfen> krapfen)
        {
            krapfen.ForEach(k => { k.Id ??= Guid.NewGuid(); });
            return BL.BL.Instance.AddKrapfenRange(krapfen);
        }
        
        public Krapfen GetKrapfen(Guid id)
        {
            return BL.BL.Instance.GetKrapfenById(id);
        }

        public List<Krapfen> GetAllKrapfen()
        {
            return BL.BL.Instance.GetAllKrapfen();
        }

        public Krapfen EditKrapfen(Krapfen krapfen)
        {
            return BL.BL.Instance.UpdateKrapfen(krapfen);
        }

        public IActionResult DeleteKrapfen(Krapfen krapfen)
        {
            BL.BL.Instance.DeleteKrapfen(krapfen);
            return StatusCode(200);
        }
    }
}