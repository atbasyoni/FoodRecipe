﻿namespace FoodRecipe.Features.Orders.PlaceOrder.Events
{
    public class OrderPlacedEvent
    {
        public int OrderId { get; set; }
        public IEnumerable<OrderItemEvent> OrderItems { get; set; }
    }
}
