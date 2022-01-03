using BookShopAPI.Areas.Admin.ViewModel;
using BookShopAPI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookShopAPI.Areas.Admin.Controllers
{
    public class BookController : Controller
    {
        private ApplicationDbContext _context;

        public BookController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            var author = _context.Author.ToList();
            var category = _context.Category.ToList();
            var publisher = _context.Publisher.ToList();
            var viewModel = new BookViewModel
            {
                Authors = author,
                Categories = category,
                Publishers = publisher
            };
            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            var book = _context.Book.SingleOrDefault(c => c.Id == id);
            if (book == null)
                return HttpNotFound();
            var author = _context.Author.ToList();
            var category = _context.Category.ToList();
            var publisher = _context.Publisher.ToList();
            var viewModel = new BookViewModel(book)
            {
                Authors = author,
                Categories = category,
                Publishers = publisher
            };
            return View(viewModel);
        }


        public JsonResult Savef(int id, HttpPostedFileBase PhotoFile, string today, int type)
        {
            var bookInDb = _context.Book.SingleOrDefault(c => c.Id == id);

            if (PhotoFile != null && PhotoFile.ContentLength > 0)
            {
                var fileName = today + PhotoFile.FileName;
                var path = Path.Combine(Server.MapPath("~/Areas/Admin/Data/BookImage/"),
                                        fileName);
                PhotoFile.SaveAs(path);
                bookInDb.Photo = fileName;
            }
            else
            {
                if (type == 0)
                    bookInDb.Photo = "150x200.png";
                else
                    return Json("no", JsonRequestBehavior.AllowGet);
            }
            _context.SaveChanges();

            return Json("ok", JsonRequestBehavior.AllowGet);


        }


    }
}