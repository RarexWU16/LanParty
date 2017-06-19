using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LanParty.Core.Domain;
using LanParty.Web.Models;
using System.Configuration;

namespace LanParty.Web.Controllers
{
    public class DefaultController : Controller
    {
        public ActionResult Index()
        {
            //ViewBag.connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            //return View(ViewBag);
            return View();
        }

        public ActionResult About()
        {
    

            return View();
        }

        public ActionResult Contact()
        {
           

            return View();
        }
        public ActionResult Sponsors()
        {
            

            return View();
        }
        public ActionResult Tournaments()
        {
  

            return View();
        }

        public ActionResult RenderMenu()
        {
            var context = new ApplicationDbContext();
            var contentTypes = context.Pages.GroupBy(type => type.ContentType).Select(group => group.FirstOrDefault());

            var menuItems = new List<DefaultLayoutViewModel.UserDefinedMenuItem>();
            foreach (var item in contentTypes)
            {
                menuItems.Add(
                    new DefaultLayoutViewModel.UserDefinedMenuItem()
                    {
                        Title = item.Title, // item.Title,
                        ContentType = item.ContentType
                    });
            }

            var viewModel = new DefaultLayoutViewModel();
            viewModel.UserDefinedMenuItems = menuItems;

            return PartialView("_UserDefinedMenu", viewModel);
        }
    }
}