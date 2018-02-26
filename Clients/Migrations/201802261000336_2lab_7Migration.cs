namespace Clients.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2lab_7Migration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InterestDeposits", "Active", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.InterestDeposits", "Active");
        }
    }
}
