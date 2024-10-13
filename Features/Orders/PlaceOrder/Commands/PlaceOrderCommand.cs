using FoodRecipe.Common;
using FoodRecipe.Common.DTOs;
using FoodRecipe.Common.Helpers;
using FoodRecipe.Data.Models;
using MassTransit;
using MediatR;

namespace FoodRecipe.Features.Orders.PlaceOrder.Commands
{
    public record PlaceOrderCommand(int UserId, List<PlaceOrderItemDTO> OrderItems) : IRequest<ResultDTO>;
    public class PlaceOrderCommandHandler : BaseRequestHandler<Order, PlaceOrderCommand, ResultDTO>
    {
        public PlaceOrderCommandHandler(RequestParameters<Order> requestParameters) : base(requestParameters)
        {
        }

        public override async Task<ResultDTO> Handle(PlaceOrderCommand request, CancellationToken cancellationToken)
        {
            var order = request.MapOne<Order>();

            order = await _repository.AddAsync(order);
            await _repository.SaveChangesAsync();

            return ResultDTO.Success(order);
        }
    }
}
