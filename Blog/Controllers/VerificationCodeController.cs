using Blog.Service;
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
    public class VerificationCodeController : ControllerBase
    {
        private IVerificationCode _verificationCode;
        public VerificationCodeController(IVerificationCode verificationCod)
        {
            _verificationCode = verificationCod;
        }
        [HttpGet]
        public ActionResult GetVrificationCode(string uuid)
        {
            if (string.IsNullOrWhiteSpace(uuid))
            {
                return BadRequest();
            }
            return Ok( _verificationCode.GetVerificationCode(uuid));
        }
        [HttpPost]
        public ActionResult CheckCode(string uuid,string code)
        {
            if (string.IsNullOrWhiteSpace(uuid) || string.IsNullOrWhiteSpace(code))
            {
                return BadRequest();
            }
            return Ok(_verificationCode.CheckCode(uuid, code));
        }
    }
}
