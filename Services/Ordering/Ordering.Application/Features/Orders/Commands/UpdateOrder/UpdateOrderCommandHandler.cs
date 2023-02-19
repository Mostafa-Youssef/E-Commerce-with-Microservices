using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Ordering.Application.Contracts.Persistence;
using Ordering.Application.Exceptions;
using Ordering.Domain.Entities;

namespace Ordering.Application.Features.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ILogger<UpdateOrderCommandHandler> _logger;
        private readonly IMapper _mapper;

        public UpdateOrderCommandHandler(IOrderRepository orderRepository, ILogger<UpdateOrderCommandHandler> logger, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var orderToUpdate = await _orderRepository.GetByIdAsync(request.Id);
            if (orderToUpdate == null)
            {
                throw new NotFoundException(nameof(Order));
            }

            //orderToUpdate = _mapper.Map<Order>(request);
            _mapper.Map(request, orderToUpdate);

            await _orderRepository.UpdateAsync(orderToUpdate);

            _logger.LogInformation($"Order {orderToUpdate.Id} is successfully updated");

            return Unit.Value;
        }
    }
}
