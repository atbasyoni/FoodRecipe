using MediatR;
using Microsoft.EntityFrameworkCore;
using FoodRecipe.Common.Helpers;
using FoodRecipe.Common;
using FoodRecipe.Data.Models;
using FoodRecipe.Common.Enums;


namespace FoodRecipe.Features.Admin.AssignFeaturesToRole.Queries
{
    public record CheckRoleFeatureAccessQuery(int roleID, Feature feature) : IRequest<bool>;
    public class CheckRoleFeatureAccessQueryHandler : BaseRequestHandler<RoleFeature, CheckRoleFeatureAccessQuery, bool>
    {
        public CheckRoleFeatureAccessQueryHandler(RequestParameters<RoleFeature> requestParameters)
                                    : base(requestParameters)
        {
        }
        public override async Task<bool> Handle(CheckRoleFeatureAccessQuery request, CancellationToken cancellationToken)
        {
            var hasAccess = await _repository.Get(r => !r.Deleted &&
                        r.RoleID == request.roleID &&
                        r.Feature == request.feature)
                        .AnyAsync();

            return hasAccess;
        }
    }
}
