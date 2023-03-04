using EventBus.Messages.Events.EntityHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.Messages.Events
{
    public class BasketCheckoutEvent : IntegrationBaseEvents
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
