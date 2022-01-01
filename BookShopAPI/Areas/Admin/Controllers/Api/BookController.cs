using BookShopAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookShopAPI.Areas.Admin.Controllers.Api
{
    public class BookController : ApiController
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


        public IHttpActionResult GetBooks()
        {
            var books = _context.Book.ToList();
            return Ok(books);
        }

        public IHttpActionResult GetBook(int id)
        {
            var book = _context.Book.SingleOrDefault(c => c.Id == id);
            if (book == null)
                return NotFound();
            return Ok(book);
        }

        [HttpPost]
        public IHttpActionResult CreateBook(Book book)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _context.Book.Add(book);
            _context.SaveChanges();
            return Created(new Uri(Request.RequestUri + "/" + book.Id), book);
        }


        [HttpPut]
        public IHttpActionResult UpdateBook(int id, Book book)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var bookInDb = _context.Book.SingleOrDefault(c => c.Id == id);

            if (bookInDb == null)
                return NotFound();

            bookInDb.Name = book.Name;

            _context.SaveChanges();

            return Ok(book);
        }

        // DELETE /api/books/1
        [HttpDelete]
        public IHttpActionResult DeleteBook(int id)
        {
            var bookInDb = _context.Book.SingleOrDefault(c => c.Id == id);

            if (bookInDb == null)
                return NotFound();

            _context.Book.Remove(bookInDb);
            _context.SaveChanges();

            return Ok(id);
        }
    }
}