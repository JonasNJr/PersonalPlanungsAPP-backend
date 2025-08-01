using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonalPlanungsAPP.Data;
using PersonalPlanungsAPP.Models;  
using PersonalPlanungsAPP.Enums;
using PersonalPlanungsAPP.SampleData;
using PersonalPlanungsAPP.Services;

namespace PersonalPlanungsAPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MitarbeiterController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly IMitarbeiterKapazitaetsService _kapService;

        public MitarbeiterController(ApplicationDbContext db, IMitarbeiterKapazitaetsService kapService)
        {
            _db = db;
            _kapService = kapService;
        }

        // GET: api/mitarbeiter
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mitarbeiter>>> GetAll()
        {
            return await _db.Mitarbeiter.ToListAsync();
        }

        // GET: api/mitarbeiter/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mitarbeiter>> GetById(int id)
        {
            var m = await _db.Mitarbeiter.FindAsync(id);
            if (m == null) return NotFound();
            return m;
        }

        // POST: api/mitarbeiter
        [HttpPost]
        public async Task<ActionResult<Mitarbeiter>> AddMitarbeiter([FromBody] Mitarbeiter mitarbeiter)
        {
            if (mitarbeiter == null)
                return BadRequest("kein JSON im Body");

            // 1. Kostenstelle prüfen …
            var info = KostenstellenBeispiel.Alle.FirstOrDefault(k => k.Kostenstelle == mitarbeiter.Kostenstelle);
            if (info == null)
                return BadRequest("Kostenstelle unbekannt.");

            // 2. Auto‐Mapping
            mitarbeiter.Abteilung = info.Abteilung;
            mitarbeiter.Bereich = info.Bereich;
            mitarbeiter.Bereichsnummer = info.Bereichsnummer;

            // 3. Speichern
            _db.Mitarbeiter.Add(mitarbeiter);
            await _db.SaveChangesAsync();

            // 4. 201 Created
            return CreatedAtAction(nameof(GetById), new { id = mitarbeiter.Id }, mitarbeiter);
        }


        // PUT: api/mitarbeiter/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMitarbeiter(int id, Mitarbeiter updated)
        {
            if (id != updated.Id)
                return BadRequest();

            // Optional: erneut Kostenstellen-Mapping prüfen…
            // var info = KostenstellenBeispiel.Alle.FirstOrDefault(k => k.Kostenstelle == updated.Kostenstelle);
            // if (info == null) return BadRequest("Kostenstelle unbekannt.");

            _db.Entry(updated).State = EntityState.Modified;
            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _db.Mitarbeiter.AnyAsync(m => m.Id == id))
                    return NotFound();
                throw;
            }
            return Ok(updated);
        }

        // GET: api/mitarbeiter/atz
        [HttpGet("atz")]
        public async Task<ActionResult<IEnumerable<Mitarbeiter>>> GetATZMitarbeiter()
        {
            var list = await _db.Mitarbeiter
                .Where(m => m.Austritt == Austrittsart.Altersteilzeit)
                .OrderBy(m => m.Kuendigung ?? m.BefristungMax)
                .ToListAsync();
            return list;
        }

        // GET: api/mitarbeiter/befristet
        [HttpGet("befristet")]
        public async Task<ActionResult<IEnumerable<Mitarbeiter>>> GetBefristete()
        {
            var now = DateTime.Now;
            var list = await _db.Mitarbeiter
                .Where(m =>
                    m.Arbeitsverhaeltnis == Arbeitsverhaeltnis.Befristet &&
                    (m.Befristung != null ||
                     m.Verlaengerung1 != null ||
                     m.Verlaengerung2 != null ||
                     m.BefristungMax != null))
                .OrderBy(m => m.BefristungMax ?? m.Verlaengerung2 ?? m.Verlaengerung1 ?? m.Befristung)
                .ToListAsync();
            return list;
        }

        // GET: api/mitarbeiter/fluktuation
        [HttpGet("fluktuation")]
        public async Task<ActionResult<object>> GetFluktuationsStatistik()
        {
            var data = await _db.Mitarbeiter
                .Where(m => m.Kuendigung.HasValue && m.Austritt != Austrittsart.KeineAngabe)
                .GroupBy(m => new { Jahr = m.Kuendigung.Value.Year, Grund = m.Austritt })
                .Select(g => new {
                    Jahr = g.Key.Jahr,
                    Austrittsart = g.Key.Grund.ToString(),
                    Anzahl = g.Count()
                })
                .OrderBy(x => x.Jahr)
                .ThenBy(x => x.Austrittsart)
                .ToListAsync();
            return Ok(data);
        }

        // GET api/mitarbeiter/{id}/forecast/monate
        [HttpGet("{id}/forecast/monate")]
        public ActionResult<IEnumerable<double>> GetMonatsForecast(int id)
        {
            var monate = Enumerable.Range(0, 24)
                                  .Select(i => DateTime.Today.AddMonths(i).Date);
            var werte = _kapService.GetFteProMonat(id, monate);
            return Ok(werte);
        }

    }
}
