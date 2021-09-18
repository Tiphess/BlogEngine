using Data.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Models
{
    public class EditPostViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Guid CategoryId { get; set; }
        public DateTime PublicationDate { get; set; }
        public string Content { get; set; }

        public IEnumerable<CategoryDTO> Categories { get; set; }
    }
}
