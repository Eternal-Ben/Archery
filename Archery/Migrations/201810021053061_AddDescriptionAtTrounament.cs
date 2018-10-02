namespace Archery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDescriptionAtTrounament : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tournaments", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tournaments", "Description");
        }
    }
}