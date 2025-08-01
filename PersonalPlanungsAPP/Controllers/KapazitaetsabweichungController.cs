using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonalPlanungsAPP.Data;  // <- wichtig!
using PersonalPlanungsAPP.Models;

namespace PersonalPlanungsAPP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KapazitaetsabweichungController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public KapazitaetsabweichungController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kapazitaetsabweichung>>> GetAll()
        {
            return await _db.Kapazitaetsabweichungen.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Kapazitaetsabweichung>> GetById(int id)
        {
            var item = await _db.Kapazitaetsabweichungen.FindAsync(id);
            if (item == null) return NotFound();
            return item;
        }

        [HttpGet("mitarbeiter/{mitarbeiterId}")]
        public async Task<ActionResult<IEnumerable<Kapazitaetsabweichung>>> GetByMitarbeiter(int mitarbeiterId)
        {
            var list = await _db.Kapazitaetsabweichungen
                .Where(a => a.MitarbeiterId == mitarbeiterId)
                .ToListAsync();
            return list;
        }

        [HttpPost]
        public async Task<ActionResult<Kapazitaetsabweichung>> Create([FromBody] Kapazitaetsabweichung abw)
        {
            // Überschneidungs-Prüfung (wie gehabt)
            bool overlap = await _db.Kapazitaetsabweichungen.AnyAsync(a =>
                a.MitarbeiterId == abw.MitarbeiterId &&
                abw.Startdatum <= a.Enddatum &&
                abw.Enddatum >= a.Startdatum
            );
            if (overlap)
                return Conflict("Für diesen Mitarbeiter existiert bereits eine Abweichung in diesem Zeitraum.");

            _db.Kapazitaetsabweichungen.Add(abw);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = abw.Id }, abw);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Kapazitaetsabweichung updated)
        {
            if (id != updated.Id)
                return BadRequest();

            _db.Entry(updated).State = EntityState.Modified;
            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _db.Kapazitaetsabweichungen.AnyAsync(x => x.Id == id))
                    return NotFound();
                throw;
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _db.Kapazitaetsabweichungen.FindAsync(id);
            if (item == null) return NotFound();
            _db.Kapazitaetsabweichungen.Remove(item);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}