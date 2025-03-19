using Microsoft.EntityFrameworkCore;
using PraticaExamen.Models;

namespace PraticaExamen.Data
{
    public class CubosContext: DbContext
    {
        public CubosContext(DbContextOptions<CubosContext> options) : base(options) { }

        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Cubo> Cubos { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<VistaCompra> VistaCompras { get; set; }

    }
}
