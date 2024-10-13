using FoodRecipe.Common;
using FoodRecipe.Common.DTOs;
using FoodRecipe.Common.Helpers;
using FoodRecipe.Data.Models;
using MediatR;

namespace FoodRecipe.Features.OrderItems.AddOrderItem.Commands
{
    public record AddOrderItemCommand(int OrderId, int RecipeId, int Quantity) : IRequest<ResultDTO>;

    public class AddOrderItemCommandHandler : BaseRequestHandler<OrderItem, AddOrderItemCommand, ResultDTO>
    {
        public AddOrderItemCommandHandler(RequestParameters<OrderItem> requestParameters) : base(requestParameters)
        {
        }

        public override async Task<ResultDTO> Handle(AddOrderItemCommand request, CancellationToken cancellationToken)
        {
            var OrderItem = request.MapOne<OrderItem>();
            OrderItem = await _repository.AddAsync(OrderItem);

            return ResultDTO.Success(OrderItem);
        }
    }
}
