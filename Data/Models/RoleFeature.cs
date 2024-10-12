
using FoodRecipe.Common.Enums;

namespace FoodRecipe.Data.Models
{
    public class RoleFeature : BaseModel
    {
        public int RoleID { get; set; }
        public Role Role { get; set; }

        public Feature Feature { get; set; }
    }
}
