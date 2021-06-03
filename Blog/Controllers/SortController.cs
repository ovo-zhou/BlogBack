using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Blog.Models;
using Microsoft.AspNetCore.Authorization;

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

        // GET: api/Sorts
        [HttpGet]
        public async Task<ActionResult> GetSorts()
        {
            var sorts= await _context.Sorts.Include(s=>s.Blogs).ToListAsync();
            var query = from sort in sorts
                        select new { sort.SortId, sort.SortName, sort.Blogs.ToList().Count };
            return Ok(query);
        }

        // GET: api/Sorts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sort>> GetSort(int id)
        {
            var sort = await _context.Sorts.FindAsync(id);

            if (sort == null)
            {
                return NotFound();
            }

            return sort;
        }
        // GET: api/Sorts/5/Blogs
        [HttpGet("{id}/Blogs")]
        public async Task<ActionResult<List<Models.Blog>>> GetBlogsBySortId(int id)
        {
            var blogs = await _context.Blogs.Where(s=>s.SortId==id).ToListAsync();

            if (blogs == null)
            {
                return NotFound();
            }

            return blogs;
        }
        // PUT: api/Sorts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSort(int id, Sort sort)
        {
            if (id != sort.SortId)
            {
                return BadRequest();
            }

            _context.Entry(sort).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SortExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Sorts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Sort>> PostSort(Sort sort)
        {
            _context.Sorts.Add(sort);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSort", new { id = sort.SortId }, sort);
        }

        // DELETE: api/Sorts/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Sort>> DeleteSort(int id)
        {
            var sort = await _context.Sorts.FindAsync(id);
            if (sort == null)
            {
                return NotFound();
            }

            _context.Sorts.Remove(sort);
            await _context.SaveChangesAsync();

            return sort;
        }

        private bool SortExists(int id)
        {
            return _context.Sorts.Any(e => e.SortId == id);
        }
    }
}
