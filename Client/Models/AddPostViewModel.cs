using Data.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Models
{
    public class AddPostViewModel
    {
        public IEnumerable<CategoryDTO> Categories { get; set; }
        public PostForm Form { get; set; }
    }
}
