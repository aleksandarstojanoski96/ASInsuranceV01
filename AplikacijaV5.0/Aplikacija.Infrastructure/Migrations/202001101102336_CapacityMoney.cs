namespace Aplikacija.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CapacityMoney : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CapacityMoney",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PowerFrom = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PowerTo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CapacityMoney");
        }
    }
}
