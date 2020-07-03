using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    public class RoomsController : Controller, IEntityController<Rooms>
    {
        [HttpPost]
        public IActionResult Add([FromBody]Rooms entity)
        {
            if (entity == null) return BadRequest();
            var context = new libraryContext();
            context.Rooms.Add(entity);
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
            return Ok(context.Rooms.Find(id));
        }

        [HttpPut]
        public IActionResult Update([FromBody]Rooms entity)
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
            return Ok(context.Rooms.ToList());
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var context = new libraryContext();
            context.Rooms.Remove(context.Rooms.Find(id));
            context.SaveChanges();
            return Ok(context.Rooms.ToList());
        }
    }
}