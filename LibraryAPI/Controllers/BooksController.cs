using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    public class BooksController : Controller,IEntityController<Books>
    {
        [HttpPost]
        public IActionResult Add([FromBody] Books entity)
        {
            if (entity == null) return BadRequest();
            var context = new libraryContext();
            context.Books.Add(entity);
            context.SaveChanges();
            if (entity.Id > 0)
            {
                return Ok(entity);
            }

            return BadRequest();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var context = new libraryContext();
            return Ok(context.Books.Find(id));
        }

        [HttpPut]
        public IActionResult Update([FromBody] Books entity)
        {
            var context = new libraryContext();
            context.Update(entity);
            context.SaveChanges();
            return Ok(entity);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var context = new libraryContext();
            return Ok(context.Books.ToList());
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var context = new libraryContext();
            context.Books.Remove(context.Books.Find(id));
            context.SaveChanges();
            return Ok(context.Books.ToList());
        }
    }
}