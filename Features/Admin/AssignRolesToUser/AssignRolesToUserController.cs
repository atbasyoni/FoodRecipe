using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FoodRecipe.Common;
using FoodRecipe.Common.Attributes;
using FoodRecipe.Common.DTOs;
using FoodRecipe.Common.Enums;
using FoodRecipe.Common.Helpers;
using FoodRecipe.Features.Admin.AssignRolesToUser.Orchestrators;
using StayCation.VerticalSlicing.Features.Admin.AssignRolesToUser;

namespace FoodRecipe.Features.Admin.AssignRolesToUser
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignRolesToUserController : BaseController
    {
        public AssignRolesToUserController(ControllereParameters controllereParameters)
                            : base(controllereParameters)
        {
        }

        [HttpPost]
        [Authorize]
        [TypeFilter(typeof(CustomizedAuthorize), Arguments = new object[] { Feature.AssignRolesToUser })]
        public async Task<ResultDTO> AssignRolesToUser(RolesToUserRequest rolesToUserRequest)
        {
            var rolesToUserDTO = rolesToUserRequest.MapOne<RolesToUserDTO>();

            var result = await _mediator.Send(new AssignRolesToUserOrchestrator(rolesToUserDTO));

            return result;
        }
    }
}
