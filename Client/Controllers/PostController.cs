using AutoMapper;
using Client.Api;
using Client.Models;
using Client.Utils;
using Data;
using Data.DTOs;
using Data.Entities;
using Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Client.Controllers
{
    public class PostController : Controller
    {
        private readonly BlogEngineService _service;
        private readonly IMapper _mapper;
        private readonly PostRepository _postRepo;

        public PostController(BlogEngineService service, BlogEngineContext context, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
            _postRepo = new PostRepository(context);
        }

        [HttpGet]
        public IActionResult AddPost()
        {
            var model = _service.Request<IEnumerable<CategoryDTO>>(HttpMethod.Get, UriProvider.Category.GET_LIST);
            return View(model);
        }

        [HttpGet]
        public IActionResult EditPost(Guid id)
        {
            var post = _service.Request<PostDTO>(HttpMethod.Get, UriProvider.Post.GetById(id));

            var model = _mapper.Map<EditPostViewModel>(post);
            model.Categories = _service.Request<IEnumerable<CategoryDTO>>(HttpMethod.Get, UriProvider.Category.GET_LIST);

            return View(model);
        }

        [HttpPost]
        public IActionResult AddPost(PostForm form)
        {
            try
            {
                var postToAdd = _mapper.Map<Post>(form);
                _postRepo.Add(postToAdd);
            }
            catch (Exception)
            {
                TempData[Constants.ACTION_MESSAGE] = "Add Post Failed";
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult EditPost(PostForm form)
        {
            try
            {
                var postToEdit = _mapper.Map<Post>(form);
                _postRepo.Edit(postToEdit);
            }
            catch (Exception)
            {
                TempData[Constants.ACTION_MESSAGE] = "Edit Post Failed";
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
