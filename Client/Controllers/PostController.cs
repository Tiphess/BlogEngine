using AutoMapper;
using Client.Api;
using Client.Models;
using Client.Utils;
using Data;
using Data.DTOs;
using Data.Entities;
using Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
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
        public IActionResult Add()
        {
            if (TempData[Constants.ACTION_MESSAGE] != null)
                ViewBag.Error = TempData[Constants.ACTION_MESSAGE];

            PostForm form = null;
            if (TempData[Constants.POST_FORM] != null)
                form = JsonConvert.DeserializeObject<PostForm>((string)TempData[Constants.POST_FORM]);

            var model = new AddPostViewModel
            {
                Categories = _service.Request<IEnumerable<CategoryDTO>>(HttpMethod.Get, UriProvider.Category.GET_LIST),
                Form = form
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            if (TempData[Constants.ACTION_MESSAGE] != null)
                ViewBag.Error = TempData[Constants.ACTION_MESSAGE];

            var post = _service.Request<PostDTO>(HttpMethod.Get, UriProvider.Post.GetById(id));

            var model = _mapper.Map<EditPostViewModel>(post);
            model.Categories = _service.Request<IEnumerable<CategoryDTO>>(HttpMethod.Get, UriProvider.Category.GET_LIST);

            return View(model);
        }

        [HttpGet]
        public IActionResult IsUniqueTitle(string title, Guid? id = null)
        {
            var posts = _service.Request<IEnumerable<PostDTO>>(HttpMethod.Get, UriProvider.Post.GET_LIST);

            if (id.HasValue)
                return Json(!posts.Any(p => p.Title == title && p.Id != id));

            return Json(!posts.Any(p => p.Title == title));
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
                TempData[Constants.ACTION_MESSAGE] = "Add Post failed.";
                TempData[Constants.POST_FORM] = JsonConvert.SerializeObject(form);
                return RedirectToAction("Add", "Post");
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
                TempData[Constants.ACTION_MESSAGE] = "Edit Post failed.";
                return RedirectToAction("Edit", "Post", new { id = form.Id });
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
