namespace GerenciamentoTarefas.Domain.Entities
{
    public abstract class BaseEntity
    {
        protected BaseEntity() { }
        public int Id { get; private set; }
        public DateTime DataCriacao { get; protected set; }

        protected void SetDataAtual() => DataCriacao = DateTime.Now;
    }
}
