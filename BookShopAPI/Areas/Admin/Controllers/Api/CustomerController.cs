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
    public class CustomerController : ApiController
    {
        private ApplicationDbContext _context;
        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        
        public IHttpActionResult GetCustomers()
        {
            var customers = _context.Customer.ToList().Select(Mapper.Map<Customer, CustomerDto>);
            return Ok(customers);
        }

        [HttpDelete]
        public IHttpActionResult DeleteVoucher(int id)
        {
            var customerInDb = _context.Customer.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                return NotFound();

            _context.Customer.Remove(customerInDb);
            _context.SaveChanges();

            return Ok(id);
        }
    }
}