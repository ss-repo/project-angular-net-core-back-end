using Microsoft.EntityFrameworkCore;

namespace APISistemaVeicularNet.Models
{
    public class VeiculosContext : DbContext
    {
        public VeiculosContext(DbContextOptions<VeiculosContext> options) : base(options) { }

        public DbSet<Veiculos> Veiculos { get; set; }  
    }
}