using Microsoft.EntityFrameworkCore;
using MarcasApi.Models;

namespace MarcasApi.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<MarcaAuto> MarcasAutos { get; set; } = null!;

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MarcaAuto>().HasData(
                new MarcaAuto { Id = 1, Nombre = "Toyota" },
                new MarcaAuto { Id = 2, Nombre = "Ford" },
                new MarcaAuto { Id = 3, Nombre = "Chevrolet" }
            );
        }
    }
}
