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
    public class CategoryController : ApiController
    {
        private ApplicationDbContext _context;
        public CategoryController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public IHttpActionResult GetCategorys()
        {
            var cates = _context.Category.ToList().Select(Mapper.Map<Category, CategoryDto>); 
            return Ok(cates);
        }

        public IHttpActionResult GetCategory(int id)
        {
            var cate = _context.Category.SingleOrDefault(c => c.Id == id);
            if (cate == null)
                return NotFound();
            return Ok(cate);
        }

        [HttpPost]
        public IHttpActionResult CreateCategory(Category cate)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _context.Category.Add(cate);
            _context.SaveChanges();
            return Created(new Uri(Request.RequestUri + "/" + cate.Id), cate);
        }


        [HttpPut]
        public IHttpActionResult UpdateCategory(int id, Category cate)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var cateInDb = _context.Category.SingleOrDefault(c => c.Id == id);

            if (cateInDb == null)
                return NotFound();

            cateInDb.Name = cate.Name;

            _context.SaveChanges();

            return Ok(cate);
        }

        // DELETE /api/categorys/1
        [HttpDelete]
        public IHttpActionResult DeleteCategory(int id)
        {
            var cateInDb = _context.Category.SingleOrDefault(c => c.Id == id);

            if (cateInDb == null)
                return NotFound();

            _context.Category.Remove(cateInDb);
            _context.SaveChanges();

            return Ok(id);
        }
    }
}