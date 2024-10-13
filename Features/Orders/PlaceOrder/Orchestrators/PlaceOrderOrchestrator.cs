using FoodRecipe.Common.DTOs;
using FoodRecipe.Common.Helpers;
using FoodRecipe.Features.OrderItems.AddBulkOrderItems.Commands;
using FoodRecipe.Features.Orders.PlaceOrder.Commands;
using FoodRecipe.Features.Orders.PlaceOrder.Events;
using MassTransit;
using MediatR;

namespace FoodRecipe.Features.Orders.PlaceOrder.Orchestrators
{
    public record PlaceOrderOrchestrator(int UserId, List<PlaceOrderItemDTO> OrderItems) : IRequest<ResultDTO>;

    public class PlaceOrderOrchestratorHandler : IRequestHandler<PlaceOrderOrchestrator, ResultDTO>
    {
        IMediator _mediator;
        IPublishEndpoint _publishEndpoint;

        public PlaceOrderOrchestratorHandler(IMediator mediator, IPublishEndpoint publishEndpoint)
        {
            _mediator = mediator;
            _publishEndpoint = publishEndpoint;
        }

        public async Task<ResultDTO> Handle(PlaceOrderOrchestrator request, CancellationToken cancellationToken)
        {
            var placedOrderResult = await _mediator.Send(new PlaceOrderCommand(request.UserId, request.OrderItems));
            
            if (!placedOrderResult.IsSuccess)
                return placedOrderResult;

            var orderItemsResult = await _mediator.Send(new AddBulkOrderItemsCommand(placedOrderResult.Data.Id, request.OrderItems));

            if (!orderItemsResult.IsSuccess) 
                return orderItemsResult;

            await _publishEndpoint.Publish(new OrderPlacedEvent
            {
                OrderId = placedOrderResult.Data.Id,
                OrderItems = request.OrderItems.AsQueryable().Map<OrderItemEvent>()
            });

            return placedOrderResult;
        }
    }
}
