using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FoodRecipe.Common;
using FoodRecipe.Common.DTOs;
using FoodRecipe.Common.Helpers;
using StayCation.VerticalSlicing.Features.Users.Register;
using StayCation.VerticalSlicing.Features.Users.Register.Commands;

namespace FoodRecipe.Features.Users.Register
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : BaseController
    {
        public RegisterController(ControllereParameters controllereParameters) : base(controllereParameters)
        {
        }

        [HttpPost]
        public async Task<ResultDTO> Register(UserRegisterRequest user)
        {
            var result = await _mediator.Send(user.MapOne<RegisterUserCommand>());

            return result;
        }

    }
}
