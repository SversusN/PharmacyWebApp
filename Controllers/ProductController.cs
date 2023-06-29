using Microsoft.AspNetCore.Mvc;
using PharmacyWebApp.Models;
using PharmacyWebApp.Models.Tables;

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

        public IActionResult AddProduct([FromBody] Product product)
        {
            _pharmacyDB.AddProduct(product, out product);
            return Json(product);
        }

        public IActionResult RemoveProduct(int id)
        {
            _pharmacyDB.RemoveProduct(id);
            return Ok();
        }
        
    }
}
