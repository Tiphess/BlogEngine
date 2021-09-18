using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Models
{
    public class PostForm
    {
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public Guid CategoryId { get; set; }
        [Required]
        public DateTime PublicationDate { get; set; }
        [Required]
        public string Content { get; set; }
    }
}
