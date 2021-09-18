using Data.DTOs;
using AutoMapper;
using Data.Entities;

namespace Api.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDTO>();
        }
    }
}
