namespace Clients.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        CitiesID = c.Int(nullable: false, identity: true),
                        CityName = c.String(),
                    })
                .PrimaryKey(t => t.CitiesID);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ContactsID = c.Int(nullable: false, identity: true),
                        ActualCity = c.Int(nullable: false),
                        ActualAddress = c.String(),
                        PhoneNumber = c.String(),
                        HomePhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.ContactsID);
            
            CreateTable(
                "dbo.Disabilities",
                c => new
                    {
                        DisabilityID = c.Int(nullable: false, identity: true),
                        DisabilityName = c.String(),
                    })
                .PrimaryKey(t => t.DisabilityID);
            
            CreateTable(
                "dbo.FamilyPositions",
                c => new
                    {
                        FamilyPositionID = c.Int(nullable: false, identity: true),
                        Position = c.String(),
                    })
                .PrimaryKey(t => t.FamilyPositionID);
            
            CreateTable(
                "dbo.Nationalities",
                c => new
                    {
                        NationalityID = c.Int(nullable: false, identity: true),
                        NationalityName = c.String(),
                    })
                .PrimaryKey(t => t.NationalityID);
            
            CreateTable(
                "dbo.PassportDatas",
                c => new
                    {
                        PassportDataID = c.Int(nullable: false, identity: true),
                        Number = c.String(),
                        Series = c.String(),
                        PassportID = c.String(),
                        IssueDate = c.DateTime(nullable: false),
                        IssueAuthority = c.Int(nullable: false),
                        BirthPlace = c.String(),
                        ResidenceCityID = c.Int(nullable: false),
                        Residenve = c.String(),
                    })
                .PrimaryKey(t => t.PassportDataID);
            
            CreateTable(
                "dbo.PersonInfoes",
                c => new
                    {
                        PersonInfoID = c.Int(nullable: false, identity: true),
                        Job = c.String(),
                        Position = c.String(),
                        FamilyPositionID = c.Int(nullable: false),
                        NationalityID = c.Int(nullable: false),
                        DisabilityID = c.Int(nullable: false),
                        Pensioner = c.Boolean(nullable: false),
                        Income = c.Int(nullable: false),
                        Reservist = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PersonInfoID);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        PersonID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        SurName = c.String(),
                        SecondName = c.String(),
                        Date = c.DateTime(nullable: false),
                        Gender = c.Boolean(nullable: false),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.PersonID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.People");
            DropTable("dbo.PersonInfoes");
            DropTable("dbo.PassportDatas");
            DropTable("dbo.Nationalities");
            DropTable("dbo.FamilyPositions");
            DropTable("dbo.Disabilities");
            DropTable("dbo.Contacts");
            DropTable("dbo.Cities");
        }
    }
}
