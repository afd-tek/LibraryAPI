using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    public class DebtsController : Controller, IEntityController<Debts>
    {
        [HttpPost]
        public IActionResult Add([FromBody] Debts entity)
        {
            if (entity == null) return BadRequest();
            var context = new libraryContext();
            context.Debts.Add(entity);
            context.SaveChanges();
            if (entity.Debtor > 0)
            {
                return Ok(entity);
            }

            return BadRequest();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var context = new libraryContext();
            return Ok(context.Debts.Find(id));
        }

        [HttpPut]
        public IActionResult Update([FromBody] Debts entity)
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
            return Ok(context.Debts.ToList());
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var context = new libraryContext();
            context.Debts.Remove(context.Debts.Find(id));
            context.SaveChanges();
            return Ok(context.Debts.ToList());
        }
    }
}
