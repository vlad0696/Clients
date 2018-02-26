namespace Clients.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3lab_1Migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClientsCredits",
                c => new
                    {
                        ClientsCreditID = c.Int(nullable: false, identity: true),
                        ClientID = c.Int(nullable: false),
                        CreditID = c.Int(nullable: false),
                        ClientCreditNumber = c.String(),
                        DateStart = c.DateTime(nullable: false),
                        DateEnd = c.DateTime(nullable: false),
                        Amount = c.Double(nullable: false),
                        Period = c.Int(nullable: false),
                        Diff = c.Boolean(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ClientsCreditID);
            
            CreateTable(
                "dbo.Credits",
                c => new
                    {
                        CreditID = c.Int(nullable: false, identity: true),
                        BalanceId = c.Int(nullable: false),
                        Diff = c.Boolean(nullable: false),
                        Percent = c.Int(nullable: false),
                        DepositName = c.String(),
                        CurrencyID = c.Int(nullable: false),
                        Period = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CreditID);
            
            CreateTable(
                "dbo.InterestCredits",
                c => new
                    {
                        InterestCreditID = c.Int(nullable: false, identity: true),
                        ClientsCreditID = c.Int(nullable: false),
                        InterestCreditNumber = c.String(),
                        Amount = c.Double(nullable: false),
                        MonthlyPayment = c.Double(nullable: false),
                        Percent = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.InterestCreditID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.InterestCredits");
            DropTable("dbo.Credits");
            DropTable("dbo.ClientsCredits");
        }
    }
}
