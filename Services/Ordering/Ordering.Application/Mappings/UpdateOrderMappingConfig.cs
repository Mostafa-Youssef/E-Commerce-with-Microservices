using Mapster;
using Ordering.Application.Features.Orders.Commands.UpdateOrder;
using Ordering.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Mappings
{
    public class UpdateOrderMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<UpdateOrderCommand, Order>()
                .Map(desc => desc.Address, src => src.Addres)
                .Map(desc => desc.Payment, src => src.payment);

        }
    }
}
