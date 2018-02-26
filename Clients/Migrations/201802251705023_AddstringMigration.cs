namespace Clients.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddstringMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clients", "IssueAuthority", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Clients", "IssueAuthority", c => c.Int(nullable: false));
        }
    }
}
