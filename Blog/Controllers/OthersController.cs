using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Blog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OthersController : ControllerBase
    {
        [HttpGet]
        [Route("weather")]
        public async Task<string> Weather(string cityName)
        {
            string url = $"https://tianqiapi.com/api?version=v1&appid=73469837&appsecret=UT6p7f2w&city={cityName}";
            string responseBody = "";
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                responseBody = await response.Content.ReadAsStringAsync();
            }
            return responseBody;
        }
    }
}
