﻿using MediatR;
using FoodRecipe.Common;
using FoodRecipe.Common.DTOs;
using FoodRecipe.Common.Helpers;
using FoodRecipe.Data.Models;
using StayCation.VerticalSlicing.Features.Admin.CreateRole;


namespace FoodRecipe.Features.Admin.CreateRole.Commands
{
    public record CreateRoleCommand(RoleCreateDTO RoleCreateDTO) : IRequest<ResultDTO>;

    public class CreateRoleCommandHandler : BaseRequestHandler<Role, CreateRoleCommand, ResultDTO>
    {
        public CreateRoleCommandHandler(RequestParameters<Role> requestParameters)
                                    : base(requestParameters)
        {
        }

        public override async Task<ResultDTO> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            if(request.RoleCreateDTO.Name == null)
            {
                return ResultDTO.Failure("Name is required");

            }
            var roleFound = await _repository.First(r => r.Name == request.RoleCreateDTO.Name);

            if (roleFound is not null)
            {
                return ResultDTO.Failure("Role with that name already exits!");
            }

            var role = request.RoleCreateDTO.MapOne<Role>();
            await _repository.AddAsync(role);
            await _repository.SaveChangesAsync();
            return ResultDTO.Success(role,"Role has been created successfully!");
        }
    }
}
