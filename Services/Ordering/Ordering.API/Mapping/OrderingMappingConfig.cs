using EventBus.Messages.Events;
using Mapster;
using Ordering.Application.Features.Orders.Commands.CheckoutOrder;

namespace Ordering.API.Mapping
{
    public class OrderingMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<BasketCheckoutEvent, CheckoutOrderCommand>().TwoWays()
                .Map(dest => dest.Addres, src => src.Address)
                .Map(dest => dest.payment, src => src.Payment);
        }
    }
}
