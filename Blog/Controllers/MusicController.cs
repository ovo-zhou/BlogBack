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
    public class MusicController : ControllerBase
    {
        private readonly Context _context;

        public MusicController(Context context)
        {
            _context = context;
        }
        [HttpPost]
        [Route("CreateMusic")]
        public IActionResult CreateMusic(Music music)
        {
            if (ModelState.IsValid)
            {
                _context.Musics.Add(music);
                _context.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }
        [HttpPost]
        [Route("DeleteMusic")]
        public IActionResult DeleteMusic(int id)
        {
            Music music = _context.Musics.FirstOrDefault(m => m.MusicId == id);
            if (music != null)
            {
                _context.Musics.Remove(music);
                _context.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }
        [HttpGet]
        [Route("GetMusic")]
        public IActionResult GetMusic()
        {
            return Ok(_context.Musics.ToList());
        }
        [HttpPost]
        [Route("UpdateMusic")]
        public IActionResult UpdateMusic(Music music)
        {
           Music updatemusic =_context.Musics.FirstOrDefault(m => m.MusicId == music.MusicId);
            if(updatemusic!=null)
            {
                updatemusic.Name = music.Name;
                updatemusic.Author = music.Author;
                _context.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }
    }
}
