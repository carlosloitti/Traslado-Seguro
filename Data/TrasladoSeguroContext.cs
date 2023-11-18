using Microsoft.EntityFrameworkCore;
using Traslado_Seguro.Model;

namespace Traslado_Seguro.Data
{
    internal class TrasladoSeguroContext : DbContext
    {
        public DbSet<STransporte> Transportes { get; set;}

        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=(localdb)\\mssqllocaldb;Database=TrasladoSeguro;Trusted_Connection=True;");
        }

        public TrasladoSeguroContext(DbContextOptions options) : base(options)
        {
        }
    }
}
