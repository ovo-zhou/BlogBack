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
            if(ModelState.IsValid)
            {
                _context.Sorts.Add(sort);
                _context.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }
    }
}
