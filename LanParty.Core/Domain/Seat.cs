using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanParty.Core.Domain
{
    public class Seat
    {
        public Guid Id { get; set; }
        [Display(Name = "Plats")]
        public string Position { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Rotation { get; set; }
        public bool Reserved { get; set; }
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }
    }
}
