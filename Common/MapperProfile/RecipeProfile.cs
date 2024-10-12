using AutoMapper;
using FoodRecipe.Data.Models;
using FoodRecipe.Features.Recipe.Add_Recipe;
using FoodRecipe.Features.Recipe.GetRecipeById;

namespace FoodRecipe.Common.MapperProfile
{
    public class RecipeProfile : Profile
    {
        public RecipeProfile()
        {
            CreateMap<Recipe, AddRecipeDTO>();
            CreateMap<Recipe, RecipeReturnDTO>();
        }
    }
}
