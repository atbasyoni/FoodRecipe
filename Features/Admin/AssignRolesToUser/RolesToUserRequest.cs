﻿namespace FoodRecipe.Features.Admin.AssignRolesToUser
{
    public class RolesToUserRequest
    {
        public List<int> RoleIds { get; set; }
        public int UserId { get; set; }
    }
}
