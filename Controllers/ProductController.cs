using Microsoft.AspNetCore.Mvc;
using PharmacyWebApp.Models;

namespace PharmacyWebApp.Controllers
{
    public class ProductController : Controller
    {
        readonly PharmacyDB _pharmacyDB;
        public ProductController(PharmacyDB pharmacyDB)
        {
            _pharmacyDB = pharmacyDB;
        }
        public IActionResult ProductPage()
        {
            return View("ProductPage", _pharmacyDB.Products.ToList());
        }
        public IActionResult GetProducts()
        {
            return Json(_pharmacyDB.Products.ToList());
        }


        
    }
}
