using Mapster;
using MapsterMapper;
using MediatR;
using Ordering.Application.Contracts.Persistence;
using Ordering.Application.Features.Orders.Dtos;

namespace Ordering.Application.Features.Orders.Queries.GetOrdersList
{
    public class GetOrdersListQueryHandler : IRequestHandler<GetOrdersListQuery, List<OrdersDto>>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrdersListQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<List<OrdersDto>> Handle(GetOrdersListQuery request, CancellationToken cancellationToken)
        {
            var orderList = await _orderRepository.GetOdersByUserName(request.UserName);
            return orderList.Adapt<List<OrdersDto>>();
        }
    }
}
