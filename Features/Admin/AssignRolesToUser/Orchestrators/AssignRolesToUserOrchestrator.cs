using MediatR;
using FoodRecipe.Common.Helpers;
using FoodRecipe.Common;
using FoodRecipe.Data.Models;
using FoodRecipe.Common.DTOs;
using FoodRecipe.Features.Users.GetUserById.Queries;


namespace FoodRecipe.Features.Admin.AssignRolesToUser.Orchestrators
{
    public record AssignRolesToUserOrchestrator(RolesToUserDTO RolesToUserDTO) : IRequest<ResultDTO>;

    public class AssignRolesToUserOrchestratorHandler : BaseRequestHandler<UserRole, AssignRolesToUserOrchestrator, ResultDTO>
    {
        public AssignRolesToUserOrchestratorHandler(RequestParameters<UserRole> requestParameters)
                                    : base(requestParameters)
        {
        }

        public override async Task<ResultDTO> Handle(AssignRolesToUserOrchestrator request, CancellationToken cancellationToken)
        {
            if (request == null || request.RolesToUserDTO == null || !request.RolesToUserDTO.RoleIds.Any())
            {
                return ResultDTO.Failure("Invalid inputs!");
            }

            var user = await _mediator.Send(new GetUserByIdQuery(request.RolesToUserDTO.UserId));
            //var role = await _repository.GetByIdAsync(request.addFeaturesToRuleDTO.RoleId);
            if (user == null)
            {
                return ResultDTO.Failure("User is not found!");
            }

            foreach (var roleId in request.RolesToUserDTO.RoleIds)
            {
                var existingUserRole = await _repository.First(
                    ur => ur.UserId == request.RolesToUserDTO.UserId && ur.RoleId == roleId
                );

                if (existingUserRole == null)
                {
                    var userRole = new UserRole
                    {
                        UserId = request.RolesToUserDTO.UserId,
                        RoleId = roleId
                    };

                    await _repository.AddAsync(userRole);
                }
            }

            await _repository.SaveChangesAsync();

            return ResultDTO.Success("Roles assigned to user successfully!");
        }
    }
}
