using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.DTOs
{
    public class PostDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime PublicationDate { get; set; }
        public string Content { get; set; }
        public Guid CategoryId { get; set; }
    }
}
