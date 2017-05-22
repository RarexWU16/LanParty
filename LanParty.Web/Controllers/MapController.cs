using LanParty.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace LanParty.Web.Controllers
{
    public class MapController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        [System.Web.Http.HttpGet]
        [AllowCrossSiteJson]
        public ActionResult Index()
        {
            var seats = db.Seats.ToList();

            return Json(seats, JsonRequestBehavior.AllowGet);
        }

        public class AllowCrossSiteJsonAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                filterContext.RequestContext.HttpContext.Response.AddHeader("Access-Control-Allow-Origin", "*");
                base.OnActionExecuting(filterContext);
            }
        }
    }
}
