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
        [HttpPost]
        [Route("FileUpload")]
        //先统一将文件保存在wwwroot/upload下
        public async Task<IActionResult> FileUpload(IFormFile file)
        {
            if (file.Length > 0)
            {
                string fileFolder = Path.Combine(_host.WebRootPath, "upload");//文件保存的文件夹
                string newFileName = Guid.NewGuid().ToString() + "_" + file.FileName;//生成唯一的文件名
                string filePath = Path.Combine(fileFolder, newFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
                return Ok(newFileName);
            }
            return BadRequest();
        }
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
        [HttpPost]
        [Route("ImgUpload")]
        //单个图片文件上传，主要用于富文本编辑器的文件上传
        public async Task<IActionResult> ImgUpload(IFormFile file)
        {
            if (file == null)
            {
                return BadRequest("文件为空");
            }
            string fileFolder = Path.Combine(_host.WebRootPath, "upload");//文件保存的文件夹
            string newFileName = Guid.NewGuid().ToString() + "_" + file.FileName;//生成唯一的文件名
            string filePath = Path.Combine(fileFolder, newFileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            return Ok(new { location = "/upload/" + newFileName });
        }
    }
}
