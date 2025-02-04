using AutoMapper;
using GerenciamentoTarefas.Application.DTOs;
using GerenciamentoTarefas.Domain.Entities;

namespace GerenciamentoTarefas.Application.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<TarefaDTO, Tarefa>()
                .ForMember(dest => dest.DataCriacao, x => x.Ignore())
                .ReverseMap();
        }
    }
}
