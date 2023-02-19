using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Ordering.Domain.Common;
using Ordering.Domain.Entities.EntityHelpers;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ordering.Domain.Entities
{
    public class Order : EntityBase
    {
        public string UserName { get; set; }
        public decimal TotalPrice { get; set; }
        public int DeliveryMethodId { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public OrderStatus Status { get; set; } = OrderStatus.Pending;

        public DeliveryMethod DeliveryMethod { get; set; }


        #region Owend by order see conifiguration

        public Address Address { get; set; }
        public Payment Payment { get; set; }

        #endregion
    }
}
