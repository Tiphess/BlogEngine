using AutoMapper;
using Client.Api;
using Client.Models;
using Client.Utils;
using Data;
using Data.DTOs;
using Data.Entities;
using Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
        public IActionResult Add()
        {
            if (TempData[Constants.ACTION_MESSAGE] != null)
                ViewBag.Error = TempData[Constants.ACTION_MESSAGE];

            CategoryForm form = null;
            if (TempData[Constants.CATEGORY_FORM] != null)
                form = JsonConvert.DeserializeObject<CategoryForm>((string)TempData[Constants.CATEGORY_FORM]);

            return View(form);
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            if (TempData[Constants.ACTION_MESSAGE] != null)
                ViewBag.Error = TempData[Constants.ACTION_MESSAGE];

            var model = _service.Request<CategoryDTO>(HttpMethod.Get, UriProvider.Category.GetById(id));
            return View(model);
        }

        [HttpGet]
        public IActionResult IsUniqueTitle(string title, Guid? id = null)
        {
            var categories = _service.Request<IEnumerable<CategoryDTO>>(HttpMethod.Get, UriProvider.Category.GET_LIST);

            if (id.HasValue)
                return Json(!categories.Any(c => c.Title == title && c.Id != id));

            return Json(!categories.Any(c => c.Title == title));
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
                TempData[Constants.ACTION_MESSAGE] = "Add Category failed.";
                TempData[Constants.CATEGORY_FORM] = JsonConvert.SerializeObject(form);
                return RedirectToAction("Add", "Category");
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
                TempData[Constants.ACTION_MESSAGE] = "Edit Category failed.";
                return RedirectToAction("Edit", "Category", new { id = form.Id });
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
