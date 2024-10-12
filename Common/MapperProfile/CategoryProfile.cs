using AutoMapper;
using FoodRecipe.Data.Models;
using FoodRecipe.Features.Category.AddCategory;

namespace FoodRecipe.Common.MapperProfile
{
    public class CategoryProfile: Profile
    {
        public CategoryProfile() 
        {
            CreateMap<Category,AddCategoryDTO>().ReverseMap();
        }

    }
}
