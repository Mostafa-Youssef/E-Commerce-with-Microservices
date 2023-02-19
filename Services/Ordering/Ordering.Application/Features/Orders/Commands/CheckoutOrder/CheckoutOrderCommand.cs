using MediatR;
using Ordering.Application.Abstractions.Messaging;
using Ordering.Application.Features.Orders.Dtos;

namespace Ordering.Application.Features.Orders.Commands.CheckoutOrder
{
    public class CheckoutOrderCommand : ICommand<Guid>
    {
        public string UserName { get; set; }
        public decimal TotalPrice { get; set; }
        public int DeliveryMethodId { get; set; }
        public string Status { get; set; }
        public AddressDto Addres { get; set; }
        public PaymentDto payment { get; set; }
    }
}
