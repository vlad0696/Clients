namespace Clients.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2lab_4Migration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Deposits", "CurrencyID", c => c.Int(nullable: false));
            DropColumn("dbo.Deposits", "Currency");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Deposits", "Currency", c => c.Int(nullable: false));
            DropColumn("dbo.Deposits", "CurrencyID");
        }
    }
}
