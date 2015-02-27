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
        public DbSet<ACEModule> AceModules { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<ModuleOrder> ModuleOrders { get; set; }
        
        //public override int SaveChanges()
        //{
        //    return base.SaveChanges();
        //}

        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        //    // Primary keys.
        //    modelBuilder.Entity<Customer>().HasKey(c => c.id);
        //    modelBuilder.Entity<Customer>().Property(p => p.id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

        //    modelBuilder.Entity<Task>().HasKey(c => c.id);
        //    modelBuilder.Entity<Task>().Property(p => p.id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

        //    modelBuilder.Entity<Department>().HasKey(c => c.id);
        //    modelBuilder.Entity<Department>().Property(p => p.id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

        //    modelBuilder.Entity<Language>().HasKey(c => c.id);
        //    modelBuilder.Entity<Language>().Property(p => p.id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        //    //// http://www.iana.org/assignments/language-subtag-registry

        //    modelBuilder.Entity<Project>().HasKey(c => c.id);
        //    modelBuilder.Entity<Project>().Property(p => p.id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

        //    modelBuilder.Entity<User>().HasKey(c => c.id);
        //    modelBuilder.Entity<User>().Property(p => p.id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

        //    modelBuilder.Entity<Relation>().HasKey(c => c.id);
        //    modelBuilder.Entity<Relation>().Property(p => p.id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

        //    modelBuilder.Entity<Attachment>().HasKey(c => c.id);
        //    modelBuilder.Entity<Attachment>().Property(p => p.id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

        //    modelBuilder.Entity<UserSetting>().HasKey(c => c.id);
        //    modelBuilder.Entity<UserSetting>().Property(p => p.id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

        //    modelBuilder.Entity<VendorLanguageRole>().HasKey(c => c.id);
        //    modelBuilder.Entity<VendorLanguageRole>().Property(p => p.id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

        //    modelBuilder.Entity<VendorLanguageRoleMember>().HasKey(c => c.id);
        //    modelBuilder.Entity<VendorLanguageRoleMember>().Property(p => p.id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

        //    modelBuilder.Entity<News>().HasKey(c => c.id);
        //    modelBuilder.Entity<News>().Property(p => p.id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

        //    modelBuilder.Entity<VendorCompany>().HasKey(c => c.id);
        //    modelBuilder.Entity<VendorCompany>().Property(p => p.id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

        //    modelBuilder.Entity<Permission>().HasKey(c => c.id);
        //    modelBuilder.Entity<Permission>().Property(p => p.id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

        //    modelBuilder.Entity<RolePrototype>().HasKey(c => c.id);
        //    modelBuilder.Entity<RolePrototype>().Property(p => p.id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

        //    modelBuilder.Entity<Tag>().HasKey(t => t.id);
        //    modelBuilder.Entity<Tag>().Property(t => t.id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

        //    modelBuilder.Entity<FinanceInput>().HasKey(i => i.id);
        //    modelBuilder.Entity<FinanceInput>().Property(i => i.id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

        //    modelBuilder.Entity<ParserCategory>().HasKey(c => c.id);
        //    modelBuilder.Entity<ParserCategory>().Property(c => c.id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

        //    modelBuilder.Entity<PaymentModel>().HasKey(m => m.id);
        //    modelBuilder.Entity<PaymentModel>().Property(m => m.id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

        //    modelBuilder.Entity<TaskAmount>().HasKey(a => a.id);
        //    modelBuilder.Entity<TaskAmount>().Property(a => a.id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

        //    modelBuilder.Entity<FinanceInput>().HasKey(f => f.id);
        //    modelBuilder.Entity<FinanceInput>().Property(f => f.id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

        //    // Primary keys for assotiation entities with composite key.
        //    // Here, the "Id" column, although unique, is just an Identity column. The real "key" consists of multiple columns, which are usually FK columns.
        //    modelBuilder.Entity<TaskHierarchyBridge>().HasKey(c => new { task_id = c.task_id, ancestor_task_id = c.ancestor_task_id });
        //    modelBuilder.Entity<TaskHierarchyBridge>().Property(p => p.id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);


        //    // Primary keys for codebooks
        //    modelBuilder.Entity<TaskState>().HasKey(c => c.id);
        //    modelBuilder.Entity<TaskState>().Property(c => c.id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

        //    // Concurrency Tokens
        //    modelBuilder.Entity<Task>().Property(x => x.version).IsConcurrencyToken();
        //    modelBuilder.Entity<Project>().Property(x => x.version).IsConcurrencyToken();


        //    //////////////////////////////////////////////////////////////////////////
        //    // one to N relationships
        //    //////////////////////////////////////////////////////////////////////////

        //    modelBuilder.Entity<Project>().HasRequired(p => p.customer).WithMany(c => c.projects).HasForeignKey(p => p.customer_id);
        //    modelBuilder.Entity<Project>().HasRequired(p => p.department).WithMany(c => c.projects).HasForeignKey(p => p.department_id);
        //    modelBuilder.Entity<Project>().HasRequired(p => p.source_language).WithMany(c => c.source_language_projects).HasForeignKey(p => p.source_language_id).WillCascadeOnDelete(false);


        //    modelBuilder.Entity<Task>().HasRequired(p => p.project).WithMany(p => p.tasks).HasForeignKey(p => p.project_id);
        //    modelBuilder.Entity<Task>().HasRequired(p => p.source_language).WithMany(c => c.source_language_tasks).HasForeignKey(p => p.source_language_id).WillCascadeOnDelete(false);
        //    modelBuilder.Entity<Task>().HasRequired(p => p.state).WithMany().HasForeignKey(c => c.state_id);

        //    //modelBuilder.Entity<Task>().HasOptional(p => p.Relation).WithMany(c => c.Tasks).HasForeignKey(p => p.RelationId);
        //    modelBuilder.Entity<Attachment>().HasOptional(p => p.task).WithMany(c => c.attachments).HasForeignKey(p => p.task_id);

        //    modelBuilder.Entity<VendorLanguageRole>().HasRequired(p => p.project).WithMany(c => c.vendor_language_roles).HasForeignKey(p => p.project_id);
        //    modelBuilder.Entity<VendorLanguageRoleMember>().HasRequired(p => p.vendor_language_role).WithMany(c => c.vendor_language_role_members).HasForeignKey(p => p.vendor_language_role_id);
        //    //modelBuilder.Entity<VendorLanguageRoleMember>().HasRequired(p => p.User).WithMany(c => c.VendorLanguageRoleMembers).HasForeignKey(p => p.UserId);

        //    //modelBuilder.Entity<News>().HasRequired(p => p.User).WithMany(c => c.News).HasForeignKey(p => p.UserId);

        //    modelBuilder.Entity<User>().HasMany(u => u.user_settings).WithOptional().HasForeignKey(s => s.user_id).WillCascadeOnDelete(true);

        //    modelBuilder.Entity<RolePrototype>().HasRequired(p => p.permission_for_manage_members).WithMany().HasForeignKey(c => c.permission_for_manage_members_id).WillCascadeOnDelete(false);

        //    modelBuilder.Entity<TaskHierarchyBridge>().HasRequired(p => p.task).WithMany().HasForeignKey(p => p.task_id).WillCascadeOnDelete(false);
        //    modelBuilder.Entity<TaskHierarchyBridge>().HasRequired(p => p.ancestor_task).WithMany().HasForeignKey(p => p.ancestor_task_id).WillCascadeOnDelete(false);

        //    // many to many relationships
        //    modelBuilder.Entity<Project>().HasMany(p => p.languages).WithMany(t => t.projects).Map(mc =>
        //    {
        //        // IN EF 4.3, there is a bug where MapLeftKey and MapRightKey are not mapping HasMany and WithMany respectively
        //        // but instead flipping this mapping around. So the MapLeftKey and MapRightKey property names have to be flipped.
        //        mc.ToTable("ProjectLanguage");
        //        mc.MapLeftKey("project_id");
        //        mc.MapRightKey("language_id");

        //    });

        //    modelBuilder.Entity<Task>().HasMany(p => p.users).WithMany(t => t.tasks).Map(mc =>
        //    {
        //        // IN EF 4.3, there is a bug where MapLeftKey and MapRightKey are not mapping HasMany and WithMany respectively
        //        // but instead flipping this mapping around. So the MapLeftKey and MapRightKey property names have to be flipped.
        //        mc.ToTable("PersonTasks");
        //        mc.MapLeftKey("task_id");
        //        mc.MapRightKey("user_id");
        //    });

        //    modelBuilder.Entity<Task>().HasMany(p => p.languages).WithMany(t => t.tasks).Map(mc =>
        //    {
        //        // IN EF 4.3, there is a bug where MapLeftKey and MapRightKey are not mapping HasMany and WithMany respectively
        //        // but instead flipping this mapping around. So the MapLeftKey and MapRightKey property names have to be flipped.
        //        mc.ToTable("LanguageTasks");
        //        mc.MapLeftKey("task_id");
        //        mc.MapRightKey("language_id");
        //    });

        //    modelBuilder.Entity<Task>().HasMany(p => p.tags).WithMany(t => t.tasks).Map(mc =>
        //    {
        //        // IN EF 4.3, there is a bug where MapLeftKey and MapRightKey are not mapping HasMany and WithMany respectively
        //        // but instead flipping this mapping around. So the MapLeftKey and MapRightKey property names have to be flipped.
        //        mc.ToTable("TaskTags");
        //        mc.MapLeftKey("task_id");
        //        mc.MapRightKey("tag_id");
        //    });

        //    modelBuilder.Entity<RolePrototype>().HasMany(r => r.permissions).WithMany(p => p.roles).Map(mc =>
        //    {
        //        // IN EF 4.3, there is a bug where MapLeftKey and MapRightKey are not mapping HasMany and WithMany respectively
        //        // but instead flipping this mapping around. So the MapLeftKey and MapRightKey property names have to be flipped.
        //        mc.ToTable("RolePermissions");
        //        mc.MapLeftKey("role_id");
        //        mc.MapRightKey("permission_id");
        //    });
        //
        }
    }
}
