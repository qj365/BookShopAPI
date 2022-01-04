using BookShopAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookShopAPI.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        private ApplicationDbContext _context;

        public DashboardController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Admin/Dashboard
        public ActionResult Index()
        {
            ViewBag.NewOrder = _context.Orders.Where(c => c.IdState == 1).Count();
            ViewBag.Book = _context.Book.Count();
            ViewBag.Customer = _context.Customer.Count();
            ViewBag.Cancel = _context.Orders.Where(c => c.IdState == 3).Count();
            ViewBag.Suscess = _context.Orders.Where(c => c.IdState == 5).Count();
            return View();
        }
    }
}