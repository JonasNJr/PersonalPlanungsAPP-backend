using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonalPlanungsAPP.Models;
using System.Collections.Generic;

namespace PersonalPlanungsAPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalentwicklungController : ControllerBase
    {
        private static List<Entwicklungsmassnahme> massnahmenListe = new();

        [HttpPost]
        public ActionResult AddMassnahme(Entwicklungsmassnahme neue)
        {
            neue.Id = massnahmenListe.Count + 1;
            massnahmenListe.Add(neue);
            return Ok(neue);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Entwicklungsmassnahme>> GetAll()
        {
            return Ok(massnahmenListe);
        }

        [HttpGet("mitarbeiter/{id}")]
        public ActionResult<IEnumerable<Entwicklungsmassnahme>> GetByMitarbeiter(int id)
        {
            var result = massnahmenListe.FindAll(m => m.MitarbeiterId == id);
            return Ok(result);
        }
    }
}
