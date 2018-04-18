using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ComplineProva.Domain;
using ComplineProva.Data.Mapping;

namespace ComplineProva.Data.Context
{
    public class ComplineDataContext : DbContext
    {
        public ComplineDataContext()
            : base("ComplineConnectionString")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Tarefa> Tarefas { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new TarefaMap());
        }
    }

    public class ComplineDbContextInitializer : DropCreateDatabaseAlways<ComplineDataContext>
    {
    }
}
