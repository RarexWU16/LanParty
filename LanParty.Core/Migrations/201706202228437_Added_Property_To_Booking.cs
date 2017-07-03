namespace LanParty.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_Property_To_Booking : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookings", "RequestedUnbook", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bookings", "RequestedUnbook");
        }
    }
}
