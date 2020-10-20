using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models;
using Blog.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Bcpg;

namespace Blog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticateService _authService;
        private readonly Context _context; 
        public AuthenticationController(IAuthenticateService authService,Context context)
        {
            this._authService = authService;
            _context = context;
        }
        [HttpPost]
        [Route("Login")]
        public ActionResult Login(string username,string password)
        {
            List<User> users = _context.Users.Where(u => u.UserName.Contains(username)).ToList();
            if (users.Count() == 0) 
            {
                return BadRequest("用户不存在");
            }
            if (users[0].Password == password.Trim())
            {
                return Ok(this._authService.GetToken(username));
            }
            else
            {
               return BadRequest("密码错误");
            }
        }
    }
}
