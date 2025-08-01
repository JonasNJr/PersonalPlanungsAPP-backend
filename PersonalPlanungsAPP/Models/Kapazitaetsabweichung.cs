namespace PersonalPlanungsAPP.Models
{
    public class Kapazitaetsabweichung
    {
        public int Id { get; set; }
        public int MitarbeiterId { get; set; }   // Verknüpfung
        public DateTime Startdatum { get; set; }
        public DateTime Enddatum { get; set; }
        public double NeueKapazitaet { get; set; }  // z. B. 0.8 = 80 %
        public string? Bemerkung { get; set; }
    }
}
