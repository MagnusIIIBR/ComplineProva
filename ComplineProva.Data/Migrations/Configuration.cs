using ComplineProva.Data.Context;
using System.Data.Entity.Migrations;

namespace ComplineProva.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ComplineDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ComplineDataContext context)
        {
        }
    }
}
