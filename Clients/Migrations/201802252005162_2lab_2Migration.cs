namespace Clients.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2lab_2Migration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Deposits", "DepositName", c => c.String());
            AlterColumn("dbo.Deposits", "Currency", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Deposits", "Currency", c => c.Int(nullable: false));
            AlterColumn("dbo.Deposits", "DepositName", c => c.Int(nullable: false));
        }
    }
}
