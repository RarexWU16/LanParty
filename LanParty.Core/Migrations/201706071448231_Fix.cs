namespace LanParty.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fix : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Seats", "PositionX", c => c.String());
            AlterColumn("dbo.Seats", "PositionY", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Seats", "PositionY", c => c.Double(nullable: false));
            AlterColumn("dbo.Seats", "PositionX", c => c.Double(nullable: false));
        }
    }
}
