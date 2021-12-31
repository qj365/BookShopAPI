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

        public ActionResult Delete(int id)
        {
            var author = _context.Author.SingleOrDefault(c => c.Id == id);
            if (author == null)
                return HttpNotFound();
            else
            {
                _context.Author.Remove(author);
                _context.SaveChanges();
                return RedirectToAction("Index", "Author");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Author author)
        {
            if (author.Id == 0)
                _context.Author.Add(author);
            else
            {
                var authorInDb = _context.Author.Single(c => c.Id == author.Id);
                authorInDb.Name = author.Name;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Author");
        }
    }
}