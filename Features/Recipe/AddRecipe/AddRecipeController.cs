using Microsoft.AspNetCore.Mvc;
using FoodRecipe.Common;
using FoodRecipe.Common.DTOs;
using FoodRecipe.Features.Recipe.Add_Recipe.Commands;

namespace FoodRecipe.Features.Recipe.Add_Recipe
{
    public class GetRecipeByIdController : BaseController
    {
        public GetRecipeByIdController(ControllereParameters controllereParameters) : base(controllereParameters)
        {
        }
        [HttpPost]
        public async Task<ResultDTO> AddRecipe(AddRecipeDTO addRecipeDTO)
        {
            var result = await _mediator.Send(new AddRecipeCommand(addRecipeDTO));

            return ResultDTO.Success(result.Data);
        }
    }
}
