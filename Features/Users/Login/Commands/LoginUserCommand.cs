using MediatR;
using FoodRecipe.Common.DTOs;
using FoodRecipe.Common;
using FoodRecipe.Common.Helpers;
using FoodRecipe.Data.Models;
using FoodRecipe.Features.Users.Login;

namespace StayCation.VerticalSlicing.Features.Users.Login.Commands
{
    public class LoginUserCommand() : IRequest<ResultDTO>
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }
    }

    public class LoginUserCommandHandler : BaseRequestHandler<User, LoginUserCommand, ResultDTO>
    {
        public LoginUserCommandHandler(RequestParameters<User> requestParameters) 
                                    : base(requestParameters)
        {
        }

        public override async Task<ResultDTO> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.First(u => u.EmailAddress == request.EmailAddress
                                                    //&& u.IsEmailVerified
                                                    );

            if (user is null || !BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
            {
                return ResultDTO.Failure("Email or Password is incorrect");
            }
            _userState.Id = user.Id.ToString();
            _userState.Email = user.EmailAddress;
            _userState.UserName = user.UserName;
            var userDTO = user.MapOne<UserForTokenDTO>();
            var token = TokenGenerator.GenerateToken(userDTO);

            return ResultDTO.Success(token, "User is logged in!");
        }
    }
}
