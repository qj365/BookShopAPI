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
    public class AuthorController : ApiController
    {
        private ApplicationDbContext _context;
        public AuthorController()
        {
            _context = new ApplicationDbContext();
        }


        public IHttpActionResult GetAuthors()
        {
            var authors = _context.Author.ToList();
            return Ok(authors);
        }

        public IHttpActionResult GetAuthor(int id)
        {
            var author = _context.Author.SingleOrDefault(c => c.Id == id);
            if (author == null)
                return NotFound();
            return Ok(author);
        }

        [HttpPost]
        public IHttpActionResult CreateAuthor(Author author)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _context.Author.Add(author);
            _context.SaveChanges();
            return Created(new Uri(Request.RequestUri + "/" + author.Id), author);
        }


        [HttpPut]
        public IHttpActionResult UpdateAuthor(int id, Author author)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var authorInDb = _context.Author.SingleOrDefault(c => c.Id == id);

            if (authorInDb == null)
                return NotFound();

            authorInDb.Name = author.Name;

            _context.SaveChanges();

            return Ok(author);
        }

        // DELETE /api/authors/1
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var authorInDb = _context.Author.SingleOrDefault(c => c.Id == id);

            if (authorInDb == null)
                return NotFound();

            _context.Author.Remove(authorInDb);
            _context.SaveChanges();

            return Ok(id);
        }

    }
}
