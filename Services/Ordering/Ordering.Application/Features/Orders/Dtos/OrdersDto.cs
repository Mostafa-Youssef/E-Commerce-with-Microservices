namespace Ordering.Application.Features.Orders.Dtos
{
    public class OrdersDto
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
