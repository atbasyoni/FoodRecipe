using FoodRecipe.Common.Enums;

namespace FoodRecipe.Data.Models
{
    public class Order : BaseModel
    {
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public OrderStatus OrderStatus { get; set; } = OrderStatus.Pending;
        public decimal Total { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
