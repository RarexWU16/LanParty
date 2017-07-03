namespace LanParty.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Moved_Property_From_Booking_To_Seat : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Seats", "RequestedUnbook", c => c.Boolean(nullable: false));
            DropColumn("dbo.Bookings", "RequestedUnbook");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bookings", "RequestedUnbook", c => c.Boolean(nullable: false));
            DropColumn("dbo.Seats", "RequestedUnbook");
        }
    }
}
