using AutoMapper;
using Client.Models;
using Data.DTOs;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Profiles
{
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            CreateMap<PostDTO, EditPostViewModel>()
                .ForMember(e => e.Categories, options => options.Ignore());
            CreateMap<PostForm, Post>()
                .ForMember(p => p.Category, options => options.Ignore());
        }
    }
}
