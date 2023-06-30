using Microsoft.AspNetCore.Mvc;
using PharmacyWebApp.Models;
using PharmacyWebApp.Models.Tables;

namespace PharmacyWebApp.Controllers
{
    public class PharmacyController : Controller
    {
        readonly PharmacyDB _pharmacyDB;
        public PharmacyController(PharmacyDB pharmacyDB)
        {
            _pharmacyDB = pharmacyDB;
        }

        public IActionResult PharmacyPage()
        {
            return View("PharmacyPage", _pharmacyDB.Pharmacies.ToList());
        }

        public IActionResult RemovePharmacy(int id) 
        {
            _pharmacyDB.RemovePharmacy(id);
            return Ok();
        }

        public IActionResult AddPharmacy([FromBody] Pharmacy pharmacy)
        {
            _pharmacyDB.AddPharmacy(pharmacy, out pharmacy);
            return Json(pharmacy);
        }
        public IActionResult ProductsForPharmacyPage(int id)
        {
            return View("ProductsForPharmacyPage", _pharmacyDB.Pharmacies.Find(id));
        }

    }
}
