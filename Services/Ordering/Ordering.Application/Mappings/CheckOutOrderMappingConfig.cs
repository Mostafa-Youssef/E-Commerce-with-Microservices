using Mapster;
using Ordering.Application.Features.Orders.Commands.CheckoutOrder;
using Ordering.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Mappings
{
    public class CheckOutOrderMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CheckoutOrderCommand, Order>()
                //.Map(dest => dest.UserName, src => src.UserName)
                .Map(dest => dest.Address, src => src.Addres)
                .Map(dest => dest.Payment, src => src.payment);
        }
    }
}
