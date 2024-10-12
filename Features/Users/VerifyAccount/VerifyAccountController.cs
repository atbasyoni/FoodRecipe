using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FoodRecipe.Common;
using FoodRecipe.Common.DTOs;
using FoodRecipe.Common.Helpers;
using FoodRecipe.Features.Users.VerifyAccount.Commands;

namespace FoodRecipe.Features.Users.VerifyAccount
{
    [Route("api/[controller]")]
    [ApiController]
    public class VerifyAccountController : BaseController
    {

        public VerifyAccountController(ControllereParameters controllereParameters) : base(controllereParameters)
        {
        }

        [HttpPost]
        public async Task<ResultDTO> VerifyAccount(VerifyAccountRequest verifyAccountRequest)
        {

            var resultDTO = await _mediator.Send(verifyAccountRequest.MapOne<VerifyAccountCommand>());

            return resultDTO;
        }
    }
}
