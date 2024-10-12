using Microsoft.AspNetCore.Mvc;
using FoodRecipe.Common;
using FoodRecipe.Common.DTOs;
using FoodRecipe.Features.Recipe.GetRecipeById.Queries;

namespace FoodRecipe.Features.Recipe.GetRecipeById
{
    public class DeleteRecipeController : BaseController
    {
        public DeleteRecipeController(ControllereParameters controllereParameters) : base(controllereParameters)
        {
        }
        [HttpPost]
        public async Task<ResultDTO> GetRecipeById(int id)
        {
            var result = await _mediator.Send(new GetRecipeByIdQuery(id));

            return ResultDTO.Success(result.Data);
        }
    }
}
