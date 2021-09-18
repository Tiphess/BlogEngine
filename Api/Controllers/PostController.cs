using Data.DTOs;
using AutoMapper;
using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("posts")]
    public class PostController : Controller
    {
        private readonly BlogEngineContext _context;
        private readonly IMapper _mapper;

        public PostController(BlogEngineContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var posts = _context.Posts.Where(p => p.PublicationDate <= DateTime.Now)
                                      .OrderByDescending(p => p.PublicationDate)
                                      .ToList();
            if (posts.Count == 0)
                return NoContent();

            var dtos = _mapper.Map<IEnumerable<PostDTO>>(posts);
            return Ok(dtos);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(Guid id)
        {
            var post = _context.Posts.FirstOrDefault(p => p.Id == id);

            if (post == null)
                return NotFound();

            var dto = _mapper.Map<PostDTO>(post);
            return Ok(dto);
        }
    }
}
