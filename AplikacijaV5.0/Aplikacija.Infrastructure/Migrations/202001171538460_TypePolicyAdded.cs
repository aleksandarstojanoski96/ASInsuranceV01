namespace Aplikacija.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TypePolicyAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TypePolicies",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Code = c.String(),
                        Name = c.String(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CapacityMoney", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TypePolicies", "Id", "dbo.CapacityMoney");
            DropIndex("dbo.TypePolicies", new[] { "Id" });
            DropTable("dbo.TypePolicies");
        }
    }
}
