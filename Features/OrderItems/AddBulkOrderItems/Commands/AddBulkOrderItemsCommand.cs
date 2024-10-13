using FoodRecipe.Common;
using FoodRecipe.Common.DTOs;
using FoodRecipe.Common.Helpers;
using FoodRecipe.Data.Models;
using FoodRecipe.Features.Orders.PlaceOrder;
using MediatR;

namespace FoodRecipe.Features.OrderItems.AddBulkOrderItems.Commands
{
    public record AddBulkOrderItemsCommand(int OrderId, List<PlaceOrderItemDTO> OrderItems) : IRequest<ResultDTO>;

    public class AddBulkOrderItemsCommandHandler : BaseRequestHandler<OrderItem, AddBulkOrderItemsCommand, ResultDTO>
    {
        public AddBulkOrderItemsCommandHandler(RequestParameters<OrderItem> requestParameters) : base(requestParameters)
        {
        }

        public override async Task<ResultDTO> Handle(AddBulkOrderItemsCommand request, CancellationToken cancellationToken)
        {
            foreach (var item in request.OrderItems)
            {
                var orderItem = item.MapOne<OrderItem>();
                orderItem.OrderId = request.OrderId;

                await _repository.AddAsync(orderItem);
            }

            await _repository.SaveChangesAsync();

            return ResultDTO.Success(true, "Order Items Added Successfully!");
        }
    }
}
