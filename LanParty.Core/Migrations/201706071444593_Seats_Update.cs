namespace LanParty.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Seats_Update : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Seats", "Width", c => c.Int(nullable: false));
            AddColumn("dbo.Seats", "Height", c => c.Int(nullable: false));
            AddColumn("dbo.Seats", "Rotation", c => c.Int(nullable: false));
            AlterColumn("dbo.Seats", "PositionX", c => c.String(nullable: true));
            AlterColumn("dbo.Seats", "PositionY", c => c.String(nullable: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Seats", "PositionY", c => c.String());
            AlterColumn("dbo.Seats", "PositionX", c => c.String());
            DropColumn("dbo.Seats", "Rotation");
            DropColumn("dbo.Seats", "Height");
            DropColumn("dbo.Seats", "Width");
        }
    }
}
