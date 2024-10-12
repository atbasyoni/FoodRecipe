using Microsoft.AspNetCore.Mvc;
using FoodRecipe.Common;
using FoodRecipe.Common.DTOs;
using FoodRecipe.Features.Recipe.DeleteRecipe.Commands;

namespace FoodRecipe.Features.Recipe.DeleteRecipe
{
    public class DeleteRecipeController : BaseController
    {
        public DeleteRecipeController(ControllereParameters controllereParameters) : base(controllereParameters)
        {
        }
        [HttpPost]
        public async Task<ResultDTO> DeleteRecipe(int id)
        {
            var result = await _mediator.Send(new DeleteRecipeCommand(id));

            return ResultDTO.Success(result.Data);
        }
    }
}
