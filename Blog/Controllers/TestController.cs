using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        [Route("Get")]
        public IActionResult Get(DateTime dateTime)
        {
            return Ok(dateTime);
        }
        [HttpPost]
        [Route("post")]
        public ActionResult Post(string name)
        {
            return Ok(name);
        }
    }
}
