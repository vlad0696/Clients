namespace Clients.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddClientGenderMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clients", "Gender", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Clients", "Gender", c => c.Boolean(nullable: false));
        }
    }
}
