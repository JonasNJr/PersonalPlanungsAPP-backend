using Microsoft.EntityFrameworkCore;
using PersonalPlanungsAPP.Models;

namespace PersonalPlanungsAPP.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opts)
            : base(opts) { }

        public DbSet<Mitarbeiter> Mitarbeiter { get; set; }
        public DbSet<Kapazitaetsabweichung> Kapazitaetsabweichungen { get; set; }
        public DbSet<KostenstelleInfo> KostenstelleInfos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Bei Bedarf hier Default-Werte, Indizes, Beziehungen konfigurieren
        }
    }
}
