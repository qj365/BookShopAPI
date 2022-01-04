using AutoMapper;
using BookShopAPI.Areas.Admin.Dto;
using BookShopAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookShopAPI.Areas.Admin.Controllers.Api
{
    public class VoucherController : ApiController
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

        public IHttpActionResult GetVouchers(
            //string name = null, string code = null, int? mindiscount = null,
            //int? maxdiscount = null, string tungay = null, string denngay = null
            )
        {

            var vouchers = _context.Voucher.ToList().Select(Mapper.Map<Voucher, VoucherDto>);

            //if (!String.IsNullOrWhiteSpace(name))
            //    vouchers = (List<Voucher>)vouchers.Where(c => c.Name.Contains(name));

            //if (!String.IsNullOrWhiteSpace(code))
            //    vouchers = (List<Voucher>)vouchers.Where(c => c.Code.Contains(code));

            //if(mindiscount != null)
            //{
            //    vouchers = (List<Voucher>)vouchers.Where(c => c.Discount >= mindiscount);
            //}

            //if (maxdiscount != null)
            //{
            //    vouchers = (List<Voucher>)vouchers.Where(c => c.Discount <= maxdiscount);
            //}

            //if (!String.IsNullOrWhiteSpace(tungay))
            //{
            //    DateTime dttungay = DateTime.Parse(tungay);
            //    //DateTime dttungay = DateTime.ParseExact(tungay, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            //    vouchers = (List<Voucher>)vouchers.Where(c => c.StartDate >= dttungay);
            //}

            //if (!String.IsNullOrWhiteSpace(denngay))
            //{
            //    DateTime dtdenngay = DateTime.Parse(denngay);
            //    //DateTime dtdenngay = DateTime.ParseExact(denngay, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            //    vouchers = (List<Voucher>)vouchers.Where(c => c.EndDate <= dtdenngay);
            //}

            return Ok(vouchers);
        }

        public IHttpActionResult GetVoucher(int id)
        {
            var voucher = _context.Voucher.SingleOrDefault(c => c.Id == id);
            if (voucher == null)
                return NotFound();
            return Ok(voucher);
        }

        [HttpPost]
        public IHttpActionResult CreateVoucher(Voucher voucher)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _context.Voucher.Add(voucher);
            _context.SaveChanges();
            return Created(new Uri(Request.RequestUri + "/" + voucher.Id), voucher);
        }

        [HttpPut]
        public IHttpActionResult UpdateVoucher(int id, Voucher voucher)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var voucherInDb = _context.Voucher.SingleOrDefault(c => c.Id == id);

            if (voucherInDb == null)
            {
                return NotFound();
            }
            else
            {
                voucherInDb.Name = voucher.Name;
                voucherInDb.Discount = voucher.Discount;
                voucherInDb.StartDate = voucher.StartDate;
                voucherInDb.EndDate = voucher.EndDate;
            }   
           
            _context.SaveChanges();

            return Ok(voucher);
        }

        [HttpDelete]
        public IHttpActionResult DeleteVoucher(int id)
        {
            var voucherInDb = _context.Voucher.SingleOrDefault(c => c.Id == id);

            if (voucherInDb == null)
                return NotFound();

            _context.Voucher.Remove(voucherInDb);
            _context.SaveChanges();

            return Ok(id);
        }
    }
}