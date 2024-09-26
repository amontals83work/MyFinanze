using Microsoft.EntityFrameworkCore;
using MyFinanzeAPI.Models;

namespace MyFinanzeAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Cargo> Cargos { get; set; }
    }
}
