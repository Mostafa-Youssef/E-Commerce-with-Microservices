using Basket.Api.Models.Entities.EntityHelpers;
using System.ComponentModel.DataAnnotations.Schema;

namespace Basket.Api.Models.Entities
{
    public class BasketCheckout
    {
        public string UserName { get; set; }
        public decimal TotalPrice { get; set; }
        public int DeliveryMethodId { get; set; }
        public string Status { get; set; } 



        #region Owend by order see conifiguration

        public Address Address { get; set; }
        public Payment Payment { get; set; }

        #endregion
    }
}
