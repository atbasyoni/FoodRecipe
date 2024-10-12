using MediatR;
using FoodRecipe.Common.Helpers;
using FoodRecipe.Common;
using FoodRecipe.Data.Models;
using FoodRecipe.Common.DTOs;
using Microsoft.EntityFrameworkCore;

namespace FoodRecipe.Features.Users.VerifyAccount.Commands
{
    public record VerifyAccountCommand() : IRequest<ResultDTO>
    {
        public string EmailAddress { get; set; }
        public string OTP { get; set; }
    }

    public class VerifyAccountCommandHandler : BaseRequestHandler<User, VerifyAccountCommand, ResultDTO>
    {

        public VerifyAccountCommandHandler(RequestParameters<User> requestParameters) : base(requestParameters)
        {
        }

        public override async Task<ResultDTO> Handle(VerifyAccountCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetAll()
                                .Where(u => u.EmailAddress == request.EmailAddress &&
                                            u.OTP == request.OTP &&
                                            !u.IsEmailVerified)
                                .FirstOrDefaultAsync();


            if (user is null)
            {
                return ResultDTO.Failure("Email or OTP is incorrect");
            }

            user.IsEmailVerified = true;

            _repository.Update(user);

            await _repository.SaveChangesAsync();

            return ResultDTO.Success(true, "Verify Account Successfully!");
        }

    }
}
