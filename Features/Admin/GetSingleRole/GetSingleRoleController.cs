using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FoodRecipe.Common;
using FoodRecipe.Common.Attributes;
using FoodRecipe.Common.DTOs;
using FoodRecipe.Common.Enums;
using FoodRecipe.Features.Admin.GetSingleRole.Queries;

namespace FoodRecipe.Features.Admin.GetSingleRole
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetSingleRoleController : BaseController
    {
        public GetSingleRoleController(ControllereParameters controllereParameters)
                            : base(controllereParameters)
        {
        }

        [HttpGet("{id}")]
        [Authorize]
        [TypeFilter(typeof(CustomizedAuthorize), Arguments = new object[] { Feature.GetSingleRole })]
        public async Task<ResultDTO> GetSingleRole(int id)
        {
            var role = await _mediator.Send(new GetRoleByIdQuery(id));
            return role;
        }
    }
}
