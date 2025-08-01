using System;
using System.Collections.Generic;
using System.Linq;
using PersonalPlanungsAPP.Data;
using PersonalPlanungsAPP.Models;

namespace PersonalPlanungsAPP.Services
{
    public class MitarbeiterKapazitaetsService : IMitarbeiterKapazitaetsService
    {
        private readonly ApplicationDbContext _db;
        public MitarbeiterKapazitaetsService(ApplicationDbContext db)
            => _db = db;

        public double GetFteAmDatum(int mitarbeiterId, DateTime datum)
        {
            var m = _db.Mitarbeiter.Find(mitarbeiterId)
                    ?? throw new KeyNotFoundException($"Mitarbeiter {mitarbeiterId} nicht gefunden");

            // Vor Eintritt: 0
            if (datum < m.Eintrittsdatum) return 0;

            // Nach Ende (Austritt/Befristung): 0
            if (m.Enddatum.HasValue && datum > m.Enddatum.Value) return 0;

            // Freistellung (optional): 0
            if (m.Freistellung.HasValue && datum >= m.Freistellung.Value) return 0;

            // Kapazitätsabweichung überschreibt
            var abw = _db.Kapazitaetsabweichungen.FirstOrDefault(a =>
                a.MitarbeiterId == mitarbeiterId &&
                a.Startdatum <= datum &&
                a.Enddatum >= datum);

            if (abw != null) return abw.NeueKapazitaet;

            // Sonst Basis-FTE
            return m.Fte;
        }

        public IEnumerable<double> GetFteProMonat(int mitarbeiterId, IEnumerable<DateTime> monatStarts)
        {
            foreach (var start in monatStarts)
                yield return GetFteAmDatum(mitarbeiterId, start);
        }
    }
}
