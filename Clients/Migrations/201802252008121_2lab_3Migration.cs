namespace Clients.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2lab_3Migration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Deposits", "Currency", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Deposits", "Currency", c => c.String());
        }
    }
}
