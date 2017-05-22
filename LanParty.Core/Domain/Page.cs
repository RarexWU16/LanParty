using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LanParty.Core.Domain
{
    public class Page
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Introduction { get; set; }
        public string Contents { get; set; }
        public string ContentType { get; set; }

        public ApplicationUser Author { get; set; }

        [Required]
        public string AuthorId { get; set; }
    }
}