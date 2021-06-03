using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private IWebHostEnvironment _host;

        public FileController(IWebHostEnvironment host)
        {
            _host = host;
        }
        [Authorize]
        [HttpPost]
        [Route("FileUpload")]
        //先统一将文件保存在wwwroot/upload下
        public async Task<IActionResult> FileUpload(IFormFile file)
        {
            if (file.Length == 0)
            {
                return BadRequest();
            }
            string fileFolder = Path.Combine(_host.WebRootPath, "upload", DateTime.Now.Year.ToString(), DateTime.Now.Month.ToString());//文件保存的文件夹
            if (!Directory.Exists(fileFolder))
            {
                Directory.CreateDirectory(fileFolder);
            }
            string newFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);//生成唯一的文件名
            string filePath = Path.Combine(fileFolder, newFileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            return Ok(Path.Combine("upload", DateTime.Now.Year.ToString(), DateTime.Now.Month.ToString(), newFileName));
        }
        [Authorize]
        [HttpPost]
        [Route("FileDelete")]
        public IActionResult FileDelete(string fileName)
        {
            if (!string.IsNullOrEmpty(fileName))
            {
                string filePath = Path.Combine(_host.WebRootPath, "upload", fileName);
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                    return Ok("删除成功");
                }
                return NotFound("没有找到该文件");
            }
            return BadRequest("请求参数有误");
        }
        /// <summary>
        /// tinymce编辑器的图片上传
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        //[Authorize]
        [HttpPost]
        [Route("ImgUpload")]
        public async Task<IActionResult> ImgUpload(IFormFile file)
        {
            if (file==null||file.Length==0)
            {
                return BadRequest();
            }
            string fileFolder = Path.Combine(_host.WebRootPath, "upload", DateTime.Now.Year.ToString(), DateTime.Now.Month.ToString());//文件保存的文件夹
            if (!Directory.Exists(fileFolder))
            {
                Directory.CreateDirectory(fileFolder);
            }
            string newFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);//生成唯一的文件名
            string filePath = Path.Combine(fileFolder, newFileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            return Ok(new { location = Path.Combine(@"\upload", DateTime.Now.Year.ToString(), DateTime.Now.Month.ToString(), newFileName) });

        }
    }
}
