using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FoodRecipe.Common;
using FoodRecipe.Common.DTOs;
using FoodRecipe.Common.Helpers;
using StayCation.VerticalSlicing.Features.Users.Login.Commands;

namespace FoodRecipe.Features.Users.Login
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : BaseController
    {
        public LoginController(ControllereParameters controllereParameters) 
                            : base(controllereParameters)
        {
        }

        [HttpPost]
        public async Task<ResultDTO> Login(UserLoginRequest user)
        {

            var result = await _mediator.Send(user.MapOne<LoginUserCommand>());

            return result;
        }
    }
}
