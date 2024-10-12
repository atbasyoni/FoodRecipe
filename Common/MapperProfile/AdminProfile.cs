using AutoMapper;
using FoodRecipe.Data.Models;
using FoodRecipe.Features.Admin.AssignFeaturesToRole;
using FoodRecipe.Features.Admin.AssignRolesToUser;
using FoodRecipe.Features.Admin.CreateRole;
using StayCation.VerticalSlicing.Features.Admin.CreateRole;
using StayCation.VerticalSlicing.Features.Admin.GetSingleRole;

namespace FoodRecipe.Common.MapperProfile
{
    public class AdminProfile : Profile
    {
        public AdminProfile()
        {
            CreateMap<RoleCreateRequest, RoleCreateDTO>().ReverseMap();
            CreateMap<RoleCreateDTO, Role>().ReverseMap();

            CreateMap<Role, RoleDTO>().ReverseMap();

            CreateMap<RolesToUserRequest, RolesToUserDTO>().ReverseMap();

            CreateMap<FeaturesToRoleRequest, FeaturesToRoleDTO>().ReverseMap();
        }
    }
}
