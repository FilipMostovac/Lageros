using Lageros.Models;
using Microsoft.EntityFrameworkCore;

namespace Lageros.Data
{
    public class LagerosContext : DbContext
    {
        public LagerosContext(DbContextOptions<LagerosContext> options) : base(options)
        {
        }
        public DbSet<Printer> Printeri { get; set; }
        public DbSet<Lageros.Models.Toner> Toner { get; set; }
        public DbSet<Lageros.Models.ZamjenaToner> ZamjenaToner { get; set; }
        public DbSet<Lageros.Models.NabavaTonera> NabavaTonera { get; set; }
        public DbSet<Lageros.Models.AdminKorisnik> AdminKorisnik { get; set; }
        public DbSet<Lageros.Models.Laptop> Laptop { get; set; }
        public DbSet<Lageros.Models.Monitor> Monitor { get; set; }
        public DbSet<Lageros.Models.Periferija> Periferija { get; set; }
        public DbSet<Lageros.Models.Korisnik> Korisnik { get; set; }
        public DbSet<Lageros.Models.Sektor> Sektor { get; set; }
        public DbSet<Lageros.Models.Izdavanje> Izdavanje { get; set; }
    }
}
