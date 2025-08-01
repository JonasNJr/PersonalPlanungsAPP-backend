// Models/KostenstelleInfo.cs
using PersonalPlanungsAPP.Enums;
using PersonalPlanungsAPP.Models;
using System.ComponentModel.DataAnnotations;

namespace PersonalPlanungsAPP.Models
{
    public class KostenstelleInfo
    {
        [Key]
        public int Id { get; set; }
        public string Kostenstelle { get; set; } = null!;  // z.B. "1100"
        public string Abteilung { get; set; } = null!;  // z.B. "HR"
        public Bereich Bereich { get; set; }          //  Bereich-Enum (Direkt/Indirekt)
        public int Bereichsnummer { get; set; }          // z.B. 1, 2, 3 …
    }
}
