using Microsoft.EntityFrameworkCore;
using RegistroObjetosPerdidos.Models;

namespace RegistroObjetosPerdidos.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Reporte> Reportes { get; set; }
    }
}