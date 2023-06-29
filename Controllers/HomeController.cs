using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PharmacyWebApp.Models;
using PharmacyWebApp.Models.Tables;
using PharmacyWebApp.Models.Tables.ProductClasses;
using System.Diagnostics;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace PharmacyWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        readonly PharmacyDB _pharmacyDB;
        public HomeController(ILogger<HomeController> logger, PharmacyDB pharmacyDB)
        {
            _logger = logger;
            _pharmacyDB = pharmacyDB;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}