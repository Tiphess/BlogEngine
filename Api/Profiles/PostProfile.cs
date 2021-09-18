using Data.DTOs;
using AutoMapper;
using Data.Entities;

namespace Api.Profiles
{
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            CreateMap<Post, PostDTO>();
        }
    }
}
