
using Endpoint.Helper;
using Endpoint.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Endpoint.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApiService service;

        public HomeController(ILogger<HomeController> logger,ApiService  service)
        {
            _logger = logger;
            this.service = service;
        }

        public IActionResult Index()
        {
            return View(service.GetAll());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Std std )
        {
            service.Post(std);
            return RedirectToAction("index");
        }

        public IActionResult Edite()
        { 
            return View();
        }
        [HttpPut]
        public IActionResult Edite(Std std)
        {
            service.Put(std);
            return RedirectToAction("index");
        }

        public IActionResult Delete()
        {
            return View();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            service.Delete(id);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
