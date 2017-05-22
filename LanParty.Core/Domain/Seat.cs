using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanParty.Core.Domain
{
    public class Seat
    {
        public Guid Id { get; set; }
        public string Position { get; set; }
        public string PositionX { get; set; }
        public string PositionY { get; set; }
        public bool Reserved { get; set; }
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }
    }
}
