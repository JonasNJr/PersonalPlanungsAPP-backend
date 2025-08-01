using System;
using System.ComponentModel.DataAnnotations.Schema;  // für [NotMapped]
using PersonalPlanungsAPP.Enums;

namespace PersonalPlanungsAPP.Models
{
    public partial class Mitarbeiter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Vorname { get; set; }
        public DateTime Eintrittsdatum { get; set; }
        public DateTime? Befristung { get; set; }
        public DateTime? Verlaengerung1 { get; set; }
        public DateTime? Verlaengerung2 { get; set; }
        public DateTime? BefristungMax { get; set; }
        public DateTime? Freistellung { get; set; }
        public DateTime? Kuendigung { get; set; }
        public Austrittsart Austritt { get; set; } = Austrittsart.KeineAngabe;
        public string? Bemerkung { get; set; }
        public string? Funktion { get; set; }
        public string Kostenstelle { get; set; }
        public string Abteilung { get; set; }
        public int Bereichsnummer { get; set; }
        public double Fte { get; set; } = 1.0;
        public Bereich Bereich { get; set; } = Bereich.Direkt;
        public Mengenabhaengigkeit Mengenabhaengigkeit { get; set; } = Mengenabhaengigkeit.Mengenunabhaengig;
        public Arbeitsverhaeltnis Arbeitsverhaeltnis { get; set; } = Arbeitsverhaeltnis.Unbefristet;

        [NotMapped]
        public DateTime? Enddatum =>
            // Kündigung (Kuendigung) geht vor allen Befristungen
            (Austritt != Austrittsart.KeineAngabe && Kuendigung.HasValue)
                ? Kuendigung
            // Ansonsten die längste mögliche Befristung
            : BefristungMax
              ?? Verlaengerung2
              ?? Verlaengerung1
              ?? Befristung;
    }
}
