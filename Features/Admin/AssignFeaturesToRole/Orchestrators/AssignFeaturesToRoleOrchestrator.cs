using MediatR;
using FoodRecipe.Common;
using FoodRecipe.Common.DTOs;
using FoodRecipe.Common.Helpers;
using FoodRecipe.Data.Models;
using FoodRecipe.Features.Admin.GetSingleRole.Queries;
using StayCation.VerticalSlicing.Features.Admin.GetSingleRole;


namespace FoodRecipe.Features.Admin.AssignFeaturesToRole.Orchestrators
{
    public record AssignFeaturesToRoleOrchestrator(FeaturesToRoleDTO FeaturesToRoleDTO) : IRequest<ResultDTO>;

    public class AssignFeaturesToRoleOrchestratorHandler : BaseRequestHandler<RoleFeature, AssignFeaturesToRoleOrchestrator, ResultDTO>
    {
        public AssignFeaturesToRoleOrchestratorHandler(RequestParameters<RoleFeature> requestParameters)
                                    : base(requestParameters)
        {
        }

        public override async Task<ResultDTO> Handle(AssignFeaturesToRoleOrchestrator request, CancellationToken cancellationToken)
        {
            if (request == null || request.FeaturesToRoleDTO == null || !request.FeaturesToRoleDTO.Features.Any())
            {
                return ResultDTO.Failure("Invalid inputs!");
            }

            var role = await _mediator.Send(new GetRoleByIdQuery(request.FeaturesToRoleDTO.RoleId));
            //var role = await _repository.GetByIdAsync(request.addFeaturesToRuleDTO.RoleId);
            if (role == null)
            {
                return ResultDTO.Failure("Invalid RoleID!");
            }

            foreach (var feature in request.FeaturesToRoleDTO.Features)
            {
                var existingRoleFeature = await _repository.First(
                    rf => rf.RoleID == request.FeaturesToRoleDTO.RoleId && rf.Feature == feature
                );

                if (existingRoleFeature == null)
                {
                    var roleFeature = new RoleFeature
                    {
                        RoleID = request.FeaturesToRoleDTO.RoleId,
                        Feature = feature
                    };

                    await _repository.AddAsync(roleFeature);
                }
            }

            await _repository.SaveChangesAsync();

            return ResultDTO.Success(true,"Features assigned to role successfully!");
        }
    }
}
