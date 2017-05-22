using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanParty.Core.Domain
{
    public class Lan
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int MaxParticipants { get; set; }
        public virtual List<Seat> Seats { get; set; }
        public string SocialMedia { get; set; }
    }
}
