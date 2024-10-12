using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FoodRecipe.Common;
using FoodRecipe.Common.Attributes;
using FoodRecipe.Common.DTOs;
using FoodRecipe.Common.Enums;
using FoodRecipe.Common.Helpers;
using FoodRecipe.Features.Admin.AssignFeaturesToRole.Orchestrators;
using StayCation.VerticalSlicing.Features.Admin.GetSingleRole;

namespace FoodRecipe.Features.Admin.AssignFeaturesToRole
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignFeaturesToRoleController : BaseController
    {
        public AssignFeaturesToRoleController(ControllereParameters controllereParameters)
                            : base(controllereParameters)
        {
        }

        [HttpPost]
        [Authorize]
        [TypeFilter(typeof(CustomizedAuthorize), Arguments = new object[] { Feature.AssignFeaturesToRole })]
        public async Task<ResultDTO> AssignFeaturesToRole(FeaturesToRoleRequest featuresToRoleRequest)
        {
            var featuresToRoleDTO = featuresToRoleRequest.MapOne<FeaturesToRoleDTO>();
            var result = await _mediator.Send(new AssignFeaturesToRoleOrchestrator(featuresToRoleDTO));
            return result;
        }
    }
}
