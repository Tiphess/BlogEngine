using Data.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Models
{
    public class IndexViewModel
    {
        public IndexViewModel()
        {
            Posts = new List<PostDTO>();
            Categories = new List<CategoryDTO>();
        }

        public IEnumerable<PostDTO> Posts { get; set; }
        public IEnumerable<CategoryDTO> Categories { get; set; }
    }
}
