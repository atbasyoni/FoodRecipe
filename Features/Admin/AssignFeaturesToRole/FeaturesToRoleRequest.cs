using FoodRecipe.Common.Enums;

namespace FoodRecipe.Features.Admin.AssignFeaturesToRole
{
    public class FeaturesToRoleRequest
    {
        public List<Feature> Features { get; set; }
        public int RoleId { get; set; }
    }
}
