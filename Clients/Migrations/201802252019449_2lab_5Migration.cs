namespace Clients.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2lab_5Migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Currencies",
                c => new
                    {
                        CurrencyID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Value = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.CurrencyID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Currencies");
        }
    }
}
