using System;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;

namespace LanParty.Core.Domain
{
    public class Booking
    {
        
        public Guid Id { get; set; }
        [Display(Name = "Användar id")]
        public ApplicationUser User { get; set; }
        [Display(Name = "Bokningsnummer")]
        public string UserId { get; set; }
        [Display(Name = "Plats")]
        public virtual Seat Seat { get; set; }
        [Display(Name = "Bokningsdatum")]
        public DateTime BookingDate { get; set; }
    }
}