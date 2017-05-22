using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LanParty.Web.Models
{
    public class EditPageViewModel
    {
        public string Title { get; set; }

        public string Introduction { get; set; }

        [AllowHtml]
        public string Contents { get; set; }

        public string ContentType { get; set; }

        public string Author { get; set; }
    }
}