namespace Clients.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddClientMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ClientID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        SurName = c.String(),
                        SecondName = c.String(),
                        DOB = c.String(),
                        Gender = c.Boolean(nullable: false),
                        Email = c.String(),
                        Number = c.String(),
                        Series = c.String(),
                        PassportID = c.String(),
                        IssueDate = c.String(),
                        IssueAuthority = c.Int(nullable: false),
                        BirthPlace = c.String(),
                        ResidenceCityID = c.Int(nullable: false),
                        Residence = c.String(),
                        ActualCity = c.Int(nullable: false),
                        ActualAddress = c.String(),
                        PhoneNumber = c.String(),
                        HomePhoneNumber = c.String(),
                        Job = c.String(),
                        Position = c.String(),
                        FamilyPositionID = c.Int(nullable: false),
                        NationalityID = c.Int(nullable: false),
                        DisabilityID = c.Int(nullable: false),
                        Pensioner = c.Boolean(nullable: false),
                        Income = c.Int(nullable: false),
                        Reservist = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClientID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Clients");
        }
    }
}
