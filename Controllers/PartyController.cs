using Microsoft.AspNetCore.Mvc;
using PharmacyWebApp.Models;
using PharmacyWebApp.Models.Tables;

namespace PharmacyWebApp.Controllers
{
    [ApiController]
    [Route("Party")]
    public class PartyController : Controller
    {
        readonly PharmacyDB _pharmacyDB;
        public PartyController(PharmacyDB pharmacyDB)
        {
            _pharmacyDB = pharmacyDB;
        }

    
        [HttpPost("/PartyPAge/{id}")]
        public IActionResult PartyPage([FromRoute]int id)
        {
            return View("PartyPage", _pharmacyDB.Warehouses.Find(id));
        }
        [HttpPost("/AddParty")]
        public IActionResult AddParty([FromBody] Party party)
        {
            _pharmacyDB.AddParty(party, out party);
            return Json(party);
        }
        [HttpPost("/RemoveParty")]
        public IActionResult RemoveParty(int id)
        {
            _pharmacyDB.RemoveParty(id);
            return Ok();
        }
        [HttpPost("/ProductForPharmacyPage/{id}")]
        public IActionResult ProductForPharmacyPage([FromRoute]int id)
        {
            return View("ProductForPharmacyPage", _pharmacyDB.Pharmacies.Find(id));
        }
    }
}
