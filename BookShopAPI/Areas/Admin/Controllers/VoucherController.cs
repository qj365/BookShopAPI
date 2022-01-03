using BookShopAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookShopAPI.Areas.Admin.Controllers
{
    public class VoucherController : Controller
    {
        private ApplicationDbContext _context;

        public VoucherController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Admin/Voucher
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
            var voucher = _context.Voucher.SingleOrDefault(c => c.Id == id);
            if (voucher == null)
                return HttpNotFound();
            return View(voucher);
        }
    }
}