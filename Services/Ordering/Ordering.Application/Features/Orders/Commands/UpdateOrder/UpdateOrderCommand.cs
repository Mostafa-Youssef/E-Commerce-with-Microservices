using MediatR;
using Ordering.Application.Features.Orders.Dtos;

namespace Ordering.Application.Features.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommand : IRequest
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public decimal TotalPrice { get; set; }
        public int DeliveryMethodId { get; set; }
        public string Status { get; set; }
        public AddressDto Addres { get; set; }
        public PaymentDto payment { get; set; }
    }
}
