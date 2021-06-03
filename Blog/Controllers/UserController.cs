using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Blog.Models;
using Blog.ApiModel;
using Microsoft.AspNetCore.Authorization;

namespace Blog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly Context _context;

        public UserController(Context context)
        {
            _context = context;
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult> GetUsers()
        {
            var user= await _context.Users.FirstOrDefaultAsync();
            if (user==null) 
            {
                return NotFound();
            }
            UserWithApi userWithApi = new UserWithApi()
            {
                UserId=user.UserId,
                UserAvatar = user.UserAvatar,
                NickName=user.NickName,
                Introduction=user.Introduction,
                Motto=user.Motto
            };
            return Ok(userWithApi);
        }
        // PUT: api/User/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, UserWithApi userWithApi)
        {
            if (id != userWithApi.UserId)
            {
                return BadRequest();
            }
            if (UserExists(id))
            {
                var user= await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);
                user.UserAvatar = userWithApi.UserAvatar;
                user.NickName = userWithApi.NickName;
                user.Introduction = userWithApi.Introduction;
                user.Motto = userWithApi.Motto;
                await _context.SaveChangesAsync();
                return Ok();
            }
            return NotFound();
        }
        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }
    }
}
