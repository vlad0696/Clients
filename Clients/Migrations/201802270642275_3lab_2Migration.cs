namespace Clients.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3lab_2Migration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InterestCredits", "LastMonthlyPayment", c => c.Double(nullable: false));
            AddColumn("dbo.InterestCredits", "Period", c => c.Int(nullable: false));
            AddColumn("dbo.InterestCredits", "PayMonths", c => c.Int(nullable: false));
            DropColumn("dbo.InterestCredits", "Percent");
        }
        
        public override void Down()
        {
            AddColumn("dbo.InterestCredits", "Percent", c => c.Int(nullable: false));
            DropColumn("dbo.InterestCredits", "PayMonths");
            DropColumn("dbo.InterestCredits", "Period");
            DropColumn("dbo.InterestCredits", "LastMonthlyPayment");
        }
    }
}
