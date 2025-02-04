using AutoMapper;
using GerenciamentoTarefas.Application.DTOs;
using GerenciamentoTarefas.Application.Services.Interfaces;
using GerenciamentoTarefas.Domain.Entities;
using GerenciamentoTarefas.Domain.Repositories;

namespace GerenciamentoTarefas.Application.Services.Implementations
{
    public class TarefaService : ITarefaService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Tarefa> _tarefaRepository;

        public TarefaService(IRepository<Tarefa> tarefaRepository, IMapper mapper)
        {
            _tarefaRepository = tarefaRepository;
            _mapper = mapper;
        }

        public async Task<int> Adicionar(TarefaDTO dto)
        {
            var tarefa = MapearEntidade(dto);
            await _tarefaRepository.Adicionar(tarefa);
            return tarefa.Id;
        }

        public async Task Atualizar(TarefaDTO dto)
        {
            var tarefa = MapearEntidade(dto);
            await _tarefaRepository.Atualizar(tarefa);
        }

        public async Task Excluir(int id)
        {
            await _tarefaRepository.Excluir(id);
        }

        public async Task<TarefaDTO> ObterPorId(int id)
        {
            var tarefa = await _tarefaRepository.ObterPorId(id);
            return _mapper.Map<TarefaDTO>(tarefa);
        }

        public async Task<List<TarefaDTO>> ObterTodos()
        {
            var tarefas = await _tarefaRepository.ObterTodos();
            return _mapper.Map<List<TarefaDTO>>(tarefas);
        }

        public void Dispose() => _tarefaRepository?.Dispose();
        private Tarefa MapearEntidade(TarefaDTO dto) => _mapper.Map<Tarefa>(dto);
    }
}
