﻿namespace FoodRecipe.Data.Models
{
    public class BaseModel
    {
        public int Id { get; set; }
        public bool Deleted { get; set; } = false;
    }
}
