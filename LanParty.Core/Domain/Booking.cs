using System;
using System.Data.SqlTypes;

namespace LanParty.Core.Domain
{
    public class Booking
    {
        public Guid Id { get; set; }
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }
        public virtual Seat Seat { get; set; }
        public DateTime BookingDate { get; set; }
    }
}