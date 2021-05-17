using Confitec.Domain.Entities;
using Confitec.Infra.EntityConfig;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Confitec.Infra.Context
{
    public class ConfitecContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }

        public ConfitecContext() : base(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=confitec;Data Source=DESKTOP-H0H29CG")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new ClienteConfiguration());

            modelBuilder.Entity<Cliente>().ToTable("Clientes");
        }

    }
}
