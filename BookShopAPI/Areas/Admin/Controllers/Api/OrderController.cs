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
    public class OrderController : ApiController
    {
        private ApplicationDbContext _context;
        public OrderController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        public IHttpActionResult GetOrders()
        {
            var orders = _context.Orders.ToList().Select(Mapper.Map<Orders, OrderDto>);
            return Ok(orders);
        }
    }
}
