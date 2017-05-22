using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Http;
using System.Web.Http.Cors;

namespace LanParty.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes, HttpConfiguration config)
        {
            
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Pages-Details",
                url: "Pages/Page/{title}",
                defaults: new { controller = "Pages", action = "Page" }
            );

            routes.MapRoute(
                name: "Pages-Create",
                url: "Pages/Create",
                defaults: new { controller = "Pages", action = "Create" }
            );

            routes.MapRoute(
                name: "Pages-Display",
                url: "Pages/{contents}",
                defaults: new { controller = "Pages", action = "Index", contents = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "Default", action = "Index" }
            );

            routes.MapRoute(
                name: "Page",
                url: "{controller}/{action}/{title}",
                defaults: new { controller = "Pages", action = "Page", title = UrlParameter.Optional }
            );

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Default", action = "Index", id = UrlParameter.Optional }
            //);
        }
    }
}
