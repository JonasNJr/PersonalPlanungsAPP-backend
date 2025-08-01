namespace PersonalPlanungsAPP.Models
{
    public class Entwicklungsmassnahme
    {
        public int Id { get; set; }
        public int MitarbeiterId { get; set; }
        public string Thema { get; set; }
        public DateTime Datum { get; set; }
        public string Status { get; set; }  // z. B. "geplant", "abgeschlossen"
        public string? Kommentar { get; set; }
    }
}
