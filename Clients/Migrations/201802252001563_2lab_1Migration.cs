namespace Clients.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2lab_1Migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClientsDeposits",
                c => new
                    {
                        ClientsDepositID = c.Int(nullable: false, identity: true),
                        ClientID = c.Int(nullable: false),
                        DepositID = c.Int(nullable: false),
                        ClientDepositNumber = c.String(),
                        DateStart = c.DateTime(nullable: false),
                        DateEnd = c.DateTime(nullable: false),
                        Amount = c.Double(nullable: false),
                        Period = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClientsDepositID);
            
            CreateTable(
                "dbo.Deposits",
                c => new
                    {
                        DepositID = c.Int(nullable: false, identity: true),
                        BalanceId = c.Int(nullable: false),
                        Revocable = c.Boolean(nullable: false),
                        Percent = c.Int(nullable: false),
                        DepositName = c.Int(nullable: false),
                        Currency = c.Int(nullable: false),
                        Period = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DepositID);
            
            CreateTable(
                "dbo.InterestDeposits",
                c => new
                    {
                        InterestDepositID = c.Int(nullable: false, identity: true),
                        ClientsDepositID = c.Int(nullable: false),
                        InterestDepositNumber = c.String(),
                        Amount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.InterestDepositID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.InterestDeposits");
            DropTable("dbo.Deposits");
            DropTable("dbo.ClientsDeposits");
        }
    }
}
