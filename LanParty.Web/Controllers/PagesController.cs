using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using LanParty.Core.Domain;
using Microsoft.AspNet.Identity;
using LanParty.Web.Models;

namespace LanParty.Web.Controllers
{
    public class PagesController : Controller
    {
        // GET: Pages
        public ActionResult Index(string contents)
        {
            ViewBag.Content = contents;

            var context = new ApplicationDbContext();
            var pages = context.Pages.Where(x => x.ContentType == contents);

            return View(pages);
        }

        public ActionResult Page(string title)
        {
            var context = new ApplicationDbContext();
            var page = context.Pages.Include(x => x.Author).Single(x => x.Title == title);
            var viewModel = new PageViewModel();
            viewModel.Title = page.Title;
            viewModel.Introduction = page.Introduction;
            viewModel.Contents = page.Contents;
            viewModel.Author = string.Format("{0} {1}", page.Author.FirstName, page.Author.LastName);

            return View(viewModel);
        }

        [HttpGet]
        //[Route("/Create/")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(EditPageViewModel editPageViewModel)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();

                var context = new ApplicationDbContext();
                var currentUser = context.Users.FirstOrDefault(x => x.Id == userId);

                var page = new Page
                {
                    Title = editPageViewModel.Title,
                    Introduction = editPageViewModel.Introduction,
                    Contents = editPageViewModel.Contents,
                    ContentType = editPageViewModel.ContentType,
                    Author = currentUser
                };

                context.Pages.Add(page);
                context.SaveChanges();

                return RedirectToAction("Index", "ContentAdmin");
            }

            return View();
        }
    }
}