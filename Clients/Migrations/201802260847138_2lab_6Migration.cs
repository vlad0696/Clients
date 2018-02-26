namespace Clients.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2lab_6Migration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ClientsDeposits", "Revocable", c => c.Boolean(nullable: false));
            AddColumn("dbo.ClientsDeposits", "Active", c => c.Boolean(nullable: false));
            AddColumn("dbo.InterestDeposits", "InitialAmount", c => c.Double(nullable: false));
            AddColumn("dbo.InterestDeposits", "Percent", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.InterestDeposits", "Percent");
            DropColumn("dbo.InterestDeposits", "InitialAmount");
            DropColumn("dbo.ClientsDeposits", "Active");
            DropColumn("dbo.ClientsDeposits", "Revocable");
        }
    }
}
