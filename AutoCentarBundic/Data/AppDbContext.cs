using Microsoft.EntityFrameworkCore;

namespace AutoCentarBundic.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Termin> Termini { get; set; }
    }
}
