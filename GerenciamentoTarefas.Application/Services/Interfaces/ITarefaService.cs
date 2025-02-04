using GerenciamentoTarefas.Application.DTOs;

namespace GerenciamentoTarefas.Application.Services.Interfaces
{
    public interface ITarefaService : IDisposable
    {
        Task<int> Adicionar(TarefaDTO dto);
        Task Atualizar(TarefaDTO dto);
        Task Excluir(int id);
        Task<TarefaDTO> ObterPorId(int id);
        Task<List<TarefaDTO>> ObterTodos();
    }
}
