using Microsoft.AspNetCore.Mvc;
using PharmacyWebApp.Models;
using PharmacyWebApp.Models.Tables;

namespace PharmacyWebApp.Controllers
{
    public class WarehouseController : Controller
    {
        readonly PharmacyDB _pharmacyDB;
        public WarehouseController(PharmacyDB pharmacyDB)
        {
            _pharmacyDB = pharmacyDB;
        }
        public IActionResult WarehousePage(int id)
        {
            return View("WarehousePage", _pharmacyDB.Pharmacies.Find(id));
        }
        public IActionResult RemoveWarehouse(int id)
        {
            if (id != 0)
                _pharmacyDB.RemoveWarehouse(id);
            return Ok();
        }

        public IActionResult AddWarehouse([FromBody] Warehouse warehouse) 
        {
            _pharmacyDB.AddWarehouse(warehouse, out warehouse);
            return Json(warehouse);
        }
    }
}
