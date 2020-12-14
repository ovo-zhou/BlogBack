using Blog.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SortController : ControllerBase
    {
        private readonly Context _context;
        public SortController(Context context)
        {
            _context = context;
        }
        [HttpPost]
        [Route("AddSort")]
        public IActionResult AddSort(Sort sort)
        {
            if (ModelState.IsValid)
            {
                _context.Sorts.Add(sort);
                _context.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }
        [HttpPost]
        [Route("UpdateSort")]
        public IActionResult UpdateSort(Sort sort)
        {
            if (ModelState.IsValid)
            {
                Sort updateSort = _context.Sorts.FirstOrDefault(s => s.SortId == sort.SortId);
                updateSort.SortName = sort.SortName;
                _context.Sorts.Attach(updateSort).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }
        [HttpGet]
        [Route("DeleteSort")]
        public IActionResult DeleteSort(int id)
        {
            var sort= _context.Sorts.FirstOrDefault(s => s.SortId == id);
            if (sort != null)
            {
                _context.Sorts.Remove(sort);
                _context.SaveChanges();
                return Ok();
            }
            return NoContent();
        }
    }
}
