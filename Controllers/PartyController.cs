using Microsoft.AspNetCore.Mvc;
using PharmacyWebApp.Models;
using PharmacyWebApp.Models.Tables;

namespace PharmacyWebApp.Controllers
{
    public class PartyController : Controller
    {
        readonly PharmacyDB _pharmacyDB;
        public PartyController(PharmacyDB pharmacyDB)
        {
            _pharmacyDB = pharmacyDB;
        }
        public IActionResult PartyPage(int id)
        {
            return View("PartyPage", _pharmacyDB.Warehouses.Find(id));
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
        public IActionResult ProductForPharmacyPage(int id)
        {
            return View("ProductForPharmacyPage", _pharmacyDB.Pharmacies.Find(id));
        }
    }
}
