using AutoMapper;
using Client.Api;
using Client.Models;
using Client.Utils;
using Data;
using Data.DTOs;
using Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly BlogEngineService _service;
        private readonly IMapper _mapper;

        public HomeController(BlogEngineService service, BlogEngineContext context, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            if (TempData[Constants.ACTION_MESSAGE] != null)
                ViewBag.Error = TempData[Constants.ACTION_MESSAGE];

            var model = new IndexViewModel
            {
                Posts = _service.Request<IEnumerable<PostDTO>>(HttpMethod.Get, UriProvider.Post.GET_LIST),
                Categories = _service.Request<IEnumerable<CategoryDTO>>(HttpMethod.Get, UriProvider.Category.GET_LIST)
            };
            
            return View(model);
        }
    }
}
