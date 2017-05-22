using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LanParty.Web.Controllers
{
    [Authorize(Roles = "Editor, Administrator")]
    public class ContentAdminController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}