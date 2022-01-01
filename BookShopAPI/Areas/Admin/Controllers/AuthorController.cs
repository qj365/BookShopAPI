using BookShopAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookShopAPI.Areas.Admin.Controllers
{
    public class AuthorController : Controller
    {

        private ApplicationDbContext _context;

        public AuthorController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Admin/Author
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            var author = _context.Author.SingleOrDefault(c => c.Id == id);
            if (author == null)
                return HttpNotFound();
            return View(author);
        }

    }
}