using Microsoft.EntityFrameworkCore;
using APIAlmoxarifado.Models;
using APIAlmoxarifado.Data.Map;

namespace APIAlmoxarifado.Data
{
    public class SistemaTarefasDBContext : DbContext
    {
        public SistemaTarefasDBContext(DbContextOptions<SistemaTarefasDBContext> options)
        : base(options)
        {
        }

        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<TarefaModel> Tarefas { get; set; }
        public DbSet<Logs> Logs { get; set; } // Remova o '?' para torná-lo não nulo
        public DbSet<Benchmarking> Benchmarking { get; set; } // Remova o '?' para torná-lo não nulo

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new TarefaMap());
            modelBuilder.ApplyConfiguration(new LogsMap()); // Aplica o mapeamento de Logs
            modelBuilder.ApplyConfiguration(new BenchmarkingMap()); // Aplica o mapeamento de Benchmarking
            base.OnModelCreating(modelBuilder);
        }
    }
}   