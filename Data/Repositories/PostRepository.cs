using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Repositories
{
    public class PostRepository : IRepository<Post>
    {
        private readonly BlogEngineContext _context;

        public PostRepository(BlogEngineContext context)
        {
            _context = context;
        }

        public void Add(Post post)
        {
            _context.Posts.Add(post);
            _context.SaveChanges();
        }

        public void Edit(Post post)
        {
            var postToEdit = _context.Posts.FirstOrDefault(p => p.Id == post.Id);
            postToEdit.Title = post.Title;
            postToEdit.PublicationDate = post.PublicationDate;
            postToEdit.Content = post.Content;
            postToEdit.CategoryId = post.CategoryId;

            _context.SaveChanges();
        }
    }
}
