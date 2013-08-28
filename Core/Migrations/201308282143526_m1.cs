namespace Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.acemodules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        MonthPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.payments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PaymentDate = c.DateTime(nullable: false),
                        PaymentSymbol = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.moduleOrder",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ModuleId = c.Int(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.UserProfile", "CorrespondentionAddress", c => c.String());
            AddColumn("dbo.UserProfile", "FacturationAddress", c => c.String());
            AddColumn("dbo.UserProfile", "EshopUrl", c => c.String());
            DropColumn("dbo.UserProfile", "Address");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserProfile", "Address", c => c.String());
            DropColumn("dbo.UserProfile", "EshopUrl");
            DropColumn("dbo.UserProfile", "FacturationAddress");
            DropColumn("dbo.UserProfile", "CorrespondentionAddress");
            DropTable("dbo.moduleOrder");
            DropTable("dbo.payments");
            DropTable("dbo.acemodules");
        }
    }
}
