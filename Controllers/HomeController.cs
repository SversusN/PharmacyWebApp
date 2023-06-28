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

        public IActionResult PharmacyPage()
        {
            return View(_pharmacyDB.GetPharmacies());
        }

        public IActionResult PartyPage(int id)
        {
            return View("PartyPage", _pharmacyDB.GetWarehouse(id));
        }

        public IActionResult GetProductsFromPharmacy(int id)
        {
            return Json(_pharmacyDB.GetProductsInPharmacies(id));
        }

        public IActionResult ProductPage()
        {
            return View("ProductPage");
        }
        [HttpGet]
        public JsonResult GetProducts()
        {
            try
            {
                List<Product> products = _pharmacyDB.GetProducts();
                return Json(products);
            }
            catch (Exception ex)
            {
                using (StreamWriter stream = new StreamWriter("C:\\Users\\gidin\\Desktop\\Errors.txt"))
                { 
                    stream.WriteLine(ex.Message);
                }
                return Json(null);
            }
        }

        [HttpPost]
        public IActionResult AddProduct([FromBody] Product product)
        {
            //Product product = obj as Product;
            _pharmacyDB.AddProduct(product, out product);
            return Json(product);
        }
        public IActionResult RemoveProduct(int id)
        { 
            _pharmacyDB.RemoveProduct(id);
            return Ok();
        }
        public IActionResult ProductsFromPharmacy(int id)
        {
            try
            {
                return View("ProductForPharmacyPage", _pharmacyDB.GetPharmacies().Find(c=>c.Id == id));
            }
            catch(Exception ex)
            {
                using (StreamWriter streamReader = new StreamWriter("C:\\Users\\gidin\\Desktop\\Errors.txt"))
                {
                    streamReader.WriteLine(ex.Message);
                    return View("Error");
                }
            }
        }

        public IActionResult PartyForWarehouse(int id)
        {
            return View("PartyPage", _pharmacyDB.GetWarehouse(id));
        }

        public IActionResult AddParty([FromBody] Party party)
        {
            _pharmacyDB.AddParty(party, out party);
            return Json(party);
        }
        public IActionResult RemoveParty(int id)
        { 
            _pharmacyDB.RemoveParty(id);
            return Ok();
        }
        public IActionResult WarehouseForPharmacy(int id)
        {
            return View("WarehousePage", _pharmacyDB.GetPharmacies().Find(c => c.Id == id));
        }

        public IActionResult WarehousePage()
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