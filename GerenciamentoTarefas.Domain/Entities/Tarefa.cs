namespace GerenciamentoTarefas.Domain.Entities
{
    public class Tarefa : BaseEntity
    {
        public Tarefa() => SetDataAtual();
        
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime? DataConclusao { get; set; }
        public StatusTarefaEnum Status { get; set; }
    }
}
