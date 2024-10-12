using Microsoft.AspNetCore.Mvc;
using Serilog;
using FoodRecipe.Common;
using FoodRecipe.Common.DTOs;
using FoodRecipe.Features.Category.AddCategory.Commands;
using FoodRecipe.Features.Users.Login;
using StayCation.VerticalSlicing.Features.Users.Login.Commands;

namespace FoodRecipe.Features.Category.AddCategory
{
    public class AddCategoryController : BaseController
    {
        public AddCategoryController(ControllereParameters controllereParameters) : base(controllereParameters)
        {
        }
        [HttpPost]
        public async Task<ResultDTO> AddCategory(AddCategoryDTO addCategory)
        {

            var result = await _mediator.Send(new AddCategoryCommand(addCategory));

            return result;
        }

    }
}
