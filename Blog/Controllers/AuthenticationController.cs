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
        public ActionResult Login(User user)
        {
            if(ModelState.IsValid)
            {
                User userFromDb= _context.Users.FirstOrDefault(u => u.UserName == user.UserName);
                if(userFromDb!=null)
                {
                    if (userFromDb.Password == user.Password) {

                        return Ok(this._authService.GetToken(user.UserName));
                    }
                    return BadRequest("密码错误");
                }
                return BadRequest("用户不存在");
            }
            return BadRequest("参数不完整");
        }
    }
}
