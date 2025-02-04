using FluentValidation;
using GerenciamentoTarefas.Application.DTOs;
using GerenciamentoTarefas.Application.Utils;

namespace GerenciamentoTarefas.Application.Validations
{
    public class TarefaDTOValidation : AbstractValidator<TarefaDTO>
    {
        public TarefaDTOValidation()
        {
            RuleFor(x => x.Titulo)
                .NotEmpty()
                .NotNull()
                .MaximumLength(100)
                .WithMessage("O campo Título deve conter no máximo 100 caracteres");

            RuleFor(x => x.DataConclusao)
                .Must(x => x == null || DateUtils.DataMaiorQueAtual(x.Value))
                .WithMessage("A Data de Conclusão não pode ser menor do que a atual");

            RuleFor(x => x.Descricao)
                .MaximumLength(300)
                .WithMessage("O campo Descrição deve conter no máximo 300 caracteres");

            RuleFor(x => x.Status)
                .IsInEnum()
                .WithMessage("Selecione um status válido para o status");
        }
    }
}
