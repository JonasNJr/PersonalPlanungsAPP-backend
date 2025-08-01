using System.Collections.Generic;
using PersonalPlanungsAPP.Models;

namespace PersonalPlanungsAPP.SampleData
{
    public static class KostenstellenBeispiel
    {
        public static List<KostenstelleInfo> Alle = new()
        {
            new KostenstelleInfo { Kostenstelle = "1100", Abteilung = "Logistik", Bereich = Enums.Bereich.Direkt, Bereichsnummer = 1 },
            new KostenstelleInfo { Kostenstelle = "1200", Abteilung = "IT", Bereich = Enums.Bereich.Indirekt, Bereichsnummer = 2 },
            new KostenstelleInfo { Kostenstelle = "1300", Abteilung = "Personal", Bereich = Enums.Bereich.Indirekt, Bereichsnummer = 2 },
            new KostenstelleInfo { Kostenstelle = "1400", Abteilung = "Produktion", Bereich = Enums.Bereich.Direkt, Bereichsnummer = 1 }
        };
    }
}
