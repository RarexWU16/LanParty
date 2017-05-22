using System.Collections.Generic;

namespace LanParty.Web.Models
{
    public class DefaultLayoutViewModel
    {
        public IEnumerable<UserDefinedMenuItem> UserDefinedMenuItems { get; set; }

        public class UserDefinedMenuItem
        {
            public string Title { get; set; }
            public string ContentType { get; set; }
        }
    }
}