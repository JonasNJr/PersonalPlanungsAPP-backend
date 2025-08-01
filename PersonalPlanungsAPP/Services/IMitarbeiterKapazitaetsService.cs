using System;
using System.Collections.Generic;

namespace PersonalPlanungsAPP.Services
{
    public interface IMitarbeiterKapazitaetsService
    {
        /// <summary>
        /// Liefert die effektive FTE eines Mitarbeiters an einem bestimmten Datum.
        /// </summary>
        double GetFteAmDatum(int mitarbeiterId, DateTime datum);

        /// <summary>
        /// Liefert die effektive FTE für eine Liste von Monatsstart-Daten.
        /// </summary>
        IEnumerable<double> GetFteProMonat(int mitarbeiterId, IEnumerable<DateTime> monatStarts);
    }
}
