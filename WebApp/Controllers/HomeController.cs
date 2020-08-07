using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public Krapfen Index()
        {
            var k = new Krapfen
            {
                Id = Guid.NewGuid(),
                Name = "Marille",
                Price = 1.5
            };
            BL.BL.Instance.AddKrapfen(k);
            return k;
        }
    }
}