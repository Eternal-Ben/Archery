namespace Archery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Archers", newName: "Administrators");
            CreateTable(
                "dbo.Archers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LicenseNumber = c.String(),
                        Mail = c.String(nullable: false, maxLength: 150),
                        Password = c.String(maxLength: 150),
                        ConfirmedPassword = c.String(),
                        LastName = c.String(nullable: false),
                        FirstName = c.String(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            DropColumn("dbo.Administrators", "LicenseNumber");
            DropColumn("dbo.Administrators", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Administrators", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Administrators", "LicenseNumber", c => c.String());
            DropTable("dbo.Archers");
            RenameTable(name: "dbo.Administrators", newName: "Archers");
        }
    }
}
