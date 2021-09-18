using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class Category
    {
        public Category()
        {
            Posts = new List<Post>();
        }

        public Guid Id { get; set; }
        public string Title { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}
