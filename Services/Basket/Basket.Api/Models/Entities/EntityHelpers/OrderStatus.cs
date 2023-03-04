using Google.Protobuf.WellKnownTypes;
using System.Runtime.Serialization;

namespace Basket.Api.Models.Entities.EntityHelpers
{
    public enum OrderStatus
    {
        [EnumMember(Value = "Pending")]
        Pending,

        [EnumMember(Value = "Payment Recevied")]
        PaymentRecevied,

        [EnumMember(Value = "Payment Failed")]
        PaymentFailed
    }
}
