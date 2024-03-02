using Application.Features.Commands.User.Create;
using Application.Features.Commands.User.Login;
using Application.Features.Commands.User.Update;
using Application.Features.Queries.GetCategories;
using Application.Features.Queries.GetCategoryById;
using Application.Features.Queries.GetCategoryNutritions;
using Application.Features.Queries.GetNutritionById;
using Application.Features.Queries.GetNutritionByName;
using Application.Features.Queries.GetNutritions;
using Application.Features.Queries.GetUserDetail;
using AutoMapper;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Nutrition, GetNutritionsQueryModel>();
            CreateMap<Category, GetCategoriesQueryModel>();
            CreateMap<Nutrition, GetNutritionByIdQueryModel>();
            CreateMap<Category, GetCategoryByIdQueryModel>();
            CreateMap<User, GetUserDetailQueryModel>();
            //CreateMap<List<Nutrition>, GetCategoryNutritionsQueryModel>().ReverseMap();
            CreateMap<User, CreateUserCommandRequest>().ReverseMap();
            CreateMap<User, LoginUserCommandModel>();
            CreateMap<UpdateUserCommandRequest, User>();


        }
    }
}
