using GerenciamentoTarefas.Domain.Entities;

namespace GerenciamentoTarefas.Infrastructure.Persistence.Repositories
{
    public class TarefaRepository : Repository<Tarefa>
    {
        public TarefaRepository(GerenciamentoTarefasDbContext context) : base(context) { }
    }
}
