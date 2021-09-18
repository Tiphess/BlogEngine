using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        private readonly BlogEngineContext _context;

        public CategoryRepository(BlogEngineContext context)
        {
            _context = context;
        }

        public void Add(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void Edit(Category category)
        {
            var categoryToEdit = _context.Categories.FirstOrDefault(c => c.Id == category.Id);
            categoryToEdit.Title = category.Title;

            _context.SaveChanges();
        }
    }
}
