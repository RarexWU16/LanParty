namespace LanParty.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changed_PositionX_And_PositionY_To_Int : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Seats", "PositionX", c => c.Int(nullable: false));
            AlterColumn("dbo.Seats", "PositionY", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Seats", "PositionY", c => c.String());
            AlterColumn("dbo.Seats", "PositionX", c => c.String());
        }
    }
}
