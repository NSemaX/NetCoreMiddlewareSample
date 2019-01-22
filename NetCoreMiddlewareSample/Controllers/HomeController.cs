using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetCoreMiddlewareSample.Models;

namespace NetCoreMiddlewareSample.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            DateTime dateTime = Convert.ToDateTime("S2019 - 01 - 22 1:21 ÖS40");
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
