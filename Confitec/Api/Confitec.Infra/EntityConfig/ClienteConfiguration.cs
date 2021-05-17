using Confitec.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Confitec.Infra.EntityConfig
{
    public class ClienteConfiguration : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfiguration()
        {
            HasKey(c => c.Id);

            Property(c => c.Id)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            Property(c => c.Nome)
                .IsRequired();

            Property(c => c.Sobrenome)
                .IsRequired();

            Property(c => c.DataNascimento)
                .IsRequired();

        }
    }
}
