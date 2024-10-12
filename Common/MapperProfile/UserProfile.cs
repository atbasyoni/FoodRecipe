using AutoMapper;
using FoodRecipe.Common.DTOs;
using FoodRecipe.Data.Models;
using FoodRecipe.Features.Users.ChangePassword;
using FoodRecipe.Features.Users.Login;
using FoodRecipe.Features.Users.Register;
using FoodRecipe.Features.Users.ResetPassword;
using FoodRecipe.Features.Users.ResetPassword.Commands;
using FoodRecipe.Features.Users.VerifyAccount;
using FoodRecipe.Features.Users.VerifyAccount.Commands;
using StayCation.VerticalSlicing.Features.Users.Login.Commands;
using StayCation.VerticalSlicing.Features.Users.Register;
using StayCation.VerticalSlicing.Features.Users.Register.Commands;

namespace FoodRecipe.Common.MapperProfile
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {

            CreateMap<User, UserForTokenDTO>().ReverseMap();
                //.ForMember(dest => dest.RoleIds, opt => opt.MapFrom(src => src.UserRoles.Select(ur => ur.RoleId).ToList()));

            CreateMap<User, ChangePasswordDTO>().ReverseMap();

            CreateMap<UserRegisterRequest, RegisterUserCommand>().ReverseMap();
            CreateMap<User, RegisterUserCommand>().ReverseMap();
            CreateMap<User, UserRegisterDTO>().ReverseMap();

            CreateMap<UserLoginRequest, LoginUserCommand>().ReverseMap();

            CreateMap<ResetPasswordRequest, ResetPasswordCommand>().ReverseMap();

            CreateMap<VerifyAccountRequest, VerifyAccountCommand>().ReverseMap();
        }
    }
}
