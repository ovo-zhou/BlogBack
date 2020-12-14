using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Blog.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

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
        [HttpGet]
        [Route("GetPreface")]
        public async Task<IActionResult> GetPreface()
        {
            var preface= await _context.Sorts.ToListAsync();
            return Ok(preface);
        }
        [HttpGet]
        [Route("GetTitleBySortId")]
        public async Task<IActionResult> GetTitleBySortId(int sortId)
        {
            var bloglist= await _context.Blogs.Where(b => b.SortId == sortId).ToListAsync();
            return Ok(bloglist);
        }
        //添加博客
        [HttpPost]
        [Route("AddBlog")]
        public IActionResult AddBlog(Models.Blog blog)
        {
            if(ModelState.IsValid)
            {
                if(_context.Sorts.Any(s => s.SortId == blog.SortId))
                {
                    _context.Blogs.Add(blog);
                    _context.SaveChanges();
                    return Ok();
                }
                return BadRequest("外键不完整");
            }
            return BadRequest("参数不完整");
        }
        [HttpPost]
        [Route("UpdateBlog")]
        public IActionResult UpdateBlog(Models.Blog blog)
        {
            if(ModelState.IsValid)
            {
                Models.Blog updateBlog = _context.Blogs.FirstOrDefault(b=>b.BlogId==blog.BlogId);
                updateBlog.Title = blog.Title;
                updateBlog.ReleaseDate = blog.ReleaseDate;
                updateBlog.Content = blog.Content;
                _context.Blogs.Attach(updateBlog).State= Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }
        [HttpGet]
        [Route("DeleteBlog")]
        public IActionResult DeleteBlog(int id)
        {
           var blog=  _context.Blogs.FirstOrDefault(b => b.BlogId == id);
            if(blog!=null)
            {
                _context.Blogs.Remove(blog);
                _context.SaveChanges();
                return Ok();
            }
            return NoContent();
        }
    }
}
