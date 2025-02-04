using GerenciamentoTarefas.Domain.Entities;

namespace GerenciamentoTarefas.Domain.Repositories
{
    public interface IRepository<TEntity> : IDisposable where TEntity : BaseEntity
    {
        Task Adicionar(TEntity entity);
        Task Atualizar(TEntity entity);
        Task Excluir(int id);
        Task<TEntity> ObterPorId(int id);
        Task<List<TEntity>> ObterTodos();
        Task<int> SaveChanges();
    }
}