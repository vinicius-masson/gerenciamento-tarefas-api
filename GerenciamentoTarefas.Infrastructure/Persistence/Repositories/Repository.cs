using GerenciamentoTarefas.Domain.Entities;
using GerenciamentoTarefas.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoTarefas.Infrastructure.Persistence.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity, new()
    {
        protected readonly GerenciamentoTarefasDbContext _dbContext;
        protected readonly DbSet<TEntity> _dbset;

        protected Repository(GerenciamentoTarefasDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbset = _dbContext.Set<TEntity>();
        }

        public virtual async Task Adicionar(TEntity entity)
        {
            _dbset.Add(entity);
            await SaveChanges();
        }

        public virtual async Task Atualizar(TEntity entity)
        {
            _dbset.Update(entity);
            await SaveChanges();
        }

        public async virtual Task Excluir(int id)
        {
            var entidade = await ObterPorId(id);

            if (entidade != null)
            {
                _dbset.Remove(entidade);
                await SaveChanges();
            }
            else
                throw new KeyNotFoundException($"Entidade com o ID {id} não encontrada.");
        }

        public virtual async Task<TEntity> ObterPorId(int id)
        {
            return await _dbset.FindAsync(id);
        }

        public virtual async Task<List<TEntity>> ObterTodos()
        {
            return await _dbset.ToListAsync();
        }

        public async Task<int> SaveChanges() => await _dbContext.SaveChangesAsync();

        public void Dispose() => _dbContext?.Dispose();
    }
}
