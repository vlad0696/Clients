namespace Clients.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddClientRequiredMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clients", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Clients", "SurName", c => c.String(nullable: false));
            AlterColumn("dbo.Clients", "SecondName", c => c.String(nullable: false));
            AlterColumn("dbo.Clients", "DOB", c => c.String(nullable: false));
            AlterColumn("dbo.Clients", "Number", c => c.String(nullable: false));
            AlterColumn("dbo.Clients", "Series", c => c.String(nullable: false));
            AlterColumn("dbo.Clients", "PassportID", c => c.String(nullable: false));
            AlterColumn("dbo.Clients", "IssueDate", c => c.String(nullable: false));
            AlterColumn("dbo.Clients", "BirthPlace", c => c.String(nullable: false));
            AlterColumn("dbo.Clients", "Residence", c => c.String(nullable: false));
            AlterColumn("dbo.Clients", "ActualAddress", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Clients", "ActualAddress", c => c.String());
            AlterColumn("dbo.Clients", "Residence", c => c.String());
            AlterColumn("dbo.Clients", "BirthPlace", c => c.String());
            AlterColumn("dbo.Clients", "IssueDate", c => c.String());
            AlterColumn("dbo.Clients", "PassportID", c => c.String());
            AlterColumn("dbo.Clients", "Series", c => c.String());
            AlterColumn("dbo.Clients", "Number", c => c.String());
            AlterColumn("dbo.Clients", "DOB", c => c.String());
            AlterColumn("dbo.Clients", "SecondName", c => c.String());
            AlterColumn("dbo.Clients", "SurName", c => c.String());
            AlterColumn("dbo.Clients", "Name", c => c.String());
        }
    }
}
