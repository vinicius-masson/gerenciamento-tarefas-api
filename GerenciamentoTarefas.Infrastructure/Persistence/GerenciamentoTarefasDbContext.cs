using GerenciamentoTarefas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace GerenciamentoTarefas.Infrastructure.Persistence
{
    public class GerenciamentoTarefasDbContext : DbContext
    {
        public GerenciamentoTarefasDbContext(DbContextOptions<GerenciamentoTarefasDbContext> options) : base(options) { }
        
        public DbSet<Tarefa> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
