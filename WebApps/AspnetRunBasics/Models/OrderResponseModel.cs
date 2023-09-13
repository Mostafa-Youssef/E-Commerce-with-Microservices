namespace AspnetRunBasics.Models
{
    public class OrderResponseModel
    {
        public string UserName { get; set; }
        public decimal TotalPrice { get; set; }
        public AddressDto Addres { get; set; }
        public PaymentDto payment { get; set; }
    }
}
