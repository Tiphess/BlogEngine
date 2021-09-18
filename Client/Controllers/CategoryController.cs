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
    public class CategoryController : Controller
    {
        private readonly BlogEngineService _service;
        private readonly IMapper _mapper;
        private readonly CategoryRepository _categoryRepo;

        public CategoryController(BlogEngineService service, BlogEngineContext context, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
            _categoryRepo = new CategoryRepository(context);
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EditCategory(Guid id)
        {
            var model = _service.Request<CategoryDTO>(HttpMethod.Get, UriProvider.Category.GetById(id));
            return View(model);
        }

        [HttpPost]
        public IActionResult AddCategory(CategoryForm form)
        {
            try
            {
                var categoryToAdd = _mapper.Map<Category>(form);
                _categoryRepo.Add(categoryToAdd);
            }
            catch (Exception)
            {
                TempData[Constants.ACTION_MESSAGE] = "Add Category Failed";
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult EditCategory(CategoryForm form)
        {
            try
            {
                var categoryToEdit = _mapper.Map<Category>(form);
                _categoryRepo.Edit(categoryToEdit);
            }
            catch (Exception)
            {
                TempData[Constants.ACTION_MESSAGE] = "Add Category Failed";
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
