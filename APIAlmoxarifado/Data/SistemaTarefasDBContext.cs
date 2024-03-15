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
        public DbSet<Logs> Logs { get; set; } // Adicione esta linha
        public DbSet<Benchmarking> Benchmarking { get; set; } // Adicione esta linha
        public DbSet<Produto> Produtos { get; set; } // Adicione esta linha

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new TarefaMap());
            modelBuilder.ApplyConfiguration(new LogsMap()); // Se você tiver um mapeamento para Logs
            modelBuilder.ApplyConfiguration(new BenchmarkingMap()); // Se você tiver um mapeamento para Benchmarking
            modelBuilder.ApplyConfiguration(new ProdutoMap()); // Adicione esta linha
            base.OnModelCreating(modelBuilder);
        }
    }
}
