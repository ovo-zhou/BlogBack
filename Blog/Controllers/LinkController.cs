
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
    public class LinkController : ControllerBase
    {
        private readonly Context _context;

        public LinkController(Context context)
        {
            _context = context;
        }
        [HttpGet("GetLink")]
        public IActionResult GetLink()
        {
            return Ok(_context.Links.ToList());
        }
        [HttpPost("DeleteLink")]
        public IActionResult DeleteLink(int id)
        {
            var link = _context.Links.FirstOrDefault(l => l.Id == id);
            if (link != null)
            {
                _context.Links.Remove(link);
                _context.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }
        [HttpPost("CreateLink")]
        public IActionResult CreateLink(Link link)
        {
            if(ModelState.IsValid)
            {
                _context.Links.Add(link);
                _context.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }
        [HttpPost("UpdateLink")]
        public IActionResult UpdateLink(Link link)
        {
            var updateLink= _context.Links.FirstOrDefault(l=>l.Id==link.Id);
            if(updateLink!=null)
            {
                updateLink.LinkIcon = link.LinkIcon;
                updateLink.LinkName = link.LinkName;
                updateLink.Url = link.Url;
                _context.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }
    }
}
