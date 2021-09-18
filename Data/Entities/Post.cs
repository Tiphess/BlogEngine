using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class Post
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime PublicationDate { get; set; }
        public string Content { get; set; }

        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
