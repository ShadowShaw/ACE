namespace Core.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Core.Models;
    using Core;

    internal sealed class Configuration : DbMigrationsConfiguration<Core.Data.ACEContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Core.Data.ACEContext context)
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
                  new ACEModule { Name = "P�ece�ov�n�", Description = ModuleInfo.PricingModuleDescription, MonthPrice = ModuleInfo.PricingModulePrice },
                  new ACEModule { Name = "Kontrola datab�ze", Description = ModuleInfo.ConsistencyModuleDescription, MonthPrice = ModuleInfo.ConsistencyModulePrice }
                );
        }
    }
}
