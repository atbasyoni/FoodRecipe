using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FoodRecipe.Common;
using FoodRecipe.Common.Attributes;
using FoodRecipe.Common.DTOs;
using FoodRecipe.Common.Enums;
using FoodRecipe.Common.Helpers;
using FoodRecipe.Features.Admin.CreateRole.Commands;
using StayCation.VerticalSlicing.Features.Admin.CreateRole;

namespace FoodRecipe.Features.Admin.CreateRole
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreateRoleController : BaseController
    {
        public CreateRoleController(ControllereParameters controllereParameters)
                            : base(controllereParameters)
        {
        }

        [HttpPost]
        [Authorize]
        [TypeFilter(typeof(CustomizedAuthorize), Arguments = new object[] { Feature.CreateRole })]
        public async Task<ResultDTO> CreateRole(RoleCreateRequest roleCreateRequest)
        {
            var roleCreateDTO = roleCreateRequest.MapOne<RoleCreateDTO>();
            var command = new CreateRoleCommand(roleCreateDTO);
            var result = await _mediator.Send(command);
            return result;
        }


    }
}
