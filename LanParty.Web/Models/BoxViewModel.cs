using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LanParty.Web.Models
{
    public class BoxViewModel
    {
        public Guid Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Rotation { get; set; }
    }
}