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
    public class BlogController : ControllerBase
    {
        private readonly Context _context;

        public BlogController(Context context)
        {
            _context = context;
        }

        // GET: api/Blog
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.Blog>>> GetBlogs()
        {
            return await _context.Blogs.ToListAsync();
        }

        // GET: api/Blog/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Blog>> GetBlog(int id)
        {
            var blog = await _context.Blogs.FirstOrDefaultAsync(b=>b.BlogId==id);
            if (blog == null)
            {
                return NotFound();
            }

            return blog;
        }

        // PUT: api/Blog/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBlog(int id, Models.Blog blog)
        {
            if (id != blog.BlogId)
            {
                return BadRequest();
            }

            _context.Entry(blog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlogExists(id))
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

        // POST: api/Blog
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Models.Blog>> PostBlog(Models.Blog blog)
        {
            _context.Blogs.Add(blog);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBlog", new { id = blog.BlogId }, blog);
        }

        // DELETE: api/Blog/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Models.Blog>> DeleteBlog(int id)
        {
            var blog = await _context.Blogs.FindAsync(id);
            if (blog == null)
            {
                return NotFound();
            }

            _context.Blogs.Remove(blog);
            await _context.SaveChangesAsync();

            return blog;
        }

        private bool BlogExists(int id)
        {
            return _context.Blogs.Any(e => e.BlogId == id);
        }
        [HttpGet("page/{id}")]
        public async Task<ActionResult<List<Models.Blog>>> GetBlogByPage(int id)
        {
            return await _context.Blogs.Include(b => b.Sort).OrderByDescending(b => b.ReleaseDate).Skip(10 * (id - 1)).Take(10).ToListAsync();
        }
        [Authorize]
        [HttpPut("{id}/Top")]
        public async Task<ActionResult> ChangeTop(int id)
        {
            if (!BlogExists(id)) 
            {
                return NotFound();
                    }
            var blog = await _context.Blogs.FirstOrDefaultAsync(b => b.BlogId == id);
            if (string.IsNullOrWhiteSpace(blog.CoverImg))
            {
                return Ok(new { state = false, message = "当前博文没有封面图，请添加封面图后重试" });
            }
            blog.Top = blog.Top==1?0 : 1;
            await _context.SaveChangesAsync();
            return Ok(new { state = true, message = "更新置顶状态成功" });
        }
       
        [HttpGet("carousel")]
        public async Task<ActionResult<List<Models.Blog>>> GetCarousel()
        {
            return await _context.Blogs.Where(b => b.Top == 1).ToListAsync();
        }
    }
}
