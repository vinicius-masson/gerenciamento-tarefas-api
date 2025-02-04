using GerenciamentoTarefas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciamentoTarefas.Infrastructure.Persistence.Mappings
{
    public class TarefaMapping : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
               .ValueGeneratedOnAdd();

            builder.Property(x => x.Titulo)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(x => x.Descricao)
                .HasColumnType("varchar(300)")
                .IsRequired(false);

            builder.Property(x => x.DataConclusao)
                .IsRequired(false);

            builder.Property(x => x.Status)
               .IsRequired()
               .HasConversion<int>();
        }
    }
}