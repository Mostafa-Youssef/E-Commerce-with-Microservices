namespace AspnetRunBasics.Models
{
    public class BasketCheckoutModel
    {
        public string UserName { get; set; }
        public decimal TotalPrice { get; set; }
        public int DeliveryMethodId { get; set; }
        public AddressDto Addres { get; set; }
        public PaymentDto payment { get; set; }
    }
}
