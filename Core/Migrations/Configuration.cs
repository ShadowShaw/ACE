namespace Core.Migrations
{
    using System.Data.Entity.Migrations;
    using Models;
    using Core;

    internal sealed class Configuration : DbMigrationsConfiguration<Data.ACEContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Data.ACEContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.ACEModules.AddOrUpdate(
                  p => p.Name,
                  new ACEModule { Name = "Pøeceòování", Description = ModuleInfo.PricingModuleDescription, MonthPrice = ModuleInfo.PricingModulePrice },
                  new ACEModule { Name = "Kontrola databáze", Description = ModuleInfo.ConsistencyModuleDescription, MonthPrice = ModuleInfo.ConsistencyModulePrice }
                );
        }
    }
}
