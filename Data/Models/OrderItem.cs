namespace FoodRecipe.Data.Models
{
    public class OrderItem : BaseModel
    {
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
