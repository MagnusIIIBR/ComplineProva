using ComplineProva.Domain;
using System.Data.Entity.ModelConfiguration;

namespace ComplineProva.Data.Mapping
{
    public class TarefaMap : EntityTypeConfiguration<Tarefa>
    {
        public TarefaMap()
        {
            ToTable("Tarefa");

            HasKey(x => x.Id);

            Property(x => x.Titulo).IsRequired().HasMaxLength(160);
            Property(x => x.Prioridade).IsRequired();
            Property(x => x.Importante).IsRequired();

        }
    }
}
