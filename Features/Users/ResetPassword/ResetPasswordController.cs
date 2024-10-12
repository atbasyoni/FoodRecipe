using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FoodRecipe.Common;
using FoodRecipe.Common.DTOs;
using FoodRecipe.Common.Helpers;
using FoodRecipe.Features.Users.ResetPassword.Commands;

namespace FoodRecipe.Features.Users.ResetPassword
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResetPasswordController : BaseController
    {

        public ResetPasswordController(ControllereParameters controllereParameters) : base(controllereParameters)
        {
        }

        [HttpPost]
        [Authorize]
        public async Task<ResultDTO> ResetPassword(ResetPasswordRequest resetPasswordRequest)
        {

            var resultDTO = await _mediator.Send(resetPasswordRequest.MapOne<ResetPasswordCommand>());

            
            return resultDTO;
        }
    }
}
