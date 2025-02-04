using GerenciamentoTarefas.Domain;

namespace GerenciamentoTarefas.Application.DTOs
{
    public class TarefaDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime? DataConclusao { get; set; }
        public StatusTarefaEnum Status { get; set; }
    }
}
