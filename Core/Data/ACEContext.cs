using System.Data.Entity;
using Core.Models;
using Core.Migrations;


namespace Core.Data
{
    public class AceContext : DbContext
    {
        public AceContext() : base("ACEContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AceContext, Configuration>());
        }

        //////////////////////////////////////////////////////////////////////////
        // Repositories for EF
        //////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Gets or sets DB set of customers
        /// </summary>
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<MemberShip> MemberShips { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UsersInRole> UsersInRole { get; set; }
        public DbSet<AceModule> AceModules { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<ModuleOrder> ModuleOrders { get; set; }
        
        //public override int SaveChanges()
        //{
        //    return base.SaveChanges();
        //}

        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
    
        }
    }
}
