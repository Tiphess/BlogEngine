using Data.DTOs;
using AutoMapper;
using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("categories")]
    public class CategoryController : ControllerBase
    {
        private readonly BlogEngineContext _context;
        private readonly IMapper _mapper;

        public CategoryController(BlogEngineContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var categories = _context.Categories.OrderBy(c => c.Title)
                                                .ToList();

            if (categories.Count == 0)
                return NoContent();

            var dtos = _mapper.Map<IEnumerable<CategoryDTO>>(categories);
            return Ok(dtos);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(Guid id)
        {
            var category = _context.Categories.FirstOrDefault(p => p.Id == id);

            if (category == null)
                return NotFound();

            var dto = _mapper.Map<CategoryDTO>(category);
            return Ok(dto);
        }

        [HttpGet]
        [Route("{id}/posts")]
        public IActionResult GetPosts(Guid id)
        {
            var category = _context.Categories.Include(c => c.Posts)
                                              .FirstOrDefault(p => p.Id == id);

            var posts = category.Posts.Where(p => p.PublicationDate <= DateTime.Now)
                                      .OrderByDescending(p => p.PublicationDate)
                                      .ToList();
            if (posts.Count == 0)
                return NoContent();

            var dtos = _mapper.Map<IEnumerable<PostDTO>>(category.Posts);
            return Ok(dtos);
        }
    }
}
