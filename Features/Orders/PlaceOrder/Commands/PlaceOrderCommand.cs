using FoodRecipe.Common;
using FoodRecipe.Common.DTOs;
using FoodRecipe.Common.Helpers;
using FoodRecipe.Data.Models;
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
            var recipe = request.MapOne<Order>();
            await _repository.AddAsync(recipe);

            return ResultDTO.Success(recipe);
        }
    }
}
