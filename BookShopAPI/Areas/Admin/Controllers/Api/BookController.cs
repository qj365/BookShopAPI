using AutoMapper;
using BookShopAPI.Areas.Admin.ViewModel;
using BookShopAPI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
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
        public IHttpActionResult CreateBook(BookViewModel bookvm)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var book = Mapper.Map<BookViewModel, Book>(bookvm);
            _context.Book.Add(book);
            _context.SaveChanges();
            bookvm.Id = book.Id;
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
            bookInDb.Discount = book.Discount;
            bookInDb.Price = book.Price;
            bookInDb.Amount = book.Amount;
            bookInDb.Description = book.Description;
            bookInDb.IdAuthor = book.IdAuthor;
            bookInDb.IdCategory = book.IdCategory;
            bookInDb.IdPublisher = book.IdPublisher;
            bookInDb.Price = book.Price;


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