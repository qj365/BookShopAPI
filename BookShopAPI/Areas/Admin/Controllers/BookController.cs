using BookShopAPI.Models;
using System;
using System.Collections.Generic;
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

        //public ActionResult Create()
        //{
        //    var author = _context.Authors.ToList();
        //    var category = _context.Categories.ToList();
        //    var publisher = _context.Publishers.ToList();
        //    var viewModel = new BookViewModel
        //    {
        //        Authors = author,
        //        Categories = category,
        //        Publishers = publisher
        //    };
        //    return View("BookForm", viewModel);
        //}

        //public ActionResult Edit(int id)
        //{
        //    var book = _context.Books.SingleOrDefault(c => c.Id == id);
        //    if (book == null)
        //        return HttpNotFound();
        //    var author = _context.Authors.ToList();
        //    var category = _context.Categories.ToList();
        //    var publisher = _context.Publishers.ToList();
        //    var viewModel = new BookViewModel(book)
        //    {
        //        Authors = author,
        //        Categories = category,
        //        Publishers = publisher
        //    };
        //    return View("BookForm", viewModel);
        //}


        
    }
}