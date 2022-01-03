using AutoMapper;
using BookShopAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookShopAPI.Areas.Admin.Controllers.Api
{
    public class PublisherController : ApiController
    {
        private ApplicationDbContext _context;
        public PublisherController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        public IHttpActionResult GetPublisher()
        {
            var publishers = _context.Publisher.ToList();
            return Ok(publishers);
        }

        public IHttpActionResult GetPublisher(int id)
        {
            var publisher = _context.Publisher.SingleOrDefault(c => c.Id == id);
            if (publisher == null)
                return NotFound();
            return Ok(publisher);
        }

        [HttpPost]
        public IHttpActionResult CreatePublisher(Publisher publisher)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _context.Publisher.Add(publisher);
            _context.SaveChanges();
            return Created(new Uri(Request.RequestUri + "/" + publisher.Id), publisher);
        }


        [HttpPut]
        public IHttpActionResult UpdatePublisher(int id, Publisher publisher)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var publisherInDb = _context.Publisher.SingleOrDefault(c => c.Id == id);

            if (publisherInDb == null)
                return NotFound();

            publisherInDb.Name = publisher.Name;
            publisherInDb.Address = publisher.Address;
            publisherInDb.Website = publisher.Website;

            _context.SaveChanges();

            return Ok(publisher);
        }

        // DELETE /api/authors/1
        [HttpDelete]
        public IHttpActionResult DeletePublisher(int id)
        {
            var publisherInDb = _context.Publisher.SingleOrDefault(c => c.Id == id);

            if (publisherInDb == null)
                return NotFound();

            _context.Publisher.Remove(publisherInDb);
            _context.SaveChanges();

            return Ok(id);
        }

    }
}
