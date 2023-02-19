using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Ordering.Application.Abstractions.Messaging;
using Ordering.Application.Contracts.Infrastructure;
using Ordering.Application.Contracts.Persistence;
using Ordering.Application.Models;
using Ordering.Domain.Entities;

namespace Ordering.Application.Features.Orders.Commands.CheckoutOrder
{
    public class CheckoutOrderCommandHandler : ICommandHandler<CheckoutOrderCommand, Guid>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IEmailService _emailService;
        private readonly ILogger<CheckoutOrderCommandHandler> _logger;
        private readonly IMapper _mapper;

        public CheckoutOrderCommandHandler(IOrderRepository orderRepository,
                                           IEmailService emailService, ILogger<CheckoutOrderCommandHandler> logger, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _emailService = emailService;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CheckoutOrderCommand request, CancellationToken cancellationToken)
        {
            var orderEntity = _mapper.Map<Order>(request);
            var newOrder = await _orderRepository.AddAsync(orderEntity);

            _logger.LogInformation($"Order {newOrder.Id} is successfully created");

            await SendMail(newOrder);

            return newOrder.Id;
        }

        private async Task SendMail(Order order)
        {
            var email = new Email() { To = "mostafa.ahmed.2.7.1998@gmail.com", Body = $"Order was created.", Subject = "Order was created" };

            try
            {
                await _emailService.SendEmail(email);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Order {order.Id} failed due to an error with the mail service: {ex.Message}");
            }
        }
    }
}
