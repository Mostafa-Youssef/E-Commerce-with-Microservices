namespace Shopping.Aggregator.Models
{
    public class BasketModel
    {
        public string UserName { get; set; }
        public decimal TotalPrice { get; set; }
        public List<BasketItemExtendedModel> Item { get; set; } = new List<BasketItemExtendedModel>();

    }
}
